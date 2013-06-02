namespace Business.Domain.Warehouse
{
    public class Container : DomainObject
    {
        #region property

        /// <summary>
        /// 容器编号
        /// </summary>
        public int ContainerId { get; set; }

        /// <summary>
        /// 容器代码
        /// </summary>
        public string ContainerCode { get; set; }

        /// <summary>
        /// 容器名称
        /// </summary>
        public string ContainerName { get; set; }

        /// <summary>
        /// 隶属仓库
        /// </summary>
        public int WarehouseId { get; set; }

        /// <summary>
        /// 容器类型
        /// </summary>
        public int ContainerType { get; set; }

        /// <summary>
        /// 容器条码
        /// </summary>
        public string Barcode { get; set; }

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

        #region additional property

        //public ContainerType Type { get; set; }

        #endregion additional property

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