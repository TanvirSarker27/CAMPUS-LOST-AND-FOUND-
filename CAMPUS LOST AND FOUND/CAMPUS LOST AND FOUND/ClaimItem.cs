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
    public partial class ClaimItem : Form
    {
        public ClaimItem()
        {
            InitializeComponent();
        }

        private void btnSubmitClaim_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(ItemIdTextBox.Text))
            {
                MessageBox.Show("Please fill in the Item ID field.",
                                "Missing Information",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                ItemIdTextBox.Focus();
                return;
            }

            int itemID;

            if (!int.TryParse(ItemIdTextBox.Text.Trim(), out itemID))
            {
                MessageBox.Show("Please enter number values for Item ID field.",
                                "Invalid Input",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                ItemIdTextBox.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(ClmContactTextBox.Text))
            {
                MessageBox.Show("Please fill in the Contact field.",
                                "Missing Information",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                ClmContactTextBox.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(ClmDescriptionRichTextBox.Text))
            {
                MessageBox.Show("Please fill in the Description field.",
                                "Missing Information",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                ClmDescriptionRichTextBox.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(ClmLocationTextBox.Text))
            {
                MessageBox.Show("Please fill in the Last Location field.",
                                "Missing Information",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                ClmLocationTextBox.Focus();
                return;
            }


            string connectionString = @"data source=LAPTOP-3GMBA5E1\SQLEXPRESS; database=CAMPUS LOST AND FOUND; integrated security=SSPI";

            itemID = Convert.ToInt32(ItemIdTextBox.Text.Trim());
            string clmContact = ClmContactTextBox.Text.Trim();
            string clmDescription = ClmDescriptionRichTextBox.Text.Trim();
            string clmLocation = ClmLocationTextBox.Text.Trim();

            string query = "INSERT INTO Claims (ItemID, Contact, Description, cLocation,Status) VALUES (@ItemID, @Contact, @Description, @cLocation,@Status)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ItemID", itemID);
                    command.Parameters.AddWithValue("@Contact", clmContact);
                    command.Parameters.AddWithValue("@Description", clmDescription);
                    command.Parameters.AddWithValue("@cLocation", clmLocation);
                    command.Parameters.AddWithValue("@Status", "Pending");//

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Report successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();
                        UsersDashboard ud = new UsersDashboard();
                        ud.Show();
                    }
                    else
                    {
                        MessageBox.Show("Failed to create the profile. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnViewReports_Click(object sender, EventArgs e)
        {
            this.Hide();
            ViewReportItems f2 = new ViewReportItems();
            f2.Show();
        }
    }
}
