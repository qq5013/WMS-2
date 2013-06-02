/*----------------------------------------------------------------
// Copyright (C) 2010 有限公司
// 版权所有。 
//
// 文件名：         ProductionWaster.cs
// 文件功能描述：   生产报废
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
    ///     生产报废
    /// </summary>
    public class ProductionWaster
    {
        public string Name { get; set; }

        public string TraceCode { get; set; }

        public string Code { get; set; }

        public string ProductStationName { get; set; }

        public string ProcessName { get; set; }

        public string EmployeeCode { get; set; }

        public DateTime Time { get; set; }
    }
}