using IDAutomation.NetAssembly;

namespace ecWMS.Common.Barcode
{
    public class BarcodeFormatFactory : IBarcodeFormatFactory
    {
        public string Barcode128(string text)
        {
            var encoder = new FontEncoder();
            return encoder.Code128b(text, 0);
        }
    }
}
