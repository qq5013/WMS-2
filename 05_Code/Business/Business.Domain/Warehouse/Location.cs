using System.Collections.Generic;

namespace Business.Domain.Warehouse
{
    public class Location : DomainObject
    {
        #region property

        /// <summary>
        /// 库位编号
        /// </summary>
        public int LocationId { get; set; }

        /// <summary>
        /// 库位代码
        /// </summary>
        public string LocationCode { get; set; }

        /// <summary>
        /// 库位名称
        /// </summary>
        public string LocationName { get; set; }

        /// <summary>
        /// 仓库编号
        /// </summary>
        public int WarehouseId { get; set; }

        /// <summary>
        /// 库区编号
        /// </summary>
        public int AreaId { get; set; }

        /// <summary>
        /// 货架编号
        /// </summary>
        public int ShelfId { get; set; }

        /// <summary>
        /// 货架行号
        /// </summary>
        public int ShelfRow { get; set; }

        /// <summary>
        /// 货架列号
        /// </summary>
        public int ShelfColumn { get; set; }

        /// <summary>
        /// 货架深度
        /// </summary>
        public int ShelfDepth { get; set; }

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
        /// 承重
        /// </summary>
        public decimal BearingWeight { get; set; }

        /// <summary>
        /// 库位条码
        /// </summary>
        public string Barcode { get; set; }

        /// <summary>
        /// 路线序号
        /// </summary>
        public int Route { get; set; }

        ///// <summary>
        ///// 库存数量
        ///// </summary>
        //public int LocationNumber { get; set; }

        /// <summary>
        /// 描述
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
        /// 是否禁用
        /// </summary>
        public bool IsActive { get; set; }

        #endregion property

        #region additional property

        //public IList<Tag> Tags { get; set; }

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