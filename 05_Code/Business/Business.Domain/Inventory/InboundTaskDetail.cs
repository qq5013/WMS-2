namespace Business.Domain.Inventory
{
    public class InboundTaskDetail : DomainObject
    {
        /// <summary> 
        /// 自动编号
        /// </summary> 
        public int Id { get; set; }

        /// <summary> 
        /// 入库单编号
        /// </summary> 
        public int TaskId { get; set; }

        /// <summary> 
        /// 货物编号
        /// </summary> 
        public int SkuId { get; set; }

        /// <summary> 
        /// 包装编号
        /// </summary> 
        public int PackId { get; set; }

        /// <summary> 
        /// 是否批次管理
        /// </summary> 
        public bool IsBatchManagement { get; set; }

        /// <summary> 
        /// 实收数量
        /// </summary> 
        public int Qty { get; set; }
    }
}
