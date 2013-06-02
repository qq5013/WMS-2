using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Domain.Inventory.Views
{
    public class OutboundPlanDetailView : OutboundPlanDetail
    {
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

        /// <summary>
        /// 包装体积
        /// </summary>
        public decimal PackVolume { get; set; }

        /// <summary>
        /// 包装重量
        /// </summary>
        public decimal PackWeight { get; set; }
    }
}
