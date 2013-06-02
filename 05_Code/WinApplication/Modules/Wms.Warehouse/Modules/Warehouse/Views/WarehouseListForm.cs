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

namespace Modules.WarehouseModule.Views
{
    [SmartPart]
    public partial class WarehouseListForm : Framework.UI.Template.Single.SingleListForm
    {
        private List<Criterion> Criterions = new List<Criterion>();

        public WarehouseListForm()
        {
            InitializeComponent();
        }

        public WarehouseListForm(FormMode mode, bool isMultiSelect) : base(mode, isMultiSelect)
        {
            InitializeComponent();
        }

        public override void InitForm()
        {
            RegisterDetailForm("Modules.WarehouseModule.Views.WarehouseEditForm");
        }

        public override void InitButtonAuthority()
        {
            btnCopy.Tag = "WAREHOUSE_INSERT";
            btnInsert.Tag = "WAREHOUSE_INSERT";
            btnUpdate.Tag = "WAREHOUSE_EDIT";
            btnDelete.Tag = "WAREHOUSE_DELETE";
            btnSearch.Tag = "WAREHOUSE_QUERY";
        }

        public override void LoadData()
        {
            try
            {
                SetQueryConditions();
                PagerQuery query = new PagerQuery("Warehouse", "WarehouseId", "*", "WarehouseId", 
                    OrderClause.OrderClauseCriteria.Descending, this.PageSize, this.PageNumber, Criterions);

                int totalCount;
                DataList = ServiceHelper.WarehouseService.GetWarehouseByPagerQuery(query, out totalCount);
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

            FormHelper.SetGridColumn(MainGridView, "WarehouseId", "�ֿ���", 100, columnIndex++, false);

            FormHelper.SetGridColumn(MainGridView, "WarehouseCode", "�ֿ����", 150, columnIndex++, true);

            FormHelper.SetGridColumn(MainGridView, "WarehouseName", "�ֿ�����", 200, columnIndex++, true);

            FormHelper.SetGridColumn(MainGridView, "CountyId", "����", 150, columnIndex++, false);

            FormHelper.SetGridColumn(MainGridView, "Isbonded", "�Ƿ�˰", 100, columnIndex++, false);

            FormHelper.SetGridColumn(MainGridView, "Acreage", "���", 100, columnIndex++, true);

            FormHelper.SetGridColumn(MainGridView, "PostalCode", "�ʱ�", 100, columnIndex++, true);

            FormHelper.SetGridColumn(MainGridView, "Address", "��ַ", 100, columnIndex++, true);

            FormHelper.SetGridColumn(MainGridView, "Contactor", "��ϵ��", 100, columnIndex++, true);

            FormHelper.SetGridColumn(MainGridView, "Phone", "�绰", 100, columnIndex++, true);

            FormHelper.SetGridColumn(MainGridView, "FaxNumber", "����", 100, columnIndex++, true);

            FormHelper.SetGridColumn(MainGridView, "Remark", "", 100, columnIndex++, false);

            FormHelper.SetGridColumn(MainGridView, "CreateUser", "", 100, columnIndex++, false);

            FormHelper.SetGridColumn(MainGridView, "CreateTime", "", 100, columnIndex++, false);

            FormHelper.SetGridColumn(MainGridView, "EditUser", "", 100, columnIndex++, false);

            FormHelper.SetGridColumn(MainGridView, "EditTime", "", 100, columnIndex++, false);

            FormHelper.SetGridColumn(MainGridView, "IsActive", "�Ƿ����", 100, columnIndex++, true);

            FormHelper.SetGridColumn(MainGridView, "IsValid", "", 100, columnIndex++, false);
        }

        public override void SetQueryConditions()
        {
            Criterions.Clear();

            if (txtWarehouseCode.Text.Trim() != "")
                Criterions.Add(new Criterion("WarehouseCode", CriteriaOperator.Like, txtWarehouseCode.Text.Trim() + "%"));
            if (txtWarehouseName.Text.Trim() != "")
                Criterions.Add(new Criterion("WarehouseName", CriteriaOperator.Like, txtWarehouseName.Text.Trim() + "%"));
        }

        public override void DeleteData()
        {
            Warehouse warehouse = CurrentData as Warehouse;
            if (warehouse == null) return;

            bool deleteResult = false;
            try
            {
                deleteResult = ServiceHelper.WarehouseService.DeleteWarehouse(warehouse.WarehouseId);
            }
            catch (FaultException<ServiceError> sex)
            {
                if (sex.Detail != null)
                    FormHelper.ShowWarningDialog(sex.Detail.ErrorMessage);
            }

            if (!deleteResult)
                FormHelper.ShowInformationDialog("ɾ���ֿ�ʧ�ܡ�");
        }
    }
}

