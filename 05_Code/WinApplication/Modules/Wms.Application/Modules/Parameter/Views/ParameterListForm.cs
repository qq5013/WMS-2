using System.Collections.Generic;
using Business.Common.Exception;
using Business.Common.QueryModel;
using Business.Domain.Application;
using Framework.UI.Template.Common;
using Framework.UI.Template.Single;
using Microsoft.Practices.CompositeUI.SmartParts;
using Wms.Common;
using System.ServiceModel;

namespace Modules.ParameterModule.Views
{
    [SmartPart]
    public partial class ParameterListForm : SingleListForm
    {
        private readonly List<Criterion> _criterions = new List<Criterion>();

        public ParameterListForm()
        {
            InitializeComponent();
        }

        public override void InitForm()
        {
            RegisterDetailForm("Modules.ParameterModule.Views.ParameterEditForm");
        }

        public override void InitButtonAuthority()
        {
            btnCopy.Tag = "PARAMETER_INSERT";
            btnInsert.Tag = "PARAMETER_INSERT";
            btnUpdate.Tag = "PARAMETER_EDIT";
            btnDelete.Tag = "PARAMETER_DELETE";
            btnSearch.Tag = "PARAMETER_QUERY";
        }

        public override void LoadData()
        {
            try
            {
                SetQueryConditions();

                var query = new PagerQuery("Parameter", "ParameterId", "*", "ParameterId", 
                    OrderClause.OrderClauseCriteria.Descending, PageSize, PageNumber, _criterions);

                int totalCount;
                DataList = ServiceHelper.ApplicationService.GetParameterByPagerQuery(query, out totalCount);
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

            FormHelper.SetGridColumn(MainGridView, "ApplicationId", "应用编号", 100, columnIndex++, false);
            FormHelper.SetGridColumn(MainGridView, "ParameterId", "参数编号", 100, columnIndex++, false);
            FormHelper.SetGridColumn(MainGridView, "ParameterCode", "参数代码", 150, columnIndex++, true);
            FormHelper.SetGridColumn(MainGridView, "ParameterValue", "参数值", 200, columnIndex++, true);
            FormHelper.SetGridColumn(MainGridView, "ValueType", "值类型", 150, columnIndex++, true);
            FormHelper.SetGridColumn(MainGridView, "Remark", "描述", 200, columnIndex++, true);
            FormHelper.SetGridColumn(MainGridView, "IsActive", "是否可用", 100, columnIndex++, true);
            
            FormHelper.SetGridColumn(MainGridView, "IsValid", "", 100, columnIndex++, false);
        }

        public override void SetQueryConditions()
        {
            _criterions.Clear();

            if (txtParameterCode.Text.Trim() != "")
                _criterions.Add(new Criterion("ParameterCode", CriteriaOperator.Like, txtParameterCode.Text.Trim() + "%"));
        }

        public override void DeleteData()
        {
            var parameter = CurrentData as Parameter;
            if (parameter == null) return;

            //bool deleteResult = false;
            try
            {
                ServiceHelper.ApplicationService.DeleteParameter(parameter.ParameterId);
                //deleteResult = ServiceHelper.ApplicationService.DeleteParameter(parameter.ParameterId);
                //if (!deleteResult)
                //    FormHelper.ShowInformationDialog("删除参数失败。");
            }
            catch (FaultException<ServiceError> sex)
            {
                if (sex.Detail != null)
                    FormHelper.ShowWarningDialog(sex.Detail.ErrorMessage);
            }
        }
    }
}

