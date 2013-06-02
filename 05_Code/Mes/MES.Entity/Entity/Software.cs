using System;
using Frame.Utils.Contract;

namespace MES.Entity
{
    /// <summary>
    ///     软件版本
    /// </summary>
    public class Software : IBaseEntity
    {
        /// <summary>
        /// </summary>
        public Int32 SoftwareId { get; set; }

        /// <summary>
        /// </summary>
        public String Name { get; set; }

        /// <summary>
        /// </summary>
        public String Code { get; set; }

        #region IBaseEntity Members

        public int GetEntityId()
        {
            return SoftwareId;
        }

        #endregion
    }
}