namespace Business.Domain.Inventory
{
    public class StockLog : DomainObject
    {
        /// <summary>
        /// 自动编号
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 库存日志类型
        /// </summary>
        public int LogType { get; set; }

        /// <summary>
        /// 日志时间
        /// </summary>
        public string LogTime { get; set; }

        /// <summary>
        /// 关联单据类型
        /// </summary>
        public int LinkBillType { get; set; }

        /// <summary>
        /// 关联单据编号
        /// </summary>
        public int LinkBillId { get; set; }

        public string LinkBillNumber { get; set; }

        /// <summary>
        /// 仓库编号
        /// </summary>
        public int WarehouseId { get; set; }

        /// <summary>
        /// 库位编号
        /// </summary>
        public int LocationId { get; set; }

        /// <summary>
        /// 容器编号
        /// </summary>
        public int ContainerId { get; set; }

        /// <summary>
        /// 货物编号
        /// </summary>
        public int SkuId { get; set; }

        /// <summary>
        /// 包装编号
        /// </summary>
        public int PackId { get; set; }

        /// <summary>
        /// 入库批次号
        /// </summary>
        public string BatchNumber { get; set; }

        /// <summary>
        /// 变更前数量
        /// </summary>
        public int BeforeQty { get; set; }

        /// <summary>
        /// 入库数量
        /// </summary>
        public int InboundQty { get; set; }

        /// <summary>
        /// 出库数量
        /// </summary>
        public int OutboundQty { get; set; }

        /// <summary>
        /// 变更后数量
        /// </summary>
        public int AfterQty { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string InboundBillNumber { get; set; }
    }
}