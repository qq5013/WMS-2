using System;
using Frame.Utils.Contract;
using MES.Enum;

namespace MES.Entity
{
    /// <summary>
    ///     商品工步
    /// </summary>
    public class ItemProcessStepDetail : IBaseEntity
    {
        /// <summary>
        /// </summary>
        public Int32 ItemProcessStepDetailId { get; set; }

        /// <summary>
        ///     商品工序
        /// </summary>
        public Int32 ItemProcessStepId { get; set; }

        /// <summary>
        ///     SKU
        /// </summary>
        public Int32 SkuId { get; set; }

        /// <summary>
        ///     追踪码
        /// </summary>
        public String TraceCode { get; set; }

        /// <summary>
        ///     创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// </summary>
        public TraceType TraceType { get; set; }

        /// <summary>
        /// </summary>
        public ItemProcessStepDetailStatus Status { get; set; }

        #region IBaseEntity Members

        public int GetEntityId()
        {
            return ItemProcessStepDetailId;
        }

        #endregion
    }
}