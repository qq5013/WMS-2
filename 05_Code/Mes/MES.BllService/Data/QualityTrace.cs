/*----------------------------------------------------------------
// Copyright (C) 2010 有限公司
// 版权所有。 
//
// 文件名：         QualityTrace.cs
// 文件功能描述：   质量追踪
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
    ///     质量追踪
    /// </summary>
    public class QualityTrace
    {
        /// <summary>
        ///     商品Id
        /// </summary>
        public int ItemId { get; set; }

        /// <summary>
        ///     产品Id
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        ///     SKU Id
        /// </summary>
        public int SkuId { get; set; }

        /// <summary>
        ///     工序 Id
        /// </summary>
        public int ProcessId { get; set; }

        /// <summary>
        ///     工步Id
        /// </summary>
        public int ProcessStepId { get; set; }

        /// <summary>
        ///     工步明细Id
        /// </summary>
        public int ProcessStepDetailId { get; set; }

        /// <summary>
        ///     操作人Id
        /// </summary>
        public int OperatorId { get; set; }

        /// <summary>
        ///     起始时间
        /// </summary>
        public DateTime BegainTime { get; set; }

        /// <summary>
        ///     追踪号
        /// </summary>
        public string TraceCode { get; set; }
    }
}