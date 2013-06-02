using System.Collections.Generic;
using Business.Common.QueryModel;
using Business.DataAccess.Contract.Repository.Application;
using Business.Domain.Application;

namespace Business.DataAccess.Repository.Application
{
    public class GroupRepository : Repository<Group>, IGroupRepository
    {
        private readonly IApplicationRepository _applicationRepository;

        public GroupRepository()
        {
            Database = DatabaseConfigName.Application;

            _applicationRepository = new ApplicationRepository();
        }

        #region IGroupRepository Members

        public Group GetByCode(string applicationCode, string groupCode)
        {
            Domain.Application.Application application = _applicationRepository.GetByCode(applicationCode);
            if (application != null)
            {
                var query = new Query();
                query.Criteria.Add(new Criterion("ApplicationId", CriteriaOperator.Equal, application.ApplicationId));
                query.Criteria.Add(new Criterion("GroupCode", CriteriaOperator.Equal, groupCode));

                return GetByQuery(query);
            }

            return null;
        }

        public IList<User> GetUsers(int groupId)
        {
            return GetListByCommand<User>("Group.GetUsers", groupId);;
        }

        #endregion
    }
}