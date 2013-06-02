using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wms.Common.Barcode;

namespace Modules.ReceiveModule.Barcode
{
    public class SNLabel : BarcodeLabel
    {
        public SNLabel()
        {
            FormatFileName = "SN.btw";
            DataFileName = "SN.txt";
            HeadData = string.Format("\"SKU_NUMBER\",\"SKU_NAME\",\"BARCODE\",\"SERIAL_NUMBER\",\"BATCH_NUMBER\",\"INBOUND_DATE\"");
            DataFormat = "\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\",\"{5}\"";
        }
    }
}
