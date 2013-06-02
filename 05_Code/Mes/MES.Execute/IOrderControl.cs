/*----------------------------------------------------------------
// Copyright (C) 2010 有限公司
// 版权所有。 
//
// 文件名：         IOrderControl.cs
// 文件功能描述：   单据控件
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

namespace MES.Execute
{
    /// <summary>
    /// 单据控件，供弹出选择单据用
    /// </summary>
    public interface IOrderControl
    {
        /// <summary>
        /// 开始模式
        /// </summary>
        OpenMode OpenMode{ get; set;}

        /// <summary>
        /// 状态
        /// </summary>
        int[] Status { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        int[] Types { get; set; }

        /// <summary>
        /// 单据号
        /// </summary>
        SetOrderCode SetOrderCode{ get; set;}
    }
}