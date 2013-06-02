/*----------------------------------------------------------------
// Copyright (C) 2010 有限公司
// 版权所有。 
//
// 文件名：         ProcessStepInfoDetail.cs
// 文件功能描述：   
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
using MES.Entity;
using MES.Enum;

namespace MES.Execute.Controls
{
    /// <summary>
    /// 工步信息明细
    /// </summary>
    public class ProcessStepInfoDetail
    {
        /// <summary>
        /// Sku信息
        /// </summary>
        public SkuInfo SkuInfo { get; set; }

        /// <summary>
        /// Sku Id
        /// </summary>
        public Int32 SkuId
        {
            get { return SkuInfo.SkuId; }
        }

        /// <summary>
        /// 代码
        /// </summary>
        public String Code
        {
            get { return SkuInfo.Code; }
        }

        /// <summary>
        /// 规格
        /// </summary>
        public String Spec
        {
            get { return SkuInfo.Spec; }
        }

        /// <summary>
        /// 型号
        /// </summary>
        public String Model
        {
            get { return SkuInfo.Model; }
        }

        /// <summary>
        /// 颜色
        /// </summary>
        public String Color
        {
            get { return SkuInfo.Color; }
        }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name
        {
            get { return SkuInfo.Name; }
        }

        /// <summary>
        /// 分类名称
        /// </summary>
        public string CategoryName
        {
            get { return SkuInfo.CategoryName; }
        }

        /// <summary>
        /// 追踪类型
        /// </summary>
        public TraceType TraceType
        {
            get { return SkuInfo.TraceType; }
        }

        /// <summary>
        /// 百分比比率
        /// </summary>
        public double Rate
        {
            get
            {
                if (Quantity == null)
                    return DoneQuantity*100;
                return ((double) DoneQuantity*100)/Quantity.Value;
            }
        }

        /// <summary>
        /// 完成数量
        /// </summary>
        public int DoneQuantity { get; set; }

        /// <summary>
        /// 总数量
        /// </summary>
        public int? Quantity { get; set; }

        /// <summary>
        /// 是否完成
        /// </summary>
        public bool IsProcessed { get; set; }
    }
}