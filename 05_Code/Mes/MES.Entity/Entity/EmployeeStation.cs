using System;
using Frame.Utils.Contract;

namespace MES.Entity
{
    /// <summary>
    ///     员工工位信息
    /// </summary>
    public class EmployeeStation : IBaseEntity
    {
        /// <summary>
        /// </summary>
        public Int32 EmployeeStationId { get; set; }

        /// <summary>
        ///     员工
        /// </summary>
        public Int32 EmployeeId { get; set; }

        /// <summary>
        ///     工位
        /// </summary>
        public Int32 StationId { get; set; }

        #region IBaseEntity Members

        public int GetEntityId()
        {
            return EmployeeStationId;
        }

        #endregion
    }
}