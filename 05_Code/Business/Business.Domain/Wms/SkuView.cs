using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Domain.Wms
{
    public class SkuView : Sku
    {
        /// <summary>
        /// 客户名称
        /// </summary>
        public string ClientName { get; set; }

        /// <summary>
        /// 商家名称
        /// </summary>
        public string MerchantName { get; set; }

        /// <summary>
        /// 制造商名称
        /// </summary>
        public string ManufacturerName { get; set; }

        /// <summary>
        /// 管理分类名称
        /// </summary>
        public string CategoryName { get; set; }
    }
}
