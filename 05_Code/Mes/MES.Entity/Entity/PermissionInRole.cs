using System;
using Frame.Utils.Contract;

namespace MES.Entity
{
    /// <summary>
    ///     角色权限
    /// </summary>
    public class PermissionInRole : IBaseEntity
    {
        /// <summary>
        /// </summary>
        public Int32 PermissionInRoleId { get; set; }

        /// <summary>
        ///     权限
        /// </summary>
        public Int32 PermissionId { get; set; }

        /// <summary>
        ///     角色
        /// </summary>
        public Int32 RoleId { get; set; }

        #region IBaseEntity Members

        public int GetEntityId()
        {
            return PermissionInRoleId;
        }

        #endregion
    }
}