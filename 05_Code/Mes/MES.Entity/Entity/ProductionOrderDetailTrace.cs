using System;
using Frame.Utils.Contract;

namespace MES.Entity
{
    /// <summary>
    ///     生产工单明细追踪
    /// </summary>
    public class ProductionOrderDetailTrace : IBaseEntity, ICloneable
    {
        public object Clone()
        {
            return MemberwiseClone();
        }
        /// <summary>
        /// </summary>
        public Int32 ProductionOrderDetailTraceId { get; set; }

        /// <summary>
        ///     生产工单明细
        /// </summary>
        public Int32 ProductionOrderDetaiId { get; set; }

        /// <summary>
        ///     代码
        /// </summary>
        public String Code { get; set; }

        #region IBaseEntity Members

        public int GetEntityId()
        {
            return ProductionOrderDetailTraceId;
        }

        #endregion
    }
}