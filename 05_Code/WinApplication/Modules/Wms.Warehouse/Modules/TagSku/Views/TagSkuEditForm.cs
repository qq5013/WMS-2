using System.Windows.Forms;
using System.Collections;
using System.Collections.Generic;
using Business.Common.Exception;
using Business.Domain.Wms;
using Business.Common.DataDictionary;
using Business.Domain.Application;
using Framework.Core.Exception;
using Framework.UI.Template.Common;
using Modules.SkuModule.Views;
using Modules.TagModule.Views;
using Wms.Common;
using Business.Common.QueryModel;
using System.ServiceModel;
using Modules.DistrictModule.Views;
using Business.Domain.Warehouse;

namespace Modules.TagSkuModule.Views
{
    public partial class TagSkuEditForm : Framework.UI.Template.Single.SingleEditForm
    {
        private string _currentTagSkuTypes;

        public TagSkuEditForm()
        {
            InitializeComponent();
        }

        public override void InitForm()
        {

            InitComboBox();

            if (CurrentData != null)
            {
                SkuTag skutag = CurrentData as SkuTag;
                if (skutag != null)
                    BackupData = skutag.Clone() as SkuTag;
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
                int newId = ServiceHelper.WarehouseService.CreateSkuTag((SkuTag)CurrentData);
                //if (_currentTagSkuTypes != string.Empty)
                //    ServiceHelper.BasicDataService.UpdateCompanyType(((Company)CurrentData).CompanyId, _currentTagSkuTypes);
                //CurrentData = ServiceHelper.BasicDataService.GetCompany(newId);
                CurrentData = ServiceHelper.WarehouseService.GetSkuTagView(newId);
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
                bool updateResult = ServiceHelper.WarehouseService.UpdateSkuTag((SkuTag)CurrentData);

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
            SkuTag skutag = null;
            switch (CurrentDataState)
            {
                case DataState.Create:
                    {
                        skutag = new SkuTag();
                        skutag.WarehouseId = GlobalState.CurrentWarehouse.WarehouseId;
                        skutag.SkuId = ((Sku)beSkuId.Tag).SkuId;
                        skutag.TagId = ((Tag)beTagId.Tag).TagId;
                        CurrentData = skutag;
                    }
                    break;
                case DataState.Update:
                    {
                        skutag = BackupData as SkuTag;
                        skutag.SkuId = ((Sku)beSkuId.Tag).SkuId;
                        skutag.TagId = ((Tag)beTagId.Tag).TagId;
                        CurrentData = skutag;
                    }
                    break;
                case DataState.Copy:
                    {
                        skutag = BackupData as SkuTag;
                        skutag.WarehouseId = GlobalState.CurrentWarehouse.WarehouseId;
                        skutag.SkuId = ((Sku)beSkuId.Tag).SkuId;
                        skutag.TagId = ((Tag)beTagId.Tag).TagId;
                        CurrentData = skutag;
                    }
                    break;
            }
        }

        public override void SetFormData()
        {
            SkuTag skutag = CurrentData as SkuTag;
            if (skutag != null)
            {
                if (skutag.Id > 0)
                {
                    Tag parentTag = ServiceHelper.WarehouseService.GetTag(skutag.TagId);
                    if (parentTag != null)
                    {
                        beTagId.Text = parentTag.TagNumber;
                        beTagId.Tag = parentTag;
                    }

                    SkuView parentSkuView = ServiceHelper.SkuService.GetSkuView(skutag.SkuId);
                    if (parentSkuView != null)
                    {
                        beSkuId.Text = parentSkuView.SkuName;
                        beSkuId.Tag = parentSkuView;
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

            if (beSkuId.Tag == null)
            {
                string tip = "请选择货物。";
                Validator.SetError(beSkuId, tip);
                result = false;
            }

            return result;
        }

        public override void ClearFormData()
        {
            _currentTagSkuTypes = string.Empty;
            beSkuId.Tag = null;
            beSkuId.Text = string.Empty;

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

        private void beSkuId_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
           
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

