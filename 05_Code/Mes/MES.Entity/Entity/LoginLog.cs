using System;
using Frame.Utils.Contract;

namespace MES.Entity
{
    /// <summary>
    ///     登录日志表
    /// </summary>
    public class LoginLog : IBaseEntity
    {
        /// <summary>
        /// </summary>
        public Int32 LoginLogId { get; set; }

        /// <summary>
        ///     登录编号
        /// </summary>
        public Int32 UserId { get; set; }

        /// <summary>
        ///     登录IP
        /// </summary>
        public String IpAddress { get; set; }

        /// <summary>
        ///     登录时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        #region IBaseEntity Members

        public int GetEntityId()
        {
            return LoginLogId;
        }

        #endregion
    }
}