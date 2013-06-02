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
using Modules.ContainerTypeModule.Views;

namespace Modules.ContainerModule.Views
{
    public partial class ContainerEditForm : Framework.UI.Template.Single.SingleEditForm
    {
        public ContainerEditForm()
        {
            InitializeComponent();
        }

        public override void InitForm()
        {
            InitComboBox();

            if (CurrentData != null)
            {
                Container container = CurrentData as Container;
                if (container != null)
                    BackupData = container.Clone() as Container;
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
                int newId = ServiceHelper.WarehouseService.CreateContainer((Container)CurrentData);
                CurrentData = ServiceHelper.WarehouseService.GetContainer(newId);
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
                bool updateResult = ServiceHelper.WarehouseService.UpdateContainer((Container)CurrentData);

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
            Container container = null;
            switch (CurrentDataState)
            {
                case DataState.Create:
                    {
                        container = new Container();
                        container.CreateUser = GlobalState.CurrentUser.UserId;
                        container.WarehouseId = GlobalState.CurrentWarehouse.WarehouseId;
                        CurrentData = container;
                    }
                    break;
                case DataState.Update:
                    {
                        container = BackupData as Container;
                        container.EditUser = GlobalState.CurrentUser.UserId;
                        CurrentData = container;
                    }
                    break;
                case DataState.Copy:
                    {
                        container = BackupData as Container;
                        container.CreateUser = GlobalState.CurrentUser.UserId;
                        container.WarehouseId = GlobalState.CurrentWarehouse.WarehouseId;
                        CurrentData = container;
                    }
                    break;
            }

            if (container != null)
            {
                container.ContainerCode = txtContainerCode.Text.Trim();
                container.ContainerName = txtContainerName.Text.Trim();
                container.Barcode = txtBarcode.Text.Trim();
                container.Remark = txtRemark.Text.Trim();
                container.IsActive = cbIsActive.SelectedIndex == 0;

                if (beContainerType.Tag != null)
                {
                    ContainerType type = beContainerType.Tag as ContainerType;
                    if (type != null)
                        container.ContainerType = type.TypeId;
                }
            }
        }

        public override void SetFormData()
        {
            Container container = CurrentData as Container;
            if (container != null)
            {
                txtContainerCode.Text = container.ContainerCode;
                txtContainerName.Text = container.ContainerName;
                txtBarcode.Text = container.Barcode;

                txtRemark.Text = container.Remark;
                if (container.IsActive)
                    cbIsActive.SelectedIndex = 0;
                else
                    cbIsActive.SelectedIndex = 1;
                txtCreateUser.Text = ServiceHelper.ApplicationService.GetUserName(container.CreateUser);
                txtCreateTime.Text = container.CreateTime;
                txtEditUser.Text = ServiceHelper.ApplicationService.GetUserName(container.EditUser);
                txtEditTime.Text = container.EditTime;

                if (container.ContainerType > 0)
                {
                    ContainerType containerType = ServiceHelper.WarehouseService.GetContainerType(container.ContainerType);
                    if (containerType != null)
                    {
                        beContainerType.Text = containerType.TypeName;
                        beContainerType.Tag = containerType;
                    }
                }

            }
        }

        public override bool ValidateData()
        {
            Validator.Clear();

            bool result = true;

            if (txtContainerCode.Text.Trim() == string.Empty)
            {
                string tip = "ÇëÌîÐ´ÈÝÆ÷´úÂë¡£";
                Validator.SetError(txtContainerCode, tip);
                result = false;
            }
            
            if (txtContainerName.Text.Trim() == string.Empty)
            {
                string tip = "ÇëÌîÐ´ÈÝÆ÷Ãû³Æ¡£";
                Validator.SetError(txtContainerName, tip);
                result = false;
            }

            if (beContainerType.Text.Trim() == string.Empty)
            {
                string tip = "ÇëÌîÐ´ÈÝÆ÷ÀàÐÍ¡£";
                Validator.SetError(beContainerType, tip);
                result = false;
            }

            if (txtBarcode.Text.Trim() == string.Empty)
            {
                string tip = "ÇëÌîÐ´ÈÝÆ÷ÌõÂë¡£";
                Validator.SetError(txtBarcode, tip);
                result = false;
            }

            if (cbIsActive.SelectedIndex == -1)
            {
                string tip = "ÇëÑ¡ÔñÊÇ·ñ¿ÉÓÃ¡£";
                Validator.SetError(cbIsActive, tip);
                result = false;
            }

            return result;
        }

        public override void ClearFormData()
        {
            beContainerType.Tag = null;
            beContainerType.Text = string.Empty;
            txtContainerCode.Text = string.Empty;
            txtContainerName.Text = string.Empty;
            txtBarcode.Text = string.Empty;
            txtRemark.Text  = string.Empty;
            cbIsActive.SelectedIndex = 0;

            txtCreateUser.Text = string.Empty;
            txtCreateTime.Text = string.Empty;
            txtEditUser.Text = string.Empty;
            txtEditTime.Text = string.Empty;
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
            }
        }

        private void beContainerType_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            Form parentForm = new DevExpress.XtraEditors.XtraForm();
            parentForm.AutoSize = true;
            parentForm.StartPosition = FormStartPosition.CenterScreen;
            parentForm.ControlBox = false;
            parentForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            ContainerTypeListForm form = new ContainerTypeListForm(FormMode.Select, false);
            form.Size = new System.Drawing.Size(810, 600);
            form.Parent = parentForm;
            form.ReferenceForm = parentForm;
            parentForm.ShowDialog();
            IList types = form.GetSelectedData<ContainerType>();
            if (types != null && types.Count > 0)
            {
                ContainerType type = types[0] as ContainerType;
                beContainerType.Tag = type;
                beContainerType.Text = type.TypeName;
            }
        }

    }
}

