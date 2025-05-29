using RECMS.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RECMS.Forms.MD
{
    public partial class AddMaterialForm : Form
    {
        private string connectionString = DatabaseHelper.GetConnectionString();
        public string MaterialName => txtMaterialName.Text.Trim();
        public string SelectedUnitId => cmbUnits.SelectedValue?.ToString();

        public AddMaterialForm()
        {
            InitializeComponent();
            _ = LoadUnitsAsync();
        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AddMaterialForm_Load(object sender, EventArgs e)
        {

        }

        private async Task LoadUnitsAsync()
        {
            DataTable dt = new DataTable(); // Declare outside the using block

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();
                    string query = "SELECT UnitID, UnitName FROM MUnits";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    adapter.Fill(dt); // Now filling the outer-scope dt
                }

                // Thread-safe UI update
                if (cmbUnits.InvokeRequired)
                {
                    cmbUnits.Invoke((MethodInvoker)delegate
                    {
                        cmbUnits.DisplayMember = "UnitName";
                        cmbUnits.ValueMember = "UnitID";
                        cmbUnits.DataSource = dt; // Now accessible
                    });
                }
                else
                {
                    cmbUnits.DisplayMember = "UnitName";
                    cmbUnits.ValueMember = "UnitID";
                    cmbUnits.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading units: {ex.Message}");
            }
        }


        private async void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate inputs
                if (string.IsNullOrEmpty(MaterialName))
                {
                    MessageBox.Show("Material name is required!");
                    return;
                }

                if (cmbUnits.SelectedValue == null)
                {
                    MessageBox.Show("Please select a unit!");
                    return;
                }

                // Check if material already exists
                bool exists = false;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();
                    string checkQuery = "SELECT 1 FROM Materials WHERE MaterialID = @MaterialID";

                    using (SqlCommand cmd = new SqlCommand(checkQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@MaterialID", MaterialName);
                        exists = (await cmd.ExecuteScalarAsync()) != null;
                    }
                }

                if (exists)
                {
                    MessageBox.Show("This material already exists!");
                    return;
                }

                // Insert new material
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();
                    string insertQuery = "INSERT INTO Materials (MaterialID, UnitID) VALUES (@MaterialID, @UnitID)";

                    using (SqlCommand cmd = new SqlCommand(insertQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@MaterialID", MaterialName);
                        cmd.Parameters.AddWithValue("@UnitID", SelectedUnitId);
                        await cmd.ExecuteNonQueryAsync();
                    }
                }

                MessageBox.Show("Material added successfully!");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
        private async Task<string> GetUnitIdByName(string unitName)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                string query = "SELECT UnitID FROM MUnits WHERE UnitName = @UnitName";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@UnitName", unitName);
                    object result = await cmd.ExecuteScalarAsync();
                    return result?.ToString();
                }
            }
        }

        private async Task<bool> CheckUnitIdExists(string unitId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                string query = "SELECT 1 FROM MUnits WHERE UnitID = @UnitID";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@UnitID", unitId);
                    object result = await cmd.ExecuteScalarAsync();
                    return result != null;
                }
            }
        }

        private async Task InsertUnitAsync(string unitId, string unitName)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                string query = "INSERT INTO MUnits (UnitID, UnitName) VALUES (@UnitID, @UnitName)";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@UnitID", unitId);
                    cmd.Parameters.AddWithValue("@UnitName", unitName);
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        private string GenerateUnitId(string unitName)
        {
            // Generate UnitID from UnitName (e.g., "Cubic Meter" → "cubic_meter")
            return unitName.Trim().ToLower().Replace(" ", "_");
        }

    }
}
