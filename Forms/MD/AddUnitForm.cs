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
using static System.Windows.Forms.MonthCalendar;

namespace RECMS.Forms.MD
{
    public partial class AddUnitForm : Form
    {
        public AddUnitForm()
        {
            InitializeComponent();
        }
        private void btnSave_Click(object sender, EventArgs e)

        {

            string connectionString = DatabaseHelper.GetConnectionString();

            try
            {
                // ======================
                // VALIDATION CHECKS (Updated)
                // ======================

                // Check required text fields
                if (string.IsNullOrWhiteSpace(txtStreetAddress.Text))
                {
                    MessageBox.Show("Please enter Street Address!");
                    txtStreetAddress.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtArea.Text))
                {
                    MessageBox.Show("Please enter Area/Sector!");
                    txtArea.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtCity.Text))
                {
                    MessageBox.Show("Please enter City!");
                    txtCity.Focus();
                    return;
                }

                // Validate price format
                if (!decimal.TryParse(txtPrice.Text, out decimal price) || price <= 0)
                {
                    MessageBox.Show("Please enter a valid positive price!");
                    txtPrice.Focus();
                    return;
                }

                // Only validate NOC Status (SalesStatus has default value)
                if (cmbNOCStatus.SelectedItem == null)
                {
                    MessageBox.Show("Please select NOC Status!");
                    cmbNOCStatus.Focus();
                    return;
                }

                // ======================
                // DATABASE OPERATIONS
                // ======================

                int addressId = -1;

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Start transaction to ensure atomic operations
                    using (SqlTransaction transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            // 1. Insert into Addresses table
                            string addressQuery = @"
                        INSERT INTO Addresses (StreetAddress, Area, City)
                        VALUES (@StreetAddress, @Area, @City);
                        SELECT SCOPE_IDENTITY();";

                            using (SqlCommand cmd = new SqlCommand(addressQuery, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@StreetAddress", txtStreetAddress.Text.Trim());
                                cmd.Parameters.AddWithValue("@Area", txtArea.Text.Trim());
                                cmd.Parameters.AddWithValue("@City", txtCity.Text.Trim());

                                addressId = Convert.ToInt32(cmd.ExecuteScalar());
                            }

                            // 2. Insert into Units table
                            string unitQuery = @"
                        INSERT INTO Units (AddressID, NOCStatus, Price)
                        VALUES (@AddressID, @NOCStatus, @Price)";

                            using (SqlCommand cmd = new SqlCommand(unitQuery, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@AddressID", addressId);
                                cmd.Parameters.AddWithValue("@NOCStatus", cmbNOCStatus.SelectedItem.ToString());
                                cmd.Parameters.AddWithValue("@Price", price);

                                cmd.ExecuteNonQuery();
                            }

                            // Commit transaction if both operations succeed
                            transaction.Commit();

                            MessageBox.Show("Unit added successfully!");
                            UnitsManagementForm unitsForm = new UnitsManagementForm();
                            unitsForm.Show();

                            this.Close();
                        }
                        catch (Exception ex)
                        {
                            // Rollback transaction if any error occurs
                            transaction.Rollback();
                            MessageBox.Show($"Error saving data: {ex.Message}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }

             // this. Close();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            // Show the owner form (UnitsManagementForm)
            if (this.Owner != null && this.Owner is UnitsManagementForm)
            {
                this.Owner.Show();
            }

            this.Close(); // Close current AddUnitForm
        }

        private void AddUnitForm_Load(object sender, EventArgs e)
        {
            // Enable drag
            FormDragHelper.MakeDraggable(this, panel1);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Unit entry cancelled!");
            this.Close();
        }
    }
}
