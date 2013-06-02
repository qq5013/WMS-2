using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Business.Domain.Mobile.Inventory
{
    public class StockView //: Stock
    {
        public virtual bool IsValid
        {
            get { return true; }
        }

        public string SkuNumber { get; set; }

        public string SkuName { get; set; }


        /// <summary>
        /// 库存数量
        /// </summary>
        public int Qty { get; set; }

        public string PackName { get; set; }

        public string LocationName { get; set; }
        public string ContainerName { get; set; }

        public string LocationCode { get; set; }
        public string ContainerCode { get; set; }
        


        /// <summary>
        /// 库存编号
        /// </summary>
        public int StockId { get; set; }

        /// <summary>
        /// 仓库编号
        /// </summary>
        public int WarehouseId { get; set; }

        /// <summary>
        /// 库位编号
        /// </summary>
        public int LocationId { get; set; }

        /// <summary>
        /// 容器编号
        /// </summary>
        public int ContainerId { get; set; }

        /// <summary>
        /// 货物编号
        /// </summary>
        public int SkuId { get; set; }

        /// <summary>
        /// 包装编号
        /// </summary>
        public int PackId { get; set; }

        /// <summary>
        /// 入库批次号
        /// </summary>
        public string BatchNumber { get; set; }


        /// <summary> 
        /// 库区编号
        /// </summary> 
        public int AreaId { get; set; }

        /// <summary> 
        /// 库区类型
        /// </summary> 
        public int AreaType { get; set; }

        /// <summary> 
        /// 入库计划号
        /// </summary> 
        public string PlanNumber { get; set; }

        /// <summary> 
        /// 入库单号
        /// </summary> 
        public string BillNumber { get; set; }

        /// <summary> 
        /// 入库日期
        /// </summary> 
        public string InboundDate { get; set; }

        /// <summary> 
        /// 生产日期
        /// </summary> 
        public string ProductionDate { get; set; }

        /// <summary> 
        /// 过期日期
        /// </summary> 
        public string ExpiringDate { get; set; }

        /// <summary> 
        /// 产品批号
        /// </summary> 
        public string ProductionBatch { get; set; }

        /// <summary> 
        /// 产地
        /// </summary> 
        public string ManufacturingOrigin { get; set; }

        /// <summary> 
        /// 扩展属性1
        /// </summary> 
        public string PropertyValue1 { get; set; }

        /// <summary> 
        /// 扩展属性2
        /// </summary> 
        public string PropertyValue2 { get; set; }

        /// <summary> 
        /// 扩展属性3
        /// </summary> 
        public string PropertyValue3 { get; set; }

        /// <summary> 
        /// 扩展属性4
        /// </summary> 
        public string PropertyValue4 { get; set; }

        /// <summary> 
        /// 扩展属性5
        /// </summary> 
        public string PropertyValue5 { get; set; }

        /// <summary> 
        /// 扩展属性6
        /// </summary> 
        public string PropertyValue6 { get; set; }

    }
}
