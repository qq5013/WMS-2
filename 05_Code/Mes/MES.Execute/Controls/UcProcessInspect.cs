/*----------------------------------------------------------------
// Copyright (C) 2010 有限公司
// 版权所有。 
//
// 文件名：         UcProcessInspect.cs
// 文件功能描述：   检验工序
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
    /// 检验工序
    /// </summary>
    public partial class UcProcessInspect : UserControl, IInitControl
    {
        /// <summary>
        /// 检验日志
        /// </summary>
        private readonly List<InspectLog> _inspectLogs = new List<InspectLog>();
     
        /// <summary>
        /// 显示错误
        /// </summary>
        public ShowError ShowError = CommonApi.ShowError;
        /// <summary>
        /// 商品
        /// </summary>
        private Item _item;
        /// <summary>
        /// 检验工序
        /// </summary>
        public UcProcessInspect()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 工序
        /// </summary>
        public Process Process { get; set; }

        /// <summary>
        /// 数据
        /// </summary>
        public ItemInspect Data { get; set; }
        /// <summary>
        /// 商品工序Service
        /// </summary>
        private static IEntityService<ItemProcess> ItemProcessService
        {
            get { return ServiceBloker.GetService<ItemProcess>(); }
        }
        /// <summary>
        /// 工序Service
        /// </summary>
        private static IEntityService<Process> ProcessService
        {
            get { return ServiceBloker.GetService<Process>(); }
        }

        #region IInitControl Members
        /// <summary>
        /// 初始化
        /// </summary>
        public void Init()
        {
            glueConfirmer.BindUser(ControlMode.Edit);
            glueCustomer.BindCustomer(ControlMode.Edit);
            glueDebugMember.BindUser(ControlMode.Edit);
            glueSoftware.BindSoftware(ControlMode.Edit);
            gridView1.ExpandAllGroups();
        }

        #endregion
        /// <summary>
        /// 加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UcInspect_Load(object sender, EventArgs e)
        {
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSaveItemClick(object sender, ItemClickEventArgs e)
        {
            if (Data == null)
            {
                MessageBox.Show(Resources.PlsInputProductTraceCode);
                return;
            }
            if (Save())
            {
                MessageBox.Show(Resources.SaveSuccess);
            }
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <returns></returns>
        private bool Save()
        {
            gridControl1.MainView.PostEditor();
            Data.LoadData(Controls);
            Data.ProcessId = Process.ProcessId;
            int itemInspectId = ServiceBloker.GetService<ItemInspect>().Save(Data);
            if (Data.ItemInspectId <= 0)
                Data.ItemInspectId = itemInspectId;

            foreach (InspectLog inspectLog in _inspectLogs)
            {
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
                ServiceBloker.GetService<ItemInspectDetail>().Save(new ItemInspectDetail
                                                                       {
                                                                           Data = inspectLog.Data,
                                                                           Remark = inspectLog.Remark,
                                                                           Result = inspectLog.Result,
                                                                           ItemInspectId = Data.ItemInspectId,
                                                                           ProductInspectId = inspectLog.InspectId,
                                                                       });
            }
            return true;
        }
        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="item"></param>
        /// <param name="itemInspect"></param>
        /// <param name="productLineId"></param>
        public static void BtnPrintItemClick(Item item, ItemInspect itemInspect, int productLineId)
        {
        }

        /// <summary>
        /// 输入追踪码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TeTraceCodeKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
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
                        btnFinish.Caption = Resources.Finish;
                    }
                    else
                    {
                        btnSave.Enabled = true;
                        btnFinish.Caption = Resources.FinishJob;
                    }
                }
                else
                {
                    btnSave.Enabled = true;
                    btnFinish.Caption = Resources.FinishJob;
                    glueDebugMember.EditValue = CommonApi.CurrentUser().UserId;
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

                teSkuCode.Text = skuInfo.Code;
                teSkuName.Text = skuInfo.Name;
                List<ItemInspectDetail> itemInspectDetails =
                    ServiceBloker.GetService<ItemInspectDetail>().FindAll(c => c.ItemInspectId == Data.ItemInspectId,
                                                                          null);

                _inspectLogs.AddRange(ServiceBloker.GetService<ProductInspect>().FindAll(c => c.ProcessId == 0, null).
                                          Select(
                                              c =>
                                              InspectLog(c, itemInspectDetails)
                                          ).ToList());
                BindDetail();
                gridView1.ExpandAllGroups();
            }
        }
        /// <summary>
        /// 绑定明细
        /// </summary>
        private void BindDetail()
        {
            gridControl1.DataSource = null;
            gridControl1.DataSource = _inspectLogs;
        }
        /// <summary>
        /// 日志
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

            // 设置明细内容
            if (itemInspectDetail != null)
            {
                inspectLog.Data = itemInspectDetail.Data;
                inspectLog.Remark = itemInspectDetail.Remark;
                inspectLog.Result = itemInspectDetail.Result;
            }
            return inspectLog;
        }

        /// <summary>
        /// 结束
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnFinishItemClick(object sender, ItemClickEventArgs e)
        {
            if (Data == null)
            {
                MessageBox.Show(Resources.PlsInputProductTraceCode);
                return;
            }
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
        /// 打印结果
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnPrintResultItemClick(object sender, ItemClickEventArgs e)
        {
           // Data.GetReport().Print();
        }
        /// <summary>
        /// 检验前置工序
        /// </summary>
        /// <param name="itemId"></param>
        /// <param name="productId"></param>
        /// <param name="sequence"></param>
        /// <returns></returns>
        public static bool CheckPreProcess(int itemId, int productId, int sequence)
        {
            List<Process> processes =
                ProcessService.FindAll(
                    c => c.ProductId == productId && c.Sequence < sequence, null);

            if (processes.Count > 0)
            {
                if (processes.Count > 1)
                    processes.Sort((x, y) => y.Sequence - x.Sequence);
                Process process = processes[0];
                if (process.Type == (int) ProcessType.Normal)//检查质检工序的前置工序是否已经完成
                {
                    int processId = process.ProcessId;

                    ItemProcess itemProcess =
                        ItemProcessService.Find(
                            c => c.ItemId == itemId && c.ProcessId == processId);
                    if (itemProcess == null
                        || itemProcess.Status != (int) ItemProcessStatus.Finished)
                    {
                        return false;
                    }
                }
                else if (process.Type == (int) ProcessType.Inspect)// 如果质检已经完成
                {
                    int processId = process.ProcessId;

                    ItemInspect itemInspect =
                        ServiceBloker.GetService<ItemInspect>().Find(
                            c => c.ItemId == itemId && c.ProcessId == processId);
                    if (itemInspect == null)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}