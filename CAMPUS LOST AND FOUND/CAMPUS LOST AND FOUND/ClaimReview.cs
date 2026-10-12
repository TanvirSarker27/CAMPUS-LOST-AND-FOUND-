using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CAMPUS_LOST_AND_FOUND
{
    public partial class ClaimReview : Form
    {
        public ClaimReview()
        {
            InitializeComponent();
        }
        int rId;
        string connectionString = "data source=LAPTOP-3GMBA5E1\\SQLEXPRESS; database=CAMPUS LOST AND FOUND; integrated security=SSPI";
        public ClaimReview(int i)
        {
            rId = i;
            InitializeComponent();
            LoadDetails();
        }

        private void LoadDetails()
        {
            string query1 = "SELECT ID, ItemName, Category, Location, Description FROM Reports WHERE ID = @ID";
            string query2 = "SELECT cLocation, Description FROM Claims WHERE ItemID = @ItemID";

            using (SqlConnection con1 = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query1, con1))
                {
                    cmd.Parameters.AddWithValue("@ID", rId);

                    con1.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            itemIdTB.Text = reader["ID"].ToString();
                            itemNameTB.Text = reader["ItemName"].ToString();
                            categoryTB.Text = reader["Category"].ToString();
                            rLastLocationTB.Text = reader["Location"].ToString();
                            rDescriptionTB.Text = reader["Description"].ToString();

                        }
                        else
                        {
                            MessageBox.Show("No report record found for Item ID: " + rId, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }

                using (SqlConnection con2 = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query2, con2))
                    {
                        cmd.Parameters.AddWithValue("@ItemID", rId);

                        con2.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                cLastLocationTB.Text = reader["cLocation"].ToString();
                                cDescriptionTB.Text = reader["Description"].ToString();
                            }
                            else
                            {
                                MessageBox.Show("No claim record found for Item ID: " + rId, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }


            }
        }
        private void back2DashboardBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminDashboard f3 = new AdminDashboard();
            f3.Show();
        }

        private void approveBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
            "Are you sure you want to approve this claim?",
            "Confirm Approval",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                return;
            }

            string query = "UPDATE Reports SET Status = 'Returned' WHERE ID = @ID; UPDATE Claims SET Status = 'Approved' WHERE ItemID = @ID;";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@ID", rId);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show(
                "Claim approved successfully! The claimant has been notified and provided with the founder's contact information.",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            this.Hide();
            ResolvedReports f1 = new ResolvedReports();
            f1.Show();

        }

        private void rejectBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
            "Are you sure you want to reject this claim?",
            "Confirm Rejection",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning);

            if (result == DialogResult.No)
            {
                return;
            }

            string query = "UPDATE Reports SET Status = 'Returned' WHERE ID = @ID; UPDATE Claims SET Status = 'Rejected' WHERE ItemID = @ID;";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@ID", rId);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show(
                "Claim Rejected!!",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            this.Hide();
            ClaimRequests f2 = new ClaimRequests();
            f2.Show();
        }
    }
}
