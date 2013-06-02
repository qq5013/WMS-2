using System;
using Frame.Utils.Contract;

namespace MES.Entity
{
    /// <summary>
    ///     单据号
    /// </summary>
    public class BillSequence : IBaseEntity
    {
        /// <summary>
        /// </summary>
        public Int32 BillSequenceId { get; set; }

        /// <summary>
        ///     前缀
        /// </summary>
        public String Prefix { get; set; }

        /// <summary>
        ///     目标
        /// </summary>
        public String Target { get; set; }

        /// <summary>
        ///     日期格式化
        /// </summary>
        public String DateFormate { get; set; }

        /// <summary>
        ///     序号格式化
        /// </summary>
        public String SequenceFormate { get; set; }

        #region IBaseEntity Members

        public int GetEntityId()
        {
            return BillSequenceId;
        }

        #endregion
    }
}