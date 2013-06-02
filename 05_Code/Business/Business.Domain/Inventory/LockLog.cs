namespace Business.Domain.Inventory
{
    public class LockLog : DomainObject
    {
        /// <summary>
        /// 自动编号
        /// </summary>
        public int LogId { get; set; }

        /// <summary>
        /// 日志时间
        /// </summary>
        public string LogTime { get; set; }

        /// <summary>
        /// 锁定日志类型
        /// </summary>
        public int LockLogType { get; set; }

        /// <summary>
        /// 锁定编号
        /// </summary>
        public int LockId { get; set; }

        /// <summary>
        /// 锁定时间
        /// </summary>
        public string LockTime { get; set; }

        /// <summary>
        /// 锁定类型
        /// </summary>
        public int LockType { get; set; }

        /// <summary>
        /// 锁定模式
        /// </summary>
        public int LockMode { get; set; }

        /// <summary>
        /// 锁定原因
        /// </summary>
        public int LockReason { get; set; }

        /// <summary>
        /// 锁定操作员
        /// </summary>
        public int Operator { get; set; }

        /// <summary>
        /// 锁定对象
        /// </summary>
        public int LockObject { get; set; }

        /// <summary>
        /// 仓库编号
        /// </summary>
        public int WarehouseId { get; set; }

        /// <summary>
        /// 库位
        /// </summary>
        public int LocationId { get; set; }

        /// <summary>
        /// 托盘
        /// </summary>
        public int ContainerId { get; set; }

        /// <summary>
        /// 货物编号
        /// </summary>
        public int SkuId { get; set; }

        /// <summary>
        /// 包装
        /// </summary>
        public int PackId { get; set; }

        /// <summary>
        /// 入库批次
        /// </summary>
        public string BatchNumber { get; set; }

        /// <summary>
        /// 锁定数量
        /// </summary>
        public int Qty { get; set; }

        /// <summary>
        /// 备注
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
        public int EditUser { get; set; }

        /// <summary>
        /// 编辑时间
        /// </summary>
        public string EditTime { get; set; }
    }
}