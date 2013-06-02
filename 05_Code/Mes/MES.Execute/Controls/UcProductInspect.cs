/*----------------------------------------------------------------
// Copyright (C) 2010 有限公司
// 版权所有。 
//
// 文件名：         UcProductInspect.cs
// 文件功能描述：   产品检验
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
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraBars;
using Frame.Utils.Service;
using MES.BllService;
using MES.Common;
using MES.Entity;
using MES.Enum;
using MES.Execute.Properties;

namespace MES.Execute.Controls
{
    /// <summary>
    ///     产品检验
    /// </summary>
    public partial class UcProductInspect : UserControl, IInitControl
    {
        /// <summary>
        ///     检验日志
        /// </summary>
        private readonly List<InspectLog> _inspectLogs = new List<InspectLog>();

        private readonly List<EntitySetting<ItemInspect>> _settings = new List<EntitySetting<ItemInspect>>();

        /// <summary>
        ///     显示错误
        /// </summary>
        public ShowError ShowError = CommonApi.ShowError;

        /// <summary>
        ///     商品
        /// </summary>
        private Item _item;

        public UcProductInspect()
        {
            InitializeComponent();
        }

        /// <summary>
        ///     工序
        /// </summary>
        public Process Process { get; set; }

        /// <summary>
        ///     商品检验
        /// </summary>
        public ItemInspect Data { get; set; }

        /// <summary>
        ///     初始化
        /// </summary>
        public void Init()
        {
            _settings
                .Setting(c => c.TraceCode, new EntitySetting
                    {
                        Control = teTraceCode
                    })
                .Setting(c => c.Code, new EntitySetting
                    {
                        Control = teCode
                    })
                .Setting(c => c.UseWay, new EntitySetting
                    {
                        Control = teUseWay
                    })
                .Setting(c => c.Standard, new EntitySetting
                    {
                        Control = teStandard
                    })
                .Setting(c => c.SpecModel, new EntitySetting
                    {
                        Control = teSpecModel
                    })
                .Setting(c => c.MachineNo, new EntitySetting
                    {
                        Control = teMachineNo
                    })
                .Setting(c => c.Remark, new EntitySetting
                    {
                        Control = meRemark
                    });
        }

        private void UcInspect_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        ///     保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSaveItemClick(object sender, ItemClickEventArgs e)
        {
            if (Save())
            {
                MessageBox.Show(Resources.SaveSuccess);
            }
        }

        /// <summary>
        ///     保存
        /// </summary>
        /// <returns></returns>
        private bool Save()
        {
            gridControl1.MainView.PostEditor();
            Data.LoadData(Controls);
            int itemInspectId = ServiceBloker.GetService<ItemInspect>().Save(Data);
            if (Data.ItemInspectId <= 0)
                Data.ItemInspectId = itemInspectId;

            // 保存明细

            var itemProcess = new ItemProcess
                {
                    OperatorId = CommonApi.CurrentUser().UserId,
                    BegainTime = DateTimeHelper.Now,
                    EndTime = DateTimeHelper.Min,
                    Status = (int) ItemProcessStatus.Finished,
                    ItemId = _item.ItemId,
                    ProcessId = Process.ProcessId
                };

            ServiceBloker.GetService<ItemProcess>().Save(itemProcess);


            return true;
        }

        /// <summary>
        ///     打印
        /// </summary>
        /// <param name="item"></param>
        /// <param name="itemInspect"></param>
        /// <param name="productLineId"></param>
        public static void BtnPrintItemClick(Item item, ItemInspect itemInspect, int productLineId)
        {
        }

        /// <summary>
        ///     输入追踪码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TeTraceCodeKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\r') return;
            _item = ServiceBloker.GetService<Item>().Find(c => c.TraceCode == teTraceCode.Text);
            if (_item == null)
            {
                ShowError("追踪码未找到");
                return;
            }


            Data = ServiceBloker.GetService<ItemInspect>().Find(c => c.ItemId == _item.ItemId);
            if (Data != null)
            {
                Data.FillData(Controls);
                if (Data.Complated)
                {
                    btnSave.Enabled = false;
                    btnFinish.Caption = "结束";
                }
                else
                {
                    btnSave.Enabled = true;
                    btnFinish.Caption = "完工";
                }
            }
            else
            {
                btnSave.Enabled = true;
                btnFinish.Caption = "完工";
                Data = new ItemInspect
                    {
                        FinishTime = DateTimeHelper.Now,
                        ItemId = _item.ItemId,
                        Code = CommonApi.GetCode<ItemInspect>()
                    };
            }
            SkuInfo skuInfo = ServiceBloker.GetQuery<SkuInfo>().Find(t => t.SkuId == _item.SkuId);

            Product product = ServiceBloker.GetService<Product>().GetById(skuInfo.ProductId);
            Process = ServiceBloker.GetService<Process>().Find(
                c => c.ProductId == product.ProductId && c.Type == (int) ProcessType.Inspect);

            if (Process == null)
            {
                ShowError("该产品没有检测工序");
                return;
            }


            List<ItemInspectDetail> itemInspectDetails =
                ServiceBloker.GetService<ItemInspectDetail>().FindAll(c => c.ItemInspectId == Data.ItemInspectId,
                                                                      null);

            _inspectLogs.AddRange(ServiceBloker.GetService<ProductInspect>().FindAll(c => c.ProcessId == 0, null).
                                                Select(
                                                    c =>
                                                    InspectLog(c, itemInspectDetails)
                                      ).ToList());
            BindDetail();
        }

        /// <summary>
        ///     绑定明细
        /// </summary>
        private void BindDetail()
        {
            gridControl1.DataSource = null;
            gridControl1.DataSource = _inspectLogs;
        }

        /// <summary>
        ///     检验日志
        /// </summary>
        /// <param name="productInspect"></param>
        /// <param name="itemInspectDetails"></param>
        /// <returns></returns>
        private static InspectLog InspectLog(ProductInspect productInspect, List<ItemInspectDetail> itemInspectDetails)
        {
            var inspectLog = new InspectLog
                {
                    InspectId = productInspect.ProductInspectId,
                    Name = productInspect.Name,
                    Content = productInspect.Content,
                    Status = (productInspect.Type == ProductInspectType.Init) ? "初始状态" : "工作状态",
                    NormalData = productInspect.MinData + "~" + productInspect.MaxData
                };
            ItemInspectDetail itemInspectDetail =
                itemInspectDetails.Find(d => d.ProductInspectId == productInspect.ProductInspectId);
            if (itemInspectDetail != null)
            {
                inspectLog.Data = itemInspectDetail.Data;
                inspectLog.Remark = itemInspectDetail.Remark;
                inspectLog.Result = itemInspectDetail.Result;
            }
            return inspectLog;
        }

        /// <summary>
        ///     完成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnFinishItemClick(object sender, ItemClickEventArgs e)
        {
            if (!Data.Complated)
            {
                Data.Complated = true;
                if (!Save()) return;
            }

            Controls.ClearData();
            _inspectLogs.Clear();
            BindDetail();
        }

        /// <summary>
        ///     打印结果
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnPrintResultItemClick(object sender, ItemClickEventArgs e)
        {
            // Data.GetReport().Print();
        }
    }
}