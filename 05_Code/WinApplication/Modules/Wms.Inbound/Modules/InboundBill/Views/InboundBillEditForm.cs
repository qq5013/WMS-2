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
using Wms.Common;
using DevExpress.XtraEditors.Controls;
using Modules.CompanyModule.Views;
using Business.Common;
using Business.Common.QueryModel;
using Business.Domain.Application;
using Business.Domain.Inventory.Views;
using Business.Domain.Wms;
using Business.Common.DataDictionary;
using Framework.Core.Collections;
using DevExpress.XtraEditors;
using Business.Common.Toolkit;
using Framework.Core.Exception;
using System.ServiceModel;
using Business.Common.Exception;
using Modules.LocationModule.Views;
using Business.Domain.Warehouse;
using Modules.UserModule.Views;
using Modules.WarehouseModule.Views;
using Modules.InboundPlanModule.Views;
using Business.Component;

namespace Modules.InboundBillModule.Views
{
    public partial class InboundBillEditForm : MasterEditForm
    {
        public IList<LocalDataInfo> listLocalData = new List<LocalDataInfo>();

        public InboundBillEditForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 单据状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            RegisterDetailForm("Modules.InboundBillModule.Views.InboundBillDetailEditForm");

            base.FormInitialize();
        }

        public override void InitInputControlData()
        {
            // bill status
            IEnumerable<DataDictionary> billStatus = CacheHelper.GetDictionaryByCategory(DictionaryEnum.INBOUNDBILL_BILLSTATUS.ToString());
            leBillStatus.Properties.DataSource = billStatus;
            leBillStatus.Properties.DisplayMember = "DictionaryValue";
            leBillStatus.Properties.ValueMember = "DictionaryId";
            leBillStatus.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DictionaryCode", "代码"));
            leBillStatus.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DictionaryValue", "值"));
        }

        public override void InitToolButtons()
        {
            btnConfirm.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnConfirm.Caption = @"确认入库";

            btnRevoke.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnRevoke.Caption = @"作废";

            btnPrint.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnPrint.Caption = @"打印单据";

            btnModify.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
        }

        public override void SetToolButtons()
        {
            base.SetToolButtons();

            // 判读当前单据状态是否可以审核
            InboundBill bill = CurrentMasterData as InboundBill;
            if (bill != null)
            {
                DataDictionary dictionary = ServiceHelper.ApplicationService.GetDataDictionary(bill.BillStatus);
                if (dictionary != null)
                {
                    if (dictionary.DictionaryCode != DictionaryHelper.ConvertToDictionaryCode((int)InboundBillStatus.Created) && dictionary.DictionaryCode != DictionaryHelper.ConvertToDictionaryCode((int)InboundBillStatus.Modified))
                    {
                        btnConfirm.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        btnUpdateMaster.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        btnRevoke.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    }
                }
            }
        }

        public override bool ConfirmData()
        {

            if (CurrentMasterData != null)
            {
                var bill = CurrentMasterData as InboundBill;

                if (bill != null)
                {
                    try
                    {
                        bool comfirmResult = ServiceHelper.InboundService.ConfirmInboundBill(GlobalState.CurrentWarehouse.WarehouseId, bill.BillId, GlobalState.CurrentUser.UserId);

                        if (comfirmResult)
                        {
                            CurrentMasterData = ServiceHelper.InboundService.GetInboundBill(bill.BillId);
                            SetMainData();
                            btnConfirm.Enabled = false;
                            btnUpdateMaster.Enabled = false;
                            FormHelper.ShowInformationDialog("确认入库单成功。");
                        }
                        else
                            FormHelper.ShowWarningDialog("确认入库单失败。");
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
            btnInsertMaster.Tag = "INBOUNDBILL_INSERT";
            btnUpdateMaster.Tag = "INBOUNDBILL_EDIT";
            btnQueryMaster.Tag = "INBOUNDBILL_QUERY";
        }

        public override void RevokeData()
        {
            if (CurrentMasterData != null)
            {
                var bill = CurrentMasterData as InboundBill;

                if (bill != null)
                {
                    try
                    {
                        bool revokeResult = ServiceHelper.InboundService.RevokeInboundBill(GlobalState.CurrentWarehouse.WarehouseId, bill.BillId, GlobalState.CurrentUser.UserId);

                        if (revokeResult)
                        {
                            CurrentMasterData = ServiceHelper.InboundService.GetInboundBill(bill.BillId);
                            SetMainData();
                            btnRevoke.Enabled = false;
                            btnUpdateMaster.Enabled = false;

                            FormHelper.ShowInformationDialog("作废入库单成功。");
                        }
                        else
                            FormHelper.ShowWarningDialog("作废入库单失败。");
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

            InboundBill bill = CurrentMasterData as InboundBill;
            if (bill != null)
            {
                List<InboundBillDetailView> details = ServiceHelper.InboundService.GetInboundBillDetailView(bill.BillId);

                listLocalData = ObjCopyToLocal(details);
                DetailDataList = CollectionHelper.ToArrayList<LocalDataInfo>(listLocalData);
                BindDetailGrid();
                BindGridColumnMap();
            }
        }

        public override void ClearMainDataControl()
        {
            bePlanId.Tag = null;
            bePlanId.Text = string.Empty;
            beReceiveLocationId.Tag = null;
            beReceiveLocationId.Text = string.Empty;
            beReceiver.Tag = null;
            beReceiver.Text = string.Empty;
            txtBillNumber.Text = string.Empty;
            txtVehicle.Text = string.Empty;
            deArrivalTime.Text = string.Empty;
            deReceiveTime.Text = string.Empty;
            txtDeliveryMan.Text = string.Empty;
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
                InboundBill bill = CurrentMasterData as InboundBill;
                CurrentMasterData = ServiceHelper.InboundService.GetInboundBill(bill.BillId);

                LoadDetailData();
            }
        }

        public override void SetMainData()
        {
            if (CurrentMasterData != null)
            {
                var bill = CurrentMasterData as InboundBill;

                if (bill != null)
                {
                    this.Text = " 入库单 - " + bill.BillNumber;

                    InboundPlan plan = ServiceHelper.InboundService.GetInboundPlan(bill.PlanId);
                    if (plan != null)
                    {
                        bePlanId.Tag = plan;
                        bePlanId.Text = plan.PlanNumber;
                    }
                    txtBillNumber.Text = bill.BillNumber;
                    txtVehicle.Text = bill.Vehicle;
                    txtDeliveryMan.Text = bill.DeliveryMan;
                    deArrivalTime.Text = bill.ArrivalTime;
                    deReceiveTime.Text = bill.ReceiveTime;

                    if (bill.Receiver > 0)
                    {
                        User user = CacheHelper.GetUser(bill.Receiver);
                        beReceiver.Tag = user;
                        beReceiver.Text = user.UserName;
                    }

                    if (bill.ReceiveLocationId > 0)
                    {
                        Location location = ServiceHelper.WarehouseService.GetLocation(bill.ReceiveLocationId);
                        if (location != null)
                        {
                            beReceiveLocationId.Tag = location;
                            beReceiveLocationId.Text = location.LocationName;
                        }
                    }

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
            try
            {
                int totalQuantity = 0;
                decimal totalVolume = 0;
                decimal totalWeight = 0;
                foreach (LocalDataInfo localInfo in listLocalData)
                {
                    switch (localInfo.OperationName)
                    {
                        case "ADD":
                        case "EDIT":
                        case "NONE":
                        case "":
                            {
                                totalQuantity = totalQuantity + localInfo.Qty;
                                totalVolume = totalVolume + (localInfo.Qty * localInfo.PackVolume);
                                totalWeight = totalWeight + (localInfo.Qty * localInfo.PackWeight);
                            }
                            break;
                    }
                }
                txtTotalQty.Text = totalQuantity.ToString();
                txtTotalVolume.Text = Decimal.Round(totalVolume, 3, MidpointRounding.AwayFromZero).ToString();
                txtTotalWeight.Text = Decimal.Round(totalWeight, 3, MidpointRounding.AwayFromZero).ToString();
            }
            catch (Exception ex)
            {
                ExceptionHelper.HandleException(ex, true, false);
            }
        }

        public override void SaveData()
        {
            try
            {
                #region 保存主表数据.........
                InboundBill bill = null;
                if (MasterDataState == DataState.Create)
                {
                    bill = new InboundBill();
                    bill.BillStatus = CacheHelper.GetDictionaryId((int)InboundBillStatus.Created);
                    bill.CreateUser = GlobalState.CurrentUser.UserId;
                    bill.WarehouseId = GlobalState.CurrentWarehouse.WarehouseId;
                }
                if (MasterDataState == DataState.Update)
                {
                    bill = CurrentMasterData as InboundBill;
                    if (bill != null)
                    {
                        bill.EditUser = GlobalState.CurrentUser.UserId;
                    }
                }

                if (bill != null)
                {
                    bill.Remark = txtRemark.Text.Trim();
                    bill.Vehicle = txtVehicle.Text.Trim();
                    if (deArrivalTime.Text != string.Empty)
                        bill.ArrivalTime = TypeConvertHelper.DatetimeToString(deArrivalTime.DateTime);
                    if (deReceiveTime.Text != string.Empty)
                        bill.ReceiveTime = TypeConvertHelper.DatetimeToString(deReceiveTime.DateTime);
                    if (bePlanId.Tag != null)
                    {
                        bill.PlanId = ((InboundPlan)bePlanId.Tag).PlanId;
                        bill.ClientId = ((InboundPlan)bePlanId.Tag).ClientId;
                        bill.MerchantId = ((InboundPlan)bePlanId.Tag).MerchantId;
                        bill.VendorId = ((InboundPlan)bePlanId.Tag).VendorId;
                    }
                    if (beReceiver.Tag != null)
                        bill.Receiver = ((User)beReceiver.Tag).UserId;
                    bill.DeliveryMan = txtDeliveryMan.Text.Trim();
                    if (beReceiveLocationId.Tag != null)
                        bill.ReceiveLocationId = ((Location)beReceiveLocationId.Tag).LocationId;

                    if (MasterDataState == DataState.Create)
                    {
                        try
                        {
                            bill = ServiceHelper.InboundService.CreateInboundBill(bill);
                        }
                        catch (FaultException<ServiceError> sex)
                        {
                            if (sex.Detail != null)
                                FormHelper.ShowWarningDialog(sex.Detail.ErrorMessage);
                        }

                        if (bill == null)
                        {
                            FormHelper.ShowErrorDialog("创建入库单失败。");
                            return;
                        }
                    }
                    if (MasterDataState == DataState.Update)
                    {
                        bool updateResult = true;
                        try
                        {
                            updateResult = ServiceHelper.InboundService.UpdateInboundBill(bill);
                        }
                        catch (FaultException<ServiceError> sex)
                        {
                            if (sex.Detail != null)
                                FormHelper.ShowWarningDialog(sex.Detail.ErrorMessage);
                        }

                        if (!updateResult)
                        {
                            FormHelper.ShowErrorDialog("更新入库单失败。");
                            return;
                        }

                    }

                    CurrentMasterData = bill;
                    SetMainData();
                }
                #endregion

                #region 保存从表数据.........
                if (bill != null)
                {
                    foreach (LocalDataInfo localInfo in listLocalData)
                    {
                        switch (localInfo.OperationName)
                        {
                            case "ADD":
                                {
                                    localInfo.BillId = bill.BillId;//改成主键
                                    int newID = ServiceHelper.InboundService.AddInboundBillDetail(bill.BillId, ObjCopyToParent(localInfo));
                                    if (newID <= 0)
                                    {
                                        throw new Exception();
                                    }
                                    localInfo.OperationName = "NONE";
                                    localInfo.Id = newID;
                                    break;
                                }
                            case "EDIT":
                                {
                                    bool updateResult = ServiceHelper.InboundService.UpdateInboundBillDetail(ObjCopyToParent(localInfo));

                                    if (!updateResult)
                                    {
                                        throw new Exception();
                                    }
                                    localInfo.OperationName = "NONE";
                                    break;
                                }
                            case "DELETE":
                                {
                                    bool deleteResult = ServiceHelper.InboundService.RemoveInboundBillDetail(ObjCopyToParent(localInfo).Id);
                                    if (!deleteResult)
                                    {
                                        throw new Exception();
                                    }
                                    break;
                                }
                        }

                        //if (localInfo.SerialNumbers.Count > 0)
                        //{
                        //    int WarehouseId = GlobalState.CurrentWarehouse.WarehouseId;
                        //    //ServiceHelper.InboundService.AddBillSN(WarehouseId, BillType.InboundBill, bill.BillId, localInfo.SkuId, localInfo.PackId, localInfo.BatchNumber, localInfo.SerialNumbers);
                        //}
                    }
                }

                if (MasterDataState == DataState.Create)
                {
                    listLocalData.Clear();
                }

                #endregion
            }
            catch (FaultException<ServiceError> sex)
            {
                if (sex.Detail != null)
                    FormHelper.ShowWarningDialog(sex.Detail.ErrorMessage);
            }

            #region 更新总数量、总体积和总重量
            CountData();
            #endregion
        }

        public override void DeleteLocalData()
        {
            if (CurrentDetailData == null) return;

            LocalDataInfo localInfo = CurrentDetailData as LocalDataInfo;

            DetailDataList.Remove(localInfo);

            if (localInfo != null)
                if (localInfo.OperationName == "ADD")
                {
                    listLocalData.Remove(localInfo);
                }
                else
                {
                    localInfo.OperationName = "DELETE";
                    listLocalData[localInfo.TempId] = localInfo;
                }
        }

        public override bool ValidateUpdateOperation()
        {
            InboundBill bill = CurrentMasterData as InboundBill;
            if (bill != null)
            {
                DataDictionary dictionary = ServiceHelper.ApplicationService.GetDataDictionary(bill.BillStatus);
                if (dictionary != null)
                {
                    if (dictionary.DictionaryCode != DictionaryHelper.ConvertToDictionaryCode((int)InboundBillStatus.Created) && dictionary.DictionaryCode != DictionaryHelper.ConvertToDictionaryCode((int)InboundBillStatus.Modified))
                    {
                        FormHelper.ShowWarningDialog("此入库单当前状态不允许被编辑。");
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// 必选项验证
        /// </summary>
        /// <returns></returns>
        public override bool ValidateMainData()
        {
            Validator.Clear();
            bool result = true;

            if (bePlanId.Tag == null)
            {
                Validator.SetError(bePlanId, "请选择入库计划单号。");
                result = false;
            }

            if (beReceiveLocationId.Tag == null)
            {
                Validator.SetError(beReceiveLocationId, "请选择收货库位。");
                result = false;
            }

            if (deArrivalTime.Text.Trim() == string.Empty)
            {
                Validator.SetError(deArrivalTime, "请选择到仓时间。");
                result = false;
            }

            if (beReceiver.Tag == null)
            {
                Validator.SetError(beReceiver, "请选择收货人。");
                result = false;
            } 

            if (deReceiveTime.Text.Trim() == string.Empty)
            {
                Validator.SetError(deReceiveTime, "请选择收货时间。");
                result = false;
            }

            return result;
        }

        /// <summary>
        /// 入库单明细容器
        /// </summary>
        public override void CustomizeDetailGrid()
        {
            int columnIndex = 0;

            FormHelper.SetGridColumn(DetailGridView, "Id", "", 100, columnIndex++, false);
            FormHelper.SetGridColumn(DetailGridView, "PlanId", "", 100, columnIndex++, false);
            FormHelper.SetGridColumn(DetailGridView, "BillId", "", 100, columnIndex++, false);
            FormHelper.SetGridColumn(DetailGridView, "SkuId", "", 100, columnIndex++, false);
            FormHelper.SetGridColumn(DetailGridView, "SkuNumber", "货物编号", 100, columnIndex++, true);
            FormHelper.SetGridColumn(DetailGridView, "SkuName", "货物名称", 100, columnIndex++, true);
            FormHelper.SetGridColumn(DetailGridView, "PackId", "", 100, columnIndex++, false);
            FormHelper.SetGridColumn(DetailGridView, "PackName", "包装", 100, columnIndex++, true);
            FormHelper.SetGridColumn(DetailGridView, "Qty", "库存数量", 100, columnIndex++, true);
            FormHelper.SetGridColumn(DetailGridView, "BatchNumber", "入库批次", 100, columnIndex++, true);
            FormHelper.SetGridColumn(DetailGridView, "ContainerId", "", 100, columnIndex++, false);
            FormHelper.SetGridColumn(DetailGridView, "ContainerName", "周转/存储容器", 100, columnIndex++, true);
            FormHelper.SetGridColumn(DetailGridView, "SerialNumbers", "", 100, columnIndex++, false);
            FormHelper.SetGridColumn(DetailGridView, "PackVolume", "包装体积", 100, columnIndex++, true);
            FormHelper.SetGridColumn(DetailGridView, "PackWeight", "包装重量", 100, columnIndex++, true);

            FormHelper.SetGridColumn(DetailGridView, "IsValid", "", 100, columnIndex++, false);
            FormHelper.SetGridColumn(DetailGridView, "TempId", "", 100, columnIndex++, false);
            FormHelper.SetGridColumn(DetailGridView, "OperationName", "", 100, columnIndex++, false);
        }
        #endregion

        #region 转换对象
        /// <summary>
        /// 将本地对象的数据拷贝到远程对象
        /// </summary>
        private InboundBillDetail ObjCopyToParent(LocalDataInfo localInfo)
        {
            InboundBillDetail info = new InboundBillDetail();

            Type ts = typeof(LocalDataInfo);
            Type t = typeof(InboundBillDetail);
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

        private IList<LocalDataInfo> ObjCopyToLocal(IList<InboundBillDetailView> entyInfoList)
        {
            IList<LocalDataInfo> list = new List<LocalDataInfo>();

            Type ts = typeof(InboundBillDetailView);
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

        /// <summary>
        /// 公司选择（供应商、客户、商家）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectCompany_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            DevExpress.XtraEditors.ButtonEdit edit = (DevExpress.XtraEditors.ButtonEdit)sender;
            if (e.Button.Kind == ButtonPredefines.Delete)
            {
                edit.Tag = null;
                edit.Text = string.Empty;
                return;
            }
            
            Form parentForm = new DevExpress.XtraEditors.XtraForm();
            parentForm.AutoSize = true;
            parentForm.StartPosition = FormStartPosition.CenterScreen;
            parentForm.ControlBox = false;
            parentForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            CompanyListForm form = new CompanyListForm(FormMode.Select, false);
            form.Size = new System.Drawing.Size(810, 600);
            form.Parent = parentForm;
            form.ReferenceForm = parentForm;
            parentForm.ShowDialog();
            IList companys = form.GetSelectedData<Company>();
            if (companys != null && companys.Count > 0)
            {
                Company company = companys[0] as Company;
                ((ButtonEdit)sender).Tag = company;
                ((ButtonEdit)sender).Text = company.ShortName;
            }
        }

        /// <summary>
        /// 入库计划编号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bePlanId_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            DevExpress.XtraEditors.ButtonEdit edit = (DevExpress.XtraEditors.ButtonEdit)sender;
            if (e.Button.Kind == ButtonPredefines.Delete)
            {
                edit.Tag = null;
                edit.Text = string.Empty;
                return;
            }

            Form parentForm = new DevExpress.XtraEditors.XtraForm();
            parentForm.AutoSize = true;
            parentForm.StartPosition = FormStartPosition.CenterScreen;
            parentForm.ControlBox = false;
            parentForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            InboundPlanListForm form = new InboundPlanListForm(FormMode.Select, false, InboundPlanStatus.Confirmed);
            form.Size = new System.Drawing.Size(810, 600);
            form.Parent = parentForm;
            form.ReferenceForm = parentForm;
            parentForm.ShowDialog();
            IList inboundplans = form.GetSelectedData<InboundPlan>();
            if (inboundplans != null && inboundplans.Count > 0)
            {
                InboundPlan inboundplan = inboundplans[0] as InboundPlan;

                bePlanId.Tag = inboundplan;
                bePlanId.Text = inboundplan.PlanNumber;
            }
        }

        /// <summary>
        /// 收货库位
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void beReceiveLocationId_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            DevExpress.XtraEditors.ButtonEdit edit = (DevExpress.XtraEditors.ButtonEdit)sender;
            if (e.Button.Kind == ButtonPredefines.Delete)
            {
                edit.Tag = null;
                edit.Text = string.Empty;
                return;
            }

            Form parentForm = new DevExpress.XtraEditors.XtraForm();
            parentForm.AutoSize = true;
            parentForm.StartPosition = FormStartPosition.CenterScreen;
            parentForm.ControlBox = false;
            parentForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            DataDictionary areaTypeDictionary = ServiceHelper.ApplicationService.GetDataDictionaryByCode(GlobalState.ApplicationCode,  DictionaryHelper.ConvertToDictionaryCode((int)AreaType.Receiving));
            int areaTypeId = 0;
            if (areaTypeDictionary != null) areaTypeId = areaTypeDictionary.DictionaryId;
            LocationListForm form = new LocationListForm(FormMode.Select, false, areaTypeId);
            form.Size = new System.Drawing.Size(810, 600);
            form.Parent = parentForm;
            form.ReferenceForm = parentForm;
            parentForm.ShowDialog();
            IList locations = form.GetSelectedData<Location>();
            if (locations != null && locations.Count > 0)
            {
                Location Location = locations[0] as Location;
                ((ButtonEdit)sender).Tag = Location;
                ((ButtonEdit)sender).Text = Location.LocationName;
            }
        }

        /// <summary>
        /// 用户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectUser_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            DevExpress.XtraEditors.ButtonEdit edit = (DevExpress.XtraEditors.ButtonEdit)sender;
            if (e.Button.Kind == ButtonPredefines.Delete)
            {
                edit.Tag = null;
                edit.Text = string.Empty;
                return;
            }

            Form parentForm = new DevExpress.XtraEditors.XtraForm();
            parentForm.AutoSize = true;
            parentForm.StartPosition = FormStartPosition.CenterScreen;
            parentForm.ControlBox = false;
            parentForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            UserListForm form = new UserListForm(FormMode.Select, false);
            form.Size = new System.Drawing.Size(810, 600);
            form.Parent = parentForm;
            form.ReferenceForm = parentForm;
            parentForm.ShowDialog();
            IList users = form.GetSelectedData<User>();
            if (users != null && users.Count > 0)
            {
                User user = users[0] as User;
                ((ButtonEdit)sender).Tag = user;
                ((ButtonEdit)sender).Text = user.UserName;
            }
        }
    }
}
