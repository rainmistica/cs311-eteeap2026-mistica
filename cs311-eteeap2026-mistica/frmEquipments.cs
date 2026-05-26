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
        private string username,userType;
        private int row;
        public frmEquipments(string username,string userType)
        {
            InitializeComponent();
            this.username = username;
            this.userType = userType;
        }
        Class1 equipment = new Class1("127.0.0.1", "itc127-eteeap2026-mistica", "root", "");
        private void frmEquipments_Load(object sender, EventArgs e)
        {

            try
            {
                FilterUserView(userType);
                DataTable dt = equipment.GetData("SELECT * FROM equipments ORDER BY asset_number");
                dataGridView1.DataSource = dt;
            }
            catch (Exception error)
            {
                MessageBox.Show("Error on frmEquipments_Load:" + error.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            var addEquipmentForm = new frmAddEquipment(username);
            addEquipmentForm.ShowDialog();
        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            RefreshView(sender, e);
        }
        private void RefreshView(object sender, EventArgs e)
        {
            txtsearch.Clear();
            frmEquipments_Load(sender, e);
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            string assetNumber = dataGridView1.Rows[row].Cells[0].Value.ToString();
            string serialNumber = dataGridView1.Rows[row].Cells[1].Value.ToString();
            string type = dataGridView1.Rows[row].Cells[2].Value.ToString();
            string manufacturer = dataGridView1.Rows[row].Cells[3].Value.ToString();
            string yearModel = dataGridView1.Rows[row].Cells[4].Value.ToString();
            string description = dataGridView1.Rows[row].Cells[5].Value.ToString();
            string department = dataGridView1.Rows[row].Cells[6].Value.ToString();
            string status = dataGridView1.Rows[row].Cells[7].Value.ToString();

            var updateEquipmentForm = new frmUpdateEquipment(assetNumber, serialNumber, type, manufacturer, yearModel, description, department, status, username);
            updateEquipmentForm.ShowDialog();
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
            DialogResult dr = MessageBox.Show("Are you sure you want to delete this equipment?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    equipment.executeSQL("DELETE FROM equipments WHERE asset_number = '" + dataGridView1.Rows[row].Cells[0].Value.ToString() + "'");

                    if (equipment.rowAffected > 0)
                    {
                        equipment.executeSQL("INSERT INTO tbllogs (datelog, timelog, action, module, performedto, performedby) VALUES ('" + DateTime.Now.ToString("yyyy-MM-dd") + "', '" +
                            DateTime.Now.ToShortTimeString() + "', 'DELETE EQUIPMENT', 'EQUIPMENT MANAGEMENT', '" + dataGridView1.Rows[row].Cells[0].Value.ToString() + "', '" + username + "')");

                        MessageBox.Show("Equipment deleted.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RefreshView(sender, e);
                    }
                }
                catch (Exception error)
                {
                    MessageBox.Show("Error on btndelete click:" + error.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            try
            {
                string query = String.Format(@"SELECT * from equipments WHERE asset_number LIKE '%{0}%' OR serial_number LIKE '%{0}%' OR type LIKE '%{0}%' OR department LIKE '%{0}%' ORDER BY asset_number",
                    txtsearch.Text);


                DataTable dt = equipment.GetData(query);
                dataGridView1.DataSource = dt;
            }
            catch (Exception error)
            {
                MessageBox.Show("Error on btnsearch_click:" + error.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FilterUserView(string userType)
        {
            if (userType.Equals("USER"))
            {
                btnadd.Enabled = false;
                btnupdate.Enabled = false;
                btndelete.Enabled = false;
            }
            else
            {
                btnadd.Enabled = true;
                btnupdate.Enabled = true;
                btndelete.Enabled = true;
            }
        }
    }
}
