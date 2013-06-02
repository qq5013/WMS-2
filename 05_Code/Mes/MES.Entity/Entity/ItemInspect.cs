using System;
using Frame.Utils.Contract;

namespace MES.Entity
{
    /// <summary>
    ///     质检调试
    /// </summary>
    public class ItemInspect : IBaseEntity
    {
        /// <summary>
        /// </summary>
        public Int32 ItemInspectId { get; set; }

        /// <summary>
        ///     产品
        /// </summary>
        public Int32 ItemId { get; set; }

        /// <summary>
        ///     工序
        /// </summary>
        public Int32 ProcessId { get; set; }

        /// <summary>
        ///     代码
        /// </summary>
        public String Code { get; set; }

        /// <summary>
        ///     生产工单
        /// </summary>
        public String ProductionOrderCode { get; set; }

        /// <summary>
        ///     客户
        /// </summary>
        public Int32 CustomerId { get; set; }

        /// <summary>
        ///     设备号
        /// </summary>
        public String MachineNo { get; set; }

        /// <summary>
        ///     用途
        /// </summary>
        public String UseWay { get; set; }

        /// <summary>
        ///     设备规范
        /// </summary>
        public String Standard { get; set; }

        /// <summary>
        ///     结束时间
        /// </summary>
        public DateTime FinishTime { get; set; }

        /// <summary>
        ///     调试员
        /// </summary>
        public Int32 DebugMemberId { get; set; }

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
        public Int32 SoftwareId { get; set; }

        /// <summary>
        /// </summary>
        public Boolean Complated { get; set; }

        public string TraceCode { get; set; }

        public string SpecModel { get; set; }

        #region IBaseEntity Members

        public int GetEntityId()
        {
            return ItemInspectId;
        }

        #endregion
    }
}