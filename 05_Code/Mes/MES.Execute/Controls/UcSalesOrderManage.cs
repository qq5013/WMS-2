
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using Frame.Utils.RelaAndCondition;
using Frame.Utils.Service;
using MES.BllService;
using MES.Entity;
using MES.Execute.Common;

namespace MES.Execute.Controls
{
    /// <summary>
    /// 销售订单管理
    /// </summary>
    public partial class UcSalesOrderManage : UserControl, IInitControl, IOrderControl
    {
        /// <summary>
        /// 查询条件
        /// </summary>
        private Condition _condition;

        /// <summary>
        /// Panel高度
        /// </summary>
        private int _panel2Height;

        /// <summary>
        /// 销售订单管理
        /// </summary>
        public UcSalesOrderManage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 条件
        /// </summary>
        private Condition Condition
        {
            get
            {
                return btnHidden.Checked
                           ? _condition & (new EntityColumn("Status") != SalesOrderStatus.Invalid)
                           : _condition;
            }
            set { _condition = value; }
        }

        /// <summary>
        /// 服务
        /// </summary>
        private IEntityService<SalesOrder> Service
        {
            get { return ServiceHelper.GetService<SalesOrder>(); }
        }

        /// <summary>
        /// 明细服务
        /// </summary>
        public IEntityService<SalesOrderDetail> DetailService
        {
            get { return ServiceHelper.GetService<SalesOrderDetail>(); }
        }

        #region IInitControl Members

        /// <summary>
        /// 初始化
        /// </summary>
        public void Init()
        {
            SuspendLayout();
            // Query Filed
            glueCustomer.BindCustomer(ControlMode.Query);
            //业务员
            glueOperator.BindUser(ControlMode.Query, new List<string> {"sales"});

            gluePayment.BindPayment(ControlMode.Query);
            glueShipVia.BindShipVia(ControlMode.Query);
            glueCreater.BindUser(ControlMode.Query, null);
            glueStatus.Bind<SalesOrderStatus>(ControlMode.Query);
            //制单日期
            deBegainCreateTime.EditValue = DateTimeHelper.Now;
            deEndCreateTime.EditValue = DateTimeHelper.Now;

            // Master
            riglueCustomer.BindCustomer();
            riglueOperator.BindUser();
            rigluePayment.BindPayment();
            riglueShipVia.BindShipVia();
            riglueStatus.Bind<SalesOrderStatus>();
            riglueCreater.BindUser();

            // Detail
            riglueMeasure.BindMeasure();
            CommonApi.BindSku(riglueSkuCategoryName, riglueSkuName, riglueSkuCode, riglueSkuSpec, riglueSkuModel,
                              riglueSkuColor, false);
            Condition = CommonApi.GetCondition<SalesOrder>(Controls);
            Rebind();

            splitContainerControl1.Collapsed = true;
            if (OpenMode == OpenMode.SingleSelect)
            {
                barManager1.HideInNotQuery();
            }
            ResetEditable();
            ResumeLayout();
        }

        #endregion

        #region IOrderControl Members

        /// <summary>
        /// 打开模式
        /// </summary>
        public OpenMode OpenMode { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public int[] Status { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        public int[] Types { get; set; }

        /// <summary>
        /// 销售订单号
        /// </summary>
        public SetOrderCode SetOrderCode { get; set; }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UcSalesOrderManage_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// 新建
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnNewItemClick(object sender, ItemClickEventArgs e)
        {
            var ucSalesOrder = new UcSalesOrder();
            ucSalesOrder.Init();
            ucSalesOrder.ShowDialog(String.Format("新建-{0}", "销售订单"));
            Rebind();
            ResetEditable();
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnEditItemClick(object sender, ItemClickEventArgs e)
        {
            Edit();
        }

        /// <summary>
        /// 编辑
        /// </summary>
        private void Edit()
        {
            var current = gridView1.Current<SalesOrder>();

            if (current != null)
            {
                var ucSalesOrder = new UcSalesOrder
                                       {
                                           Data = current
                                       };
                ucSalesOrder.Init();
                ucSalesOrder.ShowDialog(String.Format("编辑-{0}", "销售订单"));
                Rebind();
                ResetEditable();
            }
        }


        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDeleteItemClick(object sender, ItemClickEventArgs e)
        {
            var current = gridView1.Current<SalesOrder>();

            if (current != null)
            {
                // 删除前让用户确认
                if (MessageBox.Show("单据作废后不能取消，是否确认作废销售订单\"" + current.Code + "\"?", "提示信息", MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    current.Status = SalesOrderStatus.Invalid; //状态设为禁用
                    ServiceHelper.GetService<SalesOrder>().Save(current);
                    Rebind();
                    ResetEditable();
                }
            }
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnQueryItemClick(object sender, ItemClickEventArgs e)
        {
            Condition = CommonApi.GetCondition<SalesOrder>(Controls);
            Rebind();
        }

        /// <summary>
        /// 重新绑定
        /// </summary>
        private void Rebind()
        {
            List<SalesOrder> salesOrders = Service.GetAll(new QueryInfo
                                                              {
                                                                  Condition = Condition,
                                                                  CompositorList =
                                                                      new List<Compositor>
                                                                          {
                                                                              new Compositor
                                                                                  {
                                                                                      Column =
                                                                                          new EntityColumn("CreateTime"),
                                                                                      SortDirection =
                                                                                          ListSortDirection.Descending
                                                                                  }
                                                                          }
                                                              });
            gridControl1.DataSource = salesOrders;
        }

        /// <summary>
        /// 打印报表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnPrintItemClick(object sender, ItemClickEventArgs e)
        {
            var current = gridView1.Current<SalesOrder>();

            if (current != null)
            {
                current.GetReport().ShowPrint();
            }
        }


        /// <summary>
        /// 导出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnExportItemClick(object sender, ItemClickEventArgs e)
        {
            var current = gridView1.Current<SalesOrder>();
            if (current != null)
            {
                current.GetReport().Export("销售订单" + current.Code);
            }
        }

        /// <summary>
        /// 隐藏和显示作废单据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnHiddenCheckedChanged(object sender, ItemClickEventArgs e)
        {
            //2010/10/20 kenny add
            if (btnHidden.Caption == "隐藏作废单据")
            {
                btnHidden.Caption = "显示作废单据";
            }
            else
            {
                btnHidden.Caption = "隐藏作废单据";
            }

            Rebind();
        }

        /// <summary>
        /// 根据选中记录重置编辑状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GridView1FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            ResetEditable();
        }

        /// <summary>
        /// 重置编辑状态
        /// </summary>
        private void ResetEditable()
        {
            var current = gridView1.Current<SalesOrder>();
            if (current != null && current.Status != SalesOrderStatus.Created)
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
        /// 主表展开，加载子表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GridView1MasterRowExpanding(object sender, MasterRowCanExpandEventArgs e)
        {
            var current = gridView1.Current<SalesOrder>();
            if (current != null && current.Details.Count == 0)
            {
                List<SalesOrderDetail> details =
                    DetailService.FindAll(d =>
                                          d.SalesOrderId == current.SalesOrderId, null);

                current.Details.AddRange(details);
            }
        }

        /// <summary>
        /// 双击记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            if (OpenMode == OpenMode.SingleSelect)
            {
                var current = gridView1.Current<SalesOrder>();
                if (current != null && current.Details.Count == 0)
                {
                    SetOrderCode(current.Code);
                }
                if (ParentForm != null) ParentForm.Close();
            }
            else
            {
                // 编辑
                Edit();
            }
        }

        /// <summary>
        /// 隐藏显示高级查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void splitContainerControl1_SplitGroupPanelCollapsing(object sender,
                                                                      SplitGroupPanelCollapsingEventArgs e)
        {
            _panel2Height = _panel2Height > 0 ? _panel2Height : splitContainerControl1.Panel2.Height;
            if (e.Collapsing)
            {
                splitContainerControl1.Height = splitContainerControl1.Size.Height - _panel2Height;
            }
            else
            {
                splitContainerControl1.Height = splitContainerControl1.Size.Height + _panel2Height;
            }
        }

        /// <summary>
        /// 高级查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdvanceQuery_ItemClick(object sender, ItemClickEventArgs e)
        {
            splitContainerControl1.Collapsed = !splitContainerControl1.Collapsed;
        }
    }
}