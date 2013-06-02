/*----------------------------------------------------------------
// Copyright (C) 2010 有限公司
// 版权所有。 
//
// 文件名：         EnumItemInfo.cs
// 文件功能描述：   枚举信息
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

using Frame.Utils.MetaDB;

namespace MES.BllService.Data
{
    /// <summary>
    ///     枚举信息
    /// </summary>
    public class EnumItemInfo : EnumItem
    {
        public object EnumValue { get; set; }
    }
}