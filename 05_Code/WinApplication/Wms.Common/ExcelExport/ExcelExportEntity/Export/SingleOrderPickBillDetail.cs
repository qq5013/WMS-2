using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CabApplication.Common.ExcelExport.ExcelExportEntity.Export
{
    /// <summary>
    /// 单定单拣货单明细
    /// </summary>
    [Serializable]
    public class SingleOrderPickBillDetail
    {

        /// <summary>
        /// 库位
        /// </summary>
        public String LocationIn { get; set; }

        /// <summary>
        /// Item
        /// </summary>
        public String Item { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public Int32 ITemCount { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        public String ItemName { get; set; }

        /// <summary>
        /// 产品描述
        /// </summary>
        public String ItemDescription { get; set; }

        /// <summary>
        /// 型号
        /// </summary>
        public String Model { get; set; }

        /// <summary>
        /// 价格
        /// </summary>
        public decimal Price { get; set; }

    }
}
