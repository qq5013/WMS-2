/*----------------------------------------------------------------
// Copyright (C) 2010 有限公司
// 版权所有。 
//
// 文件名：         ProductionReworkData.cs
// 文件功能描述：   生产返工数据
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
using Frame.Utils.RelaAndCondition;

namespace MES.BllService.Data
{
    /// <summary>
    ///     生产返工数据
    /// </summary>
    public class ProductionReworkData
    {
        /// <summary>
        ///     查询
        /// </summary>
        /// <returns></returns>
        public List<ProductionRework> Select()
        {
            return ServiceBloker.GetQuery<ProductionRework>().GetAll(new QueryInfo());
        }
    }
}