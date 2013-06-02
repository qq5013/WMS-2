using System.Collections.Generic;

namespace Business.Domain.Wms
{
    public class CompanyType : DomainObject
    {
        #region property

        /// <summary> 
        /// 自动编号
        /// </summary> 
        public int Id { get; set; }

        /// <summary> 
        /// 公司编号
        /// </summary> 
        public int CompanyId { get; set; }

        /// <summary> 
        /// 公司类型编号
        /// </summary> 
        public int CompanyTypeId { get; set; }

        #endregion

        #region additional property

        public IList<Company> Companys { get; set; }

        #endregion
    }
}