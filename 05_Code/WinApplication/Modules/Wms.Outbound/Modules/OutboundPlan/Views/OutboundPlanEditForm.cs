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
using Modules.OutboundPlanModule.Views;
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

namespace Modules.OutboundPlanModule.Views
{
    public partial class OutboundPlanEditForm : MasterEditForm
    {
        public IList<LocalDataInfo> listLocalData = new List<LocalDataInfo>();

        public OutboundPlanEditForm()
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
            RegisterDetailForm("Modules.OutboundPlanModule.Views.OutboundPlanDetailEditForm");

            base.FormInitialize();
        }

        public override void InitInputControlData()
        {
            // outbound type
            IEnumerable<DataDictionary> outboundTypes = CacheHelper.GetDictionaryByCategory(DictionaryEnum.OUTBOUND_TYPE.ToString());
            leOutboundType.Properties.DataSource = outboundTypes;
            leOutboundType.Properties.DisplayMember = "DictionaryValue";
            leOutboundType.Properties.ValueMember = "DictionaryId";
            leOutboundType.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DictionaryCode", "代码"));
            leOutboundType.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DictionaryValue", "值"));

            // bill status
            IEnumerable<DataDictionary> planStatus = CacheHelper.GetDictionaryByCategory(DictionaryEnum.OUTBOUNDPLAN_BILLSTATUS.ToString());
            leBillStatus.Properties.DataSource = planStatus;
            leBillStatus.Properties.DisplayMember = "DictionaryValue";
            leBillStatus.Properties.ValueMember = "DictionaryId";
            leBillStatus.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DictionaryCode", "代码"));
            leBillStatus.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DictionaryValue", "值"));

            IEnumerable<DataDictionary> billTypes = CacheHelper.GetDictionaryByCategory(DictionaryEnum.OUTBOUND_BILLTYPE.ToString());
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
            btnConfirm.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnConfirm.Caption = @"审核";

            btnRevoke.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnRevoke.Caption = @"作废";
            
            btnPrint.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnPrint.Caption = @"打印单据";
        }

        //// close partial received outbound plan
        //public override void GenerateBill()
        //{
        //    DialogResult dialogResult = MessageBox.Show("是否关闭此出库计划？", "问题", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
        //    if (dialogResult == System.Windows.Forms.DialogResult.No)
        //        return;

        //    if (CurrentMasterData != null)
        //    {
        //        var plan = CurrentMasterData as OutboundPlan;

        //        if (plan != null)
        //        {
        //            try
        //            {
        //                bool closeResult = ServiceHelper.OutboundService.CloseOutboundPlan(GlobalState.CurrentWarehouse.WarehouseId, plan.PlanId, GlobalState.CurrentUser.UserId);

        //                if (closeResult)
        //                {
        //                    CurrentMasterData = ServiceHelper.OutboundService.GetOutboundPlan(plan.PlanId);
        //                    SetMainData();
        //                    btnConfirm.Enabled = false;
        //                    btnUpdateMaster.Enabled = false;
        //                    btnGenerateBill.Enabled = false;
        //                }
        //            }
        //            catch (FaultException<ServiceError> sex)
        //            {
        //                if (sex.Detail != null)
        //                    FormHelper.ShowWarningDialog(sex.Detail.ErrorMessage);
        //            }
        //        }
        //    }
        //    return;
        //}

        public override void SetToolButtons()
        {
            base.SetToolButtons();

            // 判读当前单据状态是否可以审核
            OutboundPlan plan = CurrentMasterData as OutboundPlan;
            if (plan != null)
            {
                DataDictionary dictionary = ServiceHelper.ApplicationService.GetDataDictionary(plan.BillStatus);
                if (dictionary != null)
                {
                    if (dictionary.DictionaryCode != DictionaryHelper.ConvertToDictionaryCode((int)OutboundPlanStatus.Created) && dictionary.DictionaryCode != DictionaryHelper.ConvertToDictionaryCode((int)OutboundPlanStatus.Modified))
                    {
                        btnConfirm.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        btnUpdateMaster.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    }

                    if (dictionary.DictionaryCode != DictionaryHelper.ConvertToDictionaryCode((int)OutboundPlanStatus.Created) && dictionary.DictionaryCode != DictionaryHelper.ConvertToDictionaryCode((int)OutboundPlanStatus.Modified)
                        && dictionary.DictionaryCode != DictionaryHelper.ConvertToDictionaryCode((int)OutboundPlanStatus.Confirmed))
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
                var plan = CurrentMasterData as OutboundPlan;

                if (plan != null)
                {
                    try
                    {
                        bool comfirmResult = ServiceHelper.OutboundService.ConfirmOutboundPlan(GlobalState.CurrentWarehouse.WarehouseId, plan.PlanId, GlobalState.CurrentUser.UserId);

                        if (comfirmResult)
                        {
                            CurrentMasterData = ServiceHelper.OutboundService.GetOutboundPlan(plan.PlanId);
                            SetMainData();
                            btnConfirm.Enabled = false;
                            btnUpdateMaster.Enabled = false;
                            FormHelper.ShowInformationDialog("审核出库计划成功。");
                        }
                        else
                            FormHelper.ShowWarningDialog("审核出库计划失败。");
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
                var plan = CurrentMasterData as OutboundPlan;

                if (plan != null)
                {
                    try
                    {
                        bool revokeResult = ServiceHelper.OutboundService.RevokeOutboundPlan(GlobalState.CurrentWarehouse.WarehouseId, plan.PlanId, GlobalState.CurrentUser.UserId);

                        if (revokeResult)
                        {
                            CurrentMasterData = ServiceHelper.OutboundService.GetOutboundPlan(plan.PlanId);
                            SetMainData();
                            btnRevoke.Enabled = false;
                            btnUpdateMaster.Enabled = false;

                            FormHelper.ShowInformationDialog("作废出库计划成功。");
                        }
                        else
                            FormHelper.ShowWarningDialog("作废出库计划失败。");
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

            OutboundPlan plan = CurrentMasterData as OutboundPlan;
            if (plan != null)
            {
                List<OutboundPlanDetailView> details = ServiceHelper.OutboundService.GetOutboundPlanDetailView(plan.PlanId);

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
            leOutboundType.EditValue = null;
            leLinkBillType.EditValue = null;
            dePlanIssueTime.Text = string.Empty;
            lePriority.EditValue = null;
            beMerchantId.Tag = null;
            beMerchantId.Text = string.Empty;
            leBillStatus.EditValue = null;
            txtReceiver.Text = string.Empty;

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
                OutboundPlan plan = CurrentMasterData as OutboundPlan;
                CurrentMasterData = ServiceHelper.OutboundService.GetOutboundPlan(plan.PlanId);

                LoadDetailData();
            }
        }

        public override void SetMainData()
        {
            if (CurrentMasterData != null)
            {
                var plan = CurrentMasterData as OutboundPlan;

                if (plan != null)
                {
                    this.Text = " 出库计划 - " + plan.PlanNumber;

                    txtPlanNumber.Text = plan.PlanNumber;
                    txtLinkBillNumber.Text = plan.LinkBillNumber;
                    if (plan.OutboundType > 0)
                        leOutboundType.EditValue = plan.OutboundType;
                    if (plan.LinkBillType > 0)
                        leLinkBillType.EditValue = plan.LinkBillType;

                    dePlanIssueTime.Text = plan.PlanIssueTime;
                    if (plan.Priority > 0)
                        lePriority.EditValue = plan.Priority;

                    if (plan.MerchantId > 0)
                    {
                        Company company = CacheHelper.GetCompany(plan.MerchantId);
                        beMerchantId.Tag = company;
                        beMerchantId.Text = company.ShortName;
                    }
                    txtReceiver.Text = plan.Receiver;
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
            OutboundPlan plan = null;
            if (MasterDataState == DataState.Create)
            {
                plan = new OutboundPlan();
                plan.CreateUser = GlobalState.CurrentUser.UserId;
                plan.WarehouseId = GlobalState.CurrentWarehouse.WarehouseId;
            }
            if (MasterDataState == DataState.Update)
            {
                plan = CurrentMasterData as OutboundPlan;
                if (plan != null)
                {
                    plan.EditUser = GlobalState.CurrentUser.UserId;
                }
            }

            if (plan != null)
            {
                plan.Remark = txtRemark.Text.Trim();
                plan.LinkBillNumber = txtLinkBillNumber.Text.Trim();
                if (beMerchantId.Tag != null)
                {
                    plan.MerchantId = ((Company)beMerchantId.Tag).CompanyId;
                    plan.ClientId = CacheHelper.GetParentCompanyId(plan.MerchantId);
                }
                if (leOutboundType.EditValue != null)
                    plan.OutboundType = (int)leOutboundType.EditValue;
                if (leLinkBillType.EditValue != null)
                    plan.LinkBillType = (int)leLinkBillType.EditValue;
                if (dePlanIssueTime.Text != string.Empty)
                    plan.PlanIssueTime = TypeConvertHelper.DatetimeToString(dePlanIssueTime.DateTime);
                if (lePriority.EditValue != null)
                    plan.Priority = (int)lePriority.EditValue;
                plan.Receiver = txtReceiver.Text.Trim();
                if (MasterDataState == DataState.Create)
                {
                    plan = ServiceHelper.OutboundService.CreateOutboundPlan(plan);
                    if (plan == null)
                    {
                        FormHelper.ShowErrorDialog("创建出库计划失败。");
                        return;
                    }
                }
                if (MasterDataState == DataState.Update)
                {
                    bool updateResult = ServiceHelper.OutboundService.UpdateOutboundPlan(plan);
                    if (!updateResult)
                    {
                        FormHelper.ShowErrorDialog("更新出库计划失败。");
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
                                int newID = ServiceHelper.OutboundService.AddOutboundPlanDetail(plan.PlanId, ObjCopyToParent(localInfo));
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
                                bool updateResult = ServiceHelper.OutboundService.UpdateOutboundPlanDetail(ObjCopyToParent(localInfo));
                                if (!updateResult)
                                {
                                    throw new Exception();
                                }
                                localInfo.OperationName = "NONE";
                                break;
                            }
                        case "DELETE":
                            {
                                bool deleteResult = ServiceHelper.OutboundService.RemoveOutboundPlanDetail(ObjCopyToParent(localInfo).Id);
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
            OutboundPlan plan = CurrentMasterData as OutboundPlan;
            if (plan != null)
            {
                DataDictionary dictionary = ServiceHelper.ApplicationService.GetDataDictionary(plan.BillStatus);
                if (dictionary != null)
                {
                    if (dictionary.DictionaryCode != DictionaryHelper.ConvertToDictionaryCode((int)OutboundPlanStatus.Created) && dictionary.DictionaryCode != DictionaryHelper.ConvertToDictionaryCode((int)OutboundPlanStatus.Modified))
                    {
                        FormHelper.ShowWarningDialog("此出库计划当前状态不允许被编辑。");
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

            if (leOutboundType.EditValue == null)
            {
                string tipa = "请选择出库类型。";
                Validator.SetError(leOutboundType, tipa);
                result = false;
            }

            if (beMerchantId.Tag == null)
            {
                string tipa = "请选择货主。";
                Validator.SetError(beMerchantId, tipa);
                result = false;
            }

            if (dePlanIssueTime.Text == "")
            {
                Validator.SetError(dePlanIssueTime, "请选择计划收货日期。");
                result = false;
            }

            //if (txtLinkBillNumber.Text == "")
            //{
            //    Validator.SetError(txtLinkBillNumber, "请输入关联单据号");
            //    result = false;
            //}

            return result;
        }

        public override void CustomizeDetailGrid()
        {
            int columnIndex = 0;

            FormHelper.SetGridColumn(DetailGridView, "Id", "", 100, columnIndex++, false);

            FormHelper.SetGridColumn(DetailGridView, "PlanId", "出库计划编号", 100, columnIndex++, false);

            FormHelper.SetGridColumn(DetailGridView, "SkuId", "货物编号", 100, columnIndex++, false);

            FormHelper.SetGridColumn(DetailGridView, "PackId", "包装编号", 100, columnIndex++, false);

            FormHelper.SetGridColumn(DetailGridView, "BatchNumber", "入库批次号", 100, columnIndex++, false);

            FormHelper.SetGridColumn(DetailGridView, "SkuNumber", "货物代码", 100, columnIndex++, true);

            FormHelper.SetGridColumn(DetailGridView, "SkuName", "货物名称", 100, columnIndex++, true);

            FormHelper.SetGridColumn(DetailGridView, "Qty", "数量", 100, columnIndex++, true);

            FormHelper.SetGridColumn(DetailGridView, "IssuedQty", "已出库数量", 100, columnIndex++, true);

            FormHelper.SetGridColumn(DetailGridView, "PackName", "包装名称", 100, columnIndex++, true);

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
        private OutboundPlanDetail ObjCopyToParent(LocalDataInfo localInfo)
        {
            OutboundPlanDetail info = new OutboundPlanDetail();

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

        private IList<LocalDataInfo> ObjCopyToLocal(IList<OutboundPlanDetailView> entyInfoList)
        {
            IList<LocalDataInfo> list = new List<LocalDataInfo>();

            Type ts = typeof(OutboundPlanDetailView);
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
            //打印出库计划
        }
    }
}
