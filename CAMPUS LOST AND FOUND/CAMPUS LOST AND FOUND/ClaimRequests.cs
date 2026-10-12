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
    public partial class ClaimRequests : Form
    {
        private string connectionString = @"data source=LAPTOP-3GMBA5E1\SQLEXPRESS; database=CAMPUS LOST AND FOUND; integrated security=SSPI";
        public ClaimRequests()
        {
            InitializeComponent();
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;

            string query = "SELECT * FROM Claims";
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

                    if (dataGridView1.Columns["Action"] == null)
                    {
                        DataGridViewButtonColumn btnColumn = new DataGridViewButtonColumn();
                        btnColumn.Name = "Action";
                        btnColumn.HeaderText = "Action";
                        btnColumn.Text = "Review";
                        btnColumn.UseColumnTextForButtonValue = true;
                        dataGridView1.Columns.Add(btnColumn);
                    }
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {

                if (dataGridView1.Columns[e.ColumnIndex].Name == "Action")
                {
                    int i = (int)dataGridView1.Rows[e.RowIndex].Cells["ItemID"].Value;

                    ClaimReview f2 = new ClaimReview(i);
                    f2.Show();
                    this.Hide();
                }
            }
        }
        private void backToDashBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminDashboard ad = new AdminDashboard();
            ad.Show();
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            string searchValue = textBox1.Text.Trim();

            if (string.IsNullOrWhiteSpace(searchValue))
            {
                MessageBox.Show("Please enter a search term.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = @"SELECT * FROM Claims 
                     WHERE ClaimID LIKE @searchTerm 
                        OR ItemID LIKE @searchTerm 
                        OR Contact LIKE @searchTerm 
                        OR Description LIKE @searchTerm 
                        OR cLocation LIKE @searchTerm";

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
    }
}
