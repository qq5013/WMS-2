namespace Business.Domain.Inventory
{
    public class InboundBillException : DomainObject
    {
        /// <summary> 
        /// 自动编号
        /// </summary> 
        public int Id { get; set; }

        /// <summary> 
        /// 入库单编号
        /// </summary> 
        public int BillId { get; set; }

        /// <summary> 
        /// 货物编号
        /// </summary> 
        public int SkuId { get; set; }

        /// <summary> 
        /// 包装编号
        /// </summary> 
        public int PackId { get; set; }

        /// <summary> 
        /// 异常数量
        /// </summary> 
        public int Qty { get; set; }

        /// <summary> 
        /// 异常原因
        /// </summary> 
        public int ExceptionReason { get; set; }
    }
}