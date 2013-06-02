using System;
using Frame.Utils.Contract;

namespace MES.Entity
{
    /// <summary>
    ///     支付方式
    /// </summary>
    public class Payment : IBaseEntity
    {
        /// <summary>
        /// </summary>
        public Int32 PaymentId { get; set; }

        /// <summary>
        ///     名称
        /// </summary>
        public String Name { get; set; }

        /// <summary>
        ///     代码
        /// </summary>
        public String Code { get; set; }

        #region IBaseEntity Members

        public int GetEntityId()
        {
            return PaymentId;
        }

        #endregion
    }
}