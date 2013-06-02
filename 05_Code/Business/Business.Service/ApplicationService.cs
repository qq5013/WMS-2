using System;
using System.Collections.Generic;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Activation;
using Business.Common.Exception;
using Business.Common.Exception.ExceptionCode;
using Business.Common.Toolkit;
using Business.Common.QueryModel;
using Business.DataAccess.Repository.Application;
using Business.Domain.Application;
using Business.Service.Contract;
using Business.DataAccess.Contract.Repository.Application;
using Framework.Core.Collections;
using Business.DataAccess.Repository.Wms;

namespace Business.Service
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class ApplicationService : IApplicationService
    {
        #region repository
        private IApplicationRepository _applicationRepository;
        public IApplicationRepository ApplicationRepository
        {
            set { _applicationRepository = value; }
            get 
            {
                if (_applicationRepository == null)
                    _applicationRepository = new ApplicationRepository();
                return _applicationRepository; 
            }

        }

        private IDataDictionaryRepository _dataDictionaryRepository;
        public IDataDictionaryRepository DataDictionaryRepository
        {
            set { _dataDictionaryRepository = value; }
            get
            {
                if (_dataDictionaryRepository == null)
                    _dataDictionaryRepository = new DataDictionaryRepository();
                return _dataDictionaryRepository;
            }

        }
        #endregion

        #region server
        /// <summary>
        /// 获取服务器机器名
        /// </summary>
        /// <returns>机器名</returns>
        public string GetServerName()
        {
            return Dns.GetHostName();
        }

        /// <summary>
        /// 获取服务器IP地址
        /// </summary>
        /// <returns>IP地址</returns>
        public string GetServerIpAddress()
        {
            string hostName = Dns.GetHostName();
            IPHostEntry host = Dns.GetHostEntry(hostName);

            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.ToString().Length > 5)
                    return ip.ToString();
            }

            return string.Empty;
        }

        /// <summary>
        /// 获取服务器系统时间
        /// </summary>
        /// <returns>服务器系统时间</returns>
        public DateTime GetServerDateTime()
        {
            return DateTime.Now;
        }
        #endregion server

        #region application
        public List<Application> GetAllApplication()
        {
            try
            {
                return CollectionHelper.ToList(ApplicationRepository.GetAll());
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return new List<Application>();
        }

        public List<Application> GetApplicationByQuery(Query query)
        {
            try
            {
                return CollectionHelper.ToList(ApplicationRepository.GetListByQuery(query));
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return new List<Application>();
        }

        public Application GetApplicationByCode(string applicationCode)
        {
            try
            {
                return ApplicationRepository.GetByCode(applicationCode);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return null;
        }

        public int CreateApplication(Application application)
        {
            try
            {
                Application oldApplication = GetApplicationByCode(application.ApplicationCode);
                if (oldApplication != null)
                {
                    BusinessExceptionHelper.ThrowBusinessException(ApplicationExceptionCodeHelper.ApplicationCodeExist);
                }

                return ApplicationRepository.Create(application);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return 0;
        }

        public bool UpdateApplication(Application application)
        {
            try
            {
                return ApplicationRepository.Update(application);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return false;
        }


        public bool DeleteApplication(int Id)
        {
            try
            {
                return ApplicationRepository.Delete(Id);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return false;
        }
        #endregion application

        #region data dictionary
        public DataDictionary GetDataDictionary(int dictionaryId)
        {
            try
            {
                var repository = new DataDictionaryRepository();
                return repository.Get(dictionaryId);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return null;
        }

        public List<DataDictionary> GetAllDataDictionary()
        {
            try
            {
                return CollectionHelper.ToList(DataDictionaryRepository.GetAll());
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return new List<DataDictionary>();
        }

        public List<DataDictionary> GetDataDictionaryByQuery(Query query)
        {
            try
            {
                return CollectionHelper.ToList(DataDictionaryRepository.GetListByQuery(query));
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return new List<DataDictionary>();
        }

        public DataDictionary GetDataDictionaryByCode(string applicationCode, string dictionaryCode)
        {
            try
            {
                return DataDictionaryRepository.GetByCode(applicationCode, dictionaryCode);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return null;
        }

        public int CreateDataDictionary(DataDictionary dictionary)
        {
            try
            {
                // validate new usercode exists.
                Application application = ApplicationRepository.Get(dictionary.ApplicationId);
                if (application == null)
                    BusinessExceptionHelper.ThrowBusinessException("APPLICATION_NOTFOUND");
                DataDictionary oldDictionary = DataDictionaryRepository.GetByCode(application.ApplicationCode, dictionary.DictionaryCode);
                if (oldDictionary != null)
                    BusinessExceptionHelper.ThrowBusinessException("DICTIONARYCODE_EXISTS");

                return DataDictionaryRepository.Create(dictionary);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return 0;
        }

        public bool UpdateDataDictionary(DataDictionary dictionary)
        {
            try
            {
                // validate new usercode exists.
                Application application = ApplicationRepository.Get(dictionary.ApplicationId);
                if (application == null)
                    BusinessExceptionHelper.ThrowBusinessException("APPLICATION_NOTFOUND");
                DataDictionary oldDictionary = DataDictionaryRepository.GetByCode(application.ApplicationCode, dictionary.DictionaryCode);
                if (oldDictionary != null && oldDictionary.DictionaryId != oldDictionary.DictionaryId)
                    BusinessExceptionHelper.ThrowBusinessException("DICTIONARYCODE_EXISTS");
                return DataDictionaryRepository.Update(dictionary);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return false;
        }

        public bool DeleteDataDictionary(int dictionaryId)
        {
            try
            {
                return DataDictionaryRepository.Delete(dictionaryId);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return false;
        }
        #endregion

        #region function
        public List<Function> GetAllFunction()
        {
            try
            {
                IFunctionRepository repository = new FunctionRepository();
                return CollectionHelper.ToList(repository.GetAll());
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return new List<Function>();
        }

        public List<Function> GetFunctionByQuery(Query query)
        {
            try
            {
                var repository = new FunctionRepository();
                return CollectionHelper.ToList(repository.GetListByQuery(query));
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return new List<Function>();
        }

        public Function GetFunctionByCode(string applicationCode, string functionCode)
        {
            try
            {
                var repository = new FunctionRepository();
                return repository.GetByCode(applicationCode, functionCode);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return null;
        }

        public int CreateFunction(Function function)
        {
            try
            {
                var repository = new FunctionRepository();

                // validate new functioncode exists.
                var applicationRepository = new ApplicationRepository();
                Application application = applicationRepository.Get(function.ApplicationId);
                if (application == null)
                    BusinessExceptionHelper.ThrowBusinessException("APPLICATION_NOTFOUND");
                Function oldFunction = repository.GetByCode(application.ApplicationCode, function.FunctionCode);
                if (oldFunction != null)
                    BusinessExceptionHelper.ThrowBusinessException("FUNCTIONCODE_EXISTS");

                return repository.Create(function);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return 0;
        }

        public bool UpdateFunction(Function function)
        {
            try
            {
                var repository = new FunctionRepository();

                // validate new functioncode exists.
                var applicationRepository = new ApplicationRepository();
                Application application = applicationRepository.Get(function.ApplicationId);
                if (application == null)
                    BusinessExceptionHelper.ThrowBusinessException("APPLICATION_NOTFOUND");
                Function oldFunction = repository.GetByCode(application.ApplicationCode, function.FunctionCode);
                if (oldFunction != null && oldFunction.FunctionId != function.FunctionId)
                    BusinessExceptionHelper.ThrowBusinessException("FUNCTIONCODE_EXISTS");

                return repository.Update(function);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return false;
        }

        public bool DeleteFunction(int functionId)
        {
            try
            {
                var repository = new FunctionRepository();
                return repository.Delete(functionId);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return false;
        }
        #endregion

        #region group
        public List<Group> GetAllGroup()
        {
            try
            {
                var repository = new GroupRepository();
                return CollectionHelper.ToList(repository.GetAll());
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return new List<Group>();
        }

        public List<Group> GetGroupByQuery(Query query)
        {
            try
            {
                var repository = new GroupRepository();
                return CollectionHelper.ToList(repository.GetListByQuery(query));
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return new List<Group>();
        }

        public Group GetGroupByCode(string applicationCode, string groupCode)
        {
            try
            {
                var repository = new GroupRepository();
                return repository.GetByCode(applicationCode, groupCode);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return null;
        }

        public int CreateGroup(Group group)
        {
            try
            {
                var repository = new GroupRepository();

                // validate new group code exists.
                var applicationRepository = new ApplicationRepository();
                Application application = applicationRepository.Get(group.ApplicationId);
                if (application == null)
                    BusinessExceptionHelper.ThrowBusinessException("APPLICATION_NOTFOUND");
                Group oldGroup = repository.GetByCode(application.ApplicationCode, group.GroupCode);
                if (oldGroup != null)
                    BusinessExceptionHelper.ThrowBusinessException("GROUPCODE_EXISTS");

                return repository.Create(group);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return 0;
        }

        public bool UpdateGroup(Group group)
        {
            try
            {
                var repository = new GroupRepository();
                // validate new group code exists.
                var applicationRepository = new ApplicationRepository();
                Application application = applicationRepository.Get(group.ApplicationId);
                if (application == null)
                    BusinessExceptionHelper.ThrowBusinessException("APPLICATION_NOTFOUND");
                Group oldGroup = repository.GetByCode(application.ApplicationCode, group.GroupCode);
                if (oldGroup != null && oldGroup.GroupId != group.GroupId)
                    BusinessExceptionHelper.ThrowBusinessException("GROUPCODE_EXISTS");

                return repository.Update(group);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return false;
        }

        public bool DeleteGroup(int groupId)
        {
            try
            {
                var repository = new GroupRepository();
                return repository.Delete(groupId);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return false;
        }

        public List<User> GetGroupUsers(int groupId)
        {
            try
            {
                var repository = new GroupRepository();
                return CollectionHelper.ToList(repository.GetUsers(groupId));
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return new List<User>();
        }

        public bool AddGroupUser(int groupId, int userId)
        {
            try
            {
                var repository = new GroupUserRepository();
                return repository.AddUser(groupId, userId);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return false;
        }

        public bool RemoveGroupUser(int groupId, int userId)
        {
            try
            {
                var repository = new GroupUserRepository();
                return repository.RemoveUser(groupId, userId);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return false;
        }

        #endregion

        #region parameter
        public Parameter GetParameter(int parameterId)
        {
            try
            {
                var repository = new ParameterRepository();
                return repository.Get(parameterId);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return null;
        }


        public List<Parameter> GetAllParameter()
        {
            try
            {
                var repository = new ParameterRepository();
                return CollectionHelper.ToList(repository.GetAll());
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return new List<Parameter>();
        }

        public List<Parameter> GetParameterByQuery(Query query)
        {
            try
            {
                var repository = new ParameterRepository();
                return CollectionHelper.ToList(repository.GetListByQuery(query));
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return new List<Parameter>();
        }

        public List<Parameter> GetParameterByPagerQuery(PagerQuery query, out int qty)
        {
            qty = 0;
            try
            {
                var repository = new ParameterRepository();
                return CollectionHelper.ToList(repository.GetByPager(query, out qty));
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return new List<Parameter>();
        }

        public Parameter GetParameterByCode(string applicationCode, string parameterCode)
        {
            try
            {
                var repository = new ParameterRepository();
                return repository.GetByCode(applicationCode, parameterCode);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return null;
        }

        public Parameter CreateParameter(Parameter parameter)
        {
            try
            {
                var repository = new ParameterRepository();

                // validate new parametercode exists.
                var applicationRepository = new ApplicationRepository();
                Application application = applicationRepository.Get(parameter.ApplicationId);
                if (application == null)
                    BusinessExceptionHelper.ThrowBusinessException("APPLICATION_NOTFOUND");

                Parameter oldParameter = repository.GetByCode(application.ApplicationCode, parameter.ParameterCode);
                if (oldParameter != null)
                    BusinessExceptionHelper.ThrowBusinessException("PARAMETRCODE_EXISTS");

                int newId = repository.Create(parameter);
                if (newId > 0)
                {
                    parameter.ParameterId = newId;
                    return parameter;
                }
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return null;
        }

        public bool UpdateParameter(Parameter parameter)
        {
            try
            {
                var repository = new ParameterRepository();

                // validate parametercode exists.
                var applicationRepository = new ApplicationRepository();
                Application application = applicationRepository.Get(parameter.ApplicationId);
                if (application == null)
                    BusinessExceptionHelper.ThrowBusinessException("APPLICATION_NOTFOUND");
                Parameter oldParameter = repository.GetByCode(application.ApplicationCode, parameter.ParameterCode);
                if (oldParameter != null && oldParameter.ParameterId != parameter.ParameterId)
                    BusinessExceptionHelper.ThrowBusinessException("PARAMETRCODE_EXISTS");

                return repository.Update(parameter);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return false;
        }

        public bool DeleteParameter(int parameterId)
        {
            try
            {
                var repository = new ParameterRepository();
                return repository.Delete(parameterId);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return false;
        }
        #endregion

        #region role
        public List<Role> GetAllRole()
        {
            try
            {
                var repository = new RoleRepository();
                return CollectionHelper.ToList(repository.GetAll());
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return new List<Role>();
        }

        public List<Role> GetRoleByQuery(Query query)
        {
            try
            {
                var repository = new RoleRepository();
                return CollectionHelper.ToList(repository.GetListByQuery(query));
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return new List<Role>();
        }

        public Role GetRoleByCode(string applicationCode, string roleCode)
        {
            try
            {
                var repository = new RoleRepository();
                return repository.GetByCode(applicationCode, roleCode);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return null;
        }

        public int CreateRole(Role role)
        {
            try
            {
                var repository = new RoleRepository();

                // validate new role exists.
                var applicationRepository = new ApplicationRepository();
                Application application = applicationRepository.Get(role.ApplicationId);
                if (application == null)
                    BusinessExceptionHelper.ThrowBusinessException("APPLICATION_NOTFOUND");
                Role oldRole = repository.GetByCode(application.ApplicationCode, role.RoleCode);
                if (oldRole != null)
                    BusinessExceptionHelper.ThrowBusinessException("ROLECODE_EXISTS");

                return repository.Create(role);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return 0;
        }

        public bool UpdateRole(Role role)
        {
            try
            {
                var repository = new RoleRepository();
                // validate new role exists.
                var applicationRepository = new ApplicationRepository();
                Application application = applicationRepository.Get(role.ApplicationId);
                if (application == null)
                    BusinessExceptionHelper.ThrowBusinessException("APPLICATION_NOTFOUND");
                Role oldRole = repository.GetByCode(application.ApplicationCode, role.RoleCode);
                if (oldRole != null && oldRole.RoleId != role.RoleId)
                    BusinessExceptionHelper.ThrowBusinessException("ROLECODE_EXISTS");

                return repository.Update(role);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return false;
        }

        public bool DeleteRole(int roleId)
        {
            try
            {
                var repository = new RoleRepository();
                return repository.Delete(roleId);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return false;
        }

        public List<Function> GetRoleFunctions(int roleId)
        {
            try
            {
                var repository = new RoleRepository();
                return CollectionHelper.ToList(repository.GetFunctions(roleId));
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return new List<Function>();
        }

        public bool AddRoleFunction(int roleId, int functionId)
        {
            try
            {
                var repository = new RoleFunctionRepository();
                return repository.AddFunction(roleId, functionId);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return false;
        }

        public bool RemoveRoleFunction(int roleId, int functionId)
        {
            try
            {
                var repository = new RoleFunctionRepository();
                return repository.RemoveFunction(roleId, functionId);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return false;
        }

        public List<Group> GetRoleGroups(int roleId)
        {
            try
            {
                var repository = new RoleRepository();
                return CollectionHelper.ToList(repository.GetGroups(roleId));
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return new List<Group>();
        }

        public bool AddRoleGroup(int roleId, int groupId)
        {
            try
            {
                var repository = new RoleGroupRepository();
                return repository.AddGroup(roleId, groupId);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return false;
        }

        public bool RemoveRoleGroup(int roleId, int groupId)
        {
            try
            {
                var repository = new RoleGroupRepository();
                return repository.RemoveGroup(roleId, groupId);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return false;
        }

        public List<User> GetRoleUsers(int roleId)
        {
            try
            {
                var repository = new RoleRepository();
                return CollectionHelper.ToList(repository.GetUsers(roleId));
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return new List<User>();
        }

        public bool AddRoleUser(int roleId, int userId)
        {
            try
            {
                var repository = new RoleUserRepository();
                return repository.AddUser(roleId, userId);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return false;
        }

        public bool RemoveRoleUser(int roleId, int userId)
        {
            try
            {
                var repository = new RoleUserRepository();
                return repository.RemoveUser(roleId, userId);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return false;
        }
        #endregion

        #region user
        public User GetUser(int userId)
        {
            try
            {
                var repository = new UserRepository();
                return repository.Get(userId);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return null;
        }

        public string GetUserName(int userId)
        {
            try
            {
                User user = GetUser(userId);
                if (user != null)
                    return user.UserName;
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return null;
        }

        public List<User> GetAllUser()
        {
            try
            {
                var repository = new UserRepository();
                return CollectionHelper.ToList(repository.GetAll());
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return new List<User>();
        }

        public List<User> GetUserByQuery(Query query)
        {
            try
            {
                var repository = new UserRepository();
                return CollectionHelper.ToList(repository.GetListByQuery(query));
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return new List<User>();
        }

        public List<User> GetUserByPagerQuery(PagerQuery query, out int qty)
        {
            qty = 0;
            try
            {
                var repository = new UserRepository();
                return CollectionHelper.ToList(repository.GetByPager(query, out qty));
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return new List<User>();
        }

        public User GetUserByCode(string applicationCode, string userCode)
        {
            try
            {
                var repository = new UserRepository();
                return repository.GetByCode(applicationCode, userCode);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return null;
        }

        public int CreateUser(User user)
        {
            try
            {
                var repository = new UserRepository();

                // validate new usercode exists.
                var applicationRepository = new ApplicationRepository();
                Application application = applicationRepository.Get(user.ApplicationId);
                if (application == null)
                    BusinessExceptionHelper.ThrowBusinessException("APPLICATION_NOTFOUND");
                User oldUser = repository.GetByCode(application.ApplicationCode, user.UserCode);
                if (oldUser != null)
                    BusinessExceptionHelper.ThrowBusinessException("USERCODE_EXISTS");

                user.CreateTime = TypeConvertHelper.DatetimeToString(GetServerDateTime());
                return repository.Create(user);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return 0;
        }

        public bool UpdateUser(User user)
        {
            try
            {
                var repository = new UserRepository();

                // validate new usercode exists.
                var applicationRepository = new ApplicationRepository();
                Application application = applicationRepository.Get(user.ApplicationId);
                if (application == null)
                    BusinessExceptionHelper.ThrowBusinessException("APPLICATION_NOTFOUND");
                User oldUser = repository.GetByCode(application.ApplicationCode, user.UserCode);
                if (oldUser != null && oldUser.UserId != user.UserId)
                    BusinessExceptionHelper.ThrowBusinessException("USERCODE_EXISTS");

                return repository.Update(user);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return false;
        }

        public bool DeleteUser(int userId)
        {
            try
            {
                var repository = new UserRepository();
                return repository.Delete(userId);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return false;
        }

        public User ValidateUser(string applicationCode, string userCode, string password, int warehouseId)
        {
            User user = GetUserByCode(applicationCode, userCode);
            if (user != null)
            {
                // update user login time
                user.LoginTime = TypeConvertHelper.DatetimeToString(DateTime.Now);
                UserRepository userRepository = new UserRepository();
                userRepository.Update(user);

                if (user.IsActive && user.Password == password)
                {
                    WarehouseUserRepository repository = new WarehouseUserRepository();
                    if (repository.IsWarehouseUser(warehouseId, user.UserId))
                        return user;
                }
            }

            return null;
        }

        public List<string> GetUserFunctions(string applicationCode, string userCode)
        {
            var repository = new UserRepository();
            IList<UserFunctionView> userFunctions = repository.GetFunctions(applicationCode, userCode);
            List<string> resultList = new List<string>();
            foreach (var userFunction in userFunctions)
                resultList.Add(userFunction.FunctionCode);

            return resultList;
        }
        #endregion
    }
}