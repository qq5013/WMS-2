namespace Business.Domain.Inventory
{
    public class TransferBillDetail : DomainObject
    {
        /// <summary>
        /// 自动编号
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 移库单编号
        /// </summary>
        public int BillId { get; set; }

        /// <summary>
        /// 库存编号
        /// </summary>
        public int StockId { get; set; }

        /// <summary>
        /// 货物编号
        /// </summary>
        public int SkuId { get; set; }

        /// <summary>
        /// 包装单位
        /// </summary>
        public int PackId { get; set; }

        /// <summary>
        /// 入库批次
        /// </summary>
        public string BatchNumber { get; set; }

        /// <summary>
        /// 原库位
        /// </summary>
        public int SourceLocationId { get; set; }

        /// <summary>
        /// 目标库位
        /// </summary>
        public int TargetLocationId { get; set; }

        /// <summary>
        /// 原容器
        /// </summary>
        public int SourceContainerId { get; set; }

        /// <summary>
        /// 目标容器
        /// </summary>
        public int TargetContainerId { get; set; }

        /// <summary>
        /// 计划移库数量
        /// </summary>
        public int PlanQty { get; set; }

        /// <summary>
        /// 移库数量
        /// </summary>
        public int TransferedQty { get; set; }

        /// <summary>
        /// 是否移动容器
        /// </summary>
        public bool IsTransferContainer { get; set; }
    }
}