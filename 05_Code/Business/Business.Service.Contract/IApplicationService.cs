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
    public interface IApplicationService
    {
        /*
         * 对外服务接口应尽可能通过Code访问
         * 对内接口应尽可能通过ID访问
        */ 
       
        #region server
        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "Server/Name/Get")]
        string GetServerName();

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "Server/IP/Get")]
        string GetServerIpAddress();

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "Server/DateTime/Get")]
        DateTime GetServerDateTime();
        #endregion

        #region application
        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "Application/Get")]
        List<Application> GetAllApplication();

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "Application/Query", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<Application> GetApplicationByQuery(Query query);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "Application/Get/{applicationCode}")]
        Application GetApplicationByCode(string applicationCode);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "Application/Create", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        int CreateApplication(Application application);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "Application/Update", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        bool UpdateApplication(Application application);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "Application/Delete?Id={Id}")]
        bool DeleteApplication(int Id);
        #endregion

        #region data dictionary
        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "DataDictionary/Get?Id={Id}")]
        DataDictionary GetDataDictionary(int Id);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "DataDictionary/Get")]
        List<DataDictionary> GetAllDataDictionary();

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "DataDictionary/Query", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<DataDictionary> GetDataDictionaryByQuery(Query query);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "{applicationCode}/DataDictionary/Get/{dictionaryCode}")]
        DataDictionary GetDataDictionaryByCode(string applicationCode, string dictionaryCode);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "DataDictionary/Create", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        int CreateDataDictionary(DataDictionary dictionary);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "DataDictionary/Update", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        bool UpdateDataDictionary(DataDictionary dictionary);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "DataDictionary/Delete?Id={Id}")]
        bool DeleteDataDictionary(int Id);
        #endregion

        #region function
        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "Function/GetAll")]
        List<Function> GetAllFunction();

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "Function/GetByQuery", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<Function> GetFunctionByQuery(Query query);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "Function/GetByCode?applicationCode={applicationCode}&functionCode={functionCode}")]
        Function GetFunctionByCode(string applicationCode, string functionCode);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "Function/Create", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        int CreateFunction(Function function);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "Function/Update", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        bool UpdateFunction(Function function);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "Function/Delete?functionId={functionId}")]
        bool DeleteFunction(int functionId);
        #endregion

        #region group
        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "Group/GetAll")]
        List<Group> GetAllGroup();

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "Group/GetByQuery", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<Group> GetGroupByQuery(Query query);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "Group/GetByCode?applicationCode={applicationCode}&groupCode={groupCode}")]
        Group GetGroupByCode(string applicationCode, string groupCode);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "Group/Create", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        int CreateGroup(Group group);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "Group/Update", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        bool UpdateGroup(Group group);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "Group/Delete?groupId={groupId}")]
        bool DeleteGroup(int groupId);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "Group/GetUsers?groupId={groupId}")]
        List<User> GetGroupUsers(int groupId);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "Group/AddUser?groupId={groupId}&userId={userId}")]
        bool AddGroupUser(int groupId, int userId);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "Group/RemoveUser?groupId={groupId}&userId={userId}")]
        bool RemoveGroupUser(int groupId, int userId);
        #endregion

        #region parameter

        [OperationContract]
        [FaultContract(typeof (ServiceError))]
        [WebGet(UriTemplate = "Parameter/Get?parameterId={parameterId}")]
        Parameter GetParameter(int parameterId);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "Parameter/GetAll")]
        List<Parameter> GetAllParameter();

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "Parameter/GetByQuery", Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<Parameter> GetParameterByQuery(Query query);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "Parameter/GetByPagerQuery", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<Parameter> GetParameterByPagerQuery(PagerQuery query, out int qty);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "Parameter/GetByCode?applicationCode={applicationCode}&parameterCode={parameterCode}")]
        Parameter GetParameterByCode(string applicationCode, string parameterCode);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "Parameter/Create", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        Parameter CreateParameter(Parameter parameter);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "Parameter/Update", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        bool UpdateParameter(Parameter parameter);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "Parameter/Delete?parameterId={parameterId}")]
        bool DeleteParameter(int parameterId);
        #endregion

        #region role
        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "Role/GetAll")]
        List<Role> GetAllRole();

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "Role/GetByQuery", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<Role> GetRoleByQuery(Query query);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "Role/GetByCode?applicationCode={applicationCode}&roleCode={roleCode}")]
        Role GetRoleByCode(string applicationCode, string roleCode);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "Role/Create", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        int CreateRole(Role role);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "Role/Update", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        bool UpdateRole(Role role);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "Role/Delete?roleId={roleId}")]
        bool DeleteRole(int roleId);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "Role/GetUsers?roleId={roleId}")]
        List<User> GetRoleUsers(int roleId);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "Role/AddUser?roleId={roleId}&userId={userId}")]
        bool AddRoleUser(int roleId, int userId);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "Role/RemoveUser?roleId={roleId}&userId={userId}")]
        bool RemoveRoleUser(int roleId, int userId);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "Role/GetFunctions?roleId={roleId}")]
        List<Function> GetRoleFunctions(int roleId);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "Role/AddFunction?roleId={roleId}&functionId={functionId}")]
        bool AddRoleFunction(int roleId, int functionId);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "Role/RemoveFunction?roleId={roleId}&functionId={functionId}")]
        bool RemoveRoleFunction(int roleId, int functionId);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "Role/GetGroups?roleId={roleId}")]
        List<Group> GetRoleGroups(int roleId);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "Role/AddGroup?roleId={roleId}&groupId={groupId}")]
        bool AddRoleGroup(int roleId, int groupId);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "Role/RemoveGroup?roleId={roleId}&groupId={groupId}")]
        bool RemoveRoleGroup(int roleId, int groupId);
        #endregion

        #region user
        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "User/Get?userId={userId}")]
        User GetUser(int userId);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "User/GetUserName?userId={userId}")]
        string GetUserName(int userId);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "User/GetAll")]
        List<User> GetAllUser();

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "User/GetByQuery", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<User> GetUserByQuery(Query query);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "User/GetByPagerQuery", Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<User> GetUserByPagerQuery(PagerQuery query, out int qty);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "User/GetByCode?applicationCode={applicationCode}&userCode={userCode}")]
        User GetUserByCode(string applicationCode, string userCode);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "User/Create", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        int CreateUser(User user);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "User/Update", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        bool UpdateUser(User user);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "User/Delete?userId={userId}")]
        bool DeleteUser(int userId);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "User/Validate?applicationCode={applicationCode}&userCode={userCode}&password={password}&warehouseId={warehouseId}")]
        User ValidateUser(string applicationCode, string userCode, string password, int warehouseId);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "User/GetFunctions?applicationCode={applicationCode}&userCode={userCode}")]
        List<string> GetUserFunctions(string applicationCode, string userCode);
        #endregion
    }
}