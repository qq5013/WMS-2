namespace Mes.Product.Modules.MaterialRequisitionModel
{
    public class SkuLabel : BarcodeLabel
    {
        public SkuLabel()
        {
            FormatFileName = "SkuLabel.btw";
            DataFileName = "SkuLabel.txt";
            HeadData = string.Format("\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\",\"{5}\",\"{6}\",\"{7}\""
                                     , "GOODSCODE", "BARCODE", "DESCRIPTION", "TRACECODE", "BATCHNUMBER",
                                     "PRODUCTIONDATE", "EFFECTIVEDATE", "INBOUNDDATE");
            //"GOODSCODE","BARCODE","DESCRIPTION","TRACECODE","BATCHNUMBER","PRODUCTIONDATE","EFFECTIVEDATE","INBOUNDDATE"
            DataFormat = "\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\",\"{5}\",\"{6}\",\"{7}\"";
        }
    }
}