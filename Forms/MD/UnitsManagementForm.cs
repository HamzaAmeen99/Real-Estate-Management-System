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
using System.Windows.Forms.DataVisualization.Charting;

namespace RECMS.Forms.MD
{
    public partial class UnitsManagementForm : Form
    {
        // Add connection string HERE(inside the class)
        private string connectionString = DatabaseHelper.GetConnectionString();

        private Timer timerSales;
        private DateTime _lastMonthUpdateTime = DateTime.MinValue;
        private int _currentMonth = DateTime.Now.Month;

        // Constructor and other code below
        public UnitsManagementForm()
        {
            InitializeComponent();


            CustData.CellBeginEdit += CustData_CellBeginEdit;
            // Initialize Timer
            timerSales = new Timer();
            timerSales.Interval = 5000; // 5 seconds
            timerSales.Tick += timerSales_Tick; // Connect handler
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            // Find the main form (MD_homeForm) and show it
            foreach (Form form in Application.OpenForms)
            {
                if (form is MD_homeForm)
                {
                    form.Show(); // Bring it to the front
                    form.WindowState = FormWindowState.Normal; // Restore if minimized
                    break;
                }
            }

            // Close the current form
            this.Close();
        }

        private void btnMarkSold_Click(object sender, EventArgs e)
        {
            this.Hide();
            new UnitSaleForm().Show();
        }

        private void btnAddUnit_Click(object sender, EventArgs e)
        {
            // Create and show AddUnitForm
            AddUnitForm addForm = new AddUnitForm();
            addForm.Owner = this; // Set current form as owner
            this.Hide();          // Hide current form
            addForm.Show();       // Show new form
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            this.Hide();
            new UnitReportForm().Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

            // Show the main form (replace "MainForm" with your actual main form's class name)
            new MD_homeForm().Show();

            // Close the current form
            this.Close();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async void UnitsManagementForm_Load(object sender, EventArgs e)
        
        {
            // Enable drag
            FormDragHelper.MakeDraggable(this, panel1);

            LoadCustomerData(); // Load without date filter initially
            LoadPaymentStatusChart();

            await Task.WhenAll(
                UpdateCurrentMonthSalesAsync(),
                UpdateLastMonthSalesAsync(),
                UpdateAvailableUnitsAsync()
            );

            timerSales.Start();
        }

        private void LoadCustomerData(DateTime? startDate = null, DateTime? endDate = null)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = @"
                SELECT 
                    c.CustomerID,
                    c.CustomerName,
                    c.ContactNumber,
                    c.Email,
                    a.StreetAddress,
                    a.Area,
                    a.City,
                    p.PaymentID,
                    p.PaymentAmount,
                    p.PaymentStatus,
                    p.PaymentDate, -- Add PaymentDate to display in grid
                    c.Role,
                    STRING_AGG(pi.ProjectInterest, ', ') AS ProjectInterests
                FROM Customers c
                JOIN Addresses a ON c.AddressID = a.AddressID
                LEFT JOIN Payments p ON c.CustomerID = p.CustomerID
                LEFT JOIN ProjectInterests pi ON c.CustomerID = pi.CustomerID
                WHERE 
                    (@StartDate IS NULL OR p.PaymentDate >= @StartDate)
                    AND (@EndDate IS NULL OR p.PaymentDate <= @EndDate)
                GROUP BY c.CustomerID, c.ContactNumber, c.CustomerName, a.StreetAddress, 
                    a.Area, a.City, p.PaymentID, p.PaymentAmount, p.PaymentStatus, p.PaymentDate, c.[Role], c.Email;";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    adapter.SelectCommand.Parameters.AddWithValue("@StartDate", startDate ?? (object)DBNull.Value);
                    adapter.SelectCommand.Parameters.AddWithValue("@EndDate", endDate ?? (object)DBNull.Value);

                    DataTable dt = new DataTable();
                    conn.Open();
                    adapter.Fill(dt);

                    // Bind to DataGridView
                    CustData.DataSource = dt;
                    CustData.Columns["PaymentID"].Visible = false;
                    CustData.Columns["PaymentAmount"].Visible = false;
                    CustData.Columns["PaymentDate"].HeaderText = "Payment Date"; // Add this line
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}");
            }
        }

        private void LoadPaymentStatusChart()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Query to count payment statuses
                    string query = @"
                SELECT 
                    PaymentStatus, 
                    COUNT(*) AS StatusCount 
                FROM Payments 
                GROUP BY PaymentStatus;";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Clear existing data
                    chartPaymentStatus.Series["seriesPaymentStatus"].Points.Clear();

                    // Add data to chart
                    while (reader.Read())
                    {
                        string status = reader["PaymentStatus"].ToString();
                        int count = Convert.ToInt32(reader["StatusCount"]);
                        chartPaymentStatus.Series["seriesPaymentStatus"].Points.AddXY(status, count);
                    }

                    reader.Close();
                }

                // Optional: Format the chart
                FormatChart();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading chart: {ex.Message}");
            }
        }

        private void FormatChart()
        {
            chartPaymentStatus.Titles.Clear(); // 👈 Add this line
            // Customize chart appearance
            chartPaymentStatus.Titles.Add("Payment Status Distribution");
            chartPaymentStatus.Series["seriesPaymentStatus"].IsValueShownAsLabel = true;
            chartPaymentStatus.Series["seriesPaymentStatus"].LabelFormat = "#,##0"; // Format labels
            chartPaymentStatus.Series["seriesPaymentStatus"].Font = new Font("Arial", 10);
            chartPaymentStatus.Legends[0].Title = "Payment Status";
            chartPaymentStatus.ChartAreas[0].Area3DStyle.Enable3D = false;
            chartPaymentStatus.Palette = ChartColorPalette.Pastel;
            chartPaymentStatus.Series["seriesPaymentStatus"].ToolTip = "#VALX: #VALY";
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadCustomerData();  // Refresh only customer data
            LoadPaymentStatusChart();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            string searchName = txtSearchName.Text.Trim();
            string searchContact = txtSearchContact.Text.Trim(); // Updated variable

            // Optional: Validate contact number format
            if (!Regex.IsMatch(searchContact, @"^\+?[0-9\s\-\(\)]*$") && !string.IsNullOrEmpty(searchContact))
            {
                MessageBox.Show("Invalid contact number format!");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {

                string query = @"
    SELECT 
        c.CustomerID,
        c.AddressID,
        c.ContactNumber,
        c.CustomerName,
        c.Email,
        a.StreetAddress,
        a.Area,
        a.City,
        p.PaymentStatus,
        p.PaymentAmount,
        c.Role,
        STRING_AGG(pi.ProjectInterest, ', ') AS ProjectInterests
    FROM Customers c
    JOIN Addresses a ON c.AddressID = a.AddressID
    LEFT JOIN Payments p ON c.CustomerID = p.CustomerID
    LEFT JOIN ProjectInterests pi ON c.CustomerID = pi.CustomerID
    WHERE c.CustomerName LIKE @Name 
       OR c.ContactNumber LIKE @Contact 
    GROUP BY c.CustomerID, c.AddressID, c.ContactNumber, c.CustomerName, a.StreetAddress, 
             a.Area, a.City, p.PaymentStatus, p.PaymentAmount, c.Role, c.Email;";

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.SelectCommand.Parameters.AddWithValue("@Name", $"%{searchName}%");
                adapter.SelectCommand.Parameters.AddWithValue("@Contact", $"%{searchContact}%");

                DataTable dt = new DataTable();
                adapter.Fill(dt);

                CustData.DataSource = dt;
                if (CustData.Columns.Contains("ContactNumber"))
                {
                    CustData.Columns["ContactNumber"].HeaderText = "Contact Number";
                }

                if (CustData.Columns.Contains("Email"))
                {
                    CustData.Columns["Email"].HeaderText = "Email"; // Optional: Set header text
                }

                if (CustData.Columns.Contains("PaymentAmount"))
                {
                    CustData.Columns["PaymentAmount"].Visible = false;
                }

            }
        }


        private void CustData_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            // Block editing for CustomerID column
            if (CustData.Columns[e.ColumnIndex].Name == "CustomerID")
            {
                e.Cancel = true;
                MessageBox.Show("CustomerID cannot be modified!");
            }
        }

        private void CustData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // Handle PaymentStatus with combobox
            if (CustData.Columns[e.ColumnIndex].Name == "PaymentStatus")
            {
                DataGridViewComboBoxCell comboCell = new DataGridViewComboBoxCell();
                comboCell.Items.AddRange("Paid", "Pending", "Unpaid");
                CustData[e.ColumnIndex, e.RowIndex] = comboCell;
            }
        }

        private void CustData_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            string columnName = CustData.Columns[e.ColumnIndex].Name;
            string newValue = e.FormattedValue.ToString();

            // Validation rules
            switch (columnName)
            {
                case "PaymentStatus":
                    if (!new[] { "Paid", "Pending", "Unpaid" }.Contains(newValue))
                    {
                        e.Cancel = true;
                        MessageBox.Show("Invalid Payment Status!");
                    }
                    break;

                case "ContactNumber":
                    if (!Regex.IsMatch(newValue, @"^\+?[0-9\s\-\(\)]{7,15}$"))
                    {
                        e.Cancel = true;
                        MessageBox.Show("Invalid Phone Format!\nExample: +1234567890");
                    }
                    break;

                case "Email":
                    if (!Regex.IsMatch(newValue, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                    {
                        e.Cancel = true;
                        MessageBox.Show("Invalid Email Format!\nExample: user@domain.com");
                    }
                    break;

                case "Price":
                    if (!decimal.TryParse(newValue, out decimal price) || price <= 0)
                    {
                        e.Cancel = true;
                        MessageBox.Show("Invalid Price!\nMust be positive number");
                    }
                    break;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Update Customers
                    SqlDataAdapter custAdapter = new SqlDataAdapter("SELECT * FROM Customers", conn);
                    SqlCommandBuilder custBuilder = new SqlCommandBuilder(custAdapter);
                    DataTable custDt = ((DataTable)CustData.DataSource);
                    custAdapter.Update(custDt);

                    if (custDt != null)
                    {
                        custAdapter.Update(custDt);
                    }

                    // Update Payments
                    SqlDataAdapter paymentAdapter = new SqlDataAdapter("SELECT PaymentID, CustomerID, PaymentStatus, PaymentAmount FROM Payments", conn);
                    SqlCommandBuilder paymentBuilder = new SqlCommandBuilder(paymentAdapter);
                    DataTable paymentDt = new DataTable();
                    paymentAdapter.Fill(paymentDt); // Load Payments data directly

                    foreach (DataRow custRow in custDt.Rows)
                    {
                        string customerID = custRow["CustomerID"].ToString();
                        string paymentStatus = custRow["PaymentStatus"].ToString();
                        decimal paymentAmount = Convert.ToDecimal(custRow["PaymentAmount"]);
                        DataRow[] paymentRows = paymentDt.Select($"CustomerID = '{customerID}'");
                        if (paymentRows.Length > 0)
                        {
                            paymentRows[0]["PaymentStatus"] = paymentStatus;
                            paymentRows[0]["PaymentAmount"] = paymentAmount; // Updated column name
                        }
                    }

                    paymentAdapter.Update(paymentDt);


                    MessageBox.Show("Changes saved successfully!");
                }

                // Refresh the payment chart after saving
                LoadPaymentStatusChart(); // 👈 Added this line
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Save Error: {ex.Message}");
            }
        }

        private void txtSearchAddress_TextChanged(object sender, EventArgs e)
        {

        }

        private async Task UpdateLastMonthSalesAsync()
        {
            try
            {
                decimal lastMonthSales = 0;

                await Task.Run(() =>
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        string query = @"
                    SELECT COALESCE(SUM(PaymentAmount), 0) 
                    FROM Payments 
                    WHERE 
                        PaymentDate >= DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()) - 1, 0)
                        AND PaymentDate < DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()), 0)";

                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            lastMonthSales = Convert.ToDecimal(cmd.ExecuteScalar());
                        }
                    }
                });

                Console.WriteLine($"[DEBUG] Last Month Sales: {lastMonthSales:N2}"); //Debug Log

                // Update UI safely
                if (lblLastMonthSales.InvokeRequired)
                {
                    lblLastMonthSales.Invoke((MethodInvoker)delegate
                    {
                        lblLastMonthSales.Text = $"{lastMonthSales:N2}";
                    });
                }
                else
                {
                    lblLastMonthSales.Text = $"{lastMonthSales:N2}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating last month sales: {ex.Message}");
            }
        }

        private async Task UpdateCurrentMonthSalesAsync()
        {
            try
            {
                decimal currentMonthSales = 0;

                await Task.Run(() =>
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        string query = @"
                    SELECT COALESCE(SUM(PaymentAmount), 0) 
                    FROM Payments 
                    WHERE 
                        YEAR(PaymentDate) = YEAR(GETDATE()) 
                        AND MONTH(PaymentDate) = MONTH(GETDATE())";

                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            currentMonthSales = Convert.ToDecimal(cmd.ExecuteScalar());
                        }
                    }
                });

                // Update UI safely
                if (lblCurrentMonthSales.InvokeRequired)
                {
                    lblCurrentMonthSales.Invoke((MethodInvoker)delegate
                    {
                        lblCurrentMonthSales.Text = $"{currentMonthSales:N2}";
                    });
                }
                else
                {
                    lblCurrentMonthSales.Text = $"{currentMonthSales:N2}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating current month sales: {ex.Message}");
            }
        }

        private async void timerSales_Tick(object sender, EventArgs e)
        {
            // Always update current month sales
            await UpdateCurrentMonthSalesAsync();
            await UpdateAvailableUnitsAsync();

            // Update last month sales only if the month has changed
            if (DateTime.Now.Month != _currentMonth)
            {
                await UpdateLastMonthSalesAsync();
                _currentMonth = DateTime.Now.Month;
            }
        }

        private void lblCurrentMonthSales_Click(object sender, EventArgs e)
        {

        }

        private async Task UpdateAvailableUnitsAsync()
        {
            try
            {
                int availableUnits = 0;

                await Task.Run(() =>
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        string query = "SELECT COUNT(*) FROM Units"; // Count all units
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            availableUnits = Convert.ToInt32(cmd.ExecuteScalar());
                        }
                    }
                });

                // Update label with 2-digit format (e.g., "05" instead of "5")
                if (lblavlbunits.InvokeRequired)
                {
                    lblavlbunits.Invoke((MethodInvoker)delegate
                    {
                        lblavlbunits.Text = availableUnits.ToString("D2"); // "D2" = 2-digit format
                    });
                }
                else
                {
                    lblavlbunits.Text = availableUnits.ToString("D2");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating available units: {ex.Message}");
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            DateTime startDate = dtpStartDate.Value.Date;
            DateTime endDate = dtpEndDate.Value.Date.AddDays(1); // Include entire end day

            // Swap dates if reversed
            if (startDate > endDate)
            {
                DateTime temp = startDate;
                startDate = endDate;
                endDate = temp;
            }

            LoadCustomerData(startDate, endDate);
        }
    }

}
