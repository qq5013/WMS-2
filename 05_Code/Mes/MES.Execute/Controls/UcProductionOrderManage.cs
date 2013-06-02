/*----------------------------------------------------------------
// Copyright (C) 2010 有限公司
// 版权所有。 
//
// 文件名：         UcProductionOrderManage.cs
// 文件功能描述：   生产工单管理
//
// 
// 创建标识：
//
// 修改标识：
// 修改描述：
//
// 修改标识：
// 修改描述：
----------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using Frame.Utils.RelaAndCondition;
using Frame.Utils.Service;
using MES.BllService;
using MES.Common;
using MES.Entity;
using MES.Enum;

namespace MES.Execute.Controls
{
    /// <summary>
    ///     生产工单管理
    /// </summary>
    public partial class UcProductionOrderManage : UserControl, IInitControl, IOrderControl
    {
        /// <summary>
        ///     Panel高度
        /// </summary>
        private int panel2Height;

        /// <summary>
        ///     生产工单管理
        /// </summary>
        public UcProductionOrderManage()
        {
            InitializeComponent();
        }

        /// <summary>
        ///     查询条件
        /// </summary>
        private Condition Condition { get; set; }

        /// <summary>
        ///     商品Service
        /// </summary>
        private IEntityService<Item> ItemService
        {
            get { return ServiceBloker.GetService<Item>(); }
        }



        /// <summary>
        ///     产品Service
        /// </summary>
        private IEntityService<Product> ProductService
        {
            get { return ServiceBloker.GetService<Product>(); }
        }

        /// <summary>
        ///     生产工单明细Service
        /// </summary>
        private IEntityService<ProductionOrderDetail> ProductionOrderDetailService
        {
            get { return ServiceBloker.GetService<ProductionOrderDetail>(); }
        }

        /// <summary>
        ///     初始化
        /// </summary>
        public void Init()
        {
            //glueType.Bind<ProductionOrderType>(ControlMode.Query);
            glueCreater.BindUser(ControlMode.Query, null);
            //glueCustomer.BindCustomer(ControlMode.Query);


            riglueType.Bind<ProductionOrderType>();
            riglueCreater.BindUser();
            //riglueCustomer.BindCustomer();
            riglueStatus.Bind<ProductionOrderStatus>();

            CommonApi.BindSku(riglueSkuCategoryName, riglueSkuName, riglueSkuCode, riglueSkuSpec, riglueSkuModel,
                              riglueSkuColor, false);
            Condition = CommonApi.GetCondition<ProductionOrder>(Controls);
            Rebind();
            if (OpenMode == OpenMode.SingleSelect)
            {
                barManager1.HideInNotQuery();
            }
            splitContainerControl1.Collapsed = true;

            // 打印产品生产跟踪码
            repositoryItemButtonEdit1.Click += (sender, e) =>
                {
                    var ucBarcodeScan = new UcPrintProduct
                        {Item = gridView2.CurrentFocuse<Item>()};
                    ucBarcodeScan.Init();
                    new Form
                        {
                            Controls = {ucBarcodeScan},
                            Size = new Size(450, 350),
                        }.Dialog();
                };
        }

        /// <summary>
        ///     打开模式
        /// </summary>
        public OpenMode OpenMode { get; set; }

        /// <summary>
        ///     状态
        /// </summary>
        public int[] Status { get; set; }

        /// <summary>
        ///     类型
        /// </summary>
        public int[] Types { get; set; }

        /// <summary>
        ///     设置订单号
        /// </summary>
        public SetOrderCode SetOrderCode { get; set; }

        private void UcProductionOrderManage_Load(object sender, EventArgs e)
        {

        }


        /// <summary>
        ///     新建
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnNewItemClick(object sender, ItemClickEventArgs e)
        {
            var ucProductionOrder = new UcProductionOrder();
            ucProductionOrder.Init();
            ucProductionOrder.ShowDialog(String.Format("新建-{0}", "生产工单"));
            Rebind();
            ResetEditable();
        }

        /// <summary>
        ///     编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnEditItemClick(object sender, ItemClickEventArgs e)
        {
        }

        /// <summary>
        ///     编辑
        /// </summary>
        private void Edit()
        {
            var current = gridView1.Current<ProductionOrder>();

            if (current != null)
            {
                var ucProductionOrder = new UcProductionOrder
                    {
                        Data = current
                    };
                ucProductionOrder.Init();
                ucProductionOrder.ShowDialog(String.Format("编辑-{0}", "生产工单"));
                Rebind();
                ResetEditable();
            }
        }


        /// <summary>
        ///     删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDeleteItemClick(object sender, ItemClickEventArgs e)
        {
            var current = gridView1.Current<ProductionOrder>();

            if (current != null)
            {
                if (MessageBox.Show("单据作废后不能取消，是否确认作废生产工单\"" + current.Code + "\"?", "提示信息", MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    current.Status = ProductionOrderStatus.Invalid;
                    ServiceBloker.GetService<ProductionOrder>().Save(current);
                    Rebind();
                }
            }
        }

        /// <summary>
        ///     查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnQueryItemClick(object sender, ItemClickEventArgs e)
        {
            Condition = CommonApi.GetCondition<ProductionOrder>(Controls);

            Rebind();
        }

        /// <summary>
        ///     重新绑定
        /// </summary>
        private void Rebind()
        {
            gridControl1.DataSource =
                ServiceBloker.GetService<ProductionOrder>().GetAll(new QueryInfo
                    {
                        Condition = Condition,
                        CompositorList =
                            new List<Compositor>
                                {
                                    new Compositor
                                        {
                                            Column =
                                                new EntityColumn(
                                                                       "CreateTime"),
                                            SortDirection =
                                                ListSortDirection.
                                                                       Descending
                                        }
                                }
                    });
        }

        /// <summary>
        ///     打印
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnPrintItemClick(object sender, ItemClickEventArgs e)
        {
            //XtraReport report = gridView1.Current<ProductionOrder>().GetReport();
            //report.ShowPrint();
        }


        /// <summary>
        ///     导出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BarButtonItem1ItemClick(object sender, ItemClickEventArgs e)
        {
            //var current = gridView1.Current<ProductionOrder>();
            //if (current != null) current.GetReport().Export("生产工单");
        }

        /// <summary>
        ///     根据选中的记录设置按钮状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GridView1FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            ResetEditable();
        }

        /// <summary>
        ///     设置按钮状态
        /// </summary>
        private void ResetEditable()
        {
            var current = gridView1.Current<ProductionOrder>();
            if (current != null && current.Status != ProductionOrderStatus.Created)
            {
                btnDelete.Enabled = false;
                btnEdit.Caption = "查看";
            }
            else
            {
                btnDelete.Enabled = true;
                btnEdit.Caption = "编辑";
            }
        }

        /// <summary>
        ///     展开主表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GridView1MasterRowExpanding(object sender, MasterRowCanExpandEventArgs e)
        {
            var current = gridView1.Current<ProductionOrder>();
            if (current != null && current.Details.Count == 0)
            {
                current.Details.AddRange(
                    ServiceBloker.GetService<ProductionOrderDetail>().FindAll(
                        d => d.ProductionOrderId == current.ProductionOrderId));

                current.Items.AddRange(
                    ServiceBloker.GetService<Item>().FindAll(
                        d => d.ProductionOrderId == current.ProductionOrderId));
            }
        }

        /// <summary>
        ///     隐藏或显示高级查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SplitContainerControl1SplitGroupPanelCollapsing(object sender,
                                                                     SplitGroupPanelCollapsingEventArgs e)
        {
            panel2Height = panel2Height > 0 ? panel2Height : splitContainerControl1.Panel2.Height;
            if (e.Collapsing)
            {
                splitContainerControl1.Height = splitContainerControl1.Size.Height - panel2Height;
            }
            else
            {
                splitContainerControl1.Height = splitContainerControl1.Size.Height + panel2Height;
            }
        }

        /// <summary>
        ///     隐藏或显示高级查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAdvanceQueryItemClick(object sender, ItemClickEventArgs e)
        {
            splitContainerControl1.Collapsed = !splitContainerControl1.Collapsed;
        }

        /// <summary>
        ///     双击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GridView1DoubleClick(object sender, EventArgs e)
        {
            if (OpenMode == OpenMode.SingleSelect)
            {
                // 选择单号
                var current = gridView1.Current<ProductionOrder>();
                if (current != null && current.Details.Count == 0)
                {
                    SetOrderCode(current.Code);
                }
                if (ParentForm != null) ParentForm.Close();
            }
            else //编辑
                Edit();
        }

        /// <summary>
        ///     打印产品追踪码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnPrintProductTraceItemClick(object sender, ItemClickEventArgs e)
        {
            var current = gridView1.Current<ProductionOrder>();

            if (current != null)
            {
                List<Item> items =
                    ItemService.FindAll(c => c.ProductionOrderId == current.ProductionOrderId);
                if (items.Count <= 0)
                {
                    string code = current.Code.Substring(4, 6) + current.Code.Substring(11);

                    List<ProductionOrderDetail> productionOrderDetails = ProductionOrderDetailService.FindAll(
                        c => c.ProductionOrderId == current.ProductionOrderId);

                    // 根据工单明细生成item
                    foreach (ProductionOrderDetail detail in productionOrderDetails)
                    {
                        Sku sku = SkuService.GetById(detail.SkuId);
                        Product product = ProductService.GetById(sku.ProductId);

                        string data = code + product.Code;
                        int currentNumber = CommonApi.GetCurrentNumber(data, detail.Quantity);

                        for (int i = 0; i < detail.Quantity; i++)
                        {
                            string itemcode = data + (currentNumber + i).ToString("000");
                            var item = new Item
                                {
                                    TraceCode = itemcode,
                                    SkuId = detail.SkuId,
                                    Status = ItemStatus.Plan,
                                    ProductionOrderId = current.ProductionOrderId
                                };
                            int itemId = ItemService.Save(item);
                            if (item.ItemId == 0)
                                item.ItemId = itemId;
                            items.Add(item);
                        }
                    }
                }

                var productCode = new ProductTraceCode();
                // 打印item的追踪号
                foreach (Item item in items)
                {
                    productCode.AppendData("\"" + item.TraceCode + "\",\"Name\"");
                }
                productCode.Print();
            }
        }

        /// <summary>
        ///     展开主表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BandedGridView1MasterRowExpanding(object sender, MasterRowCanExpandEventArgs e)
        {
        }
    }
}