using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MES.Web.Data
{
    public class OutboundProductData
    {
        public List<OutboundProduct> Select()
        {
            return new List<OutboundProduct>() { new OutboundProduct() { 产品 = "风机驱动器", 数量 = "5", 发货时间 = "2010-09-10", 发货单 = "123441" }, new OutboundProduct() { 产品 = "风机驱动器", 数量 = "3", 发货时间 = "2010-09-15", 发货单 = "123442" } };
        }
    }

    public class OutboundProduct
    {
        public string 产品 { get; set; }
        public string 数量 { get; set; }
        public string 发货时间 { get; set; }
        public string 发货单 { get; set; }
    }
}
