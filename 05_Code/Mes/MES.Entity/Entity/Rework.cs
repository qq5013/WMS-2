using System;
using Frame.Utils.Contract;

namespace MES.Entity
{
    /// <summary>
    ///     返工
    /// </summary>
    public class Rework : IBaseEntity
    {
        /// <summary>
        /// </summary>
        public Int32 ReworkId { get; set; }

        /// <summary>
        ///     返工工序
        /// </summary>
        public Int32 ProductProcedureId { get; set; }

        /// <summary>
        ///     状态
        /// </summary>
        public Int32 Stauts { get; set; }

        /// <summary>
        ///     备注
        /// </summary>
        public String Memo { get; set; }

        /// <summary>
        ///     创建者
        /// </summary>
        public Int32 Creater { get; set; }

        /// <summary>
        ///     创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        ///     计划执行者
        /// </summary>
        public Int32 PlanOperator { get; set; }

        /// <summary>
        ///     计划执行时间
        /// </summary>
        public DateTime PlanOperateTime { get; set; }

        /// <summary>
        ///     实际执行者
        /// </summary>
        public Int32 ActualOperator { get; set; }

        /// <summary>
        ///     实际执行时间
        /// </summary>
        public DateTime ActualOperateTime { get; set; }

        /// <summary>
        ///     操作模式
        /// </summary>
        public Int32 OperatorModel { get; set; }

        #region IBaseEntity Members

        public int GetEntityId()
        {
            return ReworkId;
        }

        #endregion
    }
}