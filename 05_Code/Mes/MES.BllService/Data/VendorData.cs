/*----------------------------------------------------------------
// Copyright (C) 2010 有限公司
// 版权所有。 
//
// 文件名：         VendorData.cs
// 文件功能描述：   供应商数据
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
    ///     供应商数据
    /// </summary>
    public class VendorData : BaseData<Vendor>
    {
        public void Update(Vendor entity)
        {
            try
            {
                if (Service.Exists(c => c.Code == entity.Code && c.VendorId != entity.VendorId))
                    throw CustomError("Code", "代码不能重复");

                Service.Save(entity);
            }
            catch (Exception ex)
            {
                throw CustomError(ex);
            }
        }

        public void Insert(Vendor entity)
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

        public void Delete(Vendor entity)
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