using System;
using Frame.Utils.Contract;

namespace MES.Entity
{
    /// <summary>
    ///     运输方式
    /// </summary>
    public class ShipVia : IBaseEntity
    {
        /// <summary>
        /// </summary>
        public Int32 ShipViaId { get; set; }

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
            return ShipViaId;
        }

        #endregion
    }
}