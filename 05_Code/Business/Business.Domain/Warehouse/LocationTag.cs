namespace Business.Domain.Warehouse
{
    public class LocationTag : DomainObject
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
        /// 库位编号
        /// </summary> 
        public int LocationId { get; set; }

        /// <summary> 
        /// 标签编号
        /// </summary> 
        public int TagId { get; set; }
    }
}