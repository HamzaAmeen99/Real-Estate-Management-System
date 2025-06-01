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
using System.Data.SqlTypes;
using System.Reflection.Emit;

namespace RECMS.CEO
{
    public partial class CEOForm : Form
    {
        private System.Windows.Forms.Timer timerClock = new System.Windows.Forms.Timer();
        private Color originalColor;

        public CEOForm()
        {
            InitializeComponent();
            originalColor = Color.FromArgb(111, 142, 136); // Or set to whatever default color you use
        }

        private void CEOForm_Load(object sender, EventArgs e)
        {
            FormHelper.MaximizeAndCenter(this);
            //timerDateTime.Start();
            UIHelpers.RoundButton(btnDashboard, 10);
            UIHelpers.RoundButton(btnReports, 10);
            UIHelpers.RoundButton(btnSettings, 10);
            UIHelpers.RoundButton(btnLogout, 10);
            // Enable drag
            FormDragHelper.MakeDraggable(this, panelTopHeader);
            lblDateTime.Text = DateTime.Now.ToString("dddd, dd-MM-yyyy hh:mm:ss tt");

            timerClock.Interval = 1000;
            timerClock.Tick += TimerClock_Tick;
            timerClock.Start();


            // Assign hover events
            btnDashboard.MouseEnter += Button_MouseEnter;
            btnDashboard.MouseLeave += Button_MouseLeave;

            btnReports.MouseEnter += Button_MouseEnter;
            btnReports.MouseLeave += Button_MouseLeave;

            btnSettings.MouseEnter += Button_MouseEnter;
            btnSettings.MouseLeave += Button_MouseLeave;

            btnLogout.MouseEnter += Button_MouseEnter;
            btnLogout.MouseLeave += Button_MouseLeave;
        }

        private void Button_MouseEnter(object sender, EventArgs e)
        {
            ((Button)sender).BackColor = Color.FromArgb(28, 79, 72);
        }

        private void Button_MouseLeave(object sender, EventArgs e)
        {
            ((Button)sender).BackColor = originalColor;
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
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            loginForm.FormClosed += (s, args) => Application.Exit();
        }

        private void panelTopHeader_Paint(object sender, PaintEventArgs e)
        {
            labelWelcome.Font = new Font("Arial", 16, FontStyle.Bold);
            labelWelcome.ForeColor = Color.White;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to exit the application?",
                "Exit Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
                this.Close();
            }
        }

        private void btnSettings_Click_1(object sender, EventArgs e)
        {
            UserManageForm settingsForm = new UserManageForm();
            settingsForm.Show();
            this.Hide();
        }

        private void timerDateTime_Tick(object sender, EventArgs e)
        {
            //panelDateTime.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy hh:mm:ss tt");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }
        private void TimerClock_Tick(object sender, EventArgs e)
        {
            lblDateTime.Text = DateTime.Now.ToString("dddd, dd-MM-yyyy hh:mm:ss tt");
        }

        private void panelMainContent_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
