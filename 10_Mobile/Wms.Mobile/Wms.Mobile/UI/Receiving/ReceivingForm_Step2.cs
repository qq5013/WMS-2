using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Wms.Mobile.Common;
using Business.Domain.Mobile.Mobile;

namespace Wms.Mobile.UI.Receiving
{
    public partial class ReceivingForm_Step2 : TemplateForm
    {
        public ReceivingTask CurrentTask { get; set; }

        public ReceivingTaskResult CurrentTaskResult { get; set; }

        public ReceivingForm_Step2()
        {
            InitializeComponent();
        }

        private void ReceivingForm_Step2_Load(object sender, EventArgs e)
        {
            SetTitle("收货-收货信息记录");

            dpArrivalTime.Value = DateTime.Now;
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            if (ValidateReceivingInformation())
            {
                this.CurrentTaskResult.ArrivalTime = dpArrivalTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
                DateTime now = ToolKit.GetServerTime();
                if (now == DateTime.MinValue)
                    this.CurrentTaskResult.ReceiveTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                else
                    this.CurrentTaskResult.ReceiveTime = now.ToString("yyyy-MM-dd HH:mm:ss");

                this.CurrentTaskResult.DeliveryMan = txtDeliveryMan.Text.Trim();
                this.CurrentTaskResult.Vehicle = txtVehicle.Text.Trim();
                this.CurrentTaskResult.LocationBarcode = txtReceivingLocation.Text.Trim();


                ReceivingForm_Step3 form = new ReceivingForm_Step3();
                form.ModuleForm = this.ModuleForm;
                form.CurrentTask = this.CurrentTask;
                form.CurrentTaskResult = this.CurrentTaskResult;
                this.Hide();
                this.Close();
                form.ShowDialog();
            }
        }

        private bool ValidateReceivingInformation()
        {
            if (txtReceivingLocation.Text == string.Empty)
            {
                lblMessage.Text = "请扫描收货库位。";
                return false;
            }
            else
            {
                if (!ToolKit.IsLocationBarcode(txtReceivingLocation.Text))
                {
                    lblMessage.Text = "扫描的库位条码不符合规则。";
                    return false;
                }
                if (txtReceivingLocation.Text.Substring(0, 1) != "R")
                {
                    lblMessage.Text = "扫描的库位条码不符合规则。";
                    txtReceivingLocation.Text = String.Empty;
                    txtReceivingLocation.Focus();
                    return false;
                }
            }

            return true;
        }

        private void dpArrivalTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
                txtDeliveryMan.Focus();
        }

        private void txtDeliveryMan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
                txtVehicle.Focus();
        }

        private void txtVehicle_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
                txtReceivingLocation.Focus();
        }

        private void txtReceivingLocation_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
                btnContinue.Focus();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            //ReceivingForm_Step1 RF1 = new ReceivingForm_Step1();
            //RF1.ModuleForm = this.ModuleForm;
            //RF1.Show();
            //this.Close();
            if (ModuleForm != null)
            {
                this.Close();
                ((ReceivingForm_Step1)ModuleForm).AbandonReciving();
                ModuleForm.Show();
            }
        }
    }
}