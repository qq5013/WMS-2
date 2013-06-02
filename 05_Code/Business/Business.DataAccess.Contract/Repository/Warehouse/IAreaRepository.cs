using System.Collections.Generic;
using Business.Domain.Warehouse;

namespace Business.DataAccess.Contract.Repository.Warehouse
{
    public interface IAreaRepository : IRepository<Area>
    {
        Area GetByCode(int warehouseId, string areaCode);

        Area GetByCode(string warehouseCode, string areaCode);

        IList<OperatorGroup> GetGroups(int areaId);
    }
}