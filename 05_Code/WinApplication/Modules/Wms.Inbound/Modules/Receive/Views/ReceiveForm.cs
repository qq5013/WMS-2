using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.ServiceModel;
using System.Windows.Forms;
using Business.Common.Exception;
using Business.Domain.Warehouse;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Grid;
using Framework.UI.Template.Others;
using Business.Domain.Inventory;
using Wms.Common;
using Microsoft.Practices.CompositeUI.SmartParts;
using Business.Domain.Inventory.Views;
using Framework.UI.Template.Common;
using Business.Domain.Warehouse.Views;
using Framework.Core.Exception;

namespace Modules.ReceiveModule.Views
{
    [SmartPart]
    public partial class ReceiveForm : CustomForm
    {
        public InboundPlan CurrentInboundPlan { get; set; }

        private List<InboundTaskDetailView> _currentTaskDetails;

        private InboundTaskDetailView _currentTaskDetail;

        private List<InboundTaskDetailResult> _receivingResult;

        private readonly Dictionary<string, Container> _transferContainerList = new Dictionary<string, Container>();

        private readonly Dictionary<string, Container> _storageContainerList = new Dictionary<string, Container>();

        private readonly Dictionary<string, ArrayList> _skuSerialNumbers = new Dictionary<string, ArrayList>();

        public ReceiveForm()
        {
            InitializeComponent();
        }

        public ReceiveForm(InboundPlan inboundPlan)
        {
            InitializeComponent();
            CurrentInboundPlan = inboundPlan;
        }

        private void ReceiveForm_Load(object sender, EventArgs e)
        {
            if (CurrentInboundPlan != null)
            {
                leInboundPlan.Properties.ReadOnly = true;
                leInboundPlan.Text = CurrentInboundPlan.PlanNumber;
            }

            tcReceivingWay.Enabled = false;

            LoadReceivingInboundPlan();
            LoadReceiveLocations();
        }

        private void LoadReceivingInboundPlan()
        {
            try
            {
                List<string> tasks = ServiceHelper.InboundService.GetReceivingTasks(GlobalState.CurrentWarehouse.WarehouseCode);
                leInboundPlan.Properties.DataSource = tasks;
                //leInboundPlan.Properties.Columns.Add(new LookUpColumnInfo("", "入库计划号"));
            }
            catch (FaultException<ServiceError> sex)
            {
                if (sex.Detail != null)
                    FormHelper.ShowWarningDialog(sex.Detail.ErrorMessage);

                FormHelper.ShowErrorDialog("待核收入库计划信息加载失败。");
            }
        }

        private void LoadReceiveLocations()
        {
            var locations = new List<LocationView>();
            try
            {
                locations = ServiceHelper.WarehouseService.GetReceivingLocation(GlobalState.CurrentWarehouse.WarehouseCode);
            }
            catch (FaultException<ServiceError> sex)
            {
                ExceptionHelper.HandleException(sex, true, false);
            }

            if (locations.Count <= 0)
            {
                FormHelper.ShowErrorDialog("当前仓库无收货暂存库位，请首先设置库位信息。");
                leInboundPlan.Enabled = false;
                leInboundTask.Enabled = false;
            }
            else
            {
                leReceiveLocation.Properties.DataSource = locations;
                leReceiveLocation.Properties.DisplayMember = "LocationName";
                leReceiveLocation.Properties.ValueMember = "LocationId";
                leReceiveLocation.Properties.Columns.Add(new LookUpColumnInfo("LocationCode", "库位代码"));
                leReceiveLocation.Properties.Columns.Add(new LookUpColumnInfo("LocationName", "库位名称"));
            }
        }

        private void leInboundPlan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                LoadInboundPlanAndTask();
            }
        }

        private void LoadInboundPlanAndTask()
        {
            string planNumber = leInboundPlan.Text;
            if (planNumber == string.Empty) return;

            // get inbound plan
            InboundPlan plan =
                ServiceHelper.InboundService.GetInboundPlanByNumber(GlobalState.CurrentWarehouse.WarehouseCode,
                                                                    planNumber);
            if (plan == null)
            {
                FormHelper.ShowWarningDialog("选择的入库计划信息不存在，请确认后重新选择。");
                return;
            }
            CurrentInboundPlan = plan;

            // get receive preparation task
            try
            {
                List<InboundTask> tasks = ServiceHelper.InboundService.GetInboundTaskByPlan(plan.PlanId);
                if (tasks.Count > 0)
                {
                    leInboundTask.Properties.DataSource = tasks;
                    leInboundTask.Properties.DisplayMember = "TaskNumber";
                    leInboundTask.Properties.ValueMember = "TaskId";
                    leInboundTask.Properties.Columns.Add(new LookUpColumnInfo("TaskNumber", "任务号"));

                    leInboundTask.EditValue = tasks[0].TaskId;
                    leInboundTask.Focus();
                }
                else
                {
                    leInboundTask.Properties.DataSource = null;
                    FormHelper.ShowWarningDialog("选择的入库计划信息尚未进行收货准备操作。");
                    leInboundPlan.Focus();
                }
            }
            catch (FaultException<ServiceError> sex)
            {
                if (sex.Detail != null)
                    FormHelper.ShowWarningDialog(sex.Detail.ErrorMessage);
            }
        }

        private void leInboundTask_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                LoadInboundTaskDetails();
            }
        }

        private void LoadInboundTaskDetails()
        {
            if (leInboundTask.EditValue == null) return;

            var dialogResult = FormHelper.ShowQuestionDialog("现在开始核收此任务？");
            if (dialogResult == DialogResult.Yes)
            {
                leInboundPlan.Enabled = false;
                leInboundTask.Enabled = false;
                tcReceivingWay.Enabled = true;

                var taskId = (int)leInboundTask.EditValue;
                var details = ServiceHelper.InboundService.GetInboundTaskDetail(taskId);
                _currentTaskDetails = details;

                leSku.Properties.DataSource = _currentTaskDetails;
                leSku.Properties.DisplayMember = "SkuNumber";
                leSku.Properties.ValueMember = "SkuId";
                leSku.Properties.Columns.Add(new LookUpColumnInfo("SkuNumber", "货物代码"));
                leSku.Properties.Columns.Add(new LookUpColumnInfo("SkuName", "货物名称"));
                leSku.Properties.Columns.Add(new LookUpColumnInfo("PackName", "包装"));

                leSku.EditValue = details[0].SkuId;

                grdTaskDetails.DataSource = details;
                CustomTaskDetailsGrid();

                // Init Result 
                _receivingResult = new List<InboundTaskDetailResult>();
                grdResult.DataSource = _receivingResult;
                CustomResultGrid();

                leReceiveLocation.Focus();
            }
        }

        private void CustomResultGrid()
        {
            int columnIndex = 0;

            FormHelper.SetGridColumn(ResultGridView, "InboundTaskId", "", 150, columnIndex++, false);

            FormHelper.SetGridColumn(ResultGridView, "InboundTaskDetailId", "", 150, columnIndex++, false);

            FormHelper.SetGridColumn(ResultGridView, "SkuId", "", 100, columnIndex++, false);

            FormHelper.SetGridColumn(ResultGridView, "PackId", "", 200, columnIndex++, false);

            FormHelper.SetGridColumn(ResultGridView, "SkuNumber", "货物代码", 100, columnIndex++, true);

            FormHelper.SetGridColumn(ResultGridView, "SkuName", "货物名称", 200, columnIndex++, true);

            FormHelper.SetGridColumn(ResultGridView, "PackName", "包装", 100, columnIndex++, true);

            FormHelper.SetGridColumn(ResultGridView, "ContainerId", "", 100, columnIndex++, false);

            FormHelper.SetGridColumn(ResultGridView, "ContainerName", "容器名", 100, columnIndex++, true);

            FormHelper.SetGridColumn(ResultGridView, "Qty", "核收数量", 100, columnIndex++, true);

            FormHelper.SetGridColumn(ResultGridView, "BatchNumber", "入库批次号", 100, columnIndex++, true);

            FormHelper.SetGridColumn(ResultGridView, "Batch", "", 100, columnIndex++, false);

            FormHelper.SetGridColumn(ResultGridView, "SerialNumbers", "", 100, columnIndex++, false);

            ResultGridView.OptionsView.ColumnAutoWidth = true;
            ResultGridView.BestFitColumns();
        }

        private void CustomTaskDetailsGrid()
        {
            int columnIndex = 0;

            FormHelper.SetGridColumn(TaskGridView, "Id", "", 100, columnIndex++, false);

            FormHelper.SetGridColumn(TaskGridView, "TaskId", "", 150, columnIndex++, false);

            FormHelper.SetGridColumn(TaskGridView, "SkuId", "", 100, columnIndex++, false);

            FormHelper.SetGridColumn(TaskGridView, "PackId", "", 200, columnIndex++, false);

            FormHelper.SetGridColumn(TaskGridView, "SkuNumber", "货物代码", 100, columnIndex++, true);

            FormHelper.SetGridColumn(TaskGridView, "SkuName", "货物名称", 200, columnIndex++, true);

            FormHelper.SetGridColumn(TaskGridView, "PackName", "包装", 100, columnIndex++, true);

            FormHelper.SetGridColumn(TaskGridView, "ReceivedQty", "已核收数量", 100, columnIndex++, true);

            FormHelper.SetGridColumn(TaskGridView, "Qty", "待核收数量", 100, columnIndex++, true);

            FormHelper.SetGridColumn(TaskGridView, "UPC", "UPC码", 100, columnIndex++, false);

            FormHelper.SetGridColumn(TaskGridView, "Barcode", "货物条码", 100, columnIndex++, false);

            FormHelper.SetGridColumn(TaskGridView, "IsBarcodeManagement", "是否条码管理", 100, columnIndex++, true);

            FormHelper.SetGridColumn(TaskGridView, "IsBatchManagement", "是否批次管理", 100, columnIndex++, true);

            FormHelper.SetGridColumn(TaskGridView, "IsPieceManagement", "是否单品管理", 100, columnIndex++, true);

            FormHelper.SetGridColumn(TaskGridView, "IsContainerManagement", "是否存储容器管理", 100, columnIndex++, true);

            FormHelper.SetGridColumn(TaskGridView, "Batchs", "", 100, columnIndex++, false);

            FormHelper.SetGridColumn(TaskGridView, "IsValid", "", 100, columnIndex++, false);

            TaskGridView.OptionsView.ColumnAutoWidth = true;
            TaskGridView.BestFitColumns();
        }

        private void leSku_EditValueChanged(object sender, EventArgs e)
        {
            if (leSku.EditValue == null) return;

            var detail = (InboundTaskDetailView)leSku.GetSelectedDataRow();
            if (detail == null) return;
            
            _currentTaskDetail = detail;

            lePack.Properties.NullText = detail.PackName;
            lePack.Tag = detail.PackId;

            seQty.Value = 0;
            seQty.Enabled = true;

            // set tab page
            if (!detail.IsBarcodeManagement)
            {
                tcReceivingWay.SelectedTabPage = tabNoBarcode;
                tabNoBarcode.PageVisible = true;
                tabBarcodeUPC.PageVisible = false;
                tabSerialNumber.PageVisible = false;
            }
            else
            {
                if (detail.IsPieceManagement)
                {
                    tcReceivingWay.SelectedTabPage = tabSerialNumber;
                    tabNoBarcode.PageVisible = false;
                    tabBarcodeUPC.PageVisible = false;
                    tabSerialNumber.PageVisible = true;

                    seQty.Value = 1;
                    seQty.Enabled = false;
                }
                else
                {
                    tcReceivingWay.SelectedTabPage = tabBarcodeUPC;
                    tabNoBarcode.PageVisible = false;
                    tabBarcodeUPC.PageVisible = true;
                    tabSerialNumber.PageVisible = false;
                }
            }

            // set container
            lblContainer.Text = detail.IsContainerManagement ? @"存储容器条码： " : @"周转容器条码： ";

            // set batch
            if (detail.IsBatchManagement)
            {
                leBatchNumber.Enabled = true;
                leBatchNumber.Properties.DataSource = detail.Batchs;
                leBatchNumber.Properties.DisplayMember = "BatchNumber";
                leBatchNumber.Properties.ValueMember = "Id";
                leBatchNumber.Properties.Columns.Add(new LookUpColumnInfo("BatchNumber", "入库批次号"));
                leBatchNumber.Properties.Columns.Add(new LookUpColumnInfo("Qty", "批次数量"));
            }
            else
            {
                leBatchNumber.Enabled = false;
                leBatchNumber.Properties.DataSource = null;
            }

            // clear form
            ClearScanInformation();
        }

        public void CustomizeBatchView(GridView view)
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
            view.BestFitColumns();
        }

        private void TaskGridView_MasterRowExpanded(object sender, CustomMasterRowEventArgs e)
        {
            var batchView = (GridView)TaskGridView.GetDetailView(TaskGridView.FocusedRowHandle, 0);
            if (batchView != null)
            {
                CustomizeBatchView(batchView);
            }
        }

        private void leInboundPlan_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == ButtonPredefines.OK)
            {
                LoadInboundPlanAndTask();
            }
        }

        private void leInboundTask_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == ButtonPredefines.OK)
            {
                LoadInboundTaskDetails();
            }
        }

        private Container FindInContainerDictionary(string barcode, Dictionary<string, Container> dictionaries)
        {
            if (dictionaries.ContainsKey(barcode))
                return dictionaries[barcode];

            return null;
        }

        private void txtContainer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char) Keys.Return)
            {
                Container container;
                if (!ValidateContainerBarcode(out container))
                {
                    txtContainer.SelectAll();
                    txtContainer.Focus();
                    return;
                }

                txtContainer.Tag = container;

                if (leBatchNumber.Enabled)
                {
                    if (_currentTaskDetail.Batchs.Count == 1)
                    {
                        // set only one default batch
                        leBatchNumber.EditValue = _currentTaskDetail.Batchs[0].Id;
                    }
                    leBatchNumber.Focus();
                }
                else
                {
                    if (!_currentTaskDetail.IsBarcodeManagement) 
                        seQty.Focus();
                    else
                    {
                        if (_currentTaskDetail.IsPieceManagement)
                        {
                            seQty.Value = 1;
                            txtSN.Focus();
                        }
                        else
                            txtUPCBarcode.Focus();
                    }
                }

            }
        }

        private bool ValidateContainerBarcode(out Container container)
        {
            // validate container
            string barcode = txtContainer.Text.Trim();

            container = null;
            if (_currentTaskDetail.IsContainerManagement)
            {
                if (barcode == string.Empty)
                {
                    FormHelper.ShowWarningDialog("当前待核收货物必须使用存储容器收货。");
                    txtContainer.Text = string.Empty;
                    txtContainer.Focus();
                    return false;
                }

                container = FindInContainerDictionary(barcode, _storageContainerList);
                if (container == null)
                {
                    try
                    {
                        container = ServiceHelper.WarehouseService.GetStorageContainerByBarcode(
                            GlobalState.CurrentWarehouse.WarehouseCode, barcode);
                    }
                    catch (FaultException<ServiceError> sex)
                    {
                        ExceptionHelper.HandleException(sex, true, false);
                    }

                    if (container != null)
                        _storageContainerList.Add(barcode, container);
                    else
                    {
                        FormHelper.ShowWarningDialog("扫描的容器条码不正确或不是存储容器。");
                        txtContainer.Text = string.Empty;
                        txtContainer.Focus();
                        return false;
                    }
                }
            }
            else
            {
                if (barcode == string.Empty)
                {
                    FormHelper.ShowWarningDialog("当前待核收货物必须使用周转容器收货。");
                    txtContainer.Text = string.Empty;
                    txtContainer.Focus();
                    return false;
                }

                if (barcode != string.Empty)
                {
                    container = FindInContainerDictionary(barcode, _transferContainerList);
                    if (container == null)
                    {
                        try
                        {
                            container = ServiceHelper.WarehouseService.GetTransferContainerByBarcode(
                                GlobalState.CurrentWarehouse.WarehouseCode, barcode);
                        }
                        catch (FaultException<ServiceError> sex)
                        {
                            ExceptionHelper.HandleException(sex, true, false);
                        }

                        if (container != null)
                            _transferContainerList.Add(barcode, container);
                        else
                        {
                            FormHelper.ShowWarningDialog("扫描的容器条码不正确或不是周转容器。");
                            txtContainer.Text = string.Empty;
                            txtContainer.Focus();
                            return false;
                        }
                    }
                }
            }

            return true;
        }

        private void leBatchNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char) Keys.Return)
            {
                if (!_currentTaskDetail.IsBarcodeManagement)
                {
                    seQty.Focus();
                }
                else
                {
                    if (_currentTaskDetail.IsPieceManagement)
                    {
                        seQty.Value = 1;
                        txtSN.Focus();
                    }
                    else
                    {
                        txtUPCBarcode.Focus();
                    }
                }
            }
        }

        private void seQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char) Keys.Return)
            {
                if (seQty.Value <= 0) return;

                if (!_currentTaskDetail.IsBarcodeManagement)
                {
                    if (!ValidateNoBarcodeSku())
                        return;
                }
                else
                {
                    if (_currentTaskDetail.IsPieceManagement)
                        if (!ValidateUPCBarcodeSku())
                            return;
                }

                btnContinue.Focus();
            }
        }

        private bool ValidateContainer()
        {
            /*
             * 如果扫描的容器条码不为空，但Tag值为空，说明条码不正确。
             * 存储容器校验规则：必须为存储型容器，存储容器非空
             * 周转容器校验规则：必须为周转型容器，周转容器可以为空
             */

            if (txtContainer.Text != string.Empty && txtContainer.Tag == null)
            {
                FormHelper.ShowWarningDialog("扫描的存储容器条码不正确，请重新扫描。");
                txtContainer.Text = string.Empty;
                return false;
            }

            if (_currentTaskDetail.IsContainerManagement)
            {
                // validate storage container
                if (txtContainer.Tag == null)
                {
                    FormHelper.ShowWarningDialog("请扫描存储容器条码");
                    txtContainer.Text = string.Empty;
                    return false;
                }
            }

            return true;
        }

        private bool ValidateBatch()
        {
            if (_currentTaskDetail.IsBatchManagement && leBatchNumber.EditValue == null)
            {
                FormHelper.ShowWarningDialog("请选择核收货物的入库批次。");
                return false;
            }

            if (leBatchNumber.EditValue != null)
            {
                var batch = (InboundBatch)leBatchNumber.GetSelectedDataRow();
                if (batch == null)
                {
                    FormHelper.ShowWarningDialog("入库批次信息异常。");
                    return false;
                }

                if (IsOverflowBatchQty(batch.BatchNumber))
                    return false;
            }

            return true;
        }


        private int GetReceivedBatchQty(int skuId, string batchNumber)
        {
            //get received qty
            int receivedBatchQty = 0;
            foreach (var detail in _receivingResult)
            {
                if (detail.SkuId == skuId && detail.BatchNumber == batchNumber)
                    receivedBatchQty = receivedBatchQty + detail.Qty;
            }

            return receivedBatchQty;
        }

        private int GetInboundTaskBatchQty(int skuId, string batchNumber)
        {
            // get batch qty
            var taskBatchQty = 0;
            foreach (var batch in _currentTaskDetail.Batchs)
            {
                if (batch.SkuId == skuId && batch.BatchNumber == batchNumber)
                    taskBatchQty = taskBatchQty + batch.Qty;
            }

            return taskBatchQty;
        }

        private bool IsOverflowBatchQty(int skuId, string batchNumber)
        {
            var receivingQty = (int) seQty.Value;
            var receivedBatchQty = GetReceivedBatchQty(skuId, batchNumber);
            var taskBatchQty = GetInboundTaskBatchQty(skuId, batchNumber);

            if ((receivingQty + receivedBatchQty) > taskBatchQty)
            {
                FormHelper.ShowWarningDialog("批次核收合计数量不能超过待核收的批次数量。");
                seQty.Value = 0;
                seQty.Focus();
                return true;
            }

            return false;
        }

        private int GetReceivedQty(int skuId)
        {
            int receivedQty = 0;
            foreach (var detail in _receivingResult)
            {
                if (detail.SkuId == skuId)
                    receivedQty = receivedQty + detail.Qty;
            }
            return receivedQty;
        }

        /// <summary>
        /// 核对当前核收数量是否超出待核收总数
        /// </summary>
        /// <param name="skuId">货物编号</param>
        /// <returns></returns>
        private bool IsOverflowQty(int skuId)
        {
            var receivingQty = (int)seQty.Value;
            var receivedQty = GetReceivedQty(skuId);
            var planQty = _currentTaskDetail.Qty;

            if ((receivingQty + receivedQty) > planQty)
            {
                FormHelper.ShowWarningDialog("核收合计数量不能超过待核收的货物数量。");
                seQty.Value = 0;
                seQty.Focus();
                return true;
            }

            return false;
        }

        private bool ValidateNoBarcodeSku()
        {
            int currentQty = (int)seQty.Value;
            if ((currentQty + _currentTaskDetail.ReceivedQty) > _currentTaskDetail.Qty)
            {
                FormHelper.ShowWarningDialog("实际核收数量不能超过待核收数量。");
                seQty.Value = 0;
                seQty.Focus();
                return false;
            }

            return true;
        }

        private bool ValidateUPCBarcodeSku()
        {
            int currentQty = (int)seQty.Value;
            if ((currentQty + _currentTaskDetail.ReceivedQty) > _currentTaskDetail.Qty)
            {
                FormHelper.ShowWarningDialog("实际核收数量不能超过待核收数量。");
                seQty.Value = 0;
                seQty.Focus();
                return false;
            }

            return true;
        }

        private InboundTaskDetailResult FindDetailResult(int skuId, int packId, int containerId, string batchNumber)
        {
            foreach (var detail in _receivingResult)
            {
                if (detail.SkuId == skuId && detail.PackId == packId && detail.ContainerId == containerId &&
                    detail.BatchNumber == batchNumber)
                    return detail;
            }

            return null;
        }

        private void txtUPCBarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char) Keys.Return)
            {
                if (ValidateUPCBarcode())
                    seQty.Focus();
                else
                {
                    txtUPCBarcode.Focus();
                }
            }
        }

        private bool ValidateUPCBarcode()
        {
            string barcode = txtUPCBarcode.Text.Trim();
            if (barcode != _currentTaskDetail.UPC && barcode != _currentTaskDetail.Barcode)
            {
                FormHelper.ShowWarningDialog("扫描的条码或UPC不是待核收的商品，请复核。");
                txtUPCBarcode.Text = string.Empty;
                return false;
            }

            return true;
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            if (!_currentTaskDetail.IsBarcodeManagement)
                AddNoBarcodeQty();
            else
            {
                if (_currentTaskDetail.IsPieceManagement)
                    AddSingleSNQty();
                else
                    AddSkuQty();
            }
        }

        private void AddSingleSNQty()
        {
            bool validatedFlag;

            string batchNumber = string.Empty;
            InboundBatch batch = null;
            if (leBatchNumber.Enabled && leBatchNumber.EditValue != null)
            {
                batch = (InboundBatch)leBatchNumber.GetSelectedDataRow();
                batchNumber = batch.BatchNumber;
            }

            int skuId = _currentTaskDetail.SkuId;
            int packId = (int)lePack.Tag;

            if (batchNumber != string.Empty)
                validatedFlag = ValidateContainer() && ValidateBatch() && !IsOverflowQty(skuId);
            else
                validatedFlag = ValidateContainer() && !IsOverflowQty(skuId);

            #region add scaned sn qty
            if (validatedFlag)
            {
                // add received qty
                _currentTaskDetail.ReceivedQty = _currentTaskDetail.ReceivedQty + (int)seQty.Value;

                //add result qty
                int containerId = 0;
                string containerName = string.Empty;
                if (txtContainer.Tag != null)
                {
                    Container container = (Container)txtContainer.Tag;
                    containerId = container.ContainerId;
                    containerName = container.ContainerName;
                }

                var resultDetail = FindDetailResult(skuId, packId, containerId, batchNumber);
                if (resultDetail != null)
                {
                    resultDetail.Qty = resultDetail.Qty + (int) seQty.Value;
                    resultDetail.SerialNumbers.Add(txtSN.Text.Trim());
                }
                else
                {
                    // create new result detail
                    resultDetail = new InboundTaskDetailResult();
                    resultDetail.InboundTaskId = _currentTaskDetail.TaskId;
                    resultDetail.InboundTaskDetailId = _currentTaskDetail.Id;
                    resultDetail.PackId = packId;
                    resultDetail.Batch = batch;
                    resultDetail.BatchNumber = batchNumber;
                    resultDetail.ContainerId = containerId;
                    resultDetail.ContainerName = containerName;
                    resultDetail.PackName = _currentTaskDetail.PackName;
                    resultDetail.Qty = (int) seQty.Value;
                    resultDetail.SerialNumbers = new List<string>();
                    resultDetail.SkuId = _currentTaskDetail.SkuId;
                    resultDetail.SkuNumber = _currentTaskDetail.SkuNumber;
                    resultDetail.SkuName = _currentTaskDetail.SkuName;

                    resultDetail.SerialNumbers.Add(txtSN.Text.Trim());

                    _receivingResult.Add(resultDetail);
                }

                //refresh grid
                grdTaskDetails.RefreshDataSource();
                grdResult.RefreshDataSource();

                //refresh listbox
                AddSNAndRefreshListBox(txtSN.Text.Trim());

                if (IsReceivingComplete())
                {
                    UploadReceivingResult();
                }
                else
                {
                    //ClearScanInformation();
                    if (!IsSkuReceived())
                    {
                        txtSN.SelectAll();
                        txtSN.Focus();
                    }
                }
            }
            #endregion
        }

        private void AddNoBarcodeQty()
        {
            bool validatedFlag;

            int skuId = _currentTaskDetail.SkuId;
            int packId = (int)lePack.Tag;

            validatedFlag = ValidateContainer() && !IsOverflowQty(skuId);

            #region add scaned qty
            if (validatedFlag)
            {
                // add received qty
                _currentTaskDetail.ReceivedQty = _currentTaskDetail.ReceivedQty + (int)seQty.Value;

                //add result qty
                int containerId = 0;
                string containerName = string.Empty;
                if (txtContainer.Tag != null)
                {
                    Container container = (Container)txtContainer.Tag;
                    containerId = container.ContainerId;
                    containerName = container.ContainerName;
                }

                var resultDetail = FindDetailResult(skuId, packId, containerId, string.Empty);
                if (resultDetail != null)
                    resultDetail.Qty = resultDetail.Qty + (int)seQty.Value;
                else
                {
                    // create new result detail
                    resultDetail = new InboundTaskDetailResult();
                    resultDetail.InboundTaskId = _currentTaskDetail.TaskId;
                    resultDetail.InboundTaskDetailId = _currentTaskDetail.Id;
                    resultDetail.PackId = packId;
                    resultDetail.Batch = null;
                    resultDetail.BatchNumber = string.Empty;
                    resultDetail.ContainerId = containerId;
                    resultDetail.ContainerName = containerName;
                    resultDetail.PackName = _currentTaskDetail.PackName;
                    resultDetail.Qty = (int)seQty.Value;
                    resultDetail.SerialNumbers = new List<string>();
                    resultDetail.SkuId = _currentTaskDetail.SkuId;
                    resultDetail.SkuNumber = _currentTaskDetail.SkuNumber;
                    resultDetail.SkuName = _currentTaskDetail.SkuName;

                    _receivingResult.Add(resultDetail);
                }

                //refresh grid
                grdTaskDetails.RefreshDataSource();
                grdResult.RefreshDataSource();

                ClearScanInformation();
                if (IsReceivingComplete())
                {
                    UploadReceivingResult();
                }
                else
                    IsSkuReceived();
            }
            #endregion
        }

        private bool IsSkuReceived()
        {
            if (_currentTaskDetail.ReceivedQty == _currentTaskDetail.Qty)
            {
                FormHelper.ShowInformationDialog(string.Format("货物{0} 核收完成， 请选择其它货物。", _currentTaskDetail.SkuNumber));
                leSku.Focus();
                return true;
            }

            return false;
        }

        private void AddSkuQty()
        {
            bool validatedFlag;

            string batchNumber = string.Empty;
            InboundBatch batch = null;
            if (leBatchNumber.Enabled && leBatchNumber.EditValue != null)
            {
                batch = (InboundBatch)leBatchNumber.GetSelectedDataRow();
                batchNumber = batch.BatchNumber;
            }

            int skuId = _currentTaskDetail.SkuId;
            int packId = (int)lePack.Tag;

            if (batchNumber != string.Empty)
                validatedFlag = ValidateContainer() && ValidateUPCBarcode() && ValidateBatch() && !IsOverflowQty(skuId);
            else
                validatedFlag = ValidateContainer() && ValidateUPCBarcode() && !IsOverflowQty(skuId);

            #region add scaned qty
            if (validatedFlag)
            {
                // add received qty
                _currentTaskDetail.ReceivedQty = _currentTaskDetail.ReceivedQty + (int)seQty.Value;

                //add result qty
                int containerId = 0;
                string containerName = string.Empty;
                if (txtContainer.Tag != null)
                {
                    Container container = (Container)txtContainer.Tag;
                    containerId = container.ContainerId;
                    containerName = container.ContainerName;
                }

                var resultDetail = FindDetailResult(skuId, packId, containerId, batchNumber);
                if (resultDetail != null)
                    resultDetail.Qty = resultDetail.Qty + (int)seQty.Value;
                else
                {
                    // create new result detail
                    resultDetail = new InboundTaskDetailResult();
                    resultDetail.InboundTaskId = _currentTaskDetail.TaskId;
                    resultDetail.InboundTaskDetailId = _currentTaskDetail.Id;
                    resultDetail.PackId = packId;
                    resultDetail.Batch = batch;
                    resultDetail.BatchNumber = batchNumber;
                    resultDetail.ContainerId = containerId;
                    resultDetail.ContainerName = containerName;
                    resultDetail.PackName = _currentTaskDetail.PackName;
                    resultDetail.Qty = (int)seQty.Value;
                    resultDetail.SerialNumbers = new List<string>();
                    resultDetail.SkuId = _currentTaskDetail.SkuId;
                    resultDetail.SkuNumber = _currentTaskDetail.SkuNumber;
                    resultDetail.SkuName = _currentTaskDetail.SkuName;

                    _receivingResult.Add(resultDetail);
                }

                //refresh grid
                grdTaskDetails.RefreshDataSource();
                grdResult.RefreshDataSource();

                ClearScanInformation();

                if (IsReceivingComplete())
                {
                    UploadReceivingResult();
                }
                else
                    IsSkuReceived();
            }
            #endregion
        }

        private void ClearScanInformation()
        {
            txtContainer.Text = string.Empty;
            leBatchNumber.EditValue = null;
            seQty.Value = 0;
            txtUPCBarcode.Text = string.Empty;
            txtSN.Text = string.Empty;
            txtStartSN.Text = string.Empty;
            txtEndSN.Text = string.Empty;

            txtContainer.Focus();
        }

        private void TaskGridView_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column.FieldName == "ReceivedQty")
            {
                if ((int)e.CellValue >= 0)
                {
                    object data = TaskGridView.GetRow(e.RowHandle);
                    if (data != null)
                    {
                        var detail = data as InboundTaskDetailView;
                        if (detail != null && detail.ReceivedQty == detail.Qty)
                        {
                            e.Appearance.ForeColor = Color.Green;
                        }
                        else
                            e.Appearance.ForeColor = Color.Red;
                    }
                }
            }
        }

        private void leReceiveLocation_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char) Keys.Return)
            {
                leSku.Focus();
            }
        }

        private void txtSN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char) Keys.Return)
            {
                string sn = txtSN.Text.Trim();
                if (sn == string.Empty)
                {
                    txtStartSN.Focus();
                }
                else
                {
                    if (!ValidateSNBarcode(sn))
                    {
                        txtSN.SelectAll();
                        txtSN.Focus();
                    }
                    else
                    {
                        seQty.Value = 1;
                        AddSingleSNQty();
                        txtSN.SelectAll();
                        txtSN.Focus();
                    }
                }
            }
        }

        private bool IsWarehouseSN(string sn)
        {
            const string prefix = "SN";
            string warehohouseCode = GlobalState.CurrentWarehouse.WarehouseCode.ToUpper();
            string snPrefix = prefix + warehohouseCode;
            if (sn.IndexOf(snPrefix) == 0)
            {
                return true;
            }

            return false;
        }

        private bool ValidateSNBarcode(string sn)
        {
            // validte sn from listbox
            string skuNumber = _currentTaskDetail.SkuNumber;
            if (!_skuSerialNumbers.ContainsKey(skuNumber))
            {
                var snList = new ArrayList();
                _skuSerialNumbers.Add(skuNumber, snList);
            }
            var serialNumbers = _skuSerialNumbers[skuNumber];
            if (serialNumbers.Contains(sn))
            {
                FormHelper.ShowWarningDialog("序列号条码重复扫描，请复核。");
                return false;
            }


            int planId = CurrentInboundPlan.PlanId;
            int skuId = _currentTaskDetail.SkuId;
            int packId = _currentTaskDetail.PackId;

            // if serial number generated by warehouse, validte sn from the table of SerailNumber
            if (IsWarehouseSN(sn))
            {
                SerialNumber serialNumber = null;
                try
                {
                    serialNumber = ServiceHelper.InboundService.GetSerialNumber(planId, skuId, packId, sn);
                }
                catch (Exception ex)
                {
                    ExceptionHelper.HandleException(ex, true,false);
                }

                if (serialNumber == null)
                {
                    FormHelper.ShowWarningDialog("扫描的仓库序列号条码不存在，请复核。");
                    return false;
                }
            }

            BillSn billSN = null;
            try
            {
                billSN = ServiceHelper.InboundService.GetBillSn(skuId, packId, sn);
            }
            catch (Exception ex)
            {
                ExceptionHelper.HandleException(ex, true, false);
            }

            if (billSN != null)
            {
                FormHelper.ShowWarningDialog("扫描的序列号条码存在于历史操作数据中，请复核。");
                return false;
            }

            return true;
        }

        private void AddSNAndRefreshListBox(string sn)
        {
            string skuNumber = _currentTaskDetail.SkuNumber;
            if (!_skuSerialNumbers.ContainsKey(skuNumber))
            {
                ArrayList snList = new ArrayList();
                _skuSerialNumbers.Add(skuNumber, snList);
            }
            ArrayList serialNumbers = _skuSerialNumbers[skuNumber];
            serialNumbers.Add(sn);

            lbSN.DataSource = null;
            lbSN.DataSource = serialNumbers;
        }

        private void leInboundPlan_EditValueChanged(object sender, EventArgs e)
        {
            LoadInboundPlanAndTask();
        }

        private bool IsReceivingComplete()
        {
            foreach (var detail in _currentTaskDetails)
            {
                if (detail.ReceivedQty != detail.Qty)
                    return false;
            }

            return true;
        }

        private void UploadReceivingResult()
        {
            DialogResult dialogResult = FormHelper.ShowQuestionDialog("所有货物核收完成，是否提交核收结果数据。");
            if (dialogResult == DialogResult.Yes)
            {
                //
            }
        }

        private void btnComplete_Click(object sender, EventArgs e)
        {
            if (!IsReceivingComplete())
            {
                FormHelper.ShowWarningDialog("部分货物尚未核收完成，请继续收货。");
                return;
            }

            UploadReceivingResult();
        }
    }
}
