using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google.Protobuf.WellKnownTypes;
using Mysqlx;
using ticket_management;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace cs311_eteeap2026_mistica
{
    public partial class frmAddEquipment : Form
    {
        private readonly string _username;
        private int errorcount;
        Class1 addEquipment = new Class1("127.0.0.1", "itc127-eteeap2026-mistica", "root", "");
        public frmAddEquipment(string username)
        {
            InitializeComponent();
            _username = username;
        }

        private void frmAddEquipment_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                errorProvider1.Clear();
                errorcount = 0;

                if(string.IsNullOrWhiteSpace(txtAssetNumber.Text))
                {
                    errorProvider1.SetError(txtAssetNumber, "Asset number is empty.");
                    errorcount++;
                }
                if (string.IsNullOrWhiteSpace(txtSerialNumber.Text))
                {
                    errorProvider1.SetError(txtSerialNumber, "Serial number is empty.");
                    errorcount++;
                }
                if (cmbType.SelectedIndex < 0)
                {
                    errorProvider1.SetError(cmbType, "Select a Type.");
                    errorcount++;
                }
                if (string.IsNullOrWhiteSpace(txtManufacturer.Text))
                {
                    errorProvider1.SetError(txtManufacturer, "Manufacturer is empty.");
                    errorcount++;
                }
                if (string.IsNullOrWhiteSpace(txtYearModel.Text))
                {
                    errorProvider1.SetError(txtYearModel, "Year Model is empty.");
                    errorcount++;
                }
                if (cmbDepartment.SelectedIndex < 0)
                {
                    errorProvider1.SetError(cmbDepartment, "Select a Department.");
                    errorcount++;
                }

                //validate AssetNumber
                ValidateDataUniqueness($"SELECT * FROM equipments WHERE asset_number = '{txtAssetNumber.Text}'",
                    txtAssetNumber,"AssetNumber");

                //validate SerialNumber

                ValidateDataUniqueness($"SELECT * FROM equipments WHERE serial_number = '{txtSerialNumber.Text}'",
                    txtSerialNumber, "SerialNumber");

                //create account
                if (errorcount == 0)
                {
                    DialogResult dr = MessageBox.Show("Are you sure you want to create this equipment?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (dr == DialogResult.Yes)
                    {
                        var query = String.Format(@"INSERT INTO equipments (asset_number,serial_number,type,manufacturer,year_model,description,department,status,created_by,date_created)
                        VALUES ('{0}','{1}','{2}','{3}',{4},'{5}','{6}','WORKING','{7}',NOW())",
                        txtAssetNumber.Text,
                        txtSerialNumber.Text,
                        cmbType.Text,
                        txtManufacturer.Text,
                        txtYearModel.Text,
                        txtDescription.Text,
                        cmbDepartment.Text,
                        _username);

                        addEquipment.executeSQL(query);

                        if (addEquipment.rowAffected > 0)
                        {
                            MessageBox.Show("New equipment added.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error on btnSave_Click:" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       
        private void txtYearModel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        
        private void ValidateDataUniqueness(string query,TextBox textbox,string field)
        {
            try
            {
                if(IsDataExisting(query))
                {
                    errorProvider1.SetError(textbox, $"{field} is already in use.");
                    errorcount++;
                }
            }
            catch (Exception error)
            {
                MessageBox.Show($"Error on validating {field}:" + error.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //Helper methods
        private bool IsDataExisting(string query)
        {
            DataTable dt = addEquipment.GetData(query);
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
