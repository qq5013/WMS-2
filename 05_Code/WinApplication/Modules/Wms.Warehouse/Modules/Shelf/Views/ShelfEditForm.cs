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
using DevExpress.XtraEditors.Controls;

namespace Modules.ShelfModule.Views
{
    public partial class ShelfEditForm : Framework.UI.Template.Single.SingleEditForm
    {
        public ShelfEditForm()
        {
            InitializeComponent();
        }

        public override void InitForm()
        {

            InitComboBox();

            if (CurrentData != null)
            {
                Shelf shelf = CurrentData as Shelf;
                if (shelf != null)
                    BackupData = shelf.Clone() as Shelf;
            }
        }


        private void InitComboBox()
        {
            Query query = new Query();
            query.Criteria.Add(new Criterion("Category", CriteriaOperator.Equal, DictionaryEnum.SHELF_TYPE.ToString()));
            query.Criteria.Add(new Criterion("DictionaryLevel", CriteriaOperator.Equal, 2));
            List<DataDictionary> shelfTypes = ServiceHelper.ApplicationService.GetDataDictionaryByQuery(query);
            leShelfType.Properties.DataSource = shelfTypes;
            leShelfType.Properties.DisplayMember = "DictionaryValue";
            leShelfType.Properties.ValueMember = "DictionaryId";
            leShelfType.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DictionaryCode", "代码"));
            leShelfType.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DictionaryValue", "值"));
        }

        public override bool CreateData()
        {
            try
            {
                int newId = ServiceHelper.WarehouseService.CreateShelf((Shelf)CurrentData);
                CurrentData = ServiceHelper.WarehouseService.GetShelf(newId);
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
                bool updateResult = ServiceHelper.WarehouseService.UpdateShelf((Shelf)CurrentData);

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
            Shelf shelf = null;
            switch (CurrentDataState)
            {
                case DataState.Create:
                    {
                        shelf = new Shelf();
                        shelf.CreateUser = GlobalState.CurrentUser.UserId;
                        shelf.WarehouseId = GlobalState.CurrentWarehouse.WarehouseId;
                        CurrentData = shelf;
                    }
                    break;
                case DataState.Update:
                    {
                        shelf = BackupData as Shelf;
                        shelf.EditUser = GlobalState.CurrentUser.UserId;
                        CurrentData = shelf;
                    }
                    break;
                case DataState.Copy:
                    {
                        shelf = BackupData as Shelf;
                        shelf.CreateUser = GlobalState.CurrentUser.UserId;
                        shelf.WarehouseId = GlobalState.CurrentWarehouse.WarehouseId;
                        CurrentData = shelf;
                    }
                    break;
            }

            if (shelf != null)
            {
                shelf.ShelfCode = txtShelfCode.Text.Trim();
                shelf.ShelfName = txtShelfName.Text.Trim();
                if (leShelfType.EditValue != null)
                    shelf.ShelfType = (int)leShelfType.EditValue;
                

                shelf.Remark = txtRemark.Text.Trim();
                shelf.IsActive = cbIsActive.SelectedIndex == 0;

                shelf.Length = seLength.Value;
                shelf.Width = seWidth.Value;
                shelf.Height = seHeight.Value;

                shelf.CoordX = seCoordX.Value;
                shelf.CoordY = seCoordY.Value;
                shelf.CoordZ = seCoordZ.Value;

                shelf.Row = (int)seRow.Value;
                shelf.Column = (int)seColumn.Value;
                shelf.Depth = (int)seDepth.Value;
                shelf.DirectionAngle = (int)seDirectionAngle.Value;

                if (beAreaId.Tag != null)
                {
                    Area area = beAreaId.Tag as Area;
                    if (area != null)
                        shelf.AreaId = area.AreaId;
                }

                if (beAisleId.Tag != null)
                {
                    Aisle aisle = beAisleId.Tag as Aisle;
                    if (aisle != null)
                        shelf.AisleId = aisle.AisleId;
                }
            }
        }

        public override void SetFormData()
        {
            Shelf shelf = CurrentData as Shelf;
            if (shelf != null)
            {
                txtShelfCode.Text = shelf.ShelfCode;
                txtShelfName.Text = shelf.ShelfName;
                leShelfType.EditValue = shelf.ShelfType;

                seLength.Value = shelf.Length;
                seWidth.Value = shelf.Width;
                seHeight.Value = shelf.Height;
                if (shelf.CoordX.HasValue)
                    seCoordX.Value = shelf.CoordX.Value;
                if (shelf.CoordY.HasValue)
                    seCoordY.Value = shelf.CoordY.Value;
                if (shelf.CoordZ.HasValue)
                    seCoordZ.Value = shelf.CoordZ.Value;

                seRow.Value = shelf.Row;
                seColumn.Value = shelf.Column;
                seDepth.Value = shelf.Depth;
                seDirectionAngle.Value = shelf.DirectionAngle;

                if (shelf.AreaId > 0)
                {
                    Area area = ServiceHelper.WarehouseService.GetArea(shelf.AreaId);
                    if (area != null)
                    {
                        beAreaId.Text = area.AreaName;
                        beAreaId.Tag = area;
                    }
                }

                if (shelf.AisleId > 0)
                {
                    Aisle aisle = ServiceHelper.WarehouseService.GetAisle(shelf.AisleId);
                    if (aisle != null)
                    {
                        beAisleId.Text = aisle.AisleName;
                        beAisleId.Tag = aisle;
                    }
                }


                txtRemark.Text = shelf.Remark;
                if (shelf.IsActive)
                    cbIsActive.SelectedIndex = 0;
                else
                    cbIsActive.SelectedIndex = 1;
                txtCreateUser.Text = ServiceHelper.ApplicationService.GetUserName(shelf.CreateUser);
                txtCreateTime.Text = shelf.CreateTime;
                txtEditUser.Text = ServiceHelper.ApplicationService.GetUserName(shelf.EditUser);
                txtEditTime.Text = shelf.EditTime;
            }
        }

        public override bool ValidateData()
        {
            Validator.Clear();

            bool result = true;

            if (txtShelfCode.Text.Trim() == string.Empty)
            {
                string tip = "请填写货架代码。";
                Validator.SetError(txtShelfCode, tip);
                result = false;
            }
            
            if (txtShelfName.Text.Trim() == string.Empty)
            {
                string tip = "请填写货架名称。";
                Validator.SetError(txtShelfName, tip);
                result = false;
            }

            if (leShelfType.EditValue == null)
            {
                string tip = "请填写货架类型。";
                Validator.SetError(leShelfType, tip);
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
            txtShelfCode.Text = string.Empty;
            txtShelfName.Text = string.Empty;
            leShelfType.EditValue = null;
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
            seDirectionAngle.Value = 0.0m;

            beAisleId.Tag = null;
            beAisleId.Text = string.Empty;

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

        private void beAisleId_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
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
            AisleListForm form = new AisleListForm(FormMode.Select, false);
            form.Size = new System.Drawing.Size(810, 600);
            form.Parent = parentForm;
            form.ReferenceForm = parentForm;
            parentForm.ShowDialog();
            IList aisles = form.GetSelectedData<Aisle>();
            if (aisles != null && aisles.Count > 0)
            {
                Aisle aisle = aisles[0] as Aisle;
                beAisleId.Tag = aisle;
                beAisleId.Text = aisle.AisleName;
            }
        }

    }
}

