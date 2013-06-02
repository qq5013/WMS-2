using System.Collections.Generic;
using Business.Domain.Wms;

namespace Business.DataAccess.Contract.Repository.Wms
{
    public interface IDistrictRepository : IRepository<District>
    {
        District GetByCode(string districtCode);

        IList<District> GetByLevel(int districtLevel);

        IList<District> GetByParent(int parentId);
    }
}