using System;
using System.ServiceModel;
using Business.Common.Exception.ExceptionCode;
using Framework.Core.Exception;

namespace Business.Common.Exception
{
    public class ServiceExceptionHelper
    {
        /// <summary>
        /// 抛出Wcf异常
        /// </summary>
        /// <param name="originalException">原生异常</param>
        public static void ThrowServiceException(System.Exception originalException)
        {
            ExceptionHelper.HandleException(originalException, true, false);

            BusinessException bex;
            if (originalException is BusinessException)
            {
                bex = originalException as BusinessException;
            }
            else
            {
                if (originalException is DataAccessException)
                {
                    bex = BusinessExceptionHelper.CreateBusinessException(SystemExceptionCodeHelper.InvalidDataAccessAnomaly,
                                                                         originalException);
                }
                else
                {
                    bex = BusinessExceptionHelper.CreateBusinessException(SystemExceptionCodeHelper.UntreatedAnomaly,
                                                                          originalException);
                }
            }

            var exception = new ServiceError(bex.ExceptionCode, bex.ExceptionMessage, originalException.ToString());
            throw new FaultException<ServiceError>(exception, new FaultReason(bex.ExceptionMessage), new FaultCode(bex.ExceptionCode));
        }
    }
}