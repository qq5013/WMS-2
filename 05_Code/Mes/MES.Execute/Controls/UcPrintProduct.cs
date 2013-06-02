using System;
using System.Windows.Forms;
using DevExpress.XtraBars;
using Frame.Utils.Service;
using MES.BllService;
using MES.Common;
using MES.Entity;

namespace MES.Execute.Controls
{
    /// <summary>
    /// 打印产品条码
    /// </summary>
    public partial class UcPrintProduct : UserControl
    {
        /// <summary>
        /// 当前时间
        /// </summary>
        private DateTime _now = DateTimeHelper.Now;

        public UcPrintProduct()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 产品
        /// </summary>
        private Product Product { get; set; }

        /// <summary>
        /// 产线
        /// </summary>
        private ProductLine ProductLine { get; set; }

        /// <summary>
        /// 物料检测
        /// </summary>
        private ItemInspect ItemInspect { get; set; }

        /// <summary>
        /// 商品
        /// </summary>
        public Item Item { get; set; }

        /// <summary>
        /// 初始化
        /// </summary>
        public void Init()
        {
            if (Item != null)
            {
                teTraceCode.Text = Item.TraceCode;
                barButtonItem1.Enabled = true;

                ProductLine =
                    ServiceBloker.GetService<ProductLine>().GetById(CommonApi.CurrentProductStation.ProductLineId);
                Product = ServiceBloker.GetService<Product>().GetById(
                    ServiceBloker.GetService<Sku>().GetById(Item.SkuId).ProductId);
                ItemInspect = ServiceBloker.GetService<ItemInspect>().Find(c => c.ItemId == Item.ItemId);
                teProductLine.Text = ProductLine.Name;
                teProductName.Text = Product.Name;
                if (ItemInspect != null)
                {
                    Software software = ServiceBloker.GetService<Software>().GetById(ItemInspect.SoftwareId);
                    string softwareName = software != null ? software.Name : "";
                    teSoftware.Text = softwareName;
                }
                teDate.Text = _now.ToString("yyyy-MM-dd");
            }
        }

        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnPrintClick(object sender, ItemClickEventArgs e)
        {
            if (Item != null && CommonApi.CurrentProductStation != null)
            {
                var productCode = new ProductCode();
                if (string.IsNullOrEmpty(Item.Barcode))
                {
                    string softwareCode = "00000";
                    if (ItemInspect != null)
                    {
                        Software software = ServiceBloker.GetService<Software>().GetById(ItemInspect.SoftwareId);
                        if (software != null) softwareCode = software.Code;
                    }

                    if (string.IsNullOrEmpty(softwareCode) || softwareCode.Length < 5)
                    {
                        softwareCode = "00000";
                    }
                    string data = ProductLine.Code + _now.ToString("yy") + _now.DayOfYear.ToString("000") +
                                  Product.Code +
                                  softwareCode;

                    IEntityService<ItemSequence> service = ServiceBloker.GetService<ItemSequence>();
                    ItemSequence itemSequence = service.Find(c => c.Code == Product.Code) ??
                                                new ItemSequence {Code = Product.Code, Step = 1};
                    int currentNumber = itemSequence.CurrentNumber;
                    itemSequence.CurrentNumber = currentNumber + itemSequence.Step;
                    service.Save(itemSequence);

                    Item.Barcode = (currentNumber + itemSequence.Step).ToString("0000000") + data;
                    Item.Save();
                }
                productCode.AppendData('\"' + Item.Barcode + "\",\"\",\"\"");
                productCode.Print();
            }
            teTraceCode.SelectAll();
            teTraceCode.Focus();
        }

        /// <summary>
        /// 输入跟踪码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TeTraceCodePropertiesKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                Item = ServiceBloker.GetService<Item>().Find(c => c.TraceCode == teTraceCode.Text.Trim());
                if (Item != null)
                {
                    barButtonItem1.Enabled = true;

                    ProductLine =
                        ServiceBloker.GetService<ProductLine>().GetById(CommonApi.CurrentProductStation.ProductLineId);
                    Product = ServiceBloker.GetService<Product>().GetById(
                        ServiceBloker.GetService<Sku>().GetById(Item.SkuId).ProductId);
                    ItemInspect = ServiceBloker.GetService<ItemInspect>().Find(c => c.ItemId == Item.ItemId);
                    teProductLine.Text = ProductLine.Name;
                    teProductName.Text = Product.Name;
                    if (ItemInspect != null)
                    {
                        Software software = ServiceBloker.GetService<Software>().GetById(ItemInspect.SoftwareId);
                        string softwareName = software != null ? software.Name : "";
                        teSoftware.Text = softwareName;
                    }
                    teDate.Text = _now.ToString("yyyy-MM-dd");
                }
                else
                {
                    barButtonItem1.Enabled = false;
                }
            }
        }

        /// <summary>
        /// Julio：Remove
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void teTraceCode_EditValueChanged(object sender, EventArgs e)
        {
        }
    }
}