namespace Business.Domain.Inventory
{
    public class CountBillDetail : DomainObject
    {
        /// <summary>
        /// 自动编号
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 盘点单编号
        /// </summary>
        public int BillId { get; set; }

        /// <summary>
        /// 库存编号
        /// </summary>
        public int StockId { get; set; }

        /// <summary>
        /// 库位编号
        /// </summary>
        public int LocationId { get; set; }

        /// <summary>
        /// 存储单元编号
        /// </summary>
        public int ContainerId { get; set; }

        /// <summary>
        /// 货物编号
        /// </summary>
        public int SkuId { get; set; }

        /// <summary>
        /// 包装单位
        /// </summary>
        public int PackId { get; set; }

        /// <summary>
        /// 入库批次
        /// </summary>
        public string BatchNumber { get; set; }

        /// <summary>
        /// 账面数量
        /// </summary>
        public int AccountQty { get; set; }

        /// <summary>
        /// 实盘数量
        /// </summary>
        public int CountedQty { get; set; }

        /// <summary>
        /// 操作人
        /// </summary>
        public int Operator { get; set; }
    }
}