using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Domain.Inventory.Views
{
    public class CountBillDetailView : CountBillDetail
    {
        public string LocationCode { get; set; }
        public string LocationName { get; set; }
        public string ContainerCode { get; set; }
        public string ContainerName { get; set; }

        /// <summary>
        /// 货物代码
        /// </summary>
        public string SkuNumber { get; set; }

        /// <summary>
        /// 货物名称
        /// </summary>
        public string SkuName { get; set; }

        /// <summary>
        /// 包装名称
        /// </summary>
        public string PackName { get; set; }
    }
}
