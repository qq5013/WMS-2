using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using Business.Common.Exception;
using Business.Common.QueryModel;
using Business.Domain.Application;
using Business.Domain.Inventory;
using Business.Domain.Inventory;
using Business.Domain.Inventory.Views;

namespace Business.Service.Contract
{
    [ServiceContract(SessionMode = SessionMode.NotAllowed)]
    public interface IInventoryService
    {
        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        List<Stock> GetStocksByWarehouse(int warehouseId);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        List<Stock> GetStocksByLocation(int warehouseId, string locationBarcode);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        List<Stock> GetStocksByContainer(int warehouseId, string containerBarcode);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        List<Stock> GetStocksBySku(int warehouseId, string skuBarcode);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        List<Stock> GetStocksByBatch(int warehouseId, string skuBarcode, string batchNumber);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        Stock GetStock(int warehouseId, int locationId, int containerId, int skuId, int packId, string batchNumber);


        #region Stock
        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "Stock/GetByPagerQuery", Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<Stock> GetStockByPagerQuery(PagerQuery query, out int qty);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "Stock/GetByPagerQueryView", Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<StockView> GetStockViewByPagerQuery(PagerQuery query, out int qty);
        #endregion

        #region Stock Log
        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "StockLog/GetByPagerQuery", Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<StockLog> GetStockLogByPagerQuery(PagerQuery query, out int qty);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "StockLogView/GetByPagerQueryView", Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<StockLogView> GetStockLogViewByPagerQuery(PagerQuery query, out int qty);
        #endregion

        #region counting bill
        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        string CreateCountBill(int warehouseId, string areaCode, string locationCode, string inboundPlanNumber, string inboundBillNumber, string skuNumber, string batchNumber, int operatorId);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        //[WebGet(UriTemplate = "OutboundPlan/Get?planId={planId}")]
        CountBill GetCountBill(int billId);


        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        //[WebGet(UriTemplate = "OutboundPlan/Confirm?warehouseId={warehouseId}&planId={planId}&userId={userId}")]
        bool ConfirmCountBill(int warehouseId, int billId, int userId);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
       // [WebGet(UriTemplate = "OutboundPlan/Revoke?warehouseId={warehouseId}&planId={planId}&userId={userId}")]
        bool RevokeCountBill(int warehouseId, int billId, int userId);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        //[WebGet(UriTemplate = "OutboundPlan/GetDetailView?planId={planId}")]
        List<CountBillDetailView> GetCountBillDetailView(int billId);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        //[WebInvoke(UriTemplate = "OutboundPlan/GetByPagerQuery", Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<CountBill> GetCountBillByPagerQuery(PagerQuery query, out int qty);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        bool UploadCountingResult(int warehouseId, int countBillId, List<CountBillDetailView> resultList, int operatorId);
        #endregion
    }
}
