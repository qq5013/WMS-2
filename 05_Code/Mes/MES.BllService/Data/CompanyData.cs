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

using System;
using MES.Entity;

namespace MES.BllService.Data
{
    public class CompanyData : BaseData<Company>
    {
        public void Update(Company entity)
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

        public void Insert(Company entity)
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

        public void Delete(Company entity)
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