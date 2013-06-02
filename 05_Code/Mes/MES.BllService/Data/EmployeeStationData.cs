/*----------------------------------------------------------------
// Copyright (C) 2010 有限公司
// 版权所有。 
//
// 文件名：         EmployeeStationData.cs
// 文件功能描述：   员工工位数据
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
    ///     员工工位数据
    /// </summary>
    public class EmployeeStationData : BaseData<EmployeeStation>
    {
        public void Update(EmployeeStation entity)
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

        public void Insert(EmployeeStation entity)
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

        public void Delete(EmployeeStation entity)
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