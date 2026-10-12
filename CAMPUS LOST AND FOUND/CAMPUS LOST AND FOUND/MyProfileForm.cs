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
    public partial class MyProfileForm : Form
    {
        string userID;
        public MyProfileForm(string id)
        {
            InitializeComponent();
            userID = id;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
            UsersDashboard ud = new UsersDashboard(userID);
            ud.Show();
        }

        private void MyProfileForm_Load(object sender, EventArgs e)
        {
            string connectionString = "data source=LAPTOP-3GMBA5E1\\SQLEXPRESS; database=CAMPUS LOST AND FOUND; integrated security=SSPI";


            string query = "SELECT FullName, IDNumber, Email, Phone, UserType " +
                           "FROM Users WHERE IDNumber = @IDNumber";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IDNumber", userID);

                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        txtFullName.Text = reader["FullName"].ToString();
                        txtID.Text = reader["IDNumber"].ToString();
                        txtEmail.Text = reader["Email"].ToString();
                        txtPhone.Text = reader["Phone"].ToString();
                        cmbUserType.Text = reader["UserType"].ToString();

                        cmbUserType.Enabled = false;
                    }
                }
            }
        }

        private void btnEditProfile_Click(object sender, EventArgs e)
        {
            string newName = txtFullName.Text.Trim();
            string newEmail = txtEmail.Text.Trim();
            string newPhone = txtPhone.Text.Trim();
            string id = txtID.Text.Trim();

            if (string.IsNullOrWhiteSpace(newName) || string.IsNullOrWhiteSpace(newEmail) || string.IsNullOrWhiteSpace(newPhone) || string.IsNullOrWhiteSpace(id))
            {
                MessageBox.Show("All fields must be filled out.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string connectionString = "data source=LAPTOP-3GMBA5E1\\SQLEXPRESS; database=CAMPUS LOST AND FOUND; integrated security=SSPI";

            string query = "UPDATE Users SET FullName = @FullName, Email = @Email, Phone = @Phone WHERE IDNumber = @IDNumber";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IDNumber", id);
                    command.Parameters.AddWithValue("@FullName", newName);
                    command.Parameters.AddWithValue("@Email", newEmail);
                    command.Parameters.AddWithValue("@Phone", newPhone);

                    connection.Open();

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Record updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("No record was updated. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            this.Hide();
            LogIn lf = new LogIn();
            lf.Show();
        }

        private void btnDeleteProfile_Click(object sender, EventArgs e)
        {
            string id = txtID.Text.Trim();

            if (string.IsNullOrWhiteSpace(id))
            {
                MessageBox.Show("Please enter a valid ID Number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this profile?",
                "Confirm Deletion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                string connectionString = "data source=LAPTOP-3GMBA5E1\\SQLEXPRESS; database=CAMPUS LOST AND FOUND; integrated security=SSPI";
                string query = "DELETE FROM Users WHERE IDNumber = @IDNumber";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@IDNumber", id);

                        connection.Open();

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Profile deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Close();
                        }
                        else
                        {
                            MessageBox.Show("No profile was found to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }

            this.Hide();
            LogIn lf = new LogIn();
            lf.Show();
        }

    }
}
