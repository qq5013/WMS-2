/*----------------------------------------------------------------
// Copyright (C) 2010 有限公司
// 版权所有。 
//
// 文件名：
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
using System.Collections.Generic;
using MES.Entity;
using MES.Enum;

namespace MES.Execute.Controls
{
    /// <summary>
    /// 物料追踪信息
    /// </summary>
    public class MaterielTraceInfo : MaterielTrace
    {
        private readonly List<ItemProcessStepDetail> _details = new List<ItemProcessStepDetail>();

        /// <summary>
        /// SKU信息
        /// </summary>
        public SkuInfo SkuInfo { get; set; }

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
        /// 是否物料
        /// </summary>
        public bool IsMateriel
        {
            get { return SkuInfo.IsMateriel; }
        }

        /// <summary>
        /// 追踪类型
        /// </summary>
        public TraceType TraceType
        {
            get { return SkuInfo.TraceType; }
        }

        /// <summary>
        /// 分类代码
        /// </summary>
        public string CategoryCode
        {
            get { return SkuInfo.CategoryCode; }
        }


        /// <summary>
        /// 工步明细
        /// </summary>
        public List<ItemProcessStepDetail> Details
        {
            get { return _details; }
        }
    }
}