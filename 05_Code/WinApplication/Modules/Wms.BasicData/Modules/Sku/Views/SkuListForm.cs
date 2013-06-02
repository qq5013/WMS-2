using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using Business.Common.Exception;
using Business.Common.QueryModel;
using Business.Domain.Wms;
using Framework.UI.Template.Common;
using Microsoft.Practices.CompositeUI.SmartParts;
using Wms.Common;
using System.ServiceModel;
using System.Diagnostics;
using Modules.CompanyModule.Views;
using DevExpress.XtraEditors.Controls;

namespace Modules.SkuModule.Views
{
    [SmartPart]
    public partial class SkuListForm : Framework.UI.Template.Single.SingleListForm
    {
        private List<Criterion> Criterions = new List<Criterion>();

        public SkuListForm()
        {
            InitializeComponent();
        }

        public SkuListForm(FormMode mode, bool isMultiSelect) : base(mode, isMultiSelect)
        {
            InitializeComponent();
        }

        public override void InitForm()
        {
            RegisterDetailForm("Modules.SkuModule.Views.SkuEditForm");
        }

        public override void InitButtonAuthority()
        {
            btnCopy.Tag = "SKU_INSERT";
            btnInsert.Tag = "SKU_INSERT";
            btnUpdate.Tag = "SKU_EDIT";
            btnDelete.Tag = "SKU_DELETE";
            btnSearch.Tag = "SKU_QUERY";
        }

        public override void LoadData()
        {
            try
            {
                SetQueryConditions();
                PagerQuery query = new PagerQuery("Vw_Sku", "SkuId", "*", "SkuId", 
                    OrderClause.OrderClauseCriteria.Descending, this.PageSize, this.PageNumber, Criterions);

                int totalCount;
                DataList = ServiceHelper.SkuService.GetSkuViewByPagerQuery(query, out totalCount);
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

            FormHelper.SetGridColumn(MainGridView, "ClientName", "客户", 100, columnIndex++, false);

            FormHelper.SetGridColumn(MainGridView, "MerchantName", "货主名称", 100, columnIndex++, true);
            FormHelper.SetGridColumn(MainGridView, "ErpCode", "货主代码", 150, columnIndex++, true);

            FormHelper.SetGridColumn(MainGridView, "ManufacturerName", "制造商名称", 100, columnIndex++, false);

            FormHelper.SetGridColumn(MainGridView, "SkuId", "货物编号", 100, columnIndex++, false);

            FormHelper.SetGridColumn(MainGridView, "SkuNumber", "货物代码", 150, columnIndex++, true);

            FormHelper.SetGridColumn(MainGridView, "SkuName", "货物名称", 200, columnIndex++, true);

            FormHelper.SetGridColumn(MainGridView, "ClientId", "客户", 100, columnIndex++, false);

            FormHelper.SetGridColumn(MainGridView, "MerchantId", "货主", 100, columnIndex++, false);

            FormHelper.SetGridColumn(MainGridView, "Manufacturer", "制造商", 100, columnIndex++, false);



            FormHelper.SetGridColumn(MainGridView, "Brand", "品牌", 150, columnIndex++, true);
            FormHelper.SetGridColumn(MainGridView, "Model", "型号", 100, columnIndex++, true);
            FormHelper.SetGridColumn(MainGridView, "Specification", "规格", 150, columnIndex++, true);
            FormHelper.SetGridColumn(MainGridView, "Barcode", "库内条码", 100, columnIndex++, true);
            FormHelper.SetGridColumn(MainGridView, "Upc", "UPC码", 150, columnIndex++, true);
            
            
            FormHelper.SetGridColumn(MainGridView, "CategoryId", "管理分类", 100, columnIndex++, false);
            FormHelper.SetGridColumn(MainGridView, "CategoryName", "管理分类", 100, columnIndex++, true);
            FormHelper.SetGridColumn(MainGridView, "GuranteePeriodYear", "保质期-年", 100, columnIndex++, false);
            FormHelper.SetGridColumn(MainGridView, "GuranteePeriodMonth", "保质期-月", 100, columnIndex++, false);
            FormHelper.SetGridColumn(MainGridView, "GuranteePeriodDay", "保质期-日", 100, columnIndex++, false);
            FormHelper.SetGridColumn(MainGridView, "Remark", "描述", 200, columnIndex++, false);

            FormHelper.SetGridColumn(MainGridView, "IsActive", "是否可用", 100, columnIndex++, true);
            FormHelper.SetGridColumn(MainGridView, "CreateUser", "", 100, columnIndex++, false);
            FormHelper.SetGridColumn(MainGridView, "CreateTime", "", 100, columnIndex++, false);
            FormHelper.SetGridColumn(MainGridView, "EditUser", "", 100, columnIndex++, false);
            FormHelper.SetGridColumn(MainGridView, "EditTime", "", 100, columnIndex++, false);

            FormHelper.SetGridColumn(MainGridView, "IsValid", "", 100, columnIndex++, false);
        }

        public override void SetQueryConditions()
        {
            Criterions.Clear();

            if (txtSkuNumber.Text.Trim() != "")
                Criterions.Add(new Criterion("SkuNumber", CriteriaOperator.Like, txtSkuNumber.Text.Trim() + "%"));
            if (txtSkuName.Text.Trim() != "")
                Criterions.Add(new Criterion("SkuName", CriteriaOperator.Like, txtSkuName.Text.Trim() + "%"));
            if (txtErpCode.Text.Trim() != "")
                Criterions.Add(new Criterion("ErpCode", CriteriaOperator.Like, txtErpCode.Text.Trim() + "%"));
            if (txtBarcode.Text.Trim() != "")
                Criterions.Add(new Criterion("Barcode", CriteriaOperator.Like, txtBarcode.Text.Trim() + "%"));
            if (txtUpc.Text.Trim() != "")
                Criterions.Add(new Criterion("Upc", CriteriaOperator.Like, txtUpc.Text.Trim() + "%"));

            if (beMerchantId.Tag != null)
                Criterions.Add(new Criterion("MerchantId", CriteriaOperator.Equal, (beMerchantId.Tag as Company).CompanyId));
        }

        public override void DeleteData()
        {
            Sku sku = CurrentData as Sku;
            if (sku == null) return;

            bool deleteResult = false;
            try
            {
                deleteResult = ServiceHelper.SkuService.DeleteSku(sku.SkuId);
            }
            catch (FaultException<ServiceError> sex)
            {
                if (sex.Detail != null)
                    FormHelper.ShowWarningDialog(sex.Detail.ErrorMessage);
            }

            if (deleteResult)
                FormHelper.ShowInformationDialog("删除货物信息成功。");
        }

        private void beMerchantId_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
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
                beMerchantId.Tag = company;
                beMerchantId.Text = company.ShortName;
            }
        }
    }
}

