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
    public class TestService : ITestService
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
        #endregion

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

        public Application CreateApplication(Application application)
        {
            try
            {
                Application oldApplication = GetApplicationByCode(application.ApplicationCode);
                if (oldApplication != null)
                {
                    BusinessExceptionHelper.ThrowBusinessException(ApplicationExceptionCodeHelper.ApplicationCodeExist);
                }

                int newId = ApplicationRepository.Create(application);
                application.ApplicationId = newId;

                return application;
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return null;
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


        public bool DeleteApplication(Application application)
        {
            try
            {
                return ApplicationRepository.Delete(application);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return false;
        }
        #endregion application
    }
}
