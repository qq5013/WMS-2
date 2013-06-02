using System.Collections.Generic;
using Business.Common.QueryModel;
using Business.DataAccess.Contract.Repository.Application;
using Business.Domain.Application;

namespace Business.DataAccess.Repository.Application
{
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        private readonly IApplicationRepository _applicationRepository;

        public RoleRepository()
        {
            Database = DatabaseConfigName.Application;

            _applicationRepository = new ApplicationRepository();
        }

        #region IRoleRepository Members

        public Role GetByCode(string applicationCode, string roleCode)
        {
            Domain.Application.Application application = _applicationRepository.GetByCode(applicationCode);
            if (application != null)
            {
                var query = new Query();
                query.Criteria.Add(new Criterion("ApplicationId", CriteriaOperator.Equal, application.ApplicationId));
                query.Criteria.Add(new Criterion("RoleCode", CriteriaOperator.Equal, roleCode));

                return GetByQuery(query);
            }

            return null;
        }

        public IList<Function> GetFunctions(int roleId)
        {
            return GetListByCommand<Function>("Role.GetFunctions", roleId);
        }

        public IList<Group> GetGroups(int roleId)
        {
            return GetListByCommand<Group>("Role.GetGroups", roleId);
        }

        public IList<User> GetUsers(int roleId)
        {
            return GetListByCommand<User>("Role.GetUsers", roleId);
        }

        #endregion
    }
}