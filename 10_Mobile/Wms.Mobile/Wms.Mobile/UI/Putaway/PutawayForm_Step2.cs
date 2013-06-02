using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Wms.Mobile.Common;
using Business.Domain.Mobile.Mobile;

namespace Wms.Mobile.UI.Putaway
{
    public partial class PutawayForm_Step2 : Wms.Mobile.UI.TemplateForm
    {
        public PutawayTask CurrentTask { get; set; }

        public PutawayTaskResult CurrentTaskResult { get; set; }

        public List<PutawayLocation> PutawayLocations { get; set; }

        public PutawayForm_Step2()
        {
            InitializeComponent();
        }

        private void PutawayForm_Step2_Load(object sender, EventArgs e)
        {
            SetTitle("上架-扫描上架");
        }

        //private void btnContinue_Click(object sender, EventArgs e)
        //{
        //    if (ValidatePutawayInformation())
        //    {

        //        this.CurrentTaskResult.LocationBarcode = txtTargetLocationBarcode.Text.Trim();
        //        this.CurrentTaskResult.SkuNumber = txtSkuBarcode.Text.Trim();

        //        PutawayForm_Step3 form = new PutawayForm_Step3();
        //        form.ModuleForm = this.ModuleForm;
        //        form.CurrentTask = this.CurrentTask;
        //        form.CurrentTaskResult = this.CurrentTaskResult;
        //        this.Hide();
        //        this.Close();
        //        form.ShowDialog();
        //    }
        //}

        //private bool ValidatePutawayInformation()
        //{
            
        //}

        private void txtSkuBarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            // get recommended sku locations
            string warehouseCode = CurrentTask.WarehouseCode;
            var locstions = new List<string>();
            var putawaylocations = new List<PutawayLocation>();
            if (e.KeyChar == (char)Keys.Enter)
            {
                try
                {
                    if (txtSkuBarcode.Text.Trim() != "")
                    {
                        string uri = string.Format("Putaway/{0}/{1}/GetLocations?barcode={2}&qty={3}", warehouseCode, "TagPutawayStrategy", txtSkuBarcode.Text.Trim(), 0);
                        var tasks = GlobalState.MyRestService.GetForObject<List<PutawayLocation>>(uri);
                        PutawayLocations = tasks;
                        foreach (PutawayLocation task in tasks)
                        {
                            locstions.Add(task.LocationCode);
                        }

                        cbLocationNumber.DataSource = locstions;
                    }
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            if (e.KeyChar == (char)Keys.Return)
                txtBatchNumber.Focus();
        }

        private PutawayTaskDetail FindSkuInTaskDetail(string skuBarcode, string sourceContainerBarcode, string batchNumber)
        {
            foreach (var detail in CurrentTask.Details)
            {
                if (detail.Barcode == skuBarcode || detail.UPC == skuBarcode)
                {
                    if (detail.ContainerBarcode == sourceContainerBarcode && detail.BatchNumber == batchNumber)
                        return detail;
                }
            }

            return null;
        }

        private string FindSkuNumber(string barcode)
        {
            foreach (var detail in CurrentTask.Details)
            {
                if (detail.Barcode == barcode || detail.UPC == barcode)
                {
                    return detail.SkuNumber;
                }
            }

            return null;
        }

        private void CompletePutaway()
        {
            PutawayForm_Step3 form = new PutawayForm_Step3();
            form.ModuleForm = this.ModuleForm;
            form.CurrentTask = this.CurrentTask;
            form.CurrentTaskResult = this.CurrentTaskResult;
            this.Hide();
            this.Close();
            form.ShowDialog();
        }

        private void btnContinueScan_Click(object sender, EventArgs e)
        {
            if (ValidateData())
            {
                int qty = ParseQty();

                string batchNumber = txtBatchNumber.Text.Trim();
                string targetLocationBarcode = txtTargetLocationBarcode.Text.Trim();
                string sourceContainerBarcode = txtSourceContainerBarcode.Text.Trim();
                string targetContainerBarcode = txtTargetContainerBarcode.Text.Trim();
                string skuNumber = FindSkuNumber(txtSkuBarcode.Text.Trim());

                PutawayTaskDetail taskDetail = FindSkuInTaskDetail(txtSkuBarcode.Text.Trim(), txtSourceContainerBarcode.Text.Trim(), txtBatchNumber.Text.Trim());
                PutawayTaskResultDetail resultDetail = FindSkuInTaskResultDetail(skuNumber, batchNumber, targetLocationBarcode, targetContainerBarcode);

                if (resultDetail != null)
                {
                    resultDetail.TransferedQty = resultDetail.TransferedQty + qty;
                }
                else
                {
                    resultDetail = new PutawayTaskResultDetail();
                    resultDetail.SkuNumber = skuNumber;
                    resultDetail.BatchNumber = batchNumber;
                    resultDetail.IsPieceManagement = taskDetail.IsPieceManagement;
                    resultDetail.IsTransferContainer = false;
                    resultDetail.PackName = taskDetail.PackName;
                    resultDetail.TransferedQty = qty;
                    resultDetail.SourceLocationBarcode = string.Empty;
                    resultDetail.TargetLocationBarcode = targetLocationBarcode;
                    resultDetail.SourceContainerBarcode = sourceContainerBarcode;
                    resultDetail.TargetContainerBarcode = targetContainerBarcode;
                    
                    CurrentTaskResult.Details.Add(resultDetail);
                }

                if (!IsPutawayComplete())
                {
                    ClearForm();
                }
                else
                {
                    CompletePutaway();
                }
            }
        }

        private void txtSourceContainerBarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
                txtSkuBarcode.Focus();
        }

        private void txtBatchNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
                cbLocationNumber.Focus();
        }

        private void cblblLocationNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbllblLLocationNumber.Text = GetRecommendLocationInformation((string)cbLocationNumber.SelectedItem);
        }

        private int ParseQty()
        {
            int qty = 0;
            try
            {
                qty = Int32.Parse(txtTransferedQty.Text.Trim());
            }
            catch
            {
                ;
            }

            return qty;
        }

        private int CalcTransferedQty(string skuNumber, string sourceContainerBarcode, string batchNumber)
        {
            int qty = 0;
            foreach (var detail in CurrentTaskResult.Details)
            {
                if (detail.SkuNumber == skuNumber && detail.SourceContainerBarcode == sourceContainerBarcode && detail.BatchNumber == batchNumber)
                    qty = qty + detail.TransferedQty;
            }
            return qty;
        }

        private PutawayTaskResultDetail FindSkuInTaskResultDetail(string skuNumber, string batchNumber, string locationBarocode, string containerBarcode)
        {
            foreach (var detail in CurrentTaskResult.Details)
            {
                if (detail.SkuNumber == skuNumber && detail.BatchNumber == batchNumber && detail.TargetContainerBarcode == containerBarcode && detail.TargetLocationBarcode == locationBarocode)
                    return detail;
            }

            return null;
        }

        private bool IsPutawayComplete()
        {
            int taskQty = 0;
            int transferedQty = 0;
            foreach (var detail in CurrentTask.Details)
                taskQty = taskQty + detail.Qty;
            foreach (var detail in CurrentTaskResult.Details)
                transferedQty = transferedQty + detail.TransferedQty;

            if (taskQty == transferedQty)
                return true;

            return false;
        }

        private void ClearForm()
        {
            txtSourceContainerBarcode.Text = string.Empty;
            txtSkuBarcode.Text = string.Empty;
            this.txtBatchNumber.Text = string.Empty;

            this.cbLocationNumber.DataSource = null;
            this.cbLocationNumber.Text = string.Empty;
            this.txtTargetLocationBarcode.Text = string.Empty;
            this.txtTargetContainerBarcode.Text = string.Empty;
            
            this.txtTransferedQty.Text = string.Empty;
            this.lblMessage.Text = string.Empty;
        }

        private bool ValidateData()
        {
            this.lblMessage.Text = string.Empty;

            //货物条码
            if (txtSkuBarcode.Text.Trim() == string.Empty)
            {
                lblMessage.Text = "请扫描上架货物条码。";
                return false;
            }
            else
            {
                if (!ToolKit.IsSkuBarcode(txtSkuBarcode.Text))
                {
                    lblMessage.Text = "扫描的货物条码不符合规则。";
                    return false;
                }
                else
                {
                    string barcode = txtSkuBarcode.Text.Trim();
                    PutawayTaskDetail taskDetail = FindSkuInTaskDetail(barcode, txtSourceContainerBarcode.Text.Trim(), txtBatchNumber.Text.Trim());
                    if (taskDetail == null)
                    {
                        this.lblMessage.Text = "扫描的货物不存在于任务明细中。";
                        return false;
                    }
                }
            }

            //库位条码
            if (txtTargetLocationBarcode.Text.Trim() == string.Empty)
            {
                lblMessage.Text = "请扫描上架库位。";
                return false;
            }
            else
            {
                if (!ToolKit.IsLocationBarcode(txtTargetLocationBarcode.Text))
                {
                    lblMessage.Text = "扫描的库位条码不符合规则。";
                    return false;
                }
            }

            if (txtTargetContainerBarcode.Text.Trim() != string.Empty)
            {
                if (!ToolKit.IsContainerBarcode(txtTargetContainerBarcode.Text.Trim()))
                {
                    this.lblMessage.Text = "扫描的容器条码不符合规则。";
                    txtTargetContainerBarcode.Focus();
                    return false;
                }
            }

            if (ParseQty() <= 0)
            {
                this.lblMessage.Text = "请输入正确的数量。";
                txtTransferedQty.Focus();
                return false;
            }
            else
            {
                string barcode = txtSkuBarcode.Text.Trim();
                PutawayTaskDetail taskDetail = FindSkuInTaskDetail(barcode, txtSourceContainerBarcode.Text.Trim(), txtBatchNumber.Text.Trim());
                int transferedQty = CalcTransferedQty(taskDetail.SkuNumber, txtSourceContainerBarcode.Text.Trim(), txtBatchNumber.Text.Trim());
                int currentQty = ParseQty();
                if (currentQty + transferedQty > taskDetail.Qty)
                {
                    this.lblMessage.Text = "上架数量超过待上架数量，请复核。";
                    txtTransferedQty.Focus();
                    return false;
                }
            }

            return true;
        }

        private string GetRecommendLocationInformation(string LocationCode)
        {
            foreach (PutawayLocation pl in PutawayLocations)
            {
                if (pl.LocationCode == LocationCode)
                {
                    return pl.LocationName + " / " + pl.SkuStockQty.ToString() + " / " + pl.OtherStockQty.ToString();
                }
            }

            return "";
        }

        private void cbLocationNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
                txtTargetLocationBarcode.Focus();
        }

        private void txtTargetLocationBarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
                txtTargetContainerBarcode.Focus();
        }

        private void txtTargetContainerBarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
                txtTransferedQty.Focus();
        }

        private void txtTransferedQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
                btnContinueScan.Focus();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            //PutawayForm_Step1 PF1 = new PutawayForm_Step1();
            //PF1.ModuleForm = this.ModuleForm;
            //PF1.Show();
            //this.Close();
            if (ModuleForm != null)
            {
                this.Close();
                ((PutawayForm_Step1)ModuleForm).AbandonPutaway();
                ModuleForm.Show();
            }
        }
    }
}

