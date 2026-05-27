using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin.Controls;
using ticket_management;

namespace cs311_eteeap2026_mistica
{
    public partial class frmAccounts : MaterialForm
    {
        private string username;
        private int row;
        public frmAccounts(string username)
        {
            InitializeComponent();
            ThemeManager.Apply(this);
            this.username = username;
        }
        Class1 accounts = new Class1("127.0.0.1", "itc127-eteeap2026-mistica", "root", "");
        private void frmAccounts_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = accounts.GetData("SELECT * FROM tblaccounts ORDER BY username");
                dataGridView1.DataSource = dt;
            }
            catch (Exception error)
            {
                MessageBox.Show("Error on frmaccounts_Load:" + error.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = accounts.GetData("SELECT * FROM tblaccounts WHERE username LIKE '%" + txtsearch.Text + "%' OR usertype LIKE '%" + txtsearch.Text + "%' ORDER BY username");
                dataGridView1.DataSource = dt;
            }
            catch (Exception error)
            {
                MessageBox.Show("Error on btnsearch_click:" + error.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtsearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnsearch_Click(sender, e);
            }
        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            RefreshView(sender,e);
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            var addaccountform = new frmAddAccounts(username);
            addaccountform.ShowDialog();
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                row = (int)e.RowIndex;
            }
            catch (Exception error)
            {
                MessageBox.Show("Error on datagridview1_cellclick:" + error.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure you want to delete this account?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    accounts.executeSQL("DELETE FROM tblaccounts WHERE username = '" + dataGridView1.Rows[row].Cells[0].Value.ToString() + "'");
                    if (accounts.rowAffected > 0)
                    {
                        accounts.executeSQL("INSERT INTO tbllogs (datelog, timelog, action, module, performedto, performedby) VALUES ('" +
                        DateTime.Now.ToString("yyyy-MM-dd") + "', '" + DateTime.Now.ToShortTimeString() + "', 'DELETE ACCOUNT', 'ACCOUNTS MANAGEMENT', '" +
                        dataGridView1.Rows[row].Cells[0].Value.ToString() + "', '" +
                        username + "')");

                        MessageBox.Show("Account deleted.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Refresh();
                    }
                }
                catch (Exception error)
                {
                    MessageBox.Show("Error on btndelete click:" + error.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            string editusername = dataGridView1.Rows[row].Cells[0].Value.ToString();
            string editpassword = dataGridView1.Rows[row].Cells[1].Value.ToString();
            string editusertype = dataGridView1.Rows[row].Cells[2].Value.ToString();
            string editstatus = dataGridView1.Rows[row].Cells[3].Value.ToString();
            var updateaccountform = new frmUpdateAccounts(editusername, editpassword, editusertype, editstatus, username);
            updateaccountform.ShowDialog();
        }

        private void RefreshView(object sender, EventArgs e)
        {
            txtsearch.Clear();
            frmAccounts_Load(sender, e);
        }
    }
}
