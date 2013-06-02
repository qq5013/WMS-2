using System.Collections.Generic;
using System.ComponentModel;
using System.ServiceModel;
using Business.Common.Exception;
using Business.Common.Toolkit;
using Business.Domain.Application;
using DevExpress.XtraBars;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
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

namespace Mes.Product.Modules.ProductionOrderModel
{
    [SmartPart]
    public partial class ProductionOrderListForm : MasterListForm
    {
        private Condition _condition;
        private IEntityService<ProductionOrder> _service;
        private List<EntitySetting<ProductionOrder>> _settings;

        public ProductionOrderListForm()
        {
            InitializeComponent();
        }

        public ProductionOrderListForm(FormMode mode, bool isMultiSelect)
            : base(mode, isMultiSelect)
        {
            InitializeComponent();
        }


        public override bool ValidateUpdateAuthority()
        {
            var bill = CurrentData as ProductionOrder;
            if (bill != null)
            {
                DataDictionary dictionary = ServiceHelper.ApplicationService.GetDataDictionary((int) bill.Status);

                if (dictionary != null)
                {
                    if (dictionary.DictionaryCode !=
                        DictionaryHelper.ConvertToDictionaryCode((int) ProductionOrderStatus.Created) &&
                        dictionary.DictionaryCode !=
                        DictionaryHelper.ConvertToDictionaryCode((int) ProductionOrderStatus.Finished))
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
            //btnAdd.Tag = "INBOUNDPLAN_INSERT";
            //btnUpdate.Tag = "INBOUNDPLAN_EDIT";
        }


        public override void FormInitialize()
        {
            RegisterDetailForm(typeof (ProductionOrderEditForm).FullName);
            _service = ServiceBloker.GetService<ProductionOrder>();
            _settings = new List<EntitySetting<ProductionOrder>>()
               .Setting(c => c.Code, new EntitySetting
               {
                   Name = "单据号",
                   Width = 100
               })
                .Setting(c => c.CustomerName, new EntitySetting
                    {
                        Name = "客户",
                        Width = 100,
                        Control = beCustomer.BindCustomer()
                    })
                .Setting(c => c.OrderDate, new EntitySetting
                    {
                        Name = "订购日期",
                        Width = 100,
                        Control = deOrderDate.BindDate()
                    })
                .Setting(c => c.DeliveryDate, new EntitySetting
                    {
                        Name = "交货日期",
                        Width = 100,
                        Control = deDeliveryDate.BindDate()
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
                        Control = deCreateTime.BindDate()
                    })
                .Setting(c => c.OrderType, new EntitySetting
                    {
                        Name = "工单类型",
                        Width = 100,
                        Control = lueOrderType.BindProductionOrderType(),
                        ColumnEdit = new RepositoryItemLookUpEdit().BindProductionOrderType()
                    })
                .Setting(c => c.Remark, new EntitySetting
                    {
                        Name = "备注",
                        Width = 100,
                        Control = meRemark
                    });


            var barButtonItem = new BarButtonItem(bmMaster, "生成领料单") {Visibility = BarItemVisibility.Always};
            barButtonItem.ItemClick += (sender, e) => { };
            bmMaster.Items.Insert(0, barButtonItem);
        }

        public override void SetButtonStatus()
        {
            base.SetButtonStatus();

            const string name = "生产总工单";
            btnAdd.Caption = string.Format("新增{0}", name);
            btnUpdate.Caption = string.Format("编辑{0}", name);
        }

        public override void LoadData()
        {
            QueryData(PageSize, PageNumber);
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

        public override void CustomizeGrid()
        {
            _settings.SetGridColumn(MasterGridView);
            MasterGridView.OptionsDetail.EnableMasterViewMode = true;
            MasterGridView.OptionsDetail.AllowExpandEmptyDetails = true;
            MasterGridView.MasterRowExpanding +=
                (sender, e) =>
                ((ProductionOrder) MasterGridView.GetRow(e.RowHandle)).Details.Add(new ProductionOrderDetail());
            var gridView = new GridView();

            ((ISupportInitialize) (gridView)).BeginInit();
            MasterGrid.ViewCollection.Add(gridView);
            MasterGrid.LevelTree.Nodes.AddRange(new[]
                {
                    new GridLevelNode {LevelTemplate = gridView, RelationName = "Details"}
                });
            gridView.GridControl = MasterGrid;
            gridView.Name = "gridView1";
            gridView.VertScrollVisibility = ScrollVisibility.Never;


            new List<EntitySetting<ProductionOrderDetail>>()
                .Setting(c => c.ProductId, new EntitySetting
                    {
                        Name = "产品代码",
                        Width = 100,
                        Control = null
                    })
                .Setting(c => c.ProductId, new EntitySetting
                    {
                        Name = "产品名称",
                        Width = 100,
                        Control = null
                    })
                .Setting(c => c.ProductId, new EntitySetting
                    {
                        Name = "产品类型",
                        Width = 100,
                        Control = null
                    })
                .Setting(c => c.Quantity, new EntitySetting
                    {
                        Name = "生产数量",
                        Width = 100,
                        Control = null
                    })
                .Setting(c => c.MeasureId, new EntitySetting
                    {
                        Name = "单位",
                        Width = 100,
                        Control = null,
                    })
                .Setting(c => c.FinishDate, new EntitySetting
                    {
                        Name = "完工日期",
                        Width = 100,
                        Control = null
                    })
                .Setting(c => c.Remark, new EntitySetting
                    {
                        Name = "备注",
                        Width = 100,
                        Control = null
                    }).SetGridColumn(gridView);


            ((ISupportInitialize) (gridView)).EndInit();
        }
    }
}