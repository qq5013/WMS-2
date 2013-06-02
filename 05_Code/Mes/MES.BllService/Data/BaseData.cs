/*----------------------------------------------------------------
// Copyright (C) 2010 有限公司
// 版权所有。 
//
// 文件名：         BaseData.cs
// 文件功能描述：   基础数据
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
using Frame.Utils.Contract;
using Frame.Utils.Log;
using Frame.Utils.RelaAndCondition;
using Frame.Utils.Service;

namespace MES.BllService.Data
{
    /// <summary>
    ///     基础数据
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BaseData<T> where T : class, IBaseEntity
    {
        private const int _userId = 1;

        /// <summary>
        ///     Html日志
        /// </summary>
        public ILogger Logger = new HtmlWriter();

        /// <summary>
        ///     服务
        /// </summary>
        public IEntityService<T> Service
        {
            get { return ServiceBloker.GetService<T>(); }
        }

        /// <summary>
        ///     用户
        /// </summary>
        public int UserId
        {
            get { return _userId; }
        }

        /// <summary>
        ///     用户错误
        /// </summary>
        /// <param name="filedName"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        protected Exception CustomError(string filedName, string message)
        {
            //HttpContext.Current.Session["CustomErrorText"] = message;
            return new Exception(message);
        }

        /// <summary>
        ///     用户错误
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        protected Exception CustomError(Exception exception)
        {
            //HttpContext.Current.Session["CustomErrorText"] = exception.Message;
            return exception;
        }

        /// <summary>
        ///     分页查询
        /// </summary>
        /// <returns></returns>
        public List<T> SelectByPage()
        {
            var serviceList = new List<T>();
            return serviceList;
        }

        /// <summary>
        ///     查询
        /// </summary>
        /// <returns></returns>
        public List<T> Select()
        {
            var queryInfo = new QueryInfo();
            List<T> list = Service.GetAll(queryInfo);
            return list;
        }

        /// <summary>
        ///     查询全部
        /// </summary>
        /// <returns></returns>
        public List<T> SelectAll()
        {
            return Service.GetAll();
        }
    }
}