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
    public partial class ResolvedReports : Form
    {
        public ResolvedReports()
        {
            InitializeComponent();
            LoadDetails();
        }

        string connectionString = "data source=LAPTOP-3GMBA5E1\\SQLEXPRESS; database=CAMPUS LOST AND FOUND; integrated security=SSPI";

        private void LoadDetails()
        {
            string query = "SELECT ID, ItemName, Category, Date, Contact, Location, Description, Status FROM Reports WHERE Status = 'Returned'";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    DataTable dataTable = new DataTable();
                    dataTable.Load(reader);

                    resolvedDataGridView.DataSource = dataTable;
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminDashboard f1 = new AdminDashboard();
            f1.Show();
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            string searchValue = textBox1.Text.Trim();

            if (string.IsNullOrWhiteSpace(searchValue))
            {
                MessageBox.Show("Please enter a search term.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = @"SELECT ID, ItemName, Category, Date, Contact, Location, Description, Status FROM Reports
                     WHERE Status = 'Returned' 
                       AND (CAST(ID AS NVARCHAR) LIKE @searchTerm
                         OR ItemName LIKE @searchTerm 
                         OR Category LIKE @searchTerm 
                         OR Contact LIKE @searchTerm 
                         OR Location LIKE @searchTerm 
                         OR Description LIKE @searchTerm)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@searchTerm", "%" + searchValue + "%");


                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    DataTable dataTable = new DataTable();
                    dataTable.Load(reader);
                    resolvedDataGridView.DataSource = dataTable;

                    if (dataTable.Rows.Count == 0)
                    {
                        MessageBox.Show("No matching rows found.", "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
    }
}
