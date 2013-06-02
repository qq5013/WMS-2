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

namespace Modules.CompanyModule.Views
{
    public partial class CompanyEditForm : Framework.UI.Template.Single.SingleEditForm
    {
        private string _currentCompanyTypes;

        public CompanyEditForm()
        {
            InitializeComponent();
        }

        public override void InitForm()
        {

            InitComboBox();

            if (CurrentData != null)
            {
                Company company = CurrentData as Company;
                if (company != null)
                    BackupData = company.Clone() as Company;
            }

            tcDetail.BackColor = this.BackColor;
        }


        private void InitComboBox()
        {
            // currency type
            Query query = new Query();
            query.Criteria.Add(new Criterion("Category", CriteriaOperator.Equal, DictionaryEnum.CURRENCY_TYPE.ToString()));
            query.Criteria.Add(new Criterion("DictionaryLevel", CriteriaOperator.Equal, 2));
            List<DataDictionary> currencyTypes = ServiceHelper.ApplicationService.GetDataDictionaryByQuery(query);
            leCurrencyType.Properties.DataSource = currencyTypes;
            leCurrencyType.Properties.DisplayMember = "DictionaryValue";
            leCurrencyType.Properties.ValueMember = "DictionaryId";
            leCurrencyType.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DictionaryCode", "代码"));
            leCurrencyType.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DictionaryValue", "值"));

            query.Criteria.Clear();
            query.Criteria.Add(new Criterion("Category", CriteriaOperator.Equal, DictionaryEnum.INVOICE_TYPE.ToString()));
            query.Criteria.Add(new Criterion("DictionaryLevel", CriteriaOperator.Equal, 2));
            List<DataDictionary> invoiceTypes = ServiceHelper.ApplicationService.GetDataDictionaryByQuery(query);
            leInvoiceType.Properties.DataSource = invoiceTypes;
            leInvoiceType.Properties.DisplayMember = "DictionaryValue";
            leInvoiceType.Properties.ValueMember = "DictionaryId";
            leInvoiceType.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DictionaryCode", "代码"));
            leInvoiceType.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DictionaryValue", "值"));

            query.Criteria.Clear();
            query.Criteria.Add(new Criterion("Category", CriteriaOperator.Equal, DictionaryEnum.COMPANY_TYPE.ToString()));
            query.Criteria.Add(new Criterion("DictionaryLevel", CriteriaOperator.Equal, 2));
            List<DataDictionary> companyTypes = ServiceHelper.ApplicationService.GetDataDictionaryByQuery(query);
            ccbCompanyType.Properties.DataSource = companyTypes;
            ccbCompanyType.Properties.DisplayMember = "DictionaryValue";
            ccbCompanyType.Properties.ValueMember = "DictionaryId";
        }

        public override bool CreateData()
        {
            try
            {
                int newId = ServiceHelper.BasicDataService.CreateCompany((Company)CurrentData);
                if (_currentCompanyTypes != string.Empty)
                    ServiceHelper.BasicDataService.UpdateCompanyType(((Company)CurrentData).CompanyId, _currentCompanyTypes);
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
                bool updateResult = ServiceHelper.BasicDataService.UpdateCompany((Company)CurrentData);
                if (_currentCompanyTypes != string.Empty)
                    ServiceHelper.BasicDataService.UpdateCompanyType(((Company)CurrentData).CompanyId, _currentCompanyTypes);

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
            Company company = null;
            switch (CurrentDataState)
            {
                case DataState.Create:
                    {
                        company = new Company();
                        company.CreateUser = GlobalState.CurrentUser.UserId;
                        CurrentData = company;
                    }
                    break;
                case DataState.Update:
                    {
                        company = BackupData as Company;
                        company.EditUser = GlobalState.CurrentUser.UserId;
                        CurrentData = company;
                    }
                    break;
                case DataState.Copy:
                    {
                        company = BackupData as Company;
                        company.CreateUser = GlobalState.CurrentUser.UserId;
                        CurrentData = company;
                    }
                    break;
            }

            if (company != null)
            {
                company.CompanyCode = txtCompanyCode.Text.Trim();
                company.CompanyName = txtCompanyName.Text.Trim();
                company.ShortName = txtShortName.Text.Trim();
                company.ErpCode = txtErpCode.Text.Trim();
                
                _currentCompanyTypes = (string)ccbCompanyType.EditValue;

                company.Remark = txtRemark.Text.Trim();
                company.IsActive = cbIsActive.SelectedIndex == 0;

                company.OrganizationCode = txtOrganizationCode.Text.Trim();
                company.Representative = txtRepresentative.Text.Trim();
                company.Homepage = txtHomepage.Text.Trim();

                if (beCountryId.Tag != null)
                {
                    District district = beCountryId.Tag as District;
                    if (district != null)
                        company.CountyId = district.DistrictId;
                }

                if (beParentId.Tag != null)
                {
                    Company parentCompany = beParentId.Tag as Company;
                    if (parentCompany != null)
                        company.ParentId = parentCompany.CompanyId;
                }

                company.PostalCode = txtPostalCode.Text.Trim();
                company.Address = txtAddress.Text.Trim();
                company.Phone = txtPhone.Text.Trim();
                company.Contactor = txtContactor.Text.Trim();

                company.TaxRegisterationCode = txtTaxRegisterationCode.Text.Trim();
                company.TaxNumber = txtTaxNumber.Text.Trim();
                company.Bank = txtBank.Text.Trim();
                company.AccountNumber = txtAccountNumber.Text.Trim();
                company.FaxNumber = txtFaxNumber.Text.Trim();

                if (leCurrencyType.EditValue != null)
                    company.CurrencyType = (int)leCurrencyType.EditValue;
                if (leInvoiceType.EditValue != null)
                    company.InvoiceType = (int)leInvoiceType.EditValue;
            }
        }

        public override void SetFormData()
        {
            Company company = CurrentData as Company;
            if (company != null)
            {
                txtCompanyCode.Text = company.CompanyCode;
                txtCompanyName.Text = company.CompanyName;
                txtErpCode.Text = company.ErpCode;
                txtShortName.Text = company.ShortName;

                //companytype & parentId;
                List<Business.Domain.Wms.CompanyType> companyTypes = ServiceHelper.BasicDataService.GetCompanyTypes(company.CompanyId);
                string itemValues = string.Empty;
                foreach (var type in companyTypes)
                {
                    if (itemValues != string.Empty)
                        itemValues = itemValues + "," + type.CompanyTypeId.ToString();
                    else
                        itemValues = type.CompanyTypeId.ToString();
                }
                ccbCompanyType.SetEditValue(itemValues);

                if (company.CountyId > 0)
                {
                    District district = ServiceHelper.BasicDataService.GetDistrict(company.CountyId);
                    if (district != null)
                    {
                        beCountryId.Text = district.DistrictName;
                        beCountryId.Tag = district;
                    }
                }

                if (company.ParentId > 0)
                {
                    Company parentCompany = ServiceHelper.BasicDataService.GetCompany(company.ParentId);
                    if (parentCompany != null)
                    {
                        beParentId.Text = parentCompany.ShortName;
                        beParentId.Tag = parentCompany;
                    }
                }

                txtRemark.Text = company.Remark;
                if (company.IsActive)
                    cbIsActive.SelectedIndex = 0;
                else
                    cbIsActive.SelectedIndex = 1;
                txtCreateUser.Text = ServiceHelper.ApplicationService.GetUserName(company.CreateUser);
                txtCreateTime.Text = company.CreateTime;
                txtEditUser.Text = ServiceHelper.ApplicationService.GetUserName(company.EditUser);
                txtEditTime.Text = company.EditTime;

                txtOrganizationCode.Text = company.OrganizationCode;
                txtRepresentative.Text= company.Representative;
                txtHomepage.Text= company.Homepage;

                txtPostalCode.Text = company.PostalCode;
                txtAddress.Text = company.Address;
                txtPhone.Text = company.Phone;
                txtContactor.Text = company.Contactor;

                txtTaxRegisterationCode.Text = company.TaxRegisterationCode;
                txtTaxNumber.Text = company.TaxNumber;
                txtBank.Text = company.Bank;
                txtAccountNumber.Text = company.AccountNumber;
                txtFaxNumber.Text = company.FaxNumber;

                leCurrencyType.EditValue = company.CurrencyType;
                leInvoiceType.EditValue = company.InvoiceType;
            }
        }

        public override bool ValidateData()
        {
            Validator.Clear();

            bool result = true;

            if (txtCompanyCode.Text.Trim() == string.Empty)
            {
                string tip = "请填写公司代码。";
                Validator.SetError(txtCompanyCode, tip);
                result = false;
            }
            
            if (txtCompanyName.Text.Trim() == string.Empty)
            {
                string tip = "请填写公司名称。";
                Validator.SetError(txtCompanyName, tip);
                result = false;
            }

            if (txtShortName.Text.Trim() == string.Empty)
            {
                string tip = "请填写公司短名。";
                Validator.SetError(txtShortName, tip);
                result = false;
            }

            if (ccbCompanyType.EditValue == null)
            {
                string tip = "请选择公司类型。";
                Validator.SetError(ccbCompanyType, tip);
                result = false;
            }

            if (txtShortName.Text.Trim() == string.Empty)
            {
                string tip = "请填写公司短名。";
                Validator.SetError(txtShortName, tip);
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
            txtCompanyCode.Text = string.Empty;
            txtCompanyName.Text = string.Empty;
            txtErpCode.Text  = string.Empty;
            txtShortName.Text = string.Empty;
            txtRemark.Text  = string.Empty;
            cbIsActive.SelectedIndex = 0;

            //companytype & parentID;
            _currentCompanyTypes = string.Empty;
            ccbCompanyType.SetEditValue("");

            beCountryId.Tag = null;
            beCountryId.Text = string.Empty;

            beParentId.Tag = null;
            beParentId.Text = string.Empty;

            txtOrganizationCode.Text = string.Empty;
            txtRepresentative.Text = string.Empty;
            txtHomepage.Text = string.Empty;

            txtPostalCode.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtContactor.Text = string.Empty;

            txtTaxRegisterationCode.Text = string.Empty;
            txtTaxNumber.Text = string.Empty;
            txtBank.Text = string.Empty;
            txtAccountNumber.Text = string.Empty;

            leCurrencyType.EditValue = null;
            leInvoiceType.EditValue = null;

            txtCreateTime.Text = string.Empty;
            txtCreateUser.Text = string.Empty;
            txtEditTime.Text = string.Empty;
            txtEditUser.Text = string.Empty;
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

        private void beParentId_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
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
                beParentId.Tag = company;
                beParentId.Text = company.ShortName;
            }
        }
    }
}

