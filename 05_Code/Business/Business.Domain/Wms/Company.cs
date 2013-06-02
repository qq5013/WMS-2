using System.Collections.Generic;

namespace Business.Domain.Wms
{
    public class Company : DomainObject
    {
        #region property

        /// <summary>
        /// 公司编号
        /// </summary>
        public int CompanyId { get; set; }

        /// <summary>
        /// 公司代码
        /// </summary>
        public string CompanyCode { get; set; }

        /// <summary>
        /// 上级公司编号
        /// </summary>
        public int ParentId { get; set; }

        /// <summary>
        /// ERP代码
        /// </summary>
        public string ErpCode { get; set; }

        /// <summary>
        /// 公司名称
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// 公司短名
        /// </summary>
        public string ShortName { get; set; }

        /// <summary>
        /// 公司地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 邮政编码
        /// </summary>
        public string PostalCode { get; set; }

        /// <summary>
        /// 联系人
        /// </summary>
        public string Contactor { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 传真
        /// </summary>
        public string FaxNumber { get; set; }

        /// <summary>
        /// 区县编号
        /// </summary>
        public int CountyId { get; set; }

        /// <summary>
        /// 组织代码
        /// </summary>
        public string OrganizationCode { get; set; }

        /// <summary>
        /// 法人代表
        /// </summary>
        public string Representative { get; set; }

        /// <summary>
        /// 主页
        /// </summary>
        public string Homepage { get; set; }

        /// <summary>
        /// 缴税注册号
        /// </summary>
        public string TaxRegisterationCode { get; set; }

        /// <summary>
        /// 税号
        /// </summary>
        public string TaxNumber { get; set; }

        /// <summary>
        /// 开户银行
        /// </summary>
        public string Bank { get; set; }

        /// <summary>
        /// 银行帐号
        /// </summary>
        public string AccountNumber { get; set; }

        /// <summary>
        /// 货币类型
        /// </summary>
        public int CurrencyType { get; set; }

        /// <summary>
        /// 发票类型
        /// </summary>
        public int InvoiceType { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 创建用户
        /// </summary>
        public int CreateUser { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public string CreateTime { get; set; }

        /// <summary>
        /// 编辑用户
        /// </summary>
        public int EditUser { get; set; }

        /// <summary>
        /// 编辑时间
        /// </summary>
        public string EditTime { get; set; }

        /// <summary>
        /// 是否激活
        /// </summary>
        public bool IsActive { get; set; }

        #endregion property

        #region additional property

        //public IList<CompanyType> CompanyTypes { get; set; }

        #endregion additional property

        public void Disable()
        {
            IsActive = false;
        }

        public void Enable()
        {
            IsActive = true;
        }
    }
}