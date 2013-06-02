/*----------------------------------------------------------------
// Copyright (C) 2010 有限公司
// 版权所有。 
//
// 文件名：         ProductionRework.cs
// 文件功能描述：   生产返工
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

namespace MES.BllService.Data
{
    /// <summary>
    ///     生产返工
    /// </summary>
    public class ProductionRework
    {
        /// <summary>
        ///     名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     跟踪码
        /// </summary>
        public string TraceCode { get; set; }

        /// <summary>
        ///     代码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        ///     工位名
        /// </summary>
        public string ProductStationName { get; set; }

        /// <summary>
        ///     工序名
        /// </summary>
        public string ProcessName { get; set; }

        /// <summary>
        ///     员工号
        /// </summary>
        public string EmployeeCode { get; set; }

        /// <summary>
        ///     时间
        /// </summary>
        public DateTime Time { get; set; }
    }
}