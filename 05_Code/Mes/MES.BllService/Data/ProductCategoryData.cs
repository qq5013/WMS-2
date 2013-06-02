/*----------------------------------------------------------------
// Copyright (C) 2010 有限公司
// 版权所有。 
//
// 文件名：         ProductCategoryData.cs
// 文件功能描述：   产品目录数据
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
    ///     产品目录数据
    /// </summary>
    public class ProductCategoryData : BaseData<ProductCategory>
    {
        public void Update(ProductCategory entity)
        {
            try
            {
                if (Service.Exists(c => c.Code == entity.Code && c.ProductCategoryId != entity.ProductCategoryId))
                    throw CustomError("Code", "代码不能重复");

                Service.Save(entity);
            }
            catch (Exception ex)
            {
                throw CustomError(ex);
            }
        }

        public void Insert(ProductCategory entity)
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

        public void Delete(ProductCategory entity)
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

        /// <summary>
        ///     更新
        /// </summary>
        /// <param name="entity"></param>
        public void UpdateAdvance(ProductCategory entity)
        {
            ProductCategory productCategory = Service.GetById(entity.GetEntityId());
            productCategory.Name = entity.Name;
            productCategory.Code = entity.Code;
            productCategory.Description = entity.Description;
            Update(productCategory);
        }

        /// <summary>
        ///     插入
        /// </summary>
        /// <param name="entity"></param>
        public void InsertAdvance(ProductCategory entity)
        {
            Insert(entity);
        }
    }
}