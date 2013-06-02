using System;
using Frame.Utils.Contract;
using MES.Enum;

namespace MES.Entity
{
    /// <summary>
    ///     质检
    /// </summary>
    public class ProductInspect : IBaseEntity
    {
        /// <summary>
        /// </summary>
        public Int32 ProductInspectId { get; set; }

        /// <summary>
        ///     产品
        /// </summary>
        public Int32 ProcessId { get; set; }

        /// <summary>
        ///     项目
        /// </summary>
        public String Name { get; set; }

        /// <summary>
        ///     类型
        /// </summary>
        public ProductInspectType Type { get; set; }

        /// <summary>
        ///     单位
        /// </summary>
        public String UnitName { get; set; }

        /// <summary>
        ///     内容
        /// </summary>
        public String Content { get; set; }

        /// <summary>
        ///     精度
        /// </summary>
        public Int32 Precision { get; set; }

        /// <summary>
        ///     最小值
        /// </summary>
        public Decimal MinData { get; set; }

        /// <summary>
        ///     最大值
        /// </summary>
        public Decimal MaxData { get; set; }

        #region IBaseEntity Members

        public int GetEntityId()
        {
            return ProductInspectId;
        }

        #endregion
    }
}