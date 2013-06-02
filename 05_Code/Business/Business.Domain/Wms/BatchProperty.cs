namespace Business.Domain.Wms
{
    public class BatchProperty : DomainObject
    {
        #region porperty

        /// <summary>
        /// 属性编号
        /// </summary>
        public int PropertyId { get; set; }

        /// <summary>
        /// 属性代码
        /// </summary>
        public string PropertyCode { get; set; }

        /// <summary>
        /// 属性名称
        /// </summary>
        public string PropertyName { get; set; }

        /// <summary>
        /// 缺省值
        /// </summary>
        public string DefaultValue { get; set; }

        /// <summary>
        /// 值类型
        /// </summary>
        public string ValueType { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 创建用户
        /// </summary>
        public int CreateUser { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public string CreateTime { get; set; }

        /// <summary>
        /// 编辑用户
        /// </summary>
        public int EditUser { get; set; }

        /// <summary>
        /// 编辑时间
        /// </summary>
        public string EditTime { get; set; }

        /// <summary>
        /// 是否激活
        /// </summary>
        public bool IsActive { get; set; }

        #endregion porperty

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