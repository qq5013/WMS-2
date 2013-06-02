using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using Business.Common.DataDictionary;
using Business.Common.Exception;
using Business.Common.QueryModel;
using Business.DataAccess.Repository.Warehouse;
using Business.DataAccess.Repository.Wms;
using Business.Domain.Warehouse;
using Business.Domain.Wms;
using Business.Service.Contract;
using Framework.Core.Collections;
using Business.Common.Toolkit;
using Business.Component;

namespace Business.Service
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class SkuService : ISkuService
    {
        #region sku
        public SkuView GetSkuView(int skuId)
        {
            try
            {
                var repository = new SkuViewRepository();
                return repository.Get(skuId);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return null;
        }

        public List<SkuView> GetAllSkuView()
        {
            try
            {
                var repository = new SkuViewRepository();
                return CollectionHelper.ToList(repository.GetAll());
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return new List<SkuView>();
        }

        public List<SkuView> GetSkuViewByQuery(Query query)
        {
            try
            {
                var repository = new SkuViewRepository();
                return CollectionHelper.ToList(repository.GetListByQuery(query));
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return new List<SkuView>();
        }

        public List<SkuView> GetSkuViewByPagerQuery(PagerQuery query, out int qty)
        {
            qty = 0;
            try
            {
                var repository = new SkuViewRepository();
                return CollectionHelper.ToList(repository.GetByPager(query, out qty));
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return new List<SkuView>();
        }

        public SkuView GetSkuViewByNumber(string clientCode, string skuNumber)
        {
            try
            {
                var repository = new SkuViewRepository();
                return repository.GetByNumber(clientCode, skuNumber);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return null;
        }

        public List<Sku> GetAllSku()
        {
            try
            {
                var repository = new SkuRepository();
                return CollectionHelper.ToList(repository.GetAll());
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return new List<Sku>();
        }

        public List<Sku> GetSkuByQuery(Query query)
        {
            try
            {
                var repository = new SkuRepository();
                return CollectionHelper.ToList(repository.GetListByQuery(query));
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return new List<Sku>();
        }

        public Pack GetPiecePack(int skuId)
        {
            try
            {
                var repository = new PackRepository();
                return repository.GetPiecePack(skuId);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return null;
        }

        public bool UpdatePiecePack(Pack piecePack)
        {
            try
            {
                var repository = new PackRepository();
                return repository.Update(piecePack);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return false;
        }

        public Sku GetSkuByNumber(string clientCode, string skuNumber)
        {
            try
            {
                var repository = new SkuViewRepository();
                return repository.GetByNumber(clientCode, skuNumber);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return null;
        }

        public int CreateSku(Sku sku)
        {
            try
            {
                var repository = new SkuRepository();
                var companyRepository = new CompanyRepository();
                Company company = companyRepository.Get(sku.ClientId);
                if (company == null)
                    BusinessExceptionHelper.ThrowBusinessException("COMPANY_EXISTS");

                Sku oldSku = GetSkuByNumber(company.CompanyCode, sku.SkuNumber);
                if (oldSku != null)
                    BusinessExceptionHelper.ThrowBusinessException("SKUNUMBER_EXISTS");

                sku.CreateTime = TypeConvertHelper.DatetimeToString(DateTime.Now);
                int skuId = repository.Create(sku);

                if (skuId > 0)
                {
                    Pack piecePack = new Pack()
                    {
                        DefaultPack = true,
                        Height = 0.0m,
                        Length = 0.0m,
                        Weight = 0.0m,
                        PackLevel = 3,
                        PackName = "件",
                        ParentId = 0,
                        ToPieceQty = 1,
                        SkuId = skuId,
                        Width = 0.0m
                    };
                    PackRepository packRepository = new PackRepository();
                    packRepository.Create(piecePack);
                }
                else
                    BusinessExceptionHelper.ThrowBusinessException("SKU_CREATE_ERROR");

                return skuId;
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return 0;
        }

        public bool UpdateSku(Sku sku)
        {
            try
            {
                var repository = new SkuRepository();
                var companyRepository = new CompanyRepository();
                Company company = companyRepository.Get(sku.ClientId);
                if (company == null)
                    BusinessExceptionHelper.ThrowBusinessException("COMPANY_EXISTS");

                Sku oldSku = GetSkuByNumber(company.CompanyCode, sku.SkuNumber);
                if (oldSku != null && oldSku.SkuId != sku.SkuId)
                    BusinessExceptionHelper.ThrowBusinessException("SKUNUMBER_EXISTS");

                sku.EditTime = TypeConvertHelper.DatetimeToString(DateTime.Now);
                return repository.Update(sku);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return false;
        }

        public bool DeleteSku(int skuId)
        {
            try
            {
                var repository = new SkuRepository();
                return repository.Delete(skuId);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return false;
        }

        public Company GetSkuClient(int skuId)
        {
            try
            {
                var repository = new SkuRepository();
                return repository.GetClient(skuId);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return null;
        }

        public Company GetSkuMerchant(int skuId)
        {
            try
            {
                var repository = new SkuRepository();
                return repository.GetMerchant(skuId);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return null;
        }

        public CategoryManagement GetCategoryManagement(int skuId)
        {
            try
            {
                var repository = new SkuRepository();
                return repository.GetCategoryManagement(skuId);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return null;
        }

        public SkuManagement GetSkuManagement(int skuId)
        {
            try
            {
                return SkuManager.GetSkuManagement(skuId);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return null;
        }

        public SkuManagement GetSkuManagementMode(int skuId)
        {
            try
            {
                return SkuManager.GetSkuManagementMode(skuId);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return null;
        }

        public Pack GetDefaultPack(int skuId)
        {
            var repository = new SkuRepository();
            IList<Pack> packs = repository.GetPacks(skuId);
            return packs.FirstOrDefault(pack => pack.DefaultPack);
        }

        public List<Pack> GetPacks(int skuId)
        {
            try
            {
                var repository = new SkuRepository();
                return CollectionHelper.ToList(repository.GetPacks(skuId));
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return new List<Pack>();
        }

        public List<BatchProperty> GetBatchProperties(int skuId)
        {
            try
            {
                var repository = new SkuRepository();
                return CollectionHelper.ToList(repository.GetBatchProperties(skuId));
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return new List<BatchProperty>();
        }

        public List<Location> GetAvailableLocations(int warehouseId, int skuId, int areaType)
        {
            try
            {
                var repository = new LocationRepository();
                return CollectionHelper.ToList(repository.GetByTag(warehouseId, skuId, areaType));
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return new List<Location>();
        }

        public List<Location> GetAvailablePickLocations(int warehouseId, int skuId)
        {
            try
            {
                var repository = new LocationRepository();
                return CollectionHelper.ToList(repository.GetByTag(warehouseId, skuId, (int)AreaType.Picking));
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return new List<Location>();
        }

        public List<Location> GetAvailableStoreLocations(int warehouseId, int skuId)
        {
            try
            {
                var repository = new LocationRepository();
                return CollectionHelper.ToList(repository.GetByTag(warehouseId, skuId, (int)AreaType.Storage));
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return new List<Location>();
        }

        public List<Location> GetPutawayPickLocations(int warehouseId, int skuId)
        {
            try
            {
                var repository = new LocationRepository();
                return CollectionHelper.ToList(repository.GetBySku(warehouseId, skuId, (int)AreaType.Picking));
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return new List<Location>();
        }

        public List<Location> GetPutawayStoreLocations(int warehouseId, int skuId)
        {
            try
            {
                var repository = new LocationRepository();
                return CollectionHelper.ToList(repository.GetBySku(warehouseId, skuId, (int)AreaType.Storage));
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return new List<Location>();
        }

        public bool SyncSkus(string clientCode, string message)
        {
            return false;
        }


        public bool MaintainSkuManagement(int skuId, bool isActive, SkuManagement skuManagement)
        {
            try
            {
                var repository = new SkuManagementRepository();

                var oldSkuMangement = GetSkuManagement(skuId);

                if (oldSkuMangement != null)
                {
                    oldSkuMangement.AbcType = skuManagement.AbcType;
                    oldSkuMangement.BarcodeManagement = skuManagement.BarcodeManagement;
                    oldSkuMangement.ContainerManagement = skuManagement.ContainerManagement;
                    oldSkuMangement.IsBigItem = skuManagement.IsBigItem;
                    oldSkuMangement.IsHeavyItem = skuManagement.IsHeavyItem;
                    oldSkuMangement.PickGroup = skuManagement.PickGroup;
                    oldSkuMangement.PickRule = skuManagement.PickRule;
                    oldSkuMangement.PieceManagement = skuManagement.PieceManagement;
                    oldSkuMangement.QcPercent = skuManagement.QcPercent;
                    oldSkuMangement.ReplenishGroup = skuManagement.ReplenishGroup;
                    oldSkuMangement.StorageCondition = skuManagement.StorageCondition;
                    oldSkuMangement.BatchManagement = skuManagement.BatchManagement;

                    skuManagement.IsActive = isActive;
                    skuManagement.EditTime = TypeConvertHelper.DatetimeToString(DateTime.Now);
                    return repository.Update(oldSkuMangement);
                }
                else
                {
                    // create
                    if (isActive)
                    {
                        skuManagement.CreateTime = TypeConvertHelper.DatetimeToString(DateTime.Now);
                        skuManagement.SkuId = skuId;
                        skuManagement.IsActive = true;
                        int newId = repository.Create(skuManagement);
                        if (newId > 0)
                            return true;
                    }
                }

                return false;
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return false;
        }

        public List<BatchProperty> GetBatchPropertyBySku(int skuId)
        {
            try
            {
                var repository = new SkuRepository();
                return CollectionHelper.ToList(repository.GetBatchProperties(skuId));
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return new List<BatchProperty>();
        }


        public bool SaveSkuBatchProperty(int skuId, List<BatchProperty> batchProperties)
        {
            try
            {
                SkuPropertyRepository skuPropertyRepository = new SkuPropertyRepository();

                if (batchProperties != null)
                {
                    // add new property
                    List<BatchProperty> currentProperties = GetBatchPropertyBySku(skuId);
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
                            SkuProperty insertProperty = new SkuProperty()
                            {
                                SkuId = skuId,
                                PropertyId = property.PropertyId,
                                Priority = 0
                            };
                            skuPropertyRepository.Create(insertProperty);
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
                            query.Criteria.Add(new Criterion("SkuId", CriteriaOperator.Equal, skuId));
                            SkuProperty deleteProperty = skuPropertyRepository.GetByQuery(query);
                            if (deleteProperty != null)
                                skuPropertyRepository.Delete(deleteProperty.Id);
                        }
                    }
                }
                else
                {
                    // dont custom sku batch property, use category batch property
                    Query query = new Query();
                    query.Criteria.Add(new Criterion("SkuId", CriteriaOperator.Equal, skuId));
                    IList<SkuProperty> skuProperties = skuPropertyRepository.GetListByQuery(query);
                    foreach (var property in skuProperties)
                    {
                        skuPropertyRepository.Delete(property.Id);
                    }
                }
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return true;
        }

        public SkuImage CreateSkuImage(SkuImage skuImage)
        {
            try
            {
                return SkuManager.CreateImage(skuImage);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return null;
        }

        public SkuImage GetSkuImage(int skuId, int index)
        {
            try
            {
                return SkuManager.GetImage(skuId, index);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return null;
        }

        public int GetSkuImageCount(int skuId)
        {
            try
            {
                return SkuManager.GetImageCount(skuId);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return 0;
        }

        public bool IsPieceManagement(int skuId)
        {
            SkuManagement skuManagement = SkuManager.GetSkuManagementMode(skuId);
            if (skuManagement != null)
                return skuManagement.PieceManagement;

            return false;
        }

        public bool IsBatchManagement(int skuId)
        {
            SkuManagement skuManagement = SkuManager.GetSkuManagementMode(skuId);
            if (skuManagement != null)
                return skuManagement.BatchManagement;

            return false;
        }

        public bool IsBarcodeManagement(int skuId)
        {
            SkuManagement skuManagement = SkuManager.GetSkuManagementMode(skuId);
            if (skuManagement != null)
                return skuManagement.BarcodeManagement;

            return false;
        }

        public bool IsContainerManagement(int skuId)
        {
            SkuManagement skuManagement = SkuManager.GetSkuManagementMode(skuId);
            if (skuManagement != null)
                return skuManagement.ContainerManagement;

            return false;
        }
        #endregion
    }
}
