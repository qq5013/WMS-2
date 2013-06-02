using System;
using Frame.Utils.Contract;

namespace MES.Entity
{
    /// <summary>
    ///     生产工单明细
    /// </summary>
    public class MaterialRequisitionDetail : IBaseEntity, ICloneable
    {
        private string _remark;

        public object Clone()
        {
            return MemberwiseClone();
        }
        /// <summary>
        /// </summary>
        public Int32 MaterialRequisitionDetailId { get; set; }

        /// <summary>
        ///     生产工单
        /// </summary>
        public Int32 MaterialRequisitionId { get; set; }

        /// <summary>
        ///     Sku
        /// </summary>
        public Int32 SkuId { get; set; }

        /// <summary>
        ///     数量
        /// </summary>
        public Int32 Quantity { get; set; }

        /// <summary>
        ///     单位
        /// </summary>
        public Int32 MeasureId { get; set; }

        public int ProductId { get; set; }

        public string Remark
        {
            get { return _remark; }
            set { _remark = value; }
        }

        public DateTime FinishDate { get; set; }

        #region IBaseEntity Members

        public int GetEntityId()
        {
            return MaterialRequisitionDetailId;
        }

        #endregion
    }
}