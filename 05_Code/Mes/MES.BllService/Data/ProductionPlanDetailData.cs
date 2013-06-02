/*----------------------------------------------------------------
// Copyright (C) 2010 有限公司
// 版权所有。 
//
// 文件名：         ProductionPlanDetailData.cs
// 文件功能描述：   生产计划明细数据
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
    ///     生产计划明细数据
    /// </summary>
    public class ProductionPlanDetailData : BaseData<ProductionPlanDetail>
    {
        public List<ProductionPlanDetail> SelectByMaster(int masterId)
        {
            return Service.FindAll(c => c.ProductionPlanId == masterId, null);
        }

        public void Update(ProductionPlanDetail entity)
        {
            try
            {
                //    entity.ProductionPlanId = Convert.ToInt32(HttpContext.Current.Session["ProductionPlanId"]);
                Service.Save(entity);
            }
            catch (Exception ex)
            {
                throw CustomError(ex);
            }
        }

        public void Insert(ProductionPlanDetail entity)
        {
            try
            {
                //  entity.ProductionPlanId = Convert.ToInt32(HttpContext.Current.Session["ProductionPlanId"]);
                Service.Save(entity);
            }
            catch (Exception ex)
            {
                throw CustomError(ex);
            }
        }

        public void Delete(ProductionPlanDetail entity)
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