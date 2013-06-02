using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Business.Domain.Mobile.Inventory
{
    public class Stock : DomainObject
    {
        /// <summary>
        /// 库存编号
        /// </summary>
        public int StockId { get; set; }

        /// <summary>
        /// 仓库编号
        /// </summary>
        public int WarehouseId { get; set; }
		
		/// <summary> 
        /// 入库单号
        /// </summary> 
        public string BillNumber { get; set; }

        /// <summary> 
        /// 入库日期
        /// </summary> 
        public string InboundDate { get; set; }

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
        /// 库存数量
        /// </summary>
        public int Qty { get; set; }
    }
}
