/*----------------------------------------------------------------
// Copyright (C) 2010 有限公司
// 版权所有。 
//
// 文件名：         ProcessStepDetailData.cs
// 文件功能描述：   工步明细数据
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
    ///     工步明细数据
    /// </summary>
    public class ProcessStepDetailData : BaseData<ProcessStepDetail>
    {
        public List<ProcessStepDetail> SelectByMaster(int masterId)
        {
            return Service.FindAll(c => c.ProcessStepId == masterId, null);
        }

        public void Update(ProcessStepDetail entity)
        {
            try
            {
                //	entity.ProcessStepId = Convert.ToInt32(HttpContext.Current.Session["ProcessStepId"]);


                Service.Save(entity);
            }
            catch (Exception ex)
            {
                throw CustomError(ex);
            }
        }

        public void Insert(ProcessStepDetail entity)
        {
            try
            {
                //	entity.ProcessStepId = Convert.ToInt32(HttpContext.Current.Session["ProcessStepId"]);

                Service.Save(entity);
            }
            catch (Exception ex)
            {
                throw CustomError(ex);
            }
        }

        public void Delete(ProcessStepDetail entity)
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