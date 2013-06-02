namespace Business.Domain.Inventory
{
    public class PackageDetail : DomainObject
    {
        /// <summary> 
        /// 自动编号
        /// </summary> 
        public int Id { get; set; }

        /// <summary> 
        /// 包裹编号
        /// </summary> 
        public int PackageId { get; set; }

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
    }
}