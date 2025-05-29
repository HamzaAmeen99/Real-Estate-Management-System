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

namespace RECMS.CEO
{
    public partial class UserManageForm : Form
    {

        private string connectionString = DatabaseHelper.GetConnectionString();
        public UserManageForm()
        {
            InitializeComponent();
            LoadRoles();
        }

        private void LoadRoles()
        {
            // Populate roles from the database
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT Role FROM Users", conn);
                SqlDataReader reader = cmd.ExecuteReader();

                cmbRoles.Items.Clear(); // Clear existing items

                while (reader.Read())
                {
                    cmbRoles.Items.Add(reader["Role"].ToString());
                }
            }
        }


        private void cmbRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbRoles.SelectedItem == null) return;

            string role = cmbRoles.SelectedItem.ToString();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(
                        "SELECT Username FROM Users WHERE Role = @Role",
                        conn
                    );
                    cmd.Parameters.AddWithValue("@Role", role);
                    object result = cmd.ExecuteScalar();
                    txtCurrentUser.Text = result?.ToString() ?? "No user found";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading user: {ex.Message}");
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string role = cmbRoles.Text;
            string newUsername = txtNewUsername.Text.Trim();
            string newPassword = txtNewPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            // Validate password match
            if (newPassword != confirmPassword)
            {
                MessageBox.Show("Passwords do not match!", "Error");
                return;
            }

            // Update the database
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(
                    "UPDATE Users SET Username = @Username, Password = @Password WHERE Role = @Role",
                    conn
                );
                cmd.Parameters.AddWithValue("@Role", role);
                cmd.Parameters.AddWithValue("@Username", newUsername);
                cmd.Parameters.AddWithValue("@Password", newPassword); // Plain text (INSECURE)
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Credentials updated successfully!");
            txtNewUsername.Clear();
            txtNewPassword.Clear();
            txtConfirmPassword.Clear();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            // Show CEOForm(if it exists)
    foreach (Form form in Application.OpenForms)
            {
                if (form is CEOForm)
                {
                    form.Show();
                    break;
                }
            }

            this.Close(); // Close UserManageForm
        }
    }
}
