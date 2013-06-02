using System;
using Frame.Utils.Contract;

namespace MES.Entity
{
    /// <summary>
    ///     SKU
    /// </summary>
    public class Sku : IBaseEntity, ICloneable
    {
        public object Clone()
        {
            return MemberwiseClone();
        }
        /// <summary>
        /// </summary>
        public Int32 SkuId { get; set; }

        /// <summary>
        ///     产品
        /// </summary>
        public Int32 ProductId { get; set; }

        /// <summary>
        ///     代码
        /// </summary>
        public String Code { get; set; }

        /// <summary>
        ///     规格
        /// </summary>
        public String Spec { get; set; }

        /// <summary>
        ///     型号
        /// </summary>
        public String Model { get; set; }

        /// <summary>
        ///     颜色
        /// </summary>
        public String Color { get; set; }

        /// <summary>
        /// </summary>
        public Decimal UnitPrice { get; set; }

        #region IBaseEntity Members

        public int GetEntityId()
        {
            return SkuId;
        }

        #endregion
    }
}