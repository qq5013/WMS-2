using System.Windows.Forms;
using System.Collections;
using System.Collections.Generic;
using Business.Common.Exception;
using Business.Domain.Wms;
using Business.Common.DataDictionary;
using Business.Domain.Application;
using Framework.Core.Exception;
using Framework.UI.Template.Common;
using Wms.Common;
using Business.Common.QueryModel;
using System.ServiceModel;
using Modules.DistrictModule.Views;
using Modules.UserModule.Views;

namespace Modules.WarehouseModule.Views
{
    public partial class WarehouseEditForm : Framework.UI.Template.Single.SingleEditForm
    {
        private List<User> _warehouseUsers;

        public WarehouseEditForm()
        {
            InitializeComponent();
        }

        public override void InitForm()
        {

            InitComboBox();
            tabWarehouseUser.PageVisible = false;

            if (CurrentData != null)
            {
                Warehouse warehouse = CurrentData as Warehouse;
                if (warehouse != null)
                    BackupData = warehouse.Clone() as Warehouse;

                try
                {
                    if (CurrentDataState == DataState.Create || CurrentDataState == DataState.Update || CurrentDataState == DataState.Read)
                    {
                        tabWarehouseUser.PageVisible = true;
                        _warehouseUsers = ServiceHelper.WarehouseService.GetWarehouseUsers(warehouse.WarehouseId);
                        BindWarehouseUser();
                    }
                }
                catch (FaultException<ServiceError> sex)
                {
                    if (sex.Detail != null)
                        FormHelper.ShowWarningDialog(sex.Detail.ErrorMessage);
                }
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
                int newId = ServiceHelper.WarehouseService.CreateWarehouse((Warehouse)CurrentData);
                CurrentData = ServiceHelper.WarehouseService.GetWarehouse(newId);
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
                bool updateResult = ServiceHelper.WarehouseService.UpdateWarehouse((Warehouse)CurrentData);

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
            Warehouse warehouse = null;
            switch (CurrentDataState)
            {
                case DataState.Create:
                    {
                        warehouse = new Warehouse();
                        warehouse.CreateUser = GlobalState.CurrentUser.UserId;
                        CurrentData = warehouse;
                    }
                    break;
                case DataState.Update:
                    {
                        warehouse = BackupData as Warehouse;
                        warehouse.EditUser = GlobalState.CurrentUser.UserId;
                        CurrentData = warehouse;
                    }
                    break;
                case DataState.Copy:
                    {
                        warehouse = BackupData as Warehouse;
                        warehouse.CreateUser = GlobalState.CurrentUser.UserId;
                        CurrentData = warehouse;
                    }
                    break;
            }

            if (warehouse != null)
            {
                warehouse.WarehouseCode = txtWarehouseCode.Text.Trim();
                warehouse.WarehouseName = txtWarehouseName.Text.Trim();
                warehouse.Acreage = seAcreage.Value;
                warehouse.Isbonded = cbIsBonded.SelectedIndex == 0;

                warehouse.Remark = txtRemark.Text.Trim();
                warehouse.IsActive = cbIsActive.SelectedIndex == 0;


                if (beCountryId.Tag != null)
                {
                    District district = beCountryId.Tag as District;
                    if (district != null)
                        warehouse.CountyId = district.DistrictId;
                }

                warehouse.PostalCode = txtPostalCode.Text.Trim();
                warehouse.Address = txtAddress.Text.Trim();
                warehouse.Phone = txtPhone.Text.Trim();
                warehouse.Contactor = txtContactor.Text.Trim();
                warehouse.FaxNumber = txtFaxNumber.Text.Trim();
            }
        }

        public override void SetFormData()
        {
            Warehouse warehouse = CurrentData as Warehouse;
            if (warehouse != null)
            {
                txtWarehouseCode.Text = warehouse.WarehouseCode;
                txtWarehouseName.Text = warehouse.WarehouseName;
                if (warehouse.Acreage.HasValue)
                    seAcreage.Value = warehouse.Acreage.Value;
                if (warehouse.Isbonded)
                    cbIsBonded.SelectedIndex = 0;
                else
                    cbIsBonded.SelectedIndex = 1;

                if (warehouse.CountyId > 0)
                {
                    District district = ServiceHelper.BasicDataService.GetDistrict(warehouse.CountyId);
                    if (district != null)
                    {
                        beCountryId.Text = district.DistrictName;
                        beCountryId.Tag = district;
                    }
                }

                txtRemark.Text = warehouse.Remark;
                if (warehouse.IsActive)
                    cbIsActive.SelectedIndex = 0;
                else
                    cbIsActive.SelectedIndex = 1;
                txtCreateUser.Text = ServiceHelper.ApplicationService.GetUserName(warehouse.CreateUser);
                txtCreateTime.Text = warehouse.CreateTime;
                txtEditUser.Text = ServiceHelper.ApplicationService.GetUserName(warehouse.EditUser);
                txtEditTime.Text = warehouse.EditTime;

                txtPostalCode.Text = warehouse.PostalCode;
                txtAddress.Text = warehouse.Address;
                txtPhone.Text = warehouse.Phone;
                txtContactor.Text = warehouse.Contactor;
                txtFaxNumber.Text = warehouse.FaxNumber;
            }
        }

        public override bool ValidateData()
        {
            Validator.Clear();

            bool result = true;

            if (txtWarehouseCode.Text.Trim() == string.Empty)
            {
                string tip = "«ÎÃÓ–¥≤÷ø‚¥˙¬Î°£";
                Validator.SetError(txtWarehouseCode, tip);
                result = false;
            }
            
            if (txtWarehouseName.Text.Trim() == string.Empty)
            {
                string tip = "«ÎÃÓ–¥≤÷ø‚√˚≥∆°£";
                Validator.SetError(txtWarehouseName, tip);
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
            txtWarehouseCode.Text = string.Empty;
            txtWarehouseName.Text = string.Empty;
            seAcreage.Value = 0.0m;
            cbIsBonded.SelectedIndex = 1;
            txtRemark.Text  = string.Empty;
            cbIsActive.SelectedIndex = 0;

            beCountryId.Tag = null;
            beCountryId.Text = string.Empty;

            txtPostalCode.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtContactor.Text = string.Empty;
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

        private void beCountryId_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            Form parentForm = new DevExpress.XtraEditors.XtraForm();
            parentForm.AutoSize = true;
            parentForm.StartPosition = FormStartPosition.CenterScreen;
            parentForm.ControlBox = false;
            parentForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            DistrictForm form = new DistrictForm(FormMode.Select, false);
            form.Size = new System.Drawing.Size(810, 600);
            form.Parent = parentForm;
            form.ReferenceForm = parentForm;
            parentForm.ShowDialog();
            object obj = form.GetSelectedData();
            District district = obj as District;
            if (district != null)
            {
                beCountryId.Tag = district;
                beCountryId.Text = district.DistrictName;
            }
        }

        private void btnInsertUser_Click(object sender, System.EventArgs e)
        {
            Form parentForm = new DevExpress.XtraEditors.XtraForm();
            parentForm.AutoSize = true;
            parentForm.StartPosition = FormStartPosition.CenterScreen;
            parentForm.ControlBox = false;
            parentForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            UserListForm form = new UserListForm(FormMode.Select, true);
            form.Size = new System.Drawing.Size(810, 600);
            form.Parent = parentForm;
            form.ReferenceForm = parentForm;
            parentForm.ShowDialog();
            IList userList = form.GetSelectedData<User>();
            List<User> tempList = new List<User>();
            foreach (User user in userList)
            {
                bool has = false;
                foreach (var wUser in _warehouseUsers)
                {
                    if (user.UserId == wUser.UserId)
                        has = true;
                }

                if (!has)
                    tempList.Add(user);
            }

            // save 
            foreach (User user in tempList)
            {
                try
                {
                    bool saveResult = ServiceHelper.WarehouseService.AddWarehouseUser(((Warehouse)CurrentData).WarehouseId, user.UserId);
                    if (saveResult)
                    {
                        _warehouseUsers.Add(user);
                    }
                }
                catch (FaultException<ServiceError> sex)
                {
                    if (sex.Detail != null)
                        FormHelper.ShowWarningDialog(sex.Detail.ErrorMessage);
                }
            }

            BindWarehouseUser();
        }

        private void BindWarehouseUser()
        {
            lbUsers.DataSource = null;
            lbUsers.DisplayMember = "UserName";
            lbUsers.ValueMember = "UserId";
            lbUsers.DataSource = _warehouseUsers;
        }

        private void btnRemoveUser_Click(object sender, System.EventArgs e)
        {
            try
            {
                var item = lbUsers.SelectedItem;

                bool saveResult = ServiceHelper.WarehouseService.RemoveWarehouseUser(((Warehouse)CurrentData).WarehouseId, ((User)item).UserId);
                if (saveResult)
                {
                    _warehouseUsers.Remove((User)item);
                    lbUsers.Refresh();
                }
            }
            catch (FaultException<ServiceError> sex)
            {
                if (sex.Detail != null)
                    FormHelper.ShowWarningDialog(sex.Detail.ErrorMessage);
            }
        }
        
    }
}

