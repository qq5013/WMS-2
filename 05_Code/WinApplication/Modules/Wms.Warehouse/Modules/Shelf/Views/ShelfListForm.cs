using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Business.Common.Exception;
using Business.Common.QueryModel;
using Business.Domain.Warehouse;
using Framework.UI.Template.Common;
using Microsoft.Practices.CompositeUI.SmartParts;
using Wms.Common;
using System.ServiceModel;

namespace Modules.ShelfModule.Views
{
    [SmartPart]
    public partial class ShelfListForm : Framework.UI.Template.Single.SingleListForm
    {
        private List<Criterion> _criterions = new List<Criterion>();

        public ShelfListForm()
        {
            InitializeComponent();
        }

        public ShelfListForm(FormMode mode, bool isMultiSelect)
            : base(mode, isMultiSelect)
        {
            InitializeComponent();
        }

        public override void InitForm()
        {
            RegisterDetailForm("Modules.ShelfModule.Views.ShelfEditForm");
        }

        public override void InitButtonAuthority()
        {
            btnCopy.Tag = "SHELF_INSERT";
            btnInsert.Tag = "SHELF_INSERT";
            btnUpdate.Tag = "SHELF_EDIT";
            btnDelete.Tag = "SHELF_DELETE";
            btnSearch.Tag = "SHELF_QUERY";
        }

        public override void LoadData()
        {
            try
            {
                SetQueryConditions();
                PagerQuery query = new PagerQuery("Shelf", "ShelfId", "*", "ShelfId", 
                    OrderClause.OrderClauseCriteria.Descending, this.PageSize, this.PageNumber, _criterions);

                int totalCount;
                DataList = ServiceHelper.WarehouseService.GetShelfByPagerQuery(query, out totalCount);
                SetSplitPage(totalCount);
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

            FormHelper.SetGridColumn(MainGridView, "ShelfId", "货架编号", 100, columnIndex++, false);

            FormHelper.SetGridColumn(MainGridView, "ShelfCode", "货架代码", 150, columnIndex++, true);

            FormHelper.SetGridColumn(MainGridView, "ShelfName", "货架名称", 200, columnIndex++, true);

            FormHelper.SetGridColumn(MainGridView, "ShelfType", "货架类型", 100, columnIndex++, true);

            FormHelper.SetGridColumn(MainGridView, "WarehouseId", "仓库编号", 150, columnIndex++, false);
            FormHelper.SetGridColumn(MainGridView, "AreaId", "仓库编号", 150, columnIndex++, false);
            FormHelper.SetGridColumn(MainGridView, "AisleId", "仓库编号", 150, columnIndex++, false);

            FormHelper.SetGridColumn(MainGridView, "Length", "长度(米)", 100, columnIndex++, true);
            FormHelper.SetGridColumn(MainGridView, "Width", "宽度(米)", 100, columnIndex++, true);
            FormHelper.SetGridColumn(MainGridView, "Height", "高度(米)", 100, columnIndex++, true);

            FormHelper.SetGridColumn(MainGridView, "CoordX", "", 100, columnIndex++, false);
            FormHelper.SetGridColumn(MainGridView, "CoordY", "", 100, columnIndex++, false);
            FormHelper.SetGridColumn(MainGridView, "CoordZ", "", 100, columnIndex++, false);

            FormHelper.SetGridColumn(MainGridView, "Row", "行数", 100, columnIndex++, true);
            FormHelper.SetGridColumn(MainGridView, "Column", "列数", 100, columnIndex++, true);
            FormHelper.SetGridColumn(MainGridView, "Depth", "深度", 100, columnIndex++, true);
            FormHelper.SetGridColumn(MainGridView, "DirectionAngle", "方向角度", 100, columnIndex++, true);

            FormHelper.SetGridColumn(MainGridView, "Remark", "描述", 200, columnIndex++, false);
            FormHelper.SetGridColumn(MainGridView, "CreateUser", "", 100, columnIndex++, false);
            FormHelper.SetGridColumn(MainGridView, "CreateTime", "", 100, columnIndex++, false);
            FormHelper.SetGridColumn(MainGridView, "EditUser", "", 100, columnIndex++, false);
            FormHelper.SetGridColumn(MainGridView, "EditTime", "", 100, columnIndex++, false);
            FormHelper.SetGridColumn(MainGridView, "IsActive", "是否可用", 100, columnIndex++, true);

            FormHelper.SetGridColumn(MainGridView, "IsValid", "", 100, columnIndex++, false);
        }

        #region 得到下拉列表框的数据
        public override void BindGridColumnMap()
        {
            DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit dictionaryLookup = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            dictionaryLookup.DataSource = CacheHelper.DictionaryCache;
            dictionaryLookup.DisplayMember = "DictionaryValue";
            dictionaryLookup.ValueMember = "DictionaryId";
            MainGridView.Columns["ShelfType"].ColumnEdit = dictionaryLookup;
        }
        #endregion

        public override void SetQueryConditions()
        {
            _criterions.Clear();

            _criterions.Add(new Criterion("WarehouseId", CriteriaOperator.Equal, GlobalState.CurrentWarehouse.WarehouseId));

            if (txtShelfCode.Text.Trim() != "")
                _criterions.Add(new Criterion("ShelfCode", CriteriaOperator.Like, txtShelfCode.Text.Trim() + "%"));
            if (txtShelfName.Text.Trim() != "")
                _criterions.Add(new Criterion("ShelfName", CriteriaOperator.Like, txtShelfName.Text.Trim() + "%"));
        }

        public override void DeleteData()
        {
            Shelf shelf = CurrentData as Shelf;
            if (shelf == null) return;

            bool deleteResult = false;
            try
            {
                deleteResult = ServiceHelper.WarehouseService.DeleteShelf(shelf.ShelfId);
            }
            catch (FaultException<ServiceError> sex)
            {
                if (sex.Detail != null)
                    FormHelper.ShowWarningDialog(sex.Detail.ErrorMessage);
            }

            if (!deleteResult)
                FormHelper.ShowInformationDialog("删除货架失败。");
        }
    }
}

