using System;
using Frame.Utils.Contract;

namespace MES.Entity
{
    /// <summary>
    ///     员工
    /// </summary>
    public class Employee : IBaseEntity
    {
        /// <summary>
        /// </summary>
        public Int32 EmployeeId { get; set; }

        /// <summary>
        ///     姓名
        /// </summary>
        public String Name { get; set; }

        /// <summary>
        ///     工号
        /// </summary>
        public String Code { get; set; }

        /// <summary>
        ///     性别
        /// </summary>
        public Int32 Gender { get; set; }

        /// <summary>
        ///     用户ID
        /// </summary>
        public Int32 UserId { get; set; }

        /// <summary>
        ///     E-mail
        /// </summary>
        public String Email { get; set; }

        /// <summary>
        ///     邮编
        /// </summary>
        public String ZipCode { get; set; }

        /// <summary>
        ///     家庭住址
        /// </summary>
        public String HomeAddress { get; set; }

        /// <summary>
        ///     电话
        /// </summary>
        public String TelePhone { get; set; }

        /// <summary>
        ///     家庭电话
        /// </summary>
        public String HomePhone { get; set; }

        /// <summary>
        ///     工作电话
        /// </summary>
        public String WorkPhone { get; set; }

        /// <summary>
        ///     备注
        /// </summary>
        public String Remark { get; set; }

        /// <summary>
        ///     生日
        /// </summary>
        public DateTime BirthDay { get; set; }

        /// <summary>
        ///     职位
        /// </summary>
        public String Duty { get; set; }

        /// <summary>
        ///     证件号
        /// </summary>
        public String CertificateNumber { get; set; }

        /// <summary>
        ///     证件类型
        /// </summary>
        public Int32 CertificateType { get; set; }

        /// <summary>
        ///     员工类别
        /// </summary>
        public Int32 EmployeeType { get; set; }

        /// <summary>
        ///     员工级别
        /// </summary>
        public Int32 EmployeeRank { get; set; }

        /// <summary>
        ///     是否禁用
        /// </summary>
        public Boolean Forbidden { get; set; }

        /// <summary>
        ///     紧急联系人
        /// </summary>
        public String EmergencyContractWith { get; set; }

        /// <summary>
        ///     传真
        /// </summary>
        public String Fax { get; set; }

        /// <summary>
        ///     描述
        /// </summary>
        public String Description { get; set; }

        /// <summary>
        /// </summary>
        public Int32 DepartmentId { get; set; }

        #region IBaseEntity Members

        public int GetEntityId()
        {
            return EmployeeId;
        }

        #endregion
    }
}