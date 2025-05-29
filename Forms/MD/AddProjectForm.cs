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

namespace RECMS.Forms.MD
{
    public partial class AddProjectForm : Form
    {

        private readonly string _connectionString = DatabaseHelper.GetConnectionString();

        // Event to notify parent form after project addition
        public event Action ProjectAdded;
        public AddProjectForm()
        {
            InitializeComponent();
            this.Load += async (sender, e) => await GenerateNextProjectIdAsync();
        }

        private async Task GenerateNextProjectIdAsync()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    // Get the highest numeric part of ProjectID (e.g., 001 from P001)
                    string query = @"
                        SELECT MAX(CAST(SUBSTRING(ProjectID, 2, LEN(ProjectID)) AS INT)) 
                        FROM Projects 
                        WHERE ProjectID LIKE 'P%' 
                        AND ISNUMERIC(SUBSTRING(ProjectID, 2, LEN(ProjectID))) = 1";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        object result = await command.ExecuteScalarAsync();
                        int maxId = result == DBNull.Value ? 0 : Convert.ToInt32(result);

                        // Format next ID as P + 3-digit number (e.g., P001)
                        txtProjectID.Text = $"P{(maxId + 1):D3}";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generating ProjectID: {ex.Message}");
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
           
        }

        private async Task SaveProjectAsync()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = @"
                    INSERT INTO Projects (ProjectID, ProjectName, Budget)
                    VALUES (@ProjectID, @ProjectName, @Budget)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ProjectID", txtProjectID.Text.Trim());
                    command.Parameters.AddWithValue("@ProjectName", txtProjectName.Text.Trim());
                    command.Parameters.AddWithValue("@Budget", numBudget.Value);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        private void AddProjectForm_Load(object sender, EventArgs e)
        {

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

        private async void btnSave_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtProjectName.Text))
            {
                MessageBox.Show("Project Name is required!");
                return;
            }

            try
            {
                await SaveProjectAsync();
                ProjectAdded?.Invoke();
                this.Close();
            }
            catch (SqlException ex) when (ex.Number == 2627)
            {
                MessageBox.Show("Project ID already exists! Try again.");
                await GenerateNextProjectIdAsync(); // Regenerate ID if conflict
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving project: {ex.Message}");
            }
        }

        private void cross_Click(object sender, EventArgs e)
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
    }

    
    
}
