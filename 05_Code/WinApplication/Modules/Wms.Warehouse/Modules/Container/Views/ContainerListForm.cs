using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Business.Common.Exception;
using Business.Common.QueryModel;
using Business.Domain.Warehouse;
using Framework.UI.Template.Common;
using Microsoft.Practices.CompositeUI.SmartParts;
using Wms.Common;
using System.ServiceModel;
using Modules.ContainerModule.Barcode;

namespace Modules.ContainerModule.Views
{
    [SmartPart]
    public partial class ContainerListForm : Framework.UI.Template.Single.SingleListForm
    {
        private List<Criterion> _criterions = new List<Criterion>();

        public ContainerListForm()
        {
            InitializeComponent();
        }

        public ContainerListForm(FormMode mode, bool isMultiSelect) : base(mode, isMultiSelect)
        {
            InitializeComponent();
        }

        public override void InitForm()
        {
            RegisterDetailForm("Modules.ContainerModule.Views.ContainerEditForm");
        }

        public override void InitButtonAuthority()
        {
            btnCopy.Tag = "Container_INSERT";
            btnInsert.Tag = "Container_INSERT";
            btnUpdate.Tag = "Container_EDIT";
            btnDelete.Tag = "Container_DELETE";
            btnSearch.Tag = "Container_QUERY";
        }

        public override void SetButtonStatus()
        {
            //base.SetButtonStatus();
            btnPrint.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnPrint.Caption = @"��ӡ�����ǩ";
        }

        public override void PrintData()
        {
            //base.PrintData();
            Container container = CurrentData as Container;
            if (container == null) return;

            ContainerLabel label = new ContainerLabel();
            string data = string.Format(ContainerLabel.DataFormat, container.ContainerCode, container.ContainerName, container.Barcode);
            label.AppendData(data);
            label.Print();
        }

        public override void LoadData()
        {
            try
            {
                SetQueryConditions();
                PagerQuery query = new PagerQuery("Container", "ContainerId", "*", "ContainerId", 
                    OrderClause.OrderClauseCriteria.Descending, this.PageSize, this.PageNumber, _criterions);

                int totalCount;
                DataList = ServiceHelper.WarehouseService.GetContainerByPagerQuery(query, out totalCount);
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

            FormHelper.SetGridColumn(MainGridView, "ContainerId", "�������", 100, columnIndex++, false);

            FormHelper.SetGridColumn(MainGridView, "ContainerCode", "��������", 150, columnIndex++, true);

            FormHelper.SetGridColumn(MainGridView, "ContainerName", "��������", 200, columnIndex++, true);

            FormHelper.SetGridColumn(MainGridView, "ContainerType", "��������", 100, columnIndex++, true);

            FormHelper.SetGridColumn(MainGridView, "Barcode", "��������", 100, columnIndex++, true);

            FormHelper.SetGridColumn(MainGridView, "WarehouseId", "�ֿ���", 150, columnIndex++, false);

            FormHelper.SetGridColumn(MainGridView, "Remark", "����", 200, columnIndex++, true);

            FormHelper.SetGridColumn(MainGridView, "IsActive", "�Ƿ����", 100, columnIndex++, true);

            FormHelper.SetGridColumn(MainGridView, "CreateUser", "", 100, columnIndex++, false);
            FormHelper.SetGridColumn(MainGridView, "CreateTime", "", 100, columnIndex++, false);
            FormHelper.SetGridColumn(MainGridView, "EditUser", "", 100, columnIndex++, false);
            FormHelper.SetGridColumn(MainGridView, "EditTime", "", 100, columnIndex++, false);

            FormHelper.SetGridColumn(MainGridView, "IsValid", "", 100, columnIndex++, false);
        }

        #region �õ������б�������
        public override void BindGridColumnMap()
        {
            DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit containerTypeLookup = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            containerTypeLookup.DataSource = CacheHelper.ContainerTypeCache;
            containerTypeLookup.DisplayMember = "TypeName";
            containerTypeLookup.ValueMember = "TypeId";
            MainGridView.Columns["ContainerType"].ColumnEdit = containerTypeLookup;
        }
        #endregion

        public override void SetQueryConditions()
        {
            _criterions.Clear();

            _criterions.Add(new Criterion("WarehouseId", CriteriaOperator.Equal, GlobalState.CurrentWarehouse.WarehouseId));

            if (txtContaineCode.Text.Trim() != "")
                _criterions.Add(new Criterion("ContainerCode", CriteriaOperator.Like, txtContaineCode.Text.Trim() + "%"));
            if (txtContaineName.Text.Trim() != "")
                _criterions.Add(new Criterion("ContainerName", CriteriaOperator.Like, txtContaineName.Text.Trim() + "%"));
        }

        public override void DeleteData()
        {
            Container container = CurrentData as Container;
            if (container == null) return;

            bool deleteResult = false;
            try
            {
                deleteResult = ServiceHelper.WarehouseService.DeleteContainer(container.ContainerId);
            }
            catch (FaultException<ServiceError> sex)
            {
                if (sex.Detail != null)
                    FormHelper.ShowWarningDialog(sex.Detail.ErrorMessage);
            }

            if (!deleteResult)
                FormHelper.ShowInformationDialog("ɾ������ʧ�ܡ�");
        }
    }
}

