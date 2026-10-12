using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CAMPUS_LOST_AND_FOUND
{
    public partial class UsersDashboard : Form
    {
        string userID;
        public UsersDashboard()
        {
            InitializeComponent();
        }

        public UsersDashboard(string id)
        {
            InitializeComponent();
            userID = id;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form f1 = new ReportItem();
            f1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form f2 = new ViewReportItems();
            f2.Show();
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

        private void btnProfile_Click(object sender, EventArgs e)
        {
            pnlProfileMenu.Visible = !pnlProfileMenu.Visible;
        }

        private void btnMyProfile_Click(object sender, EventArgs e)
        {
            this.Hide();
            MyProfileForm mp = new MyProfileForm(userID);
            mp.Show();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to logout?",
                "Logout",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                LogIn login = new LogIn();
                login.Show();

                this.Hide();
            }
        }

        private void btnChangePassword_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            ChangePasswordForm cp = new ChangePasswordForm(userID, this);
            cp.Show();
        }
    }
}
