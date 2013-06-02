/*----------------------------------------------------------------
// Copyright (C) 2010 有限公司
// 版权所有。 
//
// 文件名：         LocationData.Extend.cs
// 文件功能描述：   库位数据扩展
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

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Frame.Utils.Service;
using MES.Entity;

namespace MES.BllService.Data
{
    /// <summary>
    ///     库位数据扩展
    /// </summary>
    public partial class LocationData
    {
        public IList SelectLocationInfo()
        {
            List<Location> locations = ServiceBloker.GetService<Location>().GetAll();
            List<Warehouse> warehouses = ServiceBloker.GetService<Warehouse>().GetAll();
            return (from location in locations
                    let warehouse = warehouses.Find(c => c.WarehouseId == location.WarehouseId)
                    select new {location.LocationId, warehouse.Name}).ToList();
        }
    }
}