﻿/*----------------------------------------------------------------
// Copyright (C) 2010 有限公司
// 版权所有。 
//
// 文件名：         ProductResultData.cs
// 文件功能描述：   产品结果数据
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
    ///     产品结果数据
    /// </summary>
    public class ProductResultData
    {
        public List<ProductResult> Select(QueryInfo queryInfo, int type)
        {
            List<ProductResult> list = ServiceBloker.GetQuery<ProductResult>().GetAll(queryInfo ?? new QueryInfo());

            if (type == 1)
            {
                list.ForEach(c => c.Date = c.Date.Substring(0, 4));
            }
            else if (type == 2)
            {
                list.ForEach(c => c.Date = c.Date.Substring(0, 7));
            }

            return list;
        }
    }
}