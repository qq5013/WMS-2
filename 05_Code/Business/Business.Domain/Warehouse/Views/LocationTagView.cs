using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Domain.Warehouse.Views
{
    public class LocationTagView : LocationTag
    {
        public string LocationCode { get; set; }

        public string LocationName { get; set; }

        public string TagNumber { get; set; }

        public string WarehouseName { get; set; }
    }
}
