using System.Collections.Generic;
using Business.Domain.Application;
using Business.Domain.Warehouse;

namespace Business.DataAccess.Contract.Repository.Warehouse
{
    public interface IOperatorGroupRepository : IRepository<OperatorGroup>
    {
        OperatorGroup GetByName(string warehouseCode, string groupName);

        IList<User> GetMembers(int operatorGroupId);
    }
}