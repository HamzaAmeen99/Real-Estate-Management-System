using RECMS.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace RECMS.Forms.MD
{
    public partial class UnitReportForm : Form
    {

        private string connectionString = DatabaseHelper.GetConnectionString();


        private DataTable pivotedData; // Class-level variable to store pivoted data


        public UnitReportForm()
        {
            InitializeComponent();
            // Initialize comboboxes
            cmbFilter.Items.AddRange(new[] { "Paid", "Unpaid", "Pending" });
            cmbSortOrder.Items.AddRange(new[] { "Top 5", "Bottom 5" });

            // Set defaults
            cmbFilter.SelectedIndex = 0;
            cmbSortOrder.SelectedIndex = 0;

            // Wire events
            cmbFilter.SelectedIndexChanged += (s, e) => UpdateChart();
            cmbSortOrder.SelectedIndexChanged += (s, e) => UpdateChart();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
            new UnitsManagementForm().Show();
        }

        private async void UnitReportForm_Load(object sender, EventArgs e)
        {

            // Enable drag
            FormDragHelper.MakeDraggable(this, panel1);
            // Load DataGridView (synchronous operations)
            pivotedData = GetPivotedPaymentData();
            dgvSectorDetails.DataSource = pivotedData;

            // Configure DataGridView UI
            dgvSectorDetails.Columns["Sector"].HeaderText = "Sector";
            dgvSectorDetails.Columns["Paid"].HeaderText = "Sold Units";
            dgvSectorDetails.Columns["Unpaid"].HeaderText = "Booked Units";
            dgvSectorDetails.Columns["Pending"].HeaderText = "Pending Units";
            dgvSectorDetails.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;

            // Configure chart appearance
            chartPayments.Series.Clear();
            Series series = new Series("Units Sold");
            series.ChartType = SeriesChartType.Column; // Column chart type
            chartPayments.Series.Add(series);
            chartPayments.ChartAreas.Add(new ChartArea());

            // Set default filter dates (last 6 months)
            dtpFrom.Value = DateTime.Now.AddMonths(-6);
            dtp2.Value = DateTime.Now; // dtpTo renamed to dtp2

            // Load initial data
            await LoadChartDataAsync(dtpFrom.Value, dtp2.Value);

            // Load charts ASYNCHRONOUSLY (non-blocking)
            await LoadChartAsync(chartProjectInterest, LoadProjectInterestChart);
            // ... more charts if needed ...


            // Optional: Update chart/table after async load
            UpdateChartAndTable();
        }

        private async Task LoadChartAsync(Chart chartControl, Action loadChartMethod)
        {
            // Show loading state
            chartControl.Invoke((MethodInvoker)delegate
            {
                chartControl.Series.Clear();
                chartControl.Titles.Add("Loading...");
            });

            // Load chart data on a background thread
            await Task.Run(() =>
            {
                loadChartMethod.Invoke();
            }).ConfigureAwait(false);

            // Refresh UI after load
            chartControl.Invoke((MethodInvoker)delegate
            {
                chartControl.Titles.Clear();
                chartControl.Refresh();
            });
        }



        private void UpdateChartAndTable()
        {
            UpdateChart();
        }

        private void LoadPaymentStatusChart()
        {

        }

        private void FormatChart()
        {

        }

        private DataTable GetPaymentData()
        {
            DataTable dt = new DataTable();
            string query = @"
        SELECT 
            REPLACE(a.Area, 'Sector ', '') AS Sector,
            p.PaymentStatus,
            COUNT(*) AS StatusCount
        FROM Customers c
        JOIN Addresses a ON c.AddressID = a.AddressID
        JOIN Payments p ON c.CustomerID = p.CustomerID
        GROUP BY REPLACE(a.Area, 'Sector ', ''), p.PaymentStatus;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.Fill(dt);
            }
            return dt;
        }


        private void CmbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateChart();
        }

        private void CmbSortOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateChart();
        }

        // Define colors
        private Color[] statusColors = new Color[]
        {
    Color.FromArgb(44, 123, 182),   // Paid (Blue)
    Color.FromArgb(215, 25, 28),     // Unpaid (Red)
    Color.FromArgb(255, 192, 0)      // Pending (Yellow)
        };

        private void UpdateChart()
        {
            if (cmbFilter.SelectedItem == null || cmbSortOrder.SelectedItem == null) return;

            // Clear previous data
            chartSectorComparison.Series.Clear();

            string selectedStatus = cmbFilter.SelectedItem.ToString();
            bool showTop = cmbSortOrder.SelectedItem.ToString() == "Top 5";

            // Sort pivoted data
            var sortedData = pivotedData.AsEnumerable()
                .OrderByDescending(row => Convert.ToInt32(row[selectedStatus]))
                .ToList();

            // Reverse for bottom 5
            if (!showTop) sortedData.Reverse();

            // Take top/bottom 5 + "Others"
            var displayData = sortedData.Take(5).ToList();
            int othersCount = sortedData.Skip(5).Sum(row => Convert.ToInt32(row[selectedStatus]));


            // Create series
            chartSectorComparison.Series.Clear();
            var series = chartSectorComparison.Series.Add(selectedStatus);
            series.ChartType = SeriesChartType.Column;
            series.Color = statusColors[cmbFilter.SelectedIndex];
            series["PointWidth"] = "0.6"; // 60% width (default is 0.8)


            // Add data points
            foreach (DataRow row in displayData)
            {
                series.Points.AddXY(row["Sector"], row[selectedStatus]);
            }

            // Add "Others" category
            if (othersCount > 0)
            {
                series.Points.AddXY("Others", othersCount);
            }

            // Formatting
            chartSectorComparison.ChartAreas[0].AxisX.LabelStyle.Angle = -45;
            chartSectorComparison.ChartAreas[0].AxisX.Interval = 1;
            chartSectorComparison.Titles.Clear();
            chartSectorComparison.Titles.Add($"{cmbSortOrder.SelectedItem} Sectors by {selectedStatus}");
            chartSectorComparison.ChartAreas[0].AxisY.IsMarginVisible = true;
            pivotedData.DefaultView.Sort = $"{selectedStatus} {(showTop ? "DESC" : "ASC")}";
            dgvSectorDetails.DataSource = pivotedData.DefaultView;
        }

        private void UpdateTable()
        {
            string selectedStatus = cmbFilter.SelectedItem.ToString();
            bool ascending = cmbSortOrder.SelectedItem.ToString() == "Bottom 5";

            // Sort the existing DataView (no need to rebind DataSource)
            pivotedData.DefaultView.Sort = $"{selectedStatus} {(ascending ? "ASC" : "DESC")}";

            // Highlight the sorted column
            HighlightFilterColumn(selectedStatus);
        }

        private void HighlightFilterColumn(string selectedStatus)
        {
            // Reset all column colors
            foreach (DataGridViewColumn col in dgvSectorDetails.Columns)
            {
                col.DefaultCellStyle.BackColor = Color.White;
            }

            // Map filter to DataGridView column name (using classic switch)
            string columnName;
            switch (selectedStatus)
            {
                case "Paid":
                    columnName = "Sold Units";
                    break;
                case "Unpaid":
                    columnName = "Booked Units";
                    break;
                case "Pending":
                    columnName = "Pending Units";
                    break;
                default:
                    columnName = "";
                    break;
            }

            // Highlight the selected column
            if (!string.IsNullOrEmpty(columnName) && dgvSectorDetails.Columns.Contains(columnName))
            {
                dgvSectorDetails.Columns[columnName].DefaultCellStyle.BackColor = Color.LightBlue;
            }
        }
        private DataTable GetPivotedPaymentData()
        {
            DataTable dt = new DataTable();
            string query = @"
        SELECT 
    CASE 
        WHEN COALESCE(TRIM(REPLACE(a.Area, 'Sector ', '')), '') = '' 
        THEN 'Random Area'
        ELSE TRIM(REPLACE(a.Area, 'Sector ', '')) 
    END AS Sector,
    SUM(CASE WHEN p.PaymentStatus = 'Paid' THEN 1 ELSE 0 END) AS Paid,
    SUM(CASE WHEN p.PaymentStatus = 'Unpaid' THEN 1 ELSE 0 END) AS Unpaid,
    SUM(CASE WHEN p.PaymentStatus = 'Pending' THEN 1 ELSE 0 END) AS Pending
FROM Customers c
JOIN Addresses a ON c.AddressID = a.AddressID
JOIN Payments p ON c.CustomerID = p.CustomerID
GROUP BY 
    CASE 
        WHEN COALESCE(TRIM(REPLACE(a.Area, 'Sector ', '')), '') = '' 
        THEN 'Random Area'
        ELSE TRIM(REPLACE(a.Area, 'Sector ', '')) 
    END";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.Fill(dt);
            }

            foreach (DataRow row in dt.Rows)
            {
                if (string.IsNullOrWhiteSpace(row["Sector"].ToString()))
                {
                    row["Sector"] = "Random Area";
                }
            }
            return dt;
        }

        private void chartProjectInterest_Click(object sender, EventArgs e)
        {

        }

        private DataTable GetProjectInterestData()
        {
            DataTable dt = new DataTable();
            string query = @"
        SELECT 
    COALESCE(NULLIF(TRIM(pi.ProjectInterest), ''), 'Random Project') AS ProjectInterest,
    SUM(CASE WHEN p.PaymentStatus = 'Paid' THEN 1 ELSE 0 END) AS Paid,
    SUM(CASE WHEN p.PaymentStatus = 'Unpaid' THEN 1 ELSE 0 END) AS Unpaid,
    SUM(CASE WHEN p.PaymentStatus = 'Pending' THEN 1 ELSE 0 END) AS Pending
FROM dbo.Customers c
JOIN dbo.Payments p ON c.CustomerID = p.CustomerID
JOIN dbo.ProjectInterests pi ON c.CustomerID = pi.CustomerID
GROUP BY COALESCE(NULLIF(TRIM(pi.ProjectInterest), ''), 'Random Project')";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.Fill(dt);
            }
            return dt;
        }

        private void LoadProjectInterestChart()
        {
            try
            {
                DataTable dt = GetProjectInterestData();
                chartProjectInterest.Series.Clear();

                // Define colors for each payment status
                Dictionary<string, Color> statusColors = new Dictionary<string, Color>
    {
        { "Paid", Color.FromArgb(44, 123, 182) },   // Blue
        { "Unpaid", Color.FromArgb(215, 25, 28) },   // Red
        { "Pending", Color.FromArgb(255, 192, 0) }   // Yellow
    };

                foreach (string status in statusColors.Keys)
                {
                    Series series = new Series
                    {
                        Name = status,
                        ChartType = SeriesChartType.StackedBar,
                        Color = statusColors[status],
                        Legend = "Legend1" // Link series to the named legend
                    };
                    chartProjectInterest.Series.Add(series);
                }

                // Populate data points
                foreach (DataRow row in dt.Rows)
                {
                    string project = row["ProjectInterest"].ToString();
                    foreach (string status in statusColors.Keys)
                    {
                        int value = Convert.ToInt32(row[status]);
                        chartProjectInterest.Series[status].Points.AddXY(project, value);
                    }
                }

                // Formatting
                chartProjectInterest.ChartAreas[0].AxisX.LabelStyle.Angle = -45;
                chartProjectInterest.ChartAreas[0].AxisX.Interval = 1;
                chartProjectInterest.Titles.Clear();
                chartProjectInterest.Titles.Add("Project Popularity by Payment Status");
                chartProjectInterest.ChartAreas[0].AxisY.Title = "Number of Clients";
                chartProjectInterest.Legends.Clear();
                chartProjectInterest.Legends.Add(new Legend { Docking = Docking.Bottom });
                //chartProjectInterest.Legends.Add(legend);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading chart: {ex.Message}");
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private async Task LoadChartDataAsync(DateTime fromDate, DateTime toDate)
        {
            chartPayments.Series["Units Sold"].Points.Clear();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string query = @"
                       SELECT 
    YEAR(PaymentDate) AS Year,
    MONTH(PaymentDate) AS Month,
    CAST(COUNT(PaymentID) AS INT) AS TotalPaidPayments
FROM dbo.Payments
WHERE 
    PaymentDate BETWEEN @FromDate AND @ToDate
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
                                int year = reader.GetInt32(0);
                                int month = reader.GetInt32(1);
                                int paidCount = reader.GetInt32(2); // Use GetInt32 for SQL COUNT (returns INT)


                                // Format date as "MMM yyyy" (e.g., "Sep 2023")
                                string monthName = new DateTime(year, month, 1).ToString("MMM yyyy");
                                chartPayments.Series["Units Sold"].Points.AddXY(monthName, paidCount);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            // Calculate first day of selected "from" month
            DateTime startDate = new DateTime(dtpFrom.Value.Year, dtpFrom.Value.Month, 1);

            // Calculate last day of selected "to" month
            DateTime endDate = new DateTime(dtp2.Value.Year, dtp2.Value.Month, 1)
                                .AddMonths(1)
                                .AddDays(-1);

            // Load data asynchronously
            await LoadChartDataAsync(startDate, endDate);
        }

        private void btnExportAll_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "PNG Image|*.png";
            saveDialog.FileName = $"AllCharts_{DateTime.Now:yyyyMMddHHmmss}.png";

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                ExportAllCharts(saveDialog.FileName);
            }
        }

        private void ExportAllCharts(string filePath)
        {
            // List of charts to export
            var charts = new List<Chart> { chartSectorComparison, chartProjectInterest, chartPayments };
            var chartImages = new List<Bitmap>();

            try
            {
                // Capture each chart's current state
                foreach (var chart in charts)
                {
                    Bitmap bmp = new Bitmap(chart.Width, chart.Height);
                    chart.DrawToBitmap(bmp, chart.ClientRectangle);
                    chartImages.Add(bmp);
                }

                // Calculate combined image size
                int totalHeight = chartImages.Sum(b => b.Height);
                int maxWidth = chartImages.Max(b => b.Width);

                // Create combined image
                using (Bitmap combinedBmp = new Bitmap(maxWidth, totalHeight))
                using (Graphics g = Graphics.FromImage(combinedBmp))
                {
                    g.Clear(Color.White);
                    int y = 0;
                    foreach (var img in chartImages)
                    {
                        g.DrawImage(img, 0, y);
                        y += img.Height;
                    }
                    combinedBmp.Save(filePath, ImageFormat.Png);
                }

                MessageBox.Show("All charts exported!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
            finally
            {
                // Cleanup
                foreach (var img in chartImages)
                    img.Dispose();
            }
        }
    }
}
