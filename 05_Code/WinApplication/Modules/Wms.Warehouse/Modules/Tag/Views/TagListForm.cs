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

namespace Modules.TagModule.Views
{
    [SmartPart]
    public partial class TagListForm : Framework.UI.Template.Single.SingleListForm
    {
        private List<Criterion> _criterions = new List<Criterion>();

        public TagListForm()
        {
            InitializeComponent();
        }

        public TagListForm(FormMode mode, bool isMultiSelect) : base(mode, isMultiSelect)
        {
            InitializeComponent();
        }

        public override void InitForm()
        {
            RegisterDetailForm("Modules.TagModule.Views.TagEditForm");
        }

        public override void InitButtonAuthority()
        {
            btnCopy.Tag = "TAG_INSERT";
            btnInsert.Tag = "TAG_INSERT";
            btnUpdate.Tag = "TAG_EDIT";
            btnDelete.Tag = "TAG_DELETE";
            btnSearch.Tag = "TAG_QUERY";
        }

        public override void LoadData()
        {
            try
            {
                SetQueryConditions();
                PagerQuery query = new PagerQuery("Tag", "TagId", "*", "TagId", 
                    OrderClause.OrderClauseCriteria.Descending, this.PageSize, this.PageNumber, _criterions);

                int totalCount;
                DataList = ServiceHelper.WarehouseService.GetTagByPagerQuery(query, out totalCount);
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

            FormHelper.SetGridColumn(MainGridView, "WarehouseId", "≤÷ø‚±‡∫≈", 100, columnIndex++, false);

            FormHelper.SetGridColumn(MainGridView, "TagId", "±Í«©±‡∫≈", 100, columnIndex++, false);

            FormHelper.SetGridColumn(MainGridView, "TagNumber", "…Ë÷√¥˙¬Î", 150, columnIndex++, true);

            FormHelper.SetGridColumn(MainGridView, "Remark", "√Ë ˆ", 200, columnIndex++, true);

            FormHelper.SetGridColumn(MainGridView, "IsActive", " «∑Òø…”√", 100, columnIndex++, true);

            FormHelper.SetGridColumn(MainGridView, "IsValid", "", 100, columnIndex++, false);

            FormHelper.SetGridColumn(MainGridView, "CreateUser", "", 100, columnIndex++, false);

            FormHelper.SetGridColumn(MainGridView, "CreateTime", "", 100, columnIndex++, false);

            FormHelper.SetGridColumn(MainGridView, "EditUser", "", 100, columnIndex++, false);

            FormHelper.SetGridColumn(MainGridView, "EditTime", "", 100, columnIndex++, false);
        }

        public override void SetQueryConditions()
        {
            _criterions.Clear();
            _criterions.Add(new Criterion("WarehouseId", CriteriaOperator.Like, GlobalState.CurrentWarehouse.WarehouseId));
            if (txtTagNumber.Text.Trim() != "")
                _criterions.Add(new Criterion("TagNumber", CriteriaOperator.Like, txtTagNumber.Text.Trim() + "%"));
        }

        public override void DeleteData()
        {
            Tag tag = CurrentData as Tag;
            if (tag == null) return;

            bool deleteResult = false;
            try
            {
                deleteResult = ServiceHelper.WarehouseService.DeleteTag(tag.TagId);
            }
            catch (FaultException<ServiceError> sex)
            {
                if (sex.Detail != null)
                    FormHelper.ShowWarningDialog(sex.Detail.ErrorMessage);
            }

            if (!deleteResult)
                FormHelper.ShowInformationDialog("…æ≥˝±Í«© ß∞‹°£");
        }
    }
}

