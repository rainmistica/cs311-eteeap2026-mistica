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
    public partial class frmLogs : Form
    {
        private readonly string _username;
        Class1 logs = new Class1("127.0.0.1", "itc127-eteeap2026-mistica", "root", "");
        public frmLogs(string username)
        {
            InitializeComponent();
            _username = username;
        }

        private void frmLogs_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = logs.GetData("SELECT datelog,timelog,performedby,action,module FROM tbllogs ORDER BY created_at DESC");
                dataGridView1.DataSource = dt;
            }
            catch (Exception error)
            {
                MessageBox.Show("Error on frmLogs_Load:" + error.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure you want to delete all logs?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    logs.executeSQL("DELETE FROM tbllogs");

                    if (logs.rowAffected > 0)
                    {
                        logs.executeSQL("INSERT INTO tbllogs (datelog, timelog, action, module, performedto, performedby) VALUES ('" + DateTime.Now.ToString("yyyy-MM-dd") + "', '" +
                            DateTime.Now.ToShortTimeString() + "', 'DELETE ALL LOGS', 'LOGS MANAGEMENT', 'LOGS', '" + _username + "')");

                        MessageBox.Show("Logs deleted.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        frmLogs_Load(sender, e);
                    }
                }
                catch (Exception error)
                {
                    MessageBox.Show("Error on btndelete click:" + error.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
