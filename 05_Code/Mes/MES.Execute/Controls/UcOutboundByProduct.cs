

using System;
using System.Windows.Forms;
using MES.Entity;
using MES.Execute.Common;

namespace MES.Execute.Controls
{
    /// <summary>
    /// 通过产品出库
    /// </summary>
    public partial class UcOutboundByProduct : UserControl, IInitControl
    {
        public UcOutboundByProduct()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 选中产品时回调
        /// </summary>
        public SetProduct SetProduct;

        /// <summary>
        /// 初始化
        /// </summary>
        public void Init()
        {
            // 只处理单品追踪和Sku追踪的
            glueSku.BindSku(ControlMode.Edit, false, new[] { TraceType.Sku, TraceType.Single }, null);
            // 默认数量1
            seQuantity.EditValue = 1;
        }
        /// <summary>
        /// 完成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDoneItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var skuInfo = ((SkuInfo)glueSku.GetSelectedDataRow());
            if (skuInfo != null)
            {
                SetProduct(skuInfo.ProductId, Convert.ToInt32(seQuantity.Value));if (ParentForm != null) ParentForm.Close();
            }
            else
            {
                MessageBox.Show("请先选择产品");
            }
            
        }
        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCancelItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ParentForm != null) ParentForm.Close();
        }
    }
}
