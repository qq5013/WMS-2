﻿/*----------------------------------------------------------------
// Copyright (C) 2010 有限公司
// 版权所有。 
//
// 文件名：         ProductInfoData.cs
// 文件功能描述：   产品信息数据
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
using System.ComponentModel;
using Frame.Utils.RelaAndCondition;
using Frame.Utils.Service;

namespace MES.BllService.Data
{
    /// <summary>
    ///     产品信息数据
    /// </summary>
    public class ProductInfoData
    {
        public List<SkuInfo> Select()
        {
            IEntityQuery<SkuInfo> service = ServiceBloker.GetQuery<SkuInfo>();
            //t => t.IsMateriel == true, new ListSortDescriptionCollection(new ListSortDescription[] { new ListSortDescription(PropertyDescriptor.("Code",null),ListSortDirection.Ascending), })
            return
                service.GetAll(new QueryInfo
                    {
                        Condition = new EntityColumn("t.IsMateriel") == false,
                        CompositorList =
                            new List<Compositor>
                                {
                                    new Compositor
                                        {
                                            Column = new EntityColumn("t.Code"),
                                            SortDirection = ListSortDirection.Ascending
                                        }
                                }
                    });
        }
    }
}