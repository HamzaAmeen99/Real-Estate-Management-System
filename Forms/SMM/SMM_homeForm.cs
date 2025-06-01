using RECMS.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static RECMS.Forms.ProjectDetailsForm;

namespace RECMS.Forms.SMM
{
    public partial class SMM_homeForm : Form
    {
        private string connectionString = DatabaseHelper.GetConnectionString();
        private DataView imagesDataView;
        private int currentImageIndex = 0;
        public SMM_homeForm()
        {
            InitializeComponent();

            // Initialize ComboBoxes
            cmbSectorFilter.Items.AddRange(new[] { "Top 5", "Bottom 5" });
            cmbStatusFilter.Items.AddRange(new[] { "Paid", "Unpaid", "Pending" });
            cmbSectorFilter.SelectedIndex = 0;
            cmbStatusFilter.SelectedIndex = 0;

            // Auto-refresh when filters change
            cmbSectorFilter.SelectedIndexChanged += (s, e) => LoadSectorSalesChart();
            cmbStatusFilter.SelectedIndexChanged += (s, e) => LoadSectorSalesChart();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            // Show confirmation dialog
            DialogResult result = MessageBox.Show(
                "Are you sure you want to exit the application?",
                "Exit Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                // Close the entire application
                Application.Exit();
            }
            else
            {
                // Navigate back to LoginForm
                LoginForm loginForm = new LoginForm();
                loginForm.Show();     // Show the login form
                this.Hide();          // Hide the current form (optional)

                // OR: this.Close();   // Close the current form (if you want to destroy it)
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            new LoginForm().Show();
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dgvUnits_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void lstAssets_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        // Add this phase list
        private List<ProjectPhase> projectPhases = new List<ProjectPhase>
{
    new ProjectPhase { Name = "Site Preparation", Weight = 5m },
    new ProjectPhase { Name = "Excavation", Weight = 5m },
    new ProjectPhase { Name = "Footings & Foundation", Weight = 10m },
    new ProjectPhase { Name = "Structural Framework (25%)", Weight = 10m },
    new ProjectPhase { Name = "Structural Framework (50%)", Weight = 10m },
    new ProjectPhase { Name = "Structural Framework (100%)", Weight = 10m },
    new ProjectPhase { Name = "Exterior Walls", Weight = 5m },
    new ProjectPhase { Name = "Roofing", Weight = 5m },
    new ProjectPhase { Name = "Electrical Wiring", Weight = 5m },
    new ProjectPhase { Name = "Plumbing", Weight = 5m },
    new ProjectPhase { Name = "HVAC Installation", Weight = 5m },
    new ProjectPhase { Name = "Insulation", Weight = 5m },
    new ProjectPhase { Name = "Drywall Installation", Weight = 5m },
    new ProjectPhase { Name = "Flooring", Weight = 5m },
    new ProjectPhase { Name = "Painting", Weight = 5m },
    new ProjectPhase { Name = "Final Fixtures", Weight = 5m }
};

        private async void SMM_homeForm_Load(object sender, EventArgs e)
        {

            // Enable drag
            FormDragHelper.MakeDraggable(this, textBox6);

            await LoadProjectsAsync();
            if (cmbProjects.Items.Count > 0)
            {
                cmbProjects.SelectedIndex = 0;
                await UpdateProgressAndExpenses(cmbProjects.SelectedValue.ToString());
            }
            await LoadAvailableUnitsDataAsync();
            await UpdateAvailableUnitsAsync();
            await LoadSoldUnitsDataAsync(); // Load all sold units initially
            LoadSectorSalesChart();
        }

        private async void btnFilterSold_Click(object sender, EventArgs e)
        {
            await LoadSoldUnitsDataAsync(
                dtpSoldFrom.Value.Date,
                dtpSoldTo.Value.Date.AddDays(1) // Include full end day
            );
        }

        // Load projects into ComboBox
        private async Task LoadProjectsAsync()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    DataTable dt = new DataTable();
                    new SqlDataAdapter("SELECT ProjectID, ProjectName FROM Projects", conn).Fill(dt);

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

        // Get progress percentage
        private async Task<decimal> GetProjectProgress(string projectId)
        {
            decimal totalWeight = 0;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                await conn.OpenAsync();
                SqlCommand cmd = new SqlCommand(
                    "SELECT PhaseName FROM ProjectProgress WHERE ProjectID=@ProjectID AND IsCompleted=1",
                    conn
                );
                cmd.Parameters.AddWithValue("@ProjectID", projectId);

                using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var phase = projectPhases.FirstOrDefault(p => p.Name == reader["PhaseName"].ToString());
                        if (phase != null) totalWeight += phase.Weight;
                    }
                }
            }
            return totalWeight;
        }

        // Get total expenses (material + labor)
        private async Task<decimal> GetTotalExpenses(string projectId)
        {
            decimal material = 0, labor = 0;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                await conn.OpenAsync();

                // Material cost
                SqlCommand cmdMaterial = new SqlCommand(
                    "SELECT COALESCE(SUM(Quantity * CostPerUnit), 0) FROM ProjectMaterials WHERE ProjectID=@ProjectID",
                    conn
                );
                cmdMaterial.Parameters.AddWithValue("@ProjectID", projectId);
                material = Convert.ToDecimal(await cmdMaterial.ExecuteScalarAsync());

                // Labor cost
                SqlCommand cmdLabor = new SqlCommand(
                    "SELECT COALESCE(SUM(DaysWorked * Rate), 0) FROM ProjectLabor WHERE ProjectID=@ProjectID",
                    conn
                );
                cmdLabor.Parameters.AddWithValue("@ProjectID", projectId);
                labor = Convert.ToDecimal(await cmdLabor.ExecuteScalarAsync());
            }
            return material + labor;
        }

        // Update UI with latest data
        private async Task UpdateProgressAndExpenses(string projectId)
        {
            try
            {
                decimal progress = await GetProjectProgress(projectId);
                decimal totalExpenses = await GetTotalExpenses(projectId);

                // Update UI thread-safely
                this.Invoke((MethodInvoker)delegate
                {
                    progressBar.Value = (int)progress;
                    lblProgress.Text = $"{progress}%";
                    lblBudget.Text = $"Pkr {totalExpenses:N0}";
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating data: {ex.Message}");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private async void cmbProjects_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cmbProjects.SelectedValue == null) return;
            // Update progress and expenses
            await UpdateProgressAndExpenses(cmbProjects.SelectedValue.ToString());

            // Load images for the selected project
            currentImageIndex = 0;
            await LoadProjectImages(cmbProjects.SelectedValue.ToString());
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            if (cmbProjects.SelectedValue != null)
                await UpdateProgressAndExpenses(cmbProjects.SelectedValue.ToString());
        }

        private void btnMilestones_Click(object sender, EventArgs e)
        {

        }

        private async Task LoadProjectImages(string projectId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                await conn.OpenAsync();
                string query = "SELECT ImagePath, Description FROM ProjectImages WHERE ProjectID = @ProjectID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ProjectID", projectId);

                DataTable dt = new DataTable();
                dt.Load(await cmd.ExecuteReaderAsync());
                imagesDataView = new DataView(dt);

                UpdateImageDisplay();
            }
        }

        private void UpdateImageDisplay()
        {
            try
            {
                if (imagesDataView?.Count > 0 && currentImageIndex < imagesDataView.Count)
                {
                    string imagePath = imagesDataView[currentImageIndex]["ImagePath"].ToString();

                    // Clear previous image
                    if (picProjectImage.Image != null)
                    {
                        picProjectImage.Image.Dispose();
                        picProjectImage.Image = null;
                    }

                    if (File.Exists(imagePath))
                    {
                        // Load image
                        using (FileStream fs = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                        using (MemoryStream ms = new MemoryStream())
                        {
                            fs.CopyTo(ms);
                            picProjectImage.Image = Image.FromStream(ms);
                        }

                        lblImageDescription.Text = imagesDataView[currentImageIndex]["Description"].ToString();
                        lblImageCounter.Text = $"{currentImageIndex + 1}/{imagesDataView.Count}";
                    }
                }
                else
                {
                    picProjectImage.Image = null;
                    lblImageDescription.Text = "";
                    lblImageCounter.Text = "0/0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading image: {ex.Message}");
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (imagesDataView?.Count > 0)
            {
                currentImageIndex = (currentImageIndex + 1) % imagesDataView.Count;
                UpdateImageDisplay();
            }
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (imagesDataView?.Count > 0)
            {
                currentImageIndex = (currentImageIndex - 1 + imagesDataView.Count) % imagesDataView.Count;
                UpdateImageDisplay();
            }
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            if (imagesDataView?.Count == 0 || currentImageIndex >= imagesDataView.Count)
            {
                MessageBox.Show("No image to download!");
                return;
            }

            try
            {
                // Get the current image path
                string imagePath = imagesDataView[currentImageIndex]["ImagePath"].ToString();

                // Let the user choose where to save the image
                using (SaveFileDialog saveDialog = new SaveFileDialog())
                {
                    saveDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif";
                    saveDialog.FileName = Path.GetFileName(imagePath);

                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        // Copy the image to the selected location
                        File.Copy(imagePath, saveDialog.FileName, overwrite: true);
                        MessageBox.Show("Image downloaded successfully!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error downloading image: {ex.Message}");
            }

        }

        private void btnExportAssets_Click(object sender, EventArgs e)
        {

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
                    dgvAvailableUnits.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading units: {ex.Message}");
            }
        }

        private async Task UpdateAvailableUnitsAsync()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string query = "SELECT COUNT(*) FROM Units";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    int count = Convert.ToInt32(await cmd.ExecuteScalarAsync());

                    // Update label
                    if (lblAvailableUnitsCount.InvokeRequired)
                    {
                        lblAvailableUnitsCount.Invoke((MethodInvoker)delegate {
                            lblAvailableUnitsCount.Text = count.ToString();
                        });
                    }
                    else
                    {
                        lblAvailableUnitsCount.Text = count.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating units: {ex.Message}");
            }
        }

        private async Task LoadSoldUnitsDataAsync(
    DateTime? startDate = null,
    DateTime? endDate = null,
    string searchName = "",
    string searchContact = "")
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
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}");
            }
        }

        private async void btnFilterSold_Click_1(object sender, EventArgs e)
        {
            await LoadSoldUnitsDataAsync(
        startDate: dtpSoldFrom.Value.Date,
        endDate: dtpSoldTo.Value.Date.AddDays(1) // Include full end day
             );
        }

        private DataTable GetSectorSalesData()
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
        LEFT JOIN Payments p ON c.CustomerID = p.CustomerID
        GROUP BY REPLACE(a.Area, 'Sector ', '')";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                new SqlDataAdapter(query, conn).Fill(dt);
            }
            return dt;
        }

        private void LoadSectorSalesChart()
        {
            try
            {
                chartSalesBySector.Series.Clear();
                chartSalesBySector.Titles.Clear();

                // Get current filter values
                string status = cmbStatusFilter.SelectedItem?.ToString() ?? "Paid"; // Default to "Paid"
                bool showTop = cmbSectorFilter.SelectedItem?.ToString() == "Top 5";

                // Get data
                DataTable dt = GetSectorSalesData();

                // Sort data based on selected status
                var sortedData = dt.AsEnumerable()
                    .OrderBy(row => showTop
                        ? -Convert.ToInt32(row[status])
                        : Convert.ToInt32(row[status]))
                    .Take(5)
                    .ToList();

                // Configure chart
                Series series = new Series(status)
                {
                    ChartType = SeriesChartType.Column,
                    IsValueShownAsLabel = true,
                    Color = GetStatusColor(status)
                };

                foreach (DataRow row in sortedData)
                {
                    series.Points.AddXY(row["Sector"], row[status]);
                }

                chartSalesBySector.Series.Add(series);
                chartSalesBySector.Titles.Add($"Units Sold by Sector ({status})");
                chartSalesBySector.ChartAreas[0].AxisX.LabelStyle.Angle = -45;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading chart: {ex.Message}");
            }
        }

        // Status color mapping (unchanged)
        private Color GetStatusColor(string status)
        {
            switch (status)
            {
                case "Paid": return Color.FromArgb(44, 123, 182);
                case "Unpaid": return Color.FromArgb(215, 25, 28);
                case "Pending": return Color.FromArgb(255, 192, 0);
                default: return Color.SteelBlue;
            }
        }


    }
}
