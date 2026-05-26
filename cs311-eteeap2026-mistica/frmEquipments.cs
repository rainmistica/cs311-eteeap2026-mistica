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
    public partial class frmEquipments : Form
    {
        private string username;
        private int row;
        public frmEquipments(string username)
        {
            InitializeComponent();
            this.username = username;
        }
        Class1 accounts = new Class1("127.0.0.1", "itc127-eteeap2026-mistica", "root", "");
        private void frmEquipments_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = accounts.GetData("SELECT * FROM equipments ORDER BY asset_number");
                dataGridView1.DataSource = dt;
            }
            catch (Exception error)
            {
                MessageBox.Show("Error on frmEquipments_Load:" + error.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
