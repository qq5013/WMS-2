namespace Business.Domain.Application
{
    public class Application : DomainObject
    {
        #region property

        /// <summary> 
        /// 应用系统编号
        /// </summary> 
        public int ApplicationId { get; set; }

        /// <summary> 
        /// 应用系统代码
        /// </summary> 
        public string ApplicationCode { get; set; }

        /// <summary> 
        /// 应用系统名称
        /// </summary> 
        public string ApplicationName { get; set; }

        /// <summary> 
        /// 备注
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