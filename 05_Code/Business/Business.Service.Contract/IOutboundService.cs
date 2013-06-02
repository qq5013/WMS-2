using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using Business.Common.Exception;
using Business.Common.QueryModel;
using Business.Domain.Warehouse;
using Business.Domain.Inventory;
using Business.Domain.Inventory.Views;
using Business.Component;
using Business.Common.DataDictionary;

namespace Business.Service.Contract
{
    [ServiceContract(SessionMode = SessionMode.NotAllowed)]
    public interface IOutboundService
    {
        #region outbound plan
        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "OutboundPlan/Get?planId={planId}")]
        OutboundPlan GetOutboundPlan(int planId);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "OutboundPlan/GetByQuery", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<OutboundPlan> GetOutboundPlanByQuery(Query query);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "OutboundPlan/GetByPagerQuery", Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<OutboundPlan> GetOutboundPlanByPagerQuery(PagerQuery query, out int qty);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "OutboundPlan/GetByCode?warehouseCode={warehouseCode}&planNumber={planNumber}")]
        OutboundPlan GetOutboundPlanByNumber(string warehouseCode, string planNumber);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "OutboundPlan/GetNewNumber?warehouseId={warehouseId}")]
        string GetOutboundPlanNewNumber(int warehouseId);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "OutboundPlan/Create", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        OutboundPlan CreateOutboundPlan(OutboundPlan outboundPlan);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "OutboundPlan/Update", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        bool UpdateOutboundPlan(OutboundPlan outboundPlan);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "OutboundPlan/Confirm?warehouseId={warehouseId}&planId={planId}&userId={userId}")]
        bool ConfirmOutboundPlan(int warehouseId, int planId, int userId);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "OutboundPlan/Close?warehouseId={warehouseId}&planId={planId}&userId={userId}")]
        bool CloseOutboundPlan(int warehouseId, int planId, int userId);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "OutboundPlan/Revoke?warehouseId={warehouseId}&planId={planId}&userId={userId}")]
        bool RevokeOutboundPlan(int warehouseId, int planId, int userId);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "OutboundPlan/AddDetail", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        int AddOutboundPlanDetail(int outboundPlanId, OutboundPlanDetail planDetail);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "OutboundPlan/UpdateDetail", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        bool UpdateOutboundPlanDetail(OutboundPlanDetail planDetail);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "OutboundPlan/RemoveDetail?planDetailId={planDetailId}")]
        bool RemoveOutboundPlanDetail(int planDetailId);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "OutboundPlan/Import?clientCode={clientCode}", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        bool ImportOutboundPlan(string clientCode, string message);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "OutboundPlan/GetDetails?planId={planId}")]
        List<OutboundPlanDetail> GetOutboundPlanDetails(int planId);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "OutboundPlan/GetDetailView?planId={planId}")]
        List<OutboundPlanDetailView> GetOutboundPlanDetailView(int planId);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "OutboundPlan/GetBillsByPlan?planId={planId}")]
        List<OutboundBill> GetOutboundBillsByPlan(int planId);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "OutboundPlan/GetSerialNumbersByPlan?planId={planId}")]
        List<SerialNumber> GetSerialNumbersByPlan(int planId);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "OutboundPlan/CreateSerialNumber?warehouseId={warehouseId}&planId={planId}&skuId={skuId}&packId={packId}&qty={qty}&userId={userId}")]
        List<SerialNumber> CreateSerialNumber(int warehouseId, int planId, int skuId, int packId, int qty,
                                                            int userId);
        #endregion

        #region outbound bill
        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "OutboundBill/Get?billId={billId}")]
        OutboundBill GetOutboundBill(int billId);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "OutboundBill/GetByQuery", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<OutboundBill> GetOutboundBillByQuery(Query query);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "OutboundBill/GetByPagerQuery", Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<OutboundBill> GetOutboundBillByPagerQuery(PagerQuery query, out int qty);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "OutboundBill/GetByCode?warehouseCode={warehouseCode}&billNumber={planNumber}")]
        OutboundBill GetOutboundBillByNumber(string warehouseCode, string billNumber);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "OutboundBill/GetNewNumber?warehouseId={warehouseId}")]
        string GetOutboundBillNewNumber(int warehouseId);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "OutboundBill/Create", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        OutboundBill CreateOutboundBill(OutboundBill outboundBill);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "OutboundBill/Update", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        bool UpdateOutboundBill(OutboundBill outboundBill);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "OutboundBill/Confirm?warehouseId={warehouseId}&planId={planId}&userId={userId}")]
        bool ConfirmOutboundBill(int warehouseId, int planId, int userId);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "OutboundBill/Revoke?warehouseId={warehouseId}&billId={billId}&userId={userId}")]
        bool RevokeOutboundBill(int warehouseId, int billId, int userId);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "OutboundBill/AddDetail", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        int AddOutboundBillDetail(int outboundBillId, OutboundBillDetail billDetail);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "OutboundBill/UpdateDetail", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        bool UpdateOutboundBillDetail(OutboundBillDetail billDetail);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "OutboundBill/RemoveDetail?billDetailId={billDetailId}")]
        bool RemoveOutboundBillDetail(int billDetailId);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "OutboundBill/Import?clientCode={clientCode}", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        bool ImportOutboundBill(string clientCode, string message);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "OutboundBill/GetDetails?billId={billId}")]
        List<OutboundBillDetail> GetOutboundBillDetails(int billId);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "OutboundBill/GetDetailView?billId={billId}")]
        List<OutboundBillDetailView> GetOutboundBillDetailView(int billId);

        //[OperationContract]
        //[FaultContract(typeof(ServiceError))]
        //[WebGet(UriTemplate = "OutboundBill/GetDetailView?billId={billId}")]
        //BillSn AddBillSN(int warehouseId, BillType billType, int billId, int skuId, int packId, string batchNumber, string sn);

        //[OperationContract]
        //[FaultContract(typeof(ServiceError))]
        //[WebGet(UriTemplate = "OutboundBill/GetDetailView?billId={billId}")]
        //bool RemoveBillSN(int billsnId);

        //[OperationContract]
        //[FaultContract(typeof(ServiceError))]
        //[WebGet(UriTemplate = "OutboundBill/GetBillsByBill?billId={billId}")]
        //List<OutboundBill> GetOutboundBillsByPlan(int billId);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "OutboundBill/GetDetailView?billId={billId}")]
        List<BillSn> GetSerialNumbersByBill(int billId);

        //[OperationContract]
        //[FaultContract(typeof(ServiceError))]
        //[WebGet(UriTemplate = "OutboundBill/CreateSerialNumber?warehouseId={warehouseId}&billId={planId}&skuId={skuId}&packId={packId}&qty={qty}&userId={userId}")]
        //List<SerialNumber> CreateSerialNumber(int warehouseId, int billId, int skuId, int packId, int qty, int userId);

        #endregion
    }
}
