using Business.Common.QueryModel;
using Business.DataAccess.Contract.Repository.Application;
using Business.Domain.Application;

namespace Business.DataAccess.Repository.Application
{
    public class RoleUserRepository : Repository<RoleUser>, IRoleUserRepository
    {
        public RoleUserRepository()
        {
            Database = DatabaseConfigName.Application;
        }

        #region IRoleUserRepository Members

        public bool AddUser(int roleId, int userId)
        {
            var query = new Query();
            query.Criteria.Add(new Criterion("RoleId", CriteriaOperator.Equal, roleId));
            query.Criteria.Add(new Criterion("UserId", CriteriaOperator.Equal, userId));

            RoleUser roleUser = GetByQuery(query);
            if (roleUser == null)
            {
                roleUser = new RoleUser
                               {
                                   RoleId = roleId,
                                   UserId = userId
                               };

                return Create(roleUser) > 0;
            }

            return false;
        }

        public bool RemoveUser(int roleId, int userId)
        {
            var query = new Query();
            query.Criteria.Add(new Criterion("RoleId", CriteriaOperator.Equal, roleId));
            query.Criteria.Add(new Criterion("UserId", CriteriaOperator.Equal, userId));

            RoleUser roleUser = GetByQuery(query);
            if (roleUser != null)
            {
                return Delete(roleUser.Id);
            }

            return false;
        }

        #endregion
    }
}