using System;
using Frame.Utils.Contract;
using MES.Enum;

namespace MES.Entity
{
    /// <summary>
    ///     商品
    /// </summary>
    public class Item : IBaseEntity
    {
        /// <summary>
        /// </summary>
        public Int32 ItemId { get; set; }

        /// <summary>
        ///     产品
        /// </summary>
        public Int32 SkuId { get; set; }

        /// <summary>
        ///     跟踪码
        /// </summary>
        public String TraceCode { get; set; }

        /// <summary>
        ///     批号
        /// </summary>
        public String LotNo { get; set; }

        /// <summary>
        ///     状态
        /// </summary>
        public ItemStatus Status { get; set; }

        /// <summary>
        /// </summary>
        public String Barcode { get; set; }

        /// <summary>
        /// </summary>
        public Int32 ProductionOrderId { get; set; }

        #region IBaseEntity Members

        public int GetEntityId()
        {
            return ItemId;
        }

        #endregion
    }
}