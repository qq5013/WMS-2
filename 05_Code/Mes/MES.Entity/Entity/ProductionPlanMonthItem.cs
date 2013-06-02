using System;
using Frame.Utils.Contract;

namespace MES.Entity
{
    /// <summary>
    ///     生产计划明细追踪
    /// </summary>
    public class ProductionPlanMonthItem : IBaseEntity, ICloneable
    {
        public object Clone()
        {
            return MemberwiseClone();
        }
        /// <summary>
        /// </summary>
        public Int32 ProductionPlanMonthItemId { get; set; }

        /// <summary>
        /// </summary>
        public Int32 ProductionPlanDetailId { get; set; }

        /// <summary>
        ///     代码
        /// </summary>
        public String Code { get; set; }

        /// <summary>
        /// </summary>
        public Int32 Item0 { get; set; }

        /// <summary>
        /// </summary>
        public Int32 Item1 { get; set; }

        /// <summary>
        /// </summary>
        public Int32 Item2 { get; set; }

        /// <summary>
        /// </summary>
        public Int32 Item3 { get; set; }

        /// <summary>
        /// </summary>
        public Int32 Item4 { get; set; }

        /// <summary>
        /// </summary>
        public Int32 Item5 { get; set; }

        /// <summary>
        /// </summary>
        public Int32 Item6 { get; set; }

        /// <summary>
        /// </summary>
        public Int32 Item7 { get; set; }

        /// <summary>
        /// </summary>
        public Int32 Item8 { get; set; }

        /// <summary>
        /// </summary>
        public Int32 Item9 { get; set; }

        /// <summary>
        /// </summary>
        public Int32 Item10 { get; set; }

        /// <summary>
        /// </summary>
        public Int32 Item11 { get; set; }

        /// <summary>
        /// </summary>
        public Int32 Item12 { get; set; }

        /// <summary>
        /// </summary>
        public Int32 Item31 { get; set; }

        /// <summary>
        /// </summary>
        public Int32 Item30 { get; set; }

        /// <summary>
        /// </summary>
        public Int32 Item29 { get; set; }

        /// <summary>
        /// </summary>
        public Int32 Item28 { get; set; }

        /// <summary>
        /// </summary>
        public Int32 Item27 { get; set; }

        /// <summary>
        /// </summary>
        public Int32 Item26 { get; set; }

        /// <summary>
        /// </summary>
        public Int32 Item25 { get; set; }

        /// <summary>
        /// </summary>
        public Int32 Item24 { get; set; }

        /// <summary>
        /// </summary>
        public Int32 Item23 { get; set; }

        /// <summary>
        /// </summary>
        public Int32 Item22 { get; set; }

        /// <summary>
        /// </summary>
        public Int32 Item21 { get; set; }

        /// <summary>
        /// </summary>
        public Int32 Item20 { get; set; }

        /// <summary>
        /// </summary>
        public Int32 Item19 { get; set; }

        /// <summary>
        /// </summary>
        public Int32 Item18 { get; set; }

        /// <summary>
        /// </summary>
        public Int32 Item17 { get; set; }

        /// <summary>
        /// </summary>
        public Int32 Item16 { get; set; }

        /// <summary>
        /// </summary>
        public Int32 Item15 { get; set; }

        /// <summary>
        /// </summary>
        public Int32 Item14 { get; set; }

        /// <summary>
        /// </summary>
        public Int32 Item13 { get; set; }

        #region IBaseEntity Members

        public int GetEntityId()
        {
            return ProductionPlanMonthItemId;
        }

        #endregion
    }
}