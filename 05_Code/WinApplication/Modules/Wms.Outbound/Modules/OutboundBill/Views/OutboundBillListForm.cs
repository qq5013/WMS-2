using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;
using System.Collections.Generic;
using Framework.UI.Template.Common;
using Framework.UI.Template.MasterDetail;
using Business.Domain.Inventory;
using Microsoft.Practices.CompositeUI.SmartParts;
using Wms.Common;
using DevExpress.XtraEditors.Controls;
using Modules.CompanyModule.Views;
using Business.Common;
using Business.Common.DataDictionary;
using Business.Common.QueryModel;
using Business.Domain.Application;
using Business.Common.Exception;
using Business.Common.Toolkit;
using System.ServiceModel;
using Modules.LocationModule.Views;
using Business.Domain.Warehouse;
using DevExpress.XtraEditors;
using Business.Domain.Wms;
using Modules.OutboundPlanModule.Views;

namespace Modules.OutboundBillModule.Views
{
    [SmartPart]
    public partial class OutboundBillListForm : MasterListForm
    {

        #region properties
        private List<Criterion> _criterions = new List<Criterion>();

        #endregion 

        public OutboundBillListForm()
        {
            InitializeComponent();
            
        }

        public OutboundBillListForm(FormMode mode, bool isMultiSelect)
            : base(mode, isMultiSelect)
        {
            InitializeComponent();
        }

        public OutboundBillListForm(FormMode mode, bool isMultiSelect, bool isInvoice)
            : base(mode, isMultiSelect)
        {
            InitializeComponent();
        }

        #region template methods
        public override bool ValidateUpdateAuthority()
        {
            OutboundBill bill = CurrentData as OutboundBill;
            if (bill != null)
            {
                DataDictionary dictionary = ServiceHelper.ApplicationService.GetDataDictionary(bill.BillStatus);

                if (dictionary != null)
                {
                    if (dictionary.DictionaryCode != DictionaryHelper.ConvertToDictionaryCode((int)OutboundBillStatus.Created) && dictionary.DictionaryCode != DictionaryHelper.ConvertToDictionaryCode((int)OutboundBillStatus.Modified))
                    {
                        FormHelper.ShowWarningDialog("此出库单当前状态不允许被编辑。");
                        return false;
                    }
                }
            }
            return true;
        }

        public override void InitButtonAuthority()
        {
            //
        }

        public void InitComboBox()
        {

            // bill status
            IEnumerable<DataDictionary> billStatus = CacheHelper.GetDictionaryByCategory(DictionaryEnum.OUTBOUNDBILL_BILLSTATUS.ToString());
            leBillStatus.Properties.DataSource = billStatus;
            leBillStatus.Properties.DisplayMember = "DictionaryValue";
            leBillStatus.Properties.ValueMember = "DictionaryId";
            leBillStatus.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DictionaryCode", "代码"));
            leBillStatus.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DictionaryValue", "值"));
        }

        public override void FormInitialize()
        {
            RegisterDetailForm("Modules.OutboundBillModule.Views.OutboundBillEditForm");

            InitComboBox();

            deIssueTimeStart.DateTime = DateTime.Now.AddDays(-7);
            deIssueTimeEnd.DateTime = DateTime.Now.AddDays(7);
        }

        public override void SetButtonStatus()
        {
            base.SetButtonStatus();

            this.btnAdd.Caption = "新增出库单";
            this.btnUpdate.Caption = "编辑出库单";
        }

        public override void LoadData()
        {
            try
            {
                SetQueryConditions();
                PagerQuery query = new PagerQuery("OutboundBill", "BillId", "*", "BillId",
                    OrderClause.OrderClauseCriteria.Descending, this.PageSize, this.PageNumber, _criterions);

                int totalCount;
                DataList = ServiceHelper.OutboundService.GetOutboundBillByPagerQuery(query, out totalCount);
                SetSplitPage(totalCount);
                BindData();
            }
            catch (FaultException<ServiceError> sex)
            {
                if (sex.Detail != null)
                    FormHelper.ShowWarningDialog(sex.Detail.ErrorMessage);
            }
        }

        public override void SetQueryConditions()
        {
            _criterions.Clear();

            _criterions.Add(new Criterion("WarehouseId", CriteriaOperator.Equal, GlobalState.CurrentWarehouse.WarehouseId));

            if (beMerchantId.Tag != null)
            {
                Company company = beMerchantId.Tag as Company;
                _criterions.Add(new Criterion("MerchantId", CriteriaOperator.Equal, company.CompanyId));
            }
            if (bePlanId.Tag != null)
            {
                OutboundPlan plan = bePlanId.Tag as OutboundPlan;
                _criterions.Add(new Criterion("PlanId", CriteriaOperator.Equal, plan.PlanId));
            }
            if (txtBillNumber.Text != string.Empty)
                _criterions.Add(new Criterion("BillNumber", CriteriaOperator.Like, txtBillNumber.Text.Trim() + "%"));
            if (deIssueTimeStart.Text != string.Empty)
                _criterions.Add(new Criterion("IssueTime", CriteriaOperator.GreaterThanOrEqual, Convert.ToDateTime(deIssueTimeStart.Text.Trim()).ToString("yyyy-MM-dd")));
            if (deIssueTimeEnd.Text != string.Empty)
                _criterions.Add(new Criterion("IssueTime", CriteriaOperator.LesserThanOrEqual, Convert.ToDateTime(deIssueTimeEnd.Text.Trim()).ToString("yyyy-MM-dd")));
            if (leBillStatus.EditValue != null)
                _criterions.Add(new Criterion("BillStatus", CriteriaOperator.Equal, (int)leBillStatus.EditValue));
        }

        public override void CustomizeGrid()
        {
            int columnIndex = 0;

            FormHelper.SetGridColumn(MasterGridView, "BillId", "出库单编号", 100, columnIndex++, false);

            FormHelper.SetGridColumn(MasterGridView, "BillNumber", "出库单号", 100, columnIndex++, true);

            FormHelper.SetGridColumn(MasterGridView, "BillStatus", "单据状态", 100, columnIndex++, true);

            FormHelper.SetGridColumn(MasterGridView, "PlanId", "出库计划编号", 100, columnIndex++, false);

            FormHelper.SetGridColumn(MasterGridView, "PickBillId", "拣货单编号", 100, columnIndex++, false);

            FormHelper.SetGridColumn(MasterGridView, "SortBillId", "分拣单编号", 100, columnIndex++, false);

            FormHelper.SetGridColumn(MasterGridView, "ClientId", "客户", 100, columnIndex++, false);

            FormHelper.SetGridColumn(MasterGridView, "MerchantId", "货主", 100, columnIndex++, true);

            FormHelper.SetGridColumn(MasterGridView, "WarehouseId", "发货仓库", 100, columnIndex++, false);

            FormHelper.SetGridColumn(MasterGridView, "IssuePerson", "发货操作员", 100, columnIndex++, true);

            FormHelper.SetGridColumn(MasterGridView, "IssueLocationId", "发货库位编号", 100, columnIndex++, false);

            FormHelper.SetGridColumn(MasterGridView, "IssueTime", "发货时间", 100, columnIndex++, true);

            FormHelper.SetGridColumn(MasterGridView, "Auditor", "确认用户", 100, columnIndex++, true);

            FormHelper.SetGridColumn(MasterGridView, "AuditTime", "确认时间", 100, columnIndex++, true);

            //FormHelper.SetGridColumn(MasterGridView, "Details", "", 100, columnIndex++, false);
            //FormHelper.SetGridColumn(MasterGridView, "Packages", "", 100, columnIndex++, false);

            FormHelper.SetGridColumn(MasterGridView, "Remark", "备注", 100, columnIndex++, false);
            FormHelper.SetGridColumn(MasterGridView, "CreateUser", "创建用户", 100, columnIndex++, false);
            FormHelper.SetGridColumn(MasterGridView, "CreateTime", "创建时间", 100, columnIndex++, false);
            FormHelper.SetGridColumn(MasterGridView, "EditUser", "编辑用户", 100, columnIndex++, false);
            FormHelper.SetGridColumn(MasterGridView, "EditTime", "编辑时间", 100, columnIndex++, false);

            FormHelper.SetGridColumn(MasterGridView, "IsValid", "", 100, columnIndex++, false);
        }

        public override void BindGridColumnMap()
        {
            DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit dictionaryLookup = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            dictionaryLookup.DataSource = CacheHelper.DictionaryCache;
            dictionaryLookup.DisplayMember = "DictionaryValue";
            dictionaryLookup.ValueMember = "DictionaryId";
            MasterGridView.Columns["BillStatus"].ColumnEdit = dictionaryLookup;

            DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit companyLookup = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            companyLookup.DataSource = CacheHelper.CompanyCache;
            companyLookup.DisplayMember = "ShortName";
            companyLookup.ValueMember = "CompanyId";
            MasterGridView.Columns["MerchantId"].ColumnEdit = companyLookup;

            DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit userLookup = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            userLookup.DataSource = CacheHelper.UserCache;
            userLookup.DisplayMember = "UserName";
            userLookup.ValueMember = "UserId";
            MasterGridView.Columns["Auditor"].ColumnEdit = userLookup;
            MasterGridView.Columns["IssuePerson"].ColumnEdit = userLookup;
        }
        #endregion

        #region ui methods
        private void leBillStatus_ButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            DevExpress.XtraEditors.LookUpEdit edit = (DevExpress.XtraEditors.LookUpEdit)sender;
            if (e.Button.Kind == ButtonPredefines.Delete)
            {
                edit.EditValue = null;
            }
        }

        ///// <summary>
        ///// 收货库位
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void beReceiveLocationId_ButtonClick(object sender, ButtonPressedEventArgs e)
        //{
        //    DevExpress.XtraEditors.ButtonEdit edit = (DevExpress.XtraEditors.ButtonEdit)sender;
        //    if (e.Button.Kind == ButtonPredefines.Delete)
        //    {
        //        edit.Tag = null;
        //        edit.Text = string.Empty;
        //        return;
        //    }

        //    Form parentForm = new DevExpress.XtraEditors.XtraForm();
        //    parentForm.AutoSize = true;
        //    parentForm.StartPosition = FormStartPosition.CenterScreen;
        //    parentForm.ControlBox = false;
        //    parentForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
        //    LocationListForm form = new LocationListForm(FormMode.Select, false);
        //    form.Size = new System.Drawing.Size(810, 600);
        //    form.Parent = parentForm;
        //    form.ReferenceForm = parentForm;
        //    parentForm.ShowDialog();
        //    IList locations = form.GetSelectedData<Location>();
        //    if (locations != null && locations.Count > 0)
        //    {
        //        Location Location = locations[0] as Location;
        //        ((ButtonEdit)sender).Tag = Location;
        //        ((ButtonEdit)sender).Text = Location.LocationName;
        //    }
        //}

        /// <summary>
        /// 公司选择（供应商、客户、商家）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void beMerchantId_ButtonClick(object sender, ButtonPressedEventArgs e)
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
        /// 出库计划编号
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
            OutboundPlanListForm form = new OutboundPlanListForm(FormMode.Select, false);
            form.Size = new System.Drawing.Size(810, 600);
            form.Parent = parentForm;
            form.ReferenceForm = parentForm;
            parentForm.ShowDialog();
            IList outboundplans = form.GetSelectedData<OutboundPlan>();
            if (outboundplans != null && outboundplans.Count > 0)
            {
                OutboundPlan outboundplan = outboundplans[0] as OutboundPlan;
                ((ButtonEdit)sender).Tag = outboundplan;
                ((ButtonEdit)sender).Text = outboundplan.PlanNumber;
            }
        }

        #endregion
    }
}



