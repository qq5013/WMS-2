using System;
using Frame.Utils.Contract;
using MES.Enum;

namespace MES.Entity
{
    /// <summary>
    ///     产品
    /// </summary>
    public class Product : IBaseEntity, ICloneable
    {
        public object Clone()
        {
            return MemberwiseClone();
        }
        /// <summary>
        /// </summary>
        public Int32 ProductId { get; set; }

        /// <summary>
        ///     名称
        /// </summary>
        public String Name { get; set; }

        /// <summary>
        ///     代码
        /// </summary>
        public String Code { get; set; }

        /// <summary>
        ///     版本
        /// </summary>
        public String Version { get; set; }

        /// <summary>
        ///     状态
        /// </summary>
        public ProductStatus Status { get; set; }

        /// <summary>
        ///     创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        ///     产品分类
        /// </summary>
        public Int32 ProductCategoryId { get; set; }

        /// <summary>
        ///     是否物料
        /// </summary>
        public Boolean IsMateriel { get; set; }

        /// <summary>
        ///     追踪类型
        /// </summary>
        public TraceType TraceType { get; set; }

        #region IBaseEntity Members

        public int GetEntityId()
        {
            return ProductId;
        }

        #endregion
    }
}