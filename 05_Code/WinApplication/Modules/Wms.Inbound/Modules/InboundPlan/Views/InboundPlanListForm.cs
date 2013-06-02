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
using Business.Domain.Inventory;
using Business.Domain.Wms;
using Business.Common.Exception;
using Business.Common.Toolkit;
using System.ServiceModel;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors;

namespace Modules.InboundPlanModule.Views
{
    [SmartPart]
    public partial class InboundPlanListForm : MasterListForm
    {

        #region properties
        private List<Criterion> _criterions = new List<Criterion>();
        #endregion 

        public InboundPlanListForm()
        {
            InitializeComponent();
        }

        public InboundPlanListForm(FormMode mode, bool isMultiSelect)
            : base(mode, isMultiSelect)
        {
            InitializeComponent();
        }

        private InboundPlanStatus _inboundStatus { get; set; }
        public InboundPlanListForm(FormMode mode, bool isMultiSelect, InboundPlanStatus status)
            : base(mode, isMultiSelect)
        {
            InitializeComponent();

            CurrentFormMode = mode;
            IsMultiSelect = IsMultiSelect;
            _inboundStatus = status;
        }

        #region template methods
        public override bool ValidateUpdateAuthority()
        {
            InboundPlan plan = CurrentData as InboundPlan;
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

        public override void InitButtonAuthority()
        {
            btnAdd.Tag = "INBOUNDPLAN_INSERT";
            btnUpdate.Tag = "INBOUNDPLAN_EDIT";
        }

        public void InitComboBox()
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
        }

        public override void FormInitialize()
        {
            RegisterDetailForm("Modules.InboundPlanModule.Views.InboundPlanEditForm");

            InitComboBox();

            dePlanReceiveTimeStart.DateTime = DateTime.Now.AddDays(-7);
            dePlanReceiveTimeEnd.DateTime = DateTime.Now.AddDays(7);

            if (_inboundStatus != null)
            {
                DataDictionary status = ServiceHelper.ApplicationService.GetDataDictionaryByCode(GlobalState.ApplicationCode, ((int)_inboundStatus).ToString());
                if (status != null)
                {
                    leBillStatus.EditValue = status.DictionaryId;
                    leBillStatus.Enabled = false;
                }
            }
        }

        public override void SetButtonStatus()
        {
            base.SetButtonStatus();

            this.btnAdd.Caption = "新增入库计划";
            this.btnUpdate.Caption = "编辑入库计划";
        }

        public override void LoadData()
        {
            try
            {
                SetQueryConditions();
                PagerQuery query = new PagerQuery("InboundPlan", "PlanId", "*", "PlanId",
                    OrderClause.OrderClauseCriteria.Descending, this.PageSize, this.PageNumber, _criterions);

                int totalCount;
                DataList = ServiceHelper.InboundService.GetInboundPlanByPagerQuery(query, out totalCount);
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
            if (txtPlanNumber.Text.Trim() != "")
                _criterions.Add(new Criterion("PlanNumber", CriteriaOperator.Like, txtPlanNumber.Text.Trim() + "%"));
            if (txtLinkBillNumber.Text.Trim() != "")
                _criterions.Add(new Criterion("LinkBillNumber", CriteriaOperator.Like, txtLinkBillNumber.Text.Trim() + "%"));
            if (dePlanReceiveTimeStart.Text != string.Empty)
                _criterions.Add(new Criterion("PlanReceiveTime", CriteriaOperator.GreaterThanOrEqual, Convert.ToDateTime(dePlanReceiveTimeStart.Text.Trim()).ToString("yyyy-MM-dd")));
            if (dePlanReceiveTimeEnd.Text != string.Empty)
                _criterions.Add(new Criterion("PlanReceiveTime", CriteriaOperator.LesserThanOrEqual, Convert.ToDateTime(dePlanReceiveTimeEnd.Text.Trim()).ToString("yyyy-MM-dd")));
            if (leInboundType.EditValue != null)
                _criterions.Add(new Criterion("InboundType", CriteriaOperator.Equal, (int)leInboundType.EditValue));
            if (leBillStatus.EditValue != null)
                _criterions.Add(new Criterion("BillStatus", CriteriaOperator.Equal, (int)leBillStatus.EditValue));
        }

        public override void CustomizeGrid()
        {
            int columnIndex = 0;

            FormHelper.SetGridColumn(MasterGridView, "PlanId", "入库计划编号", 100, columnIndex++, false);

            FormHelper.SetGridColumn(MasterGridView, "PlanNumber", "入库计划单号", 150, columnIndex++, true);

            FormHelper.SetGridColumn(MasterGridView, "BillStatus", "单据状态", 100, columnIndex++, true);

            FormHelper.SetGridColumn(MasterGridView, "WarehouseId", "仓库编号", 200, columnIndex++, false);

            FormHelper.SetGridColumn(MasterGridView, "InboundType", "入库类型", 100, columnIndex++, true);

            FormHelper.SetGridColumn(MasterGridView, "LinkBillType", "关联单据类型", 100, columnIndex++, true);

            FormHelper.SetGridColumn(MasterGridView, "LinkBillNumber", "关联单据号", 100, columnIndex++, true);

            FormHelper.SetGridColumn(MasterGridView, "ClientId", "客户", 200, columnIndex++, false);

            FormHelper.SetGridColumn(MasterGridView, "MerchantId", "货主", 100, columnIndex++, true);

            FormHelper.SetGridColumn(MasterGridView, "VendorId", "供应商", 100, columnIndex++, true);

            FormHelper.SetGridColumn(MasterGridView, "PlanReceiveTime", "计划收货时间", 100, columnIndex++, true);

            FormHelper.SetGridColumn(MasterGridView, "IsCrossDock", "是否交叉转运", 100, columnIndex++, false);

            FormHelper.SetGridColumn(MasterGridView, "Auditor", "审核人", 100, columnIndex++, true);

            FormHelper.SetGridColumn(MasterGridView, "AuditTime", "审核时间", 100, columnIndex++, true);

            FormHelper.SetGridColumn(MasterGridView, "Priority", "优先级", 150, columnIndex++, true);

            FormHelper.SetGridColumn(MasterGridView, "Remark", "", 100, columnIndex++, false);
            FormHelper.SetGridColumn(MasterGridView, "CreateUser", "", 100, columnIndex++, false);
            FormHelper.SetGridColumn(MasterGridView, "CreateTime", "", 100, columnIndex++, false);
            FormHelper.SetGridColumn(MasterGridView, "EditUser", "", 100, columnIndex++, false);
            FormHelper.SetGridColumn(MasterGridView, "EditTime", "", 100, columnIndex++, false);

            FormHelper.SetGridColumn(MasterGridView, "IsValid", "", 100, columnIndex++, false);
        }

        public override void BindGridColumnMap()
        {
            DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit dictionaryLookup = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            dictionaryLookup.DataSource = CacheHelper.DictionaryCache;
            dictionaryLookup.DisplayMember = "DictionaryValue";
            dictionaryLookup.ValueMember = "DictionaryId";
            MasterGridView.Columns["LinkBillType"].ColumnEdit = dictionaryLookup;
            MasterGridView.Columns["InboundType"].ColumnEdit = dictionaryLookup;
            MasterGridView.Columns["BillStatus"].ColumnEdit = dictionaryLookup;
            MasterGridView.Columns["Priority"].ColumnEdit = dictionaryLookup;

            DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit companyLookup = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            companyLookup.DataSource = CacheHelper.CompanyCache;
            companyLookup.DisplayMember = "ShortName";
            companyLookup.ValueMember = "CompanyId";
            MasterGridView.Columns["ClientId"].ColumnEdit = companyLookup;
            MasterGridView.Columns["MerchantId"].ColumnEdit = companyLookup;
            MasterGridView.Columns["VendorId"].ColumnEdit = companyLookup;

            DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit userLookup = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            userLookup.DataSource = CacheHelper.UserCache;
            userLookup.DisplayMember = "UserName";
            userLookup.ValueMember = "UserId";
            MasterGridView.Columns["Auditor"].ColumnEdit = userLookup;
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

        private void leInboundType_ButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            DevExpress.XtraEditors.LookUpEdit edit = (DevExpress.XtraEditors.LookUpEdit)sender;
            if (e.Button.Kind == ButtonPredefines.Delete)
            {
                edit.EditValue = null;
            }
        }
        #endregion

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
    }
}



