using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using Business.Common.Exception;
using Business.Common.QueryModel;
using Business.Domain.Wms;

namespace Business.Service.Contract
{
    [ServiceContract(SessionMode = SessionMode.NotAllowed)]
    public interface IBasicDataService
    {
        #region district
        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "District/GetAll")]
        List<District> GetAllDistrict();

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "District/Get?districtId={districtId}")]
        District GetDistrict(int districtId);


        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "District/GetByQuery", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<District> GetDistrictByQuery(Query query);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "District/GetByCode?districtCode={districtCode}")]
        District GetDistrictByCode(string districtCode);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "District/Create", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        int CreateDistrict(District district);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "District/Update", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        bool UpdateDistrict(District district);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "District/Delete?districtId={districtId}")]
        bool DeleteDistrict(int districtId);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "District/GetByLevel?districtLevel={districtLevel}")]
        List<District> GetDistrictByLevel(int districtLevel);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "District/GetByParent?parentId={parentId}")]
        List<District> GetDistrictByParent(int parentId);
        #endregion

        #region company
        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "Company/Get?companyId={companyId}")]
        Company GetCompany(int companyId);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "Company/GetAll")]
        List<Company> GetAllCompany();

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "Company/GetByQuery", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<Company> GetCompanyByQuery(Query query);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "Company/GetByPagerQuery", Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<Company> GetCompanyByPagerQuery(PagerQuery query, out int qty);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "Company/GetByCode?companyCode={companyCode}")]
        Company GetCompanyByCode(string companyCode);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "Company/Create", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        int CreateCompany(Company company);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "Company/Update", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        bool UpdateCompany(Company company);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "Company/Delete?companyId={companyId}")]
        bool DeleteCompany(int companyId);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "Company/GetByType?companyTypeId={companyTypeId}")]
        List<Company> GetCompanyByType(int companyTypeId);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "Company/GetCompanyTypes?companyId={companyId}")]
        List<CompanyType> GetCompanyTypes(int companyId);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "Company/AddType?companyId={companyId}&companyTypeId={companyTypeId}")]
        bool AddCompanyType(int companyId, int companyTypeId);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "Company/RemoveType?companyId={companyId}&companyTypeId={companyTypeId}")]
        bool RemoveCompanyType(int companyId, int companyTypeId);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "Company/UpdateType?companyId={companyId}", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        void UpdateCompanyType(int companyId, string companyTypeIds);
        #endregion

        #region category management
        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "CategoryManagement/GetAll")]
        List<CategoryManagement> GetAllCategoryManagement();

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "CategoryManagement/Get?categoryId={categoryId}")]
        CategoryManagement GetCategoryManagement(int categoryId);


        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "CategoryManagement/GetByQuery", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<CategoryManagement> GetCategoryManagementByQuery(Query query);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "CategoryManagement/GetByCode?categoryCode={categoryCode}")]
        CategoryManagement GetCategoryManagementByCode(string categoryCode);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "CategoryManagement/Create", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        int CreateCategoryManagement(CategoryManagement categoryManagement);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "CategoryManagement/Update", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        bool UpdateCategoryManagement(CategoryManagement categoryManagement);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "CategoryManagement/Delete?categoryId={categoryId}")]
        bool DeleteCategoryManagement(int categoryId);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "CategoryManagement/GetByLevel?categoryLevel={categoryLevel}")]
        List<CategoryManagement> GetCategoryManagementByLevel(int categoryLevel);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "CategoryManagement/GetByParent?parentId={parentId}")]
        List<CategoryManagement> GetCategoryManagementByParent(int parentId);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "CategoryManagement/GetBatchProperty?categoryId={categoryId}")]
        List<BatchProperty> GetBatchPropertyByCategory(int categoryId);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "CategoryManagement/SaveBatchProperty?categoryId={categoryId}", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        bool SaveCategoryBatchProperty(int categoryId, List<BatchProperty> batchProperties);
        #endregion

        #region batch property
        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "BatchProperty/GetByQuery", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<BatchProperty> GetBatchPropertyByQuery(Query query);


        #endregion 

        //#region sku




        //[OperationContract]
        //[FaultContract(typeof(ServiceError))]
        //[WebInvoke(UriTemplate = "Sku/Create", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        //int CreateSku(Sku sku);

        //[OperationContract]
        //[FaultContract(typeof(ServiceError))]
        //[WebInvoke(UriTemplate = "Sku/Update", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        //[ServiceKnownType(typeof(Sku))]
        //[ServiceKnownType(typeof(SkuView))]
        //bool UpdateSku(Sku sku);

        //[OperationContract]
        //[FaultContract(typeof(ServiceError))]
        //[WebGet(UriTemplate = "Sku/Delete?skuId={skuId}")]
        //bool DeleteSku(int skuId);

        //#endregion
    }
}
