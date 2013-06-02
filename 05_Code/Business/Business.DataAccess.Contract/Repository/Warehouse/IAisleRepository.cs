using Business.Domain.Warehouse;

namespace Business.DataAccess.Contract.Repository.Warehouse
{
    public interface IAisleRepository : IRepository<Aisle>
    {
        Aisle GetByCode(string warehouseCode, string aisleCode);
    }
}