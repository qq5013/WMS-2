/*----------------------------------------------------------------
// Copyright (C) 2010 有限公司
// 版权所有。 
//
// 文件名：         ProductData.cs
// 文件功能描述：   产品数据
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
using System.Collections.Generic;
using Frame.Utils.Service;
using MES.Entity;

namespace MES.BllService.Data
{
    /// <summary>
    ///     产品数据
    /// </summary>
    public class ProductData : BaseData<Product>
    {
        public void Update(Product entity)
        {
            try
            {
                if (Service.Exists(c => c.Code == entity.Code && c.ProductId != entity.ProductId))
                    throw CustomError("Code", "代码不能重复");

                Service.Save(entity);
            }
            catch (Exception ex)
            {
                throw CustomError(ex);
            }
        }

        public void Insert(Product entity)
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

        public void Delete(Product entity)
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

        public List<Product> SelectIsMateriel(bool isMateriel)
        {
            return Service.FindAll(c => c.IsMateriel == isMateriel);
        }
    }
}