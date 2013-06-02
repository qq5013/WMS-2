using System;
using System.Collections;
using System.Collections.Generic;
using System.ServiceModel;
using System.Windows.Forms;
using Business.Common.Exception;
using Business.Common.QueryModel;
using Business.Domain.Warehouse;
using Business.Domain.Wms;
using Framework.UI.Template.Common;
using Microsoft.Practices.CompositeUI.SmartParts;
using Modules.SkuModule.Views;
using Modules.TagModule.Views;
using Wms.Common;
using DevExpress.XtraEditors.Controls;

namespace Modules.TagSkuModule.Views
{
    [SmartPart]
    public partial class TagSkuListForm : Framework.UI.Template.Single.SingleListForm
    {
        private List<Criterion> _criterions = new List<Criterion>();

        public TagSkuListForm()
        {
            InitializeComponent();
        }

        public TagSkuListForm(FormMode mode, bool isMultiSelect)
            : base(mode, isMultiSelect)
        {
            InitializeComponent();
        }

        public override void InitForm()
        {
            RegisterDetailForm("Modules.TagSkuModule.Views.TagSkuEditForm");
        }

        public override void InitButtonAuthority()
        {
            btnCopy.Tag = "TAGSKU_INSERT";
            btnInsert.Tag = "TAGSKU_INSERT";
            btnUpdate.Tag = "TAGSKU_EDIT";
            btnDelete.Tag = "TAGSKU_DELETE";
            btnSearch.Tag = "TAGSKU_QUERY";
        }

        public override void LoadData()
        {
            try
            {
                SetQueryConditions();
                PagerQuery query = new PagerQuery("Vw_SkuTag", "Id", "*", "Id", 
                    OrderClause.OrderClauseCriteria.Descending, this.PageSize, this.PageNumber, _criterions);

                int totalCount;
                DataList = ServiceHelper.WarehouseService.GetSkuTagViewByPagerQuery(query, out totalCount);
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

            FormHelper.SetGridColumn(MainGridView, "Id", "”≥…‰±‡∫≈", 100, columnIndex++, false);

            FormHelper.SetGridColumn(MainGridView, "WarehouseId", "", 150, columnIndex++, false);

            FormHelper.SetGridColumn(MainGridView, "SkuNumber", "ªıŒÔ¥˙¬Î", 200, columnIndex++, true);
            FormHelper.SetGridColumn(MainGridView, "SkuName", "ªıŒÔ√˚≥∆", 200, columnIndex++, true);

            FormHelper.SetGridColumn(MainGridView, "TagNumber", "±Í«©", 150, columnIndex++, true);
            FormHelper.SetGridColumn(MainGridView, "SkuId", "", 150, columnIndex++, false);
            FormHelper.SetGridColumn(MainGridView, "TagId", "", 150, columnIndex++, false);
            FormHelper.SetGridColumn(MainGridView, "WarehouseName", "", 100, columnIndex++, false);
            FormHelper.SetGridColumn(MainGridView, "IsValid", "", 100, columnIndex++, false);
        }

        public override void SetQueryConditions()
        {
            _criterions.Clear();

            if (beTagId.Tag != null)
                _criterions.Add(new Criterion("TagId", CriteriaOperator.Equal, ((Tag)beTagId.Tag).TagId));
            if (beSkuId.Tag != null)
                _criterions.Add(new Criterion("SkuId", CriteriaOperator.Equal, ((Sku)beSkuId.Tag).SkuId));
        }

        public override void DeleteData()
        {
            SkuTag skutag = CurrentData as SkuTag;
            if (skutag == null) return;

            bool deleteResult = false;
            try
            {
                deleteResult = ServiceHelper.WarehouseService.DeleteSkuTag(skutag.Id);
            }
            catch (FaultException<ServiceError> sex)
            {
                if (sex.Detail != null)
                    FormHelper.ShowWarningDialog(sex.Detail.ErrorMessage);
            }

            if (!deleteResult)
                FormHelper.ShowInformationDialog("…æ≥˝”≥…‰ ß∞‹°£");
        }

        private void beSkuId_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
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
            SkuListForm form = new SkuListForm(FormMode.Select, false);
            form.Size = new System.Drawing.Size(810, 600);
            form.Parent = parentForm;
            form.ReferenceForm = parentForm;
            parentForm.ShowDialog();
            IList areas = form.GetSelectedData<Sku>();
            if (areas != null && areas.Count > 0)
            {
                Sku sku = areas[0] as Sku;
                beSkuId.Tag = sku;
                beSkuId.Text = sku.SkuName;
            }
        }

        private void beTagId_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
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
            TagListForm form = new TagListForm(FormMode.Select, false);
            form.Size = new System.Drawing.Size(810, 600);
            form.Parent = parentForm;
            form.ReferenceForm = parentForm;
            parentForm.ShowDialog();
            IList areas = form.GetSelectedData<Tag>();
            if (areas != null && areas.Count > 0)
            {
                Tag tag = areas[0] as Tag;
                beTagId.Tag = tag;
                beTagId.Text = tag.TagNumber;
            }
        }
    }
}

