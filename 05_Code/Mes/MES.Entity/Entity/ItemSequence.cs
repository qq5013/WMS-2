using System;
using Frame.Utils.Contract;

namespace MES.Entity
{
    /// <summary>
    ///     商品序号
    /// </summary>
    public class ItemSequence : IBaseEntity
    {
        /// <summary>
        /// </summary>
        public Int32 ItemSequenceId { get; set; }

        /// <summary>
        ///     当前号
        /// </summary>
        public Int32 CurrentNumber { get; set; }

        /// <summary>
        ///     步长
        /// </summary>
        public Int32 Step { get; set; }

        /// <summary>
        ///     代码
        /// </summary>
        public String Code { get; set; }

        #region IBaseEntity Members

        public int GetEntityId()
        {
            return ItemSequenceId;
        }

        #endregion
    }
}