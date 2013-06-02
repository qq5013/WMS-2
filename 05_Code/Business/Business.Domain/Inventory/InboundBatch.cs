namespace Business.Domain.Inventory
{
    public class InboundBatch : DomainObject
    {
        /// <summary> 
        /// 自动编号
        /// </summary> 
        public int Id { get; set; }

        /// <summary> 
        /// 收货仓库
        /// </summary> 
        public int WarehouseId { get; set; }

        /// <summary> 
        /// 入库计划号
        /// </summary> 
        public string PlanNumber { get; set; }

        /// <summary> 
        /// 入库单号
        /// </summary> 
        public string BillNumber { get; set; }

        /// <summary> 
        /// 入库批次号
        /// </summary> 
        public string BatchNumber { get; set; }

        /// <summary> 
        /// 入库日期
        /// </summary> 
        public string InboundDate { get; set; }

        /// <summary> 
        /// 货物编号
        /// </summary> 
        public int SkuId { get; set; }

        /// <summary> 
        /// 批次数量
        /// </summary> 
        public int Qty { get; set; }

        /// <summary> 
        /// 生产日期
        /// </summary> 
        public string ProductionDate { get; set; }

        /// <summary> 
        /// 过期日期
        /// </summary> 
        public string ExpiringDate { get; set; }

        /// <summary> 
        /// 产品批号
        /// </summary> 
        public string ProductionBatch { get; set; }

        /// <summary> 
        /// 产地
        /// </summary> 
        public string ManufacturingOrigin { get; set; }

        /// <summary> 
        /// 扩展属性1
        /// </summary> 
        public string PropertyValue1 { get; set; }

        /// <summary> 
        /// 扩展属性2
        /// </summary> 
        public string PropertyValue2 { get; set; }

        /// <summary> 
        /// 扩展属性3
        /// </summary> 
        public string PropertyValue3 { get; set; }

        /// <summary> 
        /// 扩展属性4
        /// </summary> 
        public string PropertyValue4 { get; set; }

        /// <summary> 
        /// 扩展属性5
        /// </summary> 
        public string PropertyValue5 { get; set; }

        /// <summary> 
        /// 扩展属性6
        /// </summary> 
        public string PropertyValue6 { get; set; }

        /// <summary> 
        /// 创建用户
        /// </summary> 
        public int CreateUser { get; set; }

        /// <summary> 
        /// 创建时间
        /// </summary> 
        public string CreateTime { get; set; }
    }
}