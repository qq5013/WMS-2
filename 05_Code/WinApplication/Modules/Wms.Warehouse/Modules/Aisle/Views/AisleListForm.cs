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

namespace Modules.AisleModule.Views
{
    [SmartPart]
    public partial class AisleListForm : Framework.UI.Template.Single.SingleListForm
    {
        private List<Criterion> Criterions = new List<Criterion>();

        public AisleListForm()
        {
            InitializeComponent();
        }

        public AisleListForm(FormMode mode, bool isMultiSelect)
            : base(mode, isMultiSelect)
        {
            InitializeComponent();
        }

        public override void InitForm()
        {
            RegisterDetailForm("Modules.AisleModule.Views.AisleEditForm");
        }

        public override void InitButtonAuthority()
        {
            btnCopy.Tag = "AISLE_INSERT";
            btnInsert.Tag = "AISLE_INSERT";
            btnUpdate.Tag = "AISLE_EDIT";
            btnDelete.Tag = "AISLE_DELETE";
            btnSearch.Tag = "AISLE_QUERY";
        }

        public override void LoadData()
        {
            try
            {
                SetQueryConditions();
                PagerQuery query = new PagerQuery("Aisle", "AisleId", "*", "AisleId", 
                    OrderClause.OrderClauseCriteria.Descending, this.PageSize, this.PageNumber, Criterions);

                int totalCount;
                DataList = ServiceHelper.WarehouseService.GetAisleByPagerQuery(query, out totalCount);
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

            FormHelper.SetGridColumn(MainGridView, "WarehouseId", "仓库编号", 100, columnIndex++, false);

            FormHelper.SetGridColumn(MainGridView, "AisleId", "通道编号", 100, columnIndex++, false);

            FormHelper.SetGridColumn(MainGridView, "AisleCode", "通道代码", 150, columnIndex++, true);

            FormHelper.SetGridColumn(MainGridView, "AisleName", "通道名称", 200, columnIndex++, true);

            FormHelper.SetGridColumn(MainGridView, "DirectionAngle", "方向角度", 150, columnIndex++, true);

            FormHelper.SetGridColumn(MainGridView, "Length", "长度(米)", 100, columnIndex++, true);
            FormHelper.SetGridColumn(MainGridView, "Width", "宽度(米)", 100, columnIndex++, true);
            FormHelper.SetGridColumn(MainGridView, "Height", "高度(米)", 100, columnIndex++, true);

            FormHelper.SetGridColumn(MainGridView, "CoordX", "", 100, columnIndex++, false);
            FormHelper.SetGridColumn(MainGridView, "CoordY", "", 100, columnIndex++, false);
            FormHelper.SetGridColumn(MainGridView, "CoordZ", "", 100, columnIndex++, false);
            

            FormHelper.SetGridColumn(MainGridView, "Remark", "描述", 200, columnIndex++, true);

            FormHelper.SetGridColumn(MainGridView, "IsActive", "是否可用", 100, columnIndex++, true);

            FormHelper.SetGridColumn(MainGridView, "IsValid", "", 100, columnIndex++, false);
        }

        public override void SetQueryConditions()
        {
            Criterions.Clear();
            Criterions.Add(new Criterion("WarehouseId", CriteriaOperator.Like, GlobalState.CurrentWarehouse.WarehouseId));
            if (txtAisleCode.Text.Trim() != "")
                Criterions.Add(new Criterion("AisleCode", CriteriaOperator.Like, txtAisleCode.Text.Trim() + "%"));
            if (txtAisleName.Text.Trim() != "")
                Criterions.Add(new Criterion("AisleName", CriteriaOperator.Like, txtAisleName.Text.Trim() + "%"));
        }

        public override void DeleteData()
        {
            Aisle aisle = CurrentData as Aisle;
            if (aisle == null) return;

            bool deleteResult = false;
            try
            {
                deleteResult = ServiceHelper.WarehouseService.DeleteAisle(aisle.AisleId);
            }
            catch (FaultException<ServiceError> sex)
            {
                if (sex.Detail != null)
                    FormHelper.ShowWarningDialog(sex.Detail.ErrorMessage);
            }

            if (!deleteResult)
                FormHelper.ShowInformationDialog("删除通道失败。");
        }
    }
}

