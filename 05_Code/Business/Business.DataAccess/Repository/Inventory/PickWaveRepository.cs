using Business.DataAccess.Contract.Repository.Inventory;
using Business.Domain.Inventory;

namespace Business.DataAccess.Repository.Inventory
{
    public class PickWaveRepository : Repository<PickWave>, IPickWaveRepository
    {
        public PickWaveRepository()
        {
            Database = DatabaseConfigName.Inventory;
        }
    }
}