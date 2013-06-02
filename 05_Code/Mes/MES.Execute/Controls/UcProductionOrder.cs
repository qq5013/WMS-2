/*----------------------------------------------------------------
// Copyright (C) 2010 有限公司
// 版权所有。 
//
// 文件名：         UcProductionOrder.cs
// 文件功能描述：   生产工单(开线停线管理)
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
using System.Windows.Forms;
using DevExpress.XtraBars;
using Frame.Utils.Service;
using MES.BllService;
using MES.Common;
using MES.Entity;
using MES.Execute.Properties;

namespace MES.Execute.Controls
{
    /// <summary>
    ///     生产工单(开线停线管理)
    /// </summary>
    public partial class UcProductionOrder : UserControl, IInitControl, ICheckClosing
    {
        private List<EntitySetting<ProductionOrderDetail>> _detailSettings;

        private List<EntitySetting<ProductionOrder>> _settings;

        public UcProductionOrder()
        {
            InitializeComponent();
        }

        /// <summary>
        ///     生产工单
        /// </summary>
        public ProductionOrder Data { get; set; }

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
            // 生产工单必须要有对应的生产计划
            if (!string.IsNullOrEmpty(beProductionPlanCode.Text))
            {
                ProductionPlan productionPlan =
                    ServiceBloker.GetService<ProductionPlan>().Find(c => c.Code == beProductionPlanCode.Text);
                if (null == productionPlan)
                {
                    dxErrorProvider1.SetError(beProductionPlanCode, "生产计划单不存在");
                    return false;
                }
            }

            Data.LoadData(Controls);
            int productionOrderId = ServiceBloker.GetService<ProductionOrder>().Save(Data);
            if (Data.ProductionOrderId == 0)
            {
                Data.ProductionOrderId = productionOrderId;
            }
            // 删除已经删除的明细
            foreach (ProductionOrderDetail detail in Data.RemoveList)
            {
                if (detail.GetEntityId() > 0)
                    detail.Remove();
            }
            Data.RemoveList.Clear();

            // 保存明细
            foreach (ProductionOrderDetail detail in Data.Details)
            {
                detail.ProductionOrderId = Data.ProductionOrderId;
                ServiceBloker.GetService<ProductionOrderDetail>().Save(detail);
            }
            return true;
        }

        #endregion

        #region IInitControl Members

        /// <summary>
        ///     初始化
        /// </summary>
        public void Init()
        {
            barManager2.Form = groupControl1;
            // Master


            _settings = new List<EntitySetting<ProductionOrder>>()
                .Setting(c => c.OrderType, new EntitySetting
                    {
                        Name = "工单类型",
                        Control = lookUpEdit1.BindOrderType()
                    })
                .Setting(c => c.OrderDate, new EntitySetting
                    {
                        Name = "订购日期",
                        Control = deProductionDate.BindDate()
                    })
                .Setting(c => c.DeliveryDate, new EntitySetting
                    {
                        Name = "交货日期",
                        Control = dateEdit1.BindDate()
                    })
                .Setting(c => c.CreaterId, new EntitySetting
                    {
                        Name = "制单人",
                        Control = lookUpEdit1.BindUser()
                    })
                .Setting(c => c.CreateTime, new EntitySetting
                    {
                        Name = "制单日期",
                        Control = deCreateTime
                    })
                .Setting(c => c.Remark, new EntitySetting
                    {
                        Name = "备注",
                        Control = meRemark
                    });

            _detailSettings = new List<EntitySetting<ProductionOrderDetail>>();


            _detailSettings
                .Setting(c => c.ProductId, new EntitySetting
                    {
                        Name = "产品名称",
                        Width = 100,
                        Control = null
                    })
                .Setting(c => c.Quantity, new EntitySetting
                    {
                        Name = "生产数量",
                        Width = 100,
                        Control = null
                    })
                .Setting(c => c.MeasureId, new EntitySetting
                    {
                        Name = "单位",
                        Width = 100,
                        Control = null,
                    })
                .Setting(c => c.FinishDate, new EntitySetting
                    {
                        Name = "完工日期",
                        Width = 100,
                        Control = null
                    })
                .Setting(c => c.Remark, new EntitySetting
                    {
                        Name = "备注",
                        Width = 100,
                        Control = null
                    });

            _detailSettings.SetGridColumn(gridView2);
        }

        #endregion

        /// <summary>
        ///     绑定明细
        /// </summary>
        private void BindDetail()
        {
            gridControl1.DataSource = null;
            gridControl1.DataSource = Data.Details;
        }

        private void UcProductionOrder_Load(object sender, EventArgs e)
        {
        }


        /// <summary>
        ///     添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAddItemClick(object sender, ItemClickEventArgs e)
        {
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
        ///     扫描条码
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
            ProductionOrderDetail productionOrderDetail = Data.Details.Find(c => c.SkuId == skuinfo.SkuId);

            // 如果有明细记录则增加数量
            if (productionOrderDetail != null)
            {
                productionOrderDetail.Quantity += quantity;
            }
            else
            {
                // 如果没有明细记录则增加明细记录
                Data.Details.Insert(0,
                                    new ProductionOrderDetail
                                        {
                                            SkuId = skuinfo.SkuId,
                                            Quantity = quantity,
                                            MeasureId = measureid
                                        });
            }
            BindDetail();
        }

        /// <summary>
        ///     删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnRemoveItemClick(object sender, ItemClickEventArgs e)
        {
            //int[] selectedRows = bandedGridView1.GetSelectedRows();
            //if (selectedRows != null && selectedRows.Length > 0)
            //{
            //    List<ProductionOrderDetail> list =
            //        selectedRows.Select(selectedRow => bandedGridView1.GetRow(selectedRow) as ProductionOrderDetail).
            //                     ToList();
            //    foreach (ProductionOrderDetail detail in list)
            //    {
            //        Data.RemoveList.Add(detail);
            //        Data.Details.Remove(detail);
            //    }

            //    BindDetail();
            //}
        }

        private void BtnStartItemClick(object sender, ItemClickEventArgs e)
        {
        }

        private void BeProductionPlanCodeKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                ProductionOrder productionOrder =
                    ServiceBloker.GetService<ProductionOrder>().Find(c => c.Code == beProductionPlanCode.Text.Trim());
                if (productionOrder != null)
                {
                    _settings.DataFromEntity(productionOrder);
                    //  MessageBox.Show("Find");
                }
            }
        }
    }
}