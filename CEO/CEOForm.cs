using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RECMS.Forms;
using RECMS;

namespace RECMS.CEO
{
    public partial class CEOForm : Form
    {
        public CEOForm()
        {
            InitializeComponent();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            this.Hide();
            DashboardForm dashboardForm = new DashboardForm();
            dashboardForm.FormClosed += (s, args) => this.Show();
            dashboardForm.Show();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            this.Hide();
            ReportsForm reportsForm = new ReportsForm();
            reportsForm.FormClosed += (s, args) => this.Show();
            reportsForm.Show();
        }

        private void btnFinancials_Click(object sender, EventArgs e)
        {
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            this.Hide();
            UserManageForm settingsForm = new UserManageForm();
            settingsForm.FormClosed += (s, args) => this.Show();
            settingsForm.Show();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            // Close the current form (CEOForm)
            this.Hide();

            // Create a new instance of the LoginForm
            LoginForm loginForm = new LoginForm();

            // Show the LoginForm
            loginForm.Show();

            // Optionally, set the LoginForm as the startup form when it is closed
            loginForm.FormClosed += (s, args) => Application.Exit(); // This will exit the application when the LoginForm is closed.
        }

        private void panelTopHeader_Paint(object sender, PaintEventArgs e)
        {
            labelWelcome.Font = new Font("Arial", 16, FontStyle.Bold);
            labelWelcome.ForeColor = Color.White;
        }

        private void CEOForm_Load(object sender, EventArgs e)
        {
            FormHelper.MaximizeAndCenter(this);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
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
                this.Close();         // Close the current form (optional)

                // OR: this.Hide();   // Hide the current form (if you want to hide it)
            }
        }

        private void btnSettings_Click_1(object sender, EventArgs e)
        {
            UserManageForm settingsForm = new UserManageForm();
            settingsForm.Show(); //
            this.Hide();
        }
    }
}
