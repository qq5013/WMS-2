﻿using System.Runtime.Serialization;

namespace Business.Common.Exception
{
    [DataContract]
    public class ServiceError
    {
        /// <summary>
        /// 构造器
        /// </summary>
        /// <param name="errorCode">异常代码</param>
        /// <param name="errorMessage">异常信息</param>
        /// <param name="stackTrace">原生异常信息</param>
        public ServiceError(string errorCode, string errorMessage, string stackTrace)
        {
            ErrorCode = errorCode;
            ErrorMessage = errorMessage;
            StackTrace = stackTrace;
        }

        public ServiceError(string errorCode, string errorMessage)
        {
            ErrorCode = errorCode;
            ErrorMessage = errorMessage;
        }

        /// <summary>
        /// 异常代码
        /// </summary>
        [DataMember]
        public string ErrorCode { get; set; }

        /// <summary>
        /// 异常信息
        /// </summary>
        [DataMember]
        public string ErrorMessage { get; set; }

        /// <summary>
        /// 原生异常信息
        /// </summary>
        [DataMember]
        public string StackTrace { get; set; }
    }
}