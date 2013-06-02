using System;
using Frame.Utils.Contract;

namespace MES.Entity
{
    /// <summary>
    ///     仓库
    /// </summary>
    public class Warehouse : IBaseEntity
    {
        /// <summary>
        /// </summary>
        public Int32 WarehouseId { get; set; }

        /// <summary>
        ///     名称
        /// </summary>
        public String Name { get; set; }

        /// <summary>
        ///     代码
        /// </summary>
        public String Code { get; set; }

        /// <summary>
        ///     部门
        /// </summary>
        public Int32 DepartmentId { get; set; }

        /// <summary>
        ///     面积
        /// </summary>
        public Decimal Acreage { get; set; }

        /// <summary>
        ///     负责人
        /// </summary>
        public Int32 Principal { get; set; }

        /// <summary>
        ///     电话
        /// </summary>
        public String Phone { get; set; }

        /// <summary>
        ///     传真
        /// </summary>
        public String Fax { get; set; }

        /// <summary>
        ///     邮箱
        /// </summary>
        public String Email { get; set; }

        /// <summary>
        ///     地址
        /// </summary>
        public String Address { get; set; }

        /// <summary>
        ///     邮编
        /// </summary>
        public String ZipCode { get; set; }

        /// <summary>
        ///     描述
        /// </summary>
        public String Description { get; set; }

        /// <summary>
        ///     国家
        /// </summary>
        public String Country { get; set; }

        /// <summary>
        ///     省份
        /// </summary>
        public String Province { get; set; }

        /// <summary>
        ///     城市
        /// </summary>
        public String City { get; set; }

        #region IBaseEntity Members

        public int GetEntityId()
        {
            return WarehouseId;
        }

        #endregion
    }
}