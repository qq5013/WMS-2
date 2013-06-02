using System.Collections;
using System.Collections.Generic;
using Business.Common.QueryModel;
using Business.DataAccess.Contract.Repository.Warehouse;
using Business.DataAccess.Repository.Wms;
using Business.Domain.Warehouse;
using Business.Domain.Warehouse.Views;

namespace Business.DataAccess.Repository.Warehouse
{
    public class LocationViewRepository : Repository<LocationView>, ILocationViewRepository
    {
        private readonly WarehouseRepository _warehouseRepository;

        public LocationViewRepository()
        {
            Database = DatabaseConfigName.Warehouse;

            _warehouseRepository = new WarehouseRepository();
        }
    }
}