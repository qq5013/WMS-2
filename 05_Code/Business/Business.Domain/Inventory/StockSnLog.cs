namespace Business.Domain.Inventory
{
    public class StockSnLog : DomainObject
    {
        /// <summary> 
        /// 自动编号
        /// </summary> 
        public int Id { get; set; }

        /// <summary> 
        /// 仓库编号
        /// </summary> 
        public int WarehouseId { get; set; }

        /// <summary> 
        /// 库存日志编号
        /// </summary> 
        public int StockLogId { get; set; }

        /// <summary> 
        /// 货物编号
        /// </summary> 
        public int SkuId { get; set; }

        /// <summary> 
        /// 包装编号
        /// </summary> 
        public int PackId { get; set; }

        /// <summary> 
        /// 序列号
        /// </summary> 
        public string Sn { get; set; }
    }
}