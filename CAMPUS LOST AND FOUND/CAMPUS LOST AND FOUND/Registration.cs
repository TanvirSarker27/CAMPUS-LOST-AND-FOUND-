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
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string connectionString = "data source=LAPTOP-3GMBA5E1\\SQLEXPRESS; database=CAMPUS LOST AND FOUND; integrated security=SSPI";

            string fullName = txtFullName.Text.Trim();
            string id = txtID.Text.Trim();
            string email = txtEmail.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string userType = cmbUserType.Text;
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrWhiteSpace(fullName) ||
                string.IsNullOrWhiteSpace(id) ||
                string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(phone) ||
                string.IsNullOrWhiteSpace(userType) ||
                string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show(
                    "All fields must be filled out.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            string query = "INSERT INTO Users (FullName, IDNumber, Email, Phone, UserType, Password) " +
                           "VALUES (@FullName, @IDNumber, @Email, @Phone, @UserType, @Password)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FullName", fullName);
                    command.Parameters.AddWithValue("@IDNumber", id);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Phone", phone);
                    command.Parameters.AddWithValue("@UserType", userType);
                    command.Parameters.AddWithValue("@Password", password);

                    connection.Open();

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show(
                            "Registration successful!",
                            "Success",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                        this.Hide();

                        LogIn lf = new LogIn();
                        lf.Show();
                    }
                    else
                    {
                        MessageBox.Show(
                            "Registration failed. Please try again.",
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();
            LogIn f1 = new LogIn();
            f1.Show();
        }
    }
}
