using Business.Domain.Warehouse;

namespace Business.DataAccess.Contract.Repository.Warehouse
{
    public interface IAreaGroupRepository : IRepository<AreaGroup>
    {
        bool AddGroup(int areaId, int groupId);

        bool RemoveGroup(int areaId, int groupId);
    }
}