using System;
using System.Collections.Generic;
using System.ComponentModel;
using Frame.Utils.Contract;
using MES.Enum;

namespace MES.Entity
{
    /// <summary>
    ///     工步
    /// </summary>
    public class ItemProcessStep : IBaseEntity
    {
        private readonly List<ItemProcessStepDetail> _details = new List<ItemProcessStepDetail>();

        /// <summary>
        /// </summary>
        public Int32 ItemProcessStepId { get; set; }

        /// <summary>
        /// 工序
        /// </summary>
        public Int32 ItemProcessId { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public ItemProcessStepStatus Status { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Int32 ProcessStepId { get; set; }

        [Description("明细")]
        public List<ItemProcessStepDetail> Details
        {
            get { return _details; }
        }

        #region IBaseEntity Members

        public int GetEntityId()
        {
            return ItemProcessStepId;
        }

        #endregion
    }
}