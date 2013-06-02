using System;
using Mes.Product.Modules.MaterialRequisitionModel;
using Mes.Product.Modules.ProcessModule;
using Mes.Product.Modules.ProductLineModel;
using Mes.Product.Modules.ProductStationModel;
using Mes.Product.Modules.ProductionOrderModel;
using Mes.Product.Modules.ProductionPlanModel;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.Commands;

namespace Mes.Product
{
    public class ProductController : Controller
    {
        [CommandHandler("ProcessModule.ShowForm")]
        public void ShowProcessListFormHandler(object sender, EventArgs e)
        {
            this.Show<ProcessListForm>("工序信息", null);
        }

        [CommandHandler("ProductLineModule.ShowForm")]
        public void ShowProductLineListFormHandler(object sender, EventArgs e)
        {
            this.Show<ProductLineListForm>("产线信息");
        }

        [CommandHandler("ProductStationModule.ShowForm")]
        public void ShowProductStationListFormHandler(object sender, EventArgs e)
        {
            this.Show<ProductStationListForm>("工位信息");
        }

        [CommandHandler("ProductionOrderModule.ShowForm")]
        public void ShowInboundPlanListFormHander(object sender, EventArgs e)
        {
            this.Show<ProductionOrderListForm>("生产工单维护", null);
        }

        [CommandHandler("ProductionPlanModule.ShowForm")]
        public void ShowProductionPlanListFormHander(object sender, EventArgs e)
        {
            this.Show<ProductionPlanListForm>("生产计划计划维护", null);
        }

        [CommandHandler("MaterialRequisitionModule.ShowForm")]
        public void ShowMaterialRequisitionListFormHander(object sender, EventArgs e)
        {
            this.Show<MaterialRequisitionListForm>("领料单管理", null);
        }
    }
}