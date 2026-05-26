using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using K4os.Compression.LZ4.Streams;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace cs311_eteeap2026_mistica
{
    public partial class frmMain : Form
    {
        private readonly string _username, _usertype;
        public frmMain(string username, string usertype)
        {
            InitializeComponent();
            _username = username;
            _usertype = usertype;
        }

        private void accountsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var accountsform = new frmAccounts(_username);
            accountsform.ShowDialog();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure you want to logout?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                var loginform = new frmLogin();
                loginform.ShowDialog();
                this.Close();
            }
        }

        private void equipmentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var equipmentForm = new frmEquipments(_username,_usertype);
            equipmentForm.ShowDialog();
        }

        private void logsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var logsForm = new frmLogs(_username);
            logsForm.ShowDialog();
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
            "CS311-ETEEAP2026-MISTICA",
            "About",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Username:" + _username;
            toolStripStatusLabel2.Text = "Usertype:" + _usertype;
            if (_usertype == "ADMINISTRATOR")
            {
                accountsToolStripMenuItem.Visible = true;
                equipmentsToolStripMenuItem.Visible = true;
            }
            else
            {
                accountsToolStripMenuItem.Visible = false;
                equipmentsToolStripMenuItem.Visible = true;
            }
        }
    }
}
