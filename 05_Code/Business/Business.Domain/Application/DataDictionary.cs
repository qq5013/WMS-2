namespace Business.Domain.Application
{
    public class DataDictionary : DomainObject
    {
        #region property

        /// <summary> 
        /// 应用系统编号
        /// </summary> 
        public int ApplicationId { get; set; }

        /// <summary> 
        /// 字典编号
        /// </summary> 
        public int DictionaryId { get; set; }

        /// <summary> 
        /// 字典级别
        /// </summary> 
        public int DictionaryLevel { get; set; }

        /// <summary> 
        /// 父级字典编号
        /// </summary> 
        public int ParentId { get; set; }

        /// <summary> 
        /// 字典分类
        /// </summary> 
        public string Category { get; set; }

        /// <summary> 
        /// 字典代码
        /// </summary> 
        public string DictionaryCode { get; set; }

        /// <summary> 
        /// 字典值
        /// </summary> 
        public string DictionaryValue { get; set; }

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