using System.Windows.Forms;
using System.Collections;
using System.Collections.Generic;
using System.ServiceModel;
using Business.Common.Exception;
using Business.Domain.Wms;
using Business.Common.DataDictionary;
using Business.Domain.Application;
using Business.Common.QueryModel;
using Business.Domain.Warehouse;
using Framework.Core.Exception;
using Framework.UI.Template.Common;
using Modules.DistrictModule.Views;
using Modules.LocationModule.Views;
using Modules.TagModule.Views;
using Wms.Common;


namespace Modules.TagLocationModule.Views
{
    public partial class TagLocationEditForm : Framework.UI.Template.Single.SingleEditForm
    {
        private string _currentTagLocationTypes;

        public TagLocationEditForm()
        {
            InitializeComponent();
        }

        public override void InitForm()
        {

            InitComboBox();

            if (CurrentData != null)
            {
                LocationTag locationtag = CurrentData as LocationTag;
                if (locationtag != null)
                    BackupData = locationtag.Clone() as LocationTag;
            }

            tcDetail.BackColor = this.BackColor;
        }


        private void InitComboBox()
        {
            //
        }

        public override bool CreateData()
        {
            try
            {
                int newId = ServiceHelper.WarehouseService.CreateLocationTag((LocationTag)CurrentData);
                CurrentData = ServiceHelper.BasicDataService.GetCompany(newId);
                DataList.Add(CurrentData);
                return true;
            }
            catch (FaultException<ServiceError> sex)
            {
                if (sex.Detail != null)
                    FormHelper.ShowWarningDialog(sex.Detail.ErrorMessage);

            }

            return false;
        }

        public override bool UpdateData()
        {
            try
            {
                bool updateResult = ServiceHelper.WarehouseService.UpdateLocationTag((LocationTag)CurrentData);
                
                return updateResult;
            }
            catch (FaultException<ServiceError> sex)
            {
                if (sex.Detail != null)
                    FormHelper.ShowWarningDialog(sex.Detail.ErrorMessage);
            }

            return false;
        }

        public override void SaveFormData()
        {
            LocationTag locationtag = null;
            switch (CurrentDataState)
            {
                case DataState.Create:
                    {
                        locationtag = new LocationTag();
                        locationtag.WarehouseId = GlobalState.CurrentWarehouse.WarehouseId;
                        locationtag.LocationId = ((Location)beLocationId.Tag).LocationId;
                        locationtag.TagId = ((Tag)beTagId.Tag).TagId;
                        CurrentData = locationtag;
                    }
                    break;
                case DataState.Update:
                    {
                        locationtag = BackupData as LocationTag;
                        locationtag.LocationId = ((Location)beLocationId.Tag).LocationId;
                        locationtag.TagId = ((Tag)beTagId.Tag).TagId;
                        CurrentData = locationtag;
                    }
                    break;
                case DataState.Copy:
                    {
                        locationtag = BackupData as LocationTag;
                        locationtag.WarehouseId = GlobalState.CurrentWarehouse.WarehouseId;
                        locationtag.LocationId = ((Location)beLocationId.Tag).LocationId;
                        locationtag.TagId = ((Tag)beTagId.Tag).TagId;
                        CurrentData = locationtag;
                    }
                    break;
            }
        }

        public override void SetFormData()
        {
            LocationTag locationtag = CurrentData as LocationTag;
            if (locationtag != null)
            {
                if (locationtag.Id > 0)
                {
                    Location parentLocation = ServiceHelper.WarehouseService.GetLocation(locationtag.LocationId);
                    if (parentLocation != null)
                    {
                        beLocationId.Text = parentLocation.LocationName;
                        beLocationId.Tag = parentLocation;
                    }

                    Tag prarentTag = ServiceHelper.WarehouseService.GetTag(locationtag.TagId);
                    if (prarentTag != null)
                    {
                        beTagId.Text = prarentTag.TagNumber;
                        beTagId.Tag = prarentTag;
                    }
                }
            }
        }

        public override bool ValidateData()
        {
            Validator.Clear();

            bool result = true;

            if (beTagId.Tag == null)
            {
                string tip = "请选择标签。";
                Validator.SetError(beTagId, tip);
                result = false;
            }

            if (beLocationId.Tag == null)
            {
                string tip = "请选择库位。";
                Validator.SetError(beLocationId, tip);
                result = false;
            }

            return result;
        }

        public override void ClearFormData()
        {
            _currentTagLocationTypes = string.Empty;
            beLocationId.Tag = null;
            beLocationId.Text = string.Empty;

            beTagId.Tag = null;
            beTagId.Text = string.Empty;
        }

        public override void SetInputStatus()
        {
            switch (CurrentDataState)
            {
                case DataState.Create:
                case DataState.Copy:
                case DataState.Update:
                    {
                        gcBase.Enabled = true;
                        break;
                    }
                default:
                    {
                        gcBase.Enabled = false;
                    }
                    break;
            }
        }

        private void beLocationId_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
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

