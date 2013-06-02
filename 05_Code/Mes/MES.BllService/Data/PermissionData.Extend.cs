/*----------------------------------------------------------------
// Copyright (C) 2010 有限公司
// 版权所有。 
//
// 文件名：         PermissionData.Extend.cs
// 文件功能描述：   权限数据扩展
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
using Frame.Utils.RelaAndCondition;
using MES.Entity;

namespace MES.BllService.Data
{
    /// <summary>
    ///     权限数据扩展
    /// </summary>
    public class PermissionData : BaseData<Permission>
    {
        private static PermissionData _instance;

        /// <summary>
        ///     单例
        /// </summary>
        public static PermissionData Instance
        {
            get { return _instance ?? (_instance = new PermissionData()); }
        }

        /// <summary>
        ///     查询权限
        /// </summary>
        /// <returns></returns>
        public List<Permission> Select(QueryInfo queryInfo)
        {
            if (queryInfo == null)
            {
                queryInfo = new QueryInfo();
            }
            return Service.GetAll(queryInfo);
        }

        /// <summary>
        ///     查询有效权限
        /// </summary>
        /// <returns></returns>
        public List<Permission> SelectActive()
        {
            var queryInfo = new QueryInfo
                {
                    Condition = new EntityColumn("IsDeactivated") == false
                };

            return Service.GetAll(queryInfo);
        }

        /// <summary>
        ///     获取权限数量
        /// </summary>
        /// <returns></returns>
        public int GetCount()
        {
            return Service.GetCount(new QueryInfo());
        }

        /// <summary>
        ///     更新权限
        /// </summary>
        /// <param name="permission"></param>
        public void Update(Permission permission)
        {
            try
            {
                Permission item = Service.GetById(permission.GetEntityId());
                item.Name = permission.Name;
                item.Code = permission.Code;
                //item.PermissionType = permission.PermissionType;
                item.Description = permission.Description;
                item.Condition = permission.Condition;
                DateTime currentTime = DateTime.Now;
                item.UpdateTime = currentTime;
                Service.Save(item);
            }
            catch (Exception ex)
            {
                throw CustomError(ex);
            }
        }

        /// <summary>
        ///     新建权限
        /// </summary>
        /// <param name="permission"></param>
        public void Insert(Permission permission)
        {
            try
            {
                DateTime currentTime = DateTime.Now;
                permission.UpdateTime = currentTime;
                permission.CreateTime = currentTime;
                Service.Save(permission);
            }
            catch (Exception ex)
            {
                throw CustomError(ex);
            }
        }

        /// <summary>
        ///     删除权限
        /// </summary>
        /// <param name="permission"></param>
        public void Delete(Permission permission)
        {
            try
            {
                Permission item = Service.GetById(permission.GetEntityId());
                item.IsDeactivated = true;
                Service.Save(item);
            }
            catch (Exception ex)
            {
                throw CustomError(ex);
            }
        }
    }
}