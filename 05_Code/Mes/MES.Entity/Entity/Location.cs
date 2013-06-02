using System;
using Frame.Utils.Contract;

namespace MES.Entity
{
    /// <summary>
    ///     库位
    /// </summary>
    public class Location : IBaseEntity
    {
        /// <summary>
        /// </summary>
        public Int32 LocationId { get; set; }

        /// <summary>
        ///     仓库
        /// </summary>
        public Int32 WarehouseId { get; set; }

        /// <summary>
        ///     名称
        /// </summary>
        public String Name { get; set; }

        /// <summary>
        ///     代码
        /// </summary>
        public String Code { get; set; }

        /// <summary>
        ///     库位类型
        /// </summary>
        public Int32 LocationType { get; set; }

        /// <summary>
        ///     长度
        /// </summary>
        public Decimal Length { get; set; }

        /// <summary>
        ///     宽度
        /// </summary>
        public Decimal Width { get; set; }

        /// <summary>
        ///     高度
        /// </summary>
        public Decimal Height { get; set; }

        /// <summary>
        ///     存储类型
        /// </summary>
        public Int32 StorageType { get; set; }

        /// <summary>
        ///     库位状态
        /// </summary>
        public Int32 LocationStatus { get; set; }

        /// <summary>
        ///     库位序号
        /// </summary>
        public Int32 Sequence { get; set; }

        /// <summary>
        ///     描述
        /// </summary>
        public String Descripton { get; set; }

        #region IBaseEntity Members

        public int GetEntityId()
        {
            return LocationId;
        }

        #endregion
    }
}