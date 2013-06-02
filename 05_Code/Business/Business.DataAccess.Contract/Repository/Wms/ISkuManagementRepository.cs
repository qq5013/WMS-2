using Business.Domain.Wms;

namespace Business.DataAccess.Contract.Repository.Wms
{
    public interface ISkuManagementRepository : IRepository<SkuManagement>
    {
        SkuManagement GetSkuManagement(int skuId);
    }
}