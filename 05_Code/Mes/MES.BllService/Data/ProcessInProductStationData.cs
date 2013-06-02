/*----------------------------------------------------------------
// Copyright (C) 2010 有限公司
// 版权所有。 
//
// 文件名：         ProcessInProductStationData.cs
// 文件功能描述：   工序工位数据
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

namespace MES.BllService.Data
{
    /// <summary>
    ///     工序工位数据
    /// </summary>
    public class ProcessInProductStationData : BaseData<ProcessInProductStation>
    {
        public void Update(ProcessInProductStation entity)
        {
            try
            {
                Service.Save(entity);
            }
            catch (Exception ex)
            {
                throw CustomError(ex);
            }
        }

        public void Insert(ProcessInProductStation entity)
        {
            try
            {
                Service.Save(entity);
            }
            catch (Exception ex)
            {
                throw CustomError(ex);
            }
        }

        public void Delete(ProcessInProductStation entity)
        {
            try
            {
                Service.Delete(entity.GetEntityId());
            }
            catch (Exception ex)
            {
                throw CustomError(ex);
            }
        }
    }
}