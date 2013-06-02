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
using Modules.InboundPlanModule.Views;

namespace Modules.InboundBillModule.Views
{
    [SmartPart]
    public partial class InboundBillListForm : MasterListForm
    {

        #region properties
        private List<Criterion> _criterions = new List<Criterion>();
        #endregion 

        public InboundBillListForm()
        {
            InitializeComponent();
        }

        public InboundBillListForm(FormMode mode, bool isMultiSelect)
            : base(mode, isMultiSelect)
        {
            InitializeComponent();
        }

        public InboundBillListForm(FormMode mode, bool isMultiSelect, bool isInvoice)
            : base(mode, isMultiSelect)
        {
            InitializeComponent();
        }

        #region template methods
        public override bool ValidateUpdateAuthority()
        {
            InboundBill bill = CurrentData as InboundBill;
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

        public override void InitButtonAuthority()
        {
            btnAdd.Tag = "INBOUNDPLAN_INSERT";
            btnUpdate.Tag = "INBOUNDPLAN_EDIT";
        }

        public void InitComboBox()
        {
            // bill status
            IEnumerable<DataDictionary> billStatus = CacheHelper.GetDictionaryByCategory(DictionaryEnum.INBOUNDBILL_BILLSTATUS.ToString());
            leBillStatus.Properties.DataSource = billStatus;
            leBillStatus.Properties.DisplayMember = "DictionaryValue";
            leBillStatus.Properties.ValueMember = "DictionaryId";
            leBillStatus.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DictionaryCode", "代码"));
            leBillStatus.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DictionaryValue", "值"));
        }

        public override void FormInitialize()
        {
            RegisterDetailForm("Modules.InboundBillModule.Views.InboundBillEditForm");

            InitComboBox();

            deReceiveTimeStart.DateTime = DateTime.Now.AddDays(-7);
            deReceiveTimeEnd.DateTime = DateTime.Now.AddDays(7);
        }

        public override void SetButtonStatus()
        {
            base.SetButtonStatus();

            this.btnAdd.Caption = "新增入库单";
            this.btnUpdate.Caption = "编辑入库单";
        }

        public override void LoadData()
        {
            try
            {
                SetQueryConditions();
                PagerQuery query = new PagerQuery("InboundBill", "BillId", "*", "BillId",
                    OrderClause.OrderClauseCriteria.Descending, this.PageSize, this.PageNumber, _criterions);

                int totalCount;
                DataList = ServiceHelper.InboundService.GetInboundBillByPagerQuery(query, out totalCount);
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

            if (beVendorId.Tag != null)
            {
                Company company = beVendorId.Tag as Company;
                _criterions.Add(new Criterion("VendorId", CriteriaOperator.Equal, company.CompanyId));
            }
            if (beMerchantId.Tag != null)
            {
                Company company = beMerchantId.Tag as Company;
                _criterions.Add(new Criterion("MerchantId", CriteriaOperator.Equal, company.CompanyId));
            }
            if (beReceiveLocationId.Tag != null)
            {
                Location location = beReceiveLocationId.Tag as Location;
                _criterions.Add(new Criterion("ReceiveLocationId", CriteriaOperator.Equal, location.LocationId));
            }
            if (bePlanId.Tag != null)
            {
                InboundPlan plan = bePlanId.Tag as InboundPlan;
                _criterions.Add(new Criterion("PlanId", CriteriaOperator.Equal, plan.PlanId));
            }
            if (txtBillNumber.Text != string.Empty)
                _criterions.Add(new Criterion("BillNumber", CriteriaOperator.Like, txtBillNumber.Text.Trim() + "%"));
            if (deReceiveTimeStart.Text != string.Empty)
                _criterions.Add(new Criterion("ReceiveTime", CriteriaOperator.GreaterThanOrEqual, Convert.ToDateTime(deReceiveTimeStart.Text.Trim()).ToString("yyyy-MM-dd")));
            if (deReceiveTimeEnd.Text != string.Empty)
                _criterions.Add(new Criterion("ReceiveTime", CriteriaOperator.LesserThanOrEqual, Convert.ToDateTime(deReceiveTimeEnd.Text.Trim()).ToString("yyyy-MM-dd")));
            if (leBillStatus.EditValue != null)
                _criterions.Add(new Criterion("BillStatus", CriteriaOperator.Equal, (int)leBillStatus.EditValue));
        }

        public override void QueryData(int pageSize, int pageNumber)
        {
            try
            {
                SetQueryConditions();
                PagerQuery query = new PagerQuery("InboundBill", "BillId", "*", "BillId",
                    OrderClause.OrderClauseCriteria.Descending, pageSize, pageNumber, _criterions);

                int totalCount;
                DataList = ServiceHelper.InboundService.GetInboundBillByPagerQuery(query, out totalCount);
                BindData();
            }
            catch (FaultException<ServiceError> sex)
            {
                if (sex.Detail != null)
                    FormHelper.ShowWarningDialog(sex.Detail.ErrorMessage);
            }
        }

        public override void CustomizeGrid()
        {
            int columnIndex = 0;

            FormHelper.SetGridColumn(MasterGridView, "BillId", "入库单编号", 100, columnIndex++, false);

            FormHelper.SetGridColumn(MasterGridView, "BillNumber", "入库单号", 150, columnIndex++, true);

            FormHelper.SetGridColumn(MasterGridView, "BillStatus", "单据状态", 100, columnIndex++, true);

            FormHelper.SetGridColumn(MasterGridView, "PlanId", "入库计划编号", 100, columnIndex++, false);

            FormHelper.SetGridColumn(MasterGridView, "WarehouseId", "收货仓库", 200, columnIndex++, false);

            FormHelper.SetGridColumn(MasterGridView, "MerchantId", "货主", 100, columnIndex++, true);

            FormHelper.SetGridColumn(MasterGridView, "VendorId", "供应商", 100, columnIndex++, true);

            FormHelper.SetGridColumn(MasterGridView, "DeliveryMan", "送货人", 100, columnIndex++, true);

            FormHelper.SetGridColumn(MasterGridView, "Vehicle", "送货车辆", 100, columnIndex++, true);

            FormHelper.SetGridColumn(MasterGridView, "ArrivalTime", "到仓时间", 100, columnIndex++, true);

            FormHelper.SetGridColumn(MasterGridView, "ClientId", "客户", 200, columnIndex++, false);

            FormHelper.SetGridColumn(MasterGridView, "Receiver", "收货操作员", 100, columnIndex++, true);

            FormHelper.SetGridColumn(MasterGridView, "ReceiveTime", "收货时间", 100, columnIndex++, true);

            FormHelper.SetGridColumn(MasterGridView, "ReceiveLocationId", "收货库位编号", 100, columnIndex++, false);

            FormHelper.SetGridColumn(MasterGridView, "Auditor", "确认用户", 100, columnIndex++, true);

            FormHelper.SetGridColumn(MasterGridView, "AuditTime", "确认时间", 100, columnIndex++, true);



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
            MasterGridView.Columns["BillStatus"].ColumnEdit = dictionaryLookup;

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
            MasterGridView.Columns["Receiver"].ColumnEdit = userLookup;
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
            LocationListForm form = new LocationListForm(FormMode.Select, false);
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
        /// 公司选择（供应商、客户、商家）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void beVendorId_ButtonClick(object sender, ButtonPressedEventArgs e)
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
            InboundPlanListForm form = new InboundPlanListForm(FormMode.Select, false);
            form.Size = new System.Drawing.Size(810, 600);
            form.Parent = parentForm;
            form.ReferenceForm = parentForm;
            parentForm.ShowDialog();
            IList inboundplans = form.GetSelectedData<InboundPlan>();
            if (inboundplans != null && inboundplans.Count > 0)
            {
                InboundPlan inboundplan = inboundplans[0] as InboundPlan;
                ((ButtonEdit)sender).Tag = inboundplan;
                ((ButtonEdit)sender).Text = inboundplan.PlanNumber;
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



