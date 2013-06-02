/*----------------------------------------------------------------
// Copyright (C) 2010 有限公司
// 版权所有。 
//
// 文件名：         EmployeeData.cs
// 文件功能描述：   员工数据
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
using Frame.Utils.Service;
using MES.Entity;

namespace MES.BllService.Data
{
    /// <summary>
    ///     员工数据
    /// </summary>
    public class EmployeeData : BaseData<Employee>
    {
        public void Update(Employee entity)
        {
            try
            {
                if (Service.Exists(c => c.Code == entity.Code && c.EmployeeId != entity.EmployeeId))
                    throw CustomError("Code", "代码不能重复");

                Service.Save(entity);
            }
            catch (Exception ex)
            {
                throw CustomError(ex);
            }
        }

        public void Insert(Employee entity)
        {
            try
            {
                if (Service.Exists(c => c.Code == entity.Code))
                    throw CustomError("Code", "代码不能重复");

                Service.Save(entity);
            }
            catch (Exception ex)
            {
                throw CustomError(ex);
            }
        }

        public void Delete(Employee entity)
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

        public void UpdateAdvance(Employee entity)
        {
            if (entity.BirthDay < DateTime.MinValue)
            {
                entity.BirthDay = DateTime.MinValue;
            }
            Update(entity);
        }

        public void InsertAdvance(Employee entity)
        {
            if (entity.BirthDay < DateTime.MinValue)
            {
                entity.BirthDay = DateTime.MinValue;
            }
            Insert(entity);
        }
    }
}