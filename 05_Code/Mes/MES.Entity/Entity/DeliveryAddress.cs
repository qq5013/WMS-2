using System;
using Frame.Utils.Contract;

namespace MES.Entity
{
    /// <summary>
    ///     $e.Description
    /// </summary>
    public class DeliveryAddress : IBaseEntity
    {
        /// <summary>
        /// </summary>
        public Int32 DeliveryAddressId { get; set; }

        /// <summary>
        ///     代码
        /// </summary>
        public String Code { get; set; }

        /// <summary>
        ///     名称
        /// </summary>
        public String Name { get; set; }

        /// <summary>
        ///     描述
        /// </summary>
        public String Description { get; set; }

        /// <summary>
        ///     备注
        /// </summary>
        public String Remark { get; set; }

        #region IBaseEntity Members

        public int GetEntityId()
        {
            return DeliveryAddressId;
        }

        #endregion
    }
}