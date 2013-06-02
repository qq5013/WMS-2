/*----------------------------------------------------------------
// Copyright (C) 2010 有限公司
// 版权所有。 
//
// 文件名：         UcProductionPlanManage.cs
// 文件功能描述：   生产计划管理
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
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraReports.UI;
using Frame.Utils.RelaAndCondition;
using Frame.Utils.Service;
using MES.BllService;
using MES.Common;
using MES.Entity;
using MES.Enum;

namespace MES.Execute.Controls
{
    /// <summary>
    /// 生产计划管理
    /// </summary>
    public partial class UcProductionPlanManage : UserControl, IInitControl, IOrderControl
    {
        /// <summary>
        /// 查询条件
        /// </summary>
        private Condition _condition;

        /// <summary>
        /// Panel高度
        /// </summary>
        private int _panel2Height;

        public UcProductionPlanManage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 查询条件
        /// </summary>
        private Condition Condition
        {
            get
            {
                return btnHide.Checked
                           ? _condition & (new EntityColumn("Status") != OutboundStatus.Invalid)
                           : _condition;
            }
            set { _condition = value; }
        }

        #region IInitControl Members

        /// <summary>
        /// 初始化
        /// </summary>
        public void Init()
        {
            SuspendLayout();
            // Query Field
            glueCustomer.BindCustomer(ControlMode.Query);
            glueCreater.BindUser(ControlMode.Query, null);


            // Master
            //riglueCustomer.BindCustomer();
            riglueCreater.BindUser();

            // Detail
            CommonApi.BindSku(riglueSkuCategoryName, riglueSkuName, riglueSkuCode, riglueSkuSpec, riglueSkuModel,
                              riglueSkuColor, false);

            Condition = CommonApi.GetCondition<ProductionPlan>(Controls);
            //Bind data
            Rebind();

            _panel2Height = _panel2Height > 0 ? _panel2Height : splitContainerControl1.Panel2.Height;
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
        /// 设置单据号
        /// </summary>
        public SetOrderCode SetOrderCode { get; set; }

        #endregion

        /// <summary>
        /// 新建
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnNewItemClick(object sender, ItemClickEventArgs e)
        {
            var ucProductionPlan = new UcProductStatistics();
            ucProductionPlan.Init();
            ucProductionPlan.ShowDialog(String.Format("新建-{0}", "生产计划"));
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
            var current = gridView1.Current<ProductionPlan>();

            if (current != null)
            {
                var ucProductionPlan = new UcProductStatistics
                                           {
                                               Data = current
                                           };
                ucProductionPlan.Init();
                ucProductionPlan.ShowDialog(String.Format("编辑-{0}", "生产计划"));
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
            var current = gridView1.Current<ProductionPlan>();

            if (current != null)
            {
                if (MessageBox.Show("单据作废后不能取消，是否确认作废生产计划单\"" + current.Code + "\"?", "提示信息", MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    current.Status = ProductionPlanStatus.Invalid;
                    ServiceBloker.GetService<ProductionPlan>().Save(current);
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
            Condition = CommonApi.GetCondition<ProductionPlan>(Controls);

            Rebind();
        }

        /// <summary>
        /// 重新绑定
        /// </summary>
        private void Rebind()
        {
            gridControl1.DataSource =
                ServiceBloker.GetService<ProductionPlan>().GetAll(new QueryInfo
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

        private void UcProductionPlanManage_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnPrintItemClick(object sender, ItemClickEventArgs e)
        {
            var current = gridView1.Current<ProductionPlan>();

            if (current != null)
            {
                //XtraReport report = current.GetReport();
                //report.ShowPrint();
            }
        }

        /// <summary>
        /// 根据选中的记录设置按钮的状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GridView1FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            ResetEditable();
        }

        /// <summary>
        /// 设置按钮的状态
        /// </summary>
        private void ResetEditable()
        {
            var current = gridView1.Current<ProductionPlan>();
            if (current != null && current.Status != ProductionPlanStatus.Created)
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
        /// 展开主表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GridView1MasterRowExpanding(object sender, MasterRowCanExpandEventArgs e)
        {
            var current = gridView1.Current<ProductionPlan>();
            if (current != null && current.Details.Count == 0)
            {
                current.Details.AddRange(
                    ServiceBloker.GetService<ProductionPlanDetail>().FindAll(
                        d => d.ProductionPlanId == current.ProductionPlanId, null));
            }
        }

        /// <summary>
        /// 双击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GridView1DoubleClick(object sender, EventArgs e)
        {
            if (OpenMode == OpenMode.SingleSelect)
            {
                var current = gridView1.Current<ProductionPlan>();
                if (current != null && current.Details.Count == 0)
                {
                    SetOrderCode(current.Code);
                }
                if (ParentForm != null) ParentForm.Close();
            }
            else
                Edit();
        }

        /// <summary>
        /// 隐藏或者显示高级查询
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
        /// 隐藏或者显示高级查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAdvanceQueryItemClick(object sender, ItemClickEventArgs e)
        {
            splitContainerControl1.Collapsed = !splitContainerControl1.Collapsed;
        }

        /// <summary>
        /// 隐藏和显示作废单据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnHideCheckedChanged(object sender, ItemClickEventArgs e)
        {
            Rebind();
        }

        /// <summary>
        /// 导出生产计划
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExport_ItemClick(object sender, ItemClickEventArgs e)
        {
            var current = gridView1.Current<ProductionPlan>();

            if (current != null)
            {
                //XtraReport report = current.GetReport();
                //report.Export("生产计划" + current.Code);
            }
        }
    }
}