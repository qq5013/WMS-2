/*----------------------------------------------------------------
// Copyright (C) 2010 有限公司
// 版权所有。 
//
// 文件名：         UcProductionPlan.cs
// 文件功能描述：   生产计划
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
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using Frame.Utils.Service;
using MES.BllService;
using MES.Entity;
using MES.Enum;
using MES.Execute.Common;
using MES.Execute.Properties;

namespace MES.Execute.Controls
{
    /// <summary>
    /// 生产计划
    /// </summary>
    public partial class UcProductionPlan : UserControl, IInitControl, ICheckClosing
    {
        public UcProductionPlan()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Data
        /// </summary>
        public ProductionPlan Data { get; set; }

        #region ICheckClosing Members

        /// <summary>
        /// 数据变更
        /// </summary>
        public bool DataChanged { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 保存
        /// </summary>
        /// <returns></returns>
        public bool Save()
        {
            foreach (GridView view in gridControl1.Views)
            {
                view.PostEditor();
            }

            Data.LoadData(Controls);
            int productionPlanId = ServiceBloker.GetService<ProductionPlan>().Save(Data);
            if (Data.ProductionPlanId == 0)
            {
                Data.ProductionPlanId = productionPlanId;
            }
            //删除控件中删除的数据
            foreach (ProductionPlanDetail detail in Data.RemoveList)
            {
                if (detail.GetEntityId() > 0)
                    detail.Remove();
            }
            Data.RemoveList.Clear();

            // 保存明细
            foreach (ProductionPlanDetail detail in Data.Details)
            {
                detail.ProductionPlanId = Data.ProductionPlanId;
                int productionPlanDetailId = ServiceBloker.GetService<ProductionPlanDetail>().Save(detail);
                if (detail.ProductionPlanDetailId == 0)
                {
                    detail.ProductionPlanDetailId = productionPlanDetailId;
                }
                // 保存每日的计划
                foreach (ProductionPlanMonthItem productionPlanMonthItem in detail.Details)
                {
                    productionPlanMonthItem.ProductionPlanDetailId = detail.ProductionPlanDetailId;
                    int productionPlanMonthItemId =
                        ServiceBloker.GetService<ProductionPlanMonthItem>().Save(productionPlanMonthItem);
                    if (productionPlanMonthItem.ProductionPlanMonthItemId == 0)
                    {
                        productionPlanMonthItem.ProductionPlanMonthItemId = productionPlanMonthItemId;
                    }
                }
            }
            return true;
        }

        #endregion

        #region IInitControl Members

        /// <summary>
        /// 初始化
        /// </summary>
        public void Init()
        {
            barManager2.Form = groupControl1;
            glueCustomer.BindCustomer(ControlMode.Edit);
            glueCreater.BindUser(ControlMode.Edit, null);

            CommonApi.BindSku(rigleSkuCategoryName, rigleSkuName, rigleSkuCode, rigleSkuSpec, rigleSkuModel,
                              rigleSkuColor, false);

            if (Data != null)
            {
                teCode.Properties.ReadOnly = true;
                Data.FillData(Controls);

                // 已经审核的生产计划不能编辑
                if (Data.Status != ProductionPlanStatus.Created)
                {
                    foreach (object control in Controls)
                    {
                        if (control is GridLookUpEdit)
                        {
                            ((GridLookUpEdit) control).Properties.ReadOnly = true;
                        }
                        else if (control is TextEdit)
                        {
                            ((TextEdit) control).Properties.ReadOnly = true;
                        }
                        else if (control is CheckEdit)
                        {
                            ((CheckEdit) control).Properties.ReadOnly = true;
                        }
                    }
                    bandedGridView1.OptionsBehavior.ReadOnly = true;
                    btnSave.Enabled = false;
                    btnAdd.Enabled = false;
                    btnRemove.Enabled = false;
                    barButtonItem1.Enabled = false;
                }
                Data.Details.Clear();
                Data.Details.AddRange(
                    ServiceBloker.GetService<ProductionPlanDetail>().FindAll(
                        c => c.ProductionPlanId == Data.ProductionPlanId, null));
                foreach (ProductionPlanDetail productionPlanDetail in Data.Details)
                {
                    ProductionPlanDetail detail = productionPlanDetail;
                    productionPlanDetail.Details.AddRange(
                        ServiceBloker.GetService<ProductionPlanMonthItem>().FindAll(
                            c => c.ProductionPlanDetailId == detail.ProductionPlanDetailId, null));
                }
                BindDetail();
            }
            else
            {
                Reset();
            }
        }

        #endregion

        /// <summary>
        /// 重置
        /// </summary>
        private void Reset()
        {
            Data = new ProductionPlan
                       {
                           CreateTime = DateTimeHelper.Now,
                           CreaterId = CommonApi.CurrentUser().UserId,
                           Status = ProductionPlanStatus.Created,
                           DeliverDate = DateTimeHelper.Min
                       };
            teCode.Text = CommonApi.GetCode<ProductionPlan>();
            teCode.Properties.ReadOnly = true;

            Data.FillData(Controls);
            BindDetail();
        }

        private void UcProductionPlan_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCancelItemClick(object sender, ItemClickEventArgs e)
        {
            DoClose();
        }
        /// <summary>
        /// 关闭
        /// </summary>
        private void DoClose()
        {
            if (ParentForm != null) ParentForm.Close();
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSaveItemClick(object sender, ItemClickEventArgs e)
        {
            Save();

            if (
                MessageBox.Show("保存成功是否关闭编辑界面？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                DoClose();
            }
            else
            {
                BindDetail();
            }
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAddItemClick(object sender, ItemClickEventArgs e)
        {
            dxErrorProvider1.ClearErrors();
            if (dePlanMonth.EditValue == null)
            {
                dxErrorProvider1.SetError(dePlanMonth, "请先选择生产月份");
                MessageBox.Show("请先选择生产月份");
                return;
            }
            dePlanMonth.Properties.ReadOnly = true;
            var ucSelectSku = new UcSelectSku {CallBack = ImportCode, IsMateriel = false};
            ucSelectSku.Init();
            new Form
                {
                    Controls = {ucSelectSku},
                    Size = new Size(700, 280),
                    Text = Resources.AddProduct
                }.Dialog();
        }
        /// <summary>
        /// 输入条码
        /// </summary>
        /// <param name="skuinfo"></param>
        /// <param name="barcode"></param>
        /// <param name="lotno"></param>
        /// <param name="measureid"></param>
        /// <param name="quantity"></param>
        /// <param name="showerror"></param>
        private void ImportCode(SkuInfo skuinfo, string barcode, string lotno, int measureid, int quantity,
                                ShowError showerror)
        {
            ProductionPlanDetail detail = Data.Details.Find(c => c.SkuId == skuinfo.SkuId);
            // 明细存在则增加数量
            if (detail != null)
            {
                detail.Quantity += quantity;
            }
            else
            {
                // 明细不存在增加明细
                Data.Details.Insert(0,
                                    new ProductionPlanDetail
                                        {
                                            SkuId = skuinfo.SkuId,
                                            Quantity = quantity,
                                            MeasureId = measureid,
                                            Details = {new ProductionPlanMonthItem()}
                                        });
            }
            BindDetail();
        }
        /// <summary>
        /// 绑定明显
        /// </summary>
        private void BindDetail()
        {
            gridControl1.DataSource = null;
            gridControl1.DataSource = Data.Details;
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnRemoveItemClick(object sender, ItemClickEventArgs e)
        {
            int[] selectedRows = bandedGridView1.GetSelectedRows();
            if (selectedRows != null && selectedRows.Length > 0)
            {
                List<ProductionPlanDetail> list =
                    selectedRows.Select(selectedRow => bandedGridView1.GetRow(selectedRow) as ProductionPlanDetail).
                        ToList();
                //将选中的记录设为临时删除记录
                foreach (ProductionPlanDetail detail in list)
                {
                    Data.RemoveList.Add(detail);
                    Data.Details.Remove(detail);
                }

                BindDetail();
            }
        }
        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnPrintItemClick(object sender, ItemClickEventArgs e)
        {
            if (Data == null)
            {
                return;
            }
            gridControl1.MainView.PostEditor();
            Data.LoadData(Controls);
            //Data.GetReport().ShowPrint();
        }
        /// <summary>
        /// 导出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnExportItemClick(object sender, ItemClickEventArgs e)
        {
            if (Data == null)
            {
                return;
            }
            gridControl1.MainView.PostEditor();
            Data.LoadData(Controls);
            //Data.GetReport().Export("生产计划" + Data.Code);
        }
        /// <summary>
        /// 月份编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DePlanMonthEditValueChanged(object sender, EventArgs e)
        {
            DateTime dateTime = dePlanMonth.DateTime.Date;

            dateTime = Convert.ToDateTime(dateTime.ToString("yyyy-MM-01"));
            int days = (dateTime.AddMonths(1) - dateTime).Days;
            gridView7.Columns.Clear();
            //增加该月每天的记录
            for (int i = 0; i < days; i++)
            {
                gridView7.Columns.Add(new GridColumn
                                          {
                                              Caption = (i + 1).ToString(),
                                              ColumnEdit = new RepositoryItemSpinEdit {MinValue = 0, EditMask = "f0"},
                                              Visible = true,
                                              VisibleIndex = i,
                                              FieldName = "Item" + i
                                          });
            }
        }
    }
}