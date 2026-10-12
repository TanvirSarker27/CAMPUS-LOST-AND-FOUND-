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

namespace CAMPUS_LOST_AND_FOUND
{
    public partial class LogIn : Form
    {
        public LogIn()
        {
            InitializeComponent();
        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            this.Hide();
            Registration rf = new Registration();
            rf.Show();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string userID = txtID.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrWhiteSpace(userID) ||
                string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show(
                    "Please enter your ID and Password.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            string connectionString = "data source=LAPTOP-3GMBA5E1\\SQLEXPRESS; database=CAMPUS LOST AND FOUND; integrated security=SSPI";

            string query = "SELECT UserType FROM Users WHERE IDNumber COLLATE SQL_Latin1_General_CP1_CS_AS = @IDNumber AND Password COLLATE SQL_Latin1_General_CP1_CS_AS =  @Password";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IDNumber", userID);
                    command.Parameters.AddWithValue("@Password", password);

                    connection.Open();

                    object result = command.ExecuteScalar();

                    if (result != null)
                    {
                        string userType = result.ToString();

                        this.Hide();

                        if (userType == "Admin")
                        {
                            AdminDashboard adminForm = new AdminDashboard();
                            adminForm.Show();
                        }
                        else if (userType == "Student" || userType == "Staff")
                        {
                            UsersDashboard ud = new UsersDashboard(userID);
                            ud.Show();
                        }
                    }
                    else
                    {
                        MessageBox.Show(
                            "Invalid ID or Password.",
                            "Login Failed",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }
        }

    }
}
