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
using Modules.InboundPlanModule.Views;
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
using Modules.InboundPlanModule.Reports;
using Business.Domain.Report;

namespace Modules.InboundPlanModule.Views
{
    public partial class InboundPlanEditForm : MasterEditForm
    {
        public IList<LocalDataInfo> listLocalData = new List<LocalDataInfo>();

        public InboundPlanEditForm()
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
            RegisterDetailForm("Modules.InboundPlanModule.Views.InboundPlanDetailEditForm");

            base.FormInitialize();
        }

        public override void InitInputControlData()
        {
            // inbound type
            IEnumerable<DataDictionary> inboundTypes = CacheHelper.GetDictionaryByCategory(DictionaryEnum.INBOUND_TYPE.ToString());
            leInboundType.Properties.DataSource = inboundTypes;
            leInboundType.Properties.DisplayMember = "DictionaryValue";
            leInboundType.Properties.ValueMember = "DictionaryId";
            leInboundType.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DictionaryCode", "代码"));
            leInboundType.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DictionaryValue", "值"));

            // bill status
            IEnumerable<DataDictionary> billStatus = CacheHelper.GetDictionaryByCategory(DictionaryEnum.INBOUNDPLAN_BILLSTATUS.ToString());
            leBillStatus.Properties.DataSource = billStatus;
            leBillStatus.Properties.DisplayMember = "DictionaryValue";
            leBillStatus.Properties.ValueMember = "DictionaryId";
            leBillStatus.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DictionaryCode", "代码"));
            leBillStatus.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DictionaryValue", "值"));

            IEnumerable<DataDictionary> billTypes = CacheHelper.GetDictionaryByCategory(DictionaryEnum.INBOUND_BILLTYPE.ToString());
            leLinkBillType.Properties.DataSource = billTypes;
            leLinkBillType.Properties.DisplayMember = "DictionaryValue";
            leLinkBillType.Properties.ValueMember = "DictionaryId";
            leLinkBillType.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DictionaryCode", "代码"));
            leLinkBillType.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DictionaryValue", "值"));

            IEnumerable<DataDictionary> priorities = CacheHelper.GetDictionaryByCategory(DictionaryEnum.PRIORITY.ToString());
            lePriority.Properties.DataSource = priorities;
            lePriority.Properties.DisplayMember = "DictionaryValue";
            lePriority.Properties.ValueMember = "DictionaryId";
            lePriority.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DictionaryCode", "代码"));
            lePriority.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DictionaryValue", "值"));
        }

        public override void InitToolButtons()
        {
            //btnCancel.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            //btnCancel.Caption = @"撤销";

            btnConfirm.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnConfirm.Caption = @"审核";

            btnRevoke.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnRevoke.Caption = @"作废";

            btnPrint.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnPrint.Caption = "打印单据";

            btnGenerateBill.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnGenerateBill.Caption = "关闭收货";

            btnAdditionButton.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnAdditionButton.Caption = "快捷打印条码标签"; 
        }

        public override void AdditionButtonClick()
        {
            InboundPlan plan = CurrentMasterData as InboundPlan;
            if (plan != null)
            {
                PrintSkuLabelForm form = new PrintSkuLabelForm();
                form.CurrentInboundPlan = plan;
                form.Show();
            }
        }

        // close partial received inbound plan
        public override void GenerateBill()
        {
            DialogResult dialogResult = MessageBox.Show("是否关闭此入库计划？", "问题", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (dialogResult == System.Windows.Forms.DialogResult.No)
                return;

            if (CurrentMasterData != null)
            {
                var plan = CurrentMasterData as InboundPlan;

                if (plan != null)
                {
                    try
                    {
                        bool closeResult = ServiceHelper.InboundService.CloseInboundPlan(GlobalState.CurrentWarehouse.WarehouseId, plan.PlanId, GlobalState.CurrentUser.UserId);

                        if (closeResult)
                        {
                            CurrentMasterData = ServiceHelper.InboundService.GetInboundPlan(plan.PlanId);
                            SetMainData();
                            btnConfirm.Enabled = false;
                            btnUpdateMaster.Enabled = false;
                            btnGenerateBill.Enabled = false;
                        }
                    }
                    catch (FaultException<ServiceError> sex)
                    {
                        if (sex.Detail != null)
                            FormHelper.ShowWarningDialog(sex.Detail.ErrorMessage);
                    }
                }
            }
            return;
        }

        public override void SetToolButtons()
        {
            base.SetToolButtons();

            // 判读当前单据状态是否可以审核
            InboundPlan plan = CurrentMasterData as InboundPlan;
            if (plan != null)
            {
                DataDictionary dictionary = ServiceHelper.ApplicationService.GetDataDictionary(plan.BillStatus);
                if (dictionary != null)
                {
                    if (dictionary.DictionaryCode != DictionaryHelper.ConvertToDictionaryCode((int)InboundPlanStatus.Created) && dictionary.DictionaryCode != DictionaryHelper.ConvertToDictionaryCode((int)InboundPlanStatus.Modified))
                    {
                        btnConfirm.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        btnUpdateMaster.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    }

                    if (dictionary.DictionaryCode != DictionaryHelper.ConvertToDictionaryCode((int)InboundPlanStatus.Created) && dictionary.DictionaryCode != DictionaryHelper.ConvertToDictionaryCode((int)InboundPlanStatus.Modified)
                        && dictionary.DictionaryCode != DictionaryHelper.ConvertToDictionaryCode((int)InboundPlanStatus.Confirmed))
                    {
                        btnRevoke.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    }

                    if (dictionary.DictionaryCode != DictionaryHelper.ConvertToDictionaryCode((int)InboundPlanStatus.PartialReceived))
                    {
                        btnGenerateBill.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    }
                    else
                        btnGenerateBill.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                }
            }
        }

        public override bool ConfirmData()
        {
            if (CurrentMasterData != null)
            {
                var plan = CurrentMasterData as InboundPlan;

                if (plan != null)
                {
                    try
                    {
                        bool comfirmResult = ServiceHelper.InboundService.ConfirmInboundPlan(GlobalState.CurrentWarehouse.WarehouseId, plan.PlanId, GlobalState.CurrentUser.UserId);

                        if (comfirmResult)
                        {
                            CurrentMasterData = ServiceHelper.InboundService.GetInboundPlan(plan.PlanId);
                            SetMainData();
                            btnConfirm.Enabled = false;
                            btnUpdateMaster.Enabled = false;
                            FormHelper.ShowInformationDialog("审核入库计划成功。");
                        }
                        else
                            FormHelper.ShowWarningDialog("审核入库计划失败。");
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
            btnInsertMaster.Tag = "INBOUNDPLAN_INSERT";
            btnUpdateMaster.Tag = "INBOUNDPLAN_EDIT";
            btnQueryMaster.Tag = "INBOUNDPLAN_QUERY";
        }

        public override void RevokeData()
        {
            if (CurrentMasterData != null)
            {
                var plan = CurrentMasterData as InboundPlan;

                if (plan != null)
                {
                    try
                    {
                        bool revokeResult = ServiceHelper.InboundService.RevokeInboundPlan(GlobalState.CurrentWarehouse.WarehouseId, plan.PlanId, GlobalState.CurrentUser.UserId);

                        if (revokeResult)
                        {
                            CurrentMasterData = ServiceHelper.InboundService.GetInboundPlan(plan.PlanId);
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

            InboundPlan plan = CurrentMasterData as InboundPlan;
            if (plan != null)
            {
                List<InboundPlanDetailView> details = ServiceHelper.InboundService.GetInboundPlanDetailView(plan.PlanId);

                listLocalData = ObjCopyToLocal(details);
                DetailDataList = CollectionHelper.ToArrayList<LocalDataInfo>(listLocalData);
                BindDetailGrid();
                BindGridColumnMap();
                
            }
        }

        public override void ClearMainDataControl()
        {
            txtPlanNumber.Text = string.Empty;
            txtLinkBillNumber.Text = string.Empty;
            leInboundType.EditValue = null;
            leLinkBillType.EditValue = null;
            dePlanReceiveTime.Text = string.Empty;
            lePriority.EditValue = null;
            beClientId.Tag = null;
            beClientId.Text = string.Empty;
            beMerchantId.Tag = null;
            beMerchantId.Text = string.Empty;
            beVendorId.Tag = null;
            beVendorId.Text = string.Empty;
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
                InboundPlan plan = CurrentMasterData as InboundPlan;
                CurrentMasterData = ServiceHelper.InboundService.GetInboundPlan(plan.PlanId);

                LoadDetailData();
            }
        }

        public override void SetMainData()
        {
            if (CurrentMasterData != null)
            {
                var plan = CurrentMasterData as InboundPlan;

                if (plan != null)
                {
                    this.Text = " 入库计划 - " + plan.PlanNumber;

                    txtPlanNumber.Text = plan.PlanNumber;
                    txtLinkBillNumber.Text = plan.LinkBillNumber;
                    if (plan.InboundType > 0)
                        leInboundType.EditValue = plan.InboundType;
                    if (plan.LinkBillType > 0)
                        leLinkBillType.EditValue = plan.LinkBillType;

                    dePlanReceiveTime.Text = plan.PlanReceiveTime;
                    if (plan.Priority > 0)
                        lePriority.EditValue = plan.Priority;

                    if (plan.ClientId > 0)
                    {
                        Company company = CacheHelper.GetCompany(plan.ClientId);
                        beClientId.Tag = company;
                        beClientId.Text = company.ShortName;
                    }
                    if (plan.MerchantId > 0)
                    {
                        Company company = CacheHelper.GetCompany(plan.MerchantId);
                        beMerchantId.Tag = company;
                        beMerchantId.Text = company.ShortName;
                    }
                    if (plan.VendorId > 0)
                    {
                        Company company = CacheHelper.GetCompany(plan.VendorId);
                        beVendorId.Tag = company;
                        beVendorId.Text = company.ShortName;
                    }

                    if (plan.BillStatus > 0)
                        leBillStatus.EditValue = plan.BillStatus;

                    txtRemark.Text = plan.Remark;
                    txtCreateTime.Text = plan.CreateTime;
                    txtCreateUser.Text = CacheHelper.GetUserName(plan.CreateUser);
                    txtEditTime.Text = plan.EditTime;
                    txtEditUser.Text = CacheHelper.GetUserName(plan.EditUser);
                    txtAuditUser.Text = CacheHelper.GetUserName(plan.Auditor);
                    txtAuditTime.Text = plan.AuditTime;
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
                //
            }
        }

        public override void SaveData()
        {
            #region 保存主表数据.........
            InboundPlan plan = null;
            if (MasterDataState == DataState.Create)
            {
                plan = new InboundPlan();
                plan.BillStatus = CacheHelper.GetDictionaryId((int)InboundPlanStatus.Created);
                plan.CreateUser = GlobalState.CurrentUser.UserId;
                plan.WarehouseId = GlobalState.CurrentWarehouse.WarehouseId;
            }
            if (MasterDataState == DataState.Update)
            {
                plan = CurrentMasterData as InboundPlan;
                if (plan != null)
                {
                    plan.EditUser = GlobalState.CurrentUser.UserId;
                }
            }

            if (plan != null)
            {
                plan.Remark = txtRemark.Text.Trim();
                plan.LinkBillNumber = txtLinkBillNumber.Text.Trim();
                //if (beClientId.Tag != null)
                //    plan.ClientId = ((Company)beClientId.Tag).CompanyId;
                if (beMerchantId.Tag != null)
                {
                    plan.MerchantId = ((Company)beMerchantId.Tag).CompanyId;
                    plan.ClientId = CacheHelper.GetParentCompanyId(plan.MerchantId);
                }
                if (beVendorId.Tag != null)
                    plan.VendorId = ((Company)beVendorId.Tag).CompanyId;
                if (leInboundType.EditValue != null)
                    plan.InboundType = (int)leInboundType.EditValue;
                if (leLinkBillType.EditValue != null)
                    plan.LinkBillType = (int)leLinkBillType.EditValue;
                if (dePlanReceiveTime.Text != string.Empty)
                    plan.PlanReceiveTime = TypeConvertHelper.DatetimeToString(dePlanReceiveTime.DateTime);
                if (lePriority.EditValue != null)
                    plan.Priority = (int)lePriority.EditValue;

                if (MasterDataState == DataState.Create)
                {
                    plan = ServiceHelper.InboundService.CreateInboundPlan(plan);
                    if (plan == null)
                    {
                        FormHelper.ShowErrorDialog("创建入库计划失败。");
                        return;
                    }
                }
                if (MasterDataState == DataState.Update)
                {
                    bool updateResult = ServiceHelper.InboundService.UpdateInboundPlan(plan);
                    if (!updateResult)
                    {
                        FormHelper.ShowErrorDialog("更新入库计划失败。");
                        return;
                    }
                    
                }

                CurrentMasterData = plan;
                SetMainData();
            }
            #endregion

            #region 保存从表数据.........
            if (plan != null)
            {
                foreach (LocalDataInfo localInfo in listLocalData)
                {
                    switch (localInfo.OperationName)
                    {
                        case "ADD":
                            {
                                localInfo.PlanId = plan.PlanId;//改成主键
                                int newID = ServiceHelper.InboundService.AddInboundPlanDetail(plan.PlanId, ObjCopyToParent(localInfo));
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
                                bool updateResult = ServiceHelper.InboundService.UpdateInboundPlanDetail(ObjCopyToParent(localInfo));
                                if (!updateResult)
                                {
                                    throw new Exception();
                                }
                                localInfo.OperationName = "NONE";
                                break;
                            }
                        case "DELETE":
                            {
                                bool deleteResult = ServiceHelper.InboundService.RemoveInboundPlanDetail(ObjCopyToParent(localInfo).Id);
                                if (!deleteResult)
                                {
                                    throw new Exception();
                                }
                                break;
                            }
                    }
                }
            }

            if (MasterDataState == DataState.Create)
            {
                listLocalData.Clear();
            }

            #endregion

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
            InboundPlan plan = CurrentMasterData as InboundPlan;
            if (plan != null)
            {
                DataDictionary dictionary = ServiceHelper.ApplicationService.GetDataDictionary(plan.BillStatus);
                if (dictionary != null)
                {
                    if (dictionary.DictionaryCode != DictionaryHelper.ConvertToDictionaryCode((int)InboundPlanStatus.Created) && dictionary.DictionaryCode != DictionaryHelper.ConvertToDictionaryCode((int)InboundPlanStatus.Modified))
                    {
                        FormHelper.ShowWarningDialog("此入库计划当前状态不允许被编辑。");
                        return false;
                    }
                }
            }

            return true;
        }

        public override bool ValidateMainData()
        {
            Validator.Clear();
            bool result = true;

            if (leInboundType.EditValue == null)
            {
                string tipa = "请选择入库类型。";
                Validator.SetError(leInboundType, tipa);
                result = false;
            }

            //if (beClientId.Tag == null)
            //{
            //    string tipa = "请选择客户。";
            //    Validator.SetError(beClientId, tipa);
            //    result = false;
            //}

            if (beMerchantId.Tag == null)
            {
                string tipa = "请选择货主。";
                Validator.SetError(beMerchantId, tipa);
                result = false;
            }

            if (dePlanReceiveTime.Text == "")
            {
                Validator.SetError(dePlanReceiveTime, "请选择计划收货日期。");
                result = false;
            }

            return result;
        }

        public override void CustomizeDetailGrid()
        {
            int comlumnIndex = 0;

            FormHelper.SetGridColumn(DetailGridView, "Id", "", 100, comlumnIndex++, false);
            FormHelper.SetGridColumn(DetailGridView, "PlanId", "入库计划编号", 100, comlumnIndex++, false);
            FormHelper.SetGridColumn(DetailGridView, "SkuId", "", 100, comlumnIndex++, false);
            FormHelper.SetGridColumn(DetailGridView, "SkuNumber", "货物代码", 100, comlumnIndex++, true);
            FormHelper.SetGridColumn(DetailGridView, "SkuName", "货物名称", 100, comlumnIndex++, true);
            FormHelper.SetGridColumn(DetailGridView, "PackId", "", 100, comlumnIndex++, false);
            FormHelper.SetGridColumn(DetailGridView, "PackName", "包装", 100, comlumnIndex++, true);
            FormHelper.SetGridColumn(DetailGridView, "Qty", "计划数量", 100, comlumnIndex++, true);
            FormHelper.SetGridColumn(DetailGridView, "ReceivedQty", "已入库数量", 100, comlumnIndex++, true);
            FormHelper.SetGridColumn(DetailGridView, "PackVolume", "包装体积", 100, comlumnIndex++, true);
            FormHelper.SetGridColumn(DetailGridView, "PackWeight", "包装重量", 100, comlumnIndex++, true);

            FormHelper.SetGridColumn(DetailGridView, "IsValid", "", 100, comlumnIndex++, false);
            FormHelper.SetGridColumn(DetailGridView, "TempId", "", 100, comlumnIndex++, false);
            FormHelper.SetGridColumn(DetailGridView, "OperationName", "", 100, comlumnIndex++, false);
        }
        #endregion

        #region 转换对象
        /// <summary>
        /// 将本地对象的数据拷贝到远程对象
        /// </summary>
        private InboundPlanDetail ObjCopyToParent(LocalDataInfo localInfo)
        {
            InboundPlanDetail info = new InboundPlanDetail();

            Type ts = typeof(LocalDataInfo);
            Type t = typeof(InboundPlanDetail);
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

        private IList<LocalDataInfo> ObjCopyToLocal(IList<InboundPlanDetailView> entyInfoList)
        {
            IList<LocalDataInfo> list = new List<LocalDataInfo>();

            Type ts = typeof(InboundPlanDetailView);
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

        private void SelectCompany_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            DevExpress.XtraEditors.ButtonEdit edit = (DevExpress.XtraEditors.ButtonEdit)sender;
            if (e.Button.Kind == ButtonPredefines.Delete)
            {
                edit.EditValue = null;
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

        public override void PrintData()
        {
            //打印入库计划
            InboundPlan plan = CurrentMasterData as InboundPlan;
            if (plan == null) return;
            InboundPlanReportEntity reportEntity = ServiceHelper.InboundService.GetInboundPlanReport(plan.PlanId, GlobalState.CurrentUser.UserId);
            if (reportEntity == null)
            {
                FormHelper.ShowWarningDialog("获取入库计划报表数据失败。");
                return;
            }

            InboundPlanReport report = new InboundPlanReport();

            // set merchant information 
            report.lblCompanyName.Text = reportEntity.LogisticsCompanyName;
            report.lblBillType.Text = reportEntity.BillType;
            report.lblContactInformationData.Text = reportEntity.ContactInformation;
            report.lblOwnerNameData.Text = reportEntity.OwnerName;
            report.lblPrintOperatorData.Text = reportEntity.PrintOperator;
            report.lblPrintTimeData.Text = reportEntity.PrintTime;
            report.lblRemarkData.Text = reportEntity.Remark;
            report.lblWarehouseName.Text = reportEntity.WarehouseName;

            if (reportEntity.Details.Count > 0)
            {
                report.DataSource = reportEntity.Details;
            }
            report.ShowPreviewDialog();
        }
    }
}
