﻿/*----------------------------------------------------------------
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
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using Frame.Utils.Service;
using MES.BllService;
using MES.Common;
using MES.Entity;
using MES.Enum;
using MES.Execute.Properties;

namespace MES.Execute.Controls
{
    /// <summary>
    ///     生产计划
    /// </summary>
    public partial class UcProductStatistics : UserControl, IInitControl, ICheckClosing
    {
        public UcProductStatistics()
        {
            InitializeComponent();
        }

        /// <summary>
        ///     Data
        /// </summary>
        public ProductionPlan Data { get; set; }

        #region ICheckClosing Members

        /// <summary>
        ///     数据变更
        /// </summary>
        public bool DataChanged { get; set; }

        /// <summary>
        ///     标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        ///     保存
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
            }
            return true;
        }

        #endregion

        /// <summary>
        ///     初始化
        /// </summary>
        public void Init()
        {
            barManager2.Form = groupControl1;


         

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

                    btnAdd.Enabled = false;
                    btnRemove.Enabled = false;
                }
                Data.Details.Clear();
                Data.Details.AddRange(
                    ServiceBloker.GetService<ProductionPlanDetail>().FindAll(
                        c => c.ProductionPlanId == Data.ProductionPlanId, null));
                foreach (ProductionPlanDetail productionPlanDetail in Data.Details)
                {
                    ProductionPlanDetail detail = productionPlanDetail;
                }
                BindDetail();
            }
            else
            {
                Reset();
            }
        }

        /// <summary>
        ///     重置
        /// </summary>
        private void Reset()
        {
            Data = new ProductionPlan
                {
                    CreateTime = DateTimeHelper.Now,
                    CreaterId = CommonApi.CurrentUser().UserId,
                    Status = ProductionPlanStatus.Created,
                    DeliveryDate = DateTimeHelper.Min
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
        ///     添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAddItemClick(object sender, ItemClickEventArgs e)
        {
            dxErrorProvider1.ClearErrors();

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
        ///     输入条码
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
                                        });
            }
            BindDetail();
        }

        /// <summary>
        ///     绑定明显
        /// </summary>
        private void BindDetail()
        {
            gridControl1.DataSource = null;
            gridControl1.DataSource = Data.Details;
        }

        /// <summary>
        ///     删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnRemoveItemClick(object sender, ItemClickEventArgs e)
        {
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {

        }
    }
}