

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
using MES.Execute.Properties;

namespace MES.Execute.Controls
{
    /// <summary>
    /// 出库管理
    /// </summary>
    public partial class UcOutboundManage : UserControl, IInitControl, IOrderControl
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
        /// 隐藏窗体高度
        /// </summary>
        private int _panel2Height;

        /// <summary>
        /// 类型
        /// </summary>
        private int[] _types;

        public UcOutboundManage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 仓库
        /// </summary>
        public int WarehouseId { get; set; }

        /// <summary>
        /// 出库类型
        /// </summary>
        public OutboundType OutboundType { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 条件
        /// </summary>
        private Condition Condition
        {
            get
            {
                Condition condition = _condition;
                // 状态
                if (Status != null && Status.Length > 0)
                {
                    condition &= new EntityColumn("Status").In(Status);
                }
                else if (btnHidden.Checked)
                {
                    condition &= new EntityColumn("Status") != OutboundStatus.Invalid;
                }
                // 类型
                if (Types != null && Types.Length > 0)
                {
                    condition &= new EntityColumn("Type").In(Types);
                }
                else
                {
                    condition &= new EntityColumn("Type") == OutboundType;
                }
                return condition;
            }
            set { _condition = value; }
        }

        #region IInitControl Members

        public void Init()
        {
            //发货人
            glueOperator.BindUser(ControlMode.Query,
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
            //目标仓库
            riglueTargetUnit.BindWarehouse();
            //状态
            riglueStatus.Bind<OutboundStatus>();

            deBegainOperateTime.EditValue = DateTimeHelper.Now;
            deEndOperateTime.EditValue = DateTimeHelper.Now;

            switch (OutboundType)
            {
                case OutboundType.Product:
                    ProductFormInit();
                    _newFormTile = "产品销售出库单（车间成品仓库=>总转车间/客户）";
                    _isMateriel = false;
                    break;
                case OutboundType.Material:
                    MaterialFormInit();
                    _newFormTile = "车间发料出库单（中心原料仓库=>车间原料仓库）";
                    _isMateriel = true;
                    break;
                case OutboundType.ReturnMaterial:
                    ReturnMaterialFormInit();
                    _newFormTile = "供应商退货出库单（中心原料仓库=>供应商）";
                    _isMateriel = true;
                    break;
                case OutboundType.WorkShopMaterial:
                    WorkShopMaterialFormInit();
                    _newFormTile = "生产线领料出库单（车间原料仓库=>控制器生产线）";
                    _isMateriel = true;
                    break;
                case OutboundType.BackCenter:
                    BackCenterFormInit();
                    _newFormTile = "退料出库单（车间原料仓库=>中心原料仓库）";
                    _isMateriel = true;
                    break;
                case OutboundType.Inspect:
                    InspectFormInit();
                    _newFormTile = "其他部门借用出库单（车间成品仓库=>其他借用部门）";
                    _isMateriel = false;
                    break;
                case OutboundType.ProductAdjust:
                    CenterAdjustFormInit();
                    _newFormTile = "损益出库单（成品仓库）";
                    _isMateriel = false;
                    break;
                case OutboundType.CenterAdjust:
                case OutboundType.PlantAdjust:
                    CenterAdjustFormInit();
                    _isMateriel = true;
                    _newFormTile = "损益出库单（原料仓库）";
                    break;
                default:
                    break;
            }

            riglueOperator.BindUser();
            riglueType.Bind<OutboundType>();
            riglueWarehouse.BindWarehouse();
            riglueCreater.BindUser();
            //julio:出库管理界面，初期化时，显示了所有的纪录，而不是按界面上的出库时间为条件来筛选纪录的。（初期化只显示当天出库单）kenny 2010/11/10

            CommonApi.BindSku(riglueSkuCategoryName, riglueSkuName, riglueSkuCode, riglueSkuSpec, riglueSkuModel,
                              riglueSkuColor, _isMateriel);
            if (OpenMode == OpenMode.SingleSelect)
            {
                barManager1.HideInNotQuery();
            }
            Condition = CommonApi.GetCondition<Outbound>(Controls);
            Rebind();
            splitContainerControl1.Collapsed = true;
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
        public int[] Types
        {
            get { return _types; }
            set
            {
                if (value != null && value.Length > 0)
                {
                    OutboundType = (OutboundType) value[0];
                }
                _types = value;
            }
        }

        /// <summary>
        /// 销售订单号
        /// </summary>
        public SetOrderCode SetOrderCode { get; set; }

        #endregion

        private void UcOutboundManage_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// 新建
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnNewItemClick(object sender, ItemClickEventArgs e)
        {
            var ucOutbound = new UcOutbound {OutboundType = OutboundType, Title = Title, WarehouseId = WarehouseId};
            ucOutbound.Init();
            ucOutbound.ShowDialog("新建-" + _newFormTile);
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
            var outbound = gridView1.Current<Outbound>();
            if (outbound != null)
            {
                var ucOutbound = new UcOutbound
                                     {
                                         Data = outbound,
                                         OutboundType = OutboundType,
                                         Title = Title,
                                         WarehouseId = WarehouseId
                                     };
                ucOutbound.Init();
                ucOutbound.ShowDialog("编辑-" + _newFormTile);
                Rebind();
                ResetEditable();
            }
        }

        /// <summary>
        /// 作废单据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDeleteItemClick(object sender, ItemClickEventArgs e)
        {
            var current = gridView1.Current<Outbound>();

            if (current != null)
            {
                if (MessageBox.Show("单据作废后不能取消，是否确认作废" + _newFormTile + "\"" + current.Code + "\"?", "提示信息",
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    current.Status = OutboundStatus.Invalid;
                    ServiceHelper.GetService<Outbound>().Save(current);
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
            Condition = CommonApi.GetCondition<Outbound>(Controls);

            Rebind();
        }

        /// <summary>
        /// 重新绑定
        /// </summary>
        private void Rebind()
        {
            gridControl1.DataSource =
                ServiceHelper.GetService<Outbound>().GetAll(new QueryInfo
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
                                                                                            ListSortDirection.Descending
                                                                                    }
                                                                            }
                                                                });
        }

        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnPrintItemClick(object sender, ItemClickEventArgs e)
        {
            var current = gridView1.Current<Outbound>();

            if (current != null)
            {
                XtraReport report = current.GetReport(OutboundType);
                report.ShowPrint();
            }
        }

        /// <summary>
        /// 隐藏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnHiddenCheckedChanged(object sender, ItemClickEventArgs e)
        {
            Rebind();
        }

        /// <summary>
        /// 导出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnExportItemClick(object sender, ItemClickEventArgs e)
        {
            var current = gridView1.Current<Outbound>();

            if (current != null)
            {
                current.GetReport(OutboundType).Export(Title + current.Code);
            }
        }

        /// <summary>
        /// 控制按钮状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GridView1FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            ResetEditable();
        }

        /// <summary>
        /// 控制按钮状态
        /// </summary>
        private void ResetEditable()
        {
            var current = gridView1.Current<Outbound>();
            if (current != null && current.Status != OutboundStatus.Created)
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
        /// 主表展开
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GridView1MasterRowExpanding(object sender, MasterRowCanExpandEventArgs e)
        {
            var current = gridView1.Current<Outbound>();
            if (current != null && current.Details.Count == 0)
            {
                // 如果明细为空添加
                current.Details.AddRange(
                    ServiceHelper.GetService<OutboundDetail>().FindAll(d => d.OutboundId == current.OutboundId, null));
            }
        }

        /// <summary>
        /// 双击浏览或者编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            if (OpenMode == OpenMode.SingleSelect)
            {
                var current = gridView1.Current<Outbound>();
                if (current != null && current.Details.Count == 0)
                {
                    SetOrderCode(current.Code);
                }
                if (ParentForm != null) ParentForm.Close();
            }
            else
            {
                Edit();
            }
        }

        /// <summary>
        /// 展开或隐藏扩展条件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SplitContainerControl1SplitGroupPanelCollapsing(object sender,
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
        private void BtnAdvanceQueryItemClick(object sender, ItemClickEventArgs e)
        {
            splitContainerControl1.Collapsed = !splitContainerControl1.Collapsed;
        }

        /// <summary>
        /// 销售出库
        /// 成品仓	====>>	总装车间(客户)
        /// </summary>	
        private void ProductFormInit()
        {
            lblRelationCode.Text = "关联销售单号";
            beRelationCode.BindOrder<UcSalesOrderManage>("选择销售订单");
            gcRelationCode.Caption = "关联销售单号";

            lblTargetUnit.Text = "客户名称";
            glueTargetUnit.BindCustomer(ControlMode.Query);

            gcTargetUnit.Caption = "客户名称";
            riglueTargetUnit.BindCustomer();

            riglueReceiverDepartmen.BindCustomer();

            lblReceiver.Visible = false;
            glueReceiver.Visible = false;
            ;
            gcReceiver.Visible = false;

            gcReceiverDepartmen.Visible = false;
        }


        /// <summary>
        /// 领料出库
        /// 中心仓	====>>	车间仓
        /// </summary>		
        private void MaterialFormInit()
        {
            lblRelationCode.Text = Resources.RelaMaterialOrder;
            gcRelationCode.Caption = Resources.RelaMaterialOrder;

            lblTargetUnit.Text = "领料部门";
            glueTargetUnit.BindDepartment(ControlMode.Query);

            gcTargetUnit.Caption = "领料部门";
            riglueTargetUnit.BindDepartment();

            lblReceiver.Text = "领料人";
            glueReceiver.BindUser(ControlMode.Query, null);
            gcReceiver.Caption = "领料人";
            riglueReceiver.BindUser();

            gcReceiverDepartmen.Visible = false;
        }


        /// <summary>
        /// 退料出库
        /// 中心仓	====>>	供应商
        /// </summary>		
        private void ReturnMaterialFormInit()
        {
            lblRelationCode.Text = "关联采购单号";
            beRelationCode.BindOrder<UcPurchaseOrderManage>("选择采购订单");
            gcRelationCode.Caption = "关联采购单号";

            lblTargetUnit.Text = "供应商名称";

            glueTargetUnit.BindVendor(ControlMode.Query);
            gcTargetUnit.Caption = "供应商名称";
            riglueTargetUnit.BindVendor();

            gcWarehouse.Visible = true;
            gcWarehouse.Caption = "退料部门";
            riglueWarehouse.BindWarehouse();

            gcReceiverDepartmen.Visible = false;

            //接受人
            lblReceiver.Visible = false;
            glueReceiver.Visible = false;

            gcReceiver.Visible = false;
        }


        /// <summary>
        /// 车间领料出库
        /// 车间仓	====>>	生产线
        /// </summary>		
        private void WorkShopMaterialFormInit()
        {
            lblRelationCode.Text = "关联工单号";
            beRelationCode.BindOrder<UcProductionOrderManage>("选择生产工单");
            gcRelationCode.Caption = "关联工单号";

            lblTargetUnit.Text = "领料产线";
            glueTargetUnit.BindWorkShop(ControlMode.Query);
            gcTargetUnit.Caption = "领料产线";
            riglueTargetUnit.BindWorkShop();

            gcReceiverDepartmen.Visible = false;

            gcWarehouse.Visible = true;
            gcWarehouse.Caption = "发料部门";
            riglueWarehouse.BindWarehouse();

            //接受人
            lblReceiver.Text = "领料人";
            glueReceiver.BindUser(ControlMode.Query, null);
            gcReceiver.Caption = "领料人";
            riglueReceiver.BindUser();
        }


        /// <summary>
        /// 调试检验/借用出库
        /// 成品仓	====>>	其他车间或单位
        /// </summary>		
        private void InspectFormInit()
        {
            lblRelationCode.Visible = false;
            beRelationCode.Visible = false;
            gcRelationCode.Visible = false;

            lblTargetUnit.Text = "借用部门";
            glueTargetUnit.BindDepartment(ControlMode.Query);
            gcTargetUnit.Caption = "借用部门";
            riglueTargetUnit.BindDepartment();

            //接受人
            lblReceiver.Text = "借用人";
            glueReceiver.BindUser(ControlMode.Query, null);
            gcReceiver.Caption = "借用人";
        }


        /// <summary>
        /// 损益出库
        /// 中心仓	====>>	中心仓
        /// </summary>		
        private void CenterAdjustFormInit()
        {
            lblRelationCode.Visible = false;
            beRelationCode.Visible = false;
            gcRelationCode.Visible = false;

            lblTargetUnit.Visible = false;
            glueTargetUnit.Visible = false;
            gcTargetUnit.Visible = false;

            //接受人
            lblReceiver.Visible = false;
            glueReceiver.Visible = false;
            gcReceiver.Visible = false;

            lblOperator.Text = "盘点人";
            gcOperator.Caption = "盘点人";
        }


        /// <summary>
        /// 退货出库
        /// 车间仓	====>>	中心仓
        /// </summary>		
        private void BackCenterFormInit()
        {
            lblRelationCode.Text = "关联生产单号";
            beRelationCode.BindOrder<UcProductionPlanManage>("选择生产计划");
            gcRelationCode.Caption = "关联生产单号";

            lblTargetUnit.Text = "接收仓库";
            glueTargetUnit.BindWarehouse(ControlMode.Query);
            gcTargetUnit.Caption = "接收仓库";
            riglueTargetUnit.BindWarehouse();

            gcWarehouse.Visible = true;
            gcWarehouse.Caption = "退料部门";
            riglueWarehouse.BindWarehouse();

            gcReceiverDepartmen.Visible = false;

            //接受人
            lblReceiver.Visible = false;
            glueReceiver.Visible = false;

            gcReceiver.Visible = false;
        }
    }
}