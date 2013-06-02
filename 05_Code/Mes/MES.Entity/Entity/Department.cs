using System;
using Frame.Utils.Contract;

namespace MES.Entity
{
    /// <summary>
    ///     部门
    /// </summary>
    public class Department : IBaseEntity
    {
        /// <summary>
        /// </summary>
        public Int32 DepartmentId { get; set; }

        /// <summary>
        ///     公司
        /// </summary>
        public Int32 CompanyId { get; set; }

        /// <summary>
        ///     部门名称
        /// </summary>
        public String Name { get; set; }

        /// <summary>
        ///     部门编码
        /// </summary>
        public String Code { get; set; }

        /// <summary>
        ///     上级部门
        /// </summary>
        public Int32 ParentId { get; set; }

        /// <summary>
        ///     负责人
        /// </summary>
        public Int32 Principal { get; set; }

        /// <summary>
        ///     是否禁用
        /// </summary>
        public Boolean Forbidden { get; set; }

        /// <summary>
        ///     描述
        /// </summary>
        public String Description { get; set; }

        #region IBaseEntity Members

        public int GetEntityId()
        {
            return DepartmentId;
        }

        #endregion
    }
}