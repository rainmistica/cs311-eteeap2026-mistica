using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Org.BouncyCastle.Asn1.Cmp;
using ticket_management;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace cs311_eteeap2026_mistica
{
    public partial class frmUpdateEquipment : Form
    {
        private string _assetNumber, _serialNumber, _type, _manufacturer, _yearModel, _description,_department,_status, _username;

        private void txtYearModel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private int errorcount;
        Class1 updateEquipment = new Class1("127.0.0.1", "itc127-eteeap2026-mistica", "root", "");

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public frmUpdateEquipment(string assetNumber, string serialNumber, string type, string manufacturer, string yearModel, string description, string department, string status, string username)
        {
            InitializeComponent();
            _assetNumber = assetNumber;
            _serialNumber = serialNumber;
            _type = type;
            _manufacturer = manufacturer;
            _yearModel = yearModel;
            _description = description;
            _department = department;
            _status = status;
            _username = username;

        }
        private void rbRetired_CheckedChanged(object sender, EventArgs e)
        {
            if (rbRetired.Checked)
            {
                lblSelectedStatus.Text = rbRetired.Text.ToUpper();
            }
        }

        private void rbOnRepair_CheckedChanged(object sender, EventArgs e)
        {
            if (rbOnRepair.Checked)
            {
                lblSelectedStatus.Text = rbOnRepair.Text.ToUpper();
            }
        }

        private void rbWorking_CheckedChanged(object sender, EventArgs e)
        {
            if(rbWorking.Checked)
            {
                lblSelectedStatus.Text = rbWorking.Text.ToUpper();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                errorProvider1.Clear();
                errorcount = 0;

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

                if (string.IsNullOrWhiteSpace(lblSelectedStatus.Text))
                {
                    errorProvider1.SetError(lblSelectedStatus, "No Selected Status.");
                    errorcount++;
                }

                var radioButtons = new[] { rbWorking, rbOnRepair, rbRetired };

                if (!radioButtons.Any(rb => rb.Checked))
                {
                    MessageBox.Show("Please select at least one Status.", "Reminder",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                ValidateDataUniqueness($"SELECT * FROM equipments WHERE serial_number = '{txtSerialNumber.Text}'",
                    lblAssetNumber.Text,
                    txtSerialNumber,
                    "SerialNumber");

                if (errorcount == 0)
                {
                    try
                    {
                        DialogResult dr = MessageBox.Show("Are you sure you want to update this account?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dr == DialogResult.Yes)
                        {
                            string query = String.Format(@"UPDATE equipments SET serial_number = '{0}',type = '{1}', manufacturer = '{2}', year_model = {3}, description = '{4}', department = '{5}',
                            status = '{6}' WHERE asset_number = '{7}'",
                            txtSerialNumber.Text,
                            cmbType.Text,
                            txtManufacturer.Text,
                            txtYearModel.Text,
                            txtDescription.Text,
                            cmbDepartment.Text,
                            lblSelectedStatus.Text,
                            lblAssetNumber.Text);

                            updateEquipment.executeSQL(query);

                            if (updateEquipment.rowAffected > 0)
                            {
                                MessageBox.Show("Account updated.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                updateEquipment.executeSQL("INSERT INTO tbllogs (datelog, timelog, action, module, performedto, performedby) VALUES ('" + DateTime.Now.ToString("yyyy-MM-dd") + "', '" +
                                DateTime.Now.ToShortTimeString() + "', 'UPDATE EQUIPMENT', 'EQUIPMENT MANAGEMENT', '" + _username + "', '" + _username + "')");
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
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void frmUpdateEquipment_Load(object sender, EventArgs e)
        {
            lblAssetNumber.Text = _assetNumber;
            txtSerialNumber.Text = _serialNumber;
            lblType.Text = _type;
            txtManufacturer.Text = _manufacturer;
            txtYearModel.Text = _yearModel;
            txtDescription.Text = _description;
            lblDepartment.Text = _department;
            lblStatus.Text = _status;
        }
        private void ValidateDataUniqueness(string query,string assetNumber, TextBox textbox, string field)
        {
            try
            {
                if (IsDataExisting(query,assetNumber))
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
        private bool IsDataExisting(string query,string assetNumber)
        {
            DataTable dt = updateEquipment.GetData(query);
            if (dt.Rows.Count > 0)
            {
                var assetNum = dt.Rows[0]["asset_number"].ToString();
                if(String.Equals(assetNum, assetNumber,StringComparison.OrdinalIgnoreCase))
                {
                    return false;
                }
                else
                {
                    return true;
                }
                    
            }
            return false;
        }
    }
}
