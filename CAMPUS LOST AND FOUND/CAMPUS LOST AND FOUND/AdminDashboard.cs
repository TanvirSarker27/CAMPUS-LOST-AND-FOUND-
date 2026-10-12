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
    public partial class AdminDashboard : Form
    {
        string connectionString = "data source=LAPTOP-3GMBA5E1\\SQLEXPRESS; database=CAMPUS LOST AND FOUND; integrated security=SSPI";
        public AdminDashboard()
        {
            InitializeComponent();
            string query = "SELECT * FROM Reports";
            FillDataGridView(query);
        }

        private void FillDataGridView(string query)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    con.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    DataTable dataTable = new DataTable();
                    dataTable.Load(reader);
                    dataGridView1.DataSource = dataTable;
                }
            }

        }
        private void searchBtn_Click(object sender, EventArgs e)
        {
            string searchValue = textBox1.Text.Trim();

            if (string.IsNullOrWhiteSpace(searchValue))
            {
                MessageBox.Show("Please enter a search term.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = @"SELECT ID, ItemName, Category, Date, Color, Brand, Status FROM Reports 
                     WHERE ID LIKE @searchTerm 
                        OR ItemName LIKE @searchTerm 
                        OR Category LIKE @searchTerm 
                        OR Color LIKE @searchTerm 
                        OR Brand LIKE @searchTerm 
                        OR Status LIKE @searchTerm";


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@searchTerm", "%" + searchValue + "%");

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    DataTable dataTable = new DataTable();
                    dataTable.Load(reader);
                    dataGridView1.DataSource = dataTable;

                    if (dataTable.Rows.Count == 0)
                    {
                        MessageBox.Show("No matching rows found.", "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void viewClaimsBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form f2 = new ClaimRequests();
            f2.Show();
        }

        private void viewResolvedBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            ResolvedReports f3 = new ResolvedReports();
            f3.Show();
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show(
                "Are you sure you want to exit the application?",
                   "Confirm Exit",
                   MessageBoxButtons.YesNo,
                   MessageBoxIcon.Question
   );

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
