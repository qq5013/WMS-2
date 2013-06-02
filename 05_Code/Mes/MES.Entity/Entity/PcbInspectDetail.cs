using System;
using Frame.Utils.Contract;

namespace MES.Entity
{
    /// <summary>
    ///     检测数据
    /// </summary>
    public class PcbInspectDetail : IBaseEntity
    {
        /// <summary>
        /// </summary>
        public Int32 PcbInspectDetailId { get; set; }

        /// <summary>
        ///     工位
        /// </summary>
        public Int32 PcbInspectId { get; set; }

        /// <summary>
        /// </summary>
        public Int32 PcbInspectConfigId { get; set; }

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
            return PcbInspectDetailId;
        }

        #endregion
    }
}