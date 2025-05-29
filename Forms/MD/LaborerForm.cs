using RECMS.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RECMS.Forms.MD
{
    public partial class LaborerForm : Form
    {

        string connectionString = DatabaseHelper.GetConnectionString();

        private string projectId;
        private DataTable workersTable;
        public LaborerForm(string projectId, string connectionString)
        {
            InitializeComponent();
            this.projectId = projectId;
            this.connectionString = connectionString;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            // Find and show the ProjectDetailsForm
            foreach (Form form in Application.OpenForms)
            {
                if (form is ProjectDetailsForm)
                {
                    form.Show(); // Show the ProjectDetailsForm
                    form.WindowState = FormWindowState.Normal; // Restore if minimized
                    break;
                }
            }

            // Close the current ProjectReportForm
            this.Close();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                await conn.OpenAsync();
                using (SqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        string workerId = await GetOrCreateWorker(conn, transaction);
                        await CreateLaborEntry(conn, transaction, workerId);

                        transaction.Commit();
                        MessageBox.Show("Entry saved successfully!");
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show($"Error: {ex.Message}\nChanges were rolled back.");
                    }
                }
            }
        }

        private bool ValidateInputs()
        {

            // Validate laborer name
            if (!Regex.IsMatch(cmbLaborer.Text, @"^[a-zA-Z ]+$"))
            {
                MessageBox.Show("Invalid laborer name! Only letters and spaces allowed.");
                return false;
            }

            // Validate role
            if (!Regex.IsMatch(cmbRole.Text, @"^[a-zA-Z ]+$"))
            {
                MessageBox.Show("Invalid role! Only letters and spaces allowed.");
                return false;
            }

            // Validate numeric values
            if (numDays.Value <= 0)
            {
                MessageBox.Show("Days worked must be greater than 0!");
                return false;
            }

            if (numRate.Value <= 0)
            {
                MessageBox.Show("Rate must be greater than 0!");
                return false;
            }

            if (string.IsNullOrWhiteSpace(cmbLaborer.Text))
            {
                MessageBox.Show("Laborer name is required!");
                return false;
            }

            if (numDays.Value <= 0)
            {
                MessageBox.Show("Days worked must be greater than 0!");
                return false;
            }

            if (numRate.Value <= 0)
            {
                MessageBox.Show("Rate must be greater than 0!");
                return false;
            }

            return true;
        }

        private async Task<string> GetOrCreateWorker(SqlConnection conn, SqlTransaction transaction)
        {
            // If existing worker selected
            if (cmbLaborer.SelectedValue != null)
                return cmbLaborer.SelectedValue.ToString();

            // Confirm new worker creation
            if (MessageBox.Show($"Add new worker '{cmbLaborer.Text}'?", "Confirm New Worker",
                MessageBoxButtons.YesNo) != DialogResult.Yes)
                throw new Exception("Worker creation canceled");

            // Get/Create Role and Contractor
            string roleId = await GetOrCreateEntity(cmbRole, "role", "Labor", "RoleName", "RoleID", conn, transaction);
            string contractorId = await GetOrCreateEntity(cmbContractor, "contractor", "Contractors", "ContractorName", "ContractorID", conn, transaction);

            // Create new worker
            using (SqlCommand cmd = new SqlCommand(
                @"INSERT INTO Workers (WorkerName, RoleID, ContractorID) 
          OUTPUT INSERTED.WorkerID
          VALUES (@Name, @RoleID, @ContractorID)", conn, transaction))
            {
                cmd.Parameters.AddWithValue("@Name", cmbLaborer.Text);
                cmd.Parameters.AddWithValue("@RoleID", roleId);
                cmd.Parameters.AddWithValue("@ContractorID", contractorId);
                int newWorkerId = (int)await cmd.ExecuteScalarAsync();
                return newWorkerId.ToString();
            }
        }

        private async Task<string> GetOrCreateEntity(
    ComboBox combo, string entityType, string tableName,
    string nameColumn, string idColumn,
    SqlConnection conn, SqlTransaction transaction)
        {
            string entityName = combo.Text.Trim();

            // Check if the entity exists
            using (SqlCommand checkCmd = new SqlCommand(
                $@"SELECT {idColumn} FROM {tableName} WHERE {nameColumn} = @Name",
                conn, transaction))
            {
                checkCmd.Parameters.AddWithValue("@Name", entityName);
                object existingId = await checkCmd.ExecuteScalarAsync();

                if (existingId != null)
                {
                    return existingId.ToString();
                }
            }

            // Confirm creation
            if (MessageBox.Show($"Add new {entityType} '{entityName}'?", "Confirm",
                MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                throw new Exception($"{entityType} creation canceled");
            }

            // Insert new entity (no Rate for roles)
            using (SqlCommand insertCmd = new SqlCommand(
                $@"INSERT INTO {tableName} ({nameColumn}) 
           VALUES (@Name);
           SELECT SCOPE_IDENTITY();",
                conn, transaction))
            {
                insertCmd.Parameters.AddWithValue("@Name", entityName);
                object newId = await insertCmd.ExecuteScalarAsync();

                // Refresh ComboBox
                DataTable dt = (DataTable)combo.DataSource;
                dt.Clear();
                using (SqlCommand selectCmd = new SqlCommand($"SELECT {idColumn}, {nameColumn} FROM {tableName}", conn, transaction))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(selectCmd))
                    {
                        adapter.Fill(dt);
                    }
                }

                combo.DataSource = dt;
                combo.SelectedValue = newId;

                return newId.ToString();
            }
        }

        private async Task CreateLaborEntry(SqlConnection conn, SqlTransaction transaction, string workerId)
        {
            using (SqlCommand cmd = new SqlCommand(
                @"INSERT INTO ProjectLabor (ProjectID, WorkerID, WorkDate, DaysWorked, Rate)
          VALUES (@ProjectID, @WorkerID, @Date, @Days, @Rate)",
                conn, transaction))
            {
                cmd.Parameters.AddWithValue("@ProjectID", projectId);
                cmd.Parameters.AddWithValue("@WorkerID", int.Parse(workerId));
                cmd.Parameters.AddWithValue("@Date", dtpDate.Value);
                cmd.Parameters.AddWithValue("@Days", numDays.Value);
                cmd.Parameters.AddWithValue("@Rate", numRate.Value);
                await cmd.ExecuteNonQueryAsync();
            }
        }

        private void ComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var combo = (ComboBox)sender;
                if (combo.SelectedIndex == -1 && !string.IsNullOrWhiteSpace(combo.Text))
                {
                    combo.SelectedIndex = -1;
                    combo.SelectedValue = null;
                }
                e.Handled = true;
            }
        }

        private void LaborerForm_Load(object sender, EventArgs e)
        {
            LoadLaborers();
            LoadRoles();
            LoadContractors();

            // Add validation events
            cmbLaborer.KeyPress += ComboBox_KeyPress;
            cmbLaborer.Validating += ComboBox_Validating;
            cmbRole.KeyPress += ComboBox_KeyPress;
            cmbRole.Validating += ComboBox_Validating;

            numDays.KeyPress += NumericUpDown_KeyPress;
            numRate.KeyPress += NumericUpDown_KeyPress;


        }

        private void LoadLaborers()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"SELECT WorkerID, WorkerName FROM Workers";
                workersTable = new DataTable();
                new SqlDataAdapter(query, conn).Fill(workersTable);

                cmbLaborer.DataSource = workersTable;
                cmbLaborer.DisplayMember = "WorkerName";
                cmbLaborer.ValueMember = "WorkerID";
                cmbLaborer.DropDownStyle = ComboBoxStyle.DropDown;
            }
        }

        private void LoadRoles()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    DataTable rolesTable = new DataTable();
                    // Select both RoleName and the primary key (e.g., RoleName itself)
                    new SqlDataAdapter("SELECT RoleName, RoleName AS RoleID FROM Labor", conn).Fill(rolesTable);

                    cmbRole.DataSource = rolesTable;
                    cmbRole.DisplayMember = "RoleName"; // Show the role name
                    cmbRole.ValueMember = "RoleName";    // Use RoleName as the value (if it’s the PK)
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading roles: {ex.Message}");
            }
        }

        private void LoadContractors()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    DataTable contractorsTable = new DataTable();
                    // Select ContractorID and ContractorName
                    new SqlDataAdapter(
                        "SELECT ContractorID, ContractorName FROM Contractors",
                        conn
                    ).Fill(contractorsTable);

                    cmbContractor.DataSource = contractorsTable;
                    cmbContractor.DisplayMember = "ContractorName"; // Show name
                    cmbContractor.ValueMember = "ContractorID";     // Use ID as value
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading contractors: {ex.Message}");
            }
        }

        // Add at class level
        private void ComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != ' ' && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void NumericUpDown_KeyPress(object sender, KeyPressEventArgs e)
        {
            NumericUpDown numeric = (NumericUpDown)sender;
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
               (e.KeyChar != '.' || numeric.DecimalPlaces == 0))
            {
                e.Handled = true;
            }
        }

        private void ComboBox_Validating(object sender, CancelEventArgs e)
        {
            ComboBox combo = (ComboBox)sender;
            if (!Regex.IsMatch(combo.Text, @"^[a-zA-Z ]+$"))
            {
                MessageBox.Show("Only letters and spaces allowed!");
                e.Cancel = true;
            }
        }
    }
}
