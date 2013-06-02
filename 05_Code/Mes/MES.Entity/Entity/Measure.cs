using System;
using Frame.Utils.Contract;
using MES.Enum;

namespace MES.Entity
{
    /// <summary>
    ///     计量单位
    /// </summary>
    public class Measure : IBaseEntity
    {
        /// <summary>
        /// </summary>
        public Int32 MeasureId { get; set; }

        /// <summary>
        ///     代码
        /// </summary>
        public String Code { get; set; }

        /// <summary>
        ///     名称
        /// </summary>
        public String Name { get; set; }

        /// <summary>
        ///     类型
        /// </summary>
        public MeasureType Type { get; set; }

        /// <summary>
        ///     上级单位
        /// </summary>
        public Int32 ParentId { get; set; }

        /// <summary>
        ///     描述
        /// </summary>
        public String Description { get; set; }

        /// <summary>
        ///     转换率
        /// </summary>
        public Int32 ConvertRate { get; set; }

        #region IBaseEntity Members

        public int GetEntityId()
        {
            return MeasureId;
        }

        #endregion
    }
}