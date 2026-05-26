using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ticket_management;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace cs311_eteeap2026_mistica
{
    public partial class frmAddAccounts : Form
    {
        private string username;
        private int errorcount;
        Class1 addaccount = new Class1("127.0.0.1", "itc127-eteeap2026-mistica", "root", "");
        public frmAddAccounts(string username)
        {
            InitializeComponent();
            this.username = username;
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            try
            {
                //validations
                errorProvider1.Clear();
                errorcount = 0;
                if (string.IsNullOrEmpty(txtusername.Text))
                {
                    errorProvider1.SetError(txtusername, "Username is empty.");
                    errorcount++;
                }
                if (string.IsNullOrEmpty(txtpassword.Text))
                {
                    errorProvider1.SetError(txtpassword, "Password is empty.");
                    errorcount++;
                }
                if (cmbusertype.SelectedIndex < 0)
                {
                    errorProvider1.SetError(cmbusertype, "Select a usertype.");
                    errorcount++;
                }
                try
                {
                    DataTable dt = addaccount.GetData("SELECT * FROM tblaccounts WHERE username = '" + txtusername.Text + "'");
                    if (dt.Rows.Count > 0)
                    {
                        errorProvider1.SetError(txtusername, "Username is already in use.");
                        errorcount++;
                    }
                }
                catch (Exception error)
                {
                    MessageBox.Show("Error on validating username:" + error.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                //create account
                if (errorcount == 0)
                {
                    DialogResult dr = MessageBox.Show("Are you sure you want to create this account?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        addaccount.executeSQL("INSERT INTO tblaccounts (username, password, usertype, status, createdby, datecreated) VALUES ('" + txtusername.Text + "' , '" + txtpassword.Text + "' , '" +
                            cmbusertype.Text.ToUpper() + "' , 'ACTIVE' , '" + username + "' , '" + DateTime.Now.ToString("dd/MM/yyyy") + "')");
                        if (addaccount.rowAffected > 0)
                        {
                            MessageBox.Show("New account added.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Error on btnadd_click:" + error.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbshow_CheckedChanged(object sender, EventArgs e)
        {
            if (cbshow.Checked)
            {
                txtpassword.PasswordChar = '\0';
            }
            else
            {
                txtpassword.PasswordChar = '*';
            }
        }

        private void btclear_Click(object sender, EventArgs e)
        {
            txtusername.Clear();
            txtpassword.Clear();
            cmbusertype.SelectedIndex = -1;
        }

        private void frmAddAccounts_Load(object sender, EventArgs e)
        {

        }
    }
}
