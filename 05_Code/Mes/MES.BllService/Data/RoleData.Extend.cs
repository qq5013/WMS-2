/*----------------------------------------------------------------
// Copyright (C) 2010 有限公司
// 版权所有。 
//
// 文件名：         RoleData.Extend.cs
// 文件功能描述：   角色数据扩展
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
    ///     角色数据扩展
    /// </summary>
    public class RoleData
    {
        private static RoleData _instance;

        private static readonly IEntityService<Role> Service = ServiceBloker.GetService<Role>();

        private static List<Role> _all;

        private static readonly IEntityService<PermissionInRole> RelaService =
            ServiceBloker.GetService<PermissionInRole>();

        public static RoleData Instance
        {
            get { return _instance ?? (_instance = new RoleData()); }
        }


        /// <summary>
        ///     查询
        /// </summary>
        /// <returns></returns>
        public List<Role> Select()
        {
            return _all ?? (_all = Service.GetAll());
        }

        /// <summary>
        ///     条件查询
        /// </summary>
        /// <param name="queryInfo"></param>
        /// <returns></returns>
        public List<Role> Select(QueryInfo queryInfo)
        {
            if (queryInfo == null)
            {
                queryInfo = new QueryInfo();
            }
            return Service.GetAll(queryInfo);
        }

        /// <summary>
        ///     获取数量
        /// </summary>
        /// <returns></returns>
        public int GetCount()
        {
            return Service.GetCount(new QueryInfo());
        }

        /// <summary>
        ///     更新
        /// </summary>
        /// <param name="role"></param>
        public void Update(Role role)
        {
            Service.Save(role);
            _all = null;
        }

        /// <summary>
        ///     插入
        /// </summary>
        /// <param name="role"></param>
        public void Insert(Role role)
        {
            Service.Save(role);
            _all = null;
        }

        /// <summary>
        ///     删除
        /// </summary>
        /// <param name="role"></param>
        public void Delete(Role role)
        {
            Service.Delete(role.GetEntityId());
            _all = null;
        }

        /// <summary>
        ///     绑定权限
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="permissions"></param>
        public void BindPermission(int roleId, List<int> permissions)
        {
            List<PermissionInRole> permissionInRoles = RelaService.FindAll(c => c.RoleId == roleId, null);
            foreach (PermissionInRole permissionInRole in permissionInRoles)
            {
                RelaService.Delete(permissionInRole.GetEntityId());
            }
            foreach (int permissionId in permissions)
            {
                RelaService.Save(new PermissionInRole
                    {PermissionId = permissionId, RoleId = roleId});
            }
        }

        /// <summary>
        ///     获取权限
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public string GetPermissions(int roleId)
        {
            List<PermissionInRole> list = RelaService.FindAll(c => c.RoleId == roleId, null);

            if (list.Count == 0)
            {
                return "";
            }

            List<int> roleIds = list.Select(c => c.PermissionId).ToList();
            string[] strings =
                ServiceBloker.GetService<Permission>().FindAll(c => roleIds.Contains(c.PermissionId), null).Select(
                    c => c.PermissionId.ToString()).ToArray();
            return string.Join(",", strings);
        }

        /// <summary>
        ///     获取权限列表
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public List<PermissionInRole> GetPermissionList(string roleId)
        {
            int i = Convert.ToInt32(roleId);
            return RelaService.FindAll(c => c.RoleId == i, null);
        }
    }
}