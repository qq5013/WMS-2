using System.Collections;
using System.Collections.Generic;
using Business.Common.QueryModel;
using Business.DataAccess.Contract.Repository.Application;
using Business.Domain.Application;
using Framework.Core.Encryption;

namespace Business.DataAccess.Repository.Application
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly IApplicationRepository _applicationRepository;

        public UserRepository()
        {
            Database = DatabaseConfigName.Application;

            _applicationRepository = new ApplicationRepository();
        }

        #region IUserRepository Members

        public User GetByCode(string applicationCode, string userCode)
        {
            Domain.Application.Application application = _applicationRepository.GetByCode(applicationCode);
            if (application != null)
            {
                var query = new Query();
                query.Criteria.Add(new Criterion("ApplicationId", CriteriaOperator.Equal, application.ApplicationId));
                query.Criteria.Add(new Criterion("UserCode", CriteriaOperator.Equal, userCode));

                return GetByQuery(query);
            }

            return null;
        }

        public bool ChangePassword(User user, string newPassword)
        {
            if (user != null)
            {
                string encryptedPassword = EncryptHelper.Encrypt(newPassword);
                user.Password = encryptedPassword;
                return Update(user);
            }

            return false;
        }

        public IList<UserFunctionView> GetFunctions(string applicationCode, string userCode)
        {
            Domain.Application.Application application = _applicationRepository.GetByCode(applicationCode);
            if (application != null)
            {
                var query = new Query();
                query.Criteria.Add(new Criterion("ApplicationId", CriteriaOperator.Equal, application.ApplicationId));
                User user = GetByCode(applicationCode, userCode);
                
                if (user == null) return new List<UserFunctionView>();

                query.Criteria.Add(new Criterion("UserId", CriteriaOperator.Equal, user.UserId));

                var repository = new Repository<UserFunctionView>();
                repository.Database = DatabaseConfigName.Application;
                return repository.GetListByQuery(query);
            }

            return new List<UserFunctionView>();
        }

        #endregion
    }
}