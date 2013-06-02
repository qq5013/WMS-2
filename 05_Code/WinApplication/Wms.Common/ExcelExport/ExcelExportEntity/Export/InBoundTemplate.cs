using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ecWMS.Common.ExcelExport.ExcelExportEntity.Export
{
    [Serializable]
    public class InBoundTemplate
    {
        /// <summary>
        /// 计划号
        /// </summary>
        public String InBoundBillCode { get; set; }
        
        /// <summary>
        /// 入库日期
        /// </summary>
        public String InBoundDate { get; set; }

        /// <summary>
        /// 入库类型
        /// </summary>
        public String InBoundType { get; set; }

        /// <summary>
        /// 供应商
        /// </summary>
        public String Provider { get; set; }

        /// <summary>
        /// 采购员
        /// </summary>
        public String Buyer { get; set; }

        /// <summary>
        /// 联系人
        /// </summary>
        public String LinkMan { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>
        public String LinkPhone { get; set; }

        /// <summary>
        /// 入库备注
        /// </summary>
        public String InBoundMemo { get; set; }

        public IList<InBoundTemplateDetail> InBoundTemplateDetailList = new List<InBoundTemplateDetail>();
    }
}
