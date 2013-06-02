using System;
using Frame.Utils.Contract;

namespace MES.Entity
{
    /// <summary>
    ///     用户
    /// </summary>
    public class User : IBaseEntity
    {
        /// <summary>
        /// </summary>
        public Int32 UserId { get; set; }

        /// <summary>
        ///     登录名
        /// </summary>
        public String LogInName { get; set; }

        /// <summary>
        ///     密码
        /// </summary>
        public String Password { get; set; }

        /// <summary>
        ///     创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        ///     最新登录时间
        /// </summary>
        public DateTime LastLoggingTime { get; set; }

        /// <summary>
        ///     是否无效
        /// </summary>
        public Boolean IsDeactivated { get; set; }

        /// <summary>
        ///     用户名
        /// </summary>
        public String Name { get; set; }

        /// <summary>
        ///     描述
        /// </summary>
        public String Description { get; set; }

        public int ProductLineId { get; set; }

        #region IBaseEntity Members

        public int GetEntityId()
        {
            return UserId;
        }

        #endregion
    }
}