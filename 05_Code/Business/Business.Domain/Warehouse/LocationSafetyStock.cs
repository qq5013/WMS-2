namespace Business.Domain.Warehouse
{
    public class LocationSafetyStock : DomainObject
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
        /// 拣货库位编号
        /// </summary> 
        public int LocationId { get; set; }

        /// <summary> 
        /// 货物编号
        /// </summary> 
        public int SkuId { get; set; }

        /// <summary> 
        /// 包装编号
        /// </summary> 
        public int PackId { get; set; }

        /// <summary> 
        /// 最小库存量
        /// </summary> 
        public int MinQty { get; set; }

        /// <summary> 
        /// 最大库存量
        /// </summary> 
        public int MaxQty { get; set; }
    }
}