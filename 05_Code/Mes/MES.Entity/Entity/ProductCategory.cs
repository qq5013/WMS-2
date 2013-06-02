using System;
using Frame.Utils.Contract;

namespace MES.Entity
{
    /// <summary>
    ///     产品分类
    /// </summary>
    public class ProductCategory : IBaseEntity
    {
        /// <summary>
        /// </summary>
        public Int32 ProductCategoryId { get; set; }

        /// <summary>
        ///     名称
        /// </summary>
        public String Name { get; set; }

        /// <summary>
        ///     代码
        /// </summary>
        public String Code { get; set; }

        /// <summary>
        ///     父级分类
        /// </summary>
        public Int32 ParentId { get; set; }

        /// <summary>
        ///     描述
        /// </summary>
        public String Description { get; set; }

        #region IBaseEntity Members

        public int GetEntityId()
        {
            return ProductCategoryId;
        }

        #endregion
    }
}