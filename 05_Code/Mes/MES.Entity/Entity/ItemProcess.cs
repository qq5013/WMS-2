using System;
using System.Collections.Generic;
using System.ComponentModel;
using Frame.Utils.Contract;

namespace MES.Entity
{
    /// <summary>
    ///     商品工序
    /// </summary>
    public class ItemProcess : IBaseEntity
    {
        private readonly List<ItemProcessStep> _details = new List<ItemProcessStep>();

        /// <summary>
        /// </summary>
        public Int32 ItemProcessId { get; set; }

        /// <summary>
        ///     商品
        /// </summary>
        public Int32 ItemId { get; set; }

        /// <summary>
        ///     工序
        /// </summary>
        public Int32 ProcessId { get; set; }

        /// <summary>
        ///     工位
        /// </summary>
        public Int32 ProductStationId { get; set; }

        /// <summary>
        ///     开始时间
        /// </summary>
        public DateTime BegainTime { get; set; }

        /// <summary>
        ///     结束时间
        /// </summary>
        public DateTime EndTime { get; set; }

        /// <summary>
        ///     操作人
        /// </summary>
        public Int32 OperatorId { get; set; }

        /// <summary>
        /// </summary>
        public Int32 Status { get; set; }

        /// <summary>
        /// </summary>
        public Int32 InspectorId { get; set; }

        [Description("明细")]
        public List<ItemProcessStep> Details
        {
            get { return _details; }
        }

        #region IBaseEntity Members

        public int GetEntityId()
        {
            return ItemProcessId;
        }

        #endregion
    }
}