using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Business.Common.Exception;
using Business.Domain.Wms;
using Business.Common.DataDictionary;
using Business.Domain.Application;
using Framework.UI.Template.Common;
using Wms.Common;
using Business.Common.QueryModel;
using System.ServiceModel;
using Modules.CompanyModule.Views;
using Modules.CategoryManagementModule.Views;
using Framework.Core.Encryption;
using DevExpress.XtraEditors.Controls;

namespace Modules.SkuModule.Views
{
    public partial class  SkuEditForm : Framework.UI.Template.Single.SingleEditForm
    {
        private Pack _piecePack;

        private SkuManagement _skuManagement;

        public SkuEditForm()
        {
            InitializeComponent();
        }

        public override void InitForm()
        {
            InitComboBox();

            if (CurrentData != null)
            {
                Sku sku = CurrentData as Sku;
                if (sku != null)
                {
                    BackupData = sku.Clone() as Sku;

                    // load piece pack and sku management
                    try
                    {
                        _piecePack = ServiceHelper.SkuService.GetPiecePack(sku.SkuId);
                        _skuManagement = ServiceHelper.SkuService.GetSkuManagement(sku.SkuId);
                        if (_skuManagement != null && _skuManagement.IsActive)
                        {
                            layoutManagement.Enabled = true;
                            ceCustomManagement.Checked = true;
                        }
                        else
                        {
                            layoutManagement.Enabled = false;
                            ceCustomManagement.Checked = false;
                        }
                    }
                    catch (FaultException<ServiceError> sex)
                    {
                        if (sex.Detail != null)
                            FormHelper.ShowWarningDialog(sex.Detail.ErrorMessage);

                        FormHelper.ShowErrorDialog("货物附属信息加载失败。");
                    }

                    tabPack.PageEnabled = true;
                    tagSkuImage.PageEnabled = true;
                }
            }
            else
            {
                tabPack.PageEnabled = false;
                tagSkuImage.PageEnabled = false;
            }

            tcDetail.BackColor = this.BackColor;
            InitBatchPropertyTab();

            InitImages();
        }

        private void InitBatchPropertyTab()
        {
            InitBatchProperty();
            InitSkuProperty();
            AdjustProperty();

            BindSkuProperty();
            BindBatchProperty();
        }

        private void InitComboBox()
        {
            // abc type
            Query query = new Query();
            query.Criteria.Add(new Criterion("Category", CriteriaOperator.Equal, DictionaryEnum.ABC_TYPE.ToString()));
            query.Criteria.Add(new Criterion("DictionaryLevel", CriteriaOperator.Equal, 2));
            List<DataDictionary> abcTypes = ServiceHelper.ApplicationService.GetDataDictionaryByQuery(query);
            leAbcType.Properties.DataSource = abcTypes;
            leAbcType.Properties.DisplayMember = "DictionaryValue";
            leAbcType.Properties.ValueMember = "DictionaryId";
            leAbcType.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DictionaryCode", "代码"));
            leAbcType.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DictionaryValue", "值"));

            // storage condition
            query.Criteria.Clear();
            query.Criteria.Add(new Criterion("Category", CriteriaOperator.Equal, DictionaryEnum.STORAGE_CONDITION.ToString()));
            query.Criteria.Add(new Criterion("DictionaryLevel", CriteriaOperator.Equal, 2));
            List<DataDictionary> storageconditions = ServiceHelper.ApplicationService.GetDataDictionaryByQuery(query);
            leStorageCondition.Properties.DataSource = storageconditions;
            leStorageCondition.Properties.DisplayMember = "DictionaryValue";
            leStorageCondition.Properties.ValueMember = "DictionaryId";
            leStorageCondition.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DictionaryCode", "代码"));
            leStorageCondition.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DictionaryValue", "值"));

            // pick rule
            query.Criteria.Clear();
            query.Criteria.Add(new Criterion("Category", CriteriaOperator.Equal, DictionaryEnum.PICK_RULE.ToString()));
            query.Criteria.Add(new Criterion("DictionaryLevel", CriteriaOperator.Equal, 2));
            List<DataDictionary> pickRules = ServiceHelper.ApplicationService.GetDataDictionaryByQuery(query);
            lePickRule.Properties.DataSource = pickRules;
            lePickRule.Properties.DisplayMember = "DictionaryValue";
            lePickRule.Properties.ValueMember = "DictionaryId";
            lePickRule.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DictionaryCode", "代码"));
            lePickRule.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DictionaryValue", "值"));

            // pick group
            query.Criteria.Clear();
            query.Criteria.Add(new Criterion("Category", CriteriaOperator.Equal, DictionaryEnum.PICK_GROUP.ToString()));
            query.Criteria.Add(new Criterion("DictionaryLevel", CriteriaOperator.Equal, 2));
            List<DataDictionary> pickGroups = ServiceHelper.ApplicationService.GetDataDictionaryByQuery(query);
            lePickGroup.Properties.DataSource = pickGroups;
            lePickGroup.Properties.DisplayMember = "DictionaryValue";
            lePickGroup.Properties.ValueMember = "DictionaryId";
            lePickGroup.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DictionaryCode", "代码"));
            lePickGroup.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DictionaryValue", "值"));

            // replenish group
            query.Criteria.Clear();
            query.Criteria.Add(new Criterion("Category", CriteriaOperator.Equal, DictionaryEnum.REPLENISH_GROUP.ToString()));
            query.Criteria.Add(new Criterion("DictionaryLevel", CriteriaOperator.Equal, 2));
            List<DataDictionary> replenishGroups = ServiceHelper.ApplicationService.GetDataDictionaryByQuery(query);
            leReplenishGroup.Properties.DataSource = replenishGroups;
            leReplenishGroup.Properties.DisplayMember = "DictionaryValue";
            leReplenishGroup.Properties.ValueMember = "DictionaryId";
            leReplenishGroup.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DictionaryCode", "代码"));
            leReplenishGroup.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DictionaryValue", "值"));
        }

        public override bool CreateData()
        {
            try
            {
                int newId = ServiceHelper.SkuService.CreateSku((Sku)CurrentData);

                CurrentData = ServiceHelper.SkuService.GetSkuView(newId);
                DataList.Add(CurrentData);
                tabSkuProperty.PageEnabled = true;

                try
                {
                    _piecePack = ServiceHelper.SkuService.GetPiecePack(newId);
                    if (ceCustomManagement.Checked)
                        ServiceHelper.SkuService.MaintainSkuManagement(newId, ceCustomManagement.Checked, _skuManagement);
                }
                catch (FaultException<ServiceError> sex)
                {
                    if (sex.Detail != null)
                        FormHelper.ShowWarningDialog(sex.Detail.ErrorMessage);

                    FormHelper.ShowErrorDialog("货物附属信息加载失败。");
                }
                gcPack.Visible = true;

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
                bool updateResult = ServiceHelper.SkuService.UpdateSku((Sku)CurrentData);
                ServiceHelper.SkuService.UpdatePiecePack(_piecePack);

                ServiceHelper.SkuService.MaintainSkuManagement(((Sku)CurrentData).SkuId, ceCustomManagement.Checked, _skuManagement);
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
            Sku sku = null;
            switch (CurrentDataState)
            {
                case DataState.Create:
                    {
                        sku = new Sku();
                        sku.CreateUser = GlobalState.CurrentUser.UserId;
                        CurrentData = sku;

                        if (ceCustomManagement.Checked)
                        {
                            _skuManagement = new SkuManagement();
                            _skuManagement.CreateUser = GlobalState.CurrentUser.UserId;
                        }
                    }
                    break;
                case DataState.Update:
                    {
                        sku = BackupData as Sku;
                        sku.EditUser = GlobalState.CurrentUser.UserId;
                        CurrentData = sku;

                        if (_piecePack != null)
                        {
                            _piecePack.PackName = txtPackName.Text;
                            _piecePack.Length = seLength.Value;
                            _piecePack.Width = seWidth.Value;
                            _piecePack.Height = seHeight.Value;
                            _piecePack.Weight = seWeight.Value;
                        }

                        if (ceCustomManagement.Checked)
                        {
                            if (_skuManagement == null)
                            {
                                _skuManagement = new SkuManagement();
                                _skuManagement.CreateUser = GlobalState.CurrentUser.UserId;
                            }
                            else
                                _skuManagement.EditUser = GlobalState.CurrentUser.UserId;
                        }

                    }
                    break;
                case DataState.Copy:
                    {
                        sku = BackupData as Sku;
                        sku.CreateUser = GlobalState.CurrentUser.UserId;
                        CurrentData = sku;

                        if (ceCustomManagement.Checked)
                        {
                            _skuManagement = new SkuManagement();
                            _skuManagement.CreateUser = GlobalState.CurrentUser.UserId;
                        }
                    }
                    break;
            }

            if (sku != null)
            {
                sku.SkuNumber = txtSkuNumber.Text.Trim();
                sku.SkuName = txtSkuName.Text.Trim();
                sku.Barcode = txtBarcode.Text.Trim();
                sku.ErpCode = txtErpCode.Text.Trim();
                sku.Upc = txtUpc.Text.Trim();

                //if (beClientId.Tag != null)
                //    sku.ClientId = (beClientId.Tag as Company).CompanyId;
                if (beMerchantId.Tag != null)
                {
                    sku.MerchantId = (beMerchantId.Tag as Company).CompanyId;
                    sku.ClientId = CacheHelper.GetParentCompanyId(sku.MerchantId);
                }
                if (beManufacturer.Tag != null)
                    sku.Manufacturer = (beManufacturer.Tag as Company).CompanyId;

                if (beCategoryId.Tag != null)
                    sku.CategoryId = (beCategoryId.Tag as CategoryManagement).CategoryId;

                sku.Remark = txtRemark.Text.Trim();
                sku.IsActive = cbIsActive.SelectedIndex == 0;

                sku.Brand = txtBrand.Text.Trim();
                sku.Specification = txtSpecification.Text.Trim();
                sku.Model = txtModel.Text.Trim();

                sku.GuranteePeriodYear = (int)seGuranteePeriodYear.Value;
                sku.GuranteePeriodMonth = (int)seGuranteePeriodMonth.Value;
                sku.GuranteePeriodDay = (int)seGuranteePeriodDay.Value;

                if (_skuManagement != null)
                {
                    _skuManagement.QcPercent = (int)seQcPercent.Value;
                    if (leAbcType.EditValue != null)
                        _skuManagement.AbcType = (int)leAbcType.EditValue;
                    if (leStorageCondition.EditValue != null)
                        _skuManagement.StorageCondition = (int)leStorageCondition.EditValue;
                    if (lePickRule.EditValue != null)
                        _skuManagement.PickRule = (int)lePickRule.EditValue;
                    if (lePickGroup.EditValue != null)
                        _skuManagement.PickGroup = (int)lePickGroup.EditValue;
                    if (leReplenishGroup.EditValue != null)
                        _skuManagement.ReplenishGroup = (int)leReplenishGroup.EditValue;

                    _skuManagement.BarcodeManagement = cbBarcodeManagement.SelectedIndex == 0;
                    _skuManagement.ContainerManagement = cbContainerManagement.SelectedIndex == 0;
                    _skuManagement.BatchManagement = cbBatchManagement.SelectedIndex == 0;
                    _skuManagement.PieceManagement = cbPieceManagement.SelectedIndex == 0;
                    _skuManagement.IsBigItem = cbIsBigItem.SelectedIndex == 0;
                    _skuManagement.IsHeavyItem = cbIsHeavyItem.SelectedIndex == 0;
                    _skuManagement.ContainerManagement = cbContainerManagement.SelectedIndex == 0;
                }
            }
        }

        public override void SetFormData()
        {
            Sku sku = CurrentData as Sku;
            if (sku != null)
            {
                txtSkuNumber.Text = sku.SkuNumber;
                txtSkuName.Text = sku.SkuName;
                txtErpCode.Text = sku.ErpCode;
                txtBarcode.Text = sku.Barcode;
                txtUpc.Text = sku.Upc;

                if (sku.CategoryId > 0)
                {
                    CategoryManagement category = ServiceHelper.BasicDataService.GetCategoryManagement(sku.CategoryId);
                    if (category != null)
                    {
                        beCategoryId.Tag = category;
                        beCategoryId.Text = category.CategoryName;
                    }
                }

                //if (sku.ClientId > 0)
                //{
                //    Company company = ServiceHelper.BasicDataService.GetCompany(sku.ClientId);
                //    if (company != null)
                //    {
                //        beClientId.Tag = company;
                //        beClientId.Text = company.CompanyName;
                //    }
                //}
                if (sku.MerchantId > 0)
                {
                    Company company = ServiceHelper.BasicDataService.GetCompany(sku.MerchantId);
                    if (company != null)
                    {
                        beMerchantId.Tag = company;
                        beMerchantId.Text = company.CompanyName;
                    }
                }
                if (sku.Manufacturer > 0)
                {
                    Company company = ServiceHelper.BasicDataService.GetCompany(sku.Manufacturer);
                    if (company != null)
                    {
                        beManufacturer.Tag = company;
                        beManufacturer.Text = company.CompanyName;
                    }
                }

                if (sku.CategoryId > 0)
                {
                    Company company = ServiceHelper.BasicDataService.GetCompany(sku.CategoryId);
                    if (company != null)
                    {
                        beCategoryId.Tag = company;
                        beCategoryId.Text = company.CompanyName;
                    }
                }
               
                txtRemark.Text = sku.Remark;
                if (sku.IsActive)
                    cbIsActive.SelectedIndex = 0;
                else
                    cbIsActive.SelectedIndex = 1;
                txtCreateUser.Text = ServiceHelper.ApplicationService.GetUserName(sku.CreateUser);
                txtCreateTime.Text = sku.CreateTime;
                txtEditUser.Text = ServiceHelper.ApplicationService.GetUserName(sku.EditUser);
                txtEditTime.Text = sku.EditTime;

                txtBrand.Text = sku.Brand;
                txtSpecification.Text = sku.Specification;
                txtModel.Text = sku.Model;
                seGuranteePeriodYear.Value = sku.GuranteePeriodYear;
                seGuranteePeriodMonth.Value = sku.GuranteePeriodMonth;
                seGuranteePeriodDay.Value = sku.GuranteePeriodDay;

                if (_piecePack != null)
                {
                    txtPackName.Text = _piecePack.PackName;
                    seLength.Value = _piecePack.Length;
                    seWidth.Value = _piecePack.Width;
                    seHeight.Value = _piecePack.Height;
                    seWeight.Value = _piecePack.Weight;
                }

                if (_skuManagement != null)
                {
                    ceCustomManagement.Checked = true;

                    seQcPercent.EditValue = _skuManagement.QcPercent;
                    seQcPercent.Value = _skuManagement.QcPercent;

                    leAbcType.EditValue = _skuManagement.AbcType;
                    leStorageCondition.EditValue = _skuManagement.StorageCondition;
                    lePickRule.EditValue = _skuManagement.PickRule;
                    lePickGroup.EditValue = _skuManagement.PickGroup;
                    leReplenishGroup.EditValue = _skuManagement.ReplenishGroup;

                    if (_skuManagement.BarcodeManagement)
                        cbBarcodeManagement.SelectedIndex = 0;
                    else
                        cbBarcodeManagement.SelectedIndex = 1;
                    if (_skuManagement.BatchManagement)
                        cbBatchManagement.SelectedIndex = 0;
                    else
                        cbBatchManagement.SelectedIndex = 1;

                    if (_skuManagement.PieceManagement)
                        cbPieceManagement.SelectedIndex = 0;
                    else
                        cbPieceManagement.SelectedIndex = 1;

                    if (_skuManagement.IsBigItem)
                        cbIsBigItem.SelectedIndex = 0;
                    else
                        cbIsBigItem.SelectedIndex = 1;

                    if (_skuManagement.IsHeavyItem)
                        cbIsHeavyItem.SelectedIndex = 0;
                    else
                        cbIsHeavyItem.SelectedIndex = 1;

                    if (_skuManagement.ContainerManagement)
                        cbContainerManagement.SelectedIndex = 0;
                    else
                        cbContainerManagement.SelectedIndex = 1;
                }
            }
        }

        public override bool ValidateData()
        {
            Validator.Clear();

            bool result = true;

            if (txtSkuNumber.Text.Trim() == string.Empty)
            {
                string tip = "请填写货物代码。";
                Validator.SetError(txtSkuNumber, tip);
                result = false;
            }
            
            if (txtSkuName.Text.Trim() == string.Empty)
            {
                string tip = "请填写货物名称。";
                Validator.SetError(txtSkuName, tip);
                result = false;
            }

            if (txtBarcode.Text.Trim() == string.Empty)
            {
                string tip = "请填写库内条码。";
                Validator.SetError(txtBarcode, tip);
                result = false;
            }

            //if (beClientId.Tag == null)
            //{
            //    string tip = "请选择货物隶属客户。";
            //    Validator.SetError(beClientId, tip);
            //    result = false;
            //}

            if (beMerchantId.Tag == null)
            {
                string tip = "请选择货物隶属货主。";
                Validator.SetError(beMerchantId, tip);
                result = false;
            }

            if (beCategoryId.Tag == null)
            {
                string tip = "请选择货物所属管理分类。";
                Validator.SetError(beCategoryId, tip);
                result = false;
            }

            if (cbIsActive.SelectedIndex == -1)
            {
                string tip = "请选择是否可用。";
                Validator.SetError(cbIsActive, tip);
                result = false;
            }

            if (_piecePack != null && txtPackName.Text == string.Empty)
            {
                string tip = "请填写包装名称。";
                Validator.SetError(txtPackName, tip);
                result = false;
            }

            return result;
        }

        public override void ClearFormData()
        {
            txtSkuNumber.Text = string.Empty;
            txtSkuName.Text = string.Empty;
            txtErpCode.Text  = string.Empty;
            txtBarcode.Text = string.Empty;
            txtUpc.Text = string.Empty;
            txtRemark.Text  = string.Empty;
            cbIsActive.SelectedIndex = 0;

            beCategoryId.Tag = null;
            beCategoryId.Text = string.Empty;

            beClientId.Tag = null;
            beClientId.Text = string.Empty;
            beMerchantId.Tag = null;
            beMerchantId.Text = string.Empty;
            beManufacturer.Tag = null;
            beManufacturer.Text = string.Empty;

            txtBrand.Text = string.Empty;
            txtSpecification.Text = string.Empty;
            txtModel.Text = string.Empty;

            seGuranteePeriodDay.Value = 0;
            seGuranteePeriodMonth.Value = 0;
            seGuranteePeriodYear.Value = 0;

            txtPackName.Text = string.Empty;
            seLength.Value = 0.0m;
            seWidth.Value = 0.0m;
            seHeight.Value = 0.0m;
            seWeight.Value = 0.0m;

            // sku mangement
            seQcPercent.Value = 0;

            leAbcType.EditValue = null;
            leStorageCondition.EditValue = null;
            lePickRule.EditValue = null;
            lePickGroup.EditValue = null;
            leReplenishGroup.EditValue = null;

            cbBarcodeManagement.SelectedIndex = 0;
            cbBatchManagement.SelectedIndex = 1;
            cbContainerManagement.SelectedIndex = 1;
            cbIsBigItem.SelectedIndex = 1;
            cbIsHeavyItem.SelectedIndex = 1;
            cbPieceManagement.SelectedIndex = 1;
        }

        public override void SetInputStatus()
        {
            switch (CurrentDataState)
            {
                case DataState.Create:
                case DataState.Update:
                    {
                        gcBase.Enabled = true;
                        gcOther.Enabled = true;
                        break;
                    }
            }
        }

        private void beManufacturer_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
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
            CompanyListForm form = new CompanyListForm(FormMode.Select, false);
            form.Size = new System.Drawing.Size(810, 600);
            form.Parent = parentForm;
            form.ReferenceForm = parentForm;
            parentForm.ShowDialog();
            IList companys = form.GetSelectedData<Company>();
            if (companys != null && companys.Count > 0)
            {
                Company company = companys[0] as Company;
                beManufacturer.Tag = company;
                beManufacturer.Text = company.ShortName;
            }
        }

        private void beClientId_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            
            Form parentForm = new DevExpress.XtraEditors.XtraForm();
            parentForm.AutoSize = true;
            parentForm.StartPosition = FormStartPosition.CenterScreen;
            parentForm.ControlBox = false;
            parentForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            CompanyListForm form = new CompanyListForm(FormMode.Select, false);
            form.Size = new System.Drawing.Size(810, 600);
            form.Parent = parentForm;
            form.ReferenceForm = parentForm;
            parentForm.ShowDialog();
            IList companys = form.GetSelectedData<Company>();
            if (companys != null && companys.Count > 0)
            {
                Company company = companys[0] as Company;
                beClientId.Tag = company;
                beClientId.Text = company.ShortName;
            }
        }

        private void beMerchantId_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            Form parentForm = new DevExpress.XtraEditors.XtraForm();
            parentForm.AutoSize = true;
            parentForm.StartPosition = FormStartPosition.CenterScreen;
            parentForm.ControlBox = false;
            parentForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            CompanyListForm form = new CompanyListForm(FormMode.Select, false);
            form.Size = new System.Drawing.Size(810, 600);
            form.Parent = parentForm;
            form.ReferenceForm = parentForm;
            parentForm.ShowDialog();
            IList companys = form.GetSelectedData<Company>();
            if (companys != null && companys.Count > 0)
            {
                Company company = companys[0] as Company;
                beMerchantId.Tag = company;
                beMerchantId.Text = company.ShortName;
            }
        }

        private void beCategoryId_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            Form parentForm = new DevExpress.XtraEditors.XtraForm();
            parentForm.AutoSize = true;
            parentForm.StartPosition = FormStartPosition.CenterScreen;
            parentForm.ControlBox = false;
            parentForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            CategoryManagementForm form = new CategoryManagementForm(FormMode.Select, false);
            form.Size = new System.Drawing.Size(810, 600);
            form.Parent = parentForm;
            form.ReferenceForm = parentForm;
            parentForm.ShowDialog();
            object obj = form.GetSelectedData();
            CategoryManagement category = obj as CategoryManagement;
            if (category != null)
            {
                beCategoryId.Tag = category;
                beCategoryId.Text = category.CategoryName;
            }
        }

        private void ceCustomManagement_CheckedChanged(object sender, System.EventArgs e)
        {
            if (ceCustomManagement.Checked)
                layoutManagement.Enabled = true;
            else
                layoutManagement.Enabled = false;
        }

        #region sku properties
        private List<BatchProperty> _batchProperties = new List<BatchProperty>();
        private List<BatchProperty> _skuProperties = new List<BatchProperty>();

        private void BindSkuProperty()
        {
            if (_skuProperties.Count > 0)
            {
                lbSkuProperty.DataSource = null;
                lbSkuProperty.DataSource = _skuProperties;
                lbSkuProperty.DisplayMember = "PropertyName";
                lbSkuProperty.ValueMember = "PropertyId";
            }
        }

        private void BindBatchProperty()
        {
            if (_batchProperties.Count > 0)
            {
                lbBatchProperty.DataSource = null;
                lbBatchProperty.DataSource = _batchProperties;
                lbBatchProperty.DisplayMember = "PropertyName";
                lbBatchProperty.ValueMember = "PropertyId";
            }
        }

        private void AdjustProperty()
        {
            List<BatchProperty> newList = new List<BatchProperty>();
            foreach (var batchProperty in _batchProperties)
            {
                bool hasProperty = false;
                foreach (var categoryProperty in _skuProperties)
                {
                    if (batchProperty.PropertyId == categoryProperty.PropertyId)
                    {
                        hasProperty = true;
                        break;
                    }
                }

                if (!hasProperty)
                    newList.Add(batchProperty);
            }

            _batchProperties = newList;
        }

        private void InitSkuProperty()
        {
            if (CurrentData != null)
            {
                List<BatchProperty> list = ServiceHelper.SkuService.GetBatchPropertyBySku(((Sku)CurrentData).SkuId);
                _skuProperties = list;

                tabSkuProperty.PageEnabled = true;
                if (_skuProperties.Count > 0)
                {
                    ceCustomSkuProperty.Checked = true;
                    layoutProperty.Enabled = true;
                }
                else
                {
                    ceCustomSkuProperty.Checked = false;
                    layoutProperty.Enabled = false;
                }
            }
            else
                tabSkuProperty.PageEnabled = false;
        }

        private void InitBatchProperty()
        {
            Query query = new Query();
            query.Criteria.Add(new Criterion("PropertyId", CriteriaOperator.GreaterThan, 0));
            query.Criteria.Add(new Criterion("IsActive", CriteriaOperator.Equal, 1));
            query.OrderClauses.Add(new OrderClause("PropertyId", OrderClause.OrderClauseCriteria.Ascending));
            List<BatchProperty> list = ServiceHelper.BasicDataService.GetBatchPropertyByQuery(query);
            _batchProperties = list;
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            if (lbBatchProperty.SelectedItem != null)
            {
                BatchProperty property = lbBatchProperty.SelectedItem as BatchProperty;
                _skuProperties.Add(property);
                BindSkuProperty();

                _batchProperties.Remove(property);
                BindBatchProperty();
            }
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            if (lbSkuProperty.SelectedItem != null)
            {
                BatchProperty property = lbSkuProperty.SelectedItem as BatchProperty;
                _batchProperties.Add(property);
                BindBatchProperty();

                _skuProperties.Remove(property);
                BindSkuProperty();
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                bool saveResult;
                if (ceCustomSkuProperty.Checked)
                    saveResult = ServiceHelper.SkuService.SaveSkuBatchProperty(((Sku)CurrentData).SkuId, _skuProperties);
                else
                    saveResult = ServiceHelper.SkuService.SaveSkuBatchProperty(((Sku)CurrentData).SkuId, null);
                
                if (!saveResult)
                    FormHelper.ShowWarningDialog("保存货物批次属性失败。");
            }
            catch (FaultException<ServiceError> sex)
            {
                if (sex.Detail != null)
                    FormHelper.ShowWarningDialog(sex.Detail.ErrorMessage);
            }
        }

        private void ceCustomSkuProperty_CheckedChanged(object sender, EventArgs e)
        {
            if (ceCustomSkuProperty.Checked)
            {
                layoutProperty.Enabled = true;
            }
            else
                layoutProperty.Enabled = false;
        }
        #endregion 

        #region sku images
        private void btnPriorImage_Click(object sender, EventArgs e)
        {
            imgSlider.SlidePrev();
            _currentImageIndex = _currentImageIndex - 1;
            if (_currentImageIndex < 1)
                _currentImageIndex = 1;

            RefreshImageLabel();
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            int skuId = ((Sku)CurrentData).SkuId;
            UploadFile(skuId);
        }

        private void btnNextImage_Click(object sender, EventArgs e)
        {
            imgSlider.SlideNext();
            _currentImageIndex = _currentImageIndex + 1;
            if (_currentImageIndex > _skuImageCount)
                _currentImageIndex = _skuImageCount;

            RefreshImageLabel();
        }

        private int _skuImageCount;
        private int _currentImageIndex = 0;

        private void InitImages()
        {
            try
            {
                
                if (CurrentData == null) return;

                int skuId = ((Sku)CurrentData).SkuId;
                _skuImageCount = ServiceHelper.SkuService.GetSkuImageCount(skuId);
                if (_skuImageCount > 0)
                    _currentImageIndex = 1;
                else
                    _currentImageIndex = 0;

                RefreshImageLabel();

                for (int i = 1; i <= _skuImageCount; i++)
                {
                    GetSkuImages(skuId, i);
                }
            }
            catch (FaultException<ServiceError> sex)
            {
                if (sex.Detail != null)
                    FormHelper.ShowWarningDialog(sex.Detail.ErrorMessage);
            }
        }

        private void RefreshImageLabel()
        {
            lblImages.Text = string.Format("{0}/{1}", _currentImageIndex, _skuImageCount);
        }

        private string GetImagesPath()
        {
            int merchantId = ((Sku)CurrentData).MerchantId;
            return System.IO.Path.Combine(GlobalState.SkuImagesPath, merchantId.ToString());
        }

        private string GetImageFileName(int skuId, int index)
        {
            return string.Format("{0}-{1}.jpg", skuId, index);
        }

        private void GetSkuImages(int skuId, int index)
        {
            string path = GetImagesPath();
            string imageFile = System.IO.Path.Combine(path, GetImageFileName(skuId, index));
            bool isExits = System.IO.File.Exists(imageFile);
            if (!isExits)
            {
                try
                {
                    SkuImage skuImage = ServiceHelper.SkuService.GetSkuImage(skuId, index);
                    SaveToImageFile(path, skuImage, index);

                    LoadSkuImage(skuId, index);
                }
                catch (FaultException<ServiceError> sex)
                {
                    if (sex.Detail != null)
                        FormHelper.ShowWarningDialog(sex.Detail.ErrorMessage);
                }
            }
            else
                LoadSkuImage(skuId, index);
        }

        private void SaveToImageFile(string path, SkuImage skuImage, int index)
        {
            CreateFolder(path);
            string filePath = System.IO.Path.Combine(path, GetImageFileName(skuImage.SkuId, index));
            string dStr = CompressHelper.Decompress(skuImage.Image);
            Base64Helper.SaveToFile(dStr, filePath);
        }

        public void CreateFolder(string path)
        {
            System.IO.DirectoryInfo info = new System.IO.DirectoryInfo(path);
            if (!info.Exists)
                System.IO.Directory.CreateDirectory(path);
        }

        private void UploadFile(int skuId)
        {
            if (MessageBox.Show("您是否要为该货物上传一个图片文件？", "问题", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                OpenFileDialog fileDialog = new OpenFileDialog();
                fileDialog.Title = "选择格式文件";
                fileDialog.Filter = "Images Files (*.jpg)|*.jpg";
                fileDialog.FilterIndex = 1;
                fileDialog.RestoreDirectory = true;
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    string fileName = fileDialog.FileName;
                    System.IO.FileInfo fileInfo = new System.IO.FileInfo(fileName);
                    // 使用文件名
                    string shortFileName = fileDialog.SafeFileName;

                    string sStr = Base64Helper.EncodingFile(fileName);
                    string cStr = CompressHelper.Compress(sStr);

                    SkuImage newSKuImage = new SkuImage();
                    newSKuImage.SkuId = skuId;
                    newSKuImage.Image = cStr;


                    try
                    {
                        SkuImage createdImage = ServiceHelper.SkuService.CreateSkuImage(newSKuImage);
                        if (createdImage != null)
                        {
                            _skuImageCount = _skuImageCount + 1;
                            //_currentImageIndex = _skuImageCount;
                            if (_currentImageIndex == 0) 
                                _currentImageIndex = 1;

                            SaveToImageFile(GetImagesPath(), createdImage, createdImage.ImageIndex);
                            LoadSkuImage(skuId, createdImage.ImageIndex);
                            RefreshImageLabel();
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

        private void LoadSkuImage(int skuId, int _currentImageIndex)
        {
            string filePath = System.IO.Path.Combine(GetImagesPath(), GetImageFileName(skuId, _currentImageIndex));
            Image img = Image.FromFile(filePath);
            imgSlider.Images.Add(img);
        }
        #endregion
    }
}

