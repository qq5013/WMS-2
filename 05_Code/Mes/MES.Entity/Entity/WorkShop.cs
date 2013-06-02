using System;
using Frame.Utils.Contract;

namespace MES.Entity
{
    /// <summary>
    ///     车间
    /// </summary>
    public class WorkShop : IBaseEntity
    {
        /// <summary>
        /// </summary>
        public Int32 WorkShopId { get; set; }

        /// <summary>
        ///     名称
        /// </summary>
        public String Name { get; set; }

        #region IBaseEntity Members

        public int GetEntityId()
        {
            return WorkShopId;
        }

        #endregion
    }
}