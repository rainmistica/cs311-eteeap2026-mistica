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

namespace cs311_eteeap2026_mistica
{
    public partial class frmUpdateAccounts : Form
    {
        private string editusername, editpassword, editusertype, editstatus, username;
        private int errorcount;

        Class1 updateaccount = new Class1("127.0.0.1", "itc127-eteeap2026-mistica", "root", "");
        public frmUpdateAccounts(string editusername, string editpassword, string editusertype,
            string editstatus, string username)
        {
            InitializeComponent();
            this.editusername = editusername;
            this.editpassword = editpassword;
            this.editusertype = editusertype;
            this.editstatus = editstatus;
            this.username = username;
        }

        private void frmUpdateAccounts_Load(object sender, EventArgs e)
        {
            txtusername.Text = editusername;
            txtpassword.Text = editpassword;
            if (editusertype == "ADMINISTRATOR")
            {
                cmbusertype.SelectedIndex = 0;
            }
            else if (editusertype == "TECHNICAL")
            {
                cmbusertype.SelectedIndex = 1;
            }
            else if (editusertype == "USER")
            {
                cmbusertype.SelectedIndex = 2;
            }
            else
            {
                cmbusertype.SelectedIndex = -1;
            }
            if (editstatus == "ACTIVE")
            {
                cmbstatus.SelectedIndex = 0;
            }
            else if (editstatus == "INACTIVE")
            {
                cmbstatus.SelectedIndex = 1;
            }
            else
            {
                cmbstatus.SelectedIndex = -1;
            }
        }
        private void chkshow_CheckedChanged(object sender, EventArgs e)
        {
            if (chkshow.Checked)
            {
                txtpassword.PasswordChar = '\0';
            }
            else
            {
                txtpassword.PasswordChar = '*';
            }
        }
        private void btnsave_Click(object sender, EventArgs e)
        {
            //validations
            errorProvider1.Clear();
            errorcount = 0;
            if (string.IsNullOrEmpty(txtpassword.Text))
            {
                errorProvider1.SetError(txtpassword, "Input is empty.");
                errorcount++;
            }
            if (cmbusertype.SelectedIndex < 0)
            {
                errorProvider1.SetError(cmbusertype, "Select usertype.");
                errorcount++;
            }
            if (cmbstatus.SelectedIndex < 0)
            {
                errorProvider1.SetError(cmbstatus, "Select status.");
                errorcount++;
            }
            if (errorcount == 0)
            {
                try
                {
                    DialogResult dr = MessageBox.Show("Are you sure you want to update this account?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        updateaccount.executeSQL("UPDATE tblaccounts SET password = '" + txtpassword.Text + "', usertype = '" + cmbusertype.Text.ToUpper() + "', status = '" +
                            cmbstatus.Text.ToUpper() + "' WHERE username = '" + txtusername.Text + "'");
                        if (updateaccount.rowAffected > 0)
                        {
                            MessageBox.Show("Account updated.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            updateaccount.executeSQL("INSERT INTO tbllogs (datelog, timelog, action, module, performedto, performedby) VALUES ('" + DateTime.Now.ToString("dd/MM/yyyy") + "', '" +
                                DateTime.Now.ToShortTimeString() + "', 'UPDATE ACCOUNT', 'ACCOUNTS MANAGEMENT', '" + txtusername.Text + "', '" + username + "')");
                            this.Close();
                        }
                    }
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message, "Error on btnsave_Click()", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
