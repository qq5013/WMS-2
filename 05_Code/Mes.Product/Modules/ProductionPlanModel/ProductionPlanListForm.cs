using System.Collections.Generic;
using System.ServiceModel;
using Business.Common.Exception;
using Business.Common.Toolkit;
using Business.Domain.Application;
using DevExpress.XtraEditors.Repository;
using Frame.Utils.RelaAndCondition;
using Frame.Utils.Service;
using Framework.UI.Template.Common;
using Framework.UI.Template.MasterDetail;
using MES.BllService;
using MES.Common;
using MES.Entity;
using MES.Enum;
using Microsoft.Practices.CompositeUI.SmartParts;
using Wms.Common;

namespace Mes.Product.Modules.ProductionPlanModel
{
    [SmartPart]
    public partial class ProductionPlanListForm : MasterListForm
    {
        private Condition _condition;
        private IEntityService<ProductionPlan> _service;
        private List<EntitySetting<ProductionPlan>> _settings;

        public ProductionPlanListForm()
        {
            InitializeComponent();
        }

        public ProductionPlanListForm(FormMode mode, bool isMultiSelect)
            : base(mode, isMultiSelect)
        {
            InitializeComponent();
        }


        public override bool ValidateUpdateAuthority()
        {
            var plan = CurrentData as ProductionPlan;
            if (plan != null)
            {
                DataDictionary dictionary = ServiceHelper.ApplicationService.GetDataDictionary((int) plan.Status);

                if (dictionary != null)
                {
                    if (dictionary.DictionaryCode !=
                        DictionaryHelper.ConvertToDictionaryCode((int) ProductionPlanStatus.Created) &&
                        dictionary.DictionaryCode !=
                        DictionaryHelper.ConvertToDictionaryCode((int) ProductionPlanStatus.Finished))
                    {
                        FormHelper.ShowWarningDialog("此生产计划当前状态不允许被编辑。");
                        return false;
                    }
                }
            }
            return true;
        }

        public override void InitButtonAuthority()
        {
            //btnAdd.Tag = "ProductionPlan_INSERT";
            //btnUpdate.Tag = "ProductionPlan_EDIT";
        }


        public override void FormInitialize()
        {
            RegisterDetailForm(typeof (ProductionPlanEditForm).FullName);

            //            客户		联系人		订购日期		交货日期		交货地址
            //下单员		制单人      		制单日期		备注		
            _settings = new List<EntitySetting<ProductionPlan>>()
                .Setting(c => c.CustomerName, new EntitySetting
                    {
                        Name = "客户",
                        Width = 100,
                        Control = beCustomer.BindCustomer()
                    })
                .Setting(c => c.ContractWith, new EntitySetting
                    {
                        Name = "联系人",
                        Width = 100,
                        ConditionOperator = ConditionOperator.Like,
                        Control = teContractWith
                    })
                .Setting(c => c.OrderDate, new EntitySetting
                    {
                        Name = "订购日期",
                        Width = 100,
                        Control = deOrderDate
                    })
                .Setting(c => c.DeliveryDate, new EntitySetting
                    {
                        Name = "交货日期",
                        Width = 100,
                        Control = deDeliveryDate
                    })
                .Setting(c => c.DeliveryAddress, new EntitySetting
                    {
                        Name = "交货地址",
                        Width = 100,
                        ConditionOperator = ConditionOperator.Like,
                        Control = teDeliveryAddress
                    })
                .Setting(c => c.OrderCreaterId, new EntitySetting
                    {
                        Name = "下单员",
                        Width = 100,
                        Control = leOrderId.BindUser(),
                        ColumnEdit = new RepositoryItemLookUpEdit().BindUser()
                    })
                .Setting(c => c.CreaterId, new EntitySetting
                    {
                        Name = "制单人",
                        Width = 100,
                        Control = lueCreateId.BindUser(),
                        ColumnEdit = new RepositoryItemLookUpEdit().BindUser()
                    })
                .Setting(c => c.CreateTime, new EntitySetting
                    {
                        Name = "制单日期",
                        Width = 100,
                        Control = deCreatedAt
                    })
                .Setting(c => c.Remark, new EntitySetting
                    {
                        Name = "备注",
                        Width = 100,
                        ConditionOperator = ConditionOperator.Like,
                        Control = meRemark
                    });


            _service = ServiceBloker.GetService<ProductionPlan>();
        }

        public override void SetButtonStatus()
        {
            base.SetButtonStatus();

            btnAdd.Caption = "新增生产计划";
            btnUpdate.Caption = "编辑生产计划";
        }

        public override void LoadData()
        {
            try
            {
                _condition = null;
                var query = new QueryInfo
                    {
                        Condition = _settings.Condition(_condition),
                    };
                int totalCount = _service.GetCount(query);
                DataList = _service.GetList(query, (PageNumber - 1)*PageSize, PageSize);
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


        public override void QueryData(int pageSize, int pageNumber)
        {
            try
            {
                _condition = null;
                var query = new QueryInfo
                    {
                        Condition = _settings.Condition(_condition),
                    };
                int totalCount = _service.GetCount(query);
                DataList = _service.GetList(query, (PageNumber - 1)*PageSize, PageSize);
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

        public override void CustomizeGrid()
        {
            _settings.SetGridColumn(MasterGridView);
        }
    }
}