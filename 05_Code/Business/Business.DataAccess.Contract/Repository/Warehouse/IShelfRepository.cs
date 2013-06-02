using Business.Domain.Warehouse;

namespace Business.DataAccess.Contract.Repository.Warehouse
{
    public interface IShelfRepository : IRepository<Shelf>
    {
        Shelf GetByCode(string warehouseCode, string shelfCode);
    }
}