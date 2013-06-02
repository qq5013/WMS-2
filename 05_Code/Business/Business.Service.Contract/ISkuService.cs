using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using Business.Common.Exception;
using Business.Common.QueryModel;
using Business.Domain.Wms;
using Business.Domain.Warehouse;

namespace Business.Service.Contract
{
    [ServiceContract(SessionMode = SessionMode.NotAllowed)]
    public interface ISkuService
    {
        #region sku
        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "SkuView/Get?skuId={skuId}")]
        SkuView GetSkuView(int skuId);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "SkuView/GetAll")]
        List<SkuView> GetAllSkuView();

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "SkuView/GetByQuery", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<SkuView> GetSkuViewByQuery(Query query);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "SkuView/GetByCode?SkuCode={SkuCode}")]
        SkuView GetSkuViewByNumber(string clientCode, string skuNumber);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "Sku/GetAll")]
        List<Sku> GetAllSku();

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "Sku/GetByQuery", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<Sku> GetSkuByQuery(Query query);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "Sku/GetByPagerQuery", Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<SkuView> GetSkuViewByPagerQuery(PagerQuery query, out int qty);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "Sku/GetByCode?clientCode={clientCode}&skuNumber={skuNumber}")]
        Sku GetSkuByNumber(string clientCode, string skuNumber);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "Sku/Create", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        [ServiceKnownType(typeof(SkuView))]
        int CreateSku(Sku sku); 

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "Sku/Update", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        [ServiceKnownType(typeof(SkuView))]
        bool UpdateSku(Sku sku);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "Sku/Delete?skuId={skuId}")]
        bool DeleteSku(int skuId);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "Sku/GetPiecePack?skuId={skuId}")]
        Pack GetPiecePack(int skuId);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "Sku/GetClient?skuId={skuId}")]
        Company GetSkuClient(int skuId);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "Sku/GetMerchant?skuId={skuId}")]
        Company GetSkuMerchant(int skuId);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "Sku/GetCategoryManagement?skuId={skuId}")]
        CategoryManagement GetCategoryManagement(int skuId);

        //[OperationContract]
        //[FaultContract(typeof(ServiceError))]
        //[WebGet(UriTemplate = "Sku/GetSkuManagement?skuId={skuId}")]
        //SkuManagement GetSkuManagement(int skuId);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "Sku/GetDefaultPack?skuId={skuId}")]
        Pack GetDefaultPack(int skuId);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "Sku/GetPacks?skuId={skuId}")]
        List<Pack> GetPacks(int skuId);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "Sku/GetBatchProperties?skuId={skuId}")]
        List<BatchProperty> GetBatchProperties(int skuId);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "Sku/GetAvailableLocations?warehouseId={warehouseId}&skuId={skuId}&areaType={areaType}")]
        List<Location> GetAvailableLocations(int warehouseId, int skuId, int areaType);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "Sku/GetAvailablePickLocations?warehouseId={warehouseId}&skuId={skuId}")]
        List<Location> GetAvailablePickLocations(int warehouseId, int skuId);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "Sku/GetAvailableStoreLocations?warehouseId={warehouseId}&skuId={skuId}")]
        List<Location> GetAvailableStoreLocations(int warehouseId, int skuId);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "Sku/GetPutawayPickLocations?warehouseId={warehouseId}&skuId={skuId}")]
        List<Location> GetPutawayPickLocations(int warehouseId, int skuId);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "Sku/GetPutawayStoreLocations?warehouseId={warehouseId}&skuId={skuId}")]
        List<Location> GetPutawayStoreLocations(int warehouseId, int skuId);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "Sku/SyncSkus?clientCode={clientCode}", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        bool SyncSkus(string clientCode, string message);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "Sku/UpdatePiecePack", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        bool UpdatePiecePack(Pack piecePack);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "Sku/GetSkuManagement?skuId={skuId}")]
        SkuManagement GetSkuManagement(int skuId);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "Sku/GetSkuManagementMode?skuId={skuId}")]
        SkuManagement GetSkuManagementMode(int skuId);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "Sku/MaintainSkuManagement", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        bool MaintainSkuManagement(int skuId, bool isActive, SkuManagement skuManagement);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "Sku/GetBatchProperty?skuId={skuId}")]
        List<BatchProperty> GetBatchPropertyBySku(int skuId);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "Sku/SaveBatchProperty?skuId={skuId}", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        bool SaveSkuBatchProperty(int skuId, List<BatchProperty> batchProperties);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "Sku/CreateImage", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        SkuImage CreateSkuImage(SkuImage skuImage);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "Sku/GetImage?skuId={skuId}&index={index}")]
        SkuImage GetSkuImage(int skuId, int index);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "Sku/GetImageCount?skuId={skuId}")]
        int GetSkuImageCount(int skuId);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "Sku/IsPieceManagement?skuId={skuId}")]
        bool IsPieceManagement(int skuId);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "Sku/IsBatchManagement?skuId={skuId}")]
        bool IsBatchManagement(int skuId);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "Sku/IsBarcodeManagement?skuId={skuId}")]
        bool IsBarcodeManagement(int skuId);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "Sku/IsContainerManagement?skuId={skuId}")]
        bool IsContainerManagement(int skuId);
        #endregion

    }
}
