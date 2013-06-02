/*----------------------------------------------------------------
// Copyright (C) 2010 有限公司
// 版权所有。 
//
// 文件名：         BomData.cs
// 文件功能描述：   Bom 数据
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

using System.Collections.Generic;
using System.Linq;
using Frame.Utils.Service;
using MES.Entity;

namespace MES.BllService.Data
{
    /// <summary>
    ///     Bom 数据
    /// </summary>
    public class BomData
    {
        public List<Bom> Select(int productId)
        {
            List<Process> processes = productId > 0
                                          ? ServiceHelper.GetService<Process>()
                                                         .FindAll(c => c.ProductId == productId, null)
                                          : ServiceHelper.GetService<Process>().GetAll();
            List<int> processeIds = processes.Select(c => c.ProcessId).ToList();
            var result = new List<Bom>();

            if (processeIds.Count == 0)
                return result;
            List<ProcessStep> processSteps =
                ServiceHelper.GetService<ProcessStep>().FindAll(c => processeIds.Contains(c.ProcessId), null);
            List<int> processStepIds = processSteps.Select(c => c.ProcessStepId).ToList();
            if (processStepIds.Count == 0)
                return result;
            List<ProcessStepDetail> processStepDetails =
                ServiceHelper.GetService<ProcessStepDetail>()
                             .FindAll(c => processStepIds.Contains(c.ProcessStepId), null);

            result.AddRange(from processStepDetail in processStepDetails
                            let detail = processStepDetail
                            let processStep = processSteps.Find(c => c.ProcessStepId == detail.ProcessStepId)
                            select new Bom
                                {
                                    ProcessStepDetail = processStepDetail,
                                    ProcessStep = processStep,
                                    Process =
                                        (processes ?? new List<Process>()).Find(
                                            c => c.ProcessId == (processStep ?? new ProcessStep()).ProcessId)
                                });


            return result;
        }
    }
}