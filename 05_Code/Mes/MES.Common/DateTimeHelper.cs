/*----------------------------------------------------------------
// Copyright (C) 2010 有限公司
// 版权所有。 
//
// 文件名：         DateTimeHelper.cs
// 文件功能描述：   时间帮助
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

namespace MES.Common
{
    /// <summary>
    ///     时间帮助
    /// </summary>
    public static class DateTimeHelper
    {
        private static readonly DateTime _min = new DateTime(1900, 1, 1);

        private static readonly DateTime _max = new DateTime(2100, 1, 1);

        /// <summary>
        ///     当前时间
        /// </summary>
        public static DateTime Now
        {
            get { return DateTime.Now; }
        }

        /// <summary>
        ///     最小时间
        /// </summary>
        public static DateTime Min
        {
            get { return _min; }
        }

        /// <summary>
        ///     最大时间
        /// </summary>
        public static DateTime Max
        {
            get { return _max; }
        }
    }
}