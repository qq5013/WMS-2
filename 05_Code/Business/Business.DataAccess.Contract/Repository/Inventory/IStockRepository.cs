using System.Collections.Generic;
using Business.Common.QueryModel;
using Business.Domain.Inventory;
using Business.Domain.Inventory.Views;

namespace Business.DataAccess.Contract.Repository.Inventory
{
    public interface IStockRepository : IRepository<Stock>
    {
        
    }
}