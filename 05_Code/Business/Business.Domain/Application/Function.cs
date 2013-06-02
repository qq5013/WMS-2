namespace Business.Domain.Application
{
    public class Function : DomainObject
    {
        #region property

        /// <summary> 
        /// 应用系统编号
        /// </summary> 
        public int ApplicationId { get; set; }

        /// <summary> 
        /// 功能编号
        /// </summary> 
        public int FunctionId { get; set; }

        /// <summary> 
        /// 功能级别
        /// </summary> 
        public int FunctionLevel { get; set; }

        /// <summary> 
        /// 父级功能编号
        /// </summary> 
        public int ParentId { get; set; }

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