using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Domain.Warehouse.Views
{
    public class LocationView : Location
    {
        public string AreaCode { get; set; }

        public string AreaName { get; set; }

        public int AreaType { get; set; }
    }
}
