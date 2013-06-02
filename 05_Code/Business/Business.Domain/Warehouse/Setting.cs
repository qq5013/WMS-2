namespace Business.Domain.Warehouse
{
    public class Setting : DomainObject
    {
        #region property

        /// <summary>
        /// 设置编号
        /// </summary>
        public int SettingId { get; set; }

        /// <summary>
        /// 设置代码
        /// </summary>
        public string SettingCode { get; set; }

        /// <summary>
        /// 仓库编号
        /// </summary>
        public int WarehouseId { get; set; }

        /// <summary>
        /// 值类型
        /// </summary>
        public string ValueType { get; set; }

        /// <summary>
        /// 设置值
        /// </summary>
        public string SettingValue { get; set; }

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

        #endregion property

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