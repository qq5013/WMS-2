using System;
using Frame.Utils.Contract;
using MES.Enum;

namespace MES.Entity
{
    /// <summary>
    ///     供应商
    /// </summary>
    public class Customer : IBaseEntity
    {
        /// <summary>
        /// </summary>
        public Int32 CustomerId { get; set; }

        /// <summary>
        ///     名称
        /// </summary>
        public String Name { get; set; }

        /// <summary>
        ///     代码
        /// </summary>
        public String Code { get; set; }

        /// <summary>
        ///     电话
        /// </summary>
        public String Phone { get; set; }

        /// <summary>
        ///     传真
        /// </summary>
        public String Fax { get; set; }

        /// <summary>
        ///     地址
        /// </summary>
        public String Address { get; set; }

        /// <summary>
        ///     邮编
        /// </summary>
        public String ZipCode { get; set; }

        /// <summary>
        ///     E-Mail
        /// </summary>
        public String Email { get; set; }

        /// <summary>
        ///     联系人
        /// </summary>
        public String Contract { get; set; }

        /// <summary>
        ///     法人
        /// </summary>
        public String LegalPerson { get; set; }

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

        /// <summary>
        ///     公司类型
        /// </summary>
        public CompanyType CompanyType { get; set; }

        /// <summary>
        ///     网站
        /// </summary>
        public String Site { get; set; }

        /// <summary>
        ///     开户银行
        /// </summary>
        public Int32 BankId { get; set; }

        /// <summary>
        ///     税号
        /// </summary>
        public String DutyParagraph { get; set; }

        /// <summary>
        ///     银行帐号
        /// </summary>
        public String AccountNumber { get; set; }

        /// <summary>
        ///     信用等级
        /// </summary>
        public Int32 CreditRank { get; set; }

        /// <summary>
        ///     描述
        /// </summary>
        public String Description { get; set; }

        #region IBaseEntity Members

        public int GetEntityId()
        {
            return CustomerId;
        }

        #endregion
    }
}