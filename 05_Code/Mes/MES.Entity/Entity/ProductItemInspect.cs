using System;
using Frame.Utils.Contract;

namespace MES.Entity
{
    /// <summary>
    ///     $e.Description
    /// </summary>
    public class ProductItemInspect : IBaseEntity
    {
        /// <summary>
        /// </summary>
        public Int32 ProductItemInspectId { get; set; }

        /// <summary>
        /// </summary>
        public Int32 ProductId { get; set; }

        /// <summary>
        /// </summary>
        public String Name { get; set; }

        /// <summary>
        /// </summary>
        public ProductItemInspectType Type { get; set; }

        /// <summary>
        /// </summary>
        public String UnitName { get; set; }

        /// <summary>
        /// </summary>
        public String Content { get; set; }

        /// <summary>
        /// </summary>
        public Int32 Precision { get; set; }

        /// <summary>
        /// </summary>
        public Decimal MinData { get; set; }

        /// <summary>
        /// </summary>
        public Decimal MaxData { get; set; }

        #region IBaseEntity Members

        public int GetEntityId()
        {
            return ProductItemInspectId;
        }

        #endregion
    }
}