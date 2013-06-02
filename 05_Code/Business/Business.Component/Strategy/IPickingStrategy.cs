using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Domain.Warehouse;

namespace Business.Component.Strategy
{
    public interface IPickingStrategy
    {
        List<PickingStock> GetPickingStocks(int warehouseId, int skuId, int qty);
    }
}
