namespace Business.Domain.Warehouse
{
    public class Aisle : DomainObject
    {
        #region property

        /// <summary> 
        /// 通道编号
        /// </summary> 
        public int AisleId { get; set; }

        /// <summary> 
        /// 仓库编号
        /// </summary> 
        public int WarehouseId { get; set; }

        /// <summary> 
        /// 通道代码
        /// </summary> 
        public string AisleCode { get; set; }

        /// <summary> 
        /// 通道名称
        /// </summary> 
        public string AisleName { get; set; }

        /// <summary> 
        /// 方向角度
        /// </summary> 
        public int DirectionAngle { get; set; }

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