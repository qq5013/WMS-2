namespace Business.Domain.Inventory
{
    public class PickBillDetail : DomainObject
    {
        /// <summary>
        /// 自动编号
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 拣货单编号
        /// </summary>
        public int PickBillId { get; set; }

        /// <summary>
        /// 库存编号
        /// </summary>
        public int StockId { get; set; }

        /// <summary>
        /// 货物编号
        /// </summary>
        public int SkuId { get; set; }

        /// <summary>
        /// 计划货物包装
        /// </summary>
        public int PackId { get; set; }

        /// <summary>
        /// 计划入库批次号
        /// </summary>
        public string PlanBatchNumber { get; set; }

        /// <summary>
        /// 库位编号
        /// </summary>
        public int PlanLocationId { get; set; }

        /// <summary>
        /// 计划容器
        /// </summary>
        public int PlanContainerId { get; set; }

        /// <summary>
        /// 计划数量
        /// </summary>
        public int PlanQty { get; set; }

        /// <summary>
        /// 拣货入库批次号
        /// </summary>
        public string PickBatchNumber { get; set; }

        /// <summary>
        /// 拣货库位编号
        /// </summary>
        public int PickLocationId { get; set; }

        /// <summary>
        /// 拣货容器编号
        /// </summary>
        public int PickContainerId { get; set; }

        /// <summary>
        /// 拣货数量
        /// </summary>
        public int PickQty { get; set; }

        /// <summary>
        /// 拣货操作员
        /// </summary>
        public int PickOperator { get; set; }
    }
}