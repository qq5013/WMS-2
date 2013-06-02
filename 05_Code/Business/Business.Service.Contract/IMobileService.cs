using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using Business.Domain.Application;
using System.ServiceModel;
using System.ServiceModel.Web;
using Business.Common.Exception;
using Business.Common.QueryModel;
using Business.Domain.Application;
using Business.Domain.Wms;
using Business.Domain.Warehouse;
using Business.Domain.Mobile;
using Business.Domain;
using System.ServiceModel.Activation;
using Business.Domain.Inventory.Views;
using Business.Domain.Inventory;

namespace Business.Service.Contract
{
    [ServiceContract(SessionMode = SessionMode.NotAllowed)]
    public interface IMobileService
    {
        #region test
        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "Warehouse/Create", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        Warehouse CreateWarehouse(Warehouse warehouse);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "Test/CreateData")]
        void CreateTestData();
        #endregion

        #region application
        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "Server/GetDataTime")]
        string GetServerDateTime();

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "Hello/{name}")]
        string Hello(string name);
        #endregion

        #region login
        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "Warehouse/GetAll")]
        List<Warehouse> GetAllWarehouse();

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "Warehouse/{warehouseCode}/GetUsers")]
        List<User> GetWarehouseUsers(string warehouseCode);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "User/Validate/{warehouseCode}/{userCode}/{password}")]
        User ValidateUser(string warehouseCode, string userCode, string password);
        #endregion

        #region receiving 
        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "Receiving/{warehouseCode}/GetTasks")]
        List<string> GetReceivingTasks(string warehouseCode);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "Receiving/GetTask/{billNumber}")]
        ReceivingTask GetReceivingTask(string billNumber);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "Location/GetReceivingLocation")]
        List<Location> GetReceivingLocation();

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "Receiving/UploadTaskResult", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        BoolResultObject UploadReceivingTaskResult(ReceivingTaskResult result);

        #endregion 

        #region stock
        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "Stock/Query/{warehouseCode}/{barcode}")]
        List<StockView> GetStockByBarcode(string warehouseCode, string barcode);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "Stock/QueryByLocation/{warehouseCode}/{locationBarcode}")]
        List<StockView> GetStockByLocation(string warehouseCode, string locationBarcode);
        #endregion

        #region putaway
        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "Putaway/{warehouseCode}/{strategyName}/GetLocations?barcode={barcode}&qty={qty}")]
        List<PutawayLocation> GetPutawayLocations(string warehouseCode, string strategyName, string barcode, int qty);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "Putaway/{warehouseCode}/GetTasks")]
        List<string> GetPutawayTasks(string warehouseCode);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "Putaway/GetTask/{billNumber}")]
        PutawayTask GetPutawayTask(string billNumber);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "Putaway/UploadTaskResult", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        BoolResultObject UploadPutawayTaskResult(PutawayTaskResult result);
        #endregion

        #region pick
        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "Pick/{warehouseCode}/GetTasks")]
        List<string> GetPickTasks(string warehouseCode);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "Pick/GetTask/{planNumber}")]
        PickTask GetPickTask(string planNumber);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "Pick/UploadTaskResult", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        BoolResultObject UploadPickTaskResult(PickTaskResult result);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "Pick/{warehouseCode}/{strategyName}/GetStocks/{skuNumber}")]
        List<PickingStock> GetPickingStock(string warehouseCode, string strategyName, string skuNumber);
        #endregion

        #region delivery
        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "Delivery/{warehouseCode}/GetTasks")]
        List<string> GetDeliveryTasks(string warehouseCode);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "Delivery/GetTask/{billNumber}")]
        DeliveryTask GetDeliveryTask(string billNumber);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "Delivery/GetBill/{billNumber}")]
        OutboundBill GetDeliveryBill(string billNumber);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "Delivery/UploadTaskResult", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        BoolResultObject UpdateDeliveryTask(OutboundBill outboundBill);
        #endregion

        #region transfer
        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "Warehouse/{warehouseCode}/Location/{barcode}")]
        LocationInfo GetLocationByBarcode(string warehouseCode, string barcode);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "Warehouse/{warehouseCode}/Container/{barcode}")]
        ContainerInfo GetContainerByBarcode(string warehouseCode, string barcode);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "{warehouseCode}/Transfer/UploadTransferResult?operatorId={operatorId}", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        BoolResultObject UploadTransferResult(string warehouseCode, List<TransferBillDetailView> transferResult, int operatorId);
        #endregion
    }
}
