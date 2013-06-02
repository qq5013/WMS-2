using System.Windows.Forms;
using System.Collections;
using System.Collections.Generic;
using Business.Common.Exception;
using Business.Domain.Wms;
using Business.Common.DataDictionary;
using Business.Domain.Application;
using Business.Domain.Warehouse;
using Framework.Core.Exception;
using Framework.UI.Template.Common;
using Wms.Common;
using Business.Common.QueryModel;
using System.ServiceModel;
using Modules.DistrictModule.Views;
using Modules.AreaModule.Views;
using Modules.AisleModule.Views;
using Modules.WarehouseModule.Views;
using Modules.ShelfModule.Views;
using DevExpress.XtraEditors.Controls;

namespace Modules.LocationModule.Views
{
    public partial class LocationEditForm : Framework.UI.Template.Single.SingleEditForm
    {


        public LocationEditForm()
        {
            InitializeComponent();
        }

        public override void InitForm()
        {

            InitComboBox();

            if (CurrentData != null)
            {
                Location location = CurrentData as Location;
                if (location != null)
                    BackupData = location.Clone() as Location;
            }
        }


        private void InitComboBox()
        {
            //
        }

        public override bool CreateData()
        {
            try
            {
                int newId = ServiceHelper.WarehouseService.CreateLocation((Location)CurrentData);
                CurrentData = ServiceHelper.WarehouseService.GetLocationView(newId);
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
                bool updateResult = ServiceHelper.WarehouseService.UpdateLocation((Location)CurrentData);

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
            Location location = null;
            switch (CurrentDataState)
            {
                case DataState.Create:
                    {
                        location = new Location();
                        location.CreateUser = GlobalState.CurrentUser.UserId;
                        location.WarehouseId = GlobalState.CurrentWarehouse.WarehouseId;
                        CurrentData = location;
                    }
                    break;
                case DataState.Update:
                    {
                        location = BackupData as Location;
                        location.EditUser = GlobalState.CurrentUser.UserId;
                        CurrentData = location;
                    }
                    break;
                case DataState.Copy:
                    {
                        location = BackupData as Location;
                        location.CreateUser = GlobalState.CurrentUser.UserId;
                        location.WarehouseId = GlobalState.CurrentWarehouse.WarehouseId;
                        CurrentData = location;
                    }
                    break;
            }

            if (location != null)
            {

                location.LocationCode = txtLocationCode.Text.Trim();
                location.LocationName = txtLocationName.Text.Trim();

                location.Remark = txtRemark.Text.Trim();
                location.IsActive = cbIsActive.SelectedIndex == 0;

                location.Length = seLength.Value;
                location.Width = seWidth.Value;
                location.Height = seHeight.Value;

                location.CoordX = seCoordX.Value;
                location.CoordY = seCoordY.Value;
                location.CoordZ = seCoordZ.Value;

                location.ShelfRow = (int)seRow.Value;
                location.ShelfColumn = (int)seColumn.Value;
                location.ShelfDepth = (int)seDepth.Value;
                location.BearingWeight = (int)seBearingWeight.Value;

                location.Barcode = txtBarcode.Text.Trim();
                location.Route = (int)seRoute.Value;

                if (beAreaId.Tag != null)
                {
                    Area area = beAreaId.Tag as Area;
                    if (area != null)
                        location.AreaId = area.AreaId;
                }

                if (beShelfId.Tag != null)
                {
                    Shelf shelf = beShelfId.Tag as Shelf;
                    if (shelf != null)
                        location.ShelfId = shelf.ShelfId;
                }
            }
        }

        public override void SetFormData()
        {
            Location location = CurrentData as Location;
            if (location != null)
            {
                txtLocationCode.Text = location.LocationCode;
                txtLocationName.Text = location.LocationName;

                seLength.Value = location.Length;
                seWidth.Value = location.Width;
                seHeight.Value = location.Height;
                if (location.CoordX.HasValue)
                    seCoordX.Value = location.CoordX.Value;
                if (location.CoordY.HasValue)
                    seCoordY.Value = location.CoordY.Value;
                if (location.CoordZ.HasValue)
                    seCoordZ.Value = location.CoordZ.Value;

                seRow.Value = location.ShelfRow;
                seColumn.Value = location.ShelfColumn;
                seDepth.Value = location.ShelfDepth;
                seBearingWeight.Value = location.BearingWeight;
                txtBarcode.Text = location.Barcode;
                seRoute.Value = location.Route;

                if (location.AreaId > 0)
                {
                    Area area = ServiceHelper.WarehouseService.GetArea(location.AreaId);
                    if (area != null)
                    {
                        beAreaId.Text = area.AreaName;
                        beAreaId.Tag = area;
                    }
                }

                if (location.ShelfId > 0)
                {
                    Shelf shelf = ServiceHelper.WarehouseService.GetShelf(location.ShelfId);
                    if (shelf != null)
                    {
                        beShelfId.Text = shelf.ShelfName;
                        beShelfId.Tag = shelf;
                    }
                }


                txtRemark.Text = location.Remark;
                if (location.IsActive)
                    cbIsActive.SelectedIndex = 0;
                else
                    cbIsActive.SelectedIndex = 1;
                txtCreateUser.Text = ServiceHelper.ApplicationService.GetUserName(location.CreateUser);
                txtCreateTime.Text = location.CreateTime;
                txtEditUser.Text = ServiceHelper.ApplicationService.GetUserName(location.EditUser);
                txtEditTime.Text = location.EditTime;
            }
        }

        public override bool ValidateData()
        {
            Validator.Clear();

            bool result = true;

            if (txtLocationCode.Text.Trim() == string.Empty)
            {
                string tip = "«ÎÃÓ–¥ø‚Œª¥˙¬Î°£";
                Validator.SetError(txtLocationCode, tip);
                result = false;
            }
            
            if (txtLocationName.Text.Trim() == string.Empty)
            {
                string tip = "«ÎÃÓ–¥ø‚Œª√˚≥∆°£";
                Validator.SetError(txtLocationName, tip);
                result = false;
            }


            if (txtBarcode.Text.Trim() == string.Empty)
            {
                string tip = "«ÎÃÓ–¥ø‚ŒªÃı¬Î°£";
                Validator.SetError(txtBarcode, tip);
                result = false;
            }

            if (cbIsActive.SelectedIndex == -1)
            {
                string tip = "«Î—°‘Ò «∑Òø…”√°£";
                Validator.SetError(cbIsActive, tip);
                result = false;
            }

            return result;
        }

        public override void ClearFormData()
        {
            txtLocationCode.Text = string.Empty;
            txtLocationName.Text = string.Empty;
            txtRemark.Text  = string.Empty;
            cbIsActive.SelectedIndex = 0;

            txtCreateUser.Text = string.Empty;
            txtCreateTime.Text = string.Empty;
            txtEditUser.Text = string.Empty;
            txtEditTime.Text = string.Empty;

            seCoordX.Value = 0.0m;
            seCoordY.Value = 0.0m;
            seCoordZ.Value = 0.0m;
            seLength.Value = 0.0m;
            seWidth.Value = 0.0m;
            seHeight.Value = 0.0m;

            seRow.Value = 0.0m;
            seColumn.Value = 0.0m;
            seDepth.Value = 0.0m;
            seBearingWeight.Value = 0.0m;

            seRoute.Value = 0;

            beShelfId.Tag = null;
            beShelfId.Text = string.Empty;

            beAreaId.Tag = null;
            beAreaId.Text = string.Empty;
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
                        gcOther.Enabled = true;
                        break;
                    }
                default:
                    {
                        gcBase.Enabled = false;
                        gcOther.Enabled = false;
                    }
                    break;
            }
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

        private void beShelfId_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
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
            ShelfListForm form = new ShelfListForm(FormMode.Select, false);
            form.Size = new System.Drawing.Size(810, 600);
            form.Parent = parentForm;
            form.ReferenceForm = parentForm;
            parentForm.ShowDialog();
            IList shelfs = form.GetSelectedData<Shelf>();
            if (shelfs != null && shelfs.Count > 0)
            {
                Shelf shelf = shelfs[0] as Shelf;
                beShelfId.Tag = shelf;
                beShelfId.Text = shelf.ShelfName;
            }
        }

    }
}

