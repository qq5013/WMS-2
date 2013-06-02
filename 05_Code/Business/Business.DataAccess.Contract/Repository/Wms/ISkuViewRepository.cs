using Business.Domain.Wms;

namespace Business.DataAccess.Contract.Repository.Wms
{
    public interface ISkuViewRepository : IRepository<SkuView>
    {
        SkuView GetByNumber(string clientCode, string skuNumber);
    }
}