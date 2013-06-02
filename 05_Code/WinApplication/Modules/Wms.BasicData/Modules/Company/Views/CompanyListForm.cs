using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Business.Common.Exception;
using Business.Common.QueryModel;
using Business.Domain.Wms;
using Framework.UI.Template.Common;
using Microsoft.Practices.CompositeUI.SmartParts;
using Wms.Common;
using System.ServiceModel;

namespace Modules.CompanyModule.Views
{
    [SmartPart]
    public partial class CompanyListForm : Framework.UI.Template.Single.SingleListForm
    {
        private List<Criterion> Criterions = new List<Criterion>();

        public CompanyListForm()
        {
            InitializeComponent();
        }

        public CompanyListForm(FormMode mode, bool isMultiSelect)
            : base(mode, isMultiSelect)
        {
            InitializeComponent();
        }

        public override void InitForm()
        {
            RegisterDetailForm("Modules.CompanyModule.Views.CompanyEditForm");
        }

        public override void InitButtonAuthority()
        {
            btnCopy.Tag = "COMPANY_INSERT";
            btnInsert.Tag = "COMPANY_INSERT";
            btnUpdate.Tag = "COMPANY_EDIT";
            btnDelete.Tag = "COMPANY_DELETE";
            btnSearch.Tag = "COMPANY_QUERY";
        }

        public override void LoadData()
        {
            try
            {
                SetQueryConditions();
                PagerQuery query = new PagerQuery("Company", "CompanyId", "*", "CompanyId", 
                    OrderClause.OrderClauseCriteria.Descending, this.PageSize, this.PageNumber, Criterions);

                int totalCount;
                DataList = ServiceHelper.BasicDataService.GetCompanyByPagerQuery(query, out totalCount);
                SetSplitPage(totalCount);
                BindData();
            }
            catch (FaultException<ServiceError> sex)
            {
                if (sex.Detail != null)
                    FormHelper.ShowWarningDialog(sex.Detail.ErrorMessage);
            }
        }

        public override void CustomizeGrid()
        {
            int columnIndex = 0;

            FormHelper.SetGridColumn(MainGridView, "CompanyId", "公司编号", 100, columnIndex++, false);

            FormHelper.SetGridColumn(MainGridView, "CompanyCode", "公司代码", 150, columnIndex++, true);

            FormHelper.SetGridColumn(MainGridView, "CompanyName", "公司名称", 200, columnIndex++, true);

            FormHelper.SetGridColumn(MainGridView, "ShortName", "短名", 150, columnIndex++, true);

            FormHelper.SetGridColumn(MainGridView, "Phone", "联系电话", 100, columnIndex++, true);

            FormHelper.SetGridColumn(MainGridView, "Address", "联系地址", 100, columnIndex++, true);

            FormHelper.SetGridColumn(MainGridView, "Remark", "描述", 200, columnIndex++, true);

            FormHelper.SetGridColumn(MainGridView, "IsActive", "是否可用", 100, columnIndex++, true);

            FormHelper.SetGridColumn(MainGridView, "ParentId", "", 100, columnIndex++, false);
            FormHelper.SetGridColumn(MainGridView, "ErpCode", "", 100, columnIndex++, false);
            FormHelper.SetGridColumn(MainGridView, "PostalCode", "", 100, columnIndex++, false);
            FormHelper.SetGridColumn(MainGridView, "Contactor", "", 100, columnIndex++, false);
            FormHelper.SetGridColumn(MainGridView, "FaxNumber", "", 100, columnIndex++, false);
            FormHelper.SetGridColumn(MainGridView, "CountyId", "", 100, columnIndex++, false);
            FormHelper.SetGridColumn(MainGridView, "OrganizationCode", "", 100, columnIndex++, false);
            FormHelper.SetGridColumn(MainGridView, "Representative", "", 100, columnIndex++, false);
            FormHelper.SetGridColumn(MainGridView, "Homepage", "", 100, columnIndex++, false);
            FormHelper.SetGridColumn(MainGridView, "TaxRegisterationCode", "", 100, columnIndex++, false);
            FormHelper.SetGridColumn(MainGridView, "TaxNumber", "", 100, columnIndex++, false);
            FormHelper.SetGridColumn(MainGridView, "Bank", "", 100, 999, false);
            FormHelper.SetGridColumn(MainGridView, "AccountNumber", "", 100, columnIndex++, false);
            FormHelper.SetGridColumn(MainGridView, "CurrencyType", "", 100, columnIndex++, false);
            FormHelper.SetGridColumn(MainGridView, "InvoiceType", "", 100, columnIndex++, false);
            FormHelper.SetGridColumn(MainGridView, "CreateUser", "", 100, columnIndex++, false);
            FormHelper.SetGridColumn(MainGridView, "CreateTime", "", 100, columnIndex++, false);
            FormHelper.SetGridColumn(MainGridView, "EditUser", "", 100, columnIndex++, false);
            FormHelper.SetGridColumn(MainGridView, "EditTime", "", 100, columnIndex++, false);

            FormHelper.SetGridColumn(MainGridView, "IsValid", "", 100, columnIndex++, false);
        }

        public override void SetQueryConditions()
        {
            Criterions.Clear();

            if (txtCompanyCode.Text.Trim() != "")
                Criterions.Add(new Criterion("CompanyCode", CriteriaOperator.Like, txtCompanyCode.Text.Trim() + "%"));
            if (txtCompanyName.Text.Trim() != "")
                Criterions.Add(new Criterion("CompanyName", CriteriaOperator.Like, txtCompanyName.Text.Trim() + "%"));
        }

        public override void DeleteData()
        {
            Company company = CurrentData as Company;
            if (company == null) return;

            bool deleteResult = false;
            try
            {
                deleteResult = ServiceHelper.BasicDataService.DeleteCompany(company.CompanyId);
            }
            catch (FaultException<ServiceError> sex)
            {
                if (sex.Detail != null)
                    FormHelper.ShowWarningDialog(sex.Detail.ErrorMessage);
            }

            if (!deleteResult)
                FormHelper.ShowInformationDialog("删除公司失败。");
        }
    }
}

