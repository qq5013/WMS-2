/*----------------------------------------------------------------
// Copyright (C) 2010 有限公司
// 版权所有。 
//
// 文件名：         ProductionPlanData.cs
// 文件功能描述：   生产计划数据
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
    ///     生产计划数据
    /// </summary>
    public class ProductionPlanData : BaseData<ProductionPlan>
    {
        public void Update(ProductionPlan entity)
        {
            try
            {
                if (Service.Exists(c => c.Code == entity.Code && c.ProductionPlanId != entity.ProductionPlanId))
                    throw CustomError("Code", "代码不能重复");

                Service.Save(entity);
            }
            catch (Exception ex)
            {
                throw CustomError(ex);
            }
        }

        public void Insert(ProductionPlan entity)
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

        public void Delete(ProductionPlan entity)
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