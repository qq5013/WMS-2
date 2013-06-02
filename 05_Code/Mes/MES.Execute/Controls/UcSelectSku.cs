using System;
using System.Windows.Forms;
using DevExpress.XtraBars;
using MES.Common;

namespace MES.Execute.Controls
{
    /// <summary>
    ///     选择Sku
    /// </summary>
    public partial class UcSelectSku : UserControl, IInitControl
    {
        /// <summary>
        ///     回调
        /// </summary>
        public CallBack CallBack;

        /// <summary>
        ///     选择Sku
        /// </summary>
        public UcSelectSku()
        {
            InitializeComponent();
        }

     
        /// <summary>
        ///     是否物料
        /// </summary>
        public bool IsMateriel { get; set; }

        /// <summary>
        ///     初始化
        /// </summary>
        public void Init()
        {
        }

        /// <summary>
        ///     关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCloseItemClick(object sender, ItemClickEventArgs e)
        {
            if (ParentForm != null) ParentForm.Close();
        }

        private void TeCodeKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                seQuantity.Focus();
            }
        }

        private void SeQuantityKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                simpleButton1_Click(simpleButton1, null);
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            seQuantity.EditValue = 0;
            teCode.EditValue = null;
            teCode.Focus();
        }
    }
}