using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ecWMS.Common.ExcelExport.ExcelExportEntity.Export
{
    [Serializable]
    public class PickBillBoChiDetail
    {
        /// <summary>
        /// 序号
        /// </summary>
        public Int32 Index { get; set; }

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
        /// 型号产品描述
        /// </summary>
        public String ItemDescription { get; set; }

        /// <summary>
        /// 是否批次发货
        /// </summary>
        public String IsGo { get; set; }

        /// <summary>
        /// 货物类型
        /// </summary>
        public String ITemType { get; set; }
    }
}
