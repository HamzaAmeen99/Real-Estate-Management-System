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
    public partial class UnitSaleForm : Form
    {
        public UnitSaleForm()
        {
            InitializeComponent();
            txtContact.KeyPress += NumericTextOnly_KeyPress;
        }

        private string connectionString = DatabaseHelper.GetConnectionString();

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
            new UnitsManagementForm().Show();
        }

        private void NumericTextOnly_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow numbers, backspace, and + sign only
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '+')
            {
                e.Handled = true;
            }
        }

        private void btnCnfrm_Click(object sender, EventArgs e)
        {
            // Validate inputs (ensure all required fields are filled)
            if (!ValidateInputs()) return;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlTransaction transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            dynamic selectedUnit = cmbUnits.SelectedItem;
                            string customerID = txtCustomerID.Text.Trim();

                            // 1. Insert Customer
                            string insertCustomer = @"
                        INSERT INTO Customers (CustomerID, CustomerName, ContactNumber, Email, AddressID, Role)
                        VALUES (@CustomerID, @Name, @Contact, @Email, @AddressID, @Role)";

                            using (SqlCommand cmd = new SqlCommand(insertCustomer, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@CustomerID", customerID);
                                cmd.Parameters.AddWithValue("@Name", txtCustomerName.Text.Trim());
                                cmd.Parameters.AddWithValue("@Contact", txtContact.Text.Trim());
                                cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                                cmd.Parameters.AddWithValue("@AddressID", selectedUnit.AddressID);
                                cmd.Parameters.AddWithValue("@Role", txtRole.Text.Trim());
                                cmd.ExecuteNonQuery();
                            }

                            // 2. Insert Payment with Date
                            string insertPayment = @"
    INSERT INTO Payments (CustomerID, PaymentStatus, PaymentDate, PaymentAmount)
    VALUES (@CustomerID, @Status, @Date, @PaymentAmount)";

                            using (SqlCommand cmd = new SqlCommand(insertPayment, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@CustomerID", customerID);
                                cmd.Parameters.AddWithValue("@Status", cmbPaymentStatus.SelectedItem.ToString());
                                cmd.Parameters.AddWithValue("@Date", dateTimePicker1.Value.Date);

                                //Added Now
                                decimal paymentAmount = ((UnitInfo)cmbUnits.SelectedItem).Price;
                                cmd.Parameters.AddWithValue("@PaymentAmount", paymentAmount); // Updated parameter name

                                cmd.ExecuteNonQuery();
                            }

                            // 3. Insert Project Interests
                            string[] interests = txtProjectInterest.Text.Split(
                                new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                            foreach (string interest in interests)
                            {
                                using (SqlCommand cmd = new SqlCommand(
                                    "INSERT INTO ProjectInterests (CustomerID, ProjectInterest) " +
                                    "VALUES (@CustomerID, @Interest)",
                                    conn, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@CustomerID", customerID);
                                    cmd.Parameters.AddWithValue("@Interest", interest.Trim());
                                    cmd.ExecuteNonQuery();
                                }
                            }

                            // 4. Mark Unit as Sold
                            using (SqlCommand cmd = new SqlCommand(
                                "DELETE FROM Units WHERE UnitID = @UnitID",
                                conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@UnitID", selectedUnit.UnitID);
                                cmd.ExecuteNonQuery();
                            }

                            transaction.Commit();

                            MessageBox.Show("Sale recorded successfully!");
                            this.Close();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show($"Error: {ex.Message}\n\nTransaction rolled back.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
            //this.Close();
        }



        private void UnitSaleForm_Load(object sender, EventArgs e)
        {
            
                txtCustomerID.Text = GetNextCustomerID();
                // ... rest of your load code ...
            
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"
    SELECT u.UnitID, u.AddressID, 
           a.StreetAddress + ', ' + a.Area + ', ' + a.City AS FullAddress, 
           u.Price
    FROM Units u
    JOIN Addresses a ON u.AddressID = a.AddressID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    var unitList = new List<UnitInfo>(); // Use UnitInfo

                    while (reader.Read())
                    {
                        unitList.Add(new UnitInfo
                        {
                            UnitID = (int)reader["UnitID"],
                            AddressID = (int)reader["AddressID"],
                            FullAddress = reader["FullAddress"].ToString(),
                            Price = (decimal)reader["Price"]
                        });
                    }

                    cmbUnits.DataSource = unitList;
                    cmbUnits.DisplayMember = "FullAddress";
                    cmbUnits.ValueMember = "UnitID";
                }
            }
            cmbPaymentStatus.Items.AddRange(new[] { "Paid", "Unpaid", "Pending" });
            txtCustomerID.Text = GetNextCustomerID();
        }

        private void cmbPaymentStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbUnits_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbUnits.SelectedItem != null)
            {
                dynamic selectedUnit = cmbUnits.SelectedItem;
                txtFullAddress.Text = selectedUnit.FullAddress;
                txtPrice.Text = selectedUnit.Price.ToString(); // ✅ Convert to string
            }
        }

        private bool ValidateCustomerID()
        {
            string customerID = txtCustomerID.Text.Trim();
            Regex regex = new Regex(@"^CUST\d+$"); // Allows more than 3 digits

            if (!regex.IsMatch(customerID))
            {
                MessageBox.Show($"Invalid format! Example: {GetNextCustomerID()}");
                return false;
            }

            // Check if CustomerID already exists
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM Customers WHERE CustomerID = @CustomerID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CustomerID", customerID);
                    int count = (int)cmd.ExecuteScalar();
                    if (count > 0)
                    {
                        MessageBox.Show("CustomerID already exists!");
                        return false;
                    }
                }
            }
            return true;
        }

        private string GetNextCustomerID()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Query to get the highest numeric portion of CustomerIDs
                string query = @"
            SELECT MAX(CAST(SUBSTRING(CustomerID, 5, LEN(CustomerID) - 4) AS INT))
            FROM Customers
            WHERE CustomerID LIKE 'CUST[0-9]%'
            AND ISNUMERIC(SUBSTRING(CustomerID, 5, LEN(CustomerID) - 4)) = 1";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    object result = cmd.ExecuteScalar();

                    // Start with 1 if no existing IDs, otherwise increment
                    int nextNumber = 1;
                    if (result != null && result != DBNull.Value)
                    {
                        nextNumber = (int)result + 1;
                    }

                    // Format with minimum 3 digits (001, 010, 100, 1000, etc.)
                    return $"CUST{nextNumber:D3}";
                }
            }
        }

        private bool ValidateInputs()
        {
            // 1. Check empty fields with specific warnings
            if (cmbUnits.SelectedItem == null)
            {
                MessageBox.Show("Please select a unit!");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtCustomerName.Text))
            {
                MessageBox.Show("Customer Name is required!");
                txtCustomerName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtContact.Text))
            {
                MessageBox.Show("Contact Number is required!");
                txtContact.Focus();
                return false;
            }

            if (cmbPaymentStatus.SelectedItem == null)
            {
                MessageBox.Show("Select Payment Status!");
                return false;
            }

            // 👇 Phone validation
            if (!Regex.IsMatch(txtContact.Text.Trim(), @"^\+?[0-9\s\-\(\)]{7,15}$"))
            {
                MessageBox.Show("Invalid phone number!\nExample: +1234567890");
                txtContact.Focus();
                return false;
            }

            // 👇 Email validation
            if (!Regex.IsMatch(txtEmail.Text.Trim(), @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
            {
                MessageBox.Show("Invalid email!\nExample: name@example.com");
                txtEmail.Focus();
                return false;
            }

            // 👇 Role validation
            if (string.IsNullOrWhiteSpace(txtRole.Text.Trim()))
            {
                MessageBox.Show("Role is required!");
                txtRole.Focus();
                return false;
            }

            // 👇 Project interests validation
            if (string.IsNullOrWhiteSpace(txtProjectInterest.Text.Trim()))
            {
                MessageBox.Show("At least 1 Project Interest required!");
                txtProjectInterest.Focus();
                return false;
            }

            // Original CustomerID check
            if (!ValidateCustomerID()) return false;

            return true;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }

    // Add this class to your namespace
    public class UnitInfo
    {
        public int UnitID { get; set; }
        public int AddressID { get; set; }
        public string FullAddress { get; set; }
        public decimal Price { get; set; }
    }
}
