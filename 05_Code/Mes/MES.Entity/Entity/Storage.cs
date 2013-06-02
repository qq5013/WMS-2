using System;
using Frame.Utils.Contract;
using MES.Enum;

namespace MES.Entity
{
    /// <summary>
    ///     库存
    /// </summary>
    public class Storage : IBaseEntity
    {
        /// <summary>
        /// </summary>
        public Int32 StorageId { get; set; }

        /// <summary>
        ///     Sku
        /// </summary>
        public Int32 SkuId { get; set; }

        /// <summary>
        ///     代码
        /// </summary>
        public String Code { get; set; }

        /// <summary>
        ///     数量
        /// </summary>
        public Int32 Quantity { get; set; }

        /// <summary>
        ///     批号
        /// </summary>
        public String LotNo { get; set; }

        /// <summary>
        ///     库位
        /// </summary>
        public Int32 LocationId { get; set; }

        /// <summary>
        ///     追踪方式
        /// </summary>
        public TraceType TraceType { get; set; }

        #region IBaseEntity Members

        public int GetEntityId()
        {
            return StorageId;
        }

        #endregion
    }
}