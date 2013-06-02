/*----------------------------------------------------------------
// Copyright (C) 2010 有限公司
// 版权所有。 
//
// 文件名：         UserInfo.cs
// 文件功能描述：   用户信息
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
using System.Collections.Generic;
using MES.Entity;

namespace MES.BllService.Data
{
    /// <summary>
    ///     用户信息
    /// </summary>
    public class UserInfo
    {
        private readonly List<Permission> _authorities = new List<Permission>();
        private readonly List<Role> _roles = new List<Role>();
        private User _user;

        /// <summary>
        ///     名称
        /// </summary>
        public string Name
        {
            get { return User.Name; }
        }

        /// <summary>
        ///     用户Id
        /// </summary>
        public int UserId
        {
            get { return User.UserId; }
        }

        /// <summary>
        ///     登录名
        /// </summary>
        public string LogInName
        {
            get { return User.LogInName; }
        }

        /// <summary>
        ///     密码
        /// </summary>
        public string Password
        {
            get { return User.Password; }
        }

        /// <summary>
        ///     创建时间
        /// </summary>
        public DateTime CreateTime
        {
            get { return User.CreateTime; }
        }

        /// <summary>
        ///     上次登录时间
        /// </summary>
        public DateTime LastLoggingTime
        {
            get { return User.LastLoggingTime; }
        }

        /// <summary>
        ///     是否无效
        /// </summary>
        public bool IsDeactivated
        {
            get { return User.IsDeactivated; }
        }

        /// <summary>
        ///     描述
        /// </summary>
        public string Description
        {
            get { return User.Description; }
        }

        /// <summary>
        ///     用户
        /// </summary>
        public User User
        {
            get { return _user ?? new User(); }
            set { _user = value; }
        }

        /// <summary>
        ///     角色
        /// </summary>
        public List<Role> Roles
        {
            get { return _roles; }
        }

        /// <summary>
        ///     权限
        /// </summary>
        public List<Permission> Authorities
        {
            get { return _authorities; }
        }
    }
}