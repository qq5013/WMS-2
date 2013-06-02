using System;
using System.Collections.Generic;
using System.ServiceModel;
using Business.Common.Exception;
using DevExpress.XtraEditors.Repository;
using Frame.Utils.RelaAndCondition;
using Frame.Utils.Service;
using Framework.UI.Template.Common;
using Framework.UI.Template.Single;
using MES.BllService;
using MES.Common;
using MES.Entity;
using Microsoft.Practices.CompositeUI.SmartParts;

namespace Mes.Product.Modules.ProductLineModel
{
    [SmartPart]
    public partial class ProductLineListForm : SingleListForm
    {
        private readonly List<EntitySetting<ProductLine>> _settings =
            new List<EntitySetting<ProductLine>>();

        private Condition _condition;

        private IEntityService<ProductLine> _service;

        public ProductLineListForm()
        {
            InitializeComponent();
        }

        public ProductLineListForm(FormMode mode, bool isMultiSelect)
            : base(mode, isMultiSelect)
        {
            InitializeComponent();
        }

        public override void InitForm()
        {
//产线名称	
//产线代码	
//产线类别	按将来实际需要区分类别, 下拉选择
//描述	

            _settings
                .Setting(c => c.Name, new EntitySetting
                    {
                        Name = "产线名称",
                        Width = 100,
                        Control = teName,
                        ConditionOperator = ConditionOperator.Like
                    })
                .Setting(c => c.Code, new EntitySetting
                    {
                        Name = "产线代码",
                        Width = 100,
                        Control = teCode
                    })
                .Setting(c => c.ProductLineType, new EntitySetting
                    {
                        Name = "产线类别",
                        Width = 100,
                        Control = lueProductLineType.BindProductLineType(),
                        ColumnEdit = new RepositoryItemLookUpEdit().BindProductLineType()
                    })
                .Setting(c => c.Description, new EntitySetting
                    {
                        Name = "描述",
                        Width = 100,
                        Control = meRemark,
                        ConditionOperator = ConditionOperator.Like
                    });
            _service = ServiceBloker.GetService<ProductLine>();
            RegisterDetailForm(typeof (ProductLineEditForm).FullName);
        }

        public override void InitButtonAuthority()
        {
            //btnCopy.Tag = "ProductLine_INSERT";
            //btnInsert.Tag = "ProductLine_INSERT";
            //btnUpdate.Tag = "ProductLine_EDIT";
            //btnDelete.Tag = "ProductLine_DELETE";
            //btnSearch.Tag = "ProductLine_QUERY";
        }

        public override void LoadData()
        {
            try
            {
                _condition = null;
                var query = new QueryInfo
                    {
                        Condition = _settings.Condition(_condition)
                    };
                int totalCount = _service.GetCount(query);
                DataList = _service.GetList(query, (PageNumber - 1)*PageSize, PageSize);
                SetSplitPage(totalCount);
                BindData();
            }
            catch (Exception ex)
            {
                ex.Process();
            }
        }

        public override void CustomizeGrid()
        {
            _settings.SetGridColumn(MainGridView);
        }

        public override void SetQueryConditions()
        {
            _condition = _settings.Condition(null);
        }

        public override void QueryData(int pageSize, int pageNumber)
        {
            try
            {
                _condition = null;
                var query = new QueryInfo {Condition = _settings.Condition(_condition)};

                int totalCount = _service.GetCount(query);
                DataList = _service.GetList(query, (pageNumber - 1)*pageSize, pageSize);
                SetSplitPage(totalCount);
                BindData();
            }
            catch (FaultException<ServiceError> sex)
            {
                sex.Process();
                if (sex.Detail != null)
                    FormHelper.ShowWarningDialog(sex.Detail.ErrorMessage);
            }
        }

        public override void DeleteData()
        {
            var productLine = CurrentData as ProductLine;
            if (productLine == null) return;

            bool deleteResult = false;
            try
            {
                deleteResult = _service.Delete(productLine.ProductLineId) > 0;
            }
            catch (FaultException<ServiceError> sex)
            {
                sex.Process();
                if (sex.Detail != null)
                    FormHelper.ShowWarningDialog(sex.Detail.ErrorMessage);
            }

            if (deleteResult)
                FormHelper.ShowInformationDialog("删除产线成功。");
        }
    }
}