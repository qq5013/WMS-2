using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;
using System.Reflection;
using Framework.UI.Template;
using Framework.UI.Template.Common;
using Framework.UI.Template.MasterDetail;
using Business.Domain.Inventory;
using NPOI.HSSF.UserModel;
using Wms.Common;
using DevExpress.XtraEditors.Controls;
using Modules.CompanyModule.Views;
using Business.Common;
using Business.Common.QueryModel;
using Modules.CountBillModule.Views;
using Business.Domain.Application;
using Business.Domain.Inventory.Views;
using Business.Domain.Inventory;
using Business.Domain.Wms;
using Business.Common.DataDictionary;
using Framework.Core.Collections;
using DevExpress.XtraEditors;
using Business.Common.Toolkit;
using Framework.Core.Exception;
using System.ServiceModel;
using Business.Common.Exception;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Base;
using System.IO;
using NPOI;
using NPOI.HPSF;
using NPOI.HSSF;
using NPOI.HSSF.UserModel;
using NPOI.POIFS;
using NPOI.Util;

namespace Modules.CountBillModule.Views
{
    public partial class CountBillEditForm : MasterEditForm
    {
        public IList<LocalDataInfo> listLocalData = new List<LocalDataInfo>();

        public CountBillEditForm()
        {
            InitializeComponent();
        }

        private void DeleteButtonClick(object sender, ButtonPressedEventArgs e)
        {
            DevExpress.XtraEditors.LookUpEdit edit = (DevExpress.XtraEditors.LookUpEdit)sender;
            if (e.Button.Kind == ButtonPredefines.Delete)
            {
                edit.EditValue = null;
            }
        }

        #region template methods
        public override void FormInitialize()
        {
            //RegisterDetailForm("Modules.CountBillModule.Views.CountBillDetailEditForm");

            base.FormInitialize();
            this.DetailGridView.CustomDrawCell += new RowCellCustomDrawEventHandler(CustomDrawCell);
        }

        private void CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column.FieldName == "CountedQty")
            {
                if ((int)e.CellValue >= 0)
                {
                    object data = this.DetailGridView.GetRow(e.RowHandle);
                    if (data != null)
                    {
                        CountBillDetail detail = data as CountBillDetail;
                        if (detail.AccountQty > detail.CountedQty)
                        {
                            e.Appearance.ForeColor = Color.Red;
                        }
                        else
                            if (detail.AccountQty < detail.CountedQty)
                            {
                                e.Appearance.ForeColor = Color.Blue;
                            }
                            else
                                 if (detail.AccountQty == detail.CountedQty)
                                     e.Appearance.ForeColor = Color.Green;
                    }
                }
            }
        }

        public override void InitInputControlData()
        {
            // bill status
            IEnumerable<DataDictionary> planStatus = CacheHelper.GetDictionaryByCategory(DictionaryEnum.COUNTBILL_BILLSTATUS.ToString());
            leBillStatus.Properties.DataSource = planStatus;
            leBillStatus.Properties.DisplayMember = "DictionaryValue";
            leBillStatus.Properties.ValueMember = "DictionaryId";
            leBillStatus.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DictionaryCode", "代码"));
            leBillStatus.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DictionaryValue", "值"));
        }

        public override void InitToolButtons()
        {
            btnConfirm.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnConfirm.Caption = @"确认盘点结果";

            btnRevoke.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnRevoke.Caption = @"撤销";

            btnAdditionButton.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnAdditionButton.Caption = @"上传盘点结果Excel";

            btnPrint.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnPrint.Caption = @"导出Excel";

            btnUpdateMaster.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
        }

        public override void AdditionButtonClick()
        {
            if (CurrentMasterData != null)
            {
                var bill = CurrentMasterData as CountBill;
                int firstCountingStatusId =  CacheHelper.GetDictionaryId((int)CountBillStatus.Created);
                int secondCountingStatusId = CacheHelper.GetDictionaryId((int)CountBillStatus.FirstCounting);
                if (bill.BillStatus != firstCountingStatusId && bill.BillStatus != secondCountingStatusId)
                {
                    FormHelper.ShowWarningDialog("当前盘点单状态不能上传盘点结果。");
                    return;
                }

                UploadCountingResult(bill);
            }
        }

        private void UploadCountingResult(CountBill bill)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Data File|*.xls";
            openFileDialog.RestoreDirectory = true;
            openFileDialog.FilterIndex = 1;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog.FileName;

                List<CountBillDetailView> details = new List<CountBillDetailView>();
                string errorMessage = string.Empty;
                using (FileStream stream = System.IO.File.OpenRead(fileName))
                {
                    details = ImportExcel(stream, 0, -1, out errorMessage);
                }

                if (errorMessage != string.Empty)
                {
                    FormHelper.ShowErrorDialog("解析盘点单结果数据失败。");
                    FormHelper.ShowErrorDialog(errorMessage);
                    return;
                }
                else
                {
                    try
                    {
                        bool uploadResult = ServiceHelper.InventoryService.UploadCountingResult(GlobalState.CurrentWarehouse.WarehouseId,
                            bill.BillId, details, GlobalState.CurrentUser.UserId);

                        if (uploadResult)
                        {
                            MessageBox.Show("上传盘点单结果数据成功。");
                            ReloadFormData();
                            return;
                        }
                        else
                        {
                            MessageBox.Show("上传盘点单结果数据失败。");
                            return;
                        }
                    }
                    catch (FaultException<ServiceError> sex)
                    {
                        if (sex.Detail != null)
                            FormHelper.ShowWarningDialog(sex.Detail.ErrorMessage);
                    }
                }
            }　
        }

        

        private List<CountBillDetailView> ImportExcel(Stream excelFileStream, int sheetIndex, int headerRowIndex, out string message)
        {
            message = string.Empty;
            List<CountBillDetailView> resultList = new List<CountBillDetailView>();
            HSSFWorkbook workbook;
            NPOI.SS.UserModel.ISheet sheet;

            //NPOI.HSSF.UserModel.HSSFSheet sheet;
            
            try
            {
                workbook = new HSSFWorkbook(excelFileStream);
                //sheet = workbook.GetSheetAt(sheetIndex);
                sheet = workbook.GetSheetAt(sheetIndex);
                
                for (int i = (sheet.FirstRowNum); i <= sheet.LastRowNum; i++)
                {
                    NPOI.SS.UserModel.IRow row = sheet.GetRow(i);
                    if (row == null || row.GetCell(0) == null || row.GetCell(0).ToString().Trim() == "")
                    {
                        // 如果遇到第一个空行，则不再继续向后读取
                        break;
                    }

                    try
                    {
                        int stockId = (int)row.GetCell(0).NumericCellValue;
                        string locationCode = row.GetCell(1).StringCellValue;
                        string containerCode = row.GetCell(2).StringCellValue;
                        string skuNumber = row.GetCell(3).StringCellValue;
                        string skuName = row.GetCell(4).StringCellValue;
                        string packName = row.GetCell(5).StringCellValue;
                        string batchNumber = row.GetCell(6).StringCellValue;
                        int accountQty = (int)row.GetCell(7).NumericCellValue;
                        int countedQty = (int)row.GetCell(8).NumericCellValue;

                        CountBillDetailView billDetail = new CountBillDetailView();
                        billDetail.StockId = stockId;
                        billDetail.LocationCode = locationCode;
                        billDetail.ContainerCode = containerCode;
                        billDetail.SkuNumber = skuNumber;
                        billDetail.SkuName = skuName;
                        billDetail.PackName = packName;
                        billDetail.BatchNumber = batchNumber;
                        billDetail.AccountQty = accountQty;
                        billDetail.CountedQty = countedQty;

                        resultList.Add(billDetail);
                    }
                    catch (Exception ex)
                    {
                        message = message + "\r\n" + string.Format("Excel数据读取失败。行号：", row.RowNum);
                    }
                }
            }
            catch (Exception ex)
            {
                message = message + "\r\n" + ex.Message;
            }
            finally
            {
                excelFileStream.Close();
                workbook = null;
                sheet = null;
            }

            return resultList;
        }

        private HSSFWorkbook hssfworkbook;
        public override void PrintData()
        {
            CountBill bill = CurrentMasterData as CountBill;
            if (bill == null)
            {
                FormHelper.ShowWarningDialog("请先选择盘点单。");
                return;
            }

            if (DetailDataList.Count <= 0)
            {
                FormHelper.ShowWarningDialog("选择的盘点单没有明细信息。");
                return;
            }

            InitializeWorkbook();
            string sheetName = "盘点单 - " + bill.BillNumber;
            NPOI.SS.UserModel.ISheet newSheet = hssfworkbook.CreateSheet();
            int rowCount = 0;

            // create head information
            NPOI.SS.UserModel.IRow headRow = newSheet.CreateRow(rowCount);
            headRow.CreateCell(0).SetCellValue("库存编号");
            headRow.CreateCell(1).SetCellValue("库位代码");
            headRow.CreateCell(2).SetCellValue("容器代码");
            headRow.CreateCell(3).SetCellValue("货物代码");
            headRow.CreateCell(4).SetCellValue("货物名称");
            headRow.CreateCell(5).SetCellValue("包装名称");
            headRow.CreateCell(6).SetCellValue("入库批次号");
            headRow.CreateCell(7).SetCellValue("账面数量");
            headRow.CreateCell(8).SetCellValue("实盘数量");

            foreach (CountBillDetailView billDetail in DetailDataList)
            {
                NPOI.SS.UserModel.IRow row = newSheet.CreateRow(rowCount);

                row.CreateCell(0).SetCellValue(billDetail.StockId);
                row.CreateCell(1).SetCellValue(billDetail.LocationCode);
                row.CreateCell(2).SetCellValue(billDetail.ContainerCode);
                row.CreateCell(3).SetCellValue(billDetail.SkuNumber);
                row.CreateCell(4).SetCellValue(billDetail.SkuName);
                row.CreateCell(5).SetCellValue(billDetail.PackName);
                row.CreateCell(6).SetCellValue(billDetail.BatchNumber);
                row.CreateCell(7).SetCellValue(billDetail.AccountQty);
                row.CreateCell(8).SetCellValue(billDetail.AccountQty);

                rowCount++;
            }

            //string fileName = string.Format("{0}.{1}.{xls}", bill.BillNumber, DateTime.Now.ToString("yyyyMMddHHmmss"));
            string fileName = bill.BillNumber + "." + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";
            WriteToFile(fileName);
        }

        private void WriteToFile(string fileName)
        {
            string folder = @"C:\Data\";
            if (Directory.Exists(folder) != true)
                Directory.CreateDirectory(folder);

            string file = Path.Combine(folder, fileName);
            FileStream stream = new FileStream(file, FileMode.Create);
            hssfworkbook.Write(stream);
            stream.Close();

            FormHelper.ShowInformationDialog(string.Format("成功导出盘点单, 数据文件：{0}。", file));
        }

        private void InitializeWorkbook()
        {
            hssfworkbook = new HSSFWorkbook();

            DocumentSummaryInformation dsi = PropertySetFactory.CreateDocumentSummaryInformation();
            dsi.Company = "WMS";
            hssfworkbook.DocumentSummaryInformation = dsi;

            //create a entry of SummaryInformation
            SummaryInformation si = PropertySetFactory.CreateSummaryInformation();
            si.Subject = "Count Bill";
            hssfworkbook.SummaryInformation = si;
        }

        public override void SetToolButtons()
        {
            base.SetToolButtons();

            // 判读当前单据状态是否可以审核
            CountBill bill = CurrentMasterData as CountBill;
            if (bill != null)
            {
                DataDictionary dictionary = ServiceHelper.ApplicationService.GetDataDictionary(bill.BillStatus);
                if (dictionary != null)
                {
                    if (dictionary.DictionaryCode != DictionaryHelper.ConvertToDictionaryCode((int)CountBillStatus.SecondCounting))
                    {
                        btnConfirm.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    }

                    if (dictionary.DictionaryCode != DictionaryHelper.ConvertToDictionaryCode((int)CountBillStatus.Created)
                        && dictionary.DictionaryCode != DictionaryHelper.ConvertToDictionaryCode((int)CountBillStatus.FirstCounting)
                        && dictionary.DictionaryCode != DictionaryHelper.ConvertToDictionaryCode((int)CountBillStatus.SecondCounting))
                    {
                        btnRevoke.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    }
                }
            }
        }

        public override bool ConfirmData()
        {
            if (CurrentMasterData != null)
            {
                var bill = CurrentMasterData as CountBill;

                if (bill != null)
                {
                    try
                    {
                        bool comfirmResult = ServiceHelper.InventoryService.ConfirmCountBill(GlobalState.CurrentWarehouse.WarehouseId, bill.BillId, GlobalState.CurrentUser.UserId);

                        if (comfirmResult)
                        {
                            CurrentMasterData = ServiceHelper.InventoryService.GetCountBill(bill.BillId);
                            SetMainData();
                            btnConfirm.Enabled = false;
                            btnUpdateMaster.Enabled = false;
                            FormHelper.ShowInformationDialog("确认盘点单成功。");
                        }
                        else
                            FormHelper.ShowWarningDialog("确认盘点单失败。");
                    }
                    catch (FaultException<ServiceError> sex)
                    {
                        if (sex.Detail != null)
                            FormHelper.ShowWarningDialog(sex.Detail.ErrorMessage);
                    }
                    
                }
            }
            return true;
        }

        public override void SetMainDataInputStatus()
        {
            switch (MasterDataState)
            {
                case DataState.Read:
                    {
                        layoutBase.Enabled = false;
                        layoutOther.Enabled = false;
                        btnConfirm.Enabled = true;
                        btnPrint.Enabled = true;
                        btnRevoke.Enabled = true;
                        break;
                    }
                case DataState.Create:
                    {
                        layoutBase.Enabled = true;
                        layoutOther.Enabled = true;
                        btnConfirm.Enabled = false;
                        btnPrint.Enabled = false;
                        btnRevoke.Enabled = false;
                        break;
                    }
                case DataState.Update:
                    {
                        layoutBase.Enabled = true;
                        layoutOther.Enabled = true;
                        btnConfirm.Enabled = false;
                        btnPrint.Enabled = false;
                        btnRevoke.Enabled = false;
                        break;
                    }
            }

            
        }

        public override void InitAuthority()
        {
            //
        }

        public override void RevokeData()
        {
            if (CurrentMasterData != null)
            {
                var bill = CurrentMasterData as CountBill;

                if (bill != null)
                {
                    try
                    {
                        bool revokeResult = ServiceHelper.InventoryService.RevokeCountBill(GlobalState.CurrentWarehouse.WarehouseId, bill.BillId, GlobalState.CurrentUser.UserId);

                        if (revokeResult)
                        {
                            CurrentMasterData = ServiceHelper.InventoryService.GetCountBill(bill.BillId);
                            SetMainData();
                            btnRevoke.Enabled = false;
                            btnUpdateMaster.Enabled = false;
                            FormHelper.ShowInformationDialog("作废盘点单成功。");
                        }
                        else
                            FormHelper.ShowWarningDialog("作废盘点单失败。");
                    }
                    catch (FaultException<ServiceError> sex)
                    {
                        if (sex.Detail != null)
                            FormHelper.ShowWarningDialog(sex.Detail.ErrorMessage);
                    }

                }
            }
        }

        public override void LoadDetailData()
        {
            if (CurrentMasterData == null) return;

            CountBill bill = CurrentMasterData as CountBill;
            if (bill != null)
            {
                List<CountBillDetailView> details = ServiceHelper.InventoryService.GetCountBillDetailView(bill.BillId);

                listLocalData = ObjCopyToLocal(details);
                DetailDataList = CollectionHelper.ToArrayList<LocalDataInfo>(listLocalData);
                BindDetailGrid();
                BindGridColumnMap();
                
            }
        }

        public override void ClearMainDataControl()
        {
            txtBillNumber.Text = string.Empty;
            dePlanCountDate.Text = string.Empty;
            deCountTime.Text = string.Empty;
            leBillStatus.EditValue = null;

            txtRemark.Text = string.Empty;
            txtCreateTime.Text = string.Empty;
            txtCreateUser.Text = string.Empty;
            txtEditTime.Text = string.Empty;
            txtEditUser.Text = string.Empty;
            txtAuditUser.Text = string.Empty;
            txtAuditTime.Text = string.Empty;
        }

        public override void ReloadData()
        {
            if (CurrentMasterData != null)
            {
                CountBill bill = CurrentMasterData as CountBill;
                CurrentMasterData = ServiceHelper.InventoryService.GetCountBill(bill.BillId);

                LoadDetailData();
            }
        }

        public override void SetMainData()
        {
            if (CurrentMasterData != null)
            {
                var bill = CurrentMasterData as CountBill;

                if (bill != null)
                {
                    this.Text = "盘点单 - " + bill.BillNumber;

                    txtBillNumber.Text = bill.BillNumber;
                  
                    dePlanCountDate.Text = bill.PlanCountDate;
                    deCountTime.Text = bill.CountTime;

                    if (bill.BillStatus > 0)
                        leBillStatus.EditValue = bill.BillStatus;

                    txtRemark.Text = bill.Remark;
                    txtCreateTime.Text = bill.CreateTime;
                    txtCreateUser.Text = CacheHelper.GetUserName(bill.CreateUser);
                    txtEditTime.Text = bill.EditTime;
                    txtEditUser.Text = CacheHelper.GetUserName(bill.EditUser);
                    txtAuditUser.Text = CacheHelper.GetUserName(bill.Auditor);
                    txtAuditTime.Text = bill.AuditTime;
                }
            }
        }

        //计算总体积 总重量 总数量
        public override void CountData()
        {
            //try
            //{
            //    int totalQuantity = 0;
            //    decimal totalVolume = 0;
            //    decimal totalWeight = 0;
            //    foreach (LocalDataInfo localInfo in listLocalData)
            //    {
            //        switch (localInfo.OperationName)
            //        {
            //            case "ADD":
            //            case "EDIT":
            //            case "NONE":
            //            case "":
            //                {
            //                    totalQuantity = totalQuantity + localInfo.Qty;
            //                    totalVolume = totalVolume + (localInfo.Qty * localInfo.PackVolume);
            //                    totalWeight = totalWeight + (localInfo.Qty * localInfo.PackWeight);
            //                }
            //                break;
            //        }
            //    }
            //    txtTotalQty.Text = totalQuantity.ToString();
            //    txtTotalVolume.Text = Decimal.Round(totalVolume, 3, MidpointRounding.AwayFromZero).ToString();
            //    txtTotalWeight.Text = Decimal.Round(totalWeight, 3, MidpointRounding.AwayFromZero).ToString();
            //}
            //catch (Exception ex)
            //{
            //    //
            //}
        }

        public override void SaveData()
        {
            //#region 保存主表数据.........
            //OutboundPlan plan = null;
            //if (MasterDataState == DataState.Create)
            //{
            //    plan = new OutboundPlan();
            //    plan.CreateUser = GlobalState.CurrentUser.UserId;
            //    plan.WarehouseId = GlobalState.CurrentWarehouse.WarehouseId;
            //}
            //if (MasterDataState == DataState.Update)
            //{
            //    plan = CurrentMasterData as OutboundPlan;
            //    if (plan != null)
            //    {
            //        plan.EditUser = GlobalState.CurrentUser.UserId;
            //    }
            //}

            //if (plan != null)
            //{
            //    plan.Remark = txtRemark.Text.Trim();
            //    plan.LinkBillNumber = txtBillNumber.Text.Trim();
            //    if (beMerchantId.Tag != null)
            //    {
            //        plan.MerchantId = ((Company)beMerchantId.Tag).CompanyId;
            //        plan.ClientId = CacheHelper.GetParentCompanyId(plan.MerchantId);
            //    }
            //    if (leOutboundType.EditValue != null)
            //        plan.OutboundType = (int)leOutboundType.EditValue;
            //    if (leLinkBillType.EditValue != null)
            //        plan.LinkBillType = (int)leLinkBillType.EditValue;
            //    if (dePlanCountDate.Text != string.Empty)
            //        plan.PlanIssueTime = TypeConvertHelper.DatetimeToString(dePlanCountDate.DateTime);
            //    if (lePriority.EditValue != null)
            //        plan.Priority = (int)lePriority.EditValue;

            //    if (MasterDataState == DataState.Create)
            //    {
            //        plan = ServiceHelper.OutboundService.CreateOutboundPlan(plan);
            //        if (plan == null)
            //        {
            //            FormHelper.ShowErrorDialog("创建出库计划失败。");
            //            return;
            //        }
            //    }
            //    if (MasterDataState == DataState.Update)
            //    {
            //        bool updateResult = ServiceHelper.OutboundService.UpdateOutboundPlan(plan);
            //        if (!updateResult)
            //        {
            //            FormHelper.ShowErrorDialog("更新出库计划失败。");
            //            return;
            //        }
                    
            //    }

            //    CurrentMasterData = plan;
            //    SetMainData();
            //}
            //#endregion

            //#region 保存从表数据.........
            //if (plan != null)
            //{
            //    foreach (LocalDataInfo localInfo in listLocalData)
            //    {
            //        switch (localInfo.OperationName)
            //        {
            //            case "ADD":
            //                {
            //                    localInfo.PlanId = plan.PlanId;//改成主键
            //                    int newID = ServiceHelper.OutboundService.AddOutboundPlanDetail(plan.PlanId, ObjCopyToParent(localInfo));
            //                    if (newID <= 0)
            //                    {
            //                        throw new Exception();
            //                    }
            //                    localInfo.OperationName = "NONE";
            //                    localInfo.Id = newID;
            //                    break;
            //                }
            //            case "EDIT":
            //                {
            //                    bool updateResult = ServiceHelper.OutboundService.UpdateOutboundPlanDetail(ObjCopyToParent(localInfo));
            //                    if (!updateResult)
            //                    {
            //                        throw new Exception();
            //                    }
            //                    localInfo.OperationName = "NONE";
            //                    break;
            //                }
            //            case "DELETE":
            //                {
            //                    bool deleteResult = ServiceHelper.OutboundService.RemoveOutboundPlanDetail(ObjCopyToParent(localInfo).Id);
            //                    if (!deleteResult)
            //                    {
            //                        throw new Exception();
            //                    }
            //                    break;
            //                }
            //        }
            //    }
            //}

            //if (MasterDataState == DataState.Create)
            //{
            //    listLocalData.Clear();
            //}

            //#endregion

            //#region 更新总数量、总体积和总重量
            //CountData();
            //#endregion
        }

        public override bool ValidateMainData()
        {
           return true;
        }

        public override void CustomizeDetailGrid()
        {
            int columnIndex = 0;

            FormHelper.SetGridColumn(DetailGridView, "Id", "", 100, columnIndex++, false);

            FormHelper.SetGridColumn(DetailGridView, "BillId", "盘点单编号", 100, columnIndex++, false);
            
            FormHelper.SetGridColumn(DetailGridView, "StockId", "库存编号", 100, columnIndex++, false);

            FormHelper.SetGridColumn(DetailGridView, "LocationId", "库位编号", 100, columnIndex++, false);

            FormHelper.SetGridColumn(DetailGridView, "LocationCode", "库位代码", 100, columnIndex++, false);

            FormHelper.SetGridColumn(DetailGridView, "LocationName", "库位名称", 100, columnIndex++, true);

            FormHelper.SetGridColumn(DetailGridView, "ContainerId", "容器编号", 100, columnIndex++, false);

            FormHelper.SetGridColumn(DetailGridView, "ContainerCode", "容器代码", 100, columnIndex++, false);

            FormHelper.SetGridColumn(DetailGridView, "ContainerName", "容器名称", 100, columnIndex++, true);

            FormHelper.SetGridColumn(DetailGridView, "SkuId", "货物编号", 100, columnIndex++, false);

            FormHelper.SetGridColumn(DetailGridView, "SkuNumber", "货物代码", 100, columnIndex++, true);

            FormHelper.SetGridColumn(DetailGridView, "SkuName", "货物名称", 100, columnIndex++, true);

            FormHelper.SetGridColumn(DetailGridView, "PackId", "包装编号", 100, columnIndex++, false);

            FormHelper.SetGridColumn(DetailGridView, "PackName", "包装名称", 100, columnIndex++, true);

            FormHelper.SetGridColumn(DetailGridView, "AccountQty", "账面数量", 100, columnIndex++, true);

            FormHelper.SetGridColumn(DetailGridView, "CountedQty", "实盘数量", 100, columnIndex++, true);

            FormHelper.SetGridColumn(DetailGridView, "BatchNumber", "入库批次号", 100, columnIndex++, true);

            FormHelper.SetGridColumn(DetailGridView, "Operator", "操作员", 100, columnIndex++, true);

     
            FormHelper.SetGridColumn(DetailGridView, "IsValid", "", 100, columnIndex++, false);
            FormHelper.SetGridColumn(DetailGridView, "TempId", "", 100, columnIndex++, false);
            FormHelper.SetGridColumn(DetailGridView, "OperationName", "", 100, columnIndex++, false);
        }

        public override void BindGridColumnMap()
        {
            DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit userLookup = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            userLookup.DataSource = CacheHelper.UserCache;
            userLookup.DisplayMember = "UserName";
            userLookup.ValueMember = "UserId";
            DetailGridView.Columns["Operator"].ColumnEdit = userLookup;
        }

        #endregion

        #region 转换对象
        /// <summary>
        /// 将本地对象的数据拷贝到远程对象
        /// </summary>
        private CountBillDetail ObjCopyToParent(LocalDataInfo localInfo)
        {
            CountBillDetail info = new CountBillDetail();

            Type ts = typeof(LocalDataInfo);
            Type t = typeof(OutboundPlanDetail);
            PropertyInfo[] pis = t.GetProperties();
            for (int i = 0, j = pis.Length; i < j; i++)
            {
                PropertyInfo pi = ts.GetProperty(pis[i].Name);
                try
                {
                    pis[i].SetValue(info, pi.GetValue(localInfo, null), null);
                }
                catch (Exception ex)
                {
                    ExceptionHelper.HandleException(ex, true, false);
                }
            }
            return info;
        }

        private IList<LocalDataInfo> ObjCopyToLocal(IList<CountBillDetailView> entyInfoList)
        {
            IList<LocalDataInfo> list = new List<LocalDataInfo>();

            Type ts = typeof(CountBillDetailView);
            PropertyInfo[] pis = ts.GetProperties();

            Type t = typeof(LocalDataInfo);

            for (int c = 0, count = entyInfoList.Count; c < count; c++)
            {
                LocalDataInfo info = new LocalDataInfo();

                for (int i = 0, j = pis.Length; i < j; i++)
                {
                    PropertyInfo pi = t.GetProperty(pis[i].Name);
                    try
                    {
                        pi.SetValue(info, pis[i].GetValue(entyInfoList[c], null), null);
                    }
                    catch (Exception ex)
                    {
                        ExceptionHelper.HandleException(ex, true, false);
                    }
                }
                info.TempId = c;
                info.OperationName = "NONE";
                list.Add(info);
            }

            return list;
        }
        #endregion
    }
}
