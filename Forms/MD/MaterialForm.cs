using RECMS.Forms.MD;
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

namespace RECMS.Forms
{
    public partial class MaterialForm : Form
    {
        private string connectionString = DatabaseHelper.GetConnectionString();
        private readonly string _projectId;

        public MaterialForm(string projectId)
        {
            InitializeComponent();
            _projectId = projectId;

            cmbSuppliers.DropDownStyle = ComboBoxStyle.DropDown;
            cmbSuppliers.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbSuppliers.AutoCompleteSource = AutoCompleteSource.ListItems;

            _ = LoadMaterialsAndSuppliersAsync(); // Load data on form open
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
            try
            {
                string materialId = cmbMaterials.Text.Trim(); // This is the MaterialID (name)
                string supplierId = cmbSuppliers.Text.Trim();
                int quantity = (int)numQuantity.Value;
                decimal costPerUnit = numCostPerUnit.Value;
                DateTime purchaseDate = dtpPurchaseDate.Value;
                bool isNewSupplier = false;

                if (string.IsNullOrEmpty(materialId)) throw new Exception("Material is required!");
                if (string.IsNullOrEmpty(supplierId)) throw new Exception("Supplier is required!");

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();
                    using (SqlTransaction transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            // Check if supplier exists
                            bool supplierExists = await CheckSupplierExists(connection, transaction, supplierId);

                            if (!supplierExists)
                            {
                                DialogResult result = MessageBox.Show(
                                    $"Supplier '{supplierId}' doesn't exist. Create new supplier?",
                                    "New Supplier",
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question
                                );

                                if (result != DialogResult.Yes)
                                {
                                    cmbSuppliers.Text = "";
                                    cmbSuppliers.Focus();
                                    return;
                                }

                                // Insert new supplier
                                await InsertSupplier(connection, transaction, supplierId);
                                isNewSupplier = true;
                            }

                            // Insert project material
                            string query = @"INSERT INTO ProjectMaterials 
                                   (ProjectID, MaterialID, SupplierID, Quantity, CostPerUnit, PurchaseDate)
                                   VALUES 
                                   (@ProjectID, @MaterialID, @SupplierID, @Quantity, @CostPerUnit, @PurchaseDate)";

                            using (SqlCommand command = new SqlCommand(query, connection, transaction))
                            {
                                command.Parameters.AddWithValue("@ProjectID", _projectId);
                                command.Parameters.AddWithValue("@MaterialID", materialId);
                                command.Parameters.AddWithValue("@SupplierID", supplierId);
                                command.Parameters.AddWithValue("@Quantity", quantity);
                                command.Parameters.AddWithValue("@CostPerUnit", costPerUnit);
                                command.Parameters.AddWithValue("@PurchaseDate", purchaseDate);

                                await command.ExecuteNonQueryAsync();
                            }

                            transaction.Commit();

                            // Refresh suppliers list if new supplier added
                            if (isNewSupplier)
                            {
                                await LoadSuppliersAsync();
                                cmbSuppliers.SelectedIndex = cmbSuppliers.FindStringExact(supplierId);
                            }

                            MessageBox.Show("Material added successfully!");
                            this.Close();
                        }
                        catch
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (SqlException ex) when (ex.Number == 547)
            {
                MessageBox.Show("Invalid material, supplier, or project!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }

        }



        private void ShowError(string message, Control control)
        {
           
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Record entry canceled.", "Cancellation");
            this.Close();
        }

        private void txtMatName_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
        private void txtsupp_KeyPress(object sender, KeyPressEventArgs e)
        {
 
        }

        private void MaterialForm_Load(object sender, EventArgs e)
        {
            FormDragHelper.MakeDraggable(this, panel1);
        }

        private async Task LoadMaterialsAndSuppliersAsync()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();

                    // Load materials
                    string materialQuery = "SELECT MaterialID FROM Materials";
                    SqlDataAdapter materialAdapter = new SqlDataAdapter(materialQuery, connection);
                    DataTable materialTable = new DataTable();
                    materialAdapter.Fill(materialTable);

                    if (materialTable.Rows.Count == 0)
                    {
                        MessageBox.Show("No materials found! Add materials first.");
                        return;
                    }

                    cmbMaterials.BeginUpdate();
                    cmbMaterials.DataSource = materialTable;
                    cmbMaterials.DisplayMember = "MaterialID";
                    cmbMaterials.EndUpdate();

                    // Load suppliers
                    string supplierQuery = "SELECT SupplierID FROM Suppliers";
                    SqlDataAdapter supplierAdapter = new SqlDataAdapter(supplierQuery, connection);
                    DataTable supplierTable = new DataTable();
                    supplierAdapter.Fill(supplierTable);

                    if (supplierTable.Rows.Count == 0)
                    {
                        MessageBox.Show("No suppliers found! Add suppliers first.");
                        return;
                    }

                    cmbSuppliers.BeginUpdate();
                    cmbSuppliers.DataSource = supplierTable;
                    cmbSuppliers.DisplayMember = "SupplierID";
                    cmbSuppliers.EndUpdate();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}");
            }
        }

        private async void btnAddNewMaterial_Click(object sender, EventArgs e)
        {
            AddMaterialForm addForm = new AddMaterialForm();
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                // Refresh materials list
                await LoadMaterialsAndSuppliersAsync();

                // Select the newly added material
                cmbMaterials.SelectedIndex = cmbMaterials.FindStringExact(addForm.MaterialName);
            }
        }

        private async Task<bool> CheckSupplierExists(SqlConnection connection, SqlTransaction transaction, string supplierId)
        {
            string query = "SELECT 1 FROM Suppliers WHERE SupplierID = @SupplierID";
            using (SqlCommand cmd = new SqlCommand(query, connection, transaction))
            {
                cmd.Parameters.AddWithValue("@SupplierID", supplierId);
                return (await cmd.ExecuteScalarAsync()) != null;
            }
        }

        private async Task InsertSupplier(SqlConnection connection, SqlTransaction transaction, string supplierId)
        {
            string query = "INSERT INTO Suppliers (SupplierID) VALUES (@SupplierID)";
            using (SqlCommand cmd = new SqlCommand(query, connection, transaction))
            {
                cmd.Parameters.AddWithValue("@SupplierID", supplierId);
                await cmd.ExecuteNonQueryAsync();
            }
        }

        private async Task LoadSuppliersAsync()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();
                    string query = "SELECT SupplierID FROM Suppliers";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    cmbSuppliers.BeginUpdate();
                    cmbSuppliers.DataSource = dt;
                    cmbSuppliers.DisplayMember = "SupplierID";
                    cmbSuppliers.EndUpdate();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading suppliers: {ex.Message}");
            }
        }
    }
}
