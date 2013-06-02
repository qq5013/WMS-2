namespace Business.Domain.Inventory
{
    public class PickWave : DomainObject
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
        /// 出库计划编号
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
        /// 入库批次号
        /// </summary> 
        public string BatchNumber { get; set; }

        /// <summary> 
        /// 数量
        /// </summary> 
        public int Qty { get; set; }
    }
}