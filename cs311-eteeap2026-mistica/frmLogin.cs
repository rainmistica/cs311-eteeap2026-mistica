using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using ticket_management;

namespace cs311_eteeap2026_mistica
{
    public partial class frmLogin : MaterialForm
    {
        public frmLogin()
        {
            InitializeComponent();

            ThemeManager.Apply(this);
        }
        Class1 login = new Class1("127.0.0.1", "itc127-eteeap2026-mistica", "root","");

        private void cbShow_CheckedChanged(object sender, EventArgs e)
        {
            if(cbShow.Checked) 
            {
                txtPassword.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '*';
            }
        }

        private void frmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            try
            {
                var dt = login.GetData($"SELECT * FROM tblaccounts WHERE username = '{txtUsername.Text}' AND password = '{txtPassword.Text}' and status = 'ACTIVE'");
                if (dt.Rows.Count > 0)
                {
                    var mainform = new frmMain(txtUsername.Text, dt.Rows[0].Field<string>("usertype"));
                    this.Hide();
                    mainform.ShowDialog();

                }
                else
                {
                    MessageBox.Show("Incorrect login credentials or account is inactive.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error on btnLogin_click {ex.Message}",
                    "ERROR",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click_1(object sender, EventArgs e)
        {
            txtUsername.Clear();
            txtPassword.Clear();
            txtUsername.Focus();
        }
    }
}
