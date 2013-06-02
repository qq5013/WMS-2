using System.Collections.Generic;

namespace Business.Domain.Inventory
{
    public class OutboundBillDetail : DomainObject
    {
        /// <summary>
        /// 自动编号
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 出库单编号
        /// </summary>
        public int BillId { get; set; }

        /// <summary>
        /// 库存编号
        /// </summary>
        public int StockId { get; set; }

        /// <summary>
        /// 发货库位编号
        /// </summary>
        public int LocationId { get; set; }

        /// <summary>
        /// 发货存储单元
        /// </summary>
        public int ContainerId { get; set; }

        /// <summary>
        /// 货物编号
        /// </summary>
        public int SkuId { get; set; }

        /// <summary>
        /// 货物包装
        /// </summary>
        public int PackId { get; set; }

        /// <summary>
        /// 入库批次号
        /// </summary>
        public string BatchNumber { get; set; }

        /// <summary>
        /// 发货数量
        /// </summary>
        public int Qty { get; set; }

        public List<string> SerialNumbers { get; set; }

        public OutboundBillDetail()
        {
            SerialNumbers = new List<string>();

            BatchNumber = string.Empty;
        }
    }
}