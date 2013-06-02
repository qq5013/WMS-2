using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Domain.Inventory.Views
{
    public class StockLogView : StockLog
    {
        /// <summary>
        /// 库存日志类型
        /// </summary>
        public string LogTypeName { set; get; }

        /// <summary>
        /// 货物名称
        /// </summary>
        public string SkuName { set; get; }

        /// <summary>
        /// 包装名称
        /// </summary>
        public string PackName { set; get; }

        ///// <summary>
        ///// 客户名称
        ///// </summary>
        //public string ClientName { set; get; }

        ///// <summary>
        ///// 商家名称
        ///// </summary>
        //public string MerchantName { set; get; }

        ///// <summary>
        ///// 供应商名称
        ///// </summary>
        //public string VendorName { set; get; }

        ///// <summary>
        ///// 入库计划号
        ///// </summary>
        //public string PlanNumber { set; get; }

        ///// <summary>
        ///// 入库单号
        ///// </summary>
        //public string BillNumber { set; get; }

        /// <summary>
        /// 仓库名称
        /// </summary>
        public string WarehouseName { set; get; }

        /// <summary>
        /// 库区名称
        /// </summary>
        public string AreaName { set; get; }

        /// <summary>
        /// 库位名称
        /// </summary>
        public string LocationName { set; get; }

        /// <summary>
        /// 容器名称
        /// </summary>
        public string ContainerName { set; get; }

        public string WarehouseCode { set; get; }

        public int AreaId { set; get; }

        public string AreaCode { set; get; }

        public string BillTypeName { set; get; }

        public string SkuNumber { set; get; }

        public string LocationCode { set; get; }

        public string ContainerCode { set; get; }


        public string ProductionDate { get; set; }
        public string ExpiringDate { get; set; }
        public string ProductionBatch { get; set; }
        public string ManufacturingOrigin { get; set; }
        public string PropertyValue1 { get; set; }
        public string PropertyValue2 { get; set; }
        public string PropertyValue3 { get; set; }
        public string PropertyValue4 { get; set; }
        public string PropertyValue5 { get; set; }
        public string PropertyValue6 { get; set; }
    }
}
