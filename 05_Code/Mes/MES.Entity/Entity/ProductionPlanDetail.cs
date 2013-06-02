using System;
using System.Collections.Generic;
using System.ComponentModel;
using Frame.Utils.Contract;

namespace MES.Entity
{
    /// <summary>
    ///     生产计划明细
    /// </summary>
    public class ProductionPlanDetail : IBaseEntity, ICloneable
    {
        private readonly List<ProductionPlanMonthItem> _details = new List<ProductionPlanMonthItem>();

        /// <summary>
        /// </summary>
        public Int32 ProductionPlanDetailId { get; set; }

        /// <summary>
        ///     生产计划
        /// </summary>
        public Int32 ProductionPlanId { get; set; }

        /// <summary>
        ///     产品
        /// </summary>
        public Int32 SkuId { get; set; }

        /// <summary>
        ///     采购数量
        /// </summary>
        public Int32 PurchaseQuantity { get; set; }

        /// <summary>
        ///     数量
        /// </summary>
        public Int32 Quantity { get; set; }

        /// <summary>
        ///     备注
        /// </summary>
        public String Remark { get; set; }

        /// <summary>
        /// </summary>
        public Int32 MeasureId { get; set; }

        

        /// <summary>
        ///     产品代码
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// 完工日期
        /// </summary>
        public DateTime FinishDate { get; set; }

        #region IBaseEntity Members

        public int GetEntityId()
        {
            return ProductionPlanDetailId;
        }

        #endregion

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}