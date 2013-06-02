using Business.DataAccess.Contract.Repository.Inventory;
using Business.Domain.Inventory;

namespace Business.DataAccess.Repository.Inventory
{
    public class SerialNumberRepository : Repository<SerialNumber>, ISerialNumberRepository
    {
        public SerialNumberRepository()
        {
            Database = DatabaseConfigName.Inventory;
        }
    }
}