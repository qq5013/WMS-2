using System.Runtime.Serialization;
using System.ServiceModel;

namespace Business.Common.Exception
{
    [DataContract]
    public class WcfException : ExceptionDetail
    {
        /// <summary>
        /// 构造器
        /// </summary>
        /// <param name="exceptionCode">异常代码</param>
        /// <param name="exceptionMessage">异常消息</param>
        /// <param name="originalException">原生异常</param>
        public WcfException(string exceptionCode, string exceptionMessage, System.Exception originalException)
            : base(originalException)
        {
            ExceptionCode = exceptionCode;
            ExceptionMessage = exceptionMessage;
            OriginalException = originalException;
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

        /// <summary>
        /// 原生异常
        /// </summary>
        [DataMember]
        public System.Exception OriginalException { get; set; }
    }
}