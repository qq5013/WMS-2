using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wms.Common.Barcode;

namespace Modules.ReceiveModule.Barcode
{
    public class SKULabel : BarcodeLabel
    {
        public SKULabel()
        {
            FormatFileName = "SKU.btw";
            DataFileName = "SKU.txt";
            HeadData = string.Format("\"SKU_NUMBER\",\"SKU_NAME\",\"BARCODE\",\"BATCH_NUMBER\",\"INBOUND_DATE\"");
            DataFormat = "\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\"";
        }
    }
}
