using Business.Domain.Wms;

namespace Business.DataAccess.Contract.Repository.Wms
{
    public interface IPackRepository : IRepository<Pack>
    {
        Pack GetPiecePack(int skuId);
    }
}