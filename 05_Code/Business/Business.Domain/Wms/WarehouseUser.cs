namespace Business.Domain.Wms
{
    public class WarehouseUser : DomainObject
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
        /// 用户编号
        /// </summary> 
        public int UserId { get; set; }
    }
}