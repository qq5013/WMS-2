using System;
using Frame.Utils.Contract;

namespace MES.Entity
{
    /// <summary>
    ///     银行
    /// </summary>
    public class Bank : IBaseEntity
    {
        /// <summary>
        /// </summary>
        public Int32 BankId { get; set; }

        /// <summary>
        ///     代码
        /// </summary>
        public String Code { get; set; }

        /// <summary>
        ///     名称
        /// </summary>
        public String Name { get; set; }

        /// <summary>
        ///     简称
        /// </summary>
        public String ShortName { get; set; }

        #region IBaseEntity Members

        public int GetEntityId()
        {
            return BankId;
        }

        #endregion
    }
}