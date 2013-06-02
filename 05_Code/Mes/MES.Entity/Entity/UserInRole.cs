/*----------------------------------------------------------------
// Copyright (C) 2010 有限公司
// 版权所有。 
//
// 文件名：         
// 文件功能描述：   
//
// 
// 创建标识：
//
// 修改标识：
// 修改描述：
//
// 修改标识：
// 修改描述：
----------------------------------------------------------------*/

using System;
using Frame.Utils.Contract;

namespace MES.Entity
{
    /// <summary>
    ///     用户角色
    /// </summary>
    public class UserInRole : IBaseEntity
    {
        /// <summary>
        /// </summary>
        public Int32 UserInRoleId { get; set; }

        /// <summary>
        ///     用户
        /// </summary>
        public Int32 UserId { get; set; }

        /// <summary>
        ///     角色
        /// </summary>
        public Int32 RoleId { get; set; }

        #region IBaseEntity Members

        public int GetEntityId()
        {
            return UserInRoleId;
        }

        #endregion
    }
}