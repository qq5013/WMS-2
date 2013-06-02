using System;
using System.Collections;
using System.IO;
using System.Xml;
using Business.Common.Exception.ExceptionCode;
using Framework.Core.Exception;
using Framework.Core.Logger;
using System.ServiceModel;

namespace Business.Common.Exception
{
    public class BusinessExceptionHelper
    {
        /// <summary>
        /// 业务异常列表
        /// </summary>
        public static Hashtable BusinessExceptionList = new Hashtable();

        /// <summary>
        /// 存储业务异常的XML文档
        /// </summary>
        public static XmlDocument Document = new XmlDocument();

        /// <summary>
        /// 静态构造器
        /// </summary>
        static BusinessExceptionHelper()
        {
            InitExceptionList();
        }

        /// <summary>
        /// 初始化业务异常列表
        /// </summary>
        public static void InitExceptionList()
        {
            try
            {
                string file = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "BusinessException.config");
                Document.Load(file);

                XmlNodeList configNodes = Document.SelectNodes("//" + "exception");
                if (configNodes != null)
                {
                    foreach (XmlNode node in configNodes)
                    {
                        string code = string.Empty;
                        string message = string.Empty;
                        foreach (XmlNode childNode in node)
                        {
                            if (childNode.Name == "code")
                                code = childNode.InnerText;
                            else if (childNode.Name == "message")
                                message = childNode.InnerText;
                        }

                        if (code != string.Empty && message != string.Empty)
                        {
                            BusinessExceptionList.Add(code, message);
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                Document = null;
                LogHelper.WriteExceptionLog(ex.ToString());
            }
        }

        /// <summary>
        /// 获取异常描述信息
        /// </summary>
        /// <param name="exceptionCode">异常代码</param>
        /// <returns>异常描述信息</returns>
        private static string GetExceptionMessage(string exceptionCode)
        {
            string message;
            try
            {
                message = BusinessExceptionList[exceptionCode].ToString();
            }
            catch
            {
                const string code = SystemExceptionCodeHelper.UntreatedSystemAnomaly;
                message = GetExceptionMessage(code);
            }

            return message;
        }

        /// <summary>
        /// 获取业务异常
        /// </summary>
        /// <param name="exceptionCode">业务异常代码</param>
        /// <param name="innerException">原生异常</param>
        /// <returns>业务异常对象</returns>
        public static BusinessException CreateBusinessException(string exceptionCode, System.Exception innerException)
        {
            string exceptionMessage = GetExceptionMessage(exceptionCode);

            return new BusinessException(string.Empty, innerException, exceptionCode,
                                         exceptionMessage);
        }

        /// <summary>
        /// 捕捉异常,无法将错误从Service传递到Client
        /// </summary>
        /// <param name="exception">异常对象</param>
        /// <param name="writeLog">是否记录异常日志</param>
        /// <param name="throwException">是否抛出异常</param>
        public static void HandleException(System.Exception exception, bool writeLog, bool throwException)
        {
            ExceptionHelper.HandleException(exception, writeLog, throwException);
        }

        /// <summary>
        /// 抛出业务异常
        /// </summary>
        /// <param name="exceptionCode">业务异常代码</param>
        /// /// <param name="exceptionMessage">业务异常信息</param>
        public static void ThrowBusinessException(string exceptionCode, string exceptionMessage)
        {
            throw new BusinessException(exceptionCode, exceptionMessage);
        }

        /// <summary>
        /// 抛出业务异常 (三段式异常代码： 异常主体_操作/_异常说明，如 INBOUNDBILL_CREATE_ERROR)
        /// </summary>
        /// <param name="exceptionCode">业务异常代码</param>
        public static void ThrowBusinessException(string exceptionCode)
        {
            throw CreateBusinessException(exceptionCode, null);
        }

        //public static void ThrowBusinessException(string exceptionCode, string exceptionMessage)
        //{
        //    throw CreateBusinessException(exceptionCode, null);
        //}

        /// <summary>
        /// 抛出业务异常
        /// </summary>
        /// <param name="exceptionCode">业务异常代码</param>
        /// <param name="originalException">原生内部异常</param>
        public static void ThrowBusinessException(string exceptionCode, System.Exception originalException)
        {
            throw CreateBusinessException(exceptionCode, originalException);
        }

        public static void HandleServiceError(FaultException<ServiceError> exception)
        {
            if (exception.Detail != null)
            {
                BusinessExceptionHelper.ThrowBusinessException(exception.Detail.ErrorCode, exception.Detail.ErrorMessage);
            }
            else
            {
                throw exception;
            }
            
        }

    }
}