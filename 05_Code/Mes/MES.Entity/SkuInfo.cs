/*----------------------------------------------------------------
// Copyright (C) 2010 有限公司
// 版权所有。 
//
// 文件名：         SkuInfo.cs
// 文件功能描述：   SkuInfo信息
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
using MES.Enum;

namespace MES
{
    /// <summary>
    /// Sku 信息
    /// </summary>
    public class SkuInfo
    {
        /// <summary>
        /// Sku Id
        /// </summary>
        public Int32 SkuId { get; set; }

        /// <summary>
        /// 产品
        /// </summary>
        public Int32 ProductId { get; set; }

        /// <summary>
        /// 代码
        /// </summary>
        public String Code { get; set; }

        /// <summary>
        /// 规格
        /// </summary>
        public String Spec { get; set; }

        /// <summary>
        /// 型号
        /// </summary>
        public String Model { get; set; }

        /// <summary>
        /// 颜色
        /// </summary>
        public String Color { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 目录
        /// </summary>
        public string CategoryName { get; set; }

        /// <summary>
        /// 是否物料
        /// </summary>
        public bool IsMateriel { get; set; }

        /// <summary>
        /// 追踪类型
        /// </summary>
        public TraceType TraceType { get; set; }

        /// <summary>
        /// 单价
        /// </summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// 目录
        /// </summary>
        public string CategoryCode { get; set; }
    }
}