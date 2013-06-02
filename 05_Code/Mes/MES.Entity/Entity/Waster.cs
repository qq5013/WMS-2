using System;
using Frame.Utils.Contract;

namespace MES.Entity
{
    /// <summary>
    ///     废品
    /// </summary>
    public class Waster : IBaseEntity
    {
        /// <summary>
        /// </summary>
        public Int32 WasterId { get; set; }

        /// <summary>
        ///     产品信息
        /// </summary>
        public Int32 ProductInfoId { get; set; }

        /// <summary>
        ///     备注
        /// </summary>
        public String Memo { get; set; }

        /// <summary>
        ///     创建者
        /// </summary>
        public Int32 CreaterId { get; set; }

        /// <summary>
        ///     创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        #region IBaseEntity Members

        public int GetEntityId()
        {
            return WasterId;
        }

        #endregion
    }
}