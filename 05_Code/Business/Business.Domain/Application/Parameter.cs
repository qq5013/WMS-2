namespace Business.Domain.Application
{
    public class Parameter : DomainObject
    {
        #region property

        /// <summary> 
        /// 应用系统编号
        /// </summary> 
        public int ApplicationId { get; set; }

        /// <summary> 
        /// 参数编号
        /// </summary> 
        public int ParameterId { get; set; }

        /// <summary> 
        /// 参数代码
        /// </summary> 
        public string ParameterCode { get; set; }

        /// <summary> 
        /// 值类型
        /// </summary> 
        public string ValueType { get; set; }

        /// <summary> 
        /// 参数值
        /// </summary> 
        public string ParameterValue { get; set; }

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