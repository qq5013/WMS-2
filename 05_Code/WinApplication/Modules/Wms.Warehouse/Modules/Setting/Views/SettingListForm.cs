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

namespace Modules.SettingModule.Views
{
    [SmartPart]
    public partial class SettingListForm : Framework.UI.Template.Single.SingleListForm
    {
        private List<Criterion> _criterions = new List<Criterion>();

        public SettingListForm()
        {
            InitializeComponent();
        }

        public override void InitForm()
        {
            RegisterDetailForm("Modules.SettingModule.Views.SettingEditForm");
        }

        public override void InitButtonAuthority()
        {
            btnCopy.Tag = "SETTING_INSERT";
            btnInsert.Tag = "SETTING_INSERT";
            btnUpdate.Tag = "SETTING_EDIT";
            btnDelete.Tag = "SETTING_DELETE";
            btnSearch.Tag = "SETTING_QUERY";
        }

        public override void LoadData()
        {
            try
            {
                SetQueryConditions();
                PagerQuery query = new PagerQuery("Setting", "SettingId", "*", "SettingId", 
                    OrderClause.OrderClauseCriteria.Descending, this.PageSize, this.PageNumber, _criterions);

                int totalCount;
                DataList = ServiceHelper.WarehouseService.GetSettingByPagerQuery(query, out totalCount);
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

            FormHelper.SetGridColumn(MainGridView, "WarehouseId", "≤÷ø‚±‡∫≈", 100, columnIndex++, false);

            FormHelper.SetGridColumn(MainGridView, "SettingId", "…Ë÷√±‡∫≈", 100, columnIndex++, false);

            FormHelper.SetGridColumn(MainGridView, "SettingCode", "…Ë÷√¥˙¬Î", 150, columnIndex++, true);

            FormHelper.SetGridColumn(MainGridView, "SettingValue", "…Ë÷√÷µ", 200, columnIndex++, true);

            FormHelper.SetGridColumn(MainGridView, "ValueType", "÷µ¿‡–Õ", 150, columnIndex++, true);

            FormHelper.SetGridColumn(MainGridView, "Remark", "√Ë ˆ", 200, columnIndex++, true);

            FormHelper.SetGridColumn(MainGridView, "IsActive", " «∑Òø…”√", 100, columnIndex++, true);

            FormHelper.SetGridColumn(MainGridView, "IsValid", "", 100, columnIndex++, false);

            FormHelper.SetGridColumn(MainGridView, "CreateUser", "", 100, columnIndex++, false);

            FormHelper.SetGridColumn(MainGridView, "CreateTime", "", 100, columnIndex++, false);

            FormHelper.SetGridColumn(MainGridView, "EditUser", "", 100, columnIndex++, false);

            FormHelper.SetGridColumn(MainGridView, "EditTime", "", 100, columnIndex++, false);
        }

        public override void SetQueryConditions()
        {
            _criterions.Clear();
            _criterions.Add(new Criterion("WarehouseId", CriteriaOperator.Like, GlobalState.CurrentWarehouse.WarehouseId));
            if (txtSettingCode.Text.Trim() != "")
                _criterions.Add(new Criterion("SettingCode", CriteriaOperator.Like, txtSettingCode.Text.Trim() + "%"));
        }

        public override void DeleteData()
        {
            Setting setting = CurrentData as Setting;
            if (setting == null) return;

            bool deleteResult = false;
            try
            {
                deleteResult = ServiceHelper.WarehouseService.DeleteSetting(setting.SettingId);
            }
            catch (FaultException<ServiceError> sex)
            {
                if (sex.Detail != null)
                    FormHelper.ShowWarningDialog(sex.Detail.ErrorMessage);
            }

            if (!deleteResult)
                FormHelper.ShowInformationDialog("…æ≥˝≤÷ø‚…Ë÷√ ß∞‹°£");
        }
    }
}

