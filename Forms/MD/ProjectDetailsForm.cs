using RECMS.Forms.MD;
using RECMS.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RECMS.Forms
{
    public partial class ProjectDetailsForm : Form
    {
        private List<ProjectPhase> modifiedPhases = new List<ProjectPhase>();

        private string connectionString = DatabaseHelper.GetConnectionString();
        private DataView materialDataView; // For filtering materials
        private DataView laborDataView; //For filtering labor
        private DataView imagesDataView;
        private int currentImageIndex = 0;

        public event Action DataUpdated;

        public void AddMaterialToGrid(string[] materialData)
        {
            dgvdatamaterial.Rows.Add(materialData);
        }
        public ProjectDetailsForm()
        {
            InitializeComponent();
            InitializeProgressUI();
            cmbFilterMaterial.SelectedIndexChanged += (s, e) => ApplyFilters();
            cmbFilterSupplier.SelectedIndexChanged += (s, e) => ApplyFilters();
            btnDeleteMaterial.Click += btnDeleteMaterial_Click;
            if (string.IsNullOrEmpty(connectionString))
            {
                MessageBox.Show("Database connection not configured!");
                this.Close();
            }

        }

        public class ProjectPhase
        {
            public string Name { get; set; }
            public decimal Weight { get; set; }
            public bool IsCompleted { get; set; }
        }

        private List<ProjectPhase> projectPhases = new List<ProjectPhase>
{
    // Foundation & Structure
    new ProjectPhase { Name = "Site Preparation", Weight = 5m },
    new ProjectPhase { Name = "Excavation", Weight = 5m },
    new ProjectPhase { Name = "Footings & Foundation", Weight = 10m },
    new ProjectPhase { Name = "Structural Framework (25%)", Weight = 10m },
    new ProjectPhase { Name = "Structural Framework (50%)", Weight = 10m },
    new ProjectPhase { Name = "Structural Framework (100%)", Weight = 10m },
    
    // Enclosure
    new ProjectPhase { Name = "Exterior Walls", Weight = 5m },
    new ProjectPhase { Name = "Roofing", Weight = 5m },
    
    // Interior
    new ProjectPhase { Name = "Electrical Wiring", Weight = 5m },
    new ProjectPhase { Name = "Plumbing", Weight = 5m },
    new ProjectPhase { Name = "HVAC Installation", Weight = 5m },
    new ProjectPhase { Name = "Insulation", Weight = 5m },
    
    // Finishing
    new ProjectPhase { Name = "Drywall Installation", Weight = 5m },
    new ProjectPhase { Name = "Flooring", Weight = 5m },
    new ProjectPhase { Name = "Painting", Weight = 5m },
    new ProjectPhase { Name = "Final Fixtures", Weight = 5m }
};



        private void buttonClose_Click(object sender, EventArgs e)
        {
            // Find the MD_homeForm (if it exists) and show it
            foreach (Form form in Application.OpenForms)
            {
                if (form is MD_homeForm)
                {
                    form.Show(); // Show the hidden MD_homeForm
                    break;
                }
            }

            // Close the current form (UnitsManagementForm)
            this.Close();
        }

        private void btnAddMaterial_Click(object sender, EventArgs e)
        {
            if (cmbProjects.SelectedValue == null)
            {
                MessageBox.Show("Select a project first!");
                return;
            }
            string selectedProjectId = cmbProjects.SelectedValue.ToString();

            this.Hide(); // Hide the current form
            MaterialForm addMaterialForm = new MaterialForm(selectedProjectId);

            addMaterialForm.FormClosed += (s, args) => this.Show(); // Show it again when AddMaterialForm is closed

            addMaterialForm.Show();
        }

        public async void RefreshData()
        {
            if (cmbProjects.SelectedValue != null)
            {
                string projectId = cmbProjects.SelectedValue.ToString();
                await LoadMaterialDataAsync(projectId);
            }
        }
        private void btnAddLabor_Click(object sender, EventArgs e)
        {
            if (cmbProjects.SelectedValue == null)
            {
                MessageBox.Show("Select a project first!");
                return;
            }
            string selectedProjectId = cmbProjects.SelectedValue.ToString();

            this.Hide();
            new LaborerForm(selectedProjectId, connectionString).Show();

            RefreshLaborData();
        }

        // Add this method to refresh labor data
        public async void RefreshLaborData()
        {
            if (cmbProjects.SelectedValue != null)
            {
                string projectId = cmbProjects.SelectedValue.ToString();
                await LoadLaborDataAsync(projectId);
            }
        }

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            // Open the new form
            new ProjectReportForm().Show();

            // Hide the current form (instead of closing)
            this.Hide();
        }

        private void btnMatBack_Click(object sender, EventArgs e)
        {
            // Open MD_homeForm without passing any project ID
            new MD_homeForm().Show();
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async void ProjectDetailsForm_Load(object sender, EventArgs e)
        {
            try
            {
                // Load projects into ComboBox
                await LoadProjectsAsync();
                InitializeProgressUI();

                // Select first project by default
                if (cmbProjects.Items.Count > 0)
                    cmbProjects.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading projects: {ex.Message}");
            }

            await LoadProjectImages(cmbProjects.SelectedValue.ToString());
        }

        private async Task LoadProjectsAsync()
        {
            DataTable projectsTable = new DataTable();
            projectsTable.Columns.Add("ProjectID", typeof(string)); // Explicit string type
            projectsTable.Columns.Add("ProjectName", typeof(string));

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                string query = "SELECT ProjectID, ProjectName FROM Projects";

                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        projectsTable.Rows.Add(
                            reader["ProjectID"].ToString(), // Force string conversion
                            reader["ProjectName"].ToString()
                        );
                    }
                }
            }

            cmbProjects.DataSource = projectsTable;
            cmbProjects.DisplayMember = "ProjectName";
            cmbProjects.ValueMember = "ProjectID";
        }

        private async Task LoadMaterialDataAsync(string projectId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();
                    string query = @"
                SELECT 
                    PM.ProjectID,          -- Key column (hidden)
                    PM.MaterialID,         -- Key column (hidden)
                    PM.SupplierID,         -- Key column (hidden)
                    PM.PurchaseDate,       -- Key column (hidden)
                    P.ProjectName AS [Project Name],
                    M.MaterialID AS [Material Name],
                    PM.Quantity,
                    S.SupplierID AS [Supplier],
                    PM.CostPerUnit AS [Cost],
                    PM.PurchaseDate AS [Date]
                FROM ProjectMaterials PM
                INNER JOIN Projects P ON PM.ProjectID = P.ProjectID
                INNER JOIN Materials M ON PM.MaterialID = M.MaterialID
                INNER JOIN Suppliers S ON PM.SupplierID = S.SupplierID
                WHERE PM.ProjectID = @ProjectID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ProjectID", projectId);
                        DataTable dt = new DataTable();
                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            dt.Load(reader);
                        }

                        if (dt == null || dt.Rows.Count == 0)
                        {
                            MessageBox.Show("No materials found for this project.");
                            return;
                        }

                        // Initialize DataView and bind to DataGridView
                        materialDataView = new DataView(dt);
                        dgvdatamaterial.DataSource = materialDataView;

                        // Populate filter dropdowns
                        PopulateFilters(dt);


                        // Hide key columns safely
                        if (dgvdatamaterial.Columns.Contains("ProjectID"))
                            dgvdatamaterial.Columns["ProjectID"].Visible = false;
                        if (dgvdatamaterial.Columns.Contains("MaterialID"))
                            dgvdatamaterial.Columns["MaterialID"].Visible = false;
                        if (dgvdatamaterial.Columns.Contains("SupplierID"))
                            dgvdatamaterial.Columns["SupplierID"].Visible = false;
                        if (dgvdatamaterial.Columns.Contains("PurchaseDate"))
                            dgvdatamaterial.Columns["PurchaseDate"].Visible = false;

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading materials: {ex.Message}");
            }
            // Calculate and display total
            CalculateTotalExpenses();
            UpdateTotalMaterialExpensesUnfiltered();
            UpdateTotalBudgetExpenses();
        }

        private void PopulateFilters(DataTable data)
        {
            // Populate Material filter
            var materials = data.AsEnumerable()
                .Select(row => row.Field<string>("Material Name"))
                .Distinct()
                .ToList();

            cmbFilterMaterial.DataSource = materials;
            cmbFilterMaterial.SelectedIndex = -1; // No initial selection

            // Populate Supplier filter
            var suppliers = data.AsEnumerable()
                .Select(row => row.Field<string>("Supplier"))
                .Distinct()
                .ToList();

            cmbFilterSupplier.DataSource = suppliers;
            cmbFilterSupplier.SelectedIndex = -1;
        }

        private void ApplyFilters()
        {
            if (materialDataView == null) return;

            string materialFilter = cmbFilterMaterial.SelectedItem?.ToString();
            string supplierFilter = cmbFilterSupplier.SelectedItem?.ToString();

            // Build filter expression
            string filter = "";

            if (!string.IsNullOrEmpty(materialFilter))
                filter += $"[Material Name] = '{materialFilter.Replace("'", "''")}'";

            if (!string.IsNullOrEmpty(supplierFilter))
            {
                if (!string.IsNullOrEmpty(filter)) filter += " AND ";
                filter += $"[Supplier] = '{supplierFilter.Replace("'", "''")}'";
            }

            materialDataView.RowFilter = filter;
            CalculateTotalExpenses();
        }

        private void CalculateTotalExpenses()
        {
            decimal total = 0;
            if (materialDataView != null)
            {
                foreach (DataRowView row in materialDataView)
                {
                    int quantity = Convert.ToInt32(row["Quantity"]);
                    decimal cost = Convert.ToDecimal(row["Cost"]);
                    total += quantity * cost;
                }
            }
            lblTotalExpenses.Text = $"Pkr {total:N0}"; ;
        }

        private async Task LoadLaborDataAsync(string projectId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();
                    string query = @"
                SELECT 
    PL.WorkerID,
    PL.ProjectID,
    W.WorkerName AS [Name],
    L.RoleName AS [Role],
    C.ContractorName AS [Contractor],
    PL.WorkDate AS [Date],
    PL.DaysWorked AS [Days],
    PL.Rate AS [Rate],
    PL.DaysWorked * PL.Rate AS [Salary],
    SUM(PL.DaysWorked * PL.Rate) OVER (PARTITION BY PL.WorkerID, PL.ProjectID) AS [TotalPerWorker]
FROM ProjectLabor PL
INNER JOIN Workers W ON PL.WorkerID = W.WorkerID
INNER JOIN Labor L ON W.RoleID = L.RoleID
INNER JOIN Contractors C ON W.ContractorID = C.ContractorID
WHERE PL.ProjectID = @ProjectID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ProjectID", projectId);
                        DataTable dt = new DataTable();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            dt.Load(reader);
                        }
                        if (!dt.Columns.Contains("Salary"))
                        {
                            MessageBox.Show("Salary column missing in DataTable!");
                            return;
                        }

                        laborDataView = new DataView(dt);
                        dgvLabor.DataSource = laborDataView;

                        // After setting dgvLabor.DataSource
                        if (!dgvLabor.Columns.Contains("Salary"))
                        {
                            dgvLabor.Columns.Add(new DataGridViewTextBoxColumn()
                            {
                                Name = "Salary",
                                HeaderText = "Salary",
                                DataPropertyName = "Salary" // Binds to the DataTable column
                            });
                        }

                        if (dgvLabor.Columns.Contains("Salary"))
                        {
                            dgvLabor.Columns["Salary"].Visible = true;
                        }

                        PopulateLaborFilters(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading labor data: {ex.Message}");
            }

            UpdateTotalSalary();
            UpdateTotalLaborExpenses();
            UpdateTotalBudgetExpenses();
        }

        private async void cmbProjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProjects.SelectedValue == null) return;

            // Clear filters
            cmbFilterMaterial.SelectedIndex = -1;
            cmbFilterSupplier.SelectedIndex = -1;

            // Clear current image and description immediately
            picProjectImage.Image = null;
            txtImageDescription.Text = "";
            lblImageCounter.Text = "0/0";
            // Clear data and reload
            currentImageIndex = 0; // Reset to first image
            await LoadProjectImages(cmbProjects.SelectedValue.ToString());
            UpdateImageDisplay();

            // Reload data
            string selectedProjectId = cmbProjects.SelectedValue.ToString();
            await Task.WhenAll(
        LoadMaterialDataAsync(selectedProjectId),
        LoadLaborDataAsync(selectedProjectId),
        LoadProjectProgress(selectedProjectId)
    );

            try
            {
                // Show loading state
                Cursor = Cursors.WaitCursor;

                // Load both material and labor data
                await Task.WhenAll(
                    LoadMaterialDataAsync(selectedProjectId),
                    LoadLaborDataAsync(selectedProjectId)
                );
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void btnAddProject_Click(object sender, EventArgs e)
        {
            AddProjectForm addForm = new AddProjectForm();

            // Subscribe to the ProjectAdded event
            addForm.ProjectAdded += async () =>
            {
                // Refresh projects when a new one is added
                await LoadProjectsAsync();
            };

            addForm.ShowDialog();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private async void btnDeleteMaterial_Click(object sender, EventArgs e)
        {
            if (dgvdatamaterial.CurrentRow == null)
            {
                MessageBox.Show("Select a row to delete.");
                return;
            }

            // Get hidden column values
            DataGridViewRow row = dgvdatamaterial.CurrentRow;
            string projectId = row.Cells["ProjectID"].Value.ToString();
            string materialId = row.Cells["MaterialID"].Value.ToString();
            string supplierId = row.Cells["SupplierID"].Value.ToString();
            DateTime purchaseDate = Convert.ToDateTime(row.Cells["PurchaseDate"].Value);

            // Confirm deletion
            DialogResult result = MessageBox.Show(
                "Delete this record?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result != DialogResult.Yes) return;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();
                    string query = @"
                DELETE FROM ProjectMaterials 
                WHERE 
                    ProjectID = @ProjectID AND 
                    MaterialID = @MaterialID AND 
                    SupplierID = @SupplierID AND 
                    PurchaseDate = @PurchaseDate";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@ProjectID", projectId);
                        cmd.Parameters.AddWithValue("@MaterialID", materialId);
                        cmd.Parameters.AddWithValue("@SupplierID", supplierId);
                        cmd.Parameters.AddWithValue("@PurchaseDate", purchaseDate);

                        int rowsAffected = await cmd.ExecuteNonQueryAsync();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Record deleted!");
                            await LoadMaterialDataAsync(projectId); // Refresh data
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }

        }

        private void btnApplyLaborFilter_Click(object sender, EventArgs e)
        {
            ApplyLaborFilters();
        }

        private void PopulateLaborFilters(DataTable dt)
        {
            // Worker names
            cmbFilterName.DataSource = dt.AsEnumerable()
                .Select(r => r.Field<string>("Name"))
                .Distinct()
                .OrderBy(n => n)
                .ToList();
            cmbFilterName.SelectedIndex = -1;

            // Roles
            cmbFilterRole.DataSource = dt.AsEnumerable()
                .Select(r => r.Field<string>("Role"))
                .Distinct()
                .OrderBy(r => r)
                .ToList();
            cmbFilterRole.SelectedIndex = -1;

            // Contractors
            cmbFilterContractor.DataSource = dt.AsEnumerable()
                .Select(r => r.Field<string>("Contractor"))
                .Distinct()
                .OrderBy(c => c)
                .ToList();
            cmbFilterContractor.SelectedIndex = -1;
        }

        private void ApplyLaborFilters()
        {
            if (laborDataView == null) return;

            string nameFilter = cmbFilterName.SelectedItem?.ToString();
            string roleFilter = cmbFilterRole.SelectedItem?.ToString();
            string contractorFilter = cmbFilterContractor.SelectedItem?.ToString();

            string filter = "";

            if (!string.IsNullOrEmpty(nameFilter))
                filter += $"[Name] = '{nameFilter.Replace("'", "''")}'";

            if (!string.IsNullOrEmpty(roleFilter))
            {
                if (!string.IsNullOrEmpty(filter)) filter += " AND ";
                filter += $"[Role] = '{roleFilter.Replace("'", "''")}'";
            }

            if (!string.IsNullOrEmpty(contractorFilter))
            {
                if (!string.IsNullOrEmpty(filter)) filter += " AND ";
                filter += $"[Contractor] = '{contractorFilter.Replace("'", "''")}'";
            }

            DataRow[] matchedRows = laborDataView.Table.Select(filter);
            if (matchedRows.Length == 0)
            {
                MessageBox.Show("No matching records found. Please adjust the filters.");
                return;
            }

            laborDataView.RowFilter = filter;
            UpdateTotalSalary();
        }

        private void btnClearLaborFilters_Click(object sender, EventArgs e)
        {
            // Reset dropdowns
            cmbFilterName.SelectedIndex = -1;
            cmbFilterRole.SelectedIndex = -1;
            cmbFilterContractor.SelectedIndex = -1;

            // Remove filter
            if (laborDataView != null)
                laborDataView.RowFilter = string.Empty;

            UpdateTotalSalary();
            UpdateTotalLaborExpenses();
            UpdateTotalBudgetExpenses();

        }

        private void UpdateTotalSalary()
        {
            if (dgvLabor.DataSource is DataView dv)
            {
                decimal total = 0;
                foreach (DataRowView rowView in dv)
                {
                    if (decimal.TryParse(rowView["Salary"].ToString(), out decimal salary))
                    {
                        total += salary;
                    }
                }
                lblTotalSalary.Text = $"Total Salary: Pkr {total:N0}"; // Format as currency
            }
        }

        private void lblTotalSalary_Click(object sender, EventArgs e)
        {

        }
        private void dgvLabor_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dgvLabor.ClearSelection();
                dgvLabor.Rows[e.RowIndex].Selected = true;
            }
        }


        private async void btnDeleteLabor_Click(object sender, EventArgs e)
        {
            if (dgvLabor.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a labor row to delete.");
                return;
                
            }

            DataGridViewRow selectedRow = dgvLabor.SelectedRows[0];

            try
            {
                string workerName = selectedRow.Cells["Name"].Value.ToString();
                string role = selectedRow.Cells["Role"].Value.ToString();
                string contractor = selectedRow.Cells["Contractor"].Value.ToString();
                string projectId = selectedRow.Cells["ProjectID"].Value.ToString();
                DateTime workDate = Convert.ToDateTime(selectedRow.Cells["Date"].Value);

                DialogResult result = MessageBox.Show(
                    $"Delete labor record for {workerName} on {workDate:d}?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result != DialogResult.Yes) return;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();

                    string query = @"
                DELETE PL 
                FROM ProjectLabor PL
                INNER JOIN Workers W ON PL.WorkerID = W.WorkerID
                INNER JOIN Labor L ON W.RoleID = L.RoleID
                INNER JOIN Contractors C ON W.ContractorID = C.ContractorID
                WHERE 
                    W.WorkerName = @WorkerName AND
                    L.RoleName = @Role AND
                    C.ContractorName = @Contractor AND
                    PL.WorkDate = @WorkDate AND
                    PL.ProjectID = @ProjectID";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@WorkerName", workerName);
                        cmd.Parameters.AddWithValue("@Role", role);
                        cmd.Parameters.AddWithValue("@Contractor", contractor);
                        cmd.Parameters.AddWithValue("@WorkDate", workDate);
                        cmd.Parameters.AddWithValue("@ProjectID", projectId);

                        int rowsAffected = await cmd.ExecuteNonQueryAsync();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Labor record deleted.");
                            if (cmbProjects.SelectedValue != null)
                                await LoadLaborDataAsync(cmbProjects.SelectedValue.ToString());
                        }
                        else
                        {
                            MessageBox.Show("No matching labor record found.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting labor record: {ex.Message}");
            }
        }

        private void UpdateTotalLaborExpenses()
        {
            if (laborDataView?.Table == null) return;

            decimal totalExpenses = 0;

            foreach (DataRow row in laborDataView.Table.Rows)
            {
                if (decimal.TryParse(row["Salary"].ToString(), out decimal salary))
                {
                    totalExpenses += salary;
                }
            }

            lblTotalLaborExpenses.Text = $"Pkr {totalExpenses:N0}";
        }

        private void UpdateTotalMaterialExpensesUnfiltered()
        {
            if (materialDataView?.Table == null) return;

            decimal total = 0;
            foreach (DataRow row in materialDataView.Table.Rows)
            {
                int quantity = Convert.ToInt32(row["Quantity"]);
                decimal cost = Convert.ToDecimal(row["Cost"]);
                total += quantity * cost;
            }

            lblTotalMaterialExpensesUnfiltered.Text = $"Pkr {total:N0}"; ;
        }

        private void UpdateTotalBudgetExpenses()
        {
            decimal materialTotal = 0;
            decimal laborTotal = 0;

            // Calculate material total (unfiltered)
            if (materialDataView?.Table != null)
            {
                foreach (DataRow row in materialDataView.Table.Rows)
                {
                    materialTotal += Convert.ToInt32(row["Quantity"]) *
                                   Convert.ToDecimal(row["Cost"]);
                }
            }

            // Calculate labor total (unfiltered)
            if (laborDataView?.Table != null)
            {
                foreach (DataRow row in laborDataView.Table.Rows)
                {
                    if (decimal.TryParse(row["Salary"].ToString(), out decimal salary))
                    {
                        laborTotal += salary;
                    }
                }
            }

            // Display as plain numeric format "000000"
            lblTotalBudgetExpenses.Text = $"Pkr {(materialTotal + laborTotal):N0}";
        }
        private void InitializeProgressUI()
        {
            // Progress Bar Settings (set Dock in designer)
            progressBarProject.Minimum = 0;
            progressBarProject.Maximum = 100;
            progressBarProject.Value = 0;

            // Phase Checkboxes - Add to designer-created panel5
            panel5.AutoScroll = true;
            int yPos = 20;
            foreach (var phase in projectPhases)
            {
                CheckBox chk = new CheckBox
                {
                    Text = $"{phase.Name} ({phase.Weight}%)",
                    Tag = phase,
                    Checked = phase.IsCompleted,
                    Location = new Point(20, yPos),
                    AutoSize = true,
                    Width = panel5.Width - 40 // Match panel width
                };
                chk.CheckedChanged += PhaseCheckbox_CheckedChanged;
                panel5.Controls.Add(chk); // Add to designer panel
                yPos += 30;
            }
        }

        private void PhaseCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            var checkbox = (CheckBox)sender;
            var phase = (ProjectPhase)checkbox.Tag;

            // Track modified phases
            if (!modifiedPhases.Contains(phase))
            {
                modifiedPhases.Add(phase);
            }
        }

        private async Task LoadProjectProgress(string projectId)
        {
            try
            {
                // Clear existing progress
                foreach (var phase in projectPhases)
                {
                    phase.IsCompleted = false;
                }

                using (var connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();
                    var query = "SELECT PhaseName FROM ProjectProgress WHERE ProjectID = @ProjectID";

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ProjectID", projectId);

                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                var phaseName = reader["PhaseName"].ToString();
                                var phase = projectPhases.FirstOrDefault(p => p.Name == phaseName);

                                if (phase != null)
                                {
                                    phase.IsCompleted = true;
                                }
                            }
                        }
                    }
                }

                // Update checkboxes
                foreach (Control control in panel5.Controls)
                {
                    if (control is CheckBox chk && chk.Tag is ProjectPhase phase)
                    {
                        chk.Checked = phase.IsCompleted;
                    }
                }

                modifiedPhases.Clear();
                UpdateProjectProgress();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading progress: {ex.Message}");
            }
        }

        private async Task SaveProjectProgress(string projectId)
        {
            if (string.IsNullOrEmpty(projectId)) return;

            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();

                    // Only update modified phases
                    foreach (var phase in modifiedPhases)
                    {
                        // Delete existing entry if any
                        var deleteQuery = @"DELETE FROM ProjectProgress 
                                  WHERE ProjectID = @ProjectID 
                                  AND PhaseName = @PhaseName";

                        using (var deleteCmd = new SqlCommand(deleteQuery, connection))
                        {
                            deleteCmd.Parameters.AddWithValue("@ProjectID", projectId);
                            deleteCmd.Parameters.AddWithValue("@PhaseName", phase.Name);
                            await deleteCmd.ExecuteNonQueryAsync();
                        }

                        // Insert new entry if checked
                        if (phase.IsCompleted)
                        {
                            var insertQuery = @"INSERT INTO ProjectProgress 
                                      (ProjectID, PhaseName, IsCompleted)
                                      VALUES (@ProjectID, @PhaseName, @IsCompleted)";

                            using (var insertCmd = new SqlCommand(insertQuery, connection))
                            {
                                insertCmd.Parameters.AddWithValue("@ProjectID", projectId);
                                insertCmd.Parameters.AddWithValue("@PhaseName", phase.Name);
                                insertCmd.Parameters.AddWithValue("@IsCompleted", true);
                                await insertCmd.ExecuteNonQueryAsync();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving progress: {ex.Message}");
            }
        }


        private void UpdateProjectProgress()
        {
            decimal completedWeight = projectPhases
         .Where(p => p.IsCompleted)
         .Sum(p => p.Weight);

            progressBarProject.Value = (int)completedWeight;
            lblProgressPercentage.Text = $"{completedWeight}%";
            progressBarProject.ForeColor = completedWeight >= 100 ?
                Color.Green : SystemColors.Highlight;
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private async void btnSaveProgress_Click(object sender, EventArgs e)
        {
            try
            {
                // Update phase statuses
                foreach (var phase in modifiedPhases)
                {
                    var checkbox = panel5.Controls
                        .OfType<CheckBox>()
                        .FirstOrDefault(c => c.Tag == phase);

                    if (checkbox != null)
                    {
                        phase.IsCompleted = checkbox.Checked;
                    }
                }

                // Update progress display
                UpdateProjectProgress();

                // Save to database
                await SaveProjectProgress(cmbProjects.SelectedValue?.ToString());

                modifiedPhases.Clear();
                MessageBox.Show("Progress saved successfully!");

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving progress: {ex.Message}");
            }
        }

        private async Task ValidateNumericData()
        {
            try
            {
                StringBuilder validationErrors = new StringBuilder();

                // Validate ProjectMaterials numeric fields
                string materialCheckQuery = @"
            SELECT PM.EntryID, PM.Quantity, PM.CostPerUnit
            FROM ProjectMaterials PM
            WHERE TRY_CAST(PM.Quantity AS decimal(18,2)) IS NULL 
               OR TRY_CAST(PM.CostPerUnit AS decimal(18,2)) IS NULL";

                // Validate ProjectLabor numeric fields
                string laborCheckQuery = @"
            SELECT PL.EntryID, PL.DaysWorked, PL.Rate
            FROM ProjectLabor PL
            WHERE TRY_CAST(PL.DaysWorked AS decimal(18,2)) IS NULL
               OR TRY_CAST(PL.Rate AS decimal(18,2)) IS NULL";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();

                    // Check for bad material records
                    SqlCommand materialCmd = new SqlCommand(materialCheckQuery, conn);
                    using (SqlDataReader reader = await materialCmd.ExecuteReaderAsync())
                    {
                        if (reader.HasRows)
                        {
                            validationErrors.AppendLine("Invalid material records found:");
                            while (await reader.ReadAsync())
                            {
                                validationErrors.AppendLine($"EntryID: {reader["EntryID"]}, " +
                                    $"Quantity: {reader["Quantity"]}, " +
                                    $"Cost: {reader["CostPerUnit"]}");
                            }
                            validationErrors.AppendLine();
                        }
                    }

                    // Check for bad labor records
                    SqlCommand laborCmd = new SqlCommand(laborCheckQuery, conn);
                    using (SqlDataReader reader = await laborCmd.ExecuteReaderAsync())
                    {
                        if (reader.HasRows)
                        {
                            validationErrors.AppendLine("Invalid labor records found:");
                            while (await reader.ReadAsync())
                            {
                                validationErrors.AppendLine($"EntryID: {reader["EntryID"]}, " +
                                    $"Days: {reader["DaysWorked"]}, " +
                                    $"Rate: {reader["Rate"]}");
                            }
                        }
                    }

                    // Show all validation errors if any found
                    if (validationErrors.Length > 0)
                    {
                        MessageBox.Show(validationErrors.ToString(), "Data Validation Warning",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Validation failed: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lblTotalExpenses_Click(object sender, EventArgs e)
        {

        }

        private async Task LoadProjectImages(string projectId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                await conn.OpenAsync();
                string query = "SELECT ImagePath, Description FROM ProjectImages WHERE ProjectID = @ProjectID";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ProjectID", projectId);

                DataTable dt = new DataTable();
                dt.Load(await cmd.ExecuteReaderAsync());
                imagesDataView = new DataView(dt);

                UpdateImageDisplay();
            }
        }

        private void UpdateImageDisplay()
        {
            try
            {
                if (imagesDataView?.Count > 0 && currentImageIndex < imagesDataView.Count)
                {
                    string imagePath = imagesDataView[currentImageIndex]["ImagePath"].ToString();

                    // Clear previous image safely
                    if (picProjectImage.Image != null)
                    {
                        picProjectImage.Image.Dispose();
                        picProjectImage.Image = null;
                    }

                    if (File.Exists(imagePath))
                    {
                        // Load image into MemoryStream to avoid file locks
                        using (FileStream fs = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                        {
                            using (MemoryStream ms = new MemoryStream())
                            {
                                fs.CopyTo(ms); // Copy to memory stream
                                picProjectImage.Image = Image.FromStream(ms);
                            }
                        }

                        txtImageDescription.Text = imagesDataView[currentImageIndex]["Description"].ToString();
                        lblImageCounter.Text = $"{currentImageIndex + 1}/{imagesDataView.Count}";

                    }
                    else
                    {
                        MessageBox.Show("Invalid or corrupted image file!", "Error",
        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    picProjectImage.Image = null;
                    txtImageDescription.Text = "";
                    lblImageCounter.Text = "0/0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading image: {ex.Message}");
                // Clear UI on error
                picProjectImage.Image = null;
                txtImageDescription.Text = "";
                lblImageCounter.Text = "0/0";
            }

            picProjectImage.Refresh(); // Force redraw
        }

        private async void btnAddImage_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string projectId = cmbProjects.SelectedValue.ToString();
                    string projectFolder = Path.Combine(Application.StartupPath, "Images", projectId);

                    string extension = Path.GetExtension(dialog.FileName).ToLower();
                    if (!new[] { ".jpg", ".jpeg", ".png", ".gif" }.Contains(extension))
                    {
                        MessageBox.Show("Invalid image format!", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Ensure the directory exists
                    Directory.CreateDirectory(projectFolder);

                    string destFileName = Path.GetFileName(dialog.FileName);
                    string destPath = Path.Combine(projectFolder, destFileName);

                    // Copy the image (overwrite if exists)
                    File.Copy(dialog.FileName, destPath, overwrite: true);

                    // Save to database
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        await conn.OpenAsync();
                        string query = @"INSERT INTO ProjectImages 
                           (ProjectID, ImagePath, Description) 
                           VALUES (@ProjectID, @ImagePath, @Description)";

                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@ProjectID", projectId);
                        cmd.Parameters.AddWithValue("@ImagePath", destPath);
                        cmd.Parameters.AddWithValue("@Description", txtImageDescription.Text);
                        await cmd.ExecuteNonQueryAsync();
                    }

                    // Show success message HERE
                    MessageBox.Show("Image added successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information); // <-- Added

                    // Clear the description textbox after adding
                    txtImageDescription.Text = string.Empty;

                    // Refresh images and reset index
                    await LoadProjectImages(projectId);

                    if (imagesDataView.Count > 0)
                    {
                        currentImageIndex = imagesDataView.Count - 1;
                        UpdateImageDisplay();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding image: {ex.Message}");
            }
        }

        private async void btnDeleteImage_Click(object sender, EventArgs e)
        {
            if (imagesDataView?.Count > 0)
            {
                // Ask for confirmation
                DialogResult confirm = MessageBox.Show("Delete this image?", "Confirm",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirm != DialogResult.Yes) return;

                string imagePath = imagesDataView[currentImageIndex]["ImagePath"].ToString();

                // Release image resources
                if (picProjectImage.Image != null)
                {
                    picProjectImage.Image.Dispose();
                    picProjectImage.Image = null;
                }

                // Delete from database
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string query = "DELETE FROM ProjectImages WHERE ImagePath = @ImagePath";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ImagePath", imagePath);
                    await cmd.ExecuteNonQueryAsync();
                }

                // Delete file
                File.Delete(imagePath);

                // Reload images for the current project
                await LoadProjectImages(cmbProjects.SelectedValue.ToString());

                // Adjust index after reloading
                if (imagesDataView.Count > 0)
                {
                    // If deleting the last image, move to the new last index
                    currentImageIndex = Math.Min(currentImageIndex, imagesDataView.Count - 1);
                }
                else
                {
                    currentImageIndex = 0; // Reset when no images left
                }

                UpdateImageDisplay(); // Refresh UI
            }
        }

        private bool IsValidImage(string filePath)
        {
            try
            {
                using (Image img = Image.FromFile(filePath))
                {
                    return true; // File is a valid image
                }
            }
            catch
            {
                return false; // File is corrupted or not an image
            }
        }


        private void btnNext_Click(object sender, EventArgs e)
        {
            if (imagesDataView?.Count > 0)
            {
                currentImageIndex = (currentImageIndex + 1) % imagesDataView.Count;
                UpdateImageDisplay(); // Updates description automatically
            }
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (imagesDataView?.Count > 0)
            {
                currentImageIndex = (currentImageIndex - 1 + imagesDataView.Count) % imagesDataView.Count;
                UpdateImageDisplay();
            }
        }

        private async void btnSaveDescription_Click(object sender, EventArgs e)
        {
            if (imagesDataView?.Count > 0)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string query = @"UPDATE ProjectImages 
                           SET Description = @Description 
                           WHERE ImagePath = @ImagePath";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Description", txtImageDescription.Text);
                    cmd.Parameters.AddWithValue("@ImagePath", imagesDataView[currentImageIndex]["ImagePath"]);
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

    }

}