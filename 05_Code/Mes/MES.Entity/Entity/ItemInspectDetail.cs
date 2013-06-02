using System;
using Frame.Utils.Contract;

namespace MES.Entity
{
    /// <summary>
    ///     产品检测数据
    /// </summary>
    public class ItemInspectDetail : IBaseEntity
    {
        /// <summary>
        /// </summary>
        public Int32 ItemInspectDetailId { get; set; }

        /// <summary>
        /// </summary>
        public Int32 ItemInspectId { get; set; }

        /// <summary>
        ///     工位
        /// </summary>
        public Int32 ProductInspectId { get; set; }

        /// <summary>
        ///     数值
        /// </summary>
        public Decimal Data { get; set; }

        /// <summary>
        ///     备注
        /// </summary>
        public String Remark { get; set; }

        /// <summary>
        ///     结果
        /// </summary>
        public Boolean Result { get; set; }

        #region IBaseEntity Members

        public int GetEntityId()
        {
            return ItemInspectDetailId;
        }

        #endregion
    }
}