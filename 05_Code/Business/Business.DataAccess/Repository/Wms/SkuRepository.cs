using System.Collections.Generic;
using Business.Common.QueryModel;
using Business.DataAccess.Contract.Repository.Wms;
using Business.Domain.Wms;

namespace Business.DataAccess.Repository.Wms
{
    public class SkuRepository : Repository<Sku>, ISkuRepository
    {
        private readonly CompanyRepository _companyRepository;
        private readonly CategoryManagementRepository _categoryManagementRepository;
        private readonly SkuManagementRepository _skuManagementRepository;
        private readonly PackRepository _packRepository;

        public SkuRepository()
        {
            Database = DatabaseConfigName.Wms;

            _companyRepository = new CompanyRepository();
            _categoryManagementRepository = new CategoryManagementRepository();
            _skuManagementRepository = new SkuManagementRepository();
            _packRepository = new PackRepository();
        }



        public Company GetClient(int skuId)
        {
            Sku sku = Get(skuId);
            if (sku != null)
                return _companyRepository.Get(sku.ClientId);

            return null;
        }

        public Company GetMerchant(int skuId)
        {
            Sku sku = Get(skuId);
            if (sku != null)
                return _companyRepository.Get(sku.MerchantId);

            return null;
        }

        public CategoryManagement GetCategoryManagement(int skuId)
        {
            var skuViewRepository = new Repository<SkuView>();
            skuViewRepository.Database = DatabaseConfigName.Wms;
            SkuView sku = skuViewRepository.Get(skuId);
            if (sku != null)
                return _categoryManagementRepository.Get(sku.CategoryId);

            return null;
        }

        public SkuManagement GetSkuManagement(int skuId)
        {
            var query = new Query();
            query.Criteria.Add(new Criterion("SkuId", CriteriaOperator.Equal, skuId));

            return _skuManagementRepository.GetByQuery(query);
        }

        public IList<Pack> GetPacks(int skuId)
        {
            var query = new Query();
            query.Criteria.Add(new Criterion("SkuId", CriteriaOperator.Equal, skuId));

            return _packRepository.GetListByQuery(query);
        }

        public IList<BatchProperty> GetBatchProperties(int skuId)
        {
            return GetListByCommand<BatchProperty>("BatchProperty.GetBatchProperties", skuId);
        }
    }
}