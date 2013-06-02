using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraBars;
using Frame.Utils.Service;
using MES.BllService;
using MES.Common;
using MES.Entity;
using MES.Enum;

namespace MES.Execute.Controls
{
    /// <summary>
    ///     Print Barcode
    /// </summary>
    public partial class UcPrintBarcode : UserControl, IInitControl
    {
        public UcPrintBarcode()
        {
            InitializeComponent();
        }

        /// <summary>
        ///     供应商
        /// </summary>
        public int VendorId { get; set; }

        /// <summary>
        ///     Sku Id
        /// </summary>
        public List<int> SkuIds { get; set; }

        #region IInitControl Members

        /// <summary>
        ///     初始化
        /// </summary>
        public void Init()
        {
            //glueVendor.BindVendor(ControlMode.Edit);
            //if (VendorId != 0)
            //{
            //    glueVendor.EditValue = VendorId;
            //    glueVendor.Properties.ReadOnly = true;
            //}

            //glueSku.BindSku(ControlMode.Edit, true, new[] {TraceType.Sku, TraceType.Single}, SkuIds);

            seQuantity.EditValue = 1;
        }

        #endregion

        /// <summary>
        ///     退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnQuitItemClick(object sender, ItemClickEventArgs e)
        {
            if (ParentForm != null) ParentForm.Close();
        }

        /// <summary>
        ///     打印
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnPrintItemClick(object sender, ItemClickEventArgs e)
        {
            DateTime now = DateTime.Now;
            var skuInfo = (SkuInfo) glueSku.GetSelectedDataRow();
            if (skuInfo == null)
            {
                MessageBox.Show("请先选择物料");
                return;
            }
            var vendor = (Vendor) glueVendor.GetSelectedDataRow();
            if (vendor == null)
            {
                MessageBox.Show("请先选择供应商");
                return;
            }

            var materielCode = new MaterielCode();

            if (skuInfo.TraceType == TraceType.Single)
            {
                string data = vendor.Code + skuInfo.Code + now.ToString("yy") + now.DayOfYear.ToString("000") +
                              skuInfo.CategoryCode;

                IEntityService<ItemSequence> service = ServiceBloker.GetService<ItemSequence>();
                ItemSequence itemSequence = service.Find(c => c.Code == data) ??
                                            new ItemSequence {Code = data, Step = 1};
                int currentNumber = itemSequence.CurrentNumber;
                itemSequence.CurrentNumber = currentNumber + itemSequence.Step*Convert.ToInt32(seQuantity.Value);
                service.Save(itemSequence);
                for (int i = 0; i < seQuantity.Value; i++)
                {
                    materielCode.AppendData('\"' + data + (currentNumber + (i + 1)*itemSequence.Step).ToString("000") +
                                            "\",\"" + skuInfo.Code + "\",\"Code2\"");
                }
            }
            else
            {
                string data = vendor.Code + skuInfo.Code + now.ToString("yy") +
                              skuInfo.CategoryCode + now.DayOfYear.ToString("000");
                for (int i = 0; i < seQuantity.Value; i++)
                {
                    materielCode.AppendData('\"' + data + "\",\"" + skuInfo.Code + "\",\"Code2\"");
                }
            }

            materielCode.Print();
        }

        /// <summary>
        ///     选中的物料改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GlueSkuEditValueChanged(object sender, EventArgs e)
        {
            var skuInfo = (SkuInfo) glueSku.GetSelectedDataRow();
            if (skuInfo == null)
            {
                meInfo.Text = string.Empty;
            }
            else
            {
                meInfo.Text = string.Format("分类({0}) 名称({1}) 代码({2}) 规格({3}) 型号({4}) 颜色({5})", skuInfo.CategoryName,
                                            skuInfo.Name, skuInfo.Code, skuInfo.Spec, skuInfo.Model, skuInfo.Color);
            }
        }
    }
}