namespace Business.Domain.Inventory
{
    public class SortBillDetail : DomainObject
    {
        /// <summary> 
        /// 自动编号
        /// </summary> 
        public int Id { get; set; }

        /// <summary> 
        /// 分拣单编号
        /// </summary> 
        public int SortBillId { get; set; }

        /// <summary> 
        /// 库存编号
        /// </summary> 
        public int StockId { get; set; }

        /// <summary> 
        /// 容器
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
        /// 数量
        /// </summary> 
        public int Qty { get; set; }

        /// <summary> 
        /// 分拣操作员
        /// </summary> 
        public int SortOperator { get; set; }
    }
}