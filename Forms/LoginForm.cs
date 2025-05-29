using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RECMS.Helpers;
using RECMS.CEO;
using RECMS.Forms.SMM;

namespace RECMS.Forms
{
    public partial class LoginForm : Form
    {
        private string connectionString = DatabaseHelper.GetConnectionString();

        private bool _dragging = false;
        private Point _dragCursorPoint;
        private Point _dragFormPoint;
        public LoginForm()
        {
            InitializeComponent();
            this.AcceptButton = button1;

            panel1.MouseDown += Panel_MouseDown;
            panel1.MouseMove += Panel_MouseMove;
            panel1.MouseUp += Panel_MouseUp;
            textBox8.PasswordChar = '•'; // Set bullet character for password
            btnTogglePassword.Image = Properties.Resources.eye_closed; // Initial state

            textBox8.KeyDown += textBox8_KeyDown;
        }

        private void btnTogglePassword_Click(object sender, EventArgs e)
        {
            
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Hide error indicators initially
            lblstUser.Visible = false;
            lblstPW.Visible = false;

            // Get user input
            string username = textBox7.Text.Trim();
            string password = textBox8.Text;

            // Validate empty fields
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please fill in all fields!", "Missing Information",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (string.IsNullOrEmpty(username)) lblstUser.Visible = true;
                if (string.IsNullOrEmpty(password)) lblstPW.Visible = true;
                return;
            }

            // Database authentication
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(
         "SELECT Role, Password FROM Users WHERE Username COLLATE SQL_Latin1_General_CP1_CS_AS = @Username",
                         conn
                    );
                    cmd.Parameters.AddWithValue("@Username", username);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string storedPassword = reader["Password"].ToString();
                            string role = reader["Role"].ToString();

                            // Compare passwords (plain text)
                            if (password == storedPassword)
                            {
                                // Redirect based on role
                                if (role == "Managing Director (MD)")
                                {
                                    new MD_homeForm().Show();
                                    this.Hide();
                                }
                                else if (role == "Social Media Manager (SMM)")
                                {
                                    new SMM_homeForm().Show();
                                    this.Hide();
                                }
                                else if (role == "CEO")
                                {
                                    new CEOForm().Show();
                                    this.Hide();
                                }
                                return; // Exit if successful
                            }
                        }
                    }
                }

                // If we reach here, credentials are invalid
                lblstUser.Visible = true;
                lblstPW.Visible = true;
                MessageBox.Show("Invalid username or password!", "Authentication Failed",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Database error: {ex.Message}", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            lblstUser.Visible = false;
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            lblstPW.Visible = false;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            UIHelpers.RoundButton(button1, 10);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private GraphicsPath GetRoundedRectPath(Rectangle rect, int radius)
        {
            int diameter = radius * 2;
            var path = new GraphicsPath();

            path.StartFigure();
            path.AddArc(rect.Left, rect.Top, diameter, diameter, 180, 90);           // Top-left
            path.AddArc(rect.Right - diameter, rect.Top, diameter, diameter, 270, 90); // Top-right
            path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90); // Bottom-right
            path.AddArc(rect.Left, rect.Bottom - diameter, diameter, diameter, 90, 90); // Bottom-left
            path.CloseFigure();

            return path;
        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rect = panel2.ClientRectangle;
            rect.Inflate(-1, -1); // Leave space for border

            int cornerRadius = 20;

            using (GraphicsPath path = GetRoundedRectPath(rect, cornerRadius))
            {
                using (PathGradientBrush brush = new PathGradientBrush(path))
                {
                    // Center color (white)
                    brush.CenterColor = Color.FromArgb(245, 243, 239);

                    // Outer color (light gray at edges only)
                    brush.SurroundColors = new Color[] { Color.LightGray };

                    // Control how much white spreads — closer to (1.0, 1.0) = more white
                    brush.FocusScales = new PointF(0.9f, 0.9f); // Bigger white center, smaller gray border

                    e.Graphics.FillPath(brush, path);
                }

                // Optional border
                using (Pen borderPen = new Pen(Color.LightGray, 1))
                {
                    e.Graphics.DrawPath(borderPen, path);
                }
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnTogglePassword_Click_1(object sender, EventArgs e)
        {
            if (textBox8.PasswordChar == '•')
            {
                // Show password
                textBox8.PasswordChar = '\0';
                btnTogglePassword.Image = Properties.Resources.eye_open;
            }
            else
            {
                // Hide password
                textBox8.PasswordChar = '•';
                btnTogglePassword.Image = Properties.Resources.eye_closed;
            }
        }

        private void textBox8_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Validate and login
                button1_Click(sender, e);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            
        }

        private void cross_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
