using System;
using Frame.Utils.Contract;

namespace MES.Entity
{
    /// <summary>
    ///     $e.Description
    /// </summary>
    public class ItemSampleInspectDetail : IBaseEntity
    {
        /// <summary>
        /// </summary>
        public Int32 ItemSampleInspectDetailId { get; set; }

        /// <summary>
        /// </summary>
        public Int32 ItemSampleInspectId { get; set; }

        /// <summary>
        /// </summary>
        public Int32 ProductInspectId { get; set; }

        /// <summary>
        /// </summary>
        public Decimal Data { get; set; }

        /// <summary>
        /// </summary>
        public String Remark { get; set; }

        /// <summary>
        /// </summary>
        public Boolean Result { get; set; }

        #region IBaseEntity Members

        public int GetEntityId()
        {
            return ItemSampleInspectDetailId;
        }

        #endregion
    }
}