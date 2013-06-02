using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Activation;
using Business.Common.Exception;
using Business.Common.QueryModel;
using Business.DataAccess.Repository.Wms;
using Business.DataAccess.Repository;
using Business.Domain.Wms;
using Business.Service.Contract;
using Framework.Core.Collections;
using Business.Common.Toolkit;

namespace Business.Service
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class BasicDataService : IBasicDataService
    {
        #region district
        public List<District> GetAllDistrict()
        {
            try
            {
                var repository = new DistrictRepository();
                return CollectionHelper.ToList(repository.GetAll());
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return new List<District>();
        }

        public District GetDistrict(int districtId)
        {
            try
            {
                var repository = new DistrictRepository();
                return repository.Get(districtId);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return null;
        }

        public List<District> GetDistrictByQuery(Query query)
        {
            try
            {
                var repository = new DistrictRepository();
                return CollectionHelper.ToList(repository.GetListByQuery(query));
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return new List<District>();
        }

        public District GetDistrictByCode(string districtCode)
        {
            try
            {
                var repository = new DistrictRepository();
                return repository.GetByCode(districtCode);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return null;
        }

        public int CreateDistrict(District district)
        {
            try
            {
                var repository = new DistrictRepository();
                return repository.Create(district);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return 0;
        }

        public bool UpdateDistrict(District district)
        {
            try
            {
                var repository = new DistrictRepository();
                return repository.Update(district);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return false;
        }

        public bool DeleteDistrict(int districtId)
        {
            try
            {
                var repository = new DistrictRepository();
                return repository.Delete(districtId);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return false;
        }

        public List<District> GetDistrictByLevel(int districtLevel)
        {
            try
            {
                var repository = new DistrictRepository();
                return CollectionHelper.ToList(repository.GetByLevel(districtLevel));
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return new List<District>();
        }

        public List<District> GetDistrictByParent(int parentId)
        {
            try
            {
                var repository = new DistrictRepository();
                return CollectionHelper.ToList(repository.GetByParent(parentId));
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return new List<District>();
        }
        #endregion

        #region Company
        public Company GetCompany(int companyId)
        {
            try
            {
                var repository = new CompanyRepository();
                return repository.Get(companyId);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return null;
        }

        public List<Company> GetAllCompany()
        {
            try
            {
                var repository = new CompanyRepository();
                return CollectionHelper.ToList(repository.GetAll());
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return new List<Company>();
        }

        public List<Company> GetCompanyByQuery(Query query)
        {
            try
            {
                var repository = new CompanyRepository();
                return CollectionHelper.ToList(repository.GetListByQuery(query));
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return new List<Company>();
        }

        public List<Company> GetCompanyByPagerQuery(PagerQuery query, out int qty)
        {
            qty = 0;
            try
            {
                var repository = new CompanyRepository();
                return CollectionHelper.ToList(repository.GetByPager(query, out qty));
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return new List<Company>();
        }

        public Company GetCompanyByCode(string companyCode)
        {
            try
            {
                var repository = new CompanyRepository();
                return repository.GetByCode(companyCode);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return null;
        }

        public int CreateCompany(Company company)
        {
            try
            {
                var repository = new CompanyRepository();
                Company oldCompany = GetCompanyByCode(company.CompanyCode);
                if (oldCompany != null)
                    BusinessExceptionHelper.ThrowBusinessException("COMPANYCODE_EXISTS");
                
                company.CreateTime = TypeConvertHelper.DatetimeToString(DateTime.Now);
                return repository.Create(company);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return 0;
        }

        public bool UpdateCompany(Company company)
        {
            try
            {
                var repository = new CompanyRepository();
                Company oldCompany = GetCompanyByCode(company.CompanyCode);
                if (oldCompany != null && oldCompany.CompanyId != company.CompanyId)
                    BusinessExceptionHelper.ThrowBusinessException("COMPANYCODE_EXISTS");

                company.EditTime = TypeConvertHelper.DatetimeToString(DateTime.Now);
                return repository.Update(company);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return false;
        }

        public bool DeleteCompany(int companyId)
        {
            try
            {
                var repository = new CompanyRepository();
                return repository.Delete(companyId);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return false;
        }

        public List<Company> GetCompanyByType(int companyTypeId)
        {
            try
            {
                var repository = new CompanyRepository();
                return CollectionHelper.ToList(repository.GetByType(companyTypeId));
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return new List<Company>();
        }

        public List<CompanyType> GetCompanyTypes(int companyId)
        {
            try
            {
                var repository = new CompanyRepository();
                return CollectionHelper.ToList(repository.GetTypes(companyId));
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return new List<CompanyType>();
        }

        public bool AddCompanyType(int companyId, int companyTypeId)
        {
            try
            {
                var repository = new CompanyTypeRepository();
                return repository.AddType(companyId, companyTypeId);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return false;
        }

        public bool RemoveCompanyType(int companyId, int companyTypeId)
        {
            try
            {
                var repository = new CompanyTypeRepository();
                return repository.RemoveType(companyId, companyTypeId);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return false;
        }

        public void UpdateCompanyType(int companyId, string companyTypeIds)
        {
            try
            {
                string[] typeIds = companyTypeIds.Split(',');
                List<CompanyType> currentTypes = GetCompanyTypes(companyId);

                // add new types
                foreach (var strTypeId in typeIds)
                {
                    bool hasType = false;
                    int typeId = Int32.Parse(strTypeId);
                    foreach (var type in currentTypes)
                    {
                        if (type.CompanyTypeId == typeId)
                            hasType = true;
                    }

                    if (!hasType)
                    {
                        AddCompanyType(companyId, typeId);
                    }
                }

                // remove deleted types
                foreach (var type in currentTypes)
                {
                    bool hasType = false;
                    foreach (var strTypeId in typeIds)
                    {
                        int typeId = Int32.Parse(strTypeId);
                        if (type.CompanyTypeId == typeId)
                            hasType = true;
                    }

                    if (!hasType)
                    {
                        RemoveCompanyType(companyId, type.CompanyTypeId);
                    }
                }

            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }
        }
        #endregion

        #region categorymanagement
        public List<CategoryManagement> GetAllCategoryManagement()
        {
            try
            {
                var repository = new CategoryManagementRepository();
                return CollectionHelper.ToList(repository.GetAll());
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return new List<CategoryManagement>();
        }

        public CategoryManagement GetCategoryManagement(int categoryId)
        {
            try
            {
                var repository = new CategoryManagementRepository();
                return repository.Get(categoryId);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return null;
        }

        public List<CategoryManagement> GetCategoryManagementByQuery(Query query)
        {
            try
            {
                var repository = new CategoryManagementRepository();
                return CollectionHelper.ToList(repository.GetListByQuery(query));
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return new List<CategoryManagement>();
        }

        public CategoryManagement GetCategoryManagementByCode(string categoryCode)
        {
            try
            {
                var repository = new CategoryManagementRepository();
                return repository.GetByCode(categoryCode);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return null;
        }

        public int CreateCategoryManagement(CategoryManagement categoryManagement)
        {
            try
            {
                var repository = new CategoryManagementRepository();
                //categoryManagement.CreateTime = TypeConvertHelper.DatetimeToString(DateTime.Now);
                return repository.Create(categoryManagement);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return 0;
        }

        public bool UpdateCategoryManagement(CategoryManagement categoryManagement)
        {
            try
            {
                var repository = new CategoryManagementRepository();
                categoryManagement.EditTime = TypeConvertHelper.DatetimeToString(DateTime.Now);
                return repository.Update(categoryManagement);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return false;
        }

        public bool DeleteCategoryManagement(int categoryId)
        {
            try
            {
                var repository = new CategoryManagementRepository();
                return repository.Delete(categoryId);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return false;
        }

        public List<CategoryManagement> GetCategoryManagementByLevel(int categoryLevel)
        {
            try
            {
                var repository = new CategoryManagementRepository();
                return CollectionHelper.ToList(repository.GetByLevel(categoryLevel));
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return new List<CategoryManagement>();
        }

        public List<CategoryManagement> GetCategoryManagementByParent(int parentId)
        {
            try
            {
                var repository = new CategoryManagementRepository();
                return CollectionHelper.ToList(repository.GetByParent(parentId));
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return new List<CategoryManagement>();
        }

        public List<BatchProperty> GetBatchPropertyByCategory(int categoryId)
        {
            try
            {
                var repository = new CategoryManagementRepository();
                return CollectionHelper.ToList(repository.GetBatchProperty(categoryId));
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return new List<BatchProperty>();
        }


        public bool SaveCategoryBatchProperty(int categoryId, List<BatchProperty> batchProperties)
        {
            try
            {
                CategoryPropertyRepository categoryPropertyRepository = new CategoryPropertyRepository();

                // add new property
                List<BatchProperty> currentProperties = GetBatchPropertyByCategory(categoryId);
                foreach (var property in batchProperties)
                {
                    bool hasProperty = false;
                    foreach (var oldProperty in currentProperties)
                    {
                        if (property.PropertyId == oldProperty.PropertyId)
                        {
                            hasProperty = true;
                            break;
                        }
                    }
                    if (!hasProperty)
                    {
                        CategoryProperty insertProperty = new CategoryProperty()
                        {
                            CategoryId = categoryId,
                            PropertyId = property.PropertyId,
                            Priority = 0
                        };
                        categoryPropertyRepository.Create(insertProperty);
                    }
                }

                // remove old property
                foreach (var property in currentProperties)
                {
                    bool hasProperty = false;
                    foreach (var newProperty in batchProperties)
                    {
                        if (property.PropertyId == newProperty.PropertyId)
                        {
                            hasProperty = true;
                            break;
                        }
                    }
                    if (!hasProperty)
                    {
                        Query query = new Query();
                        query.Criteria.Add(new Criterion("PropertyId", CriteriaOperator.Equal, property.PropertyId));
                        query.Criteria.Add(new Criterion("CategoryId", CriteriaOperator.Equal, categoryId));
                        CategoryProperty deleteProperty = categoryPropertyRepository.GetByQuery(query);
                        if (deleteProperty != null)
                            categoryPropertyRepository.Delete(deleteProperty.Id);
                    }
                }
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return true;
        }
        #endregion

        #region batch property
        public List<BatchProperty> GetBatchPropertyByQuery(Query query)
        {
            try
            {
                var repository = new BatchPropertyRepository();
                return CollectionHelper.ToList(repository.GetListByQuery(query));
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return new List<BatchProperty>();
        }
        #endregion 

        //#region sku
        //public SkuView GetSku(int SkuId)
        //{
        //    try
        //    {
        //        var repository = new SkuViewRepository();
        //        return repository.Get(SkuId);
        //    }
        //    catch (Exception ex)
        //    {
        //        ServiceExceptionHelper.ThrowServiceException(ex);
        //    }

        //    return null;
        //}

        //public List<SkuView> GetAllSku()
        //{
        //    try
        //    {
        //        var repository = new SkuViewRepository();
        //        return CollectionHelper.ToList(repository.GetAll());
        //    }
        //    catch (Exception ex)
        //    {
        //        ServiceExceptionHelper.ThrowServiceException(ex);
        //    }

        //    return new List<SkuView>();
        //}

        //public List<SkuView> GetSkuByQuery(Query query)
        //{
        //    try
        //    {
        //        var repository = new SkuViewRepository();
        //        return CollectionHelper.ToList(repository.GetListByQuery(query));
        //    }
        //    catch (Exception ex)
        //    {
        //        ServiceExceptionHelper.ThrowServiceException(ex);
        //    }

        //    return new List<SkuView>();
        //}

        //public List<SkuView> GetSkuByPagerQuery(PagerQuery query, out int qty)
        //{
        //    qty = 0;
        //    try
        //    {
        //        var repository = new SkuViewRepository();
        //        return CollectionHelper.ToList(repository.GetByPager(query, out qty));
        //    }
        //    catch (Exception ex)
        //    {
        //        ServiceExceptionHelper.ThrowServiceException(ex);
        //    }

        //    return new List<SkuView>();
        //}

        //public SkuView GetSkuByNumber(string clientCode, string skuNumber)
        //{
        //    try
        //    {
        //        var repository = new SkuViewRepository();
        //        return repository.GetByNumber(clientCode, skuNumber);
        //    }
        //    catch (Exception ex)
        //    {
        //        ServiceExceptionHelper.ThrowServiceException(ex);
        //    }

        //    return null;
        //}

        //public int CreateSku(Sku sku)
        //{
        //    try
        //    {
        //        var repository = new SkuRepository();
        //        var companyRepository = new CompanyRepository();
        //        Company company = companyRepository.Get(sku.ClientId);
        //        if (company == null)
        //            BusinessExceptionHelper.ThrowBusinessException("COMPANY_EXISTS");

        //        Sku oldSku = GetSkuByNumber(company.CompanyCode, sku.SkuNumber);
        //        if (oldSku != null)
        //            BusinessExceptionHelper.ThrowBusinessException("SKUNUMBER_EXISTS");

        //        sku.CreateTime = TypeConvertHelper.DatetimeToString(DateTime.Now);
        //        int skuId = repository.Create(sku);

        //        if (skuId > 0)
        //        {
        //            Pack piecePack = new Pack()
        //            {
        //                DefaultPack = true,
        //                Height = 0.0m,
        //                Length = 0.0m,
        //                Weight = 0.0m,
        //                PackLevel = 3,
        //                PackName = "件",
        //                ParentId = 0,
        //                ToPieceQty = 1,
        //                SkuId = skuId,
        //                Width = 0.0m
        //            };
        //            PackRepository packRepository = new PackRepository();
        //            packRepository.Create(piecePack);
        //        }
        //        else
        //            BusinessExceptionHelper.ThrowBusinessException("SKU_CREATE_ERROR");

        //        return skuId;
        //    }
        //    catch (Exception ex)
        //    {
        //        ServiceExceptionHelper.ThrowServiceException(ex);
        //    }

        //    return 0;
        //}

        //public bool UpdateSku(Sku sku)
        //{
        //    try
        //    {
        //        var repository = new SkuRepository();
        //        var companyRepository = new CompanyRepository();
        //        Company company = companyRepository.Get(sku.ClientId);
        //        if (company == null)
        //            BusinessExceptionHelper.ThrowBusinessException("COMPANY_EXISTS");

        //        Sku oldSku = GetSkuByNumber(company.CompanyCode, sku.SkuNumber);
        //        if (oldSku != null && oldSku.SkuId != sku.SkuId)
        //            BusinessExceptionHelper.ThrowBusinessException("SKUNUMBER_EXISTS");

        //        sku.EditTime = TypeConvertHelper.DatetimeToString(DateTime.Now);
        //        return repository.Update(sku);
        //    }
        //    catch (Exception ex)
        //    {
        //        ServiceExceptionHelper.ThrowServiceException(ex);
        //    }

        //    return false;
        //}

        //public bool DeleteSku(int skuId)
        //{
        //    try
        //    {
        //        var repository = new SkuRepository();
        //        return repository.Delete(skuId);
        //    }
        //    catch (Exception ex)
        //    {
        //        ServiceExceptionHelper.ThrowServiceException(ex);
        //    }

        //    return false;
        //}


        //public Pack GetPiecePack(int skuId)
        //{
        //    try
        //    {
        //        var repository = new PackRepository();
        //        return repository.GetPiecePack(skuId);
        //    }
        //    catch (Exception ex)
        //    {
        //        ServiceExceptionHelper.ThrowServiceException(ex);
        //    }

        //    return null;
        //}

        //public bool UpdatePiecePack(Pack piecePack)
        //{
        //    try
        //    {
        //        var repository = new PackRepository();
        //        return repository.Update(piecePack);
        //    }
        //    catch (Exception ex)
        //    {
        //        ServiceExceptionHelper.ThrowServiceException(ex);
        //    }

        //    return false;
        //}

        //public SkuManagement GetSkuManagement(int skuId)
        //{
        //    try
        //    {
        //        var repository = new SkuManagementRepository();
        //        return repository.GetSkuManagement(skuId);
        //    }
        //    catch (Exception ex)
        //    {
        //        ServiceExceptionHelper.ThrowServiceException(ex);
        //    }

        //    return null;
        //}

        //public bool MaintainSkuManagement(int skuId, bool isActive, SkuManagement skuManagement)
        //{
        //    try
        //    {
        //        var repository = new SkuManagementRepository();

        //        SkuManagement _oldSkuMangement = GetSkuManagement(skuId);

        //        if (_oldSkuMangement != null)
        //        {
        //            _oldSkuMangement.AbcType = skuManagement.AbcType;
        //            _oldSkuMangement.BarcodeManagement = skuManagement.BarcodeManagement;
        //            _oldSkuMangement.ContainerManagement = skuManagement.ContainerManagement;
        //            _oldSkuMangement.IsBigItem = skuManagement.IsBigItem;
        //            _oldSkuMangement.IsHeavyItem = skuManagement.IsHeavyItem;
        //            _oldSkuMangement.PickGroup = skuManagement.PickGroup;
        //            _oldSkuMangement.PickRule = skuManagement.PickRule;
        //            _oldSkuMangement.PieceManagement = skuManagement.PieceManagement;
        //            _oldSkuMangement.QcPercent = skuManagement.QcPercent;
        //            _oldSkuMangement.ReplenishGroup = skuManagement.ReplenishGroup;
        //            _oldSkuMangement.StorageCondition = skuManagement.StorageCondition;

        //            skuManagement.IsActive = isActive;
        //            skuManagement.EditTime = TypeConvertHelper.DatetimeToString(DateTime.Now);
        //            return repository.Update(_oldSkuMangement);
        //        }
        //        else
        //        {
        //            // create
        //            if (isActive)
        //            {
        //                skuManagement.CreateTime = TypeConvertHelper.DatetimeToString(DateTime.Now);
        //                skuManagement.SkuId = skuId;
        //                int newId = repository.Create(skuManagement);
        //                if (newId > 0)
        //                    return true;
        //            }
        //        }

        //        return false;
        //    }
        //    catch (Exception ex)
        //    {
        //        ServiceExceptionHelper.ThrowServiceException(ex);
        //    }

        //    return false;
        //}

        //public List<BatchProperty> GetBatchPropertyBySku(int skuId)
        //{
        //    try
        //    {
        //        var repository = new SkuRepository();
        //        return CollectionHelper.ToList(repository.GetBatchProperties(skuId));
        //    }
        //    catch (Exception ex)
        //    {
        //        ServiceExceptionHelper.ThrowServiceException(ex);
        //    }

        //    return new List<BatchProperty>();
        //}


        //public bool SaveSkuBatchProperty(int skuId, List<BatchProperty> batchProperties)
        //{
        //    try
        //    {
        //        SkuPropertyRepository skuPropertyRepository = new SkuPropertyRepository();

        //        if (batchProperties != null)
        //        {
        //            // add new property
        //            List<BatchProperty> currentProperties = GetBatchPropertyBySku(skuId);
        //            foreach (var property in batchProperties)
        //            {
        //                bool hasProperty = false;
        //                foreach (var oldProperty in currentProperties)
        //                {
        //                    if (property.PropertyId == oldProperty.PropertyId)
        //                    {
        //                        hasProperty = true;
        //                        break;
        //                    }
        //                }
        //                if (!hasProperty)
        //                {
        //                    SkuProperty insertProperty = new SkuProperty()
        //                    {
        //                        SkuId = skuId,
        //                        PropertyId = property.PropertyId,
        //                        Priority = 0
        //                    };
        //                    skuPropertyRepository.Create(insertProperty);
        //                }
        //            }

        //            // remove old property
        //            foreach (var property in currentProperties)
        //            {
        //                bool hasProperty = false;
        //                foreach (var newProperty in batchProperties)
        //                {
        //                    if (property.PropertyId == newProperty.PropertyId)
        //                    {
        //                        hasProperty = true;
        //                        break;
        //                    }
        //                }
        //                if (!hasProperty)
        //                {
        //                    Query query = new Query();
        //                    query.Criteria.Add(new Criterion("PropertyId", CriteriaOperator.Equal, property.PropertyId));
        //                    query.Criteria.Add(new Criterion("SkuId", CriteriaOperator.Equal, skuId));
        //                    SkuProperty deleteProperty = skuPropertyRepository.GetByQuery(query);
        //                    if (deleteProperty != null)
        //                        skuPropertyRepository.Delete(deleteProperty.Id);
        //                }
        //            }
        //        }
        //        else
        //        {
        //            // dont custom sku batch property, use category batch property
        //            Query query = new Query();
        //            query.Criteria.Add(new Criterion("SkuId", CriteriaOperator.Equal, skuId));
        //            IList<SkuProperty> skuProperties  = skuPropertyRepository.GetListByQuery(query);
        //            foreach (var property in skuProperties)
        //            {
        //                skuPropertyRepository.Delete(property.Id);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ServiceExceptionHelper.ThrowServiceException(ex);
        //    }

        //    return true;
        //}
        //#endregion
    }
}
