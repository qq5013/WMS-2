using System;
using Frame.Utils.Contract;

namespace MES.Entity
{
    /// <summary>
    ///     单据号明细
    /// </summary>
    public class BillSequenceDetail : IBaseEntity
    {
        /// <summary>
        /// </summary>
        public Int32 BillSequenceDetailId { get; set; }

        /// <summary>
        ///     单据号
        /// </summary>
        public Int32 BillSequenceId { get; set; }

        /// <summary>
        ///     代码
        /// </summary>
        public String Code { get; set; }

        /// <summary>
        ///     序号
        /// </summary>
        public Int32 Sequence { get; set; }

        #region IBaseEntity Members

        public int GetEntityId()
        {
            return BillSequenceDetailId;
        }

        #endregion
    }
}