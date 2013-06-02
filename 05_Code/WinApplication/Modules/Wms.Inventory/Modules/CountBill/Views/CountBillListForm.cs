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
using DevExpress.XtraEditors;
using Modules.CompanyModule.Views;
using Business.Common;
using Business.Common.DataDictionary;
using Business.Common.QueryModel;
using Business.Domain.Application;
using Business.Domain.Inventory;
using Business.Common.Exception;
using Business.Common.Toolkit;
using Business.Domain.Wms;
using System.ServiceModel;

namespace Modules.CountBillModule.Views
{
    [SmartPart]
    public partial class CountBillListForm : MasterListForm
    {
        #region properties
        private List<Criterion> _criterions = new List<Criterion>();

        #endregion 

        public CountBillListForm()
        {
            InitializeComponent();
            
        }

        public CountBillListForm(FormMode mode, bool isMultiSelect)
            : base(mode, isMultiSelect)
        {
            InitializeComponent();
        }

        #region template methods

        public override void InitButtonAuthority()
        {
            //
        }

        public void InitComboBox()
        {
            // bill status
            IEnumerable<DataDictionary> planStatus = CacheHelper.GetDictionaryByCategory(DictionaryEnum.COUNTBILL_BILLSTATUS.ToString());
            leBillStatus.Properties.DataSource = planStatus;
            leBillStatus.Properties.DisplayMember = "DictionaryValue";
            leBillStatus.Properties.ValueMember = "DictionaryId";
            leBillStatus.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DictionaryCode", "代码"));
            leBillStatus.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DictionaryValue", "值"));
        }

        public override void FormInitialize()
        {
            RegisterDetailForm("Modules.CountBillModule.Views.CountBillEditForm");

            InitComboBox();

            dePlanCountDateStart.DateTime = DateTime.Now.AddDays(-7);
            dePlanCountDateEnd.DateTime = DateTime.Now.AddDays(7);
        }

        public override void SetButtonStatus()
        {
            base.SetButtonStatus();

            //this.btnAdd.Caption = "新增出库计划";
            //this.btnUpdate.Caption = "编辑出库计划";

            this.btnAdd.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnUpdate.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
        }

        
        public override void LoadData()
        {
            try
            {
                SetQueryConditions();
                PagerQuery query = new PagerQuery("CountBill", "BillId", "*", "BillId",
                    OrderClause.OrderClauseCriteria.Descending, this.PageSize, this.PageNumber, _criterions);

                int totalCount;
                DataList = ServiceHelper.InventoryService.GetCountBillByPagerQuery(query, out totalCount);
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

            if (txtBillNumber.Text.Trim() != "")
                _criterions.Add(new Criterion("BillNumber", CriteriaOperator.Like, txtBillNumber.Text.Trim() + "%"));
            if (dePlanCountDateStart.Text != string.Empty)
                _criterions.Add(new Criterion("PlanCountDate", CriteriaOperator.GreaterThanOrEqual, Convert.ToDateTime(dePlanCountDateStart.Text.Trim()).ToString("yyyy-MM-dd")));
            if (dePlanCountDateEnd.Text != string.Empty)
                _criterions.Add(new Criterion("PlanCountDate", CriteriaOperator.LesserThanOrEqual, Convert.ToDateTime(dePlanCountDateEnd.Text.Trim()).ToString("yyyy-MM-dd")));
            if (leBillStatus.EditValue != null)
                _criterions.Add(new Criterion("BillStatus", CriteriaOperator.Equal, (int)leBillStatus.EditValue));
        }

        public override void CustomizeGrid()
        {
            int columnIndex = 0;

            FormHelper.SetGridColumn(MasterGridView, "BillId", "出库计划编号", 100, columnIndex++, false);

            FormHelper.SetGridColumn(MasterGridView, "BillNumber", "出库计划单号", 150, columnIndex++, true);

            FormHelper.SetGridColumn(MasterGridView, "BillStatus", "单据状态", 100, columnIndex++, true);

            FormHelper.SetGridColumn(MasterGridView, "WarehouseId", "发货仓库编号", 100, columnIndex++, false);

            FormHelper.SetGridColumn(MasterGridView, "PlanCountDate", "计划盘点日期", 100, columnIndex++, true);

            FormHelper.SetGridColumn(MasterGridView, "CountTime", "盘点时间", 100, columnIndex++, true);

            FormHelper.SetGridColumn(MasterGridView, "Auditor", "确认用户", 100, columnIndex++, true);

            FormHelper.SetGridColumn(MasterGridView, "AuditTime", "确认日期", 100, columnIndex++, true);

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
        #endregion
    }
}



