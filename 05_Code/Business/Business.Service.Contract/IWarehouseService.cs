using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using Business.Common.Exception;
using Business.Common.QueryModel;
using Business.Domain.Application;
using Business.Domain.Wms;
using Business.Domain.Warehouse;
using Business.Domain.Warehouse.Views;

namespace Business.Service.Contract
{
    [ServiceContract(SessionMode = SessionMode.NotAllowed)]
    public interface IWarehouseService
    {
        #region warehouse
        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "Warehouse/Get?warehouseId={warehouseId}")]
        Warehouse GetWarehouse(int warehouseId);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "Warehouse/GetAll")]
        List<Warehouse> GetAllWarehouse();

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "Warehouse/GetByQuery", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<Warehouse> GetWarehouseByQuery(Query query);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "Warehouse/GetByPagerQuery", Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<Warehouse> GetWarehouseByPagerQuery(PagerQuery query, out int qty);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "Warehouse/GetByCode?warehouseCode={warehouseCode}")]
        Warehouse GetWarehouseByCode(string warehouseCode);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "Warehouse/Create", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        int CreateWarehouse(Warehouse warehouse);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "Warehouse/Update", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        bool UpdateWarehouse(Warehouse warehouse);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "Warehouse/Delete?warehouseId={warehouseId}")]
        bool DeleteWarehouse(int warehouseId);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "Warehouse/GetUsers?warehouseId={warehouseId}")]
        List<User> GetWarehouseUsers(int warehouseId);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "Warehouse/AddUser?warehouseId={warehouseId}&userId={userId}")]
        bool AddWarehouseUser(int warehouseId, int userId);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "Warehouse/RemoveUser?warehouseId={warehouseId}&userId={userId}")]
        bool RemoveWarehouseUser(int warehouseId, int userId);
        #endregion

        #region area
        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "Area/Get?areaId={areaId}")]
        Area GetArea(int areaId);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "Area/GetAll")]
        List<Area> GetAllArea();

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "Area/GetByQuery", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<Area> GetAreaByQuery(Query query);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "Area/GetByPagerQuery", Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<Area> GetAreaByPagerQuery(PagerQuery query, out int qty);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "Area/GetByCode?warehouseCode={warehouseCode}&AreaCode={areaCode}")]
        Area GetAreaByCode(string warehouseCode, string areaCode);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "Area/Create", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        int CreateArea(Area area);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "Area/Update", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        bool UpdateArea(Area area);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "Area/Delete?areaId={areaId}")]
        bool DeleteArea(int areaId);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "Area/GetGroups?areaId={areaId}")]
        List<OperatorGroup> GetAreaGroups(int areaId);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "Group/AddUser?areaId={areaId}&operatorGroupId={operatorGroupId}")]
        bool AddAreaGroup(int areaId, int operatorGroupId);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "Group/RemoveUser?areaId={areaId}&operatorGroupId={operatorGroupId}")]
        bool RemoveAreaGroup(int areaId, int operatorGroupId);
        #endregion

        #region aisle
        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "Aisle/Get?aisleId={aisleId}")]
        Aisle GetAisle(int aisleId);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "Aisle/GetAll")]
        List<Aisle> GetAllAisle();

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "Aisle/GetByQuery", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<Aisle> GetAisleByQuery(Query query);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "Aisle/GetByPagerQuery", Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<Aisle> GetAisleByPagerQuery(PagerQuery query, out int qty);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "Aisle/GetByCode?applicationCode={warehouseCode}&aisleCode={aisleCode}")]
        Aisle GetAisleByCode(string warehouseCode, string aisleCode);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "Aisle/Create", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        int CreateAisle(Aisle aisle);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "Aisle/Update", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        bool UpdateAisle(Aisle aisle);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "Aisle/Delete?aisleId={aisleId}")]
        bool DeleteAisle(int aisleId);
        #endregion

        #region shelf
        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "Shelf/Get?shelfId={shelfId}")]
        Shelf GetShelf(int shelfId);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "Shelf/GetAll")]
        List<Shelf> GetAllShelf();

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "Shelf/GetByQuery", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<Shelf> GetShelfByQuery(Query query);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "Shelf/GetByPagerQuery", Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<Shelf> GetShelfByPagerQuery(PagerQuery query, out int qty);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "Shelf/GetByCode?applicationCode={warehouseCode}&shelfCode={shelfCode}")]
        Shelf GetShelfByCode(string warehouseCode, string shelfCode);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "Shelf/Create", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        int CreateShelf(Shelf shelf);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "Shelf/Update", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        bool UpdateShelf(Shelf shelf);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "Shelf/Delete?shelfId={shelfId}")]
        bool DeleteShelf(int shelfId);
        #endregion

        #region location
        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "Location/Get?typeId={locationId}")]
        Location GetLocation(int locationId);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "LocationView/Get?typeId={locationId}")]
        LocationView GetLocationView(int locationId);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "Location/GetAll")]
        List<Location> GetAllLocation();

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "Location/GetByQuery", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<Location> GetLocationByQuery(Query query);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "LocationView/GetByQuery", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<LocationView> GetLocationViewByQuery(Query query);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "Location/GetByPagerQuery", Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<Location> GetLocationByPagerQuery(PagerQuery query, out int qty);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "LocationView/GetByPagerQuery", Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<LocationView> GetLocationViewByPagerQuery(PagerQuery query, out int qty);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "Location/GetByCode?applicationCode={warehouseCode}&locationCode={locationCode}")]
        Location GetLocationByCode(string warehouseCode, string locationCode);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "Location/Create", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        [ServiceKnownType(typeof(LocationView))]
        int CreateLocation(Location location);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "Location/Update", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        [ServiceKnownType(typeof(LocationView))]
        bool UpdateLocation(Location location);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "Location/Delete?locationId={locationId}")]
        bool DeleteLocation(int locationId);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "{warehouse}/Location/GetReceivingLocation")]
        List<LocationView> GetReceivingLocation(string warehouseCode);
        #endregion

        #region operator group
        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "OperatorGroup/GetAll")]
        List<OperatorGroup> GetAllOperatorGroup();

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "OperatorGroup/GetByQuery", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<OperatorGroup> GetOperatorGroupByQuery(Query query);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "OperatorGroup/GetByCode?warehouseCode={warehouseCode}&groupName={groupName}")]
        OperatorGroup GetOperatorGroupByName(string warehouseCode, string groupName);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "OperatorGroup/Create", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        int CreateOperatorGroup(OperatorGroup operatorGroup);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "OperatorGroup/Update", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        bool UpdateOperatorGroup(OperatorGroup operatorGroup);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "OperatorGroup/Delete?operatorGroupId={operatorGroupId}")]
        bool DeleteOperatorGroup(int operatorGroupId);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "OperatorGroup/GetMembers?operatorGroupId={operatorGroupId}")]
        List<User> GetGroupMembers(int operatorGroupId);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "OperatorGroup/AddUser?operatorGroupId={operatorGroupId}&userId={userId}")]
        bool AddGroupMember(int operatorGroupId, int userId);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "OperatorGroup/RemoveUser?operatorGroupId={operatorGroupId}&userId={userId}")]
        bool RemoveGroupMember(int operatorGroupId, int userId);
        #endregion

        #region container type
        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "ContainerType/Get?typeId={typeId}")]
        ContainerType GetContainerType(int typeId);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "ContainerType/GetAll")]
        List<ContainerType> GetAllContainerType();

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "ContainerType/GetByQuery", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<ContainerType> GetContainerTypeByQuery(Query query);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "ContainerType/GetByPagerQuery", Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<ContainerType> GetContainerTypeByPagerQuery(PagerQuery query, out int qty);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "ContainerType/GetByCode?applicationCode={warehouseCode}&containerTypeCode={containerTypeCode}")]
        ContainerType GetContainerTypeByCode(string warehouseCode, string containerTypeCode);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "ContainerType/Create", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        int CreateContainerType(ContainerType containerType);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "ContainerType/Update", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        bool UpdateContainerType(ContainerType containerType);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "ContainerType/Delete?containerTypeId={containerTypeId}")]
        bool DeleteContainerType(int containerTypeId);
        #endregion

        #region container
        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "Container/Get?typeId={containerId}")]
        Container GetContainer(int containerId);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "Container/GetAll")]
        List<Container> GetAllContainer();

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "Container/GetByQuery", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<Container> GetContainerByQuery(Query query);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "Container/GetByPagerQuery", Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<Container> GetContainerByPagerQuery(PagerQuery query, out int qty);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "Container/GetByCode?warehouseCode={warehouseCode}&containerCode={containerCode}")]
        Container GetContainerByCode(string warehouseCode, string containerCode);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "Container/Create", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        int CreateContainer(Container container);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "Container/Update", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        bool UpdateContainer(Container container);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "Container/Delete?ContainerId={ContainerId}")]
        bool DeleteContainer(int containerId);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "Container/GetByBarcode?applicationCode={warehouseCode}&barcode={barcode}")]
        Container GetTransferContainerByBarcode(string warehouseCode, string barcode);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "Container/GetByBarcode?applicationCode={warehouseCode}&barcode={barcode}")]
        Container GetStorageContainerByBarcode(string warehouseCode, string barcode);
        #endregion

        #region setting
        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "Setting/Get?settingId={settingId}")]
        Setting GetSetting(int settingId);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "Setting/GetAll")]
        List<Setting> GetAllSetting();

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "Setting/GetByQuery", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<Setting> GetSettingByQuery(Query query);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "Setting/GetByPagerQuery", Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<Setting> GetSettingByPagerQuery(PagerQuery query, out int qty);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "Setting/GetByCode?applicationCode={warehouseCode}&settingCode={settingCode}")]
        Setting GetSettingByCode(string warehouseCode, string settingCode);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "Setting/Create", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        int CreateSetting(Setting setting);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "Setting/Update", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        bool UpdateSetting(Setting setting);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "Setting/Delete?settingId={settingId}")]
        bool DeleteSetting(int settingId);
        #endregion

        #region safety stock
        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "SafetyStock/Create", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        int CreateSafetyStock(SafetyStock safetyStock);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "SafetyStock/Update", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        bool UpdateSafetyStock(SafetyStock safetyStock);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "SafetyStock/Delete?safetyStockId={safetyStockId}")]
        bool DeleteSafetyStock(int safetyStockId);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "SafetyStock/Get?applicationCode={warehouseCode}&skuId={skuId}")]
        SafetyStock GetSafetyStock(string warehouseCode, int skuId);
        #endregion

        #region location safety stock
        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "LocationSafetyStock/Create", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        int CreateLocationSafetyStock(LocationSafetyStock locationSafetyStock);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "LocationSafetyStock/Update", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        bool UpdateLocationSafetyStock(LocationSafetyStock locationSafetyStock);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "LocationSafetyStock/Delete?locationSafetyStockId={locationSafetyStockId}")]
        bool DeleteLocationSafetyStock(int locationSafetyStockId);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "LocationSafetyStock/Get?applicationCode={warehouseCode}&skuId={skuId}&locationId={locationId}")]
        LocationSafetyStock GetLocationSafetyStock(string warehouseCode, int skuId, int locationId);
        #endregion

        #region tag
        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "Tag/Get?tagId={tagId}")]
        Tag GetTag(int tagId);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "Tag/GetAll")]
        List<Tag> GetAllTag();

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "Tag/GetByQuery", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<Tag> GetTagByQuery(Query query);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "Tag/GetByPagerQuery", Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<Tag> GetTagByPagerQuery(PagerQuery query, out int qty);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "Tag/GetByCode?applicationCode={warehouseCode}&tagNumber={tagNumber}")]
        Tag GetTagByNumber(string warehouseCode, string tagNumber);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "Tag/Create", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        int CreateTag(Tag tag);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "Tag/Update", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        bool UpdateTag(Tag tag);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "Tag/Delete?TagId={tagId}")]
        bool DeleteTag(int tagId);
        #endregion

        #region Sku Tag
        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "SkuTag/GetByPagerQuery", Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<SkuTag> GetSkuTagByPagerQuery(PagerQuery query, out int qty);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "SkuTagView/GetByPagerQuery", Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<SkuTagView> GetSkuTagViewByPagerQuery(PagerQuery query, out int qty);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "SkuTag/GetByQuery", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<SkuTag> GetSkuTagByQuery(Query query);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "SkuTag/GetByQuery", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<SkuTagView> GetSkuTagViewByQuery(Query query);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "SkuTag/Create", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        [ServiceKnownType(typeof(SkuTagView))]
        int CreateSkuTag(SkuTag skutag);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "SkuTag/Update", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        [ServiceKnownType(typeof(SkuTagView))]
        bool UpdateSkuTag(SkuTag skutag);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "SkuTag/Delete?id={id}")]
        bool DeleteSkuTag(int id);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "SkuTag/GetView?id={id}")]
        SkuTagView GetSkuTagView(int id);
        #endregion

        #region Location Tag
        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "LocationTag/GetByPagerQuery", Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<LocationTag> GetLocationTagByPagerQuery(PagerQuery query, out int qty);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "LocationTagView/GetByPagerQuery", Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<LocationTagView> GetLocationTagViewByPagerQuery(PagerQuery query, out int qty);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "LocationTag/GetByQuery", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<LocationTag> GetLocationTagByQuery(Query query);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "LocationTagView/GetByQuery", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<LocationTagView> GetLocationTagViewByQuery(Query query);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "LocationTag/Create", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        [ServiceKnownType(typeof(LocationTagView))]
        int CreateLocationTag(LocationTag locationtag);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "LocationTag/Update", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        [ServiceKnownType(typeof(LocationTagView))]
        bool UpdateLocationTag(LocationTag locationtag);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "LocationTag/Delete?SkuTagId={locationtagId}")]
        bool DeleteLocationTag(int locationtagId);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "LocationTag/GetView?id={id}")]
        LocationTagView GetLocationTagView(int id);
        #endregion
    }
}
