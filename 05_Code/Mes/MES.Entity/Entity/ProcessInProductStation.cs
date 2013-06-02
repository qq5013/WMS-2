using System;
using Frame.Utils.Contract;

namespace MES.Entity
{
    /// <summary>
    ///     工序工位关系
    /// </summary>
    public class ProcessInProductStation : IBaseEntity
    {
        /// <summary>
        /// </summary>
        public Int32 ProcessInProductStationId { get; set; }

        /// <summary>
        ///     工序
        /// </summary>
        public Int32 ProcessId { get; set; }

        /// <summary>
        ///     工位
        /// </summary>
        public Int32 ProductStationId { get; set; }

        #region IBaseEntity Members

        public int GetEntityId()
        {
            return ProcessInProductStationId;
        }

        #endregion
    }
}