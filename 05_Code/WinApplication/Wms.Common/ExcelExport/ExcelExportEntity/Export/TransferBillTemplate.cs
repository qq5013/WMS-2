using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ecWMS.Common.ExcelExport.ExcelExportEntity.Export
{
    /// <summary>
    /// 移库单导出
    /// </summary>
    [Serializable]
    public class TransferBillTemplate
    {
        /// <summary>
        /// 移库单号
        /// </summary>
        public String TransferBillCode { get; set; }

        /// <summary>
        /// 移库库位
        /// </summary>
        public String TransferWarehouse { get; set; }

        /// <summary>
        /// 移库单类型
        /// </summary>
        public String TransferType { get; set; }

        /// <summary>
        /// 移库单操作人员
        /// </summary>
        public String TransferOperator { get; set; }

        /// <summary>
        /// 计划移库日期
        /// </summary>
        public String TransferPlanDate { get; set; }

        /// <summary>
        /// 移库日期
        /// </summary>
        public String TransferDate { get; set; }

        /// <summary>
        /// 容器移库
        /// </summary>
        public String TransferUnit { get; set; }

        /// <summary>
        /// 移库描述
        /// </summary>
        public String TransferMemo { get; set; }

        /// <summary>
        /// 明细信息
        /// </summary>
        public IList<TransferBillTemplateDetail> TransferBillTemplates { get; set; }
    }
}
