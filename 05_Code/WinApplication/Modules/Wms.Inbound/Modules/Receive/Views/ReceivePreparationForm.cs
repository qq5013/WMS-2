using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Framework.UI.Template.Others;
using Microsoft.Practices.CompositeUI.SmartParts;
using Business.Domain.Inventory;
using Business.Domain.Inventory.Views;
using Wms.Common;
using Framework.UI.Template.Common;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Grid;
using Business.Domain.Wms;
using System.ServiceModel;
using Business.Common.Exception;
using Framework.Core.Encryption;
using Modules.ReceiveModule.Barcode;
using Wms.Common.Device;

namespace Modules.ReceiveModule.Views
{
    [SmartPart]
    public partial class ReceivePreparationForm : CustomForm
    {
        public InboundPlan CurrentInboundPlan;

        public List<InboundPlanDetailView> PlanDetails;

        public List<ReceivingPreparationDetail> ReceivingDetails;

        //public ReceivingTaskResult _receivingResult;

        public ReceivingPreparationDetail BatchViewCurrentReceivingDetail;

        public ReceivingPreparationDetail BarcodeViewCurrentReceivingDetail;

        public ReceivePreparationForm()
        {
            InitializeComponent();
            InitPrinters();

            InitReceivingTask();

            deArrivalTime.DateTime = DateTime.Now;
            deArrivalTime.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }

        private void InitPrinters()
        {
            List<string> printers = LocalPrinter.GetLocalPrinters();
            if (printers.Count <= 0)
            {
                FormHelper.ShowErrorDialog("初始化打印机信息失败，请检查打印机联接后重试。");
                return;
            }

            cbPrinters.Properties.Items.Clear();
            foreach (string printerName in printers)
                cbPrinters.Properties.Items.Add(printerName);

            cbPrinters.SelectedIndex = 0;
        }

        private void InitReceivingTask()
        {
            List<string> tasks = ServiceHelper.InboundService.GetReceivingTasks(GlobalState.CurrentWarehouse.WarehouseCode);
            cbInboundPlan.Properties.Items.Clear();
            foreach (var task in tasks)
                cbInboundPlan.Properties.Items.Add(task);
        }

        private void bePlanId_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        public void CustomizePlanDetailGrid()
        {
            int comlumnIndex = 0;

            FormHelper.SetGridColumn(PlanView, "Id", "", 100, comlumnIndex++, false);
            FormHelper.SetGridColumn(PlanView, "PlanId", "入库计划编号", 100, comlumnIndex++, false);
            FormHelper.SetGridColumn(PlanView, "SkuId", "", 100, comlumnIndex++, false);
            FormHelper.SetGridColumn(PlanView, "SkuNumber", "货物代码", 100, comlumnIndex++, true);
            FormHelper.SetGridColumn(PlanView, "SkuName", "货物名称", 150, comlumnIndex++, true);
            FormHelper.SetGridColumn(PlanView, "PackId", "", 100, comlumnIndex++, false);
            FormHelper.SetGridColumn(PlanView, "PackName", "包装", 100, comlumnIndex++, true);
            FormHelper.SetGridColumn(PlanView, "Qty", "计划数量", 100, comlumnIndex++, true);
            FormHelper.SetGridColumn(PlanView, "ReceivedQty", "已入库数量", 100, comlumnIndex++, true);
            FormHelper.SetGridColumn(PlanView, "PackVolume", "包装体积", 100, comlumnIndex++, true);
            FormHelper.SetGridColumn(PlanView, "PackWeight", "包装重量", 100, comlumnIndex++, true);
            FormHelper.SetGridColumn(PlanView, "IsValid", "", 100, comlumnIndex++, false);

            PlanView.OptionsView.ColumnAutoWidth = true;
        }

        public void CustomizeReceivingDetailGrid()
        {
            int comlumnIndex = 0;

            FormHelper.SetGridColumn(ReceivingView, "Id", "", 100, comlumnIndex++, false);
            FormHelper.SetGridColumn(ReceivingView, "PlanId", "入库计划编号", 100, comlumnIndex++, false);
            FormHelper.SetGridColumn(ReceivingView, "SkuId", "", 100, comlumnIndex++, false);
            FormHelper.SetGridColumn(ReceivingView, "ReceivingQty", "实收数量", 100, comlumnIndex++, true);
            FormHelper.SetGridColumn(ReceivingView, "Qty", "计划数量", 100, comlumnIndex++, true);
            FormHelper.SetGridColumn(ReceivingView, "ReceivedQty", "已入库数量", 100, comlumnIndex++, true);
            FormHelper.SetGridColumn(ReceivingView, "SkuNumber", "货物代码", 100, comlumnIndex++, true);
            FormHelper.SetGridColumn(ReceivingView, "SkuName", "货物名称", 150, comlumnIndex++, true);
            FormHelper.SetGridColumn(ReceivingView, "PackId", "", 100, comlumnIndex++, false);
            FormHelper.SetGridColumn(ReceivingView, "PackName", "包装", 100, comlumnIndex++, true);
            FormHelper.SetGridColumn(ReceivingView, "PackVolume", "包装体积", 100, comlumnIndex++, false);
            FormHelper.SetGridColumn(ReceivingView, "PackWeight", "包装重量", 100, comlumnIndex++, false);
            FormHelper.SetGridColumn(ReceivingView, "IsValid", "", 100, comlumnIndex++, false);
            FormHelper.SetGridColumn(ReceivingView, "IsBatchManagement", "是否批次管理", 100, comlumnIndex++, true);
            FormHelper.SetGridColumn(ReceivingView, "IsBarcodeManagement", "是否条码管理", 100, comlumnIndex++, true);
            FormHelper.SetGridColumn(ReceivingView, "IsPieceManagement", "是否单件管理", 100, comlumnIndex++, true);

            ReceivingView.OptionsView.ColumnAutoWidth = true;

            //ReceivingView.Columns["Id"].ReadOnly = true;
            //ReceivingView.Columns["PlanId"].ReadOnly = true;
            //ReceivingView.Columns["SkuId"].ReadOnly = true;
            //ReceivingView.Columns["Qty"].ReadOnly = true;
            //ReceivingView.Columns["ReceivedQty"].ReadOnly = true;
            //ReceivingView.Columns["SkuNumber"].ReadOnly = true;
            //ReceivingView.Columns["SkuName"].ReadOnly = true;
            //ReceivingView.Columns["PackId"].ReadOnly = true;
            //ReceivingView.Columns["PackName"].ReadOnly = true;
            //ReceivingView.Columns["PackVolume"].ReadOnly = true;
            //ReceivingView.Columns["PackWeight"].ReadOnly = true;
            //ReceivingView.Columns["IsValid"].ReadOnly = true;
        }

        public void CustomizeBatchDetailGrid()
        {
            int comlumnIndex = 0;

            FormHelper.SetGridColumn(BatchView, "Id", "", 100, comlumnIndex++, false);
            FormHelper.SetGridColumn(BatchView, "PlanId", "入库计划编号", 100, comlumnIndex++, false);
            FormHelper.SetGridColumn(BatchView, "SkuId", "", 100, comlumnIndex++, false);
            FormHelper.SetGridColumn(BatchView, "ReceivingQty", "实收数量", 100, comlumnIndex++, true);
            FormHelper.SetGridColumn(BatchView, "Qty", "计划数量", 100, comlumnIndex++, true);
            FormHelper.SetGridColumn(BatchView, "ReceivedQty", "已入库数量", 100, comlumnIndex++, true);
            FormHelper.SetGridColumn(BatchView, "SkuNumber", "货物代码", 100, comlumnIndex++, true);
            FormHelper.SetGridColumn(BatchView, "SkuName", "货物名称", 150, comlumnIndex++, true);
            FormHelper.SetGridColumn(BatchView, "PackId", "", 100, comlumnIndex++, false);
            FormHelper.SetGridColumn(BatchView, "PackName", "包装", 100, comlumnIndex++, true);
            FormHelper.SetGridColumn(BatchView, "PackVolume", "包装体积", 100, comlumnIndex++, false);
            FormHelper.SetGridColumn(BatchView, "PackWeight", "包装重量", 100, comlumnIndex++, false);
            FormHelper.SetGridColumn(BatchView, "IsValid", "", 100, comlumnIndex++, false);
            FormHelper.SetGridColumn(BatchView, "IsBatchManagement", "是否批次管理", 100, comlumnIndex++, true);
            FormHelper.SetGridColumn(BatchView, "IsBarcodeManagement", "是否条码管理", 100, comlumnIndex++, true);
            FormHelper.SetGridColumn(BatchView, "IsPieceManagement", "是否单件管理", 100, comlumnIndex++, true);

            BatchView.OptionsView.ColumnAutoWidth = true;
        }

        public void CustomizeBarcodeGrid()
        {
            int comlumnIndex = 0;

            FormHelper.SetGridColumn(BarcodeView, "Id", "", 100, comlumnIndex++, false);
            FormHelper.SetGridColumn(BarcodeView, "PlanId", "入库计划编号", 100, comlumnIndex++, false);
            FormHelper.SetGridColumn(BarcodeView, "SkuId", "", 100, comlumnIndex++, false);
            FormHelper.SetGridColumn(BarcodeView, "ReceivingQty", "实收数量", 100, comlumnIndex++, true);
            FormHelper.SetGridColumn(BarcodeView, "Qty", "计划数量", 100, comlumnIndex++, true);
            FormHelper.SetGridColumn(BarcodeView, "ReceivedQty", "已入库数量", 100, comlumnIndex++, true);
            FormHelper.SetGridColumn(BarcodeView, "SkuNumber", "货物代码", 100, comlumnIndex++, true);
            FormHelper.SetGridColumn(BarcodeView, "SkuName", "货物名称", 150, comlumnIndex++, true);
            FormHelper.SetGridColumn(BarcodeView, "PackId", "", 100, comlumnIndex++, false);
            FormHelper.SetGridColumn(BarcodeView, "PackName", "包装", 100, comlumnIndex++, true);
            FormHelper.SetGridColumn(BarcodeView, "PackVolume", "包装体积", 100, comlumnIndex++, false);
            FormHelper.SetGridColumn(BarcodeView, "PackWeight", "包装重量", 100, comlumnIndex++, false);
            FormHelper.SetGridColumn(BarcodeView, "IsValid", "", 100, comlumnIndex++, false);
            FormHelper.SetGridColumn(BarcodeView, "IsBatchManagement", "是否批次管理", 100, comlumnIndex++, true);
            FormHelper.SetGridColumn(BarcodeView, "IsBarcodeManagement", "是否条码管理", 100, comlumnIndex++, true);
            FormHelper.SetGridColumn(BarcodeView, "IsPieceManagement", "是否单件管理", 100, comlumnIndex++, true);

            BarcodeView.OptionsView.ColumnAutoWidth = true;
        }

        public void CustomizeInboundBatchGrid()
        {
            int comlumnIndex = 0;

            FormHelper.SetGridColumn(BatchDetailView, "Id", "", 100, comlumnIndex++, false);
            FormHelper.SetGridColumn(BatchDetailView, "WarehouseId", "", 100, comlumnIndex++, false);
            FormHelper.SetGridColumn(BatchDetailView, "PlanNumber", "", 100, comlumnIndex++, false);
            FormHelper.SetGridColumn(BatchDetailView, "BillNumber", "", 100, comlumnIndex++, false);
            FormHelper.SetGridColumn(BatchDetailView, "BatchNumber", "入库批次号", 100, comlumnIndex++, true);
            FormHelper.SetGridColumn(BatchDetailView, "InboundDate", "入库日期", 100, comlumnIndex++, true);
            FormHelper.SetGridColumn(BatchDetailView, "SkuId", "", 100, comlumnIndex++, false);
            FormHelper.SetGridColumn(BatchDetailView, "ProductionDate", "生产日期", 100, comlumnIndex++, true);
            FormHelper.SetGridColumn(BatchDetailView, "ExpiringDate", "过期日期", 100, comlumnIndex++, true);
            FormHelper.SetGridColumn(BatchDetailView, "ProductionBatch", "制造商批号", 100, comlumnIndex++, true);
            FormHelper.SetGridColumn(BatchDetailView, "Qty", "批次数量", 150, comlumnIndex++, true);
            FormHelper.SetGridColumn(BatchDetailView, "ManufacturingOrigin", "", 100, comlumnIndex++, false);
            FormHelper.SetGridColumn(BatchDetailView, "PropertyValue1", "", 100, comlumnIndex++, false);
            FormHelper.SetGridColumn(BatchDetailView, "PropertyValue2", "", 100, comlumnIndex++, false);
            FormHelper.SetGridColumn(BatchDetailView, "PropertyValue3", "", 100, comlumnIndex++, false);
            FormHelper.SetGridColumn(BatchDetailView, "PropertyValue4", "", 100, comlumnIndex++, false);
            FormHelper.SetGridColumn(BatchDetailView, "PropertyValue5", "", 100, comlumnIndex++, false);
            FormHelper.SetGridColumn(BatchDetailView, "PropertyValue6", "", 100, comlumnIndex++, false);
            FormHelper.SetGridColumn(BatchDetailView, "CreateUser", "", 100, comlumnIndex++, false);
            FormHelper.SetGridColumn(BatchDetailView, "CreateTime", "", 100, comlumnIndex++, false);
            FormHelper.SetGridColumn(BatchDetailView, "IsValid", "", 100, comlumnIndex++, false);

            BatchDetailView.OptionsView.ColumnAutoWidth = true;
        }

        public void CustomizeBarcodeViewBatchGrid(GridView view)
        {
            int comlumnIndex = 0;

            FormHelper.SetGridColumn(view, "Id", "", 100, comlumnIndex++, false);
            FormHelper.SetGridColumn(view, "WarehouseId", "", 100, comlumnIndex++, false);
            FormHelper.SetGridColumn(view, "PlanNumber", "", 100, comlumnIndex++, false);
            FormHelper.SetGridColumn(view, "BillNumber", "", 100, comlumnIndex++, false);
            FormHelper.SetGridColumn(view, "BatchNumber", "入库批次号", 100, comlumnIndex++, true);
            FormHelper.SetGridColumn(view, "InboundDate", "入库日期", 100, comlumnIndex++, true);
            FormHelper.SetGridColumn(view, "SkuId", "", 100, comlumnIndex++, false);
            FormHelper.SetGridColumn(view, "ProductionDate", "生产日期", 100, comlumnIndex++, true);
            FormHelper.SetGridColumn(view, "ExpiringDate", "过期日期", 100, comlumnIndex++, true);
            FormHelper.SetGridColumn(view, "ProductionBatch", "制造商批号", 100, comlumnIndex++, true);
            FormHelper.SetGridColumn(view, "Qty", "批次数量", 150, comlumnIndex++, true);
            FormHelper.SetGridColumn(view, "ManufacturingOrigin", "", 100, comlumnIndex++, false);
            FormHelper.SetGridColumn(view, "PropertyValue1", "", 100, comlumnIndex++, false);
            FormHelper.SetGridColumn(view, "PropertyValue2", "", 100, comlumnIndex++, false);
            FormHelper.SetGridColumn(view, "PropertyValue3", "", 100, comlumnIndex++, false);
            FormHelper.SetGridColumn(view, "PropertyValue4", "", 100, comlumnIndex++, false);
            FormHelper.SetGridColumn(view, "PropertyValue5", "", 100, comlumnIndex++, false);
            FormHelper.SetGridColumn(view, "PropertyValue6", "", 100, comlumnIndex++, false);
            FormHelper.SetGridColumn(view, "CreateUser", "", 100, comlumnIndex++, false);
            FormHelper.SetGridColumn(view, "CreateTime", "", 100, comlumnIndex++, false);
            FormHelper.SetGridColumn(view, "IsValid", "", 100, comlumnIndex++, false);

            view.OptionsView.ColumnAutoWidth = true;
        }


        private void cbInboundPlan_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            string planNumber = cbInboundPlan.Text.Trim();
            InboundPlan plan = ServiceHelper.InboundService.GetInboundPlanByNumber(GlobalState.CurrentWarehouse.WarehouseCode, planNumber);
            if (plan == null)
            {
                FormHelper.ShowWarningDialog(string.Format("入库计划号{0}不存在，请重新输入入库计划号。", planNumber));
                return;
            }
            else
            {
                // load details;
                CurrentInboundPlan = plan;
                List<InboundPlanDetailView> details = ServiceHelper.InboundService.GetInboundPlanDetailView(plan.PlanId);
                if (details.Count <= 0)
                {
                    FormHelper.ShowWarningDialog(string.Format("入库计划号{0}无明细信息，请重新输入入库计划号。", planNumber));
                    return;
                }
                else
                {
                    PlanDetails = details;
                    grdPlanDetail.DataSource = null;
                    grdPlanDetail.DataSource = details;
                    CustomizePlanDetailGrid();
                }
                cbInboundPlan.Enabled = false;
                btnSelect.Enabled = false;
            }
        }

        private void cbInboundPlan_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == ButtonPredefines.Redo)
            {
                InitReceivingTask();
            }
        }

        private int GetTotalReceivingQty()
        {
            int totalQty = 0;
            foreach (var detail in ReceivingDetails)
            {
                totalQty = totalQty + detail.ReceivingQty;
            }

            return totalQty;
        }

        private void wizReceivePreparation_NextClick(object sender, DevExpress.XtraWizard.WizardCommandButtonClickEventArgs e)
        {
            if (wizReceivePreparation.SelectedPage == pageRecordDeliveryInformation)
            {
                if (CurrentInboundPlan == null)
                {
                    FormHelper.ShowWarningDialog("请选择入库计划。");
                    e.Handled = true;
                    return;
                }

                RecordReceivingInformation();
                BindReceivingDetails();
            }
            else
                if (wizReceivePreparation.SelectedPage == pageRecordReceiveQty)
                {
                    if (GetTotalReceivingQty() <= 0)
                    {
                        FormHelper.ShowWarningDialog("请填写货物实收数量。");
                        e.Handled = true;
                        return;
                    }
                    BindBatchDetails();
                }
                else
                    if (wizReceivePreparation.SelectedPage == pageBatch)
                    {
                        if (!ValidateBatch())
                        {
                            FormHelper.ShowWarningDialog("批次信息尚未创建完毕，或批次数量不符合实收数量。");
                            e.Handled = true;
                            return;
                        }
                        BindBarcodeDetails();
                    }

        }

        private bool ValidateBatch()
        {
            List<ReceivingPreparationDetail> details = (List<ReceivingPreparationDetail>)grdBatch.DataSource;
            foreach (ReceivingPreparationDetail item in details)
            {
                int receivingQty = item.ReceivingQty;
                int totalBatchQty = 0;
                foreach (ReceivingInboundBatch batch in item.Batchs)
                    totalBatchQty = totalBatchQty + batch.Qty;

                if (receivingQty != totalBatchQty)
                    return false;
            }

            return true;
        }

        private void BindReceivingDetails()
        {
            grdReceivingDetail.DataSource = null;
            if (ReceivingDetails != null)
                grdReceivingDetail.DataSource = ReceivingDetails;

            CustomizeReceivingDetailGrid();
        }

        private void BindBatchDetails()
        {
            grdBatch.DataSource = null;
            if (ReceivingDetails != null)
            {
                List<ReceivingPreparationDetail> batchDetails = new List<ReceivingPreparationDetail>();
                foreach (var detail in ReceivingDetails)
                {
                    if (detail.ReceivingQty > 0 && detail.IsBatchManagement)
                    {
                       batchDetails.Add(detail);
                    }
                }

                grdBatch.DataSource = batchDetails;
            }

            CustomizeBatchDetailGrid();
        }

        private void BindBarcodeDetails()
        {
            grdBarcode.DataSource = null;
            if (ReceivingDetails != null)
            {
                List<ReceivingPreparationDetail> batchDetails = new List<ReceivingPreparationDetail>();
                foreach (var detail in ReceivingDetails)
                {
                    if (detail.ReceivingQty > 0 && detail.IsBarcodeManagement)
                    {
                        batchDetails.Add(detail);
                    }
                }

                grdBarcode.DataSource = batchDetails;
            }

            CustomizeBarcodeGrid();
        }

        private void RecordReceivingInformation()
        {
            //if (_receivingResult == null)
            //    _receivingResult = new ReceivingTaskResult();

            //_receivingResult.ArrivalTime = deArrivalTime.DateTime.ToString("yyyy-MM-dd HH:mm:ss");
            //_receivingResult.DeliveryMan = txtDeliveryMan.Text.Trim();
            //_receivingResult.Vehicle = txtVehicle.Text.Trim();

            if (ReceivingDetails == null)
            {
                ReceivingDetails = new List<ReceivingPreparationDetail>();

                foreach (var planDetail in PlanDetails)
                {
                    ReceivingPreparationDetail receivingDetail = new ReceivingPreparationDetail();
                    receivingDetail.Batchs = new List<ReceivingInboundBatch>();
                    receivingDetail.PackId = planDetail.PackId;
                    receivingDetail.PackName = planDetail.PackName;
                    receivingDetail.PackVolume = planDetail.PackVolume;
                    receivingDetail.PackWeight = planDetail.PackWeight;
                    receivingDetail.PlanId = planDetail.PlanId;
                    receivingDetail.Qty = planDetail.Qty;
                    receivingDetail.ReceivedQty = planDetail.ReceivedQty;
                    receivingDetail.ReceivingQty = 0;
                    receivingDetail.SkuId = planDetail.SkuId;
                    receivingDetail.SkuName = planDetail.SkuName;
                    receivingDetail.SkuNumber = planDetail.SkuNumber;

                    SkuManagement management = ServiceHelper.SkuService.GetSkuManagementMode(planDetail.SkuId);
                    if (management != null)
                    {
                        receivingDetail.IsBarcodeManagement = management.BarcodeManagement;
                        receivingDetail.IsBatchManagement = management.BatchManagement;
                        receivingDetail.IsPieceManagement = management.PieceManagement;
                    }

                    ReceivingDetails.Add(receivingDetail);
                }
            }
        }

        private void BatchView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            ClearBatchInformation();

            ReceivingPreparationDetail currentDetail = (ReceivingPreparationDetail)BatchView.GetRow(BatchView.FocusedRowHandle);
            if (currentDetail != null) 
            {
                BatchViewCurrentReceivingDetail = currentDetail;
                int skuId = currentDetail.SkuId;
                List<BatchProperty> properties =  ServiceHelper.SkuService.GetBatchProperties(skuId);

                deProductionDate.Enabled = true;
                deProductionDate.DateTime = DateTime.Now;
                foreach (var property in properties)
                {
                    if (property.PropertyCode.ToUpper() == "PRODUCTIONDATE")
                        deProductionDate.Enabled = true;

                    if (property.PropertyCode.ToUpper() == "EXPIRATIONDATE")
                        deEffectiveDate.Enabled = true;

                    if (property.PropertyCode.ToUpper() == "LOTNUMBER")
                        txtProductionBatch.Enabled = true;
                }

                BindInboundBatch();
            }
        }

        private void BindInboundBatch()
        {
            grdBatchDetail.DataSource = null;
            grdBatchDetail.DataSource = BatchViewCurrentReceivingDetail.Batchs;

            CustomizeInboundBatchGrid();
        }

        private void ClearBatchInformation()
        {
            deProductionDate.Text = string.Empty;
            deInboundDate.DateTime = DateTime.Now;
            deInboundDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            deEffectiveDate.Text = string.Empty;
            txtProductionBatch.Text = string.Empty;
            seBatchQty.Value = 0;
            seBatchLabelQty.Value = 0;

            deProductionDate.Enabled = false;
            deInboundDate.Enabled = false;
            deEffectiveDate.Enabled = false;
            txtProductionBatch.Enabled = false;
        }

        private void ReceivingView_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column.FieldName == "ReceivingQty")
            {
                e.Appearance.ForeColor = Color.Blue;
                
                if ((int)e.CellValue >= 0)
                {
                    object data = this.ReceivingView.GetRow(e.RowHandle);
                    if (data != null)
                    {
                        ReceivingPreparationDetail detail = data as ReceivingPreparationDetail;
                        if ((int)e.CellValue >= (detail.Qty - detail.ReceivedQty))
                        {
                            //e.Appearance.ForeColor = Color.Red;
                            //e.CellValue = detail.Qty - detail.ReceivedQty;
                            detail.ReceivingQty = detail.Qty - detail.ReceivedQty;
                            e.Appearance.ForeColor = Color.Green;
                        }
                    }
                }
            }
        }

        private void btnCreateBatch_Click(object sender, EventArgs e)
        {
            if (IsOverReceivingQty())
            {
                FormHelper.ShowWarningDialog("批次数量不能超过实收数量。");
                return;
            }

            if (BatchViewCurrentReceivingDetail != null)
            {
                ReceivingInboundBatch batch = new ReceivingInboundBatch();
                batch.Qty = (int)seBatchQty.Value;
                batch.BatchNumber = ServiceHelper.InboundService.GetNewBatchNumber(GlobalState.CurrentWarehouse.WarehouseCode);
                batch.BillNumber = "";
                batch.CreateUser = GlobalState.CurrentUser.UserId;
                batch.CreateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                if (deEffectiveDate.Enabled)
                    batch.ExpiringDate = deEffectiveDate.DateTime.ToString("yyyy-MM-dd");
                batch.InboundDate = deInboundDate.DateTime.ToString("yyyy-MM-dd");
                batch.PlanNumber = CurrentInboundPlan.PlanNumber;
                if (txtProductionBatch.Enabled)
                    batch.ProductionBatch = txtProductionBatch.Text.Trim();
                if (deProductionDate.Enabled)
                    batch.ProductionDate = deProductionDate.DateTime.ToString("yyyy-MM-dd");
                batch.SkuId = BatchViewCurrentReceivingDetail.SkuId;
                batch.WarehouseId = CurrentInboundPlan.WarehouseId;

                BatchViewCurrentReceivingDetail.Batchs.Add(batch);

                BindInboundBatch();
            }
        }

        private bool IsOverReceivingQty()
        {
            if (BatchViewCurrentReceivingDetail != null)
            {
                int receivingQty = BatchViewCurrentReceivingDetail.ReceivingQty;
                int totalQty = 0;
                foreach (var batch in BatchViewCurrentReceivingDetail.Batchs)
                {
                    totalQty = totalQty + batch.Qty;
                }

                if (totalQty > receivingQty)
                {
                    return false;
                }
            }

            return false;
        }

        private void btnDeleteBatch_Click(object sender, EventArgs e)
        {
            ReceivingInboundBatch batch = (ReceivingInboundBatch)BatchDetailView.GetRow(BatchDetailView.FocusedRowHandle);
            if (batch != null)
            {
                BatchViewCurrentReceivingDetail.Batchs.Remove(batch);
                BindInboundBatch();
            }
        }


        private void ClearSkuInformation()
        {
            txtUpc.Text = string.Empty;
            seGuranteePeriodDay.Value = 0;
            seGuranteePeriodMonth.Value = 0;
            seGuranteePeriodYear.Value = 0;
            seLength.Value = 0;
            seWidth.Value = 0;
            seHeight.Value = 0;
            seWeight.Value = 0;
        }

        private void ReceivingView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            ReceivingPreparationDetail currentDetail = (ReceivingPreparationDetail)ReceivingView.GetRow(ReceivingView.FocusedRowHandle);
            if (currentDetail != null)
            {
                ClearSkuInformation();
                int skuId = currentDetail.SkuId;
                InitImages(skuId);
                
                Sku sku = ServiceHelper.SkuService.GetSkuView(skuId);
                txtUpc.Text = sku.Upc;
                seGuranteePeriodDay.Value = sku.GuranteePeriodDay;
                seGuranteePeriodMonth.Value = sku.GuranteePeriodMonth;
                seGuranteePeriodYear.Value = sku.GuranteePeriodYear;

                List<Pack> packs = ServiceHelper.SkuService.GetPacks(skuId);
                foreach (Pack pack in packs)
                {
                    if (pack.PackId == currentDetail.PackId)
                    {
                        seLength.Value = pack.Length;
                        seWidth.Value = pack.Width;
                        seHeight.Value = pack.Height;
                        seWeight.Value = pack.Weight;
                    }
                }
            }
        }

        private void BarcodeView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //
        }

        private void BarcodeView_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            ReceivingPreparationDetail currentDetail = (ReceivingPreparationDetail)BarcodeView.GetRow(BarcodeView.FocusedRowHandle);
            if (currentDetail != null)
            {
                BarcodeViewCurrentReceivingDetail = currentDetail;

                txtBarcode.Text = string.Empty;
                txtStartSN.Text = string.Empty;
                txtEndSN.Text = string.Empty;
                cbBatch.Text = string.Empty;
                sePrintLabelQty.Value = 0;

                if (currentDetail.IsPieceManagement)
                {
                    tabSkuBarcode.PageVisible = false;
                    tabSerialNumber.PageVisible = true;
                }
                else
                {
                    tabSkuBarcode.PageVisible = true;
                    tabSerialNumber.PageVisible = false;

                    SkuView sku = ServiceHelper.SkuService.GetSkuView(currentDetail.SkuId);
                    if (sku != null)
                        txtBarcode.Text = sku.Barcode;

                }

                if (currentDetail.IsBatchManagement)
                {
                    BarcodeView.ExpandMasterRow(e.RowHandle);
                    sePrintLabelQty.Value = 0;
                }
                else
                {
                    cbBatch.Text = string.Empty;
                    sePrintLabelQty.Value = currentDetail.ReceivingQty;
                }
            }

        }

        private void BarcodeView_MouseDown(object sender, MouseEventArgs e)
        {
            GridView batchView = (GridView)BarcodeView.GetDetailView(BarcodeView.FocusedRowHandle, 0);
            if (batchView != null)
            {
                ReceivingInboundBatch currentBatch = (ReceivingInboundBatch)batchView.GetRow(batchView.FocusedRowHandle);
                if (currentBatch != null)
                    cbBatch.Text = currentBatch.BatchNumber;
            }
        }

        #region sku images
        private int _skuImageCount;
        private int _currentImageIndex = 0;

        private void InitImages(int skuId)
        {
            try
            {
                imgSlider.Images.Clear();

                _skuImageCount = ServiceHelper.SkuService.GetSkuImageCount(skuId);
                if (_skuImageCount > 0)
                    _currentImageIndex = 1;
                else
                    _currentImageIndex = 0;

                for (int i = 1; i <= _skuImageCount; i++)
                {
                    GetSkuImages(skuId, i);
                }
            }
            catch (FaultException<ServiceError> sex)
            {
                if (sex.Detail != null)
                    FormHelper.ShowWarningDialog(sex.Detail.ErrorMessage);
            }
        }

        private string GetImagesPath()
        {
            int merchantId = CurrentInboundPlan.MerchantId;
            return System.IO.Path.Combine(GlobalState.SkuImagesPath, merchantId.ToString());
        }

        private string GetImageFileName(int skuId, int index)
        {
            return string.Format("{0}-{1}.jpg", skuId, index);
        }

        private void GetSkuImages(int skuId, int index)
        {
            string path = GetImagesPath();
            string imageFile = System.IO.Path.Combine(path, GetImageFileName(skuId, index));
            bool isExits = System.IO.File.Exists(imageFile);
            if (!isExits)
            {
                try
                {
                    SkuImage skuImage = ServiceHelper.SkuService.GetSkuImage(skuId, index);
                    SaveToImageFile(path, skuImage, index);

                    LoadSkuImage(skuId, index);
                }
                catch (FaultException<ServiceError> sex)
                {
                    if (sex.Detail != null)
                        FormHelper.ShowWarningDialog(sex.Detail.ErrorMessage);
                }
            }
            else
                LoadSkuImage(skuId, index);
        }

        private void SaveToImageFile(string path, SkuImage skuImage, int index)
        {
            CreateFolder(path);
            string filePath = System.IO.Path.Combine(path, GetImageFileName(skuImage.SkuId, index));
            string dStr = CompressHelper.Decompress(skuImage.Image);
            Base64Helper.SaveToFile(dStr, filePath);
        }

        public void CreateFolder(string path)
        {
            System.IO.DirectoryInfo info = new System.IO.DirectoryInfo(path);
            if (!info.Exists)
                System.IO.Directory.CreateDirectory(path);
        }

        private void LoadSkuImage(int skuId, int _currentImageIndex)
        {
            string filePath = System.IO.Path.Combine(GetImagesPath(), GetImageFileName(skuId, _currentImageIndex));
            Image img = Image.FromFile(filePath);
            imgSlider.Images.Add(img);
        }
        #endregion

        private void BarcodeView_MasterRowExpanded(object sender, CustomMasterRowEventArgs e)
        {
            GridView batchView = (GridView)BarcodeView.GetDetailView(BarcodeView.FocusedRowHandle, 0);
            if (batchView != null)
            {
                CustomizeBarcodeViewBatchGrid(batchView);
                batchView.RowClick -= new RowClickEventHandler(BarcodeDetailBatchView_RowClick);
                batchView.RowClick += new RowClickEventHandler(BarcodeDetailBatchView_RowClick);
            }
        }


        private void BarcodeDetailBatchView_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            GridView view = (GridView)sender;

            ReceivingInboundBatch currentBatch = (ReceivingInboundBatch)view.GetRow(view.FocusedRowHandle);
            if (currentBatch != null)
            {
                cbBatch.Text = currentBatch.BatchNumber;
                sePrintLabelQty.Value = currentBatch.Qty;
            }
        }

        private void wizReceivePreparation_FinishClick(object sender, CancelEventArgs e)
        {
            DialogResult dialogResult = FormHelper.ShowQuestionDialog("是否保存当前收货准备任务数据？");
            if (dialogResult == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    ReceivingPreparation preparation = new ReceivingPreparation();
                    preparation.WarehouseId = CurrentInboundPlan.WarehouseId;
                    preparation.Vehicle = txtVehicle.Text.Trim();
                    preparation.PlanId = CurrentInboundPlan.PlanId;
                    preparation.Operator = GlobalState.CurrentUser.UserId;
                    preparation.ArrivalTime = deArrivalTime.DateTime.ToString("yyyy-MM-dd HH:mm:ss");
                    preparation.DeliveryMan = txtDeliveryMan.Text.Trim();

                    List<ReceivingPreparationDetail> receivedList = new List<ReceivingPreparationDetail>();
                    foreach (var detail in ReceivingDetails)
                        if (detail.ReceivingQty > 0)
                            receivedList.Add(detail);
                    preparation.Details = receivedList;

                    // upload result
                    string taskNumber = ServiceHelper.InboundService.UploadReceivingPreparation(preparation);

                    if (taskNumber == string.Empty)
                    {
                        FormHelper.ShowWarningDialog("收货准备任务数据保存失败。");
                    }
                    else
                    {
                        FormHelper.ShowInformationDialog(string.Format("收货准备任务数据保存成功，任务号为{0}。", taskNumber));
                        AbortInboundTask();
                    }
                }
                catch (FaultException<ServiceError> sex)
                {
                    if (sex.Detail != null)
                        FormHelper.ShowWarningDialog(sex.Detail.ErrorMessage);
                }
            }
        }

        private void wizReceivePreparation_CancelClick(object sender, CancelEventArgs e)
        {
            // abort inbound task
            DialogResult dialogResult = FormHelper.ShowQuestionDialog("是否放弃当前收货准备任务？");

            if (dialogResult == DialogResult.Yes)
            {
                AbortInboundTask();
            }
        }

        private void AbortInboundTask()
        {
            wizReceivePreparation.SelectedPage = pageIntroduction;
            CurrentInboundPlan = null;
            BatchViewCurrentReceivingDetail = null;
            PlanDetails = null;
            ReceivingDetails = null;
            grdPlanDetail.DataSource = null;

            cbInboundPlan.Text = string.Empty;
            cbInboundPlan.Enabled = true;
            btnSelect.Enabled = true;
            deArrivalTime.DateTime = DateTime.Now;
            txtDeliveryMan.Text = string.Empty;
            txtVehicle.Text = string.Empty;
        }

        private void btnPrintBarcodeLabel_Click(object sender, EventArgs e)
        {
            if (sePrintLabelQty.Value <= 0)
            {
                FormHelper.ShowWarningDialog("标签数量必须大于0。");
                return;
            }

            if (BarcodeViewCurrentReceivingDetail == null)
            {
                FormHelper.ShowWarningDialog("请选择明细。");
                return;
            }

            if (tcLabel.SelectedTabPage == tabSerialNumber)
                PrintSNLabel();
            else
                PrintBarcodeLabel();
        }

        private void PrintBarcodeLabel()
        {
            try
            {
                SkuView sku = ServiceHelper.SkuService.GetSkuView(BarcodeViewCurrentReceivingDetail.SkuId);
                if (sku == null)
                {
                    FormHelper.ShowErrorDialog("货物条码信息获取失败。");
                    return;
                }

                SKULabel skuLabel = new SKULabel();
                if (cbPrinters.Text != string.Empty)
                    SKULabel.ParmatersFormat = SKULabel.ParmatersFormat + string.Format(" /PRN=\"{0}\"", cbPrinters.Text);

                int labelQty = (int)sePrintLabelQty.Value;
                for (int i = 1; i <= labelQty; i++)
                {
                    string data = string.Format(SKULabel.DataFormat, BarcodeViewCurrentReceivingDetail.SkuNumber, BarcodeViewCurrentReceivingDetail.SkuName,
                                                 sku.Barcode, cbBatch.Text.Trim(), DateTime.Now.ToString("yyyy-MM-dd"));
                    skuLabel.AppendData(data);
                }

                skuLabel.Print();
            }
            catch (FaultException<ServiceError> sex)
            {
                if (sex.Detail != null)
                    FormHelper.ShowWarningDialog(sex.Detail.ErrorMessage);
            }
            catch (Exception ex)
            {
                Framework.Core.Exception.ExceptionHelper.HandleException(ex, true, false);
                FormHelper.ShowErrorDialog("打印货物条码标签失败。");
            }
        }

        private void PrintSNLabel()
        {
            try
            {
                List<SerialNumber> numbers = ServiceHelper.InboundService.CreateSerialNumber(GlobalState.CurrentWarehouse.WarehouseId, BarcodeViewCurrentReceivingDetail.PlanId, BarcodeViewCurrentReceivingDetail.SkuId, BarcodeViewCurrentReceivingDetail.PackId, (int)sePrintLabelQty.Value, GlobalState.CurrentUser.UserId);

                if (numbers.Count != (int)sePrintLabelQty.Value)
                {
                    FormHelper.ShowErrorDialog("序列号创建失败。");
                    return;
                }

                SerialNumber[] snArray = numbers.ToArray();

                txtStartSN.Text = snArray[0].Sn;
                txtEndSN.Text = snArray[snArray.Length - 1].Sn;

                SkuView sku = ServiceHelper.SkuService.GetSkuView(BarcodeViewCurrentReceivingDetail.SkuId);
                if (sku == null)
                {
                    FormHelper.ShowErrorDialog("货物条码信息获取失败。");
                    return;
                }

                SNLabel snLabel = new SNLabel();
                if (cbPrinters.Text != string.Empty)
                    SNLabel.ParmatersFormat = SNLabel.ParmatersFormat + string.Format(" /PRN=\"{0}\"", cbPrinters.Text);
                foreach (var serialNumber in numbers)
                {
                    string data = string.Format(SNLabel.DataFormat, BarcodeViewCurrentReceivingDetail.SkuNumber, BarcodeViewCurrentReceivingDetail.SkuName,
                                                 sku.Barcode, serialNumber.Sn, cbBatch.Text.Trim(), DateTime.Now.ToString("yyyy-MM-dd"));
                    snLabel.AppendData(data);
                }

                snLabel.Print();
            }
            catch (FaultException<ServiceError> sex)
            {
                if (sex.Detail != null)
                    FormHelper.ShowWarningDialog(sex.Detail.ErrorMessage);
            }
            catch (Exception ex)
            {
                Framework.Core.Exception.ExceptionHelper.HandleException(ex, true, false);
                FormHelper.ShowErrorDialog("打印货物序列号标签失败。");
            }
        }
    }
}
