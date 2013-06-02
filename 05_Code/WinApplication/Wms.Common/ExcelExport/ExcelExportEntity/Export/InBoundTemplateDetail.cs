using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ecWMS.Common.ExcelExport.ExcelExportEntity.Export
{
    [Serializable]
    public class InBoundTemplateDetail
    {
        /// <summary>
        /// 序号
        /// </summary>
        public String Index { get; set; }

        /// <summary>
        /// 商品代码
        /// </summary>
        public String ItemCode { get; set; }

        /// <summary>
        /// 商品描述
        /// </summary>
        public String ItemName { get; set; }

        /// <summary>
        /// 批次管理
        /// </summary>
        public String Management { get; set; }

        /// <summary>
        /// UPC
        /// </summary>
        public String UPC { get; set; }

        /// <summary>
        /// 计划数量
        /// </summary>
        public String PlanQutity { get; set; }

        /// <summary>
        /// 实到数量
        /// </summary>
        public String FactQutity { get; set; }

        /// <summary>
        /// 称重
        /// </summary>
        public String Heavey { get; set; }
    }
}
