using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wms.Common.Barcode;

namespace Modules.LocationModule.Barcode
{
    public class LocationLabel : BarcodeLabel
    {
        public LocationLabel()
        {
            FormatFileName = "Location.btw";
            DataFileName = "Location.txt";
            HeadData = string.Format("\"LOCATION_CODE\",\"LOCATION_NAME\",\"BARCODE\"");
            DataFormat = "\"{0}\",\"{1}\",\"{2}\"";
        }
    }
}
