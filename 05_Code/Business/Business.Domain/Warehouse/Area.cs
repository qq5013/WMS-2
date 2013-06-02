using System.Collections.Generic;

namespace Business.Domain.Warehouse
{
    public class Area : DomainObject
    {
        #region property

        /// <summary>
        /// 库区编号
        /// </summary>
        public int AreaId { get; set; }

        /// <summary>
        /// 库区代码
        /// </summary>
        public string AreaCode { get; set; }

        /// <summary>
        /// 库区名称
        /// </summary>
        public string AreaName { get; set; }

        /// <summary>
        /// 仓库编号
        /// </summary>
        public int WarehouseId { get; set; }

        /// <summary>
        /// 库区类型
        /// </summary>
        public int AreaType { get; set; }

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

        //public IList<OperatorGroup> Groups { get; set; }

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