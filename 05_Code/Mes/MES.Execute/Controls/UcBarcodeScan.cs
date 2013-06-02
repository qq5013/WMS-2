using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using MES.Common;

namespace MES.Execute.Controls
{
    /// <summary>
    ///     Scan Barcode
    /// </summary>
    public partial class UcBarcodeScan : UserControl
    {
        /// <summary>
        ///     回调
        /// </summary>
        public CallBack CallBack;

        public UcBarcodeScan()
        {
            InitializeComponent();
        }

        /// <summary>
        ///     扫描条码动作完成后
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BeBarcodeKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                Scan();
            }
        }

        /// <summary>
        ///     扫描条码动作完成后
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BeBarcodeButtonClick(object sender, ButtonPressedEventArgs e)
        {
            try
            {
                // 扫描
                Scan();
            }
            catch (Exception ex)
            {
                // 记录日志
                CommonApi.Logger.Write(ex);
            }
            // Julio：？？
            Scan();
        }

        /// <summary>
        ///     扫描解析
        /// </summary>
        private void Scan()
        {
            string barcode = beBarcode.Text;
            // 选中全部以便下次扫描
            beBarcode.SelectAll();

            string lotNo;
            SkuInfo skuInfo = CommonApi.Prase(barcode, out lotNo, Error);

            // 如果找到Sku信息
            if (skuInfo != null)
            {
                lblMessage.Text = string.Empty;

                // 如果回调函数存在，则反馈错误
                if (CallBack != null) CallBack(skuInfo, barcode, lotNo, CommonApi.DefaultMeasureId, 1, Error);
            }
        }

        /// <summary>
        ///     错误显示
        /// </summary>
        /// <param name="msg"></param>
        private void Error(string msg)
        {
            lblMessage.ForeColor = Color.Red;
            lblMessage.Text = msg;
        }
    }
}