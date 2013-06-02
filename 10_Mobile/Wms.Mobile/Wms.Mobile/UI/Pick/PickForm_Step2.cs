using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Business.Domain.Mobile.Mobile;
using Wms.Mobile.Common;
using Business.Domain.Mobile.Inventory;

namespace Wms.Mobile.UI.Pick
{
    public partial class PickForm_Step2 : Wms.Mobile.UI.TemplateForm
    {
        public PickTask CurrentTask { get; set; }

        public PickTaskResult CurrentTaskResult { get; set; }

        public List<PickingStock> PickingStocks { get; set; }

        public PickForm_Step2()
        {
            InitializeComponent();
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            if (ValidateData())
            {
                int qty = ParseQty();

                string batchNumber = txtBatchNumber.Text.Trim();
                string pickLocationBarcode = txtPickLocationBarcode.Text.Trim();
                int pickLocationId = GetLocationID(txtPickLocationBarcode.Text.Trim());
                int pickStockId = GetStockID(txtPickLocationBarcode.Text.Trim());
                string pickContainerBarcode = txtPickContainerBarcode.Text.Trim();
                string skuNumber = FindSkuNumber(txtPickSkuBarcode.Text.Trim());
                //string pickTask = txtPickTask.Text.Trim();

                PickTaskDetail taskDetail = FindSkuInTaskDetail(txtPickSkuBarcode.Text.Trim(), txtPickContainerBarcode.Text.Trim(), batchNumber);
                PickTaskResultDetail resultDetail = FindSkuInTaskResultDetail(skuNumber, batchNumber, pickLocationBarcode, pickContainerBarcode);

                if (resultDetail != null)
                {
                    resultDetail.ReceivedQty = resultDetail.ReceivedQty + qty;
                }
                else
                {
                    resultDetail = new PickTaskResultDetail();
                    resultDetail.SkuNumber = skuNumber;
                    resultDetail.BatchNumber = batchNumber;
                    resultDetail.IsPieceManagement = taskDetail.IsPieceManagement;
                    resultDetail.PackName = taskDetail.PackName;
                    resultDetail.ReceivedQty = qty;
                    resultDetail.LocationId = pickLocationId;
                    resultDetail.ContainerBarcode = pickContainerBarcode;
                    resultDetail.LocationBarcode = pickLocationBarcode;
                    //resultDetail.PickTask = pickTask;
                    resultDetail.BatchNumber = batchNumber;
                    resultDetail.StockId = pickStockId;

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

        private void PickForm_Step2_Load(object sender, EventArgs e)
        {
            SetTitle("拣货-扫描拣货");
        }

        private void txtPickTask_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
                txtPickLocationBarcode.Focus();
        }

        private void txtPickLocationBarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char) Keys.Return)
            {
                if (this.cbPickRecommend.Text.Trim() != this.txtPickLocationBarcode.Text.Trim())
                {
                    MessageBox.Show("前一个批次未出货！");
                    this.txtPickLocationBarcode.Text = String.Empty;
                }
                else
                {
                    txtPickContainerBarcode.Focus();
                }
            }
        }

        private void txtPickContainerBarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
                txtPickQty.Focus();
        }

        private void txtPickQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
                txtBatchNumber.Focus();
        }

        private void txtPickSkuBarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            // get recommended pick locations
            string warehouseCode = CurrentTask.WarehouseCode;
            var locstions = new List<string>();
            var putawaylocations = new List<PickingStock>();
            if (e.KeyChar == (char)Keys.Enter)
            {
                try
                {
                    bool dSku = false;
                    foreach (PickTaskDetail ds in CurrentTask.Details)
                    {
                        if (ds.SkuNumber.ToString() == txtPickSkuBarcode.Text.Trim())
                        {
                            dSku = true;
                        }
                    }

                    if (!dSku)
                    {
                        txtPickSkuBarcode.Text = String.Empty;
                        MessageBox.Show("该货物不在此拣货单中！");

                        if (e.KeyChar == (char)Keys.Return)
                            txtPickSkuBarcode.Focus();
                    }
                    else
                    {
                        if (txtPickSkuBarcode.Text.Trim() != "")
                        {
                            string uri = string.Format("Pick/{0}/{1}/GetStocks/{2}", warehouseCode, 0, txtPickSkuBarcode.Text.Trim());
                            var tasks = GlobalState.MyRestService.GetForObject<List<PickingStock>>(uri);
                            PickingStocks = tasks;
                            foreach (PickingStock task in tasks)
                            {
                                locstions.Add(task.LocationCode);
                            }

                            foreach (PickTaskResultDetail ptrd in CurrentTaskResult.Details)
                            {
                                foreach (PickingStock task in tasks)
                                {
                                    if (task.LocationBarcode == ptrd.LocationBarcode)
                                    {
                                        if (task.StockQty == ptrd.ReceivedQty)
                                        {
                                            locstions.Remove(ptrd.LocationBarcode);
                                        }
                                    }
                                }
                            }

                            cbPickRecommend.DataSource = locstions;
                        }

                        if (e.KeyChar == (char)Keys.Return)
                            txtPickLocationBarcode.Focus();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private int ParseQty()
        {
            int qty = 0;
            try
            {
                qty = Int32.Parse(txtPickQty.Text.Trim());
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

            //货物条码
            if (txtPickSkuBarcode.Text.Trim() == string.Empty)
            {
                lblMessage.Text = "请扫描出库货物条码。";
                return false;
            }
            else
            {
                if (!ToolKit.IsSkuBarcode(txtPickSkuBarcode.Text))
                {
                    lblMessage.Text = "扫描的货物条码不符合规则。";
                    return false;
                }
                else
                {
                    string barcode = txtPickSkuBarcode.Text.Trim();
                    PickTaskDetail taskDetail = FindSkuInTaskDetail(barcode, txtPickContainerBarcode.Text.Trim(), "");
                    if (taskDetail == null)
                    {
                        this.lblMessage.Text = "扫描的货物不存在于任务明细中。";
                        return false;
                    }
                }
            }

            //库位条码
            if (txtPickLocationBarcode.Text.Trim() == string.Empty)
            {
                lblMessage.Text = "请扫描出库库位。";
                return false;
            }
            else
            {
                if (!ToolKit.IsLocationBarcode(txtPickLocationBarcode.Text))
                {
                    lblMessage.Text = "扫描的库位条码不符合规则。";
                    return false;
                }
            }

            if (GetLocationID(txtPickLocationBarcode.Text.Trim()) == 0)
            {
                lblMessage.Text = "出库库位不存在。";
                return false;
            }

            

            if (txtPickContainerBarcode.Text.Trim() != string.Empty)
            {
                if (!ToolKit.IsContainerBarcode(txtPickContainerBarcode.Text.Trim()))
                {
                    this.lblMessage.Text = "扫描的容器条码不符合规则。";
                    txtPickContainerBarcode.Focus();
                    return false;
                }
            }

            if (ParseQty() <= 0)
            {
                this.lblMessage.Text = "请输入正确的数量。";
                txtPickQty.Focus();
                return false;
            }
            else
            {
                string barcode = txtPickSkuBarcode.Text.Trim();
                PickTaskDetail taskDetail = FindSkuInTaskDetail(barcode, txtPickContainerBarcode.Text.Trim(), "");
                int transferedQty = CalcPickQty(taskDetail.SkuNumber, txtPickContainerBarcode.Text.Trim(), "");
                int currentQty = ParseQty();
                if (currentQty + transferedQty > GetStockNumber(txtPickSkuBarcode.Text.Trim()))
                {
                    this.lblMessage.Text = "出库数量超过库存数量，请复核。";
                    txtPickQty.Focus();
                    return false;
                }
            }

            //if (!GetBatchNumber(cbPickRecommend.SelectedItem.ToString(), txtBatchNumber.Text.Trim()))
            //{
            //    MessageBox.Show("批次不一致，是否使用！","提示",MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
            //    if (MessageBoxButtons.OKCancel != MessageBoxButtons.OK)
            //    {
            //        txtBatchNumber.Text = string.Empty;
            //        txtBatchNumber.Focus();
            //        return false;
            //    }
            //}

            return true;
        }

        private PickTaskDetail FindSkuInTaskDetail(string skuBarcode, string sourceContainerBarcode, string batchNumber)
        {
            foreach (var detail in CurrentTask.Details)
            {
                if (detail.Barcode == skuBarcode || detail.UPC == skuBarcode)
                {
                    return detail;
                }
            }

            return null;
        }

        private int CalcPickQty(string skuNumber, string sourceContainerBarcode, string batchNumber)
        {
            int qty = 0;
            foreach (var detail in CurrentTaskResult.Details)
            {
                if (detail.SkuNumber == skuNumber && detail.ContainerBarcode == sourceContainerBarcode && detail.BatchNumber == batchNumber)
                    qty = qty + detail.ReceivedQty;
            }
            return qty;
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

        private PickTaskResultDetail FindSkuInTaskResultDetail(string skuNumber, string batchNumber, string locationBarocode, string containerBarcode)
        {
            foreach (var detail in CurrentTaskResult.Details)
            {
                if (detail.SkuNumber == skuNumber && detail.BatchNumber == batchNumber && detail.ContainerBarcode == containerBarcode && detail.LocationBarcode == locationBarocode)
                    return detail;
            }

            return null;
        }

        //private bool IsPutawayComplete()
        //{
        //    int taskQty = 0;
        //    int transferedQty = 0;
        //    //foreach (var detail in CurrentTask.Details)
        //    taskQty = GetStockNumber(txtPickSkuBarcode.Text.Trim());//taskQty + detail.Qty;
        //    foreach (var detail in CurrentTaskResult.Details)
        //        transferedQty = transferedQty + detail.ReceivedQty;

        //    if (taskQty >= transferedQty)
        //        return true;

        //    return false;
        //}

        private bool IsPutawayComplete()
        {
            int taskQty = 0;
            int transferedQty = 0;
            //int itaskQty = 0;
            foreach (var detail in CurrentTask.Details)
            taskQty = taskQty + detail.Qty;
            foreach (var detail in CurrentTaskResult.Details)
                transferedQty = transferedQty + detail.ReceivedQty;

            //itaskQty = GetStockNumber(txtPickSkuBarcode.Text.Trim());
            //if (itaskQty == transferedQty)
            //{
            //    string warehouseCode = CurrentTask.WarehouseCode;
            //    var locations = new List<string>();
            //    string uri = string.Format("Pick/{0}/{1}/GetStocks/{2}", warehouseCode, 0, txtPickSkuBarcode.Text.Trim());
            //    var tasks = GlobalState.MyRestService.GetForObject<List<PickingStock>>(uri);
            //    PickingStocks = tasks;
            //    foreach (PickingStock task in tasks)
            //    {
            //        locations.Add(task.LocationCode);
            //    }

            //    foreach (PickTaskResultDetail ptrd in CurrentTaskResult.Details)
            //    {
            //        locations.Remove(ptrd.LocationBarcode);
            //    }

            //    cbPickRecommend.DataSource = locations;

            //}
                

            if (taskQty <= transferedQty)
                return true;

            return false;
        }

        private void ClearForm()
        {
            this.txtPickContainerBarcode.Text = string.Empty;
            this.txtPickSkuBarcode.Text = string.Empty;
            this.txtPickLocationBarcode.Text = string.Empty;
            this.txtPickQty.Text = string.Empty;
            //this.txtPickTask.Text = string.Empty;
            this.lblMessage.Text = string.Empty;
            this.txtBatchNumber.Text = String.Empty;
            this.cbPickRecommend.DataSource = null;
            this.lblPickRecommendMessage.Text = String.Empty;
            this.txtPickSkuBarcode.Focus();
        }

        private void CompletePutaway()
        {
            PickForm_Step3 form = new PickForm_Step3();
            form.ModuleForm = this.ModuleForm;
            form.CurrentTask = this.CurrentTask;
            form.CurrentTaskResult = this.CurrentTaskResult;
            this.Hide();
            this.Close();
            form.ShowDialog();
        }

        private void txtPickTask_TextChanged(object sender, EventArgs e)
        {
            //lblPickTaskCount.Text = (20 - txtPickTask.Text.Length).ToString() + "/20";
        }

        private void cbPickRecommend_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblPickRecommendMessage.Text = GetRecommendLocationInformation((string)cbPickRecommend.SelectedItem);
        }

        private string GetRecommendLocationInformation(string LocationCode)
        {
            foreach (PickingStock ps in PickingStocks)
            {
                if (ps.LocationCode == LocationCode)
                {
                    if (ps.LocationName == null)
                        ps.LocationName = "";

                    if (ps.ContainerCode == null)
                        ps.ContainerCode = "";

                    if (ps.BatchNumber == null)
                        ps.BatchNumber = "";

                    return ps.LocationCode.ToString() + " / " + ps.ContainerCode.ToString() + "/" + ps.BatchNumber.ToString() + " / " + ps.StockQty.ToString();
                    break;
                }
            }

            return "";
        }

        private int GetLocationID(string LocationCode)
        {
            foreach (PickingStock ps in PickingStocks)
            {
                if (ps.LocationCode == LocationCode)
                {
                    return ps.LocationId;
                    break;
                }
            }
            return 0;
        }

        private int GetStockID(string LocationCode)
        {
            foreach (PickingStock ps in PickingStocks)
            {
                if (ps.LocationCode == LocationCode)
                {
                    return ps.StockId;
                    break;
                }
            }
            return 0;
        }

        private bool GetBatchNumber(string LocationCode, string BatchNumber)
        {
            foreach (PickingStock ps in PickingStocks)
            {
                if (ps.LocationCode == LocationCode)
                {
                    if (ps.BatchNumber == BatchNumber)
                    {
                        return true;
                    }
                    break;
                }
            }
            return false;
        }

        private int GetStockNumber(string SkuBarcode)
        {
            int skuqty = 0;
            foreach (PickingStock ps in PickingStocks)
            {
                if (ps.SkuBarcode == SkuBarcode)
                {
                    skuqty += ps.StockQty;
                }
            }

            return skuqty;
        }

        private void txtBatchNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (!GetBatchNumber(txtPickLocationBarcode.Text.Trim(), txtBatchNumber.Text.Trim()))
                {
                    MessageBox.Show("批次不一致，请扫描正确的批次！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                    if (MessageBoxButtons.OK == MessageBoxButtons.OK)
                    {
                        txtBatchNumber.Text = string.Empty;
                        txtBatchNumber.Focus();
                    }
                }
            }

            if (e.KeyChar == (char)Keys.Return)
                btnContinue.Focus();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            //PickForm_Step1 PF1 = new PickForm_Step1();
            //PF1.ModuleForm = this.ModuleForm;
            //PF1.Show();
            //this.Close();
            if (ModuleForm != null)
            {
                this.Close();
                ((PickForm_Step1)ModuleForm).AbandonPutaway();
                ModuleForm.Show();
            }
        }
    }
}

