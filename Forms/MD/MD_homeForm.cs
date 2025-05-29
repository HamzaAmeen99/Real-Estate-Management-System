using RECMS.Forms.MD;
using RECMS.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static RECMS.Forms.ProjectDetailsForm;

namespace RECMS.Forms
{
    public partial class MD_homeForm : Form
    {
        private string connectionString = DatabaseHelper.GetConnectionString();
        private bool _dragging = false;
        private Point _dragCursorPoint;
        private Point _dragFormPoint;
        public MD_homeForm()
        {
            InitializeComponent();
            panel1.MouseDown += Panel_MouseDown;
            panel1.MouseMove += Panel_MouseMove;
            panel1.MouseUp += Panel_MouseUp;

            // Attach events to each panel
            panel2.MouseEnter += Panel_MouseEnter;
            panel2.MouseLeave += Panel_MouseLeave;

            panel3.MouseEnter += Panel_MouseEnter;
            panel3.MouseLeave += Panel_MouseLeave;

            panel4.MouseEnter += Panel_MouseEnter;
            panel4.MouseLeave += Panel_MouseLeave;

            // Also attach to child controls inside each panel
            AttachHoverEventsToChildren(panel2);
            AttachHoverEventsToChildren(panel3);
            AttachHoverEventsToChildren(panel4);
        }
        private void Panel_MouseEnter(object sender, EventArgs e)
        {
            if (sender is Panel panel)
            {
                panel.BackColor = Color.DarkGray;
            }
        }

        private void Panel_MouseLeave(object sender, EventArgs e)
        {
            if (sender is Panel panel)
            {
                panel.BackColor = Color.Gainsboro;
            }
        }
        private void AttachHoverEventsToChildren(Panel panel)
        {
            foreach (Control ctrl in panel.Controls)
            {
                ctrl.MouseEnter += (s, e) => Panel_MouseEnter(panel, e);
                ctrl.MouseLeave += (s, e) => Panel_MouseLeave(panel, e);
            }
        }
        private void Panel_MouseDown(object sender, MouseEventArgs e)
        {
            _dragging = true;
            _dragCursorPoint = Cursor.Position;
            _dragFormPoint = this.Location;
        }

        private void Panel_MouseMove(object sender, MouseEventArgs e)
        {
            if (_dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(_dragCursorPoint));
                this.Location = Point.Add(_dragFormPoint, new Size(dif));
            }
        }

        private void Panel_MouseUp(object sender, MouseEventArgs e)
        {
            _dragging = false;
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

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblTotalExpenses_Click(object sender, EventArgs e)
        {

        }

        private void labelproj_Click(object sender, EventArgs e)
        {
            var detailsForm = new ProjectDetailsForm();
            detailsForm.DataUpdated += async () =>
            {
                if (cmbProjectsHome.SelectedValue != null)
                    await UpdateProgressAndExpenses(cmbProjectsHome.SelectedValue.ToString());
            };
            // Hide MD_homeForm (instead of closing it)
            this.Hide();

            // Show ProjectDetailsForm
            detailsForm.Show();

            // When ProjectDetailsForm closes, re-show MD_homeForm
            detailsForm.FormClosed += (s, args) => this.Show();

        }

        private void labelunit_Click(object sender, EventArgs e)
        {
            // Open UnitsManagementForm
            var unitsForm = new UnitsManagementForm();
            unitsForm.Show();

            // Hide the current MD_homeForm (instead of closing)
            this.Hide();
        }

        private void labelrep_Click(object sender, EventArgs e)
        {
            // Open ReportMain form
            var reportForm = new ReportMain();
            reportForm.Show();

            // Close the current form
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new ProjectReportForm().Show(); // Open without closing current form
        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            new LoginForm().Show();
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private async void MD_homeForm_Load(object sender, EventArgs e)
        {
            

            await LoadProjectsAsync();

            // Load data for the first project immediately
            if (cmbProjectsHome.Items.Count > 0)
            {
                cmbProjectsHome.SelectedIndex = 0;
                // Force an update
                await UpdateProgressAndExpenses(cmbProjectsHome.SelectedValue.ToString());
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void gbStats_Enter(object sender, EventArgs e)
        {

        }

        private void panelright_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelmid_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelLeft_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        // Add this phase list to MD_homeForm.cs (same as ProjectDetailsForm)
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

        private async Task<decimal> GetProjectProgress(string projectId)
        {
            decimal totalWeight = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                string query = "SELECT PhaseName FROM ProjectProgress WHERE ProjectID = @ProjectID AND IsCompleted = 1";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@ProjectID", projectId);
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            string phaseName = reader["PhaseName"].ToString();
                            var phase = projectPhases.FirstOrDefault(p => p.Name == phaseName);
                            if (phase != null)
                                totalWeight += phase.Weight;
                        }
                    }
                }
            }
            return totalWeight;
        }
        private async Task LoadProjectsAsync()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();
                    string query = "SELECT ProjectID, ProjectName FROM Projects";

                    // Load data properly
                    SqlDataAdapter da = new SqlDataAdapter(query, connection);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Clear existing items first
                    cmbProjectsHome.BeginUpdate();
                    cmbProjectsHome.DataSource = null;
                    cmbProjectsHome.Items.Clear();

                    // Rebind data
                    cmbProjectsHome.DataSource = dt;
                    cmbProjectsHome.DisplayMember = "ProjectName";
                    cmbProjectsHome.ValueMember = "ProjectID";
                    cmbProjectsHome.EndUpdate();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading projects: {ex.Message}");
            }
        }

        // Update progress/expenses when project is selected
        private async void cmbProjectsHome_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProjectsHome.SelectedValue == null) return;

            try
            {
                string projectId = cmbProjectsHome.SelectedValue.ToString();
                MessageBox.Show($"Selected ProjectID: {projectId}"); // Debug
                await UpdateProgressAndExpenses(projectId);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        // Fetch and display data
        private async Task UpdateProgressAndExpenses(string projectId)
        {
            if (string.IsNullOrEmpty(projectId)) return;

            try
            {
                decimal progress = await GetProjectProgress(projectId);
                decimal totalExpenses = await GetTotalExpenses(projectId);

                this.Invoke((MethodInvoker)delegate
                {
                    progressBarHome.Value = (int)progress;
                    lblProgressHome.Text = $"{progress}%";
                    lblBudgetHome.Text = $"Pkr {totalExpenses:N0}";
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating stats: {ex.Message}");
            }
        }

        // Get total expenses
        private async Task<decimal> GetTotalExpenses(string projectId)
        {
            decimal materialTotal = 0, laborTotal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                // Material Total
                SqlCommand cmdMaterial = new SqlCommand(
                    "SELECT COALESCE(SUM(Quantity * CostPerUnit), 0) FROM ProjectMaterials WHERE ProjectID = @ProjectID",
                    connection);
                cmdMaterial.Parameters.AddWithValue("@ProjectID", projectId);
                materialTotal = Convert.ToDecimal(await cmdMaterial.ExecuteScalarAsync());

                // Labor Total
                SqlCommand cmdLabor = new SqlCommand(
                    "SELECT COALESCE(SUM(DaysWorked * Rate), 0) FROM ProjectLabor WHERE ProjectID = @ProjectID",
                    connection);
                cmdLabor.Parameters.AddWithValue("@ProjectID", projectId);
                laborTotal = Convert.ToDecimal(await cmdLabor.ExecuteScalarAsync());
            }

            return materialTotal + laborTotal;
        }

        private void btnOpenDetails_Click(object sender, EventArgs e)
        {
            ProjectDetailsForm detailsForm = new ProjectDetailsForm();
            detailsForm.DataUpdated += async () =>
            {
                if (cmbProjectsHome.SelectedValue != null)
                    await UpdateProgressAndExpenses(cmbProjectsHome.SelectedValue.ToString());
            };
            detailsForm.Show();
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            if (cmbProjectsHome.SelectedValue != null)
            {
                await UpdateProgressAndExpenses(cmbProjectsHome.SelectedValue.ToString());
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void labelgreet_Click(object sender, EventArgs e)
        {

        }
    }
}
