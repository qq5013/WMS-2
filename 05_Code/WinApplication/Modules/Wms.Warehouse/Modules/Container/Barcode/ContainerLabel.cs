using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wms.Common.Barcode;

namespace Modules.ContainerModule.Barcode
{
    public class ContainerLabel : BarcodeLabel
    {
        public ContainerLabel()
        {
            FormatFileName = "Container.btw";
            DataFileName = "Container.txt";
            HeadData = string.Format("\"CONTAINER_CODE\",\"CONTAINER_NAME\",\"BARCODE\"");
            DataFormat = "\"{0}\",\"{1}\",\"{2}\"";
        }
    }
}
