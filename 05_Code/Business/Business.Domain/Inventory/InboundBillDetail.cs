using System.Collections.Generic;

namespace Business.Domain.Inventory
{
    public class InboundBillDetail : DomainObject
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
        /// 存储容器编号
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
        /// 收货数量
        /// </summary>
        public int Qty { get; set; }

        ///// <summary>
        ///// 已收数量
        ///// </summary>
        //public int ReceivedQty { get; set; }

        public List<string> SerialNumbers { get; set; }

        public InboundBillDetail()
        {
            SerialNumbers = new List<string>();

            BatchNumber = string.Empty;
        }
    }
}