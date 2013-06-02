using System;
using Frame.Utils.Contract;

namespace MES.Entity
{
    /// <summary>
    ///     质检调试
    /// </summary>
    public class PcbInspect : IBaseEntity
    {
        /// <summary>
        /// </summary>
        public Int32 PcbInspectId { get; set; }

        /// <summary>
        ///     产品
        /// </summary>
        public Int32 SkuId { get; set; }

        /// <summary>
        ///     代码
        /// </summary>
        public String TraceCode { get; set; }

        /// <summary>
        ///     生产工单
        /// </summary>
        public String OrderCode { get; set; }

        /// <summary>
        ///     客户
        /// </summary>
        public Int32 VendorId { get; set; }

        /// <summary>
        ///     用途
        /// </summary>
        public String UseWay { get; set; }

        /// <summary>
        ///     结束时间
        /// </summary>
        public DateTime InspectTime { get; set; }

        /// <summary>
        ///     调试员
        /// </summary>
        public Int32 InspecterId { get; set; }

        /// <summary>
        ///     确认人
        /// </summary>
        public Int32 ConfirmerId { get; set; }

        /// <summary>
        ///     调试结果
        /// </summary>
        public String Result { get; set; }

        /// <summary>
        ///     备注
        /// </summary>
        public String Remark { get; set; }

        /// <summary>
        /// </summary>
        public String RelaOrderCode { get; set; }

        /// <summary>
        /// </summary>
        public Int32 SoftwareId { get; set; }

        /// <summary>
        /// </summary>
        public Boolean Complated { get; set; }

        #region IBaseEntity Members

        public int GetEntityId()
        {
            return PcbInspectId;
        }

        #endregion
    }
}