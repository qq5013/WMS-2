/*----------------------------------------------------------------
// Copyright (C) 2010 有限公司
// 版权所有。 
//
// 文件名：         ProcessData.Extend.cs
// 文件功能描述：   工序数据扩展
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
    ///     工序数据扩展
    /// </summary>
    public partial class ProcessData
    {
        public void UpdateExtend(Process entity)
        {
            entity.ImageData = Service.GetById(entity.GetEntityId()).ImageData;
            Update(entity);
        }

        public void InsertExtend(Process entity)
        {
            entity.ImageData = new byte[0];
            Insert(entity);
        }
    }
}