using RECMS;
using RECMS.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RECMS.CEO
{
    public partial class DashboardForm : Form
    {
        private string connectionString = DatabaseHelper.GetConnectionString();
        private bool _dragging = false;
        private Point _dragCursorPoint;
        private Point _dragFormPoint;

        private Timer timerSales;
        private DateTime _lastMonthUpdateTime = DateTime.MinValue;
        private int _currentMonth = DateTime.Now.Month;
        private int _currentRow;
        private DataGridView _currentGrid;
        private int _pageNumber = 1;
        private DataGridView _currentPrintGrid; // Track which grid to print
        private readonly Color _headerColor = Color.FromArgb(0, 100, 0); // Dark green
        private readonly Color _headerTextColor = Color.White;
        public DashboardForm()
        {
            InitializeComponent();

            // Mouse dragging for custom title bar
            panelTitleBar.MouseDown += Panel_MouseDown;
            panelTitleBar.MouseMove += Panel_MouseMove;
            panelTitleBar.MouseUp += Panel_MouseUp;

            // Configure controls
            ConfigureDataGridViews();

            // Timer setup
            timerSales = new Timer();
            timerSales.Interval = 5000;
            timerSales.Tick += timerSales_Tick;
            timerSales.Start();

            // Prevent auto scaling and sizing issues
            //this.AutoScaleMode = AutoScaleMode.None;
            //this.AutoSize = false;

            //// Lock form size strictly
            //Size fixedSize = new Size(1200, 800);
            //this.Size = fixedSize;
            //this.MinimumSize = fixedSize;
            //this.MaximumSize = fixedSize;

            //// Start in the center
            //this.StartPosition = FormStartPosition.CenterScreen;

            //// Ensure normal (not maximized) state
            //this.WindowState = FormWindowState.Normal;

            // Printing
            printDocument1.PrintPage += printDocument_PrintPage;

            // Optional fix for display quirks
            //this.Shown += DashboardForm_Shown;
        }

        private void DashboardForm_Shown(object sender, EventArgs e)
        {
            
            //this.Size = new Size(1200, 800);
        }



        private void Panel_MouseDown(object sender, MouseEventArgs e)
        {
            _dragging = true;
            _dragCursorPoint = System.Windows.Forms.Cursor.Position;
            _dragFormPoint = this.Location;
        }

        private void Panel_MouseMove(object sender, MouseEventArgs e)
        {
            if (_dragging)
            {
                Point dif = Point.Subtract(System.Windows.Forms.Cursor.Position, new Size(_dragCursorPoint));
                this.Location = Point.Add(_dragFormPoint, new Size(dif));
            }
        }

        private void Panel_MouseUp(object sender, MouseEventArgs e)
        {
            _dragging = false;
        }

        private void ConfigureDataGridViews()
        {
            // For Materials Grid
            dgvMaterials.Columns.AddRange(new DataGridViewColumn[] {
        new DataGridViewTextBoxColumn { Name = "MaterialName", HeaderText = "Material Name", DataPropertyName = "MaterialName"},
        new DataGridViewTextBoxColumn { Name = "SupplierName", HeaderText = "Supplier", DataPropertyName = "SupplierName"},
        new DataGridViewTextBoxColumn {Name = "Quantity", HeaderText = "Qty",DataPropertyName = "Quantity"},
        // Rest of columns...
    });

            // Configure Labor DataGridView
            dgvLabor.AutoGenerateColumns = false;
            dgvLabor.Columns.AddRange(new DataGridViewColumn[] {
                new DataGridViewTextBoxColumn { Name = "WorkerName", HeaderText = "Name", DataPropertyName = "WorkerName" },
                new DataGridViewTextBoxColumn { Name = "ContractorName", HeaderText = "Contractor", DataPropertyName = "ContractorName" },
                new DataGridViewTextBoxColumn { Name = "DaysWorked", HeaderText = "Days", DataPropertyName = "DaysWorked" },
                new DataGridViewTextBoxColumn { Name = "Rate", HeaderText = "Rate", DataPropertyName = "Rate", DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" } },
                new DataGridViewTextBoxColumn { Name = "Salary", HeaderText = "Salary", DataPropertyName = "Salary", DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" } }
            });
        }

        // Modified LoadMaterialDataAsync
        private async Task LoadMaterialDataAsync(string projectId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string query = @"
                SELECT 
                    M.MaterialID AS MaterialName,
                    S.SupplierID AS SupplierName, 
                    PM.Quantity,
                    PM.CostPerUnit,
                    PM.PurchaseDate
                FROM ProjectMaterials PM
                INNER JOIN Materials M ON PM.MaterialID = M.MaterialID
                INNER JOIN Suppliers S ON PM.SupplierID = S.SupplierID
                WHERE PM.ProjectID = @ProjectID";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ProjectID", projectId);

                    DataTable dt = new DataTable();
                    dt.Load(await cmd.ExecuteReaderAsync());
                    dgvMaterials.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Material load error: {ex.Message}");
            }
        }

        // Modified LoadLaborDataAsync
        private async Task LoadLaborDataAsync(string projectId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string query = @"
                     SELECT 
                         W.WorkerName AS WorkerName,       -- Use WorkerName instead of WorkerID
                         C.ContractorName AS ContractorName, -- Use ContractorName instead of ContractorID
                         PL.DaysWorked,
                         PL.Rate,
                         (PL.DaysWorked * PL.Rate) AS Salary
                         FROM ProjectLabor PL
                         INNER JOIN Workers W ON PL.WorkerID = W.WorkerID
                         INNER JOIN Contractors C ON W.ContractorID = C.ContractorID
                         WHERE PL.ProjectID = @ProjectID";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ProjectID", projectId);

                    DataTable dt = new DataTable();
                    dt.Load(await cmd.ExecuteReaderAsync());
                    dgvLabor.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Labor load error: {ex.Message}");
            }
        }

        private void LoadProjectData()
        {
           
        }
        
        private async void DashboardForm_Load(object sender, EventArgs e)
        {
            UIHelpers.RoundButton(btnRefresh, 7);
            UIHelpers.RoundButton(btnSearch, 7);
            // Set the specific size
            //this.Size = new Size(1200, 800); // Width = 1200, Height = 800

            //// center the form on the screen
            //this.StartPosition = FormStartPosition.CenterScreen;
            try
            {
                await LoadProjectsAsync();

                if (cmbProjects.Items.Count > 0)
                {
                    cmbProjects.SelectedIndex = 0;
                    // Load data for first project
                    await LoadMaterialDataAsync(cmbProjects.SelectedValue.ToString());
                    await LoadLaborDataAsync(cmbProjects.SelectedValue.ToString());
                    UpdateAllExpenses();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Initial load error: {ex.Message}");
            }

            await Task.WhenAll(
                     LoadSoldUnitsData(searchName: "", searchContact: "", startDate: null, endDate: null),
                     UpdateCurrentMonthSalesAsync(),
                     UpdateLastMonthSalesAsync(),
                     UpdateAvailableUnitsAsync(),
                     LoadAvailableUnitsDataAsync()
            );
        }

        // Load projects into ComboBox (reusable)
        private async Task LoadProjectsAsync()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                await conn.OpenAsync();
                string query = "SELECT ProjectID, ProjectName FROM Projects";

                SqlCommand cmd = new SqlCommand(query, conn);
                DataTable dt = new DataTable();
                dt.Load(await cmd.ExecuteReaderAsync());

                // Bind ComboBox
                cmbProjects.DisplayMember = "ProjectName";
                cmbProjects.ValueMember = "ProjectID";
                cmbProjects.DataSource = dt;
            }
        }

        // Update all expense labels (call this whenever data changes)
        private void UpdateAllExpenses()
        {
            UpdateTotalMaterialExpensesUnfiltered();
            UpdateTotalLaborExpenses();
            UpdateTotalBudgetExpenses();
        }

        // Material cost (unfiltered)
        private void UpdateTotalMaterialExpensesUnfiltered()
        {
            decimal total = 0;
            foreach (DataGridViewRow row in dgvMaterials.Rows)
            {
                if (row.Cells["Quantity"].Value != null &&
                    row.Cells["CostPerUnit"].Value != null)
                {
                    total += Convert.ToInt32(row.Cells["Quantity"].Value) *
                            Convert.ToDecimal(row.Cells["CostPerUnit"].Value);
                }
            }
            lblTotalMaterialExpensesUnfiltered.Text = $"Pkr {total:N0}";
        }

        // Labor cost (unfiltered)
        private void UpdateTotalLaborExpenses()
        {
            decimal total = 0;
            foreach (DataGridViewRow row in dgvLabor.Rows)
            {
                if (row.Cells["Salary"].Value != null)
                {
                    total += Convert.ToDecimal(row.Cells["Salary"].Value);
                }
            }
            lblTotalLaborExpenses.Text = $"Pkr {total:N0}";
        }

        // Total budget
        private void UpdateTotalBudgetExpenses()
        {
            decimal materialTotal = 0, laborTotal = 0;

            if (!string.IsNullOrEmpty(lblTotalMaterialExpensesUnfiltered.Text))
                materialTotal = Convert.ToDecimal(lblTotalMaterialExpensesUnfiltered.Text.Replace("Pkr", "").Trim());

            if (!string.IsNullOrEmpty(lblTotalLaborExpenses.Text))
                laborTotal = Convert.ToDecimal(lblTotalLaborExpenses.Text.Replace("Pkr", "").Trim());

            lblTotalBudgetExpenses.Text = $"Pkr {materialTotal + laborTotal:N0}";
        }

        // When project changes
        private async void cmbProjects_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cmbProjects.SelectedValue == null) return;
            string projectId = cmbProjects.SelectedValue.ToString();

            // Refresh data for the newly selected project
            await LoadMaterialDataAsync(projectId);
            await LoadLaborDataAsync(projectId);
            UpdateAllExpenses();
        }

        // After adding/deleting data
        public async void RefreshData()
        {
            if (cmbProjects.SelectedValue != null)
            {
                string projectId = cmbProjects.SelectedValue.ToString();
                await LoadMaterialDataAsync(projectId);
                await LoadLaborDataAsync(projectId);
            }
            UpdateAllExpenses();
        }

        private void panelMainContent_Paint(object sender, PaintEventArgs e) { }
        private void panelRevenue_Paint(object sender, PaintEventArgs e) { }
        private void panelExpenses_Paint(object sender, PaintEventArgs e) { }
        private void panelNetProfit_Paint(object sender, PaintEventArgs e) { }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            if (cmbProjects.SelectedValue != null)
            {
                string projectId = cmbProjects.SelectedValue.ToString();
                await LoadMaterialDataAsync(projectId);
                await LoadLaborDataAsync(projectId);
                UpdateAllExpenses();
            }
        }

        private async Task LoadSoldUnitsData(
    string searchName = "",
    string searchContact = "",
    DateTime? startDate = null,
    DateTime? endDate = null)
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
                    p.PaymentDate,
                    p.PaymentAmount,
                    a.StreetAddress,
                    p.PaymentStatus
                FROM Customers c
                JOIN Addresses a ON c.AddressID = a.AddressID
                LEFT JOIN Payments p ON c.CustomerID = p.CustomerID
                WHERE 
                    (c.CustomerName LIKE @Name OR @Name = '')
                    AND (c.ContactNumber LIKE @Contact OR @Contact = '')
                    AND (@StartDate IS NULL OR p.PaymentDate >= @StartDate)
                    AND (@EndDate IS NULL OR p.PaymentDate <= @EndDate)";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    adapter.SelectCommand.Parameters.AddWithValue("@Name", $"%{searchName}%");
                    adapter.SelectCommand.Parameters.AddWithValue("@Contact", $"%{searchContact}%");
                    adapter.SelectCommand.Parameters.AddWithValue("@StartDate", startDate ?? (object)DBNull.Value);
                    adapter.SelectCommand.Parameters.AddWithValue("@EndDate", endDate ?? (object)DBNull.Value);

                    DataTable dt = new DataTable();
                    await conn.OpenAsync();
                    adapter.Fill(dt);

                    dgvSoldUnits.DataSource = dt;

                    if (dgvSoldUnits.Columns.Contains("CustomerID"))
                    {
                        dgvSoldUnits.Columns["CustomerID"].Visible = false;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}");
            }
        }

        private async Task UpdateCurrentMonthSalesAsync()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string query = @"
                SELECT COALESCE(SUM(PaymentAmount), 0) 
                FROM Payments 
                WHERE 
                    YEAR(PaymentDate) = YEAR(GETDATE()) 
                    AND MONTH(PaymentDate) = MONTH(GETDATE())";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    decimal sales = Convert.ToDecimal(await cmd.ExecuteScalarAsync());
                    lblCurrentMonthSales.Text = $"Pkr {sales:N0}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating sales: {ex.Message}");
            }
        }

        private async Task UpdateLastMonthSalesAsync()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string query = @"
                SELECT COALESCE(SUM(PaymentAmount), 0) 
                FROM Payments 
                WHERE 
                    PaymentDate >= DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()) - 1, 0)
                    AND PaymentDate < DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()), 0)";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    decimal lastMonthSales = Convert.ToDecimal(await cmd.ExecuteScalarAsync());

                    // Update UI safely
                    if (lblLastMonthSales.InvokeRequired)
                    {
                        lblLastMonthSales.Invoke((MethodInvoker)delegate
                        {
                            lblLastMonthSales.Text = $"Pkr {lastMonthSales:N0}";
                        });
                    }
                    else
                    {
                        lblLastMonthSales.Text = $"Pkr {lastMonthSales:N0}";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating last month sales: {ex.Message}");
            }
        }

        private async Task UpdateAvailableUnitsAsync()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string query = "SELECT COUNT(*) FROM Units"; // Unsold units
                    SqlCommand cmd = new SqlCommand(query, conn);
                    int count = Convert.ToInt32(await cmd.ExecuteScalarAsync());
                    lblAvailableUnits.Text = count.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating units: {ex.Message}");
            }
        }

        private async void timerSales_Tick(object sender, EventArgs e)
        {
            await UpdateCurrentMonthSalesAsync();
            await UpdateAvailableUnitsAsync();

            // Update last month sales only once per month
            if (DateTime.Now.Month != _currentMonth)
            {
                await UpdateLastMonthSalesAsync();
                _currentMonth = DateTime.Now.Month;
            }
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

                dgvSoldUnits.DataSource = dt;
                if (dgvSoldUnits.Columns.Contains("ContactNumber"))
                {
                    dgvSoldUnits.Columns["ContactNumber"].HeaderText = "Contact Number";
                }

                if (dgvSoldUnits.Columns.Contains("Email"))
                {
                    dgvSoldUnits.Columns["Email"].HeaderText = "Email"; // Optional: Set header text
                }

                if (dgvSoldUnits.Columns.Contains("PaymentAmount"))
                {
                    dgvSoldUnits.Columns["PaymentAmount"].Visible = false;
                }

            }
        }

        private void label6_Click(object sender, EventArgs e) {   }
        private void lblTotalMaterialExpensesUnfiltered_Click(object sender, EventArgs e){ }
        private void label3_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e){}
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e){}
        private void label9_Click(object sender, EventArgs e){ }
        private void label1_Click(object sender, EventArgs e) { }
        private void label12_Click(object sender, EventArgs e){ }
        private void pictureBoxLogo_Click(object sender, EventArgs e){ }
        private void lblTotalBudgetExpenses_Click(object sender, EventArgs e){}
        private void lblTotalLaborExpenses_Click(object sender, EventArgs e) { }
        private void label5_Click(object sender, EventArgs e) { }
        private void panelTitleBar_Paint(object sender, PaintEventArgs e) { }
        private void label7_Click(object sender, EventArgs e) {  }

        private async void btnFilter_Click(object sender, EventArgs e)
        {
            // Declare variables locally
            DateTime startDate = dtpStartDate.Value.Date;
            DateTime endDate = dtpEndDate.Value.Date.AddDays(1); // Include entire end day

            // Swap dates if reversed
            if (startDate > endDate)
            {
                DateTime temp = startDate;
                startDate = endDate;
                endDate = temp;
            }

            await LoadSoldUnitsData(
                txtSearchName.Text.Trim(),
                txtSearchContact.Text.Trim(),
                startDate,
                endDate
            );
        }

        private async Task LoadAvailableUnitsDataAsync()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string query = @"
                SELECT 
                    a.StreetAddress,
                    a.Area,
                    a.City,
                    u.Price,
                    u.NOCStatus
                FROM Units u
                INNER JOIN Addresses a ON u.AddressID = a.AddressID";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dgvAvailableUnits.DataSource = dt;

                    // Format columns
                    dgvAvailableUnits.Columns["StreetAddress"].HeaderText = "Street Address";
                    dgvAvailableUnits.Columns["Area"].HeaderText = "Area/Sector";
                    dgvAvailableUnits.Columns["City"].HeaderText = "City";
                    dgvAvailableUnits.Columns["Price"].HeaderText = "Price (PKR)";
                    dgvAvailableUnits.Columns["Price"].DefaultCellStyle.Format = "N2"; // Currency format
                    dgvAvailableUnits.Columns["NOCStatus"].HeaderText = "NOC Status";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading units: {ex.Message}");
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e) {}

        private void btnPrintSoldUnits_Click(object sender, EventArgs e)
        {
            _currentPrintGrid = dgvSoldUnits;
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            if (_currentPrintGrid == null) return;

            // 1. Header Formatting
            Font headerFont = new Font("Arial", 18, FontStyle.Bold);
            Font subHeaderFont = new Font("Arial", 12);
            Font contentFont = new Font("Arial", 10);

            float yPos = 20;
            float leftMargin = e.MarginBounds.Left;
            float rightMargin = e.MarginBounds.Right;

            // 2. Company Header
            e.Graphics.DrawString("REAL ESTATE COMPANY", headerFont, Brushes.Black,
                new RectangleF(leftMargin, yPos, e.PageBounds.Width, headerFont.Height),
                new StringFormat { Alignment = StringAlignment.Center });
            yPos += headerFont.Height + 20;

            // 3. Report Title & Date
            string reportTitle;
            switch (_currentPrintGrid.Name)
            {
                case "dgvAvailableUnits":
                    reportTitle = "Available Units Report";
                    break;
                case "dgvSoldUnits":
                    reportTitle = "Sold Units Report";
                    break;
                default:
                    reportTitle = "Units Report";
                    break;
            }


            e.Graphics.DrawString(reportTitle, subHeaderFont, Brushes.Black, leftMargin, yPos);
            e.Graphics.DrawString(DateTime.Now.ToString("dd MMMM yyyy"), subHeaderFont, Brushes.Black,
                rightMargin - 150, yPos);
            yPos += subHeaderFont.Height + 30;

            // 4. Print ONLY the selected grid
            PrintDataGridView(_currentPrintGrid, ref yPos, e, reportTitle);

            // 5. Footer
            e.Graphics.DrawString($"Page {_pageNumber}", contentFont, Brushes.Black,
                new RectangleF(leftMargin, yPos + 20, e.PageBounds.Width, contentFont.Height),
                new StringFormat { Alignment = StringAlignment.Center });

            e.HasMorePages = false;
        }

        private void PrintDataGridView(DataGridView grid, ref float yPos, PrintPageEventArgs e, string title)
        {
            try
            {
                const float PAGE_PADDING = 20f; // Added safety margin
                var pageWidth = e.MarginBounds.Width - PAGE_PADDING * 2;
                var filteredData = ((DataTable)grid.DataSource)?.DefaultView?.ToTable() ?? new DataTable();

                // Declare all fonts in a single using block
                using (Font titleFont = new Font("Arial", 14, FontStyle.Bold))
                using (Font headerFont = new Font("Arial", 11, FontStyle.Bold))
                using (Font contentFont = new Font("Arial", 10))
                using (var greenBrush = new SolidBrush(Color.FromArgb(0, 100, 0)))
                using (var whiteBrush = new SolidBrush(Color.White))
                {
                    // 1. Header Panel
                    const int headerHeight = 100;
                    e.Graphics.FillRectangle(greenBrush, new Rectangle(0, 0, e.PageBounds.Width, headerHeight));

                    // 2. Logo
                    try
                    {
                        using (var logo = Image.FromFile("D:\\Ahmed Ali\\DB_Project_Demo1\\RECMS_80%\\RECMS\\Resources\\BFS White.png"))
                        {
                            var logoRect = new Rectangle(20, 10, 80, 80);
                            e.Graphics.DrawImage(logo, logoRect);
                        }
                    }
                    catch { /* Handle missing logo */ }

                    // 3. Company Header
                    using (var companyFont = new Font("Arial", 24, FontStyle.Bold))
                    using (var taglineFont = new Font("Arial", 12, FontStyle.Italic))
                    {
                        var companyRect = new RectangleF(120, 20, e.PageBounds.Width - 140, 40);
                        e.Graphics.DrawString("BFS", companyFont, whiteBrush, companyRect);

                        var taglineRect = new RectangleF(120, 60, e.PageBounds.Width - 140, 30);
                        e.Graphics.DrawString("Real Estate & Developers", taglineFont, whiteBrush, taglineRect);
                    }

                    // 4. Report Content
                    yPos = headerHeight + 20;

                    // Table Title
                    e.Graphics.DrawString(title, titleFont, Brushes.Black, e.MarginBounds.Left, yPos);
                    yPos += titleFont.Height + 10;

                    // Calculate column widths
                    float[] columnWidths = new float[grid.Columns.Count];
                    float totalWidth = 0;

                    for (int i = 0; i < grid.Columns.Count; i++)
                    {
                        if (grid.Columns[i].Visible)
                        {
                            columnWidths[i] = TextRenderer.MeasureText(grid.Columns[i].HeaderText, headerFont).Width + 20;
                            totalWidth += columnWidths[i];
                        }
                    }

                    // Draw Headers
                    float xPos = e.MarginBounds.Left;
                    for (int i = 0; i < grid.Columns.Count; i++)
                    {
                        if (grid.Columns[i].Visible)
                        {
                            e.Graphics.FillRectangle(Brushes.LightGray, xPos, yPos, columnWidths[i], headerFont.Height);
                            e.Graphics.DrawRectangle(Pens.Black, xPos, yPos, columnWidths[i], headerFont.Height);
                            e.Graphics.DrawString(
                                grid.Columns[i].HeaderText,
                                headerFont,
                                Brushes.Black,
                                new RectangleF(xPos, yPos, columnWidths[i], headerFont.Height),
                                new StringFormat { Alignment = StringAlignment.Center }
                            );
                            xPos += columnWidths[i];
                        }
                    }
                    yPos += headerFont.Height;

                    // Draw Rows
                    foreach (DataGridViewRow row in grid.Rows)
                    {
                        if (!row.Visible) continue;

                        xPos = e.MarginBounds.Left;
                        float rowHeight = 0;

                        for (int i = 0; i < grid.Columns.Count; i++)
                        {
                            if (!grid.Columns[i].Visible) continue;

                            string cellValue = row.Cells[i].FormattedValue?.ToString() ?? "";
                            var cellSize = e.Graphics.MeasureString(cellValue, contentFont);

                            e.Graphics.DrawString(
                                cellValue,
                                contentFont,
                                Brushes.Black,
                                new RectangleF(xPos, yPos, columnWidths[i], cellSize.Height)
                            );
                            e.Graphics.DrawRectangle(Pens.Black, xPos, yPos, columnWidths[i], cellSize.Height);

                            xPos += columnWidths[i];
                            if (cellSize.Height > rowHeight) rowHeight = cellSize.Height;
                        }

                        yPos += rowHeight;

                        // Check page bounds
                        if (yPos <= e.MarginBounds.Bottom) continue;

                        e.HasMorePages = true;
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Print error: {ex.Message}");
                e.Cancel = true;
            }
            finally
            {
                e.HasMorePages = false;
            }
        }

        private string GetReportTitle()
        {
            // Example implementation - customize this:
            return "CEO Monthly Performance Report";
        }

        private void PrintAvailableUnits_Click(object sender, EventArgs e)
        {
            _currentPrintGrid = dgvAvailableUnits;
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();


        }

        private void panelRevenue_Paint_1(object sender, PaintEventArgs e)
        {

        }
    }
}
