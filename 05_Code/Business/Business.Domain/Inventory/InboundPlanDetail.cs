using System.Collections.Generic;

namespace Business.Domain.Inventory
{
    public class InboundPlanDetail : DomainObject
    {
        /// <summary>
        /// 自动编号
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 入库计划编号
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
        /// 数量
        /// </summary>
        public int Qty { get; set; }

        /// <summary>
        /// 已收数量
        /// </summary>
        public int ReceivedQty { get; set; }

        //#region additional property

        //public IList<InboundBatch> Batchs { get; set; }

        //#endregion additional property
    }
}