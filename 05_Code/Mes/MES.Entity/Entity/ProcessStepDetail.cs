using System;
using Frame.Utils.Contract;

namespace MES.Entity
{
    /// <summary>
    ///     工步明细
    /// </summary>
    public class ProcessStepDetail : IBaseEntity, ICloneable
    {
        /// <summary>
        /// </summary>
        public Int32 ProcessStepDetailId { get; set; }


        /// <summary>
        ///     工序
        /// </summary>
        public Int32 ProcessId { get; set; }

        /// <summary>
        ///     工步
        /// </summary>
        public Int32 ProcessStepId { get; set; }

        /// <summary>
        ///     SKU
        /// </summary>
        public Int32 SkuId { get; set; }

        /// <summary>
        ///     数量
        /// </summary>
        public Int32 Quantity { get; set; }

        /// <summary>
        ///     序号
        /// </summary>
        public Int32 Sequence { get; set; }

        /// <summary>
        ///     标题
        /// </summary>
        public String Name { get; set; }

        /// <summary>
        ///     提示
        /// </summary>
        public String Notice { get; set; }

        /// <summary>
        ///     单位
        /// </summary>
        public int MeasureId { get; set; }

        /// <summary>
        ///     描述
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        ///     装配指导
        /// </summary>
        public string Description { get; set; }

        #region IBaseEntity Members

        public int GetEntityId()
        {
            return ProcessStepDetailId;
        }

        #endregion

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}