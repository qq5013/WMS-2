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

namespace Modules.AreaModule.Views
{
    [SmartPart]
    public partial class AreaListForm : Framework.UI.Template.Single.SingleListForm
    {
        private List<Criterion> Criterions = new List<Criterion>();

        public AreaListForm()
        {
            InitializeComponent();
        }

        public AreaListForm(FormMode mode, bool isMultiSelect) : base(mode, isMultiSelect)
        {
            InitializeComponent();
        }

        public override void InitForm()
        {
            RegisterDetailForm("Modules.AreaModule.Views.AreaEditForm");
        }

        public override void InitButtonAuthority()
        {
            btnCopy.Tag = "AREA_INSERT";
            btnInsert.Tag = "AREA_INSERT";
            btnUpdate.Tag = "AREA_EDIT";
            btnDelete.Tag = "AREA_DELETE";
            btnSearch.Tag = "AREA_QUERY";
        }

        public override void LoadData()
        {
            try
            {
                SetQueryConditions();
                PagerQuery query = new PagerQuery("Area", "AreaId", "*", "AreaId", 
                    OrderClause.OrderClauseCriteria.Descending, this.PageSize, this.PageNumber, Criterions);

                int totalCount;
                DataList = ServiceHelper.WarehouseService.GetAreaByPagerQuery(query, out totalCount);
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

            FormHelper.SetGridColumn(MainGridView, "AreaId", "库区编号", 100, columnIndex++, false);

            FormHelper.SetGridColumn(MainGridView, "AreaCode", "库区代码", 150, columnIndex++, true);

            FormHelper.SetGridColumn(MainGridView, "AreaName", "库区名称", 200, columnIndex++, true);

            FormHelper.SetGridColumn(MainGridView, "AreaType", "库区类型", 100, columnIndex++, true);

            FormHelper.SetGridColumn(MainGridView, "WarehouseId", "仓库编号", 150, columnIndex++, false);

            FormHelper.SetGridColumn(MainGridView, "Length", "长度(米)", 100, columnIndex++, true);
            FormHelper.SetGridColumn(MainGridView, "Width", "宽度(米)", 100, columnIndex++, true);
            FormHelper.SetGridColumn(MainGridView, "Height", "高度(米)", 100, columnIndex++, true);

            FormHelper.SetGridColumn(MainGridView, "Remark", "描述", 200, columnIndex++, true);

            FormHelper.SetGridColumn(MainGridView, "IsActive", "是否可用", 100, columnIndex++, true);

            FormHelper.SetGridColumn(MainGridView, "CoordX", "", 100, columnIndex++, false);
            FormHelper.SetGridColumn(MainGridView, "CoordY", "", 100, columnIndex++, false);
            FormHelper.SetGridColumn(MainGridView, "CoordZ", "", 100, columnIndex++, false);

            

            FormHelper.SetGridColumn(MainGridView, "CreateUser", "", 100, columnIndex++, false);
            FormHelper.SetGridColumn(MainGridView, "CreateTime", "", 100, columnIndex++, false);
            FormHelper.SetGridColumn(MainGridView, "EditUser", "", 100, columnIndex++, false);
            FormHelper.SetGridColumn(MainGridView, "EditTime", "", 100, columnIndex++, false);

            FormHelper.SetGridColumn(MainGridView, "IsValid", "", 100, columnIndex++, false);
        }

        #region 得到下拉列表框的数据
        public override void BindGridColumnMap()
        {

            DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit dictionaryLookup = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            dictionaryLookup.DataSource = CacheHelper.DictionaryCache;
            dictionaryLookup.DisplayMember = "DictionaryValue";
            dictionaryLookup.ValueMember = "DictionaryId";
            MainGridView.Columns["AreaType"].ColumnEdit = dictionaryLookup;
        }
        #endregion

        public override void SetQueryConditions()
        {
            Criterions.Clear();

            Criterions.Add(new Criterion("WarehouseId", CriteriaOperator.Equal, GlobalState.CurrentWarehouse.WarehouseId));

            if (txtAreaCode.Text.Trim() != "")
                Criterions.Add(new Criterion("AreaCode", CriteriaOperator.Like, txtAreaCode.Text.Trim() + "%"));
            if (txtAreaName.Text.Trim() != "")
                Criterions.Add(new Criterion("AreaName", CriteriaOperator.Like, txtAreaName.Text.Trim() + "%"));
        }

        public override void DeleteData()
        {
            Area area = CurrentData as Area;
            if (area == null) return;

            bool deleteResult = false;
            try
            {
                deleteResult = ServiceHelper.WarehouseService.DeleteArea(area.AreaId);
            }
            catch (FaultException<ServiceError> sex)
            {
                if (sex.Detail != null)
                    FormHelper.ShowWarningDialog(sex.Detail.ErrorMessage);
            }

            if (!deleteResult)
                FormHelper.ShowInformationDialog("删除库区失败。");
        }
    }
}

