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
    public partial class ChangePasswordForm : Form
    {
        string userID;
        public UsersDashboard UsersDashboard;
        public ChangePasswordForm()
        {
            InitializeComponent();
        }

        public ChangePasswordForm(string id, UsersDashboard UsersDashboard)
        {
            InitializeComponent();
            userID = id;
            this.UsersDashboard = UsersDashboard;
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            string currentPassword = txtCurrentPassword.Text.Trim();
            string newPassword = txtNewPassword.Text.Trim();
            string confirmPassword = txtConfirmPassword.Text.Trim();

            if (string.IsNullOrWhiteSpace(currentPassword) ||
                string.IsNullOrWhiteSpace(newPassword) ||
                string.IsNullOrWhiteSpace(confirmPassword))
            {
                MessageBox.Show(
                    "All fields must be filled out.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (newPassword != confirmPassword)
            {
                MessageBox.Show(
                    "New password and confirm password do not match.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            string connectionString = "data source=LAPTOP-3GMBA5E1\\SQLEXPRESS; database=CAMPUS LOST AND FOUND; integrated security=SSPI";


            string query ="UPDATE Users SET Password = @NewPassword " + "WHERE IDNumber = @IDNumber AND Password = @CurrentPassword";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NewPassword", newPassword);
                    command.Parameters.AddWithValue("@IDNumber", userID);
                    command.Parameters.AddWithValue("@CurrentPassword", currentPassword);

                    connection.Open();

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show(
                            "Password changed successfully!",
                            "Success",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                        txtCurrentPassword.Clear();
                        txtNewPassword.Clear();
                        txtConfirmPassword.Clear();
                    }
                    else
                    {
                        MessageBox.Show(
                            "Current password is incorrect.",
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }

            this.Hide();
            LogIn f1 = new LogIn();
            f1.Show();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
            UsersDashboard.Show();
        }
    }
}
