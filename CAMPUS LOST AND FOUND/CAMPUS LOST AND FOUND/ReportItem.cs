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
    public partial class ReportItem : Form
    {
        public ReportItem()
        {
            InitializeComponent();
            string[] category = new string[16];

            category[0] = "Identification";
            category[1] = "Electronics";
            category[2] = "Computers";
            category[3] = "Gadgets";
            category[4] = "Storage";
            category[5] = "Keys";
            category[6] = "Bags";
            category[7] = "Books";
            category[8] = "Stationery";
            category[9] = "Rainwear";
            category[10] = "Containers";
            category[11] = "Audio";
            category[12] = "Apparel";
            category[13] = "Eyewear";
            category[14] = "Accessories";
            category[15] = "Other";

            CategorycomboBox1.DataSource = category;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            UsersDashboard ud = new UsersDashboard();
            ud.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NametextBox1.Text))
            {
                MessageBox.Show("Please fill in the Item Name field.",
                                "Missing Information",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                NametextBox1.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(CategorycomboBox1.Text))
            {
                MessageBox.Show("Please select a Category.",
                                "Missing Information",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                CategorycomboBox1.Focus();
                return;
            }

            if (!radioButton1.Checked && !radioButton2.Checked)
            {
                MessageBox.Show("Please select the Item Status.",
                                "Missing Information",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }


            if (string.IsNullOrWhiteSpace(ColortextBox2.Text))
            {
                MessageBox.Show("Please fill in the Color field.",
                                "Missing Information",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                ColortextBox2.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(LocationtextBox3.Text))
            {
                MessageBox.Show("Please fill in the Last Location field.",
                                "Missing Information",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                LocationtextBox3.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(ContacttextBox4.Text))
            {
                MessageBox.Show("Please fill in the Contact Info field.",
                                "Missing Information",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                ContacttextBox4.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(BrandtextBox5.Text))
            {
                MessageBox.Show("Please fill in the Brand field.",
                                "Missing Information",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                BrandtextBox5.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(DescriptionrichTextBox1.Text))
            {
                MessageBox.Show("Please fill in the Description field.",
                                "Missing Information",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                DescriptionrichTextBox1.Focus();
                return;
            }


            string connectionString = "data source=LAPTOP-3GMBA5E1\\SQLEXPRESS; database=CAMPUS LOST AND FOUND; integrated security=SSPI";

            string itemName = NametextBox1.Text.Trim();
            string category = CategorycomboBox1.Text.Trim();
            string date = dateTimePicker1.Text.Trim();
            string description = DescriptionrichTextBox1.Text.Trim();
            string color = ColortextBox2.Text.Trim();
            string location = LocationtextBox3.Text.Trim();
            string contact = ContacttextBox4.Text.Trim();
            string brand = BrandtextBox5.Text.Trim();
            string status;

            if (radioButton1.Checked)
            { status = radioButton1.Text; }

            else
            { status = radioButton2.Text; }


            //string details = itemName + "\n" + category + "\n" + date + "\n" + description + "\n" + color + "\n" + location + "\n" + contact + "\n" + brand + "\n" + status;
            //MessageBox.Show(details);

            string query = "INSERT INTO Reports (ItemName, Category, Date, Description, Color, Location, Contact, Brand, Status) VALUES (@ItemName, @Category, @Date, @Description, @Color, @Location, @Contact, @Brand, @Status)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ItemName", itemName);
                    command.Parameters.AddWithValue("@Category", category);
                    command.Parameters.AddWithValue("@Date", dateTimePicker1.Value);
                    command.Parameters.AddWithValue("@Description", description);
                    command.Parameters.AddWithValue("@Color", color);
                    command.Parameters.AddWithValue("@Location", location);
                    command.Parameters.AddWithValue("@Contact", contact);
                    command.Parameters.AddWithValue("@Brand", brand);
                    command.Parameters.AddWithValue("@Status", status);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Report successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();
                        ViewReportItems f1 = new ViewReportItems();
                        f1.Show();
                    }
                    else
                    {
                        MessageBox.Show("Failed to create the profile. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
        }
    }
}
