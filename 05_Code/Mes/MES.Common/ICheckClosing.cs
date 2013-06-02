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

namespace MES.Common
{
    /// <summary>
    /// 关闭前判断
    /// </summary>
    public interface ICheckClosing
    {
        /// <summary>
        /// 数据是否变化
        /// </summary>
        bool DataChanged { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        string Title { get; set; }

        /// <summary>
        /// 保存
        /// </summary>
        /// <returns></returns>
        bool Save();
    }
}