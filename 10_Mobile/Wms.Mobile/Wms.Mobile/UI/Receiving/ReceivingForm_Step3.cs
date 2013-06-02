using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Business.Domain.Mobile.Mobile;
using Wms.Mobile.Common;

namespace Wms.Mobile.UI.Receiving
{
    public partial class ReceivingForm_Step3 : TemplateForm
    {
        public ReceivingTask CurrentTask { get; set; }

        public ReceivingTaskResult CurrentTaskResult { get; set; }

        public ReceivingForm_Step3()
        {
            InitializeComponent();
        }

        private void ReceivingForm_Step3_Load(object sender, EventArgs e)
        {
            SetTitle("收货-扫描货物");
        }

        private void ClearForm()
        {
            this.txtBarcode.Text = string.Empty;
            this.txtBatchNumber.Text = string.Empty;
            this.txtQty.Text = string.Empty;
            txtContainerBarcode.Text = string.Empty;
            this.txtBarcode.Focus();
        }

        private int ParseQty()
        {
            int qty = 0;
            try
            {
                qty = Int32.Parse(txtQty.Text.Trim());
            }
            catch
            {
                ;
            }

            return qty;
        }

        private bool ValidateData()
        {
            this.lblMessage.Text = string.Empty;

            if (txtBarcode.Text.Trim() == string.Empty)
            {
                this.lblMessage.Text = "请扫描货物条码或UPC码。";
                txtBarcode.Focus();
                return false;
            }

            if (txtBatchNumber.Text.Trim() == string.Empty)
            {
                this.lblMessage.Text = "请扫描货物入库批次号。";
                txtBatchNumber.Focus();
                return false;
            }

            if (ParseQty() <= 0)
            {
                this.lblMessage.Text = "请输入正确的数量。";
                txtQty.Focus();
                return false;
            }

            if (txtContainerBarcode.Text.Trim() != string.Empty)
            {
                if (!ToolKit.IsContainerBarcode(txtContainerBarcode.Text.Trim()))
                {
                    this.lblMessage.Text = "扫描的容器条码不符合规则。";
                    txtContainerBarcode.Focus();
                    return false;
                }
            }

            string barcode = txtBarcode.Text.Trim();
            ReceivingTaskDetail taskDetail = FindSkuInTaskDetail(barcode);
            if (taskDetail == null)
            {
                this.lblMessage.Text = "扫描的货物不存在于任务明细中。";
                txtBarcode.Focus();
                return false;
            }
            else
            {
                int receivedQty = CalcReceivedQty(taskDetail.SkuNumber);
                int currentQty = ParseQty();
                if (currentQty + receivedQty > taskDetail.Qty)
                {
                    this.lblMessage.Text = "收货数量超过待收货数量，请复核。";
                    txtQty.Focus();
                    return false;
                }
            }

            return true;
        }

        private int CalcReceivedQty(string skuNumber)
        {
            int qty = 0;
            foreach (var detail in CurrentTaskResult.Details)
                if (detail.SkuNumber == skuNumber)
                    qty = qty + detail.ReceivedQty;

            return qty;
        }

        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Delete)
                    e.Handled = true;
            }

            if (e.KeyChar == (char)Keys.Return)
                txtContainerBarcode.Focus();
        }

        private ReceivingTaskDetail FindSkuInTaskDetail(string barcode)
        {
            foreach (var detail in CurrentTask.Details)
            {
                if (detail.Barcode == barcode || detail.UPC == barcode)
                    return detail;
            }

            return null;
        }

        private ReceivingTaskResultDetail FindSkuInTaskResultDetail(string skuNumber,string batchNumber, string containerBarcode)
        {
            foreach (var detail in CurrentTaskResult.Details)
            {
                if (detail.SkuNumber == skuNumber && detail.BatchNumber == batchNumber && detail.ContainerBarcode == containerBarcode)
                    return detail;
            }

            return null;
        }

        private bool IsReceivingComplete()
        {
            int taskQty = 0;
            int receivedQty = 0;
            foreach (var detail in CurrentTask.Details)
                taskQty = taskQty + detail.Qty;
            foreach (var detail in CurrentTaskResult.Details)
                receivedQty = receivedQty + detail.ReceivedQty;

            if (taskQty == receivedQty)
                return true;

            return false;
        }

        private void btnContinueScan_Click(object sender, EventArgs e)
        {
            if (ValidateData())
            {
                int qty = ParseQty();

                string barcode = txtBarcode.Text.Trim();
                string batchNumber = txtBatchNumber.Text.Trim();
                string containerBarcode = txtContainerBarcode.Text.Trim();
                ReceivingTaskDetail taskDetail = FindSkuInTaskDetail(barcode);
                ReceivingTaskResultDetail resultDetail = FindSkuInTaskResultDetail(taskDetail.SkuNumber,batchNumber, containerBarcode);

                if (resultDetail != null)
                {
                    resultDetail.ReceivedQty = resultDetail.ReceivedQty + qty;
                }
                else
                {
                    resultDetail = new ReceivingTaskResultDetail();
                    resultDetail.SkuNumber = taskDetail.SkuNumber;
                    resultDetail.BatchNumber = txtBatchNumber.Text.Trim();
                    resultDetail.IsPieceManagement = taskDetail.IsPieceManagement;
                    resultDetail.PackName = taskDetail.PackName;
                    resultDetail.ContainerBarcode = containerBarcode;
                    //resultDetail.SerialNumbers = new List<string>();
                    resultDetail.ReceivedQty = qty;
                    CurrentTaskResult.Details.Add(resultDetail);
                }

                if (!IsReceivingComplete())
                {
                    ClearForm();
                }
                else
                {
                    // goto task complete form
                    btnComplete_Click(null, null);
                }
            }
        }

        private void btnComplete_Click(object sender, EventArgs e)
        {
            ReceivingForm_Step4 form = new ReceivingForm_Step4();
            form.ModuleForm = this.ModuleForm;
            form.CurrentTask = this.CurrentTask;
            form.CurrentTaskResult = this.CurrentTaskResult;
            this.Hide();
            this.Close();
            form.ShowDialog();
        }

        private void txtBarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
                txtBatchNumber.Focus();
        }

        private void txtBatchNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
                txtQty.Focus();
        }

        private void txtContainerBarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
                btnContinueScan.Focus();
        }

    }
}