using System.ServiceModel;
using Business.Common.Exception.ExceptionCode;

namespace Business.Common.Exception
{
    public class WcfExceptionHelper
    {
        /// <summary>
        /// 抛出Wcf异常
        /// </summary>
        /// <param name="originalException">原生异常</param>
        public static void ThrowWcfException(System.Exception originalException)
        {
            BusinessException bex;
            if (originalException is BusinessException)
            {
                bex = originalException as BusinessException;
            }
            else
            {
                bex = BusinessExceptionHelper.CreateBusinessException(SystemExceptionCodeHelper.UntreatedAnomaly,
                                                                      originalException);
            }

            var exception = new WcfException(bex.ExceptionCode, bex.ExceptionMessage, bex);
            throw new FaultException<WcfException>(exception, exception.ExceptionMessage);
        }
    }
}