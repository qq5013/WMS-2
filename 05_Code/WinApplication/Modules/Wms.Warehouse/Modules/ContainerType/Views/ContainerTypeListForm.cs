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

namespace Modules.ContainerTypeModule.Views
{
    [SmartPart]
    public partial class ContainerTypeListForm : Framework.UI.Template.Single.SingleListForm
    {
        private List<Criterion> _criterions = new List<Criterion>();

        public ContainerTypeListForm()
        {
            InitializeComponent();
        }

        public ContainerTypeListForm(FormMode mode, bool isMultiSelect)
            : base(mode, isMultiSelect)
        {
            InitializeComponent();
        }

        public override void InitForm()
        {
            RegisterDetailForm("Modules.ContainerTypeModule.Views.ContainerTypeEditForm");
        }

        public override void InitButtonAuthority()
        {
            btnCopy.Tag = "CONTAINERTYPE_INSERT";
            btnInsert.Tag = "CONTAINERTYPE_INSERT";
            btnUpdate.Tag = "CONTAINERTYPE_EDIT";
            btnDelete.Tag = "CONTAINERTYPE_DELETE";
            btnSearch.Tag = "CONTAINERTYPE_QUERY";
        }

        public override void LoadData()
        {
            try
            {
                SetQueryConditions();
                PagerQuery query = new PagerQuery("ContainerType", "TypeId", "*", "TypeId", 
                    OrderClause.OrderClauseCriteria.Descending, this.PageSize, this.PageNumber, _criterions);

                int totalCount;
                DataList = ServiceHelper.WarehouseService.GetContainerTypeByPagerQuery(query, out totalCount);
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

            FormHelper.SetGridColumn(MainGridView, "TypeId", "容器类型编号", 100, columnIndex++, false);

            FormHelper.SetGridColumn(MainGridView, "TypeCode", "容器类型代码", 150, columnIndex++, true);

            FormHelper.SetGridColumn(MainGridView, "TypeName", "容器类型名称", 200, columnIndex++, true);

            FormHelper.SetGridColumn(MainGridView, "PurposeType", "用途类型", 100, columnIndex++, true);

            FormHelper.SetGridColumn(MainGridView, "Length", "长度(米)", 100, columnIndex++, true);
            FormHelper.SetGridColumn(MainGridView, "Width", "宽度(米)", 100, columnIndex++, true);
            FormHelper.SetGridColumn(MainGridView, "Height", "高度(米)", 100, columnIndex++, true);

            FormHelper.SetGridColumn(MainGridView, "Weight", "自重(千克)", 100, columnIndex++, true);
            FormHelper.SetGridColumn(MainGridView, "BearingWeight", "承重(千克)", 100, columnIndex++, true);


            FormHelper.SetGridColumn(MainGridView, "IsValid", "", 100, columnIndex++, false);
        }

        public override void SetQueryConditions()
        {
            _criterions.Clear();
            _criterions.Add(new Criterion("WarehouseId", CriteriaOperator.Like, GlobalState.CurrentWarehouse.WarehouseId));
            if (txtTypeCode.Text.Trim() != "")
                _criterions.Add(new Criterion("TypeCode", CriteriaOperator.Like, txtTypeCode.Text.Trim() + "%"));
            if (txtTypeName.Text.Trim() != "")
                _criterions.Add(new Criterion("TypeName", CriteriaOperator.Like, txtTypeName.Text.Trim() + "%"));
        }

        public override void DeleteData()
        {
            ContainerType type = CurrentData as ContainerType;
            if (type == null) return;

            bool deleteResult = false;
            try
            {
                deleteResult = ServiceHelper.WarehouseService.DeleteContainerType(type.TypeId);
            }
            catch (FaultException<ServiceError> sex)
            {
                if (sex.Detail != null)
                    FormHelper.ShowWarningDialog(sex.Detail.ErrorMessage);
            }

            if (!deleteResult)
                FormHelper.ShowInformationDialog("删除容器类型失败。");
        }
    }
}

