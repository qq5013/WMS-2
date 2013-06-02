using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraReports.UI;
using Frame.Utils.RelaAndCondition;
using Frame.Utils.Service;
using MES.BllService;
using MES.Entity;
using MES.Execute.Common;

namespace MES.Execute.Controls
{
    /// <summary>
    /// 入库单管理
    /// </summary>
    public partial class UcInboundManage : UserControl, IInitControl, IOrderControl
    {
        /// <summary>
        /// 条件
        /// </summary>
        private Condition _condition;

        /// <summary>
        /// 是否物料
        /// </summary>
        private bool _isMateriel;

        /// <summary>
        /// 新窗体标题
        /// </summary>
        private string _newFormTile;

        /// <summary>
        /// 隐藏Panel高度
        /// </summary>
        private int _panel2Height;

        public UcInboundManage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 仓库
        /// </summary>
        public int WarehouseId { get; set; }

        /// <summary>
        /// 入库明细Service
        /// </summary>
        public IEntityService<InboundDetail> InboundDetailService
        {
            get { return ServiceHelper.GetService<InboundDetail>(); }
        }

        /// <summary>
        /// 入库类型
        /// </summary>
        public InboundType InboundType { get; set; }

        /// <summary>
        /// 条件
        /// </summary>
        private Condition Condition
        {
            get
            {
                // 查询条件
                Condition condition = _condition;

                // 状态条件
                if (Status != null && Status.Length > 0)
                {
                    condition &= new EntityColumn("Status").In(Status);
                }
                else if (btnHidden.Checked)
                {
                    condition &= new EntityColumn("Status") != InboundStatus.Invalid;
                }

                // 类型条件
                if (Types != null && Types.Length > 0)
                {
                    condition &= new EntityColumn("Type").In(Types);
                }
                else
                {
                    condition &= (new EntityColumn("Type") == InboundType);
                }


                return condition;
            }
            set { _condition = value; }
        }

        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 入库Service
        /// </summary>
        private IEntityService<Inbound> InboundService
        {
            get { return ServiceHelper.GetService<Inbound>(); }
        }

        #region IInitControl Members

        /// <summary>
        /// 初始化
        /// </summary>
        public void Init()
        {
            //验收人
            glueInspector.BindUser(ControlMode.Query,
                                   new List<string>
                                       {
                                           "purchase",
                                           "centerWarehosue",
                                           "workshopWarehouse",
                                           "productWarehouse",
                                           "purchase",
                                           "qualityManagement",
                                           "administrators"
                                       });
            riglueInspector.BindUser();
            riglueType.Bind<InboundType>();
            //仓库
            riglueWarehouse.BindWarehouse();
            riglueStatus.Bind<InboundStatus>();

            deBegainReceiveTime.EditValue = DateTimeHelper.Now;
            deEndReceiveTime.EditValue = DateTimeHelper.Now;
            gridColumn8.Visible = false;
            gridColumn4.Visible = false;
            gridColumn5.Visible = false;
            gridColumn12.Visible = false;
            gridColumn3.Visible = false;
            gridColumn2.Visible = false;
            gridColumn7.Visible = false;

            switch (InboundType)
            {
                case InboundType.Purchase:
                    PurchaseFormInit();
                    _isMateriel = true;
                    _newFormTile = "入库单（原料供应商=>中心原料仓库）";
                    break;
                case InboundType.Material:
                    MaterialFormInit();
                    _isMateriel = true;
                    _newFormTile = "出库单（中心原料仓库=>车间原料仓库）";
                    break;
                case InboundType.ReturnMaterial:
                    ReturnMaterialFormInit();
                    _isMateriel = true;
                    _newFormTile = "退料单（产品生产线=>车间原料仓库）";
                    break;
                case InboundType.Product:
                    ProductFormInit();
                    _isMateriel = false;
                    _newFormTile = "产品入库单（产品生产线=>成品仓库）";
                    break;
                case InboundType.ReturnProduct:
                    ReturnProductFormInit();
                    _isMateriel = false;
                    _newFormTile = "产品退货单（总装车间/客户=>成品仓库）";
                    break;
                case InboundType.ReturnMaterialToCenter:
                    ReturnMaterialToCenterFormInit();
                    _isMateriel = true;
                    _newFormTile = "退料单（车间原料仓库=>中心原料仓库）";
                    break;
                case InboundType.CenterAdjust:
                case InboundType.PlantAdjust:
                    AdjustFormInit();
                    _isMateriel = true;
                    _newFormTile = "损益入库单（原料仓库）";
                    break;
                case InboundType.ProductAdjust:
                    AdjustFormInit();
                    _isMateriel = false;
                    _newFormTile = "损益入库单（成品仓库）";
                    break;
                case InboundType.BackProduct:
                    BackProductFormInit();
                    _isMateriel = false;
                    _newFormTile = "归还入库单（借还部门=>成品仓库）";
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            CommonApi.BindSku(riglueSkuCategoryName, riglueSkuName, riglueSkuCode, riglueSkuSpec, riglueSkuModel,
                              riglueSkuColor, _isMateriel);
            Condition = CommonApi.GetCondition<Inbound>(Controls);
            Rebind();
            if (OpenMode == OpenMode.SingleSelect)
            {
                barManager1.HideInNotQuery();
            }
            splitContainerControl1.Collapsed = true;
        }

        #endregion

        #region IOrderControl Members

        /// <summary>
        /// 打开方式
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

        private void UcInboundManage_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// 新建
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnNewItemClick(object sender, ItemClickEventArgs e)
        {
            var ucInbound = new UcInbound {InboundType = InboundType, Title = Title, WarehouseId = WarehouseId};
            ucInbound.Init();
            ucInbound.ShowDialog("新建-" + _newFormTile);
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
            var inbound = gridView1.Current<Inbound>();
            if (inbound != null)
            {
                var ucInbound = new UcInbound
                                    {
                                        Data = inbound,
                                        InboundType = InboundType,
                                        Title = Title,
                                        WarehouseId = WarehouseId
                                    };
                ucInbound.Init();
                ucInbound.ShowDialog("编辑-" + _newFormTile);
                Rebind();
                ResetEditable();
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnRemoveItemClick(object sender, ItemClickEventArgs e)
        {
            var current = gridView1.Current<Inbound>();

            if (current != null)
            {
                if (MessageBox.Show("单据作废后不能取消，是否确认作废" + _newFormTile + "\"" + current.Code + "\"?", "提示信息",
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    current.Status = InboundStatus.Invalid;
                    InboundService.Save(current);
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
            Condition = CommonApi.GetCondition<Inbound>(Controls);
            Rebind();
        }

        /// <summary>
        /// 重新绑定数据
        /// </summary>
        private void Rebind()
        {
            // 默认时间倒序
            gridControl1.DataSource =
                InboundService.GetAll(new QueryInfo
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
        }

        /// <summary>
        /// 打印报表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnPrintItemClick(object sender, ItemClickEventArgs e)
        {
            var inbound = gridView1.Current<Inbound>();
            if (inbound != null)
            {
                XtraReport report = inbound.GetReport(InboundType);
                report.ShowPrint();
            }
        }

        /// <summary>
        /// 设置按钮状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView1_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            ResetEditable();
        }

        /// <summary>
        /// 设置按钮状态
        /// </summary>
     
        private void ResetEditable()
        {
            var inbound = gridView1.Current<Inbound>();
            if (inbound != null)
            {
                if (inbound.Status == InboundStatus.Created)
                {
                    btnRemove.Enabled = true;
                    btnEdit.Caption = "编辑";
                }
                else
                {
                    btnRemove.Enabled = false;
                    btnEdit.Caption = "查看";
                }
            }
        }

        /// <summary>
        /// 显示隐藏作废单据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnHiddenCheckedChanged(object sender, ItemClickEventArgs e)
        {
           
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
        /// 导出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnExportItemClick(object sender, ItemClickEventArgs e)
        {
            var inbound = gridView1.Current<Inbound>();
            if (inbound != null)
            {
                inbound.GetReport(InboundType).Export(Title + inbound.Code);
            }
        }

        /// <summary>
        /// 主表展开，加载子表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GridView1MasterRowExpanding(object sender, MasterRowCanExpandEventArgs e)
        {
            var current = gridView1.Current<Inbound>();
            if (current != null && current.Details.Count == 0)
            {
                current.Details.AddRange(
                    InboundDetailService.FindAll(d => d.InboundId == current.InboundId, null));
            }
        }

        /// <summary>
        /// 双击编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GridView1DoubleClick(object sender, EventArgs e)
        {
            Edit();
        }

        /// <summary>
        /// 显示/隐藏扩展查询条件
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


        /// <summary>
        /// 采购入库
        /// 供应商	====>>	中心仓
        /// </summary>
        private void PurchaseFormInit()
        {
            //查询条件
            lblPreOrderType.Text = "采购申请单号";
            beRelationCode.BindOrder<UcPurchaseOrderManage>("选择采购申请单号");

            lblSourceUnit.Text = "供应商";
            glueSourceUnit.BindVendor(ControlMode.Query);

            //高级查询条件
            labelCheckUser.Text = "库房验收人";
            //glueInspector.BindUser(ControlMode.Query, null);

            lblBuyer.Text = "零部件提交人";
            glueDeliverMan.BindUser(ControlMode.Query, null);

            lblSender.Text = "零部件提交部门";
            glueDeliverDep.BindDepartment(ControlMode.Query);

            //主表显示
            gridColumn13.Caption = "采购申请单号";

            gcSourceUnit.Caption = "供应商";
            riglueSourceUnit.BindVendor();

            gridColumn16.Caption = "零部件提交人";
            riglueDeliverMan.BindUser();

            gridColumn15.Caption = "零部件提交部门";
            riglueDeliverDep.BindDepartment();
        }

        /// <summary>
        /// 车间仓库领料
        /// 中心仓	====>>	车间仓
        /// </summary>
        private void MaterialFormInit()
        {
            //查询条件
            lblPreOrderType.Text = "关联出库单号";
            beRelationCode.BindOrder<UcOutboundManage>("选择出库单");

            lblSourceUnit.Visible = false;
            glueSourceUnit.Visible = false;

            //高级查询条件
            labelCheckUser.Text = "库房验收人";
            //glueInspector.BindUser(ControlMode.Query, null);

            lblBuyer.Text = "发料人";
            glueDeliverMan.BindUser(ControlMode.Query, null);

            lblSender.Visible = false;
            glueDeliverDep.Visible = false;

            //主表显示
            gridColumn13.Caption = "关联出库单号";

            gcSourceUnit.Visible = false;

            gridColumn16.Caption = "发料人";
            riglueDeliverMan.BindUser();

            gridColumn15.Visible = false;
        }

        /// <summary>
        /// 退料入库
        /// 生产线	====>>	车间仓
        /// </summary>		
        private void ReturnMaterialFormInit()
        {
            //查询条件
            lblPreOrderType.Text = "关联生产单号";
            beRelationCode.BindOrder<UcProductionPlanManage>("选择生产计划单");

            lblSourceUnit.Visible = false;
            glueSourceUnit.Visible = false;

            //高级查询条件
            labelCheckUser.Text = "库房验收人";
            //glueInspector.BindUser(ControlMode.Query, null);

            lblBuyer.Text = "退料人";
            glueDeliverMan.BindUser(ControlMode.Query, null);

            lblSender.Visible = false;
            glueDeliverDep.Visible = false;


            //主表显示
            gridColumn13.Caption = "关联生产单号";

            gcSourceUnit.Caption = "发货仓库";
            gcSourceUnit.Visible = false;

            gridColumn16.Caption = "退料人";
            riglueDeliverMan.BindUser();

            gridColumn15.Visible = false;
        }

        /// <summary>
        /// 成品入库
        /// 生产线	====>>	成品仓
        /// </summary>		
        private void ProductFormInit()
        {
            //查询条件
            lblPreOrderType.Text = "关联工单号";
            beRelationCode.BindOrder<UcProductionOrderManage>("选择生产工单");

            lblSourceUnit.Text = "生产产线";
            glueSourceUnit.BindWorkShop(ControlMode.Query);

            //高级查询条件
            labelCheckUser.Text = "库房验收人";
            //glueInspector.BindUser(ControlMode.Query, null);

            lblBuyer.Text = "提交人";
            glueDeliverMan.BindUser(ControlMode.Query, null);

            lblSender.Visible = false;
            glueDeliverDep.Visible = false;


            //主表显示
            gridColumn13.Caption = "关联工单号";

            gcSourceUnit.Caption = "生产产线";
            riglueSourceUnit.BindWorkShop();

            gridColumn16.Caption = "提交人";
            riglueDeliverMan.BindUser();

            gridColumn15.Visible = false;
        }

        /// <summary>
        /// 退货入库
        /// 总装车间(客户)	====>>	成品仓
        /// </summary>		
        private void ReturnProductFormInit()
        {
            //查询条件
            lblPreOrderType.Text = "关联销售单号";
            beRelationCode.BindOrder<UcSalesOrderManage>("选择销售订单");

            lblSourceUnit.Text = "退货单位";
            glueSourceUnit.BindCustomer(ControlMode.Query);

            //高级查询条件
            labelCheckUser.Text = "库房验收人";
            //glueInspector.BindUser(ControlMode.Query, null);

            lblBuyer.Visible = false;
            glueDeliverMan.Visible = false;

            lblSender.Visible = false;
            glueDeliverDep.Visible = false;


            //主表显示
            gridColumn13.Caption = "关联销售单号";

            gcSourceUnit.Caption = "退货单位";
            riglueSourceUnit.BindCustomer();

            gridColumn16.Visible = false;

            gridColumn15.Visible = false;
        }

        /// <summary>
        /// 退料入库
        /// 车间仓	====>>	中心仓
        /// </summary>		
        private void ReturnMaterialToCenterFormInit()
        {
            //查询条件
            lblPreOrderType.Text = "关联出库单号";
            beRelationCode.BindOrder<UcOutboundManage>("选择出库单");


            lblSourceUnit.Text = "退料部门";
            glueSourceUnit.BindDepartment(ControlMode.Query);

            //高级查询条件
            labelCheckUser.Text = "库房验收人";
            //glueInspector.BindUser(ControlMode.Query, null);

            lblBuyer.Text = "退料人";
            glueDeliverMan.BindUser(ControlMode.Query, null);

            lblSender.Visible = false;
            glueDeliverDep.Visible = false;

            //主表显示
            gridColumn13.Caption = "关联出库单号";

            gcSourceUnit.Caption = "退料仓(部门)";
            riglueSourceUnit.BindDepartment();

            gridColumn16.Caption = "退料人";
            riglueDeliverMan.BindUser();

            gridColumn15.Visible = false;
        }

        /// <summary>
        /// 损益入库
        /// 三种仓库损益入库共用
        /// </summary>		
        private void AdjustFormInit()
        {
            //查询条件
            lblPreOrderType.Visible = false;
            beRelationCode.Visible = false;
            lblSourceUnit.Visible = false;
            glueSourceUnit.Visible = false;

            //高级查询条件
            labelCheckUser.Text = "盘点人";
            //glueInspector.BindUser(ControlMode.Query, null);

            lblBuyer.Visible = false;
            glueDeliverMan.Visible = false;

            lblSender.Visible = false;
            glueDeliverDep.Visible = false;

            //主表显示
            gridColumn9.Caption = "盘点人";
            gridColumn13.Visible = false;
            gcSourceUnit.Visible = false;
            gridColumn16.Visible = false;
            gridColumn15.Visible = false;
        }

        /// <summary>
        /// 归还入库
        /// 其他车间或单位	====>>	成品仓
        /// </summary>		
        private void BackProductFormInit()
        {
            //查询条件
            lblPreOrderType.Text = "关联出库单号";
            beRelationCode.BindOrder<UcOutboundManage>("选择出库单");

            lblSourceUnit.Text = "归还部门";
            glueSourceUnit.BindDepartment(ControlMode.Query);

            //高级查询条件
            labelCheckUser.Text = "库房验收人";
            // glueInspector.BindUser(ControlMode.Query, null);

            lblBuyer.Text = "归还人";
            glueDeliverMan.BindUser(ControlMode.Query, null);

            lblSender.Visible = false;
            glueDeliverDep.Visible = false;

            //主表显示
            gridColumn13.Caption = "关联出库单号";

            gcSourceUnit.Caption = "归还部门";
            riglueSourceUnit.BindDepartment();

            gridColumn16.Caption = "归还人";
            riglueDeliverMan.BindUser();

            gridColumn15.Visible = false;
        }
    }
}