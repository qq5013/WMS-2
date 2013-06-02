namespace Business.Domain.Warehouse
{
    public class AreaGroup : DomainObject
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
        /// 库区编号
        /// </summary> 
        public int AreaId { get; set; }

        /// <summary> 
        /// 操作员组编号
        /// </summary> 
        public int GroupId { get; set; }
    }
}