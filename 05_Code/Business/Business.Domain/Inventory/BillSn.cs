namespace Business.Domain.Inventory
{
    public class BillSn : DomainObject
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
        /// 单据类型
        /// </summary> 
        public int BillType { get; set; }

        /// <summary> 
        /// 单据编号
        /// </summary> 
        public int BillId { get; set; }

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
        /// 序列号
        /// </summary> 
        public string Sn { get; set; }
    }
}