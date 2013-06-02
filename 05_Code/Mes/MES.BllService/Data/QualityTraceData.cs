/*----------------------------------------------------------------
// Copyright (C) 2010 有限公司
// 版权所有。 
//
// 文件名：         QualityTraceData.cs
// 文件功能描述：   质量追踪数据
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
using Frame.Utils.Service;

namespace MES.BllService.Data
{
    /// <summary>
    ///     质量追踪数据
    /// </summary>
    public class QualityTraceData
    {
        public List<QualityTrace> Select(int itemId)
        {
            if (itemId == 0)
                return new List<QualityTrace>();

            return ServiceBloker.GetQuery<QualityTrace>().FindAll(t => t.ItemId == itemId, null);
        }
    }
}