using System;
using Frame.Utils.Contract;

namespace MES.Entity
{
    /// <summary>
    ///     生产物料追踪
    /// </summary>
    public class MaterielTrace : IBaseEntity, ICloneable
    {
        public object Clone()
        {
            return MemberwiseClone();
        }
        /// <summary>
        /// </summary>
        public Int32 MaterielTraceId { get; set; }

        /// <summary>
        ///     条码
        /// </summary>
        public String TraceCode { get; set; }

        /// <summary>
        ///     数量
        /// </summary>
        public Int32 Quantity { get; set; }

        #region IBaseEntity Members

        public int GetEntityId()
        {
            return MaterielTraceId;
        }

        #endregion
    }
}