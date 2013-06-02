using System;
using Frame.Utils.Contract;

namespace MES.Entity
{
    /// <summary>
    ///     工步依赖
    /// </summary>
    public class ProcessStepDependency : IBaseEntity
    {
        /// <summary>
        /// </summary>
        public Int32 ProcessStepDependencyId { get; set; }

        /// <summary>
        ///     工步
        /// </summary>
        public Int32 ProcessStepId { get; set; }

        /// <summary>
        ///     依赖
        /// </summary>
        public Int32 DependencyId { get; set; }

        #region IBaseEntity Members

        public int GetEntityId()
        {
            return ProcessStepDependencyId;
        }

        #endregion
    }
}