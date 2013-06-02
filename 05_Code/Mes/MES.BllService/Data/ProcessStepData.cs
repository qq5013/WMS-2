/*----------------------------------------------------------------
// Copyright (C) 2010 有限公司
// 版权所有。 
//
// 文件名：         ProcessStepData.cs
// 文件功能描述：   工步数据
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
    ///     工步数据
    /// </summary>
    public class ProcessStepData : BaseData<ProcessStep>
    {
        public void Update(ProcessStep entity)
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

        public void Insert(ProcessStep entity)
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

        public void Delete(ProcessStep entity)
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