using System;
using Frame.Utils.Contract;
using MES.Enum;

namespace MES.Entity
{
    /// <summary>
    ///     权限
    /// </summary>
    public class Permission : IBaseEntity
    {
        /// <summary>
        /// </summary>
        public Int32 PermissionId { get; set; }

        /// <summary>
        ///     上级权限
        /// </summary>
        public Int32 ParentId { get; set; }

        /// <summary>
        ///     代码
        /// </summary>
        public String Code { get; set; }

        /// <summary>
        ///     是否无效
        /// </summary>
        public Boolean IsDeactivated { get; set; }

        /// <summary>
        ///     名称
        /// </summary>
        public String Name { get; set; }

        /// <summary>
        ///     描述
        /// </summary>
        public String Description { get; set; }

        /// <summary>
        ///     类型
        /// </summary>
        public PermissionType Type { get; set; }

        /// <summary>
        ///     创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        ///     更新时间
        /// </summary>
        public DateTime UpdateTime { get; set; }

        /// <summary>
        ///     条件
        /// </summary>
        public String Condition { get; set; }

        #region IBaseEntity Members

        public int GetEntityId()
        {
            return PermissionId;
        }

        #endregion
    }
}