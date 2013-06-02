using System.Collections.Generic;
using Business.Domain.Wms;

namespace Business.DataAccess.Contract.Repository.Wms
{
    public interface ISkuRepository : IRepository<Sku>
    {
        Company GetClient(int skuId);

        Company GetMerchant(int skuId);

        CategoryManagement GetCategoryManagement(int skuId);

        SkuManagement GetSkuManagement(int skuId);

        IList<Pack> GetPacks(int skuId);

        IList<BatchProperty> GetBatchProperties(int skuId);
    }
}