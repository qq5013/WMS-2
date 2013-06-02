using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Domain.Warehouse.Views
{
    public class SkuTagView : SkuTag
    {
        public string SkuNumber { get; set; }

        public string SkuName { get; set; }

        public string TagNumber { get; set; }

        public string WarehouseName { get; set; }
    }
}
