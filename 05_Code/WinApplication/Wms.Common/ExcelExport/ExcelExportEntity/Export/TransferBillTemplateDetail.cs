using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ecWMS.Common.ExcelExport.ExcelExportEntity.Export
{
    /// <summary>
    /// 移库明细信息
    /// </summary>
    [Serializable]
    public class TransferBillTemplateDetail
    {

        /// <summary>
        /// 序号
        /// </summary>
        public Int32 Index { get; set; }

        /// <summary>
        /// 商品代码
        /// </summary>
        public String ItemCode { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        public String ItemName { get; set; }

        /// <summary>
        /// 计划移库数量
        /// </summary>
        public String PlanTransferQuantity { get; set; }

        /// <summary>
        /// 移库数量
        /// </summary>
        public String TransferQuantity { get; set; }

        /// <summary>
        /// 货物包装
        /// </summary>
        public String ItemPack { get; set; }

        /// <summary>
        /// 原库位
        /// </summary>
        public String SourceLocation { get; set; }

        /// <summary>
        /// 原容器
        /// </summary>
        public String SourceUnit { get; set; }

        /// <summary>
        /// 目标库位
        /// </summary>
        public String TargetLocation { get; set; }

        /// <summary>
        /// 目标容器
        /// </summary>
        public String TargetUnit { get; set; }

        /// <summary>
        /// 批号
        /// </summary>
        public String BatchNo { get; set; }
    }
}
