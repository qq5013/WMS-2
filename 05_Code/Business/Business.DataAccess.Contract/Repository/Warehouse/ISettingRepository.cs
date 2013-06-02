using Business.Domain.Warehouse;

namespace Business.DataAccess.Contract.Repository.Warehouse
{
    public interface ISettingRepository : IRepository<Setting>
    {
        Setting GetByCode(string warehouseCode, string settingCode);

        Setting GetByCode(int warehouseId, string settingCode);
    }
}