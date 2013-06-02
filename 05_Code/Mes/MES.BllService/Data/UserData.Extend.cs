/*----------------------------------------------------------------
// Copyright (C) 2010 有限公司
// 版权所有。 
//
// 文件名：         UserData.Extend.cs
// 文件功能描述：   用户数据
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
using System.Linq;
using Frame.Utils.RelaAndCondition;
using Frame.Utils.Service;
using MES.Entity;

namespace MES.BllService.Data
{
    /// <summary>
    ///     用户数据
    /// </summary>
    public class UserData : BaseData<User>
    {
        private static UserData _instance;

        private static List<User> _all;

        /// <summary>
        ///     单例
        /// </summary>
        public static UserData Instance
        {
            get { return _instance ?? (_instance = new UserData()); }
        }

        /// <summary>
        ///     获取所有用户
        /// </summary>
        /// <returns></returns>
        public List<User> Select(QueryInfo queryInfo)
        {
            if (queryInfo == null)
            {
                return SelectActivated();
            }
            queryInfo.Condition &= new EntityColumn("IsDeactivated") == false;
            return Service.GetAll(queryInfo);
        }

        /// <summary>
        ///     获取所有有效用户
        /// </summary>
        /// <returns></returns>
        public List<User> SelectActivated()
        {
            return _all ?? (_all = Service.FindAll(c => c.IsDeactivated == false, null));
        }

        /// <summary>
        ///     获取用户数量
        /// </summary>
        /// <returns></returns>
        public int GetCount()
        {
            return Service.GetCount(new QueryInfo());
        }

        /// <summary>
        ///     更新
        /// </summary>
        /// <param name="user"></param>
        public void Update(User user)
        {
            User item = Service.GetById(user.GetEntityId());

            item.LogInName = user.LogInName;
            item.Name = user.Name;
            if (!string.IsNullOrEmpty(user.Password))
                item.Password = user.Password;
            item.Description = user.Description;

            Service.Save(item);
            _all = null;
        }

        /// <summary>
        ///     新增
        /// </summary>
        /// <param name="user"></param>
        public void Insert(User user)
        {
            try
            {
                user.CreateTime = DateTime.Now;
                user.LastLoggingTime = new DateTime(1900, 1, 1);

                Service.Save(user);
                _all = null;
            }
            catch (Exception ex)
            {
                throw CustomError(ex);
            }
        }

        /// <summary>
        ///     删除（并非实际删除，只是将用户设置为无效）
        /// </summary>
        /// <param name="user"></param>
        public void Delete(User user)
        {
            User item = Service.GetById(user.GetEntityId());
            item.IsDeactivated = true;
            Service.Save(item);
            _all = null;
        }

        /// <summary>
        ///     获取用户对应的所有角色名字，以", "分隔
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public string GetRoleName(object userId)
        {
            int id = Convert.ToInt32(userId);
            List<UserInRole> userInRoles = ServiceBloker.GetService<UserInRole>().FindAll(c => c.UserId == id, null);
            if (userInRoles.Count == 0)
                return string.Empty;

            List<int> roleIds = userInRoles.Select(c => c.RoleId).ToList();
            List<Role> roles = ServiceBloker.GetService<Role>().FindAll(c => roleIds.Contains(c.RoleId), null);
            string[] strings = roles.Select(c => c.Name).ToArray();
            return string.Join(", ", strings);
        }

        /// <summary>
        ///     用户角色绑定
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="roles"></param>
        public void BindRole(int userId, List<int> roles)
        {
            ServiceBloker.GetService<UserInRole>().DeleteByCondition(c => c.UserId == userId);
            foreach (int role in roles)
            {
                ServiceBloker.GetService<UserInRole>().Save(new UserInRole {UserId = userId, RoleId = role});
            }
        }

        /// <summary>
        ///     获取用户对应的所有角色Id，以", "分隔
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public string GetRoles(int userId)
        {
            int id = Convert.ToInt32(userId);
            List<UserInRole> userInRoles = ServiceBloker.GetService<UserInRole>().FindAll(c => c.UserId == id, null);
            if (userInRoles.Count == 0)
                return string.Empty;

            List<int> roleIds = userInRoles.Select(c => c.RoleId).ToList();
            List<Role> roles = ServiceBloker.GetService<Role>().FindAll(c => roleIds.Contains(c.RoleId), null);
            string[] strings = roles.Select(c => c.RoleId.ToString()).ToArray();
            return string.Join(",", strings);
        }
    }
}