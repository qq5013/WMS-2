using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using Business.Common.Exception;
using Business.Common.QueryModel;
using Business.Domain.Application;

namespace Business.Service.Contract
{
    [ServiceContract(SessionMode = SessionMode.NotAllowed)]
    public interface ITestService
    {
        #region test
        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "Application")]
        List<Application> GetAllApplication();

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "Application", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<Application> GetApplicationByQuery(Query query);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "Application/{applicationCode}")]
        Application GetApplicationByCode(string applicationCode);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "Application", Method = "PUT", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        Application CreateApplication(Application application);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "Application", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        bool UpdateApplication(Application application);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "Application", Method = "DELETE", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        bool DeleteApplication(Application application);
        #endregion
    }
}
