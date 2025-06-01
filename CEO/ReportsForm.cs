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
using System.Windows.Forms.DataVisualization.Charting;

namespace RECMS.CEO
{
    public partial class ReportsForm : Form
    {
        private string connectionString = DatabaseHelper.GetConnectionString();

        private bool _dragging = false;
        private Point _dragCursorPoint;
        private Point _dragFormPoint;

        private DataTable pivotedSectorData; // For sector comparison chart
        private Color[] statusColors = new Color[]
        {
             Color.FromArgb(44, 123, 182), // Paid (Blue)
             Color.FromArgb(215, 25, 28),  // Unpaid (Red)
             Color.FromArgb(255, 192, 0)   // Pending (Yellow)
        };

        public ReportsForm()
        {
            InitializeComponent();

            //this.Size = new Size(1200, 800);
            //this.StartPosition = FormStartPosition.CenterScreen;

            btnExportMaterial.Click += (s, e) => ExportChart(chartMaterialCost, "MaterialCosts");
            btnExportLabor.Click += (s, e) => ExportChart(chartLaborCost, "LaborCosts");
            btnExportSales.Click += (s, e) => ExportChart(chartSalesOverTime, "SalesOverTime");
            btnExportSector.Click += (s, e) => ExportChart(chartSectorComparison, "SectorComparison");

            InitializeCharts();
            InitializeSalesCharts();

            panel1.MouseDown += Panel_MouseDown;
            panel1.MouseMove += Panel_MouseMove;
            panel1.MouseUp += Panel_MouseUp;

            this.Load += async (sender, e) => await LoadProjects();
            cmbProjects.SelectedIndexChanged += async (sender, e) => await LoadChartData();

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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void ReportsForm_Load(object sender, EventArgs e)
        {
            // Enable drag
            FormDragHelper.MakeDraggable(this, panel1);

            // Set default dates to current month for Sales Over Time chart
            dtpSalesFrom.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpSalesTo.Value = DateTime.Now;

            // Auto-load both charts
            await LoadSalesOverTimeChart(dtpSalesFrom.Value, dtpSalesTo.Value); // Sales chart with current month
            await LoadSectorComparisonChart(); // Sector chart with all data

        }

        private void dataGridReports_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void InitializeCharts()
        {
            // Material Cost Chart
            chartMaterialCost.Series.Clear();
            chartMaterialCost.Titles.Clear();
            chartMaterialCost.Titles.Add("Material Costs by Type");
            chartMaterialCost.Titles[0].Font = new Font("Segoe UI", 12, FontStyle.Bold);
            chartMaterialCost.ChartAreas.Add(new ChartArea("MaterialArea"));
            chartMaterialCost.ChartAreas[0].AxisY.Title = "Cost (PKR)";
            chartMaterialCost.ChartAreas[0].AxisY.LabelStyle.Format = "#,##0";
            //chartMaterialCost.Height = 400;

            // Labor Cost Chart
            chartLaborCost.Series.Clear();
            chartLaborCost.Titles.Clear();
            chartLaborCost.Titles.Add("Labor Costs by Role");
            chartLaborCost.Titles[0].Font = new Font("Segoe UI", 12, FontStyle.Bold);
            chartLaborCost.ChartAreas.Add(new ChartArea("LaborArea"));
            chartLaborCost.ChartAreas[0].AxisY.Title = "Cost (PKR)";
            chartLaborCost.ChartAreas[0].AxisY.LabelStyle.Format = "#,##0";
            //chartLaborCost.Height = 400;
        }

        // Load projects into ComboBox
        private async Task LoadProjects()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    SqlCommand cmd = new SqlCommand("SELECT ProjectID, ProjectName FROM Projects", conn);
                    SqlDataReader reader = await cmd.ExecuteReaderAsync();
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    cmbProjects.DataSource = dt;
                    cmbProjects.DisplayMember = "ProjectName";
                    cmbProjects.ValueMember = "ProjectID";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading projects: {ex.Message}");
            }
        }

        private bool isLoading = false; // Add this at the class level
        private async Task LoadChartData()
        {
            if (isLoading || cmbProjects.SelectedValue == null) return;

            isLoading = true;
            try
            {
                string projectId = cmbProjects.SelectedValue.ToString();
                await LoadMaterialCostData(projectId);
                await LoadLaborCostData(projectId);
            }
            finally
            {
                isLoading = false;
            }
        }

        // Material Cost Logic
        private async Task LoadMaterialCostData(string projectId)
        {
            try
            {
                // Clear the series on the UI thread
                if (chartMaterialCost.InvokeRequired)
                {
                    chartMaterialCost.Invoke((MethodInvoker)(() => chartMaterialCost.Series.Clear()));
                }
                else
                {
                    chartMaterialCost.Series.Clear();
                }

                // Create the series
                Series series = new Series("MaterialSeries");
                series.ChartType = SeriesChartType.Column;
                series.IsValueShownAsLabel = true;
                series.Color = Color.SteelBlue;
                //series["PointWidth"] = "0.6"; // Reduces column width (0.6 = 60% of default width)


                // Execute the query and populate data
                string query = @"
            SELECT M.MaterialID AS MaterialName, 
                   SUM(PM.Quantity * PM.CostPerUnit) AS TotalCost
            FROM ProjectMaterials PM
            JOIN Materials M ON PM.MaterialID = M.MaterialID
            WHERE PM.ProjectID = @ProjectID
            GROUP BY M.MaterialID
            ORDER BY TotalCost DESC";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ProjectID", projectId);
                    SqlDataReader reader = await cmd.ExecuteReaderAsync();

                    while (await reader.ReadAsync())
                    {
                        string material = reader["MaterialName"].ToString();
                        decimal cost = Convert.ToDecimal(reader["TotalCost"]);
                        series.Points.AddXY(material, cost);
                    }
                }

                // Add the series on the UI thread
                if (chartMaterialCost.InvokeRequired)
                {
                    chartMaterialCost.Invoke((MethodInvoker)(() => chartMaterialCost.Series.Add(series)));
                }
                else
                {
                    chartMaterialCost.Series.Add(series);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading material costs: {ex.Message}");
            }
        }

        // Labor Cost Logic
        private async Task LoadLaborCostData(string projectId)
        {
            try
            {
                // Clear the series on the UI thread
                if (chartLaborCost.InvokeRequired)
                {
                    chartLaborCost.Invoke((MethodInvoker)(() => chartLaborCost.Series.Clear()));
                }
                else
                {
                    chartLaborCost.Series.Clear();
                }

                Series series = new Series("LaborSeries");
                series.ChartType = SeriesChartType.Column;
                series.IsValueShownAsLabel = true;
                series.Color = Color.Orange;
                //series["PointWidth"] = "0.6";

                string query = @"
            SELECT L.RoleName, SUM(PL.DaysWorked * PL.Rate) AS TotalCost
            FROM ProjectLabor PL
            JOIN Workers W ON PL.WorkerID = W.WorkerID
            JOIN Labor L ON W.RoleID = L.RoleID
            WHERE PL.ProjectID = @ProjectID
            GROUP BY L.RoleName
            ORDER BY TotalCost DESC";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ProjectID", projectId);
                    SqlDataReader reader = await cmd.ExecuteReaderAsync();

                    while (await reader.ReadAsync())
                    {
                        string role = reader["RoleName"].ToString(); // Use RoleName
                        decimal cost = Convert.ToDecimal(reader["TotalCost"]);
                        series.Points.AddXY(role, cost);
                    }
                }

                // Add the series on the UI thread
                if (chartLaborCost.InvokeRequired)
                {
                    chartLaborCost.Invoke((MethodInvoker)(() => chartLaborCost.Series.Add(series)));
                }
                else
                {
                    chartLaborCost.Series.Add(series);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading labor costs: {ex.Message}");
            }
        }

        private void InitializeSalesCharts()
        {
            // Initialize ComboBoxes
            cmbStatusFilter.Items.AddRange(new[] { "Paid", "Unpaid", "Pending" });
            cmbSectorSortOrder.Items.AddRange(new[] { "Top 5", "Bottom 5" });
            cmbStatusFilter.SelectedIndex = 0;
            cmbSectorSortOrder.SelectedIndex = 0;

            // Wire events
            btnApplySalesFilter.Click += async (s, e) => await LoadSalesChartData();
            cmbStatusFilter.SelectedIndexChanged += (s, e) => UpdateSectorChart();
            cmbSectorSortOrder.SelectedIndexChanged += (s, e) => UpdateSectorChart();
        }

        private async Task LoadSalesChartData()
        {
            DateTime startDate = dtpSalesFrom.Value.Date;
            DateTime endDate = dtpSalesTo.Value.Date.AddDays(1);

            // Load only the Sales Over Time chart
            await LoadSalesOverTimeChart(startDate, endDate);
        }

        private async Task LoadSalesOverTimeChart(DateTime fromDate, DateTime toDate)
        {
            chartSalesOverTime.Series.Clear();
            Series series = new Series("Units Sold");
            series.ChartType = SeriesChartType.Column;
            chartSalesOverTime.Series.Add(series);

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string query = @"
                SELECT 
                    YEAR(PaymentDate) AS Year,
                    MONTH(PaymentDate) AS Month,
                    COUNT(PaymentID) AS TotalPaid
                FROM Payments
                WHERE PaymentDate BETWEEN @FromDate AND @ToDate
                AND PaymentStatus = 'Paid'
                GROUP BY YEAR(PaymentDate), MONTH(PaymentDate)
                ORDER BY Year, Month";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@FromDate", fromDate);
                        cmd.Parameters.AddWithValue("@ToDate", toDate);

                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                string monthLabel = $"{new DateTime(reader.GetInt32(0), reader.GetInt32(1), 1):MMM yyyy}";
                                series.Points.AddXY(monthLabel, reader.GetInt32(2));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading sales data: {ex.Message}");
            }
        }

        private DataTable GetPivotedPaymentData()
        {
            DataTable dt = new DataTable();
            string query = @"
        SELECT 
            REPLACE(a.Area, 'Sector ', '') AS Sector,
            SUM(CASE WHEN p.PaymentStatus = 'Paid' THEN 1 ELSE 0 END) AS Paid,
            SUM(CASE WHEN p.PaymentStatus = 'Unpaid' THEN 1 ELSE 0 END) AS Unpaid,
            SUM(CASE WHEN p.PaymentStatus = 'Pending' THEN 1 ELSE 0 END) AS Pending
        FROM Customers c
        JOIN Addresses a ON c.AddressID = a.AddressID
        JOIN Payments p ON c.CustomerID = p.CustomerID
        GROUP BY REPLACE(a.Area, 'Sector ', '')";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                new SqlDataAdapter(query, conn).Fill(dt);
            }
            return dt;
        }

        private void UpdateSectorChart()
        {
            if (cmbStatusFilter.SelectedItem == null || cmbSectorSortOrder.SelectedItem == null) return;

            chartSectorComparison.Series.Clear();

            string selectedStatus = cmbStatusFilter.SelectedItem.ToString();
            bool showTop = cmbSectorSortOrder.SelectedItem.ToString() == "Top 5";

            // Sort data based on selection
            var sortedData = pivotedSectorData.AsEnumerable()
                .OrderBy(row => showTop
                    ? -Convert.ToInt32(row[selectedStatus]) // For top 5: sort descending
                    : Convert.ToInt32(row[selectedStatus])  // For bottom 5: sort ascending
                )
                .Take(5) // Take first 5 (actual top/bottom)
                .ToList();

            // Create series
            var series = chartSectorComparison.Series.Add(selectedStatus);
            series.ChartType = SeriesChartType.Column;
            series.Color = statusColors[cmbStatusFilter.SelectedIndex];
            series["PointWidth"] = "0.6";

            // Add data points
            foreach (DataRow row in sortedData)
            {
                series.Points.AddXY(row["Sector"], row[selectedStatus]);
            }

            // Formatting
            chartSectorComparison.ChartAreas[0].AxisX.LabelStyle.Angle = -45;
            chartSectorComparison.ChartAreas[0].AxisX.Interval = 1;
            chartSectorComparison.Titles.Clear();
            chartSectorComparison.Titles.Add($"{cmbSectorSortOrder.SelectedItem} Sectors by {selectedStatus}");
        }

        private async Task LoadSectorComparisonChart()
        {
            // Load Sector Comparison Data (all historical data)
            pivotedSectorData = GetPivotedPaymentData();
            UpdateSectorChart();
        }

        private async void btnApplySalesFilter_Click(object sender, EventArgs e)
        {
            DateTime startDate = dtpSalesFrom.Value.Date;
            DateTime endDate = dtpSalesTo.Value.Date.AddDays(1); // Include full day

            // Refresh ONLY the Sales Over Time chart
            await LoadSalesOverTimeChart(startDate, endDate);
        }

        private void chartMaterialCost_Click(object sender, EventArgs e)
        {

        }

        private void ExportChart(Chart chart, string defaultFileName)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "PNG Image|*.png";
            saveDialog.FileName = $"{defaultFileName}_{DateTime.Now:yyyyMMdd}";

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    chart.SaveImage(saveDialog.FileName, ChartImageFormat.Png);
                    MessageBox.Show("Chart exported successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Export failed: {ex.Message}");
                }
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
