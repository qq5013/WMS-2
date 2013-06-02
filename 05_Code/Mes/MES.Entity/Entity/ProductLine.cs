using System;
using Frame.Utils.Contract;
using MES.Enum;

namespace MES.Entity
{
    /// <summary>
    ///     生产线
    /// </summary>
    public class ProductLine : IBaseEntity, ICloneable
    {
        /// <summary>
        /// </summary>
        public Int32 ProductLineId { get; set; }

        /// <summary>
        ///     产品线号码
        /// </summary>
        public String Code { get; set; }

        /// <summary>
        ///     名称
        /// </summary>
        public String Name { get; set; }

        /// <summary>
        ///     描述
        /// </summary>
        public String Description { get; set; }

        /// <summary>
        ///     是否有效
        /// </summary>
        public ProductLineStatus Status { get; set; }

        /// <summary>
        ///     产品线类型
        /// </summary>
        public Int32 ProductLineType { get; set; }

        #region IBaseEntity Members

        public int GetEntityId()
        {
            return ProductLineId;
        }

        #endregion

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}