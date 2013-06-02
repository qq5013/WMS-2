/*----------------------------------------------------------------
// Copyright (C) 2010 有限公司
// 版权所有。 
//
// 文件名：         Bom.cs
// 文件功能描述：   Bom
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

using MES.Entity;

namespace MES.BllService.Data
{
    /// <summary>
    ///     Bom
    /// </summary>
    public class Bom
    {
        /// <summary>
        ///     工序
        /// </summary>
        public Process Process { get; set; }

        /// <summary>
        ///     工步明细
        /// </summary>
        public ProcessStepDetail ProcessStepDetail { get; set; }

        /// <summary>
        ///     工步
        /// </summary>
        public ProcessStep ProcessStep { get; set; }

        /// <summary>
        ///     产品Id
        /// </summary>
        public int ProductId
        {
            get
            {
                if (Process != null) return Process.ProductId;
                return 0;
            }
        }

        /// <summary>
        ///     Sku Id
        /// </summary>
        public int SkuId
        {
            get { return ProcessStepDetail.SkuId; }
        }

        /// <summary>
        ///     数量
        /// </summary>
        public int Quantity
        {
            get { return ProcessStepDetail.Quantity; }
        }

        /// <summary>
        ///     工序名称
        /// </summary>
        public string ProcessName
        {
            get
            {
                if (Process != null) return Process.Name;
                return string.Empty;
            }
        }
    }
}