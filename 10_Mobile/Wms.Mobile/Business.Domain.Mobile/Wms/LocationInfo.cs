using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Domain.Mobile.Wms
{
    public class LocationInfo
    {
        public int LocationId { get; set; }

        public string LocationCode { get; set; }

        public string LocationName { get; set; }

        public string Barcode { get; set; }
    }
}
