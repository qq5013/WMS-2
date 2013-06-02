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

namespace Modules.AreaModule.Views
{
    public partial class AreaEditForm : Framework.UI.Template.Single.SingleEditForm
    {
        public AreaEditForm()
        {
            InitializeComponent();
        }

        public override void InitForm()
        {
            InitComboBox();

            if (CurrentData != null)
            {
                Area area = CurrentData as Area;
                if (area != null)
                    BackupData = area.Clone() as Area;
            }
        }


        private void InitComboBox()
        {
            IEnumerable<DataDictionary> areaTypes = CacheHelper.GetDictionaryByCategory(DictionaryEnum.AREA_TYPE.ToString());
            leAreaType.Properties.DataSource = areaTypes;
            leAreaType.Properties.DisplayMember = "DictionaryValue";
            leAreaType.Properties.ValueMember = "DictionaryId";
            leAreaType.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DictionaryCode", "代码"));
            leAreaType.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DictionaryValue", "值"));
        }

        public override bool CreateData()
        {
            try
            {
                int newId = ServiceHelper.WarehouseService.CreateArea((Area)CurrentData);
                CurrentData = ServiceHelper.WarehouseService.GetArea(newId);
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
                bool updateResult = ServiceHelper.WarehouseService.UpdateArea((Area)CurrentData);

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
            Area area = null;
            switch (CurrentDataState)
            {
                case DataState.Create:
                    {
                        area = new Area();
                        area.CreateUser = GlobalState.CurrentUser.UserId;
                        area.WarehouseId = GlobalState.CurrentWarehouse.WarehouseId;
                        CurrentData = area;
                    }
                    break;
                case DataState.Update:
                    {
                        area = BackupData as Area;
                        area.EditUser = GlobalState.CurrentUser.UserId;
                        CurrentData = area;
                    }
                    break;
                case DataState.Copy:
                    {
                        area = BackupData as Area;
                        area.CreateUser = GlobalState.CurrentUser.UserId;
                        area.WarehouseId = GlobalState.CurrentWarehouse.WarehouseId;
                        CurrentData = area;
                    }
                    break;
            }

            if (area != null)
            {
                area.AreaCode = txtAreaCode.Text.Trim();
                area.AreaName = txtAreaName.Text.Trim();
                if (leAreaType.EditValue != null)
                    area.AreaType = (int)leAreaType.EditValue;
                

                area.Remark = txtRemark.Text.Trim();
                area.IsActive = cbIsActive.SelectedIndex == 0;

                area.Length = seLength.Value;
                area.Width = seWidth.Value;
                area.Height = seHeight.Value;

                area.CoordX = seCoordX.Value;
                area.CoordY = seCoordY.Value;
                area.CoordZ = seCoordZ.Value;
            }
        }

        public override void SetFormData()
        {
            Area area = CurrentData as Area;
            if (area != null)
            {
                txtAreaCode.Text = area.AreaCode;
                txtAreaName.Text = area.AreaName;
                leAreaType.EditValue = area.AreaType;

                seLength.Value = area.Length;
                seWidth.Value = area.Width;
                seHeight.Value = area.Height;
                if (area.CoordX.HasValue)
                    seCoordX.Value = area.CoordX.Value;
                if (area.CoordY.HasValue)
                    seCoordY.Value = area.CoordY.Value;
                if (area.CoordZ.HasValue)
                    seCoordZ.Value = area.CoordZ.Value;

                txtRemark.Text = area.Remark;
                if (area.IsActive)
                    cbIsActive.SelectedIndex = 0;
                else
                    cbIsActive.SelectedIndex = 1;
                txtCreateUser.Text = ServiceHelper.ApplicationService.GetUserName(area.CreateUser);
                txtCreateTime.Text = area.CreateTime;
                txtEditUser.Text = ServiceHelper.ApplicationService.GetUserName(area.EditUser);
                txtEditTime.Text = area.EditTime;
            }
        }

        public override bool ValidateData()
        {
            Validator.Clear();

            bool result = true;

            if (txtAreaCode.Text.Trim() == string.Empty)
            {
                string tip = "请填写库区代码。";
                Validator.SetError(txtAreaCode, tip);
                result = false;
            }
            
            if (txtAreaName.Text.Trim() == string.Empty)
            {
                string tip = "请填写库区名称。";
                Validator.SetError(txtAreaName, tip);
                result = false;
            }

            if (leAreaType.EditValue == null)
            {
                string tip = "请填写库区类型。";
                Validator.SetError(leAreaType, tip);
                result = false;
            }

            if (cbIsActive.SelectedIndex == -1)
            {
                string tip = "请选择是否可用。";
                Validator.SetError(cbIsActive, tip);
                result = false;
            }

            return result;
        }

        public override void ClearFormData()
        {
            txtAreaCode.Text = string.Empty;
            txtAreaName.Text = string.Empty;
            leAreaType.EditValue = null;
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

    }
}

