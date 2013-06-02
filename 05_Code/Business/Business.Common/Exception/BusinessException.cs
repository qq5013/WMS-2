using System;
using System.Runtime.Serialization;

namespace Business.Common.Exception
{
    [DataContract]
    public class BusinessException : ApplicationException
    {
        /// <summary>
        /// 业务异常
        /// </summary>
        /// <param name="message">原生异常信息</param>
        /// <param name="innerException">原生异常</param>
        /// <param name="exceptionCode">业务异常代码</param>
        /// <param name="exceptionMessage">业务异常信息</param>
        public BusinessException(string message, System.Exception innerException, string exceptionCode, string exceptionMessage)
            : base(message, innerException)
        {
            ExceptionCode = exceptionCode;
            ExceptionMessage = exceptionMessage;
        }

        public BusinessException(string exceptionCode, string exceptionMessage)
        {
            ExceptionCode = exceptionCode;
            ExceptionMessage = exceptionMessage;
        }

        /// <summary>
        /// 异常代码
        /// </summary>
        [DataMember]
        public string ExceptionCode { get; set; }

        /// <summary>
        /// 异常消息
        /// </summary>
        [DataMember]
        public string ExceptionMessage { get; set; }
    }
}