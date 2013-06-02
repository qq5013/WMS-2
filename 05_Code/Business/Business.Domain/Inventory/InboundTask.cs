namespace Business.Domain.Inventory
{
    public class InboundTask : DomainObject
    {
        /// <summary> 
        /// 任务编号
        /// </summary> 
        public int TaskId { get; set; }

        /// <summary> 
        /// 任务单号
        /// </summary> 
        public string TaskNumber { get; set; }

        /// <summary> 
        /// 入库计划编号
        /// </summary> 
        public int PlanId { get; set; }

        /// <summary> 
        /// 收货仓库
        /// </summary> 
        public int WarehouseId { get; set; }

        /// <summary> 
        /// 送货人
        /// </summary> 
        public string DeliveryMan { get; set; }

        /// <summary> 
        /// 送货车辆
        /// </summary> 
        public string Vehicle { get; set; }

        /// <summary> 
        /// 到仓时间
        /// </summary> 
        public string ArrivalTime { get; set; }

        /// <summary> 
        /// 操作员
        /// </summary> 
        public int Operator { get; set; }

        /// <summary> 
        /// 单据状态
        /// </summary> 
        public int BillStatus { get; set; }

        /// <summary> 
        /// 描述
        /// </summary> 
        public string Remark { get; set; }

        /// <summary> 
        /// 创建用户
        /// </summary> 
        public int CreateUser { get; set; }

        /// <summary> 
        /// 创建时间
        /// </summary> 
        public string CreateTime { get; set; }

        /// <summary> 
        /// 编辑用户
        /// </summary> 
        public int? EditUser { get; set; }

        /// <summary> 
        /// 编辑时间
        /// </summary> 
        public string EditTime { get; set; }

    }
}
