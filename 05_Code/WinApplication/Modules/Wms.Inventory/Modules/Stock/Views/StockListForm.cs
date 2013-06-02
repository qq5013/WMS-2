using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;
using System.Collections.Generic;
using Business.Domain.Inventory.Views;
using Framework.UI.Template.Common;
using Framework.UI.Template.Single;
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
using DevExpress.XtraEditors;
using Business.Domain.Wms;
using Modules.ContainerModule.Views;
using Modules.AreaModule.Views;
using Business.Domain.Warehouse;
using Modules.SkuModule.Views;

namespace Modules.StockModule.Views
{
    [SmartPart]
    public partial class StockListForm : SingleListForm 
    {

        #region properties
        private List<Criterion> _criterions = new List<Criterion>();
        #endregion 

        public StockListForm()
        {
            InitializeComponent();
            
        }

        public StockListForm(FormMode mode, bool isMultiSelect)
            : base(mode, isMultiSelect)
        {
            InitializeComponent();
        }

        public StockListForm(FormMode mode, bool isMultiSelect, bool isInvoice)
            : base(mode, isMultiSelect)
        {
            InitializeComponent();
        }

        #region template methods

        public override void InitButtonAuthority()
        {
            //
        }

        public override void SetButtonStatus()
        {
            btnInsert.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnCopy.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnUpdate.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            btnExport.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnExport.Caption = @"创建盘点单";
        }

        public override void ExportData()
        {
            DialogResult result = MessageBox.Show("是否根据当前查询条件创建盘点单？", "问题", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.No)
                return;

            try
            {
                string areaCode = txtAreaCode.Text.Trim();
                string locationCode = txtLocationCode.Text.Trim();
                string planNumber = txtPlanNumber.Text.Trim();
                string billNumber = txtBillNumber.Text.Trim();
                string skuNumber = txtSkuNumber.Text.Trim();
                string batchNumber = txtBatchNumber.Text.Trim();

                string countBillNumber = ServiceHelper.InventoryService.CreateCountBill(GlobalState.CurrentWarehouse.WarehouseId, areaCode, locationCode, planNumber, billNumber, skuNumber, batchNumber,GlobalState.CurrentUser.UserId);
                if (countBillNumber != string.Empty)
                    FormHelper.ShowInformationDialog(string.Format("盘点单{0}创建成功。", countBillNumber));
                else
                    FormHelper.ShowWarningDialog(string.Format("盘点单创建失败。"));
            }
            catch (FaultException<ServiceError> sex)
            {
                if (sex.Detail != null)
                    FormHelper.ShowWarningDialog(sex.Detail.ErrorMessage);
            }
        }

        public override void LoadData()
        {
            try
            {
                SetQueryConditions();
                PagerQuery query = new PagerQuery("Vw_Stock", "StockId", "*", "StockId",
                    OrderClause.OrderClauseCriteria.Descending, this.PageSize, this.PageNumber, _criterions);

                int totalCount;
                List<StockView> stocks = ServiceHelper.InventoryService.GetStockViewByPagerQuery(query, out totalCount);

                // calc storage days
                foreach (var stock in stocks)
                {
                    if (stock.InboundDate != string.Empty)
                    {
                        DateTime inboundDate = DateTime.Parse(stock.InboundDate);
                        TimeSpan inboundDateSpan = new TimeSpan(inboundDate.Ticks);
                        TimeSpan nowDateSpan = new TimeSpan(DateTime.Now.Ticks);
                        TimeSpan ts = inboundDateSpan.Subtract(nowDateSpan).Duration();
                        int days = ts.Days;
                        stock.StorageDays = days.ToString();
                    }
                }

                DataList = stocks;
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

            if (txtLocationCode.Text.Trim() != string.Empty)
                _criterions.Add(new Criterion("LocationCode", CriteriaOperator.Like, txtLocationCode.Text.Trim() + "%"));
            if (txtAreaCode.Text.Trim() != string.Empty)
                _criterions.Add(new Criterion("AreaCode", CriteriaOperator.Like, txtAreaCode.Text.Trim() + "%"));

            if (txtPlanNumber.Text.Trim() != string.Empty)
                _criterions.Add(new Criterion("PlanNumber", CriteriaOperator.Like, txtPlanNumber.Text.Trim() + "%"));
            if (txtBillNumber.Text.Trim() != string.Empty)
                _criterions.Add(new Criterion("BillNumber", CriteriaOperator.Like, txtBillNumber.Text.Trim() + "%"));
            if (txtSkuNumber.Text.Trim() != string.Empty)
                _criterions.Add(new Criterion("SkuNumber", CriteriaOperator.Like, txtSkuNumber.Text.Trim() + "%"));
            if (txtBatchNumber.Text.Trim() != string.Empty)
                _criterions.Add(new Criterion("BatchNumber", CriteriaOperator.Like, txtBatchNumber.Text.Trim() + "%"));

            if (beMerchantId.Tag != null)
            {
                var company = beMerchantId.Tag as Company;
                if (company != null)
                    _criterions.Add(new Criterion("MerchantId", CriteriaOperator.Equal, company.CompanyId));
            }
            if (beVendorId.Tag != null)
            {
                var company = beVendorId.Tag as Company;
                if (company != null)
                    _criterions.Add(new Criterion("VendorId", CriteriaOperator.Equal, company.CompanyId));
            }
        }

        public override void CustomizeGrid()
        {
            int columnIndex = 0;
            FormHelper.SetGridColumn(MainGridView, "StockId", "库存编号", 100, columnIndex++, false);

            FormHelper.SetGridColumn(MainGridView, "WarehouseId", "仓库编号", 150, columnIndex++, false);
            FormHelper.SetGridColumn(MainGridView, "WarehouseCode", "仓库代码", 150, columnIndex++, false);
            FormHelper.SetGridColumn(MainGridView, "WarehouseName", "仓库名称", 150, columnIndex++, false);

            FormHelper.SetGridColumn(MainGridView, "MerchantId", "货主", 100, columnIndex++, false);
            FormHelper.SetGridColumn(MainGridView, "VendorId", "供应商", 100, columnIndex++, false);

            FormHelper.SetGridColumn(MainGridView, "SkuId", "货物编号", 100, columnIndex++, false);
            FormHelper.SetGridColumn(MainGridView, "SkuNumber", "货物代码", 100, columnIndex++, true);
            FormHelper.SetGridColumn(MainGridView, "SkuName", "货物名称", 100, columnIndex++, true);

            FormHelper.SetGridColumn(MainGridView, "PackId", "包装编号", 200, columnIndex++, false);
            FormHelper.SetGridColumn(MainGridView, "PackName", "包装", 100, columnIndex++, true);

            FormHelper.SetGridColumn(MainGridView, "Qty", "库存数量", 100, columnIndex++, true);

            FormHelper.SetGridColumn(MainGridView, "BatchNumber", "入库批次号", 100, columnIndex++, true);

            FormHelper.SetGridColumn(MainGridView, "AreaId", "", 150, columnIndex++, false);
            FormHelper.SetGridColumn(MainGridView, "AreaCode", "库区代码", 150, columnIndex++, false);
            FormHelper.SetGridColumn(MainGridView, "AreaName", "库区名称", 150, columnIndex++, true);
            FormHelper.SetGridColumn(MainGridView, "AreaType", "", 150, columnIndex++, false);

            FormHelper.SetGridColumn(MainGridView, "LocationId", "库位编号", 100, columnIndex++, false);
            FormHelper.SetGridColumn(MainGridView, "LocationCode", "库位代码", 100, columnIndex++, true);
            FormHelper.SetGridColumn(MainGridView, "LocationName", "库位名", 100, columnIndex++, false);

            FormHelper.SetGridColumn(MainGridView, "ContainerId", "容器编号", 100, columnIndex++, false);
            FormHelper.SetGridColumn(MainGridView, "ContainerCode", "容器代码", 100, columnIndex++, true);
            FormHelper.SetGridColumn(MainGridView, "ContainerName", "容器名", 100, columnIndex++, false);

            FormHelper.SetGridColumn(MainGridView, "PlanNumber", "入库计划", 100, columnIndex++, true);
            FormHelper.SetGridColumn(MainGridView, "BillNumber", "入库单号", 100, columnIndex++, true);
            FormHelper.SetGridColumn(MainGridView, "InboundDate", "入库日期", 200, columnIndex++, true);

            FormHelper.SetGridColumn(MainGridView, "StorageDays", "库龄(天数)", 200, columnIndex++, true);

            FormHelper.SetGridColumn(MainGridView, "ProductionDate", "生产日期", 100, columnIndex++, false);
            FormHelper.SetGridColumn(MainGridView, "ExpiringDate", "过期日期", 100, columnIndex++, false);
            FormHelper.SetGridColumn(MainGridView, "ProductionBatch", "生产批号", 100, columnIndex++, false);
            FormHelper.SetGridColumn(MainGridView, "ManufacturingOrigin", "产地", 100, columnIndex++, false);
            FormHelper.SetGridColumn(MainGridView, "PropertyValue1", "属性1", 100, columnIndex++, false);
            FormHelper.SetGridColumn(MainGridView, "PropertyValue2", "属性2", 100, columnIndex++, false);
            FormHelper.SetGridColumn(MainGridView, "PropertyValue3", "属性3", 100, columnIndex++, false);
            FormHelper.SetGridColumn(MainGridView, "PropertyValue4", "属性4", 100, columnIndex++, false);
            FormHelper.SetGridColumn(MainGridView, "PropertyValue5", "属性5", 100, columnIndex++, false);
            FormHelper.SetGridColumn(MainGridView, "PropertyValue6", "属性6", 100, columnIndex++, false);

            FormHelper.SetGridColumn(MainGridView, "IsValid", "", 100, columnIndex++, false);
        }

        public override void BindGridColumnMap()
        {
            var companyLookup = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            companyLookup.DataSource = CacheHelper.CompanyCache;
            companyLookup.DisplayMember = "ShortName";
            companyLookup.ValueMember = "CompanyId";
            MainGridView.Columns["MerchantId"].ColumnEdit = companyLookup;
            MainGridView.Columns["VendorId"].ColumnEdit = companyLookup;
        }

        private void SelectCompany_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            var edit = (ButtonEdit)sender;
            if (e.Button.Kind == ButtonPredefines.Delete)
            {
                edit.Tag = null;
                edit.Text = string.Empty;
                return;
            }

            var parentForm = new XtraForm();
            parentForm.AutoSize = true;
            parentForm.StartPosition = FormStartPosition.CenterScreen;
            parentForm.ControlBox = false;
            parentForm.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            var form = new CompanyListForm(FormMode.Select, false);
            form.Size = new Size(810, 600);
            form.Parent = parentForm;
            form.ReferenceForm = parentForm;
            parentForm.ShowDialog();
            IList companys = form.GetSelectedData<Company>();
            if (companys != null && companys.Count > 0)
            {
                var company = companys[0] as Company;
                if (company != null)
                {
                    ((ButtonEdit) sender).Tag = company;
                    ((ButtonEdit) sender).Text = company.ShortName;
                }
            }
        }
        #endregion

       
    }
}



