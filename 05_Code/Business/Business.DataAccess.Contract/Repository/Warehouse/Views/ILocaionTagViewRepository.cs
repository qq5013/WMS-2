using System.Collections.Generic;
using Business.Common.QueryModel;
using Business.Domain.Inventory;
using Business.Domain.Warehouse.Views;

namespace Business.DataAccess.Contract.Repository.Warehouse.Views
{
    public interface ILocaionTagViewRepository : IRepository<LocationTagView>
    {
        LocationTagView Get(int locationId, int tagId);
    }
}
