using Business.Service.Contract;
using Spring.Context;
using Spring.Context.Support;
using System;

namespace Wms.Common
{
    public class ServiceHelper
    {
        static readonly IApplicationContext ApplicationContext = ContextRegistry.GetContext();

        public static IApplicationService ApplicationService;
        public static IBasicDataService BasicDataService;
        public static IWarehouseService WarehouseService;
        public static ISkuService SkuService;
        public static IInboundService InboundService;
        public static IOutboundService OutboundService;
        public static IInventoryService InventoryService;

        static ServiceHelper()
        {
            ApplicationService = (IApplicationService)ApplicationContext.GetObject("ApplicationService");
            BasicDataService = (IBasicDataService)ApplicationContext.GetObject("BasicDataService");
            WarehouseService = (IWarehouseService)ApplicationContext.GetObject("WarehouseService");
            SkuService = (ISkuService)ApplicationContext.GetObject("SkuService");
            InboundService = (IInboundService)ApplicationContext.GetObject("InboundService");
            OutboundService = (IOutboundService)ApplicationContext.GetObject("OutboundService");
            InventoryService = (IInventoryService)ApplicationContext.GetObject("InventoryService");
        }
    }
}
