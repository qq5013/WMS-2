using System;
using Frame.Utils.Contract;
using MES.Enum;

namespace MES.Entity
{
    /// <summary>
    ///     工位
    /// </summary>
    public class ProductStation : IBaseEntity, ICloneable
    {
        /// <summary>
        /// </summary>
        public Int32 ProductStationId { get; set; }

        /// <summary>
        ///     生产线
        /// </summary>
        public Int32 ProductLineId { get; set; }

        /// <summary>
        ///     名称
        /// </summary>
        public String Name { get; set; }

        /// <summary>
        ///     状态
        /// </summary>
        public ProductStationStatus Status { get; set; }

        /// <summary>
        ///     代码
        /// </summary>
        public String Code { get; set; }

        /// <summary>
        ///     序号
        /// </summary>
        public Int32 Sequence { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Remark { get; set; }

        #region IBaseEntity Members

        public int GetEntityId()
        {
            return ProductStationId;
        }

        #endregion

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}