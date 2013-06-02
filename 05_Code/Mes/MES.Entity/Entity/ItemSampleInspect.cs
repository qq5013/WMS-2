using System;
using Frame.Utils.Contract;

namespace MES.Entity
{
    /// <summary>
    ///     $e.Description
    /// </summary>
    public class ItemSampleInspect : IBaseEntity
    {
        /// <summary>
        /// </summary>
        public Int32 ItemSampleInspectId { get; set; }

        /// <summary>
        /// </summary>
        public Int32 ItemId { get; set; }

        /// <summary>
        /// </summary>
        public Int32 ResultId { get; set; }

        /// <summary>
        /// </summary>
        public Boolean Complated { get; set; }

        /// <summary>
        /// </summary>
        public Int32 ConfirmerId { get; set; }

        #region IBaseEntity Members

        public int GetEntityId()
        {
            return ItemSampleInspectId;
        }

        #endregion
    }
}