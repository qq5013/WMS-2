using System;
using Frame.Utils.Contract;

namespace MES.Entity
{
    /// <summary>
    ///     角色
    /// </summary>
    public class Role : IBaseEntity
    {
        /// <summary>
        /// </summary>
        public Int32 RoleId { get; set; }

        /// <summary>
        ///     代码
        /// </summary>
        public String Code { get; set; }

        /// <summary>
        ///     名称
        /// </summary>
        public String Name { get; set; }

        /// <summary>
        ///     描述
        /// </summary>
        public String Description { get; set; }

        #region IBaseEntity Members

        public int GetEntityId()
        {
            return RoleId;
        }

        #endregion
    }
}