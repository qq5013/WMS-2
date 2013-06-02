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

namespace Mes.Product.Modules.ProductStationModel
{
    /// <summary>
    /// 工位维护
    /// </summary>
    [SmartPart]
    public partial class ProductStationListForm : SingleListForm
    {
        private Condition _condition;

        private List<EntitySetting<ProductStation>> _settings;

        public ProductStationListForm()
        {
            InitializeComponent();
        }

        public ProductStationListForm(FormMode mode, bool isMultiSelect)
            : base(mode, isMultiSelect)
        {
            InitializeComponent();
        }

        private static IEntityService<ProductStation> Service
        {
            get { return ServiceBloker.GetService<ProductStation>(); }
        }

        public override void InitForm()
        {
            RegisterDetailForm(typeof (ProductStationEditForm).FullName);

            _settings =
                new List<EntitySetting<ProductStation>>()
                    .Setting(c => c.Code, new EntitySetting
                        {
                            Name = "工位代码",
                            Width = 100,
                            Control = teCode
                        })
                    .Setting(c => c.Name, new EntitySetting
                        {
                            Name = "工位名称",
                            Width = 100,
                            ConditionOperator = ConditionOperator.Like,
                            Control = teName
                        })
                    .Setting(c => c.ProductLineId, new EntitySetting
                        {
                            Name = "产线代码",
                            Width = 100,
                            Control = lueProductLine.BindProductLine(),
                            ColumnEdit = new RepositoryItemLookUpEdit().BindProductLine()
                        })
                    .Setting(c => c.Remark, new EntitySetting
                        {
                            Name = "描述",
                            Width = 100,
                            ConditionOperator = ConditionOperator.Like,
                            Control = meRemark
                        });
        }

        public override void InitButtonAuthority()
        {
            //btnCopy.Tag = "ProductStation_INSERT";
            //btnInsert.Tag = "ProductStation_INSERT";
            //btnUpdate.Tag = "ProductStation_EDIT";
            //btnDelete.Tag = "ProductStation_DELETE";
            //btnSearch.Tag = "ProductStation_QUERY";
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
                int totalCount = Service.GetCount(query);
                DataList = Service.GetList(query, (PageNumber - 1)*PageSize, PageSize);
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


        public override void QueryData(int pageSize, int pageNumber)
        {
            try
            {
                _condition = null;
                var query = new QueryInfo {Condition = _settings.Condition(_condition)};

                int totalCount = Service.GetCount(query);
                DataList = Service.GetList(query, (pageNumber - 1)*pageSize, pageSize);
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
            var productStation = CurrentData as ProductStation;
            if (productStation == null) return;

            bool deleteResult = false;
            try
            {
                deleteResult = Service.Delete(productStation.ProductStationId) > 0;
            }
            catch (FaultException<ServiceError> sex)
            {
                sex.Process();
                if (sex.Detail != null)
                    FormHelper.ShowWarningDialog(sex.Detail.ErrorMessage);
            }

            if (deleteResult)
                FormHelper.ShowInformationDialog("删除工位成功。");
        }
    }
}