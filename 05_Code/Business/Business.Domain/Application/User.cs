namespace Business.Domain.Application
{
    public class User : DomainObject
    {
        #region property

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
        /// 登录口令
        /// </summary> 
        public string Password { get; set; }

        /// <summary> 
        /// 创建时间
        /// </summary> 
        public string CreateTime { get; set; }

        /// <summary> 
        /// 登录时间
        /// </summary> 
        public string LoginTime { get; set; }

        /// <summary> 
        /// 描述
        /// </summary> 
        public string Remark { get; set; }

        /// <summary> 
        /// 是否激活
        /// </summary> 
        public bool IsActive { get; set; }

        #endregion

        public void Disable()
        {
            IsActive = false;
        }

        public void Enable()
        {
            IsActive = true;
        }
    }
}