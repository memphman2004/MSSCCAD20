using System;
using System.Windows.Forms;

namespace Assignments_4._2
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Simple credential check as requested
            if (txtUserId.Text == "Teacher" && txtPassword.Text == "Admin")
            {
                this.DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Invalid credentials. Try User ID: Teacher, Password: Admin",
                    "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) btnLogin.PerformClick();
        }
    }
}
