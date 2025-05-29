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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace RECMS.Forms.MD
{
    public partial class ReportMain : Form
    {
        private string connectionString = DatabaseHelper.GetConnectionString();
        public ReportMain()
        {
            InitializeComponent();
            InitializeCharts();

            btnExportProject.Click += (s, e) => ExportProjectCharts();
            btnExportUnits.Click += (s, e) => ExportUnitsChart();

            this.Load += async (sender, e) => await LoadProjects();
            cmbProjects.SelectedIndexChanged += async (sender, e) => await LoadChartData();
            this.Load += (sender, e) => LoadUnitsOverTimeChart();

            // New: Date filter setup
            dtpDateFrom.Value = DateTime.Now.AddMonths(-1); // Default: last 30 days
            dtpDateTo.Value = DateTime.Now;

            // Auto-refresh when dates change
            dtpDateFrom.ValueChanged += (s, e) => LoadUnitsOverTimeChart();
            dtpDateTo.ValueChanged += (s, e) => LoadUnitsOverTimeChart();

            // Initialize Units Over Time Chart
            chartUnitsOverTime.Series.Clear();
            chartUnitsOverTime.Titles.Clear();
            chartUnitsOverTime.Titles.Add("Units Sold Over Time");
            chartUnitsOverTime.ChartAreas.Add(new ChartArea("TimeArea"));
            chartUnitsOverTime.ChartAreas["TimeArea"].AxisX.LabelStyle.Angle = -45;
            chartUnitsOverTime.ChartAreas["TimeArea"].AxisX.Interval = 1;

        }

        // Initialize chart settings
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

        private void buttonClose_Click(object sender, EventArgs e)
        {
            // Check if MD_homeForm is already open
            bool isMDHomeOpen = false;
            foreach (Form form in Application.OpenForms)
            {
                if (form is MD_homeForm)
                {
                    form.Show(); // Bring MD_homeForm to the front
                    form.WindowState = FormWindowState.Normal; // Restore if minimized
                    isMDHomeOpen = true;
                    break;
                }
            }

            // If MD_homeForm wasn't found, create a new instance
            if (!isMDHomeOpen)
            {
                MD_homeForm homeForm = new MD_homeForm();
                homeForm.Show();
            }

            // Close the current ReportMain form
            this.Close();
        }

        private async void LoadUnitsOverTimeChart()
        {
            try
            {
                chartUnitsOverTime.Series.Clear();
                chartUnitsOverTime.Titles.Clear();

                DateTime startDate = dtpDateFrom.Value.Date;
                DateTime endDate = dtpDateTo.Value.Date.AddDays(1);

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync(); // Use async open
                    string query = @"
                SELECT 
                    CAST(PaymentDate AS DATE) AS SaleDate,
                    COUNT(PaymentID) AS UnitsSold
                FROM Payments
                WHERE PaymentDate BETWEEN @StartDate AND @EndDate
                    AND PaymentStatus = 'Paid'
                GROUP BY CAST(PaymentDate AS DATE)
                ORDER BY SaleDate";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@StartDate", startDate);
                    cmd.Parameters.AddWithValue("@EndDate", endDate);

                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        if (!reader.HasRows)
                        {
                            MessageBox.Show("No sales data found for the selected dates.");
                            return;
                        }

                        Series series = new Series("UnitsSold")
                        {
                            ChartType = SeriesChartType.Column,
                            Color = Color.SteelBlue,
                            IsValueShownAsLabel = true
                        };

                        while (await reader.ReadAsync())
                        {
                            DateTime date = reader.GetDateTime(0);
                            int units = reader.GetInt32(1);
                            series.Points.AddXY(date.ToString("dd-MMM"), units);
                        }

                        // Update chart on UI thread
                        if (chartUnitsOverTime.InvokeRequired)
                        {
                            chartUnitsOverTime.Invoke((MethodInvoker)delegate
                            {
                                chartUnitsOverTime.Series.Add(series);
                                chartUnitsOverTime.Titles.Add($"Units Sold ({startDate:dd-MMM} to {endDate.AddDays(-1):dd-MMM})");
                            });
                        }
                        else
                        {
                            chartUnitsOverTime.Series.Add(series);
                            chartUnitsOverTime.Titles.Add($"Units Sold ({startDate:dd-MMM} to {endDate.AddDays(-1):dd-MMM})");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading chart: {ex.Message}");
            }
        }

        private void ExportProjectCharts()
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "PNG Image|*.png";
            saveDialog.FileName = $"ProjectCharts_{DateTime.Now:yyyyMMddHHmmss}.png";

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Combine Material & Labor charts
                    CombineAndExportCharts(
                        new List<Chart> { chartMaterialCost, chartLaborCost },
                        saveDialog.FileName
                    );
                    MessageBox.Show("Project charts exported!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Export failed: {ex.Message}");
                }
            }
        }

        private void ExportUnitsChart()
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "PNG Image|*.png";
            saveDialog.FileName = $"UnitsChart_{DateTime.Now:yyyyMMddHHmmss}.png";

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Export single chart
                    CombineAndExportCharts(
                        new List<Chart> { chartUnitsOverTime },
                        saveDialog.FileName
                    );
                    MessageBox.Show("Units chart exported!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Export failed: {ex.Message}");
                }
            }
        }

        private void CombineAndExportCharts(List<Chart> charts, string filePath)
        {
            List<Bitmap> chartImages = new List<Bitmap>();

            try
            {
                // Capture chart images
                foreach (var chart in charts)
                {
                    Bitmap bmp = new Bitmap(chart.Width, chart.Height);
                    chart.DrawToBitmap(bmp, chart.ClientRectangle);
                    chartImages.Add(bmp);
                }

                // Calculate combined dimensions
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
                    combinedBmp.Save(filePath, System.Drawing.Imaging.ImageFormat.Png);
                }
            }
            finally
            {
                // Cleanup resources
                foreach (var img in chartImages)
                    img.Dispose();
            }
        }
    }
}
