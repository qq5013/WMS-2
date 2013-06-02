namespace Business.Domain.Inventory
{
    public class OperationLog : DomainObject
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
        /// 仓库
        /// </summary>
        public int WarehouseId { get; set; }

        /// <summary>
        /// 操作员
        /// </summary>
        public int Operator { get; set; }

        /// <summary>
        /// 操作类型
        /// </summary>
        public int OperationType { get; set; }

        /// <summary>
        /// 关联单据类型
        /// </summary>
        public int LinkBillType { get; set; }

        /// <summary>
        /// 关联单据编号
        /// </summary>
        public int LinkBillId { get; set; }

        /// <summary>
        /// 原库位编号
        /// </summary>
        public int SourceLocationId { get; set; }

        /// <summary>
        /// 目标库位编号
        /// </summary>
        public int TargetLocationId { get; set; }

        /// <summary>
        /// 原容器编号
        /// </summary>
        public int SourceContainerId { get; set; }

        /// <summary>
        /// 目标容器编号
        /// </summary>
        public int TargetContainerId { get; set; }

        /// <summary>
        /// 货物编号
        /// </summary>
        public int SkuId { get; set; }

        /// <summary>
        /// 货物包装
        /// </summary>
        public int PackId { get; set; }

        /// <summary>
        /// 操作数量
        /// </summary>
        public int Qty { get; set; }
    }
}