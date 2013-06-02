namespace Business.Domain.Warehouse
{
    public class Shelf : DomainObject
    {
        #region property

        /// <summary>
        /// 货架编号
        /// </summary>
        public int ShelfId { get; set; }

        /// <summary>
        /// 货架代码
        /// </summary>
        public string ShelfCode { get; set; }

        /// <summary>
        /// 货架名称
        /// </summary>
        public string ShelfName { get; set; }

        /// <summary>
        /// 仓库编号
        /// </summary>
        public int WarehouseId { get; set; }

        /// <summary>
        /// 库区编号
        /// </summary>
        public int AreaId { get; set; }

        /// <summary>
        /// 面向通道编号
        /// </summary>
        public int AisleId { get; set; }

        /// <summary>
        /// 货架类型
        /// </summary>
        public int ShelfType { get; set; }

        /// <summary>
        /// 方向角度
        /// </summary>
        public int DirectionAngle { get; set; }

        /// <summary>
        /// 长度
        /// </summary>
        public decimal Length { get; set; }

        /// <summary>
        /// 宽度
        /// </summary>
        public decimal Width { get; set; }

        /// <summary>
        /// 高度
        /// </summary>
        public decimal Height { get; set; }

        /// <summary>
        /// 行
        /// </summary>
        public int Row { get; set; }

        /// <summary>
        /// 列
        /// </summary>
        public int Column { get; set; }

        /// <summary>
        /// 深度
        /// </summary>
        public int Depth { get; set; }

        /// <summary>
        /// X坐标
        /// </summary>
        public decimal? CoordX { get; set; }

        /// <summary>
        /// Y坐标
        /// </summary>
        public decimal? CoordY { get; set; }

        /// <summary>
        /// Z坐标
        /// </summary>
        public decimal? CoordZ { get; set; }

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