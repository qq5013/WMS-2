using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using Business.Common.Exception;
using Business.Common.QueryModel;
using Business.Domain.Warehouse;
using Framework.UI.Template.Common;
using Microsoft.Practices.CompositeUI.SmartParts;
using Wms.Common;
using System.ServiceModel;
using Business.Common.DataDictionary;
using Business.Domain.Application;
using Modules.AreaModule.Views;
using DevExpress.XtraEditors.Controls;
using Modules.LocationModule.Barcode;

namespace Modules.LocationModule.Views
{
    [SmartPart]
    public partial class LocationListForm : Framework.UI.Template.Single.SingleListForm
    {
        private List<Criterion> _criterions = new List<Criterion>();

        private int _areaTypeId;

        public LocationListForm()
        {
            InitializeComponent();
        }

        public LocationListForm(FormMode mode, bool isMultiSelect) : base(mode, isMultiSelect)
        {
            InitializeComponent();
        }

        public LocationListForm(FormMode mode, bool isMultiSelect, int areaTypeId)
            : base(mode, isMultiSelect)
        {
            InitializeComponent();
            _areaTypeId = areaTypeId;

            
        }

        public override void InitForm()
        {
            RegisterDetailForm("Modules.LocationModule.Views.LocationEditForm");

            InitComboBox();

            if (_areaTypeId > 0)
            {
                leAreaType.EditValue = _areaTypeId;
                leAreaType.Enabled = false;
            }
        }

        private void InitComboBox()
        {
            IEnumerable<DataDictionary> areaTypes = CacheHelper.GetDictionaryByCategory(DictionaryEnum.AREA_TYPE.ToString());
            leAreaType.Properties.DataSource = areaTypes;
            leAreaType.Properties.DisplayMember = "DictionaryValue";
            leAreaType.Properties.ValueMember = "DictionaryId";
            leAreaType.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DictionaryCode", "����"));
            leAreaType.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DictionaryValue", "ֵ"));
        }

        public override void InitButtonAuthority()
        {
            btnCopy.Tag = "Location_INSERT";
            btnInsert.Tag = "Location_INSERT";
            btnUpdate.Tag = "Location_EDIT";
            btnDelete.Tag = "Location_DELETE";
            btnSearch.Tag = "Location_QUERY";
        }

        public override void SetButtonStatus()
        {
            //base.SetButtonStatus();
            btnPrint.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnPrint.Caption = @"��ӡ�����ǩ";
        }

        public override void PrintData()
        {
            //base.PrintData();
            Location location = CurrentData as Location;
            if (location == null) return;

            LocationLabel label = new LocationLabel();
            string data = string.Format(LocationLabel.DataFormat, location.LocationCode, location.LocationName, location.Barcode);
            label.AppendData(data);
            label.Print();
        }

        public override void LoadData()
        {
            try
            {
                SetQueryConditions();
                PagerQuery query = new PagerQuery("Vw_Location", "LocationId", "*", "LocationId", 
                    OrderClause.OrderClauseCriteria.Descending, this.PageSize, this.PageNumber, _criterions);

                int totalCount;
                DataList = ServiceHelper.WarehouseService.GetLocationViewByPagerQuery(query, out totalCount);
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

            FormHelper.SetGridColumn(MainGridView, "LocationId", "��λ���", 100, columnIndex++, false);
            FormHelper.SetGridColumn(MainGridView, "LocationCode", "��λ����", 150, columnIndex++, true);
            FormHelper.SetGridColumn(MainGridView, "LocationName", "��λ����", 150, columnIndex++, true);
            FormHelper.SetGridColumn(MainGridView, "Barcode", "��λ����", 100, columnIndex++, true);

            FormHelper.SetGridColumn(MainGridView, "WarehouseId", "�ֿ���", 100, columnIndex++, false);
            FormHelper.SetGridColumn(MainGridView, "AreaId", "�������", 150, columnIndex++, false);
            FormHelper.SetGridColumn(MainGridView, "AreaCode", "��������", 150, columnIndex++, false);
            FormHelper.SetGridColumn(MainGridView, "AreaName", "��������", 150, columnIndex++, true);
            FormHelper.SetGridColumn(MainGridView, "AreaType", "��������", 150, columnIndex++, true);

            FormHelper.SetGridColumn(MainGridView, "Length", "����(��)", 100, columnIndex++, true);
            FormHelper.SetGridColumn(MainGridView, "Width", "���(��)", 100, columnIndex++, true);
            FormHelper.SetGridColumn(MainGridView, "Height", "�߶�(��)", 100, columnIndex++, true);

            FormHelper.SetGridColumn(MainGridView, "BearingWeight", "����(ǧ��)", 100, columnIndex++, true);

            FormHelper.SetGridColumn(MainGridView, "ShelfId", "���ܱ��", 100, columnIndex++, false);
            FormHelper.SetGridColumn(MainGridView, "ShelfRow", "�����к�", 100, columnIndex++, true);
            FormHelper.SetGridColumn(MainGridView, "ShelfColumn", "�����к�", 100, columnIndex++, true);
            FormHelper.SetGridColumn(MainGridView, "ShelfDepth", "�������", 100, columnIndex++, true);

            FormHelper.SetGridColumn(MainGridView, "CoordX", "X����", 100, columnIndex++, false);
            FormHelper.SetGridColumn(MainGridView, "CoordY", "Y����", 100, columnIndex++, false);
            FormHelper.SetGridColumn(MainGridView, "CoordZ", "Z����", 100, columnIndex++, false);

            FormHelper.SetGridColumn(MainGridView, "Route", "·�����", 100, columnIndex++, true);

            FormHelper.SetGridColumn(MainGridView, "Remark", "����", 200, columnIndex++, false);
            FormHelper.SetGridColumn(MainGridView, "CreateUser", "", 100, columnIndex++, false);
            FormHelper.SetGridColumn(MainGridView, "CreateTime", "", 100, columnIndex++, false);
            FormHelper.SetGridColumn(MainGridView, "EditUser", "", 100, columnIndex++, false);
            FormHelper.SetGridColumn(MainGridView, "EditTime", "", 100, columnIndex++, false);
            FormHelper.SetGridColumn(MainGridView, "IsActive", "�Ƿ����", 100, columnIndex++, true);

            FormHelper.SetGridColumn(MainGridView, "IsValid", "", 100, 999, false);
        }

        #region �õ������б�������
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
            _criterions.Clear();

            _criterions.Add(new Criterion("WarehouseId", CriteriaOperator.Equal, GlobalState.CurrentWarehouse.WarehouseId));

            if (txtLocationCode.Text.Trim() != "")
                _criterions.Add(new Criterion("LocationCode", CriteriaOperator.Like, txtLocationCode.Text.Trim() + "%"));
            if (txtLocationName.Text.Trim() != "")
                _criterions.Add(new Criterion("LocationName", CriteriaOperator.Like, txtLocationName.Text.Trim() + "%"));

            if (leAreaType.EditValue != null)
            {
                _criterions.Add(new Criterion("AreaType", CriteriaOperator.Like, (int)leAreaType.EditValue));
            }
            if (beAreaId.Tag != null)
            {
                Area area = beAreaId.Tag as Area;
                if (area != null)
                    _criterions.Add(new Criterion("AreaId", CriteriaOperator.Equal, area.AreaId));
            }
        }

        public override void DeleteData()
        {
            Location location = CurrentData as Location;
            if (location == null) return;

            bool deleteResult = false;
            try
            {
                deleteResult = ServiceHelper.WarehouseService.DeleteLocation(location.LocationId);
            }
            catch (FaultException<ServiceError> sex)
            {
                if (sex.Detail != null)
                    FormHelper.ShowWarningDialog(sex.Detail.ErrorMessage);
            }

            if (!deleteResult)
                FormHelper.ShowInformationDialog("ɾ����λʧ�ܡ�");
        }

        private void beAreaId_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            DevExpress.XtraEditors.ButtonEdit edit = (DevExpress.XtraEditors.ButtonEdit)sender;
            if (e.Button.Kind == ButtonPredefines.Delete)
            {
                edit.EditValue = null;
                return;
            }

            Form parentForm = new DevExpress.XtraEditors.XtraForm();
            parentForm.AutoSize = true;
            parentForm.StartPosition = FormStartPosition.CenterScreen;
            parentForm.ControlBox = false;
            parentForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            AreaListForm form = new AreaListForm(FormMode.Select, false);
            form.Size = new System.Drawing.Size(810, 600);
            form.Parent = parentForm;
            form.ReferenceForm = parentForm;
            parentForm.ShowDialog();
            IList areas = form.GetSelectedData<Area>();
            if (areas != null && areas.Count > 0)
            {
                Area area = areas[0] as Area;
                beAreaId.Tag = area;
                beAreaId.Text = area.AreaName;
            }
        }
    }
}

