using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Wms.Mobile.Common;
using Business.Domain.Mobile.Inventory;

namespace Wms.Mobile.UI.StockQuery
{
    public partial class StockQueryForm : TemplateForm
    {
        public StockQueryForm()
        {
            InitializeComponent();
        }


        private void StockQueryForm_Load(object sender, EventArgs e)
        {
            SetTitle("库存-库存查询");
        }

        private void txtBarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                QueryStockByBarcode(txtBarcode.Text.Trim());

        }

        private void QueryStockByBarcode(string barcode)
        {
            try
            {
                string uri = string.Format("Stock/Query/{0}/{1}", GlobalState.CurrentWarehouse.WarehouseCode, txtBarcode.Text.Trim());
                var stocks = GlobalState.MyRestService.GetForObject<List<StockView>>(uri);

                if (stocks.Count > 0)
                {
                    gridStock.DataSource = null;
                    gridStock.DataSource = stocks;

                    SetGridStyle();
                    lblMessage.Text = string.Empty;
                }
                else
                    lblMessage.Text = "无相应库存信息。";

            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                lblMessage.Text = ex.Message;
            }
        }

        private void SetGridStyle()
        {
            DataGridTableStyle style = new DataGridTableStyle();
            gridStock.TableStyles.Clear();
            gridStock.TableStyles.Add(style);

            style.MappingName = gridStock.DataSource.GetType().Name;
            for (int i = 0; i <= style.GridColumnStyles.Count - 1; i++)
            {
                style.GridColumnStyles[i].Width = 0;
            }

            style.GridColumnStyles["SkuNumber"].HeaderText = "货物代码";
            style.GridColumnStyles["SkuNumber"].Width = 80;
            style.GridColumnStyles["SkuName"].HeaderText = "货物名称";
            style.GridColumnStyles["SkuName"].Width = 80;
            style.GridColumnStyles["Qty"].HeaderText = "数量";
            style.GridColumnStyles["Qty"].Width = 40;
            style.GridColumnStyles["PackName"].HeaderText = "包装";
            style.GridColumnStyles["PackName"].Width = 40;
            style.GridColumnStyles["LocationCode"].HeaderText = "库位";
            style.GridColumnStyles["LocationCode"].Width = 40;
            style.GridColumnStyles["ContainerCode"].HeaderText = "容器";
            style.GridColumnStyles["ContainerCode"].Width = 40;
            style.GridColumnStyles["BatchNumber"].HeaderText = "批次";
            style.GridColumnStyles["BatchNumber"].Width = 60;
            style.GridColumnStyles["BillNumber"].HeaderText = "入库单号";
            style.GridColumnStyles["BillNumber"].Width = 60;
            style.GridColumnStyles["InboundDate"].HeaderText = "入库日期";
            style.GridColumnStyles["InboundDate"].Width = 80;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.MainForm.Show();
            this.Close();
        }
    }
}