using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Wms.Mobile.Common;
using Business.Domain.Mobile.Mobile;
using Business.Domain.Mobile.Wms;
using Business.Domain.Mobile.Inventory;

namespace Wms.Mobile.UI.Transfer
{
    public partial class TransferForm_Step1 : Wms.Mobile.UI.TemplateForm
    {
        public List<StockView> LocationStocks { get; set; }

        public List<TransferBillDetailView> TransferBillDetails { get; set; }

        public TransferForm_Step1()
        {
            InitializeComponent();


        }

        public void AbandonTransfer()
        {
            TransferBillDetails = new List<TransferBillDetailView>();
        }

        private void PutawayForm_Step2_Load(object sender, EventArgs e)
        {
            SetTitle("主动移货-扫描");

            TransferBillDetails = new List<TransferBillDetailView>();
        }

        private void CompleteTransfer()
        {
            TransferForm_Step2 form = new TransferForm_Step2();
            form.ModuleForm = this.ModuleForm;
            form.MainForm = this.MainForm;
            form.TransferBillDetails = this.TransferBillDetails;
            this.Hide();
            this.Close();
            form.ShowDialog();
        }

        private void btnContinueScan_Click(object sender, EventArgs e)
        {
            if (ValidateData())
            {
                int rowIndex = gridStock.CurrentRowIndex;
                StockView stock = LocationStocks[rowIndex];
                if (stock == null)
                {
                    lblMessage.Text = "请选择需要移货的库存信息。";
                    gridStock.Focus();
                    return;
                }

                int qty = ParseQty();
                TransferBillDetailView billDetail = new TransferBillDetailView();
                billDetail.BatchNumber = stock.BatchNumber;
                billDetail.IsTransferContainer = true;
                billDetail.PackId = stock.PackId;
                billDetail.PackName = stock.PackName;
                billDetail.PlanQty = 0;
                billDetail.SkuId = stock.SkuId;
                billDetail.SkuName = stock.SkuName;
                billDetail.SkuNumber = stock.SkuNumber;
                billDetail.StockId = stock.StockId;
                billDetail.TransferedQty = qty;
                billDetail.SourceContainerName = stock.ContainerName;
                billDetail.SourceContainerId = stock.ContainerId;
                billDetail.SourceLocationId = stock.LocationId;
                billDetail.SourceLocationName = stock.LocationName;

                LocationInfo targetLocation = ToolKit.GetLocation(txtTargetLocation.Text.Trim());
                if (targetLocation == null)
                {
                    lblMessage.Text = "目标库位信息不正确。";
                    txtTargetLocation.Focus();
                    return;
                }
                else
                {
                    billDetail.TargetLocationId = targetLocation.LocationId;
                    billDetail.TargetLocationCode = targetLocation.LocationCode;
                    billDetail.TargetLocationName = targetLocation.LocationName;
                }

                ContainerInfo targetContainer = ToolKit.GetContainer(txtTargetContainer.Text.Trim());
                if (targetContainer != null)
                {
                    billDetail.TargetContainerId = targetContainer.ContainerId;
                    billDetail.TargetContainerCode = targetContainer.ContainerCode;
                    billDetail.TargetContainerName = targetContainer.ContainerName;
                }


                TransferBillDetails.Add(billDetail);

                ClearForm();
                txtSourceLocation.Focus();
            }
        }

        private int ParseQty()
        {
            int qty = 0;
            try
            {
                qty = Int32.Parse(txtTransferQty.Text.Trim());
            }
            catch
            {
                ;
            }

            return qty;
        }

        private void ClearForm()
        {
            this.txtSourceLocation.Text = string.Empty;
            this.gridStock.DataSource = null;
            this.txtSourceLocation.Text = string.Empty;
            this.txtTargetLocation.Text = string.Empty;
            this.txtTargetContainer.Text = string.Empty;
            
            this.txtTransferQty.Text = string.Empty;
            this.lblMessage.Text = string.Empty;
        }

        private bool ValidateData()
        {
            this.lblMessage.Text = string.Empty;


            //库位条码
            if (txtSourceLocation.Text.Trim() == string.Empty)
            {
                txtSourceLocation.Focus();
                lblMessage.Text = "请扫描原库位条码。";
                return false;
            }

            if (gridStock.DataSource == null)
            {
                txtSourceLocation.Focus();
                lblMessage.Text = "请重新扫描原库位条码。";
                return false;
            }

            if (gridStock.CurrentRowIndex < 0)
            {
                gridStock.Focus();
                lblMessage.Text = "请选择需要移货的库存信息。";
                return false;
            }

            //库位条码
            if (txtTargetLocation.Text.Trim() == string.Empty)
            {
                lblMessage.Text = "请扫描目标库位。";
                return false;
            }
            else
            {
                if (!ToolKit.IsLocationBarcode(txtTargetLocation.Text))
                {
                    lblMessage.Text = "扫描的库位条码不符合规则。";
                    return false;
                }
            }

            if (txtTargetContainer.Text.Trim() != string.Empty)
            {
                if (!ToolKit.IsContainerBarcode(txtTargetContainer.Text.Trim()))
                {
                    this.lblMessage.Text = "扫描的容器条码不符合规则。";
                    txtTargetContainer.Focus();
                    return false;
                }
            }

            if (ParseQty() <= 0)
            {
                this.lblMessage.Text = "请输入正确的数量。";
                txtTransferQty.Focus();
                return false;
            }
            else
            {
                int rowIndex = gridStock.CurrentRowIndex;
                if (rowIndex >= 0 && LocationStocks.Count - 1 >= rowIndex)
                {
                    StockView stock = LocationStocks[rowIndex];

                    int currentQty = ParseQty();
                    if (currentQty > stock.Qty)
                    {
                        this.lblMessage.Text = "移货数量不能超过库存数量，请复核。";
                        txtTransferQty.Focus();
                        return false;
                    }
                }
            }

            return true;
        }

        private void txtTargetLocationBarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
                txtTargetContainer.Focus();
        }

        private void txtTargetContainerBarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
                btnContinue.Focus();
        }

        private void txtTransferedQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Delete)
                    e.Handled = true;
            }
            
            if (e.KeyChar == (char)Keys.Return)
                txtTargetLocation.Focus();
        }

        private void txtSourceLocation_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                // get stocks by location
                string warehouseCode = GlobalState.CurrentWarehouse.WarehouseCode;
                string uri = string.Format("Stock/QueryByLocation/{0}/{1}", warehouseCode, txtSourceLocation.Text.Trim());
                List<StockView> stocks = GlobalState.MyRestService.GetForObject<List<StockView>>(uri);

                if (stocks.Count <= 0)
                    lblMessage.Text = "库存不存在或原库位条码有误。";
                else
                {
                    gridStock.DataSource = null;
                    gridStock.DataSource = stocks;
                    LocationStocks = stocks;
                    SetGridStyle();
                }
                gridStock.Focus();
            }
        }

        private void SetGridStyle()
        {
            DataGridTableStyle style = new DataGridTableStyle();
            gridStock.TableStyles.Clear();
            gridStock.TableStyles.Add(style);

            style.MappingName = gridStock.DataSource.GetType().Name;
            style.GridColumnStyles["LocationName"].HeaderText = "库位";
            style.GridColumnStyles["LocationName"].Width = 80;

            style.GridColumnStyles["ContainerName"].HeaderText = "容器";
            style.GridColumnStyles["ContainerName"].Width = 80;
            style.GridColumnStyles["SkuNumber"].HeaderText = "货物代码";
            style.GridColumnStyles["SkuNumber"].Width = 80;
             style.GridColumnStyles["SkuName"].HeaderText = "货物名称";
            style.GridColumnStyles["SkuName"].Width = 0;
            style.GridColumnStyles["PackName"].HeaderText = "包装";
            style.GridColumnStyles["PackName"].Width = 40;
            style.GridColumnStyles["Qty"].HeaderText = "库存数量";
            style.GridColumnStyles["Qty"].Width = 40;
            style.GridColumnStyles["BatchNumber"].HeaderText = "入库批次";
            style.GridColumnStyles["BatchNumber"].Width = 80;
            style.GridColumnStyles["BillNumber"].HeaderText = "入库单号";
            style.GridColumnStyles["BillNumber"].Width = 80;
            style.GridColumnStyles["InboundDate"].HeaderText = "入库日期";
            style.GridColumnStyles["InboundDate"].Width = 80;

            style.GridColumnStyles["IsValid"].Width = 0;
            style.GridColumnStyles["StockId"].Width = 0;
            style.GridColumnStyles["WarehouseId"].Width = 0;
            style.GridColumnStyles["LocationId"].Width = 0;
            style.GridColumnStyles["ContainerId"].Width = 0;
            style.GridColumnStyles["SkuId"].Width = 0;
            style.GridColumnStyles["PackId"].Width = 0;
            style.GridColumnStyles["AreaId"].Width = 0;
            style.GridColumnStyles["AreaType"].Width = 0;
            style.GridColumnStyles["PlanNumber"].Width = 0;
            style.GridColumnStyles["ProductionDate"].Width = 0;
            style.GridColumnStyles["ExpiringDate"].Width = 0;
            style.GridColumnStyles["ProductionBatch"].Width = 0;
            style.GridColumnStyles["ManufacturingOrigin"].Width = 0;
            style.GridColumnStyles["PropertyValue1"].Width = 0;
            style.GridColumnStyles["PropertyValue2"].Width = 0;
            style.GridColumnStyles["PropertyValue3"].Width = 0;
            style.GridColumnStyles["PropertyValue4"].Width = 0;
            style.GridColumnStyles["PropertyValue5"].Width = 0;
            style.GridColumnStyles["PropertyValue6"].Width = 0;
        }

        private void btnComplete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("全部货物是否移货完成？", "问题", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dialogResult == DialogResult.No) return;
            
            CompleteTransfer();
        }
    }
}

