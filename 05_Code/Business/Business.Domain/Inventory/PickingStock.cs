using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Domain.Warehouse
{
    public class PickingStock
    {
        /// <summary>
        /// 库位编号
        /// </summary>
        public int LocationId { get; set; }

        /// <summary>
        /// 库位代码
        /// </summary>
        public string LocationCode { get; set; }

        /// <summary>
        /// 库位名称
        /// </summary>
        public string LocationName { get; set; }

        /// <summary>
        /// 库位条码
        /// </summary>
        public string LocationBarcode { get; set; }

        /// <summary>
        /// 路线序号
        /// </summary>
        public int Route { get; set; }

        /// <summary>
        /// 容器编号
        /// </summary>
        public int ContainerId { get; set; }

        /// <summary>
        /// 容器代码
        /// </summary>
        public string ContainerCode { get; set; }

        /// <summary>
        /// 容器名称
        /// </summary>
        public string ContainerName { get; set; }

        /// <summary>
        /// 容器条码
        /// </summary>
        public string ContainerBarcode { get; set; }

        /// <summary>
        /// 货物编号
        /// </summary>
        public int SkuId { get; set; }

        /// <summary>
        /// 货物代码
        /// </summary>
        public string SkuNumber { get; set; }

        /// <summary>
        /// 货物名称
        /// </summary>
        public string SkuName { get; set; }

        /// <summary>
        /// 货物条码
        /// </summary>
        public string SkuBarcode { get; set; }

        /// <summary>
        /// 货物UPC码
        /// </summary>
        public string UPC { get; set; }

        /// <summary>
        /// 包装编号
        /// </summary>
        public int PackId { get; set; }

        /// <summary>
        /// 包装名称
        /// </summary>
        public string PackName { get; set; }

        /// <summary>
        /// 入库单号
        /// </summary>
        public string InboundBillNumber { get; set; }

        /// <summary>
        /// 入库批次
        /// </summary>
        public string BatchNumber { get; set; }

        /// <summary>
        /// 库位上货物库存数量
        /// </summary>
        public int StockQty { get; set; }

        /// <summary>
        /// 库存编号
        /// </summary>
        public int StockId { get; set; }
    }
}
