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

namespace MES.Execute
{
    public interface ICheckClosing
    {
        bool DataChanged { get; set; }

        string Title { get; set; }

        bool Save();
    }
}