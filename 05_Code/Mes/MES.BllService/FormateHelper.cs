/*----------------------------------------------------------------
// Copyright (C) 2010 有限公司
// 版权所有。 
//
// 文件名：         FormateHelper.cs
// 文件功能描述：   格式化帮助
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

namespace MES.BllService
{
    /// <summary>
    ///     格式化帮助
    /// </summary>
    public static class FormateHelper
    {
        /// <summary>
        ///     时间格式化
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string FormateTime(object obj)
        {
            if (obj == null || obj == DBNull.Value)
            {
                return string.Empty;
            }
            DateTime dateTime = Convert.ToDateTime(obj);
            if (dateTime <= new DateTime(1900, 1, 1))
            {
                return string.Empty;
            }
            return dateTime.ToString("yyyy-MM-dd HH:mm");
        }

        /// <summary>
        ///     日期格式化
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string FormateDate(object obj)
        {
            if (obj == null || obj == DBNull.Value)
            {
                return string.Empty;
            }
            DateTime dateTime = Convert.ToDateTime(obj);
            if (dateTime <= new DateTime(1900, 1, 1))
            {
                return string.Empty;
            }
            return dateTime.ToString("yyyy-MM-dd");
        }
    }
}