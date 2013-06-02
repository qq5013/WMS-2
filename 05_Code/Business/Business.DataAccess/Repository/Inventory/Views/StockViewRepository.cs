using System;
using System.Collections.Generic;
using Business.Common.QueryModel;
using Business.DataAccess.Contract.Repository.Inventory;
using Business.Domain.Inventory;
using Business.Domain.Inventory.Views;
using Framework.Core.Collections;
using Framework.Core.Exception;
using Framework.Database.IBatis;

namespace Business.DataAccess.Repository.Inventory
{
    public class StockViewRepository : Repository<StockView>, IStockViewRepository
    {
        public StockViewRepository()
        {
            Database = DatabaseConfigName.Inventory;
        }
    }
}