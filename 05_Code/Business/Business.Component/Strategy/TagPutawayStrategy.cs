using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Domain.Warehouse;

namespace Business.Component.Strategy
{
    /// <summary>
    /// 标签上架策略
    /// </summary>
    public class TagPutawayStrategy : IPutawayStrategy
    {
        /// <summary>
        /// 获取货物可上架库位信息
        /// </summary>
        /// <param name="warehouseId">仓库编号</param>
        /// <param name="skuId">货物编号</param>
        /// <param name="qty">待上架数量</param>
        /// <returns>成功返回可上架库位信息列表，否则返回空列表</returns>
        public List<PutawayLocation> GetPutawayLocations(int warehouseId, int skuId, int qty)
        {
            return TagManager.GetPutawayLocations(warehouseId, skuId, qty);
        }
    }
}
