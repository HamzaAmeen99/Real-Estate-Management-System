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

namespace RECMS.Forms.MD
{
    public partial class ProjectReportForm : Form
    {
        private string connectionString = DatabaseHelper.GetConnectionString();
        public ProjectReportForm()
        {
            InitializeComponent();

            // In the ProjectReportForm constructor:
            btnExportMaterial.Click += (s, e) => ExportTabCharts("Material");
            btnExportLabor.Click += (s, e) => ExportTabCharts("Labor");

            // Initialize UI
            InitializeCharts();

            // Load data
            this.Load += async (sender, e) => {
                await ValidateNumericData();
                await LoadProjects();
                if (cmbProjects.Items.Count > 0)
                {
                    cmbProjects.SelectedIndex = 0;
                    await LoadChartData();
                }
            };

            // Refresh charts when project changes
            cmbProjects.SelectedIndexChanged += async (sender, e) => {
                await LoadChartData();
            };
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

        private void btnGenerate_Click(object sender, EventArgs e)
        {

        }

        private void InitializeCharts()
        {
            // Material Cost Chart (Tab 1)
            InitializeMaterialChart();
            InitializeMaterialCostChart();

            // Labor Cost Charts (Tab 2)
            InitializeLaborSupplierChart();
            InitializeLaborRolesChart();
        }

        private void InitializeMaterialChart()
        {
            chartMaterial.Series.Clear();
            chartMaterial.Titles.Clear();
            chartMaterial.Legends.Clear();
            chartMaterial.ChartAreas.Clear();

            // Configure chart area
            ChartArea area = new ChartArea("MaterialArea");
            area.AxisX.LabelStyle.Font = new Font("Segoe UI", 9);
            area.AxisY.LabelStyle.Font = new Font("Segoe UI", 9);
            area.AxisY.Title = "Cost (Pkr)";
            area.AxisY.LabelStyle.Format = "#,##0";
            chartMaterial.ChartAreas.Add(area);

            // Add title
            chartMaterial.Titles.Add("Material Costs by Supplier");
            chartMaterial.Titles[0].Font = new Font("Segoe UI", 12, FontStyle.Bold);

            // Add legend
            Legend legend = new Legend();
            legend.Docking = Docking.Right;
            chartMaterial.Legends.Add(legend);
        }

        private void InitializeMaterialCostChart()
        {
            chartMaterialCost.Series.Clear();
            chartMaterialCost.Titles.Clear();
            chartMaterialCost.Legends.Clear();
            chartMaterialCost.ChartAreas.Clear();

            // Configure chart area
            ChartArea area = new ChartArea("MaterialCostArea");
            area.AxisX.LabelStyle.Font = new Font("Segoe UI", 9);
            area.AxisY.LabelStyle.Font = new Font("Segoe UI", 9);
            area.AxisY.Title = "Cost (Pkr)";
            area.AxisY.LabelStyle.Format = "#,##0";
            chartMaterialCost.ChartAreas.Add(area);

            // Add title
            chartMaterialCost.Titles.Add("Material Costs by Type");
            chartMaterialCost.Titles[0].Font = new Font("Segoe UI", 12, FontStyle.Bold);
        }

        private void InitializeLaborSupplierChart()
        {
            chartLaborSupplier.Series.Clear();
            chartLaborSupplier.Titles.Clear();
            chartLaborSupplier.Legends.Clear();
            chartLaborSupplier.ChartAreas.Clear();

            // Configure chart area
            ChartArea area = new ChartArea("LaborSupplierArea");
            area.AxisX.LabelStyle.Font = new Font("Segoe UI", 9);
            area.AxisY.LabelStyle.Font = new Font("Segoe UI", 9);
            area.AxisY.Title = "Cost (Pkr)";
            area.AxisY.LabelStyle.Format = "#,##0";
            chartLaborSupplier.ChartAreas.Add(area);

            // Add title
            chartLaborSupplier.Titles.Add("Labor Costs by Contractor");
            chartLaborSupplier.Titles[0].Font = new Font("Segoe UI", 12, FontStyle.Bold);

            // Add legend
            Legend legend = new Legend();
            legend.Docking = Docking.Right;
            chartLaborSupplier.Legends.Add(legend);
        }

        private void InitializeLaborRolesChart()
        {
            chartLaborRoles.Series.Clear();
            chartLaborRoles.Titles.Clear();
            chartLaborRoles.Legends.Clear();
            chartLaborRoles.ChartAreas.Clear();

            // Configure chart area
            ChartArea area = new ChartArea("LaborRolesArea");
            area.AxisX.LabelStyle.Font = new Font("Segoe UI", 9);
            area.AxisY.LabelStyle.Font = new Font("Segoe UI", 9);
            area.AxisY.Title = "Cost (Pkr)";
            area.AxisY.LabelStyle.Format = "#,##0";
            chartLaborRoles.ChartAreas.Add(area);

            // Add title
            chartLaborRoles.Titles.Add("Labor Costs by Role (Stacked)");
            chartLaborRoles.Titles[0].Font = new Font("Segoe UI", 12, FontStyle.Bold);

            // Add legend
            Legend legend = new Legend();
            legend.Docking = Docking.Right;
            chartLaborRoles.Legends.Add(legend);
        }

        private async Task LoadProjects()
        {
            try
            {
                string query = "SELECT ProjectID, ProjectName FROM Projects ORDER BY ProjectName";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

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

        private bool isChartLoading = false;
        private async Task LoadChartData()
        {
            if (isChartLoading || cmbProjects.SelectedValue == null) return;

            isChartLoading = true;
            try
            {
                string projectId = cmbProjects.SelectedValue.ToString();
                await LoadMaterialData(projectId);
                await LoadMaterialCostData(projectId);
                await LoadLaborSupplierData(projectId);
                await LoadLaborRolesData(projectId);
            }
            finally
            {
                isChartLoading = false;
            }
        }

        private async Task LoadMaterialData(string projectId)
        {
            try
            {
                if (chartMaterial.InvokeRequired)
                {
                    chartMaterial.Invoke((MethodInvoker)(() => chartMaterial.Series.Clear()));
                }
                else
                {
                    chartMaterial.Series.Clear();
                }
                // CORRECTED: Use SupplierID directly as the supplier name
                string query = @"SELECT S.SupplierID AS SupplierName, 
                               SUM(PM.Quantity * PM.CostPerUnit) AS TotalCost
                        FROM ProjectMaterials PM
                        JOIN Suppliers S ON PM.SupplierID = S.SupplierID
                        WHERE PM.ProjectID = @ProjectID
                        GROUP BY S.SupplierID
                        ORDER BY TotalCost DESC";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ProjectID", projectId);

                    SqlDataReader reader = await cmd.ExecuteReaderAsync();

                    Series series = new Series("Materials");
                    series.ChartType = SeriesChartType.Column;
                    series.IsValueShownAsLabel = true;
                    series.LabelFormat = "#,##0";
                    series.Color = Color.SteelBlue;

                    if (chartMaterial.InvokeRequired)
                    {
                        chartMaterial.Invoke((MethodInvoker)(() => chartMaterial.Series.Add(series)));
                    }
                    else
                    {
                        chartMaterial.Series.Add(series);
                    }

                    while (await reader.ReadAsync())
                    {
                        string supplier = reader["SupplierName"].ToString();
                        decimal cost = reader["TotalCost"] != DBNull.Value
                            ? Convert.ToDecimal(reader["TotalCost"])
                            : 0m;

                        series.Points.AddXY(supplier, cost);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading material data: {ex.Message}");
            }
        }

        private async Task LoadMaterialCostData(string projectId)
        {
            try
            {
                chartMaterialCost.Series.Clear();

                string query = @"SELECT M.MaterialID AS MaterialName, 
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

                    Series series = new Series("MaterialCosts");
                    series.ChartType = SeriesChartType.Column;
                    series.Color = Color.SteelBlue;
                    series.IsValueShownAsLabel = true;
                    series.LabelFormat = "#,##0";

                    while (await reader.ReadAsync())
                    {
                        string material = reader["MaterialName"].ToString();
                        decimal cost = Convert.ToDecimal(reader["TotalCost"]);
                        series.Points.AddXY(material, cost);
                    }

                    chartMaterialCost.Series.Add(series);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading material cost data: {ex.Message}");
            }
        }

        private async Task LoadLaborSupplierData(string projectId)
        {
            try
            {
                chartLaborSupplier.Series.Clear();

                string query = @"SELECT C.ContractorName AS SupplierName, 
                                SUM(PL.DaysWorked * PL.Rate) AS TotalCost
                         FROM ProjectLabor PL
                         JOIN Workers W ON PL.WorkerID = W.WorkerID
                         JOIN Contractors C ON W.ContractorID = C.ContractorID
                         WHERE PL.ProjectID = @ProjectID
                         GROUP BY C.ContractorName
                         ORDER BY TotalCost DESC";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ProjectID", projectId);

                    SqlDataReader reader = await cmd.ExecuteReaderAsync();

                    Series series = new Series("LaborSuppliers");
                    series.ChartType = SeriesChartType.Bar;
                    series.IsValueShownAsLabel = true;
                    series.LabelFormat = "#,##0";
                    series.Color = Color.Orange;

                    while (await reader.ReadAsync())
                    {
                        string supplier = reader["SupplierName"].ToString();
                        decimal cost = reader["TotalCost"] != DBNull.Value
                            ? Convert.ToDecimal(reader["TotalCost"])
                            : 0m;

                        series.Points.AddXY(supplier, cost);
                    }

                    chartLaborSupplier.Series.Add(series);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading labor supplier data: {ex.Message}");
            }
        }

        private async Task LoadLaborRolesData(string projectId)
        {
            try
            {
                chartLaborRoles.Series.Clear();

                string query = @"SELECT L.RoleName, SUM(PL.DaysWorked * PL.Rate) AS TotalCost
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

                    Series series = new Series("LaborRoles");
                    series.ChartType = SeriesChartType.StackedColumn;
                    series.IsValueShownAsLabel = true;
                    series.LabelFormat = "#,##0";
                    series["PointWidth"] = "0.8"; // Adjust bar thickness

                    // Assign colors based on role
                    while (await reader.ReadAsync())
                    {
                        string role = reader["RoleName"].ToString();
                        decimal cost = reader["TotalCost"] != DBNull.Value
                            ? Convert.ToDecimal(reader["TotalCost"])
                            : 0m;

                        DataPoint point = new DataPoint();
                        point.SetValueY(cost);
                        point.Color = GenerateRoleColor(role);
                        point.AxisLabel = role;
                        point.LegendText = role;
                        series.Points.Add(point);
                    }

                    chartLaborRoles.Series.Add(series);

                    // Add space between columns
                    chartLaborRoles.ChartAreas[0].AxisX.IsMarginVisible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading labor roles data: {ex.Message}");
            }
        }

        private Color GenerateRoleColor(string roleName)
        {
            // Predefined color palette
            Color[] colors = {
        Color.FromArgb(31, 119, 180),  // Blue
        Color.FromArgb(255, 127, 14),   // Orange
        Color.FromArgb(44, 160, 44),    // Green
        Color.FromArgb(214, 39, 40),    // Red
        Color.FromArgb(148, 103, 189),  // Purple
        Color.FromArgb(140, 86, 75),    // Brown
        Color.FromArgb(227, 119, 194),  // Pink
        Color.FromArgb(127, 127, 127)   // Gray
            };

            int index = Math.Abs(roleName.GetHashCode()) % colors.Length;
            return colors[index];
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

        private void tabLabor_Click(object sender, EventArgs e)
        {

        }

        private void ProjectReportForm_Load(object sender, EventArgs e)
        {

        }

        private void ExportTabCharts(string tabName)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "PNG Image|*.png";
            saveDialog.FileName = $"{tabName}Charts_{DateTime.Now:yyyyMMddHHmmss}.png";

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    List<Chart> charts = new List<Chart>();

                    // Select charts based on tab
                    switch (tabName)
                    {
                        case "Material":
                            charts.Add(chartMaterial);
                            charts.Add(chartMaterialCost);
                            break;
                        case "Labor":
                            charts.Add(chartLaborSupplier);
                            charts.Add(chartLaborRoles);
                            break;
                    }

                    // Capture chart images
                    var chartImages = new List<Bitmap>();
                    foreach (var chart in charts)
                    {
                        Bitmap bmp = new Bitmap(chart.Width, chart.Height);
                        chart.DrawToBitmap(bmp, chart.ClientRectangle);
                        chartImages.Add(bmp);
                    }

                    // Combine images vertically
                    int totalHeight = chartImages.Sum(b => b.Height);
                    int maxWidth = chartImages.Max(b => b.Width);

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
                        combinedBmp.Save(saveDialog.FileName, System.Drawing.Imaging.ImageFormat.Png);
                    }

                    MessageBox.Show($"{tabName} charts exported!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Export failed: {ex.Message}");
                }
            }
        }
    }
}

