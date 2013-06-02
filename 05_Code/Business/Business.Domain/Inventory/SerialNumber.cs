namespace Business.Domain.Inventory
{
    public class SerialNumber : DomainObject
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
        /// 入库计划编号
        /// </summary> 
        public int PlanId { get; set; }

        /// <summary> 
        /// 货物编号
        /// </summary> 
        public int SkuId { get; set; }

        /// <summary> 
        /// 货物包装
        /// </summary> 
        public int PackId { get; set; }

        /// <summary> 
        /// 序列号索引
        /// </summary> 
        public int SnIndex { get; set; }

        /// <summary> 
        /// 创建用户
        /// </summary> 
        public int CreateUser { get; set; }

        /// <summary> 
        /// 创建时间
        /// </summary> 
        public string CreateTime { get; set; }

        /// <summary> 
        /// 序列号
        /// </summary> 
        public string Sn { get; set; }
    }
}