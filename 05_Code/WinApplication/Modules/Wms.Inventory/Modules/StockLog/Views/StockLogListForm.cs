using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;
using System.Collections.Generic;
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

namespace Modules.StockLogModule.Views
{
    [SmartPart]
    public partial class StockLogListForm : SingleListForm
    {

        #region properties
        private List<Criterion> Criterions = new List<Criterion>();

        #endregion 

        public StockLogListForm()
        {
            InitializeComponent();
            
        }

        public StockLogListForm(FormMode mode, bool isMultiSelect)
            : base(mode, isMultiSelect)
        {
            InitializeComponent();
        }

        public StockLogListForm(FormMode mode, bool isMultiSelect, bool isInvoice)
            : base(mode, isMultiSelect)
        {
            InitializeComponent();
        }

        #region template methods


        public void InitComboBox()
        {
            // bill status
            IEnumerable<DataDictionary> logtype = CacheHelper.GetDictionaryByCategory(DictionaryEnum.STOCKLOG_TYPE.ToString());
            leLogType.Properties.DataSource = logtype;
            leLogType.Properties.DisplayMember = "DictionaryValue";
            leLogType.Properties.ValueMember = "DictionaryId";
            leLogType.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DictionaryCode", "代码"));
            leLogType.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DictionaryValue", "值"));
        }

        public override void InitForm()
        {
            InitComboBox();

            deLogTimeStart.DateTime = DateTime.Now.AddDays(-7);
            deLogTimeEnd.DateTime = DateTime.Now.AddDays(7);
        }

        public override void SetButtonStatus()
        {
            btnInsert.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnCopy.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnUpdate.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
        }

        public override void LoadData()
        {
            try
            {
                SetQueryConditions();
                PagerQuery query = new PagerQuery("Vw_StockLog", "Id", "*", "Id",
                    OrderClause.OrderClauseCriteria.Descending, this.PageSize, this.PageNumber, Criterions);

                int totalCount;
                DataList = ServiceHelper.InventoryService.GetStockLogViewByPagerQuery(query, out totalCount);
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
            Criterions.Clear();

            Criterions.Add(new Criterion("WarehouseId", CriteriaOperator.Equal, GlobalState.CurrentWarehouse.WarehouseId));

            if (txtLocationCode.Text.Trim() != string.Empty)
                Criterions.Add(new Criterion("LocationCode", CriteriaOperator.Like, txtLocationCode.Text.Trim() + "%"));
            if (txtAreaCode.Text.Trim() != string.Empty)
                Criterions.Add(new Criterion("AreaCode", CriteriaOperator.Like, txtAreaCode.Text.Trim() + "%"));

            if (txtLinkBillNumber.Text.Trim() != string.Empty)
                Criterions.Add(new Criterion("LinkBillNumber", CriteriaOperator.Like, txtLinkBillNumber.Text.Trim() + "%"));
            if (txtBillNumber.Text.Trim() != string.Empty)
                Criterions.Add(new Criterion("InboundBillNumber", CriteriaOperator.Like, txtBillNumber.Text.Trim() + "%"));

            if (txtSkuNumber.Text.Trim() != string.Empty)
                Criterions.Add(new Criterion("SkuNumber", CriteriaOperator.Like, txtSkuNumber.Text.Trim() + "%"));
            if (txtBatchNumber.Text.Trim() != string.Empty)
                Criterions.Add(new Criterion("BatchNumber", CriteriaOperator.Like, txtBatchNumber.Text.Trim() + "%"));

            if (leLogType.EditValue != null)
                Criterions.Add(new Criterion("LogType", CriteriaOperator.Equal, (int)leLogType.EditValue));
            if (deLogTimeStart.Text != string.Empty)
                Criterions.Add(new Criterion("LogTime", CriteriaOperator.GreaterThanOrEqual, Convert.ToDateTime(deLogTimeStart.Text.Trim()).ToString("yyyy-MM-dd")));
            if (deLogTimeEnd.Text != string.Empty)
                Criterions.Add(new Criterion("LogTime", CriteriaOperator.LesserThanOrEqual, Convert.ToDateTime(deLogTimeEnd.Text.Trim()).ToString("yyyy-MM-dd")));
        }

        public override void CustomizeGrid()
        {
            int columnIndex = 0;

            FormHelper.SetGridColumn(MainGridView, "Id", "自动编号", 100, columnIndex++, false);

            FormHelper.SetGridColumn(MainGridView, "LogType", "日志类型", 150, columnIndex++, false);
            FormHelper.SetGridColumn(MainGridView, "LogTypeName", "日志类型", 100, columnIndex++, true);

            FormHelper.SetGridColumn(MainGridView, "LogTime", "日志时间", 100, columnIndex++, true);

            FormHelper.SetGridColumn(MainGridView, "LinkBillType", "关联单据类型", 200, columnIndex++, false);
            FormHelper.SetGridColumn(MainGridView, "BillTypeName", "关联单据类型", 200, columnIndex++, true);
            FormHelper.SetGridColumn(MainGridView, "LinkBillId", "关联单据编号", 100, columnIndex++, false);
            FormHelper.SetGridColumn(MainGridView, "LinkBillNumber", "关联单据号", 100, columnIndex++, true);

            FormHelper.SetGridColumn(MainGridView, "SkuId", "货物编号", 100, columnIndex++, false);
            FormHelper.SetGridColumn(MainGridView, "SkuNumber", "货物代码", 100, columnIndex++, true);
            FormHelper.SetGridColumn(MainGridView, "SkuName", "货物名称", 100, columnIndex++, true);

            FormHelper.SetGridColumn(MainGridView, "PackId", "包装编号", 200, columnIndex++, false);
            FormHelper.SetGridColumn(MainGridView, "PackName", "包装", 100, columnIndex++, true);
            FormHelper.SetGridColumn(MainGridView, "BeforeQty", "变更前数量", 100, columnIndex++, true);

            FormHelper.SetGridColumn(MainGridView, "InboundQty", "入库数量", 100, columnIndex++, true);

            FormHelper.SetGridColumn(MainGridView, "OutboundQty", "出库数量", 100, columnIndex++, true);

            FormHelper.SetGridColumn(MainGridView, "AfterQty", "变更后数量", 100, columnIndex++, true);

            FormHelper.SetGridColumn(MainGridView, "BatchNumber", "入库批次号", 100, columnIndex++, true);

            FormHelper.SetGridColumn(MainGridView, "WarehouseId", "仓库编号", 100, columnIndex++, false);
            FormHelper.SetGridColumn(MainGridView, "WarehouseCode", "仓库代码", 100, columnIndex++, false);
            FormHelper.SetGridColumn(MainGridView, "WarehouseName", "仓库名称", 100, columnIndex++, false);

            FormHelper.SetGridColumn(MainGridView, "AreaId", "", 150, columnIndex++, false);
            FormHelper.SetGridColumn(MainGridView, "AreaCode", "库区代码", 150, columnIndex++, false);
            FormHelper.SetGridColumn(MainGridView, "AreaName", "库区名称", 150, columnIndex++, true);

            FormHelper.SetGridColumn(MainGridView, "LocationId", "库位编号", 100, columnIndex++, false);
            FormHelper.SetGridColumn(MainGridView, "LocationCode", "库位代码", 100, columnIndex++, false);
            FormHelper.SetGridColumn(MainGridView, "LocationName", "库位名", 100, columnIndex++, true);

            FormHelper.SetGridColumn(MainGridView, "ContainerId", "容器编号", 100, columnIndex++, false);
            FormHelper.SetGridColumn(MainGridView, "ContainerCode", "容器代码", columnIndex++, 17, false);
            FormHelper.SetGridColumn(MainGridView, "ContainerName", "容器", 100, columnIndex++, true);

            FormHelper.SetGridColumn(MainGridView, "InboundBillNumber", "入库单号", 100, columnIndex++, true);

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
            //
        }
        #endregion
    }
}



