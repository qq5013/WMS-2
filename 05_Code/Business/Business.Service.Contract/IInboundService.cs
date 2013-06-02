using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using Business.Common.Exception;
using Business.Common.QueryModel;
using Business.Domain.Inventory;
using Business.Domain.Inventory.Views;
using Business.Domain.Report;

namespace Business.Service.Contract
{
    [ServiceContract(SessionMode = SessionMode.NotAllowed)]
    public interface IInboundService
    {
        #region inbound plan        
        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "InboundPlan/Get?planId={planId}")]
        InboundPlan GetInboundPlan(int planId);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "InboundPlan/GetByQuery", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<InboundPlan> GetInboundPlanByQuery(Query query);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "InboundPlan/GetByPagerQuery", Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<InboundPlan> GetInboundPlanByPagerQuery(PagerQuery query, out int qty);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "InboundPlan/GetByCode?warehouseCode={warehouseCode}&planNumber={planNumber}")]
        InboundPlan GetInboundPlanByNumber(string warehouseCode, string planNumber);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "InboundPlan/GetNewNumber?warehouseId={warehouseId}")]
        string GetInboundPlanNewNumber(int warehouseId);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "InboundPlan/Create", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        InboundPlan CreateInboundPlan(InboundPlan inboundPlan);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "InboundPlan/Update", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        bool UpdateInboundPlan(InboundPlan inboundPlan);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "InboundPlan/Confirm?warehouseId={warehouseId}&planId={planId}&userId={userId}")]
        bool ConfirmInboundPlan(int warehouseId, int planId, int userId);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "InboundPlan/Close?warehouseId={warehouseId}&planId={planId}&userId={userId}")]
        bool CloseInboundPlan(int warehouseId, int planId, int userId);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "InboundPlan/Revoke?warehouseId={warehouseId}&planId={planId}&userId={userId}")]
        bool RevokeInboundPlan(int warehouseId, int planId, int userId);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "InboundPlan/AddDetail", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        int AddInboundPlanDetail(int inboundPlanId, InboundPlanDetail planDetail);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "InboundPlan/UpdateDetail", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        bool UpdateInboundPlanDetail(InboundPlanDetail planDetail);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "InboundPlan/RemoveDetail?planDetailId={planDetailId}")]
        bool RemoveInboundPlanDetail(int planDetailId);
        
        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "InboundPlan/Import?clientCode={clientCode}", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        bool ImportInboundPlan(string clientCode, string message);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "InboundPlan/GetDetails?planId={planId}")]
        List<InboundPlanDetail> GetInboundPlanDetails(int planId);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "InboundPlan/GetDetailView?planId={planId}")]
        List<InboundPlanDetailView> GetInboundPlanDetailView(int planId);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "InboundPlan/GetBillsByPlan?planId={planId}")]
        List<InboundBill> GetInboundBillsByPlan(int planId);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "InboundPlan/GetSerialNumbersByPlan?planId={planId}")]
        List<SerialNumber> GetSerialNumbersByPlan(int planId);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "InboundPlan/CreateSerialNumber?warehouseId={warehouseId}&planId={planId}&skuId={skuId}&packId={packId}&qty={qty}&userId={userId}")]
        List<SerialNumber> CreateSerialNumber(int warehouseId, int planId, int skuId, int packId, int qty,
                                                            int userId);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "InboundPlan/GetReport?planId={planId}&operatorId={operatorId}")]
        InboundPlanReportEntity GetInboundPlanReport(int planId, int operatorId);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "InboundPlan/{warehouseCode}/GetNewBatchNumber")]
        string GetNewBatchNumber(string warehouseCode);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "InboundPlan/{warehouseCode}/GetTasks")]
        List<string> GetReceivingTasks(string warehouseCode);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "InboundPlan/UploadReceivingPreparation", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string UploadReceivingPreparation(ReceivingPreparation receivingPreparation);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "InboundPlan/GetInboundTaskByPlan?planId={planId}")]
        List<InboundTask> GetInboundTaskByPlan(int planId);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "InboundPlan/GetInboundTaskDetail?taskId={taskId}")]
        List<InboundTaskDetailView> GetInboundTaskDetail(int taskId);
        #endregion

        #region inbound bill
        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "InboundBill/Get?billId={billId}")]
        InboundBill GetInboundBill(int billId);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "InboundBill/GetByQuery", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<InboundBill> GetInboundBillByQuery(Query query);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "InboundBill/GetByPagerQuery", Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<InboundBill> GetInboundBillByPagerQuery(PagerQuery query, out int qty);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "InboundBill/GetByCode?warehouseCode={warehouseCode}&billNumber={planNumber}")]
        InboundBill GetInboundBillByNumber(string warehouseCode, string billNumber);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "InboundBill/GetNewNumber?warehouseId={warehouseId}")]
        string GetInboundBillNewNumber(int warehouseId);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "InboundBill/Create", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        InboundBill CreateInboundBill(InboundBill inboundBill);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "InboundBill/Update", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        bool UpdateInboundBill(InboundBill inboundBill);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "InboundBill/Confirm?warehouseId={warehouseId}&planId={planId}&userId={userId}")]
        bool ConfirmInboundBill(int warehouseId, int planId, int userId);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "InboundBill/Revoke?warehouseId={warehouseId}&billId={billId}&userId={userId}")]
        bool RevokeInboundBill(int warehouseId, int billId, int userId);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "InboundBill/AddDetail", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        int AddInboundBillDetail(int inboundBillId, InboundBillDetail billDetail);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "InboundBill/UpdateDetail", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        bool UpdateInboundBillDetail(InboundBillDetail billDetail);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "InboundBill/RemoveDetail?billDetailId={billDetailId}")]
        bool RemoveInboundBillDetail(int billDetailId);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "InboundBill/Import?clientCode={clientCode}", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        bool ImportInboundBill(string clientCode, string message);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "InboundBill/GetDetails?billId={billId}")]
        List<InboundBillDetail> GetInboundBillDetails(int billId);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "InboundBill/GetDetailView?billId={billId}")]
        List<InboundBillDetailView> GetInboundBillDetailView(int billId);

        //[OperationContract]
        //[FaultContract(typeof(ServiceError))]
        //[WebGet(UriTemplate = "InboundBill/GetDetailView?billId={billId}")]
        //BillSn AddBillSN(int warehouseId, BillType billType, int billId, int skuId, int packId, string batchNumber, string sn);

        //[OperationContract]
        //[FaultContract(typeof(ServiceError))]
        //[WebGet(UriTemplate = "InboundBill/GetDetailView?billId={billId}")]
        //bool RemoveBillSN(int billsnId);

        //[OperationContract]
        //[FaultContract(typeof(ServiceError))]
        //[WebGet(UriTemplate = "InboundBill/GetBillsByBill?billId={billId}")]
        //List<InboundBill> GetInboundBillsByPlan(int billId);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "InboundBill/GetDetailView?billId={billId}")]
        List<BillSn> GetSerialNumbersByBill(int billId);

        //[OperationContract]
        //[FaultContract(typeof(ServiceError))]
        //[WebGet(UriTemplate = "InboundBill/CreateSerialNumber?warehouseId={warehouseId}&billId={planId}&skuId={skuId}&packId={packId}&qty={qty}&userId={userId}")]
        //List<SerialNumber> CreateSerialNumber(int warehouseId, int billId, int skuId, int packId, int qty, int userId);

        #endregion

        #region inbound batch

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "InboundBatch/Create", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        InboundBatch CreateInboundBatch(InboundBatch inboundBatch);
        #endregion

        #region serial number
        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "SerialNumber/Get?planId={planId}&skuId={skuId}&packId={packId}&sn={sn}")]
        SerialNumber GetSerialNumber(int planId, int skuId, int packId, string sn);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "BillSn/Get?skuId={skuId}&packId={packId}&sn={sn}")]
        BillSn GetBillSn(int skuId, int packId, string sn);
        #endregion

    }
}
