using Business.Common.QueryModel;
using Business.DataAccess.Contract.Repository.Application;
using Business.Domain.Application;

namespace Business.DataAccess.Repository.Application
{
    public class RoleFunctionRepository : Repository<RoleFunction>, IRoleFunctionRepository
    {
        public RoleFunctionRepository()
        {
            Database = DatabaseConfigName.Application;
        }

        #region IRoleFunctionRepository Members

        public bool AddFunction(int roleId, int functionId)
        {
            var query = new Query();
            query.Criteria.Add(new Criterion("RoleId", CriteriaOperator.Equal, roleId));
            query.Criteria.Add(new Criterion("FunctionId", CriteriaOperator.Equal, functionId));

            RoleFunction roleFunction = GetByQuery(query);
            if (roleFunction == null)
            {
                roleFunction = new RoleFunction
                                   {
                                       RoleId = roleId,
                                       FunctionId = functionId
                                   };

                return Create(roleFunction) > 0;
            }

            return false;
        }

        public bool RemoveFunction(int roleId, int functionId)
        {
            var query = new Query();
            query.Criteria.Add(new Criterion("RoleId", CriteriaOperator.Equal, roleId));
            query.Criteria.Add(new Criterion("FunctionId", CriteriaOperator.Equal, functionId));

            RoleFunction roleFunction = GetByQuery(query);
            if (roleFunction != null)
            {
                return Delete(roleFunction.Id);
            }

            return false;
        }

        #endregion
    }
}