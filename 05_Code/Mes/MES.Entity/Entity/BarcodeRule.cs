using System;
using Frame.Utils.Contract;
using MES.Enum;

namespace MES.Entity
{
    /// <summary>
    ///     条码规则
    /// </summary>
    public class BarcodeRule : IBaseEntity
    {
        /// <summary>
        /// </summary>
        public Int32 BarcodeRuleId { get; set; }

        /// <summary>
        ///     产品Id
        /// </summary>
        public TraceType TraceType { get; set; }

        /// <summary>
        ///     规则内容
        /// </summary>
        public String RuleContent { get; set; }

        /// <summary>
        ///     规则描述
        /// </summary>
        public String RuleDesc { get; set; }

        #region IBaseEntity Members

        public int GetEntityId()
        {
            return BarcodeRuleId;
        }

        #endregion
    }
}