namespace Business.Domain.Application
{
    public class UserFunctionView
    {
        /// <summary> 
        /// 应用系统编号
        /// </summary> 
        public int ApplicationId { get; set; }

        /// <summary> 
        /// 用户编号
        /// </summary> 
        public int UserId { get; set; }

        /// <summary> 
        /// 用户代码
        /// </summary> 
        public string UserCode { get; set; }

        /// <summary> 
        /// 用户名称
        /// </summary> 
        public string UserName { get; set; }

        /// <summary> 
        /// 功能编号
        /// </summary> 
        public int FunctionId { get; set; }

        /// <summary> 
        /// 功能代码
        /// </summary> 
        public string FunctionCode { get; set; }

        /// <summary> 
        /// 功能名称
        /// </summary> 
        public string FunctionName { get; set; }

        /// <summary> 
        /// 资源标识符
        /// </summary> 
        public string ResourceIdentifier { get; set; }
    }
}
