/*----------------------------------------------------------------
// Copyright (C) 2010 有限公司
// 版权所有。 
//
// 文件名：         ProductionWasterData.cs
// 文件功能描述：   生产报废数据
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
    ///     生产报废数据
    /// </summary>
    public class ProductionWasterData
    {
        /// <summary>
        ///     界面选择导致报废的工序
        /// </summary>
        /// <returns></returns>
        public List<ProductionWaster> Select()
        {
            return ServiceBloker.GetQuery<ProductionWaster>().GetAll(new QueryInfo());
        }
    }
}