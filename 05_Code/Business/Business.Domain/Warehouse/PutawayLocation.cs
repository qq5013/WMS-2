using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Domain.Warehouse
{
    public class PutawayLocation //: Location
    {
        /// <summary>
        /// 库位编号
        /// </summary>
        public int LocationId { get; set; }

        /// <summary>
        /// 库位代码
        /// </summary>
        public string LocationCode { get; set; }

        /// <summary>
        /// 库位名称
        /// </summary>
        public string LocationName { get; set; }

        /// <summary>
        /// 库位条码
        /// </summary>
        public string Barcode { get; set; }

        /// <summary>
        /// 路线序号
        /// </summary>
        public int Route { get; set; }

        /// <summary>
        /// 库位上上架货物库存数量
        /// </summary>
        public int SkuStockQty { get; set; }

        /// <summary>
        /// 库位上其它货物库存数量
        /// </summary>
        public int OtherStockQty { get; set; }
    }
}
