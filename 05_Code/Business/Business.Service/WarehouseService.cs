using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Activation;
using Business.Common.DataDictionary;
using Business.Common.Exception;
using Business.Common.QueryModel;
using Business.DataAccess.Repository.Warehouse;
using Business.DataAccess.Repository.Warehouse.Views;
using Business.DataAccess.Repository.Wms;
using Business.Domain.Application;
using Business.Domain.Warehouse;
using Business.Domain.Warehouse.Views;
using Business.Domain.Wms;
using Business.Service.Contract;
using Framework.Core.Collections;
using Business.Common.Toolkit;
using Business.Component;

namespace Business.Service
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class WarehouseService : IWarehouseService
    {
        #region warehouse
        public Warehouse GetWarehouse(int warehouseId)
        {
            try
            {
                var repository = new WarehouseRepository();
                return repository.Get(warehouseId);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return null;
        }

        public List<Warehouse> GetAllWarehouse()
        {
            try
            {
                var repository = new WarehouseRepository();
                return CollectionHelper.ToList(repository.GetAll());
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return new List<Warehouse>();
        }

        public List<Warehouse> GetWarehouseByQuery(Query query)
        {
            try
            {
                var repository = new WarehouseRepository();
                return CollectionHelper.ToList(repository.GetListByQuery(query));
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return new List<Warehouse>();
        }

        public List<Warehouse> GetWarehouseByPagerQuery(PagerQuery query, out int qty)
        {
            qty = 0;
            try
            {
                var repository = new WarehouseRepository();
                return CollectionHelper.ToList(repository.GetByPager(query, out qty));
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return new List<Warehouse>();
        }

        public Warehouse GetWarehouseByCode(string warehouseCode)
        {
            try
            {
                var repository = new WarehouseRepository();
                return repository.GetByCode(warehouseCode);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return null;
        }

        public int CreateWarehouse(Warehouse warehouse)
        {
            try
            {
                var repository = new WarehouseRepository();
                Warehouse oldWarehouse = repository.GetByCode(warehouse.WarehouseCode);
                if (oldWarehouse != null)
                    BusinessExceptionHelper.ThrowBusinessException("WAREHOUSECODE_EXISTS");

                warehouse.CreateTime = TypeConvertHelper.DatetimeToString(DateTime.Now);
                return repository.Create(warehouse);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return 0;
        }

        public bool UpdateWarehouse(Warehouse warehouse)
        {
            try
            {
                var repository = new WarehouseRepository();
                Warehouse oldWarehouse = repository.GetByCode(warehouse.WarehouseCode);
                if (oldWarehouse != null && oldWarehouse.WarehouseId != warehouse.WarehouseId)
                    BusinessExceptionHelper.ThrowBusinessException("WAREHOUSECODE_EXISTS");
                warehouse.EditTime = TypeConvertHelper.DatetimeToString(DateTime.Now);
                return repository.Update(warehouse);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return false;
        }

        public bool DeleteWarehouse(int warehouseId)
        {
            try
            {
                var repository = new WarehouseRepository();
                return repository.Delete(warehouseId);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return false;
        }

        public List<User> GetWarehouseUsers(int warehouseId)
        {
            try
            {
                var repository = new WarehouseRepository();
                return CollectionHelper.ToList(repository.GetUsers(warehouseId));
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return new List<User>();
        }

        public bool AddWarehouseUser(int warehouseId, int userId)
        {
            try
            {
                var repository = new WarehouseUserRepository();
                return repository.AddUser(warehouseId, userId);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return false;
        }

        public bool RemoveWarehouseUser(int warehouseId, int userId)
        {
            try
            {
                var repository = new WarehouseUserRepository();
                return repository.RemoveUser(warehouseId, userId);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return false;
        }

        #endregion

        #region area
        public Area GetArea(int areaId)
        {
            try
            {
                var repository = new AreaRepository();
                return repository.Get(areaId);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return null;
        }

        public List<Area> GetAllArea()
        {
            try
            {
                var repository = new AreaRepository();
                return CollectionHelper.ToList<Area>(repository.GetAll());
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return new List<Area>();
        }

        public List<Area> GetAreaByQuery(Query query)
        {
            try
            {
                var repository = new AreaRepository();
                return CollectionHelper.ToList(repository.GetListByQuery(query));
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return new List<Area>();
        }

        public List<Area> GetAreaByPagerQuery(PagerQuery query, out int qty)
        {
            qty = 0;
            try
            {
                var repository = new AreaRepository();
                return CollectionHelper.ToList(repository.GetByPager(query, out qty));
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return new List<Area>();
        }

        public Area GetAreaByCode(string warehouseCode, string areaCode)
        {
            try
            {
                var repository = new AreaRepository();
                return repository.GetByCode(warehouseCode, areaCode);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return null;
        }

        public int CreateArea(Area area)
        {
            try
            {
                var repository = new AreaRepository();
                Area oldArea = repository.GetByCode(area.WarehouseId, area.AreaCode);
                if (oldArea != null)
                    BusinessExceptionHelper.ThrowBusinessException("AREACODE_EXISTS");

                area.CreateTime = TypeConvertHelper.DatetimeToString(DateTime.Now);
                return repository.Create(area);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return 0;
        }

        public bool UpdateArea(Area area)
        {
            try
            {
                var repository = new AreaRepository();
                Area oldArea = repository.GetByCode(area.WarehouseId, area.AreaCode);
                if (oldArea != null && oldArea.AreaId != area.AreaId)
                    BusinessExceptionHelper.ThrowBusinessException("AREACODE_EXISTS");

                area.EditTime = TypeConvertHelper.DatetimeToString(DateTime.Now);
                return repository.Update(area);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return false;
        }

        public bool DeleteArea(int areaId)
        {
            try
            {
                var repository = new AreaRepository();
                return repository.Delete(areaId);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return false;
        }

        public List<OperatorGroup> GetAreaGroups(int areaId)
        {
            try
            {
                var repository = new AreaRepository();
                return CollectionHelper.ToList(repository.GetGroups(areaId));
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return new List<OperatorGroup>();
        }

        public bool AddAreaGroup(int areaId, int groupId)
        {
            try
            {
                var repository = new AreaGroupRepository();
                return repository.AddGroup(areaId, groupId);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return false;
        }

        public bool RemoveAreaGroup(int areaId, int groupId)
        {
            try
            {
                var repository = new AreaGroupRepository();
                return repository.RemoveGroup(areaId, groupId);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return false;
        }

        #endregion

        #region aisle
        public Aisle GetAisle(int aisleId)
        {
            try
            {
                var repository = new AisleRepository();
                return repository.Get(aisleId);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return null;
        }

        public List<Aisle> GetAllAisle()
        {
            try
            {
                var repository = new AisleRepository();
                return CollectionHelper.ToList(repository.GetAll());
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return new List<Aisle>();
        }

        public List<Aisle> GetAisleByQuery(Query query)
        {
            try
            {
                var repository = new AisleRepository();
                return CollectionHelper.ToList(repository.GetListByQuery(query));
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return new List<Aisle>();
        }

        public List<Aisle> GetAisleByPagerQuery(PagerQuery query, out int qty)
        {
            qty = 0;
            try
            {
                var repository = new AisleRepository();
                return CollectionHelper.ToList(repository.GetByPager(query, out qty));
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return new List<Aisle>();
        }

        public Aisle GetAisleByCode(string warehouseCode, string aisleCode)
        {
            try
            {
                var repository = new AisleRepository();
                return repository.GetByCode(warehouseCode, aisleCode);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return null;
        }

        public int CreateAisle(Aisle aisle)
        {
            try
            {
                var repository = new AisleRepository();
                return repository.Create(aisle);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return 0;
        }

        public bool UpdateAisle(Aisle aisle)
        {
            try
            {
                var repository = new AisleRepository();
                return repository.Update(aisle);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return false;
        }

        public bool DeleteAisle(int aisleId)
        {
            try
            {
                var repository = new AisleRepository();
                return repository.Delete(aisleId);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return false;
        }
        #endregion

        #region shelf
        public Shelf GetShelf(int shelfId)
        {
            try
            {
                var repository = new ShelfRepository();
                return repository.Get(shelfId);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return null;
        }

        public List<Shelf> GetAllShelf()
        {
            try
            {
                var repository = new ShelfRepository();
                return CollectionHelper.ToList(repository.GetAll());
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return new List<Shelf>();
        }

        public List<Shelf> GetShelfByQuery(Query query)
        {
            try
            {
                var repository = new ShelfRepository();
                return CollectionHelper.ToList(repository.GetListByQuery(query));
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return new List<Shelf>();
        }

        public List<Shelf> GetShelfByPagerQuery(PagerQuery query, out int qty)
        {
            qty = 0;
            try
            {
                var repository = new ShelfRepository();
                return CollectionHelper.ToList(repository.GetByPager(query, out qty));
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return new List<Shelf>();
        }

        public Shelf GetShelfByCode(string warehouseCode, string shelfCode)
        {
            try
            {
                var repository = new ShelfRepository();
                return repository.GetByCode(warehouseCode, shelfCode);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return null;
        }

        public int CreateShelf(Shelf shelf)
        {
            try
            {
                var repository = new ShelfRepository();
                shelf.CreateTime = TypeConvertHelper.DatetimeToString(DateTime.Now);
                return repository.Create(shelf);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return 0;
        }

        public bool UpdateShelf(Shelf shelf)
        {
            try
            {
                var repository = new ShelfRepository();
                shelf.EditTime = TypeConvertHelper.DatetimeToString(DateTime.Now);
                return repository.Update(shelf);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return false;
        }

        public bool DeleteShelf(int shelfId)
        {
            try
            {
                var repository = new ShelfRepository();
                return repository.Delete(shelfId);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return false;
        }
        #endregion

        #region location
        public Location GetLocation(int locationId)
        {
            try
            {
                var repository = new LocationRepository();
                return repository.Get(locationId);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return null;
        }

        public LocationView GetLocationView(int locationId)
        {
            try
            {
                var repository = new LocationViewRepository();
                return repository.Get(locationId);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return null;
        }

        public List<Location> GetAllLocation()
        {
            try
            {
                var repository = new LocationRepository();
                return CollectionHelper.ToList(repository.GetAll());
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return new List<Location>();
        }

        public List<Location> GetLocationByQuery(Query query)
        {
            try
            {
                var repository = new LocationRepository();
                return CollectionHelper.ToList(repository.GetListByQuery(query));
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return new List<Location>();
        }


        public List<LocationView> GetLocationViewByQuery(Query query)
        {
            try
            {
                var repository = new LocationViewRepository();
                return CollectionHelper.ToList(repository.GetListByQuery(query));
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return new List<LocationView>();
        }

        public List<LocationView> GetLocationViewByPagerQuery(PagerQuery query, out int qty)
        {
            qty = 0;
            try
            {
                var repository = new LocationViewRepository();
                return CollectionHelper.ToList(repository.GetByPager(query, out qty));
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return new List<LocationView>();
        }

        public List<Location> GetLocationByPagerQuery(PagerQuery query, out int qty)
        {
            qty = 0;
            try
            {
                var repository = new LocationRepository();
                return CollectionHelper.ToList(repository.GetByPager(query, out qty));
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return new List<Location>();
        }

        public Location GetLocationByCode(string warehouseCode, string locationCode)
        {
            try
            {
                var repository = new LocationRepository();
                return repository.GetByCode(warehouseCode, locationCode);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return null;
        }

        public int CreateLocation(Location location)
        {
            try
            {
                var repository = new LocationRepository();
                Location oldLocation = repository.GetByCode(location.WarehouseId, location.LocationCode);
                if (oldLocation != null)
                    BusinessExceptionHelper.ThrowBusinessException("LOCATIONCODE_EXISTS");

                location.CreateTime = TypeConvertHelper.DatetimeToString(DateTime.Now);
                return repository.Create(location);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return 0;
        }

        public bool UpdateLocation(Location location)
        {
            try
            {
                var repository = new LocationRepository();
                Location oldLocation = repository.GetByCode(location.WarehouseId, location.LocationCode);
                if (oldLocation != null && oldLocation.LocationId != location.LocationId)
                    BusinessExceptionHelper.ThrowBusinessException("LOCATIONCODE_EXISTS");

                location.EditTime = TypeConvertHelper.DatetimeToString(DateTime.Now);
                return repository.Update(location);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return false;
        }

        public bool DeleteLocation(int locationId)
        {
            try
            {
                var repository = new LocationRepository();
                return repository.Delete(locationId);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return false;
        }

        public List<LocationView> GetReceivingLocation(string warehouseCode)
        {
            try
            {
                WarehouseRepository warehouseRepository = new WarehouseRepository();
                Warehouse warehouse = warehouseRepository.GetByCode(warehouseCode);
                if (warehouse == null)
                    BusinessExceptionHelper.ThrowBusinessException("WAREHOUSE_NOTFOUND");

                return WarehouseManager.GetReceivingLocation(warehouse.WarehouseId);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return new List<LocationView>();
        }
        #endregion

        #region operatorGroup
        public List<OperatorGroup> GetAllOperatorGroup()
        {
            try
            {
                var repository = new OperatorGroupRepository();
                return CollectionHelper.ToList(repository.GetAll());
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return new List<OperatorGroup>();
        }

        public List<OperatorGroup> GetOperatorGroupByQuery(Query query)
        {
            try
            {
                var repository = new OperatorGroupRepository();
                return CollectionHelper.ToList(repository.GetListByQuery(query));
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return new List<OperatorGroup>();
        }

        public OperatorGroup GetOperatorGroupByName(string warehouseCode, string groupName)
        {
            try
            {
                var repository = new OperatorGroupRepository();
                return repository.GetByName(warehouseCode, groupName);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return null;
        }

        public int CreateOperatorGroup(OperatorGroup operatorGroup)
        {
            try
            {
                var repository = new OperatorGroupRepository();
                return repository.Create(operatorGroup);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return 0;
        }

        public bool UpdateOperatorGroup(OperatorGroup operatorGroup)
        {
            try
            {
                var repository = new OperatorGroupRepository();
                return repository.Update(operatorGroup);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return false;
        }

        public bool DeleteOperatorGroup(int operatorGroupId)
        {
            try
            {
                var repository = new OperatorGroupRepository();
                return repository.Delete(operatorGroupId);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return false;
        }

        public List<User> GetGroupMembers(int operatorGroupId)
        {
            try
            {
                var repository = new OperatorGroupRepository();
                return CollectionHelper.ToList(repository.GetMembers(operatorGroupId));
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return new List<User>();
        }

        public bool AddGroupMember(int operatorGroupId, int userId)
        {
            try
            {
                var repository = new GroupMemberRepository();
                return repository.AddMember(operatorGroupId, userId);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return false;
        }

        public bool RemoveGroupMember(int operatorGroupId, int userId)
        {
            try
            {
                var repository = new GroupMemberRepository();
                return repository.RemoveMember(operatorGroupId, userId);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return false;
        }

        #endregion

        #region containerType
        public ContainerType GetContainerType(int typeId)
        {
            try
            {
                var repository = new ContainerTypeRepository();
                return repository.Get(typeId);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return null;
        }

        public List<ContainerType> GetAllContainerType()
        {
            try
            {
                var repository = new ContainerTypeRepository();
                return CollectionHelper.ToList(repository.GetAll());
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return new List<ContainerType>();
        }

        public List<ContainerType> GetContainerTypeByQuery(Query query)
        {
            try
            {
                var repository = new ContainerTypeRepository();
                return CollectionHelper.ToList(repository.GetListByQuery(query));
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return new List<ContainerType>();
        }

        public List<ContainerType> GetContainerTypeByPagerQuery(PagerQuery query, out int qty)
        {
            qty = 0;
            try
            {
                var repository = new ContainerTypeRepository();
                return CollectionHelper.ToList(repository.GetByPager(query, out qty));
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return new List<ContainerType>();
        }

        public ContainerType GetContainerTypeByCode(string warehouseCode, string typeCode)
        {
            try
            {
                var repository = new ContainerTypeRepository();
                return repository.GetByCode(warehouseCode, typeCode);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return null;
        }

        public int CreateContainerType(ContainerType containerType)
        {
            try
            {
                var repository = new ContainerTypeRepository();

                ContainerType oldContainerType = repository.GetByCode(containerType.WarehouseId, containerType.TypeCode);
                if (oldContainerType != null)
                    BusinessExceptionHelper.ThrowBusinessException("CONTAINERTYPECODE_EXISTS");

                return repository.Create(containerType);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return 0;
        }

        public bool UpdateContainerType(ContainerType containerType)
        {
            try
            {
                var repository = new ContainerTypeRepository();
                ContainerType oldContainerType = repository.GetByCode(containerType.WarehouseId, containerType.TypeCode);
                if (oldContainerType != null && oldContainerType.TypeId != containerType.TypeId) 
                    BusinessExceptionHelper.ThrowBusinessException("CONTAINERTYPECODE_EXISTS");

                return repository.Update(containerType);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return false;
        }

        public bool DeleteContainerType(int containerTypeId)
        {
            try
            {
                var repository = new ContainerTypeRepository();
                return repository.Delete(containerTypeId);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return false;
        }
        #endregion

        #region container
        public Container GetContainer(int containerId)
        {
            try
            {
                var repository = new ContainerRepository();
                return repository.Get(containerId);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return null;
        }

        public List<Container> GetAllContainer()
        {
            try
            {
                var repository = new ContainerRepository();
                return CollectionHelper.ToList(repository.GetAll());
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return new List<Container>();
        }

        public List<Container> GetContainerByQuery(Query query)
        {
            try
            {
                var repository = new ContainerRepository();
                return CollectionHelper.ToList(repository.GetListByQuery(query));
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return new List<Container>();
        }

        public List<Container> GetContainerByPagerQuery(PagerQuery query, out int qty)
        {
            qty = 0;
            try
            {
                var repository = new ContainerRepository();
                return CollectionHelper.ToList(repository.GetByPager(query, out qty));
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return new List<Container>();
        }

        public Container GetContainerByCode(string warehouseCode, string containerCode)
        {
            try
            {
                var repository = new ContainerRepository();
                return repository.GetByCode(warehouseCode, containerCode);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return null;
        }

        public int CreateContainer(Container container)
        {
            try
            {
                var repository = new ContainerRepository();

                // validate new container code exists.
                Container oldContainer = repository.GetByCode(container.WarehouseId, container.ContainerCode);
                if (oldContainer != null)
                    BusinessExceptionHelper.ThrowBusinessException("CONTAINERCODE_EXISTS");

                container.CreateTime = TypeConvertHelper.DatetimeToString(DateTime.Now);
                return repository.Create(container);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return 0;
        }

        public bool UpdateContainer(Container container)
        {
            try
            {
                var repository = new ContainerRepository();

                Container oldContainer = repository.GetByCode(container.WarehouseId, container.ContainerCode);
                if (oldContainer != null && oldContainer.ContainerId != container.ContainerId)
                    BusinessExceptionHelper.ThrowBusinessException("CONTAINERCODE_EXISTS");

                container.EditTime = TypeConvertHelper.DatetimeToString(DateTime.Now);
                return repository.Update(container);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return false;
        }

        public bool DeleteContainer(int containerId)
        {
            try
            {
                var repository = new ContainerRepository();
                return repository.Delete(containerId);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return false;
        }

        public Container GetTransferContainerByBarcode(string warehouseCode, string barcode)
        {
            try
            {
                Warehouse warehouse = WarehouseManager.GetWarehouse(warehouseCode);
                if (warehouse == null)
                    BusinessExceptionHelper.ThrowBusinessException("WAREHOUSE_NOTFOUND");

                Container container = WarehouseManager.GetContainerByBarcode(warehouse.WarehouseId, barcode);
                if (container == null)
                    BusinessExceptionHelper.ThrowBusinessException("CONTAINER_NOTFOUND");

                ContainerType type = WarehouseManager.GetContainerType(container.ContainerType);
                if (type == null)
                    BusinessExceptionHelper.ThrowBusinessException("CONTAINERTYPE_NOTFOUND");

                if (DictionaryManager.IsEuqalDictionary(type.PurposeType, (int) PurposeType.Transfering))
                    return container;

            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return null;
        }

        public Container GetStorageContainerByBarcode(string warehouseCode, string barcode)
        {
            try
            {
                Warehouse warehouse = WarehouseManager.GetWarehouse(warehouseCode);
                if (warehouse == null)
                    BusinessExceptionHelper.ThrowBusinessException("WAREHOUSE_NOTFOUND");

                Container container = WarehouseManager.GetContainerByBarcode(warehouse.WarehouseId, barcode);
                if (container == null)
                    BusinessExceptionHelper.ThrowBusinessException("CONTAINER_NOTFOUND");

                ContainerType type = WarehouseManager.GetContainerType(container.ContainerType);
                if (type == null)
                    BusinessExceptionHelper.ThrowBusinessException("CONTAINERTYPE_NOTFOUND");

                if (DictionaryManager.IsEuqalDictionary(type.PurposeType, (int)PurposeType.Storage))
                    return container;
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return null;
        }
        #endregion

        #region setting
        public Setting GetSetting(int settingId)
        {
            try
            {
                var repository = new SettingRepository();
                return repository.Get(settingId);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return null;
        }

        public List<Setting> GetAllSetting()
        {
            try
            {
                var repository = new SettingRepository();
                return CollectionHelper.ToList(repository.GetAll());
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return new List<Setting>();
        }

        public List<Setting> GetSettingByQuery(Query query)
        {
            try
            {
                var repository = new SettingRepository();
                return CollectionHelper.ToList(repository.GetListByQuery(query));
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return new List<Setting>();
        }

        public List<Setting> GetSettingByPagerQuery(PagerQuery query, out int qty)
        {
            qty = 0;
            try
            {
                var repository = new SettingRepository();
                return CollectionHelper.ToList(repository.GetByPager(query, out qty));
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return new List<Setting>();
        }

        public Setting GetSettingByCode(string warehouseCode, string settingCode)
        {
            try
            {
                var repository = new SettingRepository();
                return repository.GetByCode(warehouseCode, settingCode);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return null;
        }

        public int CreateSetting(Setting setting)
        {
            try
            {
                var repository = new SettingRepository();
                Setting oldSetting = repository.GetByCode(setting.WarehouseId, setting.SettingCode);
                if (oldSetting != null)
                    BusinessExceptionHelper.ThrowBusinessException("SETTINGCODE_EXISTS");

                setting.CreateTime = TypeConvertHelper.DatetimeToString(DateTime.Now);
                return repository.Create(setting);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return 0;
        }

        public bool UpdateSetting(Setting setting)
        {
            try
            {
                var repository = new SettingRepository();
                Setting oldSetting = repository.GetByCode(setting.WarehouseId, setting.SettingCode);
                if (oldSetting != null && oldSetting.SettingId != setting.SettingId)
                    BusinessExceptionHelper.ThrowBusinessException("SETTINGCODE_EXISTS");

                setting.EditTime = TypeConvertHelper.DatetimeToString(DateTime.Now);
                return repository.Update(setting);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return false;
        }

        public bool DeleteSetting(int settingId)
        {
            try
            {
                var repository = new SettingRepository();
                return repository.Delete(settingId);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return false;
        }
        #endregion

        #region safety stock
        public int CreateSafetyStock(SafetyStock safetyStock)
        {
            try
            {
                var repository = new SafetyStockRepository();
                return repository.Create(safetyStock);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return 0;
        }

        public bool UpdateSafetyStock(SafetyStock safetyStock)
        {
            try
            {
                var repository = new SafetyStockRepository();
                return repository.Update(safetyStock);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return false;
        }

        public bool DeleteSafetyStock(int safetyStockId)
        {
            try
            {
                var repository = new SafetyStockRepository();
                return repository.Delete(safetyStockId);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return false;
        }

        public SafetyStock GetSafetyStock(string warehouseCode, int skuId)
        {
            try
            {
                var repository = new SafetyStockRepository();
                return repository.GetBySku(warehouseCode, skuId);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return null;
        }
        #endregion

        #region location safety stock
        public int CreateLocationSafetyStock(LocationSafetyStock locationSafetyStock)
        {
            try
            {
                var repository = new LocationSafetyStockRepository();
                return repository.Create(locationSafetyStock);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return 0;
        }

        public bool UpdateLocationSafetyStock(LocationSafetyStock locationSafetyStock)
        {
            try
            {
                var repository = new LocationSafetyStockRepository();
                return repository.Update(locationSafetyStock);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return false;
        }

        public bool DeleteLocationSafetyStock(int locationSafetyStockId)
        {
            try
            {
                var repository = new LocationSafetyStockRepository();
                return repository.Delete(locationSafetyStockId);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return false;
        }

        public LocationSafetyStock GetLocationSafetyStock(string warehouseCode, int skuId, int locationId)
        {
            try
            {
                var repository = new LocationSafetyStockRepository();
                return repository.GetBySku(warehouseCode, skuId, locationId);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return null;
        }
        #endregion

        #region tag
        public Tag GetTag(int tagId)
        {
            try
            {
                var repository = new TagRepository();
                return repository.Get(tagId);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return null;
        }

        public List<Tag> GetAllTag()
        {
            try
            {
                var repository = new TagRepository();
                return CollectionHelper.ToList(repository.GetAll());
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return new List<Tag>();
        }

        public List<Tag> GetTagByQuery(Query query)
        {
            try
            {
                var repository = new TagRepository();
                return CollectionHelper.ToList(repository.GetListByQuery(query));
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return new List<Tag>();
        }

        public List<Tag> GetTagByPagerQuery(PagerQuery query, out int qty)
        {
            qty = 0;
            try
            {
                var repository = new TagRepository();
                return CollectionHelper.ToList(repository.GetByPager(query, out qty));
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return new List<Tag>();
        }

        public Tag GetTagByNumber(string warehouseCode, string tagNumber)
        {
            try
            {
                var repository = new TagRepository();
                return repository.GetByNumber(warehouseCode, tagNumber);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return null;
        }

        public int CreateTag(Tag tag)
        {
            try
            {
                var repository = new TagRepository();
                Tag oldTag = repository.GetByNumber(tag.WarehouseId, tag.TagNumber);
                if (oldTag != null)
                    BusinessExceptionHelper.ThrowBusinessException("TAGNUMBER_EXISTS");

                tag.CreateTime = TypeConvertHelper.DatetimeToString(DateTime.Now);
                return repository.Create(tag);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return 0;
        }

        public bool UpdateTag(Tag tag)
        {
            try
            {
                var repository = new TagRepository();
                Tag oldTag = repository.GetByNumber(tag.WarehouseId, tag.TagNumber);
                if (oldTag != null && oldTag.TagId != tag.TagId)
                    BusinessExceptionHelper.ThrowBusinessException("TAGNUMBER_EXISTS");

                tag.EditTime = TypeConvertHelper.DatetimeToString(DateTime.Now);
                return repository.Update(tag);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return false;
        }

        public bool DeleteTag(int tagId)
        {
            try
            {
                var repository = new TagRepository();
                return repository.Delete(tagId);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return false;
        }
        #endregion

        #region Sku Tag
        public List<SkuTag> GetSkuTagByPagerQuery(PagerQuery query, out int qty)
        {
            qty = 0;
            try
            {
                var repository = new SkuTagRepository();
                return CollectionHelper.ToList(repository.GetByPager(query, out qty));
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return new List<SkuTag>();
        }

        public List<SkuTagView> GetSkuTagViewByPagerQuery(PagerQuery query, out int qty)
        {
            qty = 0;
            try
            {
                var repository = new SkuTagViewRepository();
                return CollectionHelper.ToList(repository.GetByPager(query, out qty));
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return new List<SkuTagView>();
        }

        public List<SkuTag> GetSkuTagByQuery(Query query)
        {
            try
            {
                var repository = new SkuTagRepository();
                return CollectionHelper.ToList(repository.GetListByQuery(query));
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return new List<SkuTag>();
        }

        public List<SkuTagView> GetSkuTagViewByQuery(Query query)
        {
            try
            {
                var repository = new SkuTagViewRepository();
                return CollectionHelper.ToList(repository.GetListByQuery(query));
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return new List<SkuTagView>();
        }

        public int CreateSkuTag(SkuTag skuTag)
        {
            try
            {
                var repository = new SkuTagRepository();
                var viewRepository = new SkuTagViewRepository();
                SkuTagView skuTagView = viewRepository.Get(skuTag.SkuId, skuTag.TagId);
                if (skuTagView != null)
                    BusinessExceptionHelper.ThrowBusinessException("SKUTAG_EXISTS");

                return repository.Create(skuTag);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return 0;
        }

        public bool UpdateSkuTag(SkuTag skuTag)
        {
            try
            {
                var repository = new SkuTagRepository();
                var viewRepository = new SkuTagViewRepository();
                SkuTagView skuTagView = viewRepository.Get(skuTag.SkuId, skuTag.TagId);
                if (skuTagView != null && skuTagView.Id != skuTag.Id)
                    BusinessExceptionHelper.ThrowBusinessException("SKUTAG_EXISTS");
                return repository.Update(skuTag);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return false;
        }

        public bool DeleteSkuTag(int id)
        {
            try
            {
                var repository = new SkuTagRepository();
                return repository.Delete(id);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return false;
        }

        public SkuTagView GetSkuTagView(int id)
        {
            try
            {
                var repository = new SkuTagViewRepository();
                return repository.Get(id);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return null;
        }
        #endregion

        #region Location Tag
        public List<LocationTag> GetLocationTagByPagerQuery(PagerQuery query, out int qty)
        {
            qty = 0;
            try
            {
                var repository = new LocationTagRepository();
                return CollectionHelper.ToList(repository.GetByPager(query, out qty));
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return new List<LocationTag>();
        }

        public List<LocationTagView> GetLocationTagViewByPagerQuery(PagerQuery query, out int qty)
        {
            qty = 0;
            try
            {
                var repository = new LocationTagViewRepository();
                return CollectionHelper.ToList(repository.GetByPager(query, out qty));
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return new List<LocationTagView>();
        }

        public List<LocationTag> GetLocationTagByQuery(Query query)
        {
            try
            {
                var repository = new LocationTagRepository();
                return CollectionHelper.ToList(repository.GetListByQuery(query));
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return new List<LocationTag>();
        }

        public List<LocationTagView> GetLocationTagViewByQuery(Query query)
        {
            try
            {
                var repository = new LocationTagViewRepository();
                return CollectionHelper.ToList(repository.GetListByQuery(query));
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return new List<LocationTagView>();
        }

        public int CreateLocationTag(LocationTag locationTag)
        {
            try
            {
                var repository = new LocationTagRepository();
                var viewRepository = new LocationTagViewRepository();
                LocationTagView locationTagView = viewRepository.Get(locationTag.LocationId, locationTag.TagId);
                if (locationTagView != null)
                    BusinessExceptionHelper.ThrowBusinessException("LOCATIONTAG_EXISTS");

                return repository.Create(locationTag);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return 0;
        }

        public bool UpdateLocationTag(LocationTag locationTag)
        {
            try
            {
                var repository = new LocationTagRepository();
                var viewRepository = new LocationTagViewRepository();
                LocationTagView locationTagView = viewRepository.Get(locationTag.LocationId, locationTag.TagId);
                if (locationTagView != null && locationTagView.Id != locationTag.Id)
                    BusinessExceptionHelper.ThrowBusinessException("LOCATIONTAG_EXISTS");

                return repository.Update(locationTag);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return false;
        }

        public bool DeleteLocationTag(int locationtagId)
        {
            try
            {
                var repository = new LocationTagRepository();
                return repository.Delete(locationtagId);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return false;
        }

        public LocationTagView GetLocationTagView(int id)
        {
            try
            {
                var repository = new LocationTagViewRepository();
                return repository.Get(id);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return null;
        }
        #endregion
    }
}
