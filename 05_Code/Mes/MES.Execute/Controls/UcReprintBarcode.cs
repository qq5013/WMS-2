using System.Windows.Forms;
using DevExpress.XtraBars;
using MES.Common;

namespace MES.Execute.Controls
{
    /// <summary>
    /// 条码补打
    /// </summary>
    public partial class UcReprintBarcode : UserControl
    {
        /// <summary>
        /// 条码补打
        /// </summary>
        public UcReprintBarcode()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnPrintItemClick(object sender, ItemClickEventArgs e)
        {
            string barcode = teBarcode.Text.Trim();
            // 根据不同的条码类型，重新打印条码
            switch (barcode.Length)
            {
                case 15:
                    var productTraceCode = new BarcodeLabel();
                    for (int i = 0; i < seQuantity.Value; i++)
                    {
                        productTraceCode.AppendData("\"" + barcode + "\",\"Name\"");
                    }
                    productTraceCode.Print();
                    break;
                case 16:
                    {
                        var materielCode = new BarcodeLabel();
                        for (int i = 0; i < seQuantity.Value; i++)
                        {
                            materielCode.AppendData('\"' + barcode + "\",\"" + barcode.Substring(4, 5) + "\",\"Code2\"");
                        }
                        materielCode.Print();
                    }
                    break;
                case 19:
                    {
                        var materielCode = new BarcodeLabel();
                        for (int i = 0; i < seQuantity.Value; i++)
                        {
                            materielCode.AppendData('\"' + barcode + "\",\"" + barcode.Substring(4, 5) + "\",\"Code2\"");
                        }
                        materielCode.Print();
                    }
                    break;
                case 23:
                    var productCode = new BarcodeLabel();
                    for (int i = 0; i < seQuantity.Value; i++)
                        productCode.AppendData('\"' + barcode + "\",\"\",\"\"");
                    productCode.Print();
                    break;
                default:
                    MessageBox.Show("条码格式不正确无法打印");
                    break;
            }
        }

        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCancelItemClick(object sender, ItemClickEventArgs e)
        {
            if (ParentForm != null) ParentForm.Close();
        }
    }
}