namespace Business.Common.Exception.ExceptionCode
{
    /// <summary>
    /// 系统错误描述
    /// </summary>
    public static class SystemExceptionCodeHelper
    {
        /// <summary>
        /// 未处理的异常
        /// </summary>
        public const string UntreatedAnomaly = "UNTREATED_ANOMALY";

        /// <summary>
        /// 未处理的系统异常
        /// </summary>
        public const string UntreatedSystemAnomaly = "UNTREATED_SYSTEM_ANOMALY";

        /// <summary>
        /// 未处理的业务异常
        /// </summary>
        public const string UntreatedBusinessAnomaly = "UNTREATED_BUSINESS_ANOMALY";

        /// <summary>
        /// 未处理的服务异常
        /// </summary>
        public const string UntreatedServiceAnomaly = "UNTREATED_SERVICE_ANOMALY";

        /// <summary>
        /// 不合法的实体异常
        /// </summary>
        public const string InvalidEntityAnomaly = "INVALID_ENEITY_ANOMALY";

        /// <summary>
        /// 未处理的数据库访问异常
        /// </summary>
        public const string InvalidDataAccessAnomaly = "DATAACCESS_ERROR";
    }
}