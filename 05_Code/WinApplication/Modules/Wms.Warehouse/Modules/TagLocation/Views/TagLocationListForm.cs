using System;
using System.Collections;
using System.Collections.Generic;
using System.ServiceModel;
using System.Windows.Forms;
using Business.Common.Exception;
using Business.Common.QueryModel;
using Business.Domain.Wms;
using Business.Domain.Warehouse;
using Framework.UI.Template.Common;
using Microsoft.Practices.CompositeUI.SmartParts;
using Modules.LocationModule.Views;
using Modules.TagModule.Views;
using Wms.Common;
using DevExpress.XtraEditors.Controls;

namespace Modules.TagLocationModule.Views
{
    [SmartPart]
    public partial class TagLocationListForm : Framework.UI.Template.Single.SingleListForm
    {
        private List<Criterion> _criterions = new List<Criterion>();

        public TagLocationListForm()
        {
            InitializeComponent();
        }

        public TagLocationListForm(FormMode mode, bool isMultiSelect)
            : base(mode, isMultiSelect)
        {
            InitializeComponent();
        }

        public override void InitForm()
        {
            RegisterDetailForm("Modules.TagLocationModule.Views.TagLocationEditForm");
        }

        public override void InitButtonAuthority()
        {
            btnCopy.Tag = "TAGLOCATION_INSERT";
            btnInsert.Tag = "TAGLOCATION_INSERT";
            btnUpdate.Tag = "TAGLOCATION_EDIT";
            btnDelete.Tag = "TAGLOCATION_DELETE";
            btnSearch.Tag = "TAGLOCATION_QUERY";
        }

        public override void LoadData()
        {
            try
            {
                SetQueryConditions();
                PagerQuery query = new PagerQuery("Vw_LocationTag", "Id", "*", "Id", 
                    OrderClause.OrderClauseCriteria.Descending, this.PageSize, this.PageNumber, _criterions);

                int totalCount;
                DataList = ServiceHelper.WarehouseService.GetLocationTagViewByPagerQuery(query, out totalCount);
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

            FormHelper.SetGridColumn(MainGridView, "Id", "×Ô¶¯±àºÅ", 100, columnIndex++, false);

            FormHelper.SetGridColumn(MainGridView, "WarehouseId", "", 100, columnIndex++, false);

            FormHelper.SetGridColumn(MainGridView, "LocationId", "", 100, columnIndex++, false);

            FormHelper.SetGridColumn(MainGridView, "TagId", "", 100, columnIndex++, false);

            FormHelper.SetGridColumn(MainGridView, "WarehouseName", "²Ö¿âÃû³Æ", 100, columnIndex++, false);

            FormHelper.SetGridColumn(MainGridView, "LocationCode", "¿âÎ»´úÂë", 100, columnIndex++, true);

            FormHelper.SetGridColumn(MainGridView, "LocationName", "¿âÎ»Ãû³Æ", 100, columnIndex++, true);

            FormHelper.SetGridColumn(MainGridView, "TagNumber", "±êÇ©Ãû³Æ", 100, columnIndex++, true);

            FormHelper.SetGridColumn(MainGridView, "IsValid", "", 100, columnIndex++, false);
        }

        public override void SetQueryConditions()
        {
            _criterions.Clear();

            if (beLocationId.Tag != null)
                _criterions.Add(new Criterion("LocationId", CriteriaOperator.Equal, ((Location)beLocationId.Tag).LocationId ));
            if (beTagId.Tag != null)
                _criterions.Add(new Criterion("TagId", CriteriaOperator.Equal, ((Tag)beTagId.Tag).TagId));
        }

        public override void DeleteData()
        {
            LocationTag location = CurrentData as LocationTag;
            if (location == null) return;

            bool deleteResult = false;
            try
            {
                deleteResult = ServiceHelper.WarehouseService.DeleteLocationTag(location.Id);
            }
            catch (FaultException<ServiceError> sex)
            {
                if (sex.Detail != null)
                    FormHelper.ShowWarningDialog(sex.Detail.ErrorMessage);
            }

            if (!deleteResult)
                FormHelper.ShowInformationDialog("É¾³ýÓ³ÉäÊ§°Ü¡£");
        }

        private void beLocationId_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
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
            IList areas = form.GetSelectedData<Location>();
            if (areas != null && areas.Count > 0)
            {
                Location location = areas[0] as Location;
                beLocationId.Tag = location;
                beLocationId.Text = location.LocationName;
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

