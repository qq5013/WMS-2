using System.Windows.Forms;
using Business.Common.Exception;
using Business.Domain.Warehouse;
using Framework.Core.Exception;
using Framework.UI.Template.Common;
using Wms.Common;
using System.ServiceModel;

namespace Modules.AisleModule.Views
{
    public partial class AisleEditForm : Framework.UI.Template.Single.SingleEditForm
    {
        public AisleEditForm()
        {
            InitializeComponent();
        }

        public override void InitForm()
        {
            if (CurrentData != null)
            {
                Aisle aisle = CurrentData as Aisle;
                if (aisle != null)
                    BackupData = aisle.Clone() as Aisle;
            }

            tcDetail.BackColor = this.BackColor;
        }

        public override bool CreateData()
        {
            try
            {
                int newId = ServiceHelper.WarehouseService.CreateAisle((Aisle)CurrentData);
                CurrentData = ServiceHelper.WarehouseService.GetAisle(newId);
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
                return ServiceHelper.WarehouseService.UpdateAisle((Aisle)CurrentData);
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
            Aisle aisle = null;
            switch (CurrentDataState)
            {
                case DataState.Create:
                    {
                        aisle = new Aisle();
                        aisle.WarehouseId = GlobalState.CurrentWarehouse.WarehouseId;
                        CurrentData = aisle;
                    }
                    break;
                case DataState.Update:
                    {
                        aisle = BackupData as Aisle;
                        CurrentData = aisle;
                        break;
                    }
                case DataState.Copy:
                    {
                        aisle = BackupData as Aisle;
                        aisle.WarehouseId = GlobalState.CurrentWarehouse.WarehouseId;
                        CurrentData = aisle;
                    }
                    break;
            }

            if (aisle != null)
            {
                aisle.AisleCode = txtAisleCode.Text.Trim();
                aisle.AisleName = txtAisleName.Text.Trim();
                aisle.Remark = txtRemark.Text.Trim();
                aisle.IsActive = cbIsActive.SelectedIndex == 0;

                aisle.Length = seLength.Value;
                aisle.Width = seWidth.Value;
                aisle.Height = seHeight.Value;

                aisle.CoordX = seCoordX.Value;
                aisle.CoordY = seCoordY.Value;
                aisle.CoordZ = seCoordZ.Value;

                aisle.DirectionAngle = (int)seDirectionAngle.Value;
            }
        }

        public override void SetFormData()
        {
            Aisle aisle = CurrentData as Aisle;
            if (aisle != null)
            {
                txtAisleCode.Text = aisle.AisleCode;
                txtAisleName.Text = aisle.AisleName;
                txtRemark.Text = aisle.Remark;
                if (aisle.IsActive)
                    cbIsActive.SelectedIndex = 0;
                else
                    cbIsActive.SelectedIndex = 1;

                seLength.Value = aisle.Length;
                seWidth.Value = aisle.Width;
                seHeight.Value = aisle.Height;
                if (aisle.CoordX.HasValue)
                    seCoordX.Value = aisle.CoordX.Value;
                if (aisle.CoordY.HasValue)
                    seCoordY.Value = aisle.CoordY.Value;
                if (aisle.CoordZ.HasValue)
                    seCoordZ.Value = aisle.CoordZ.Value;

                seDirectionAngle.Value = aisle.DirectionAngle;
            }
        }

        public override bool ValidateData()
        {
            Validator.Clear();

            bool result = true;
            if (txtAisleCode.Text.Trim() == string.Empty)
            {
                string tip = "请填写通道代码。";
                Validator.SetError(txtAisleCode, tip);
                result = false;
            }

            if (txtAisleName.Text.Trim() == string.Empty)
            {
                string tip = "请填写通道名称。";
                Validator.SetError(txtAisleName, tip);
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
            txtAisleCode.Text  = string.Empty;
            txtAisleName.Text  = string.Empty;
            txtRemark.Text  = string.Empty;
            cbIsActive.SelectedIndex = 0;

            seCoordX.Value = 0.0m;
            seCoordY.Value = 0.0m;
            seCoordZ.Value = 0.0m;
            seLength.Value = 0.0m;
            seWidth.Value = 0.0m;
            seHeight.Value = 0.0m;
            seDirectionAngle.Value = 0.0m;
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

