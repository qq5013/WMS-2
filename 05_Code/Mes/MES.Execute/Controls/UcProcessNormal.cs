/*----------------------------------------------------------------
// Copyright (C) 2010 有限公司
// 版权所有。 
//
// 文件名：         UcProcessNormal.cs
// 文件功能描述：   工位生产（普通）
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
using System.IO;
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
    ///     工位生产
    /// </summary>
    public partial class UcProcessNormal : UserControl, IInitControl
    {
        /// <summary>
        ///     OK状态时输入
        /// </summary>
        private const string Ok = "ok";

        /// <summary>
        ///     商品
        /// </summary>
        private Item _item;

        /// <summary>
        ///     工位生产
        /// </summary>
        public UcProcessNormal()
        {
            InitializeComponent();
        }

        /// <summary>
        ///     工序
        /// </summary>
        public Process Process { get; set; }

        /// <summary>
        ///     工位
        /// </summary>
        public ProductStation ProductStation { get; set; }

        /// <summary>
        ///     工步Servcie
        /// </summary>
        private static IEntityService<ProcessStep> ProcessStepService
        {
            get { return ServiceBloker.GetService<ProcessStep>(); }
        }

        /// <summary>
        ///     工步明细Servcie
        /// </summary>
        private static IEntityService<ProcessStepDetail> ProcessStepDetailService
        {
            get { return ServiceBloker.GetService<ProcessStepDetail>(); }
        }

        /// <summary>
        ///     产品Service
        /// </summary>
        private static IEntityService<Product> ProductService
        {
            get { return ServiceBloker.GetService<Product>(); }
        }

        /// <summary>
        ///     Sku信息查询
        /// </summary>
        private static IEntityQuery<SkuInfo> SkuInfoQuery
        {
            get { return ServiceBloker.GetQuery<SkuInfo>(); }
        }

        /// <summary>
        ///     产品工序Service
        /// </summary>
        private static IEntityService<ItemProcess> ItemProcessService
        {
            get { return ServiceBloker.GetService<ItemProcess>(); }
        }

        /// <summary>
        ///     产品工步Service
        /// </summary>
        private static IEntityService<ItemProcessStep> ItemProcessStepService
        {
            get { return ServiceBloker.GetService<ItemProcessStep>(); }
        }

        /// <summary>
        ///     产品工步明细
        /// </summary>
        private static IEntityService<ItemProcessStepDetail> ItemProcessStepDetailService
        {
            get { return ServiceBloker.GetService<ItemProcessStepDetail>(); }
        }

        /// <summary>
        ///     当前工步
        /// </summary>
        public ProcessStepInfo CurrentStep { get; set; }

        /// <summary>
        ///     当前工序
        /// </summary>
        protected ItemProcess ItemProcess { get; set; }

        /// <summary>
        ///     工步信息列表
        /// </summary>
        public List<ProcessStepInfo> Data { get; set; }

        /// <summary>
        ///     工序Service
        /// </summary>
        private static IEntityService<Process> ProcessService
        {
            get { return ServiceBloker.GetService<Process>(); }
        }

        /// <summary>
        ///     物流追踪Servcie
        /// </summary>
        private static IEntityService<MaterielTrace> MaterielTraceService
        {
            get { return ServiceBloker.GetService<MaterielTrace>(); }
        }

        #region IInitControl Members

        /// <summary>
        ///     初始化
        /// </summary>
        public void Init()
        {
            Product product = ProductService.GetById(Process.ProductId);
            lblProductName.Text = product.Name;
            lblProcessName.Text = string.Format("工序内容：{0}", Process.Name);
            lblProcessName.ForeColor = Color.Empty;
            if (Process.ImageData != null && Process.ImageData.Length > 0)
            {
                Stream s = new MemoryStream(Process.ImageData);
                pictureBox1.Image = new Bitmap(s);
            }

            lblInfo.Text = string.Format("{0}{1}  工序：{2}", Resources.Version, product.Version, Process.Code);
            btnPrintProduct.Visibility = BarItemVisibility.Never;
            Process process =
                ServiceBloker.GetService<Process>().Find(
                    c => c.Type == (int) ProcessType.Inspect && c.ProductId == Process.ProductId);
            if (process != null)
              
                {
                    btnPrintProduct.Visibility = BarItemVisibility.Always;
                }

            Rebind();
        }

        #endregion

        /// <summary>
        ///     重新绑定
        /// </summary>
        private void Rebind()
        {
         
            teProduct.Properties.ReadOnly = false;
            teProduct.SelectAll();
            teProduct.Focus();
            teOperator.Properties.ReadOnly = false;
            teOperator.Text = string.Empty;
            List<ProcessStep> processSteps = ProcessStepService.FindAll(c => c.ProcessId == Process.ProcessId);
            List<int> processStepIds = processSteps.Select(c => c.ProcessStepId).ToList();
            List<ProcessStepDetail> stepDetails = processStepIds.Count == 0
                                                      ? new List<ProcessStepDetail>()
                                                      : ProcessStepDetailService.FindAll(
                                                          c => processStepIds.Contains(c.ProcessStepId));
            List<int> stepDetailIds = stepDetails.Select(c => c.SkuId).ToList();

            List<SkuInfo> skuInfos = stepDetailIds.Count == 0
                                         ? new List<SkuInfo>()
                                         : SkuInfoQuery.FindAll(c => stepDetailIds.Contains(c.SkuId));

            Data = processSteps.Select(
                c =>
                    {
                        var info = new ProcessStepInfo
                            {
                                Notice = c.Notice,
                                Title = c.Name,
                                ProcessStepId = c.ProcessStepId
                            };
                        stepDetails.FindAll(t =>
                                            t.ProcessStepId == c.ProcessStepId).ForEach(
                                                obj =>
                                                    {
                                                        var detail =
                                                            new ProcessStepInfoDetail
                                                                {
                                                                    SkuInfo =
                                                                        skuInfos.Find(
                                                                            s =>
                                                                            s.SkuId == obj.SkuId
                                                                            )
                                                                };

                                                        if (obj.Quantity > 0)
                                                            detail.Quantity = obj.Quantity;
                                                        info.Details.Add(detail);
                                                    });

                        return info;
                    }).
                                ToList();

            gridControl1.DataSource = Data;
        }

        private void UcStation_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        ///     输入产品
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TeProductKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                try
                {
                    ProductCodeInput();
                }
                catch (Exception ex)
                {
                    CommonApi.Logger.Write(ex);
                }
            }
        }

        /// <summary>
        ///     产品代码输入
        /// </summary>
        private void ProductCodeInput()
        {
            string itemcode = teProduct.Text.Trim();

            _item = ItemService().Find(c => c.TraceCode == itemcode);
            if (_item == null)
            {
                teProduct.SelectAll();
                teProduct.Focus();
                ShowError("输入产品跟踪码错误");
                return;
            }
            //if (ServiceBloker.GetService<Sku>().GetById(_item.SkuId).ProductId != Process.ProductId)
            //{
            //    teProduct.SelectAll();
            //    teProduct.Focus();
            //    ShowError("输入产品跟踪码不是本工序生产的产品！");
            //    return;
            //}

            // 返工状态的item必须先完成返工
            if (_item.Status == ItemStatus.Rework)
            {
                teProduct.SelectAll();
                teProduct.Focus();
                ShowError("输入产品跟踪码错误，产品正在返工状态，必须完成返工后才能继续！");
                return;
            }

            // 报废的item 不能再继续生产
            if (_item.Status == ItemStatus.Waster)
            {
                teProduct.SelectAll();
                teProduct.Focus();
                ShowError("输入产品跟踪码错误，产品已作废！");
                return;
            }

            ItemProcess =
                ItemProcessService.Find(c => c.ProcessId == Process.ProcessId && c.ItemId == _item.ItemId);

            if (ItemProcess != null)
            {
                if (ItemProcess.Status == (int) ItemProcessStatus.Finished)
                {
                    teProduct.SelectAll();
                    teProduct.Focus();
                    ShowError("该产品已经完成当前工序！");
                    return;
                }
                //else if (ItemProcess.Status == (int)ItemProcessStatus.Rework)
                //{
                //    teProduct.SelectAll();
                //    teProduct.Focus();
                //    ShowError("该产品已经完成当前工序！");
                //    return;
                //}

                List<ItemProcessStep> itemProcessSteps =
                    ItemProcessStepService.FindAll(
                        c => c.ItemProcessId == ItemProcess.ItemProcessId);
                int index = 0;
                foreach (ItemProcessStep itemProcessStep in itemProcessSteps)
                {
                    ItemProcessStep step = itemProcessStep;
                    ProcessStepInfo processStepInfo = Data.Find(c => c.ProcessStepId == step.ProcessStepId);
                    if (processStepInfo != null)
                    {
                        processStepInfo.ProcessStep = itemProcessStep;
                        ItemProcessStep processStep = itemProcessStep;
                        List<ItemProcessStepDetail> details = ItemProcessStepDetailService.FindAll(
                            c =>
                            c.ItemProcessStepId == processStep.ItemProcessStepId &&
                            c.Status == ItemProcessStepDetailStatus.Normal);
                        itemProcessStep.Details.AddRange(details);
                        if (processStepInfo.RebindItem())
                        {
                            index++;
                        }
                    }
                }

                if (Data.Count - 1 > index)
                {
                    CurrentStep = Data[index];
                }
                else
                {
                    gridView1.ExpandMasterRow(Data.Count - 1);
                    if (Process.IsCheck && ItemProcess.Status == (int) ItemProcessStatus.Finished)
                    {
                        FinishProcess(teProduct.Text);
                        return;
                    }
                }
                gridView1.ExpandMasterRow(index);
            }
            else
            {
                int sequence = Process.Sequence;
                // 检查前置工序是否完成
                if (!CheckPreProcess(_item.ItemId, Process.ProductId, sequence))
                {
                    teProduct.SelectAll();
                    teProduct.Focus();
                    ShowError("前置工序尚未完成");
                    return;
                }

                // 将状态设为正在生产
                if (_item.Status == ItemStatus.Plan)
                {
                    _item.Status = ItemStatus.Init;
                    _item.Save();
                }
                ItemProcess = new ItemProcess
                    {
                        ProcessId = Process.ProcessId,
                        ProductStationId = (ProductStation ?? new ProductStation()).ProductStationId,
                        ItemId = _item.ItemId,
                        OperatorId = CommonApi.CurrentUser().UserId,
                        BegainTime = DateTimeHelper.Now,
                        EndTime = DateTimeHelper.Min,
                        Status = (int) ItemProcessStatus.Init
                    };

                int itemProcessId = ItemProcess.Save();
                if (ItemProcess.ItemProcessId == 0)
                {
                    ItemProcess.ItemProcessId = itemProcessId;
                }

                // 目前只支持工步必须按序完成。
                if (Process.IsStepByStep)
                {
                    CurrentStep = Data[0];
                    CurrentStep.SetStatus(ItemProcessStepStatus.Processing, ItemProcess.ItemProcessId);
                    gridView1.ExpandMasterRow(0);
                }
            }
            btnForceStop.Enabled = true;
            btnPrintProduct.Enabled = true;
            teProduct.Properties.ReadOnly = true;

            teOperator.Properties.ReadOnly = false;
            teOperator.Focus();
        }

        /// <summary>
        ///     商品Service
        /// </summary>
        /// <returns></returns>
        private IEntityService<Item> ItemService()
        {
            return ServiceBloker.GetService<Item>();
        }

        /// <summary>
        ///     检查前置工序是否完成
        /// </summary>
        /// <param name="itemId"></param>
        /// <param name="productId"></param>
        /// <param name="sequence"></param>
        /// <returns></returns>
        public static bool CheckPreProcess(int itemId, int productId, int sequence)
        {
            List<Process> processes =
                ProcessService.FindAll(
                    c => c.ProductId == productId && c.Sequence < sequence);

            if (processes.Count > 0)
            {
                if (processes.Count > 1)
                    processes.Sort((x, y) => y.Sequence - x.Sequence);
                // 找到当前工序的前置工序
                Process process = processes[0];
                // 判断前置工序是否完成
                if (process.Type == (int) ProcessType.Normal)
                {
                    // 前置工序是普通工序
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
                else if (process.Type == (int) ProcessType.Inspect)
                {
                    // 前置工序是质检工序

                    ItemInspect itemInspect =
                        ServiceBloker.GetService<ItemInspect>().Find(
                            c => c.ItemId == itemId);
                    if (itemInspect == null)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        ///     显示错误
        /// </summary>
        /// <param name="error"></param>
        private void ShowError(string error)
        {
            lblOperator.ForeColor = Color.Red;
            lblOperator.Text = error;
        }

        /// <summary>
        ///     显示Ok
        /// </summary>
        /// <param name="message"></param>
        private void ShowOK(string message)
        {
            lblOperator.ForeColor = Color.Blue;
            lblOperator.Text = message;
        }

        /// <summary>
        ///     操作属性
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TeOperatorPropertiesKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                try
                {
                    DoOperator();
                }
                catch (Exception ex)
                {
                    ShowError("扫描失败,请重试" + ex.Message);
                }
            }
        }

        /// <summary>
        ///     操作
        /// </summary>
        private void DoOperator()
        {
            string traceCode = teOperator.Text;
            //if (!Process.IsStepByStep) return;
            if (CurrentStep.Details.Count == 0)
            {
                // 当前工步没明细的情况下
                if (string.Compare(Ok, traceCode, StringComparison.CurrentCultureIgnoreCase) == 0)
                {
                    int indexOf = Data.IndexOf(CurrentStep);

                    CurrentStep.SetStatus(ItemProcessStepStatus.Processed, ItemProcess.ItemProcessId);
                    indexOf++;
                    // 工步都完成结束工序
                    if (indexOf >= Data.Count)
                    {
                        FinishProcess(teProduct.Text);
                        return;
                    }

                    CurrentStep = Data[indexOf];
                    lblNotice.Text = CurrentStep.Notice;
                    lblContent.Text = CurrentStep.Title;
                    teOperator.Text = string.Empty;
                    gridView1.CollapseAllDetails();
                    gridView1.GridControl.Refresh();
                    gridView1.ExpandMasterRow(indexOf);

                    CurrentStep.SetStatus(ItemProcessStepStatus.Processing, ItemProcess.ItemProcessId);
                }
            }
            else
            {
                if (string.Compare(Ok, traceCode, StringComparison.CurrentCultureIgnoreCase) == 0)
                {
                    // 输入ok的处理
                    if (CurrentStep.Details.Exists(c => c.IsProcessed == false && c.TraceType != TraceType.None))
                    {
                        ShowError("还有未扫描的物料");
                        teOperator.SelectAll();
                        return;
                    }
                    List<ProcessStepInfoDetail> list = CurrentStep.Details.FindAll(c => c.IsProcessed == false);
                    int indexOf = Data.IndexOf(CurrentStep);
                    foreach (ProcessStepInfoDetail detail in list)
                    {
                        detail.IsProcessed = true;
                    }
                    CurrentStep.SetStatus(ItemProcessStepStatus.Processed, ItemProcess.ItemProcessId);
                    indexOf++;
                    // 工步都完成结束工序
                    if (indexOf >= Data.Count)
                    {
                        FinishProcess(teProduct.Text);
                        return;
                    }

                    CurrentStep = Data[indexOf];
                    lblNotice.Text = CurrentStep.Notice;
                    lblContent.Text = CurrentStep.Title;
                    CurrentStep.SetStatus(ItemProcessStepStatus.Processing, ItemProcess.ItemProcessId);
                    teOperator.Text = string.Empty;
                    gridView1.CollapseAllDetails();
                    gridView1.GridControl.Refresh();
                    gridView1.ExpandMasterRow(indexOf);
                    return;
                }
                if (traceCode.Length > 9)
                {
                    // 输入物料条码处理
                    MaterielTrace materielTrace =
                        MaterielTraceService.Find(c => c.TraceCode == traceCode);
                    if (materielTrace == null)
                    {
                        ShowError("物料条码不在生产车间");
                        teOperator.SelectAll();
                        return;
                    }
                    if (materielTrace.Quantity == 1)
                    {
                        materielTrace.Remove();
                    }
                    else
                    {
                        materielTrace.Quantity -= 1;
                        materielTrace.Save();
                    }

                    string code = traceCode.Substring(4, 5);

                    ProcessStepInfoDetail detail = CurrentStep.Details.Find(c => c.Code == code);
                    int indexOf = Data.IndexOf(CurrentStep);
                    if (detail != null)
                    {
                        detail.DoneQuantity += 1;
                        ItemProcessStepDetailService.Save(new ItemProcessStepDetail
                            {
                                CreateTime =
                                    DateTimeHelper.Now,
                                ItemProcessStepId =
                                    CurrentStep.
                                                              ProcessStep.
                                                              ItemProcessStepId,
                                SkuId = detail.SkuId,
                                TraceType =
                                    detail.TraceType,
                                TraceCode = traceCode,
                                Status =
                                    ItemProcessStepDetailStatus
                                                              .Normal
                            });
                        ShowOK("扫描物料:" + detail.Name + "(" + detail.Code + ")");

                        if (detail.Quantity == null || detail.Quantity == 1 ||
                            detail.DoneQuantity == detail.Quantity)
                        {
                            detail.IsProcessed = true;
                            if (!CurrentStep.Details.Exists(c => c.IsProcessed == false))
                            {
                                CurrentStep.SetStatus(ItemProcessStepStatus.Processed, ItemProcess.ItemProcessId);
                                indexOf++;
                                // 工步都完成结束工序
                                if (indexOf >= Data.Count)
                                {
                                    FinishProcess(teProduct.Text);
                                    return;
                                }

                                CurrentStep = Data[indexOf];
                                lblNotice.Text = CurrentStep.Notice;
                                lblContent.Text = CurrentStep.Title;
                                CurrentStep.SetStatus(ItemProcessStepStatus.Processing,
                                                      ItemProcess.ItemProcessId);
                            }
                        }


                        teOperator.Text = string.Empty;
                        gridView1.CollapseAllDetails();
                        gridView1.GridControl.Refresh();
                        gridView1.ExpandMasterRow(indexOf);
                        return;
                    }
                }
                ShowError("物料条码扫描错误");
                teOperator.SelectAll();
            }
        }

        /// <summary>
        ///     完成工序
        /// </summary>
        /// <param name="productCode"></param>
        private void FinishProcess(string productCode)
        {
            // 如果设置工序完工后需要检验
            if (Process.IsCheck)
            {
                ItemProcess.Status = (int) ItemProcessStatus.WaitInspect;
                ItemProcess.Save();
                // 弹出检验对话框
                //DialogResult result = new Form
                //                                {
                //                                    Controls = { new UcProcessendCheck { ItemProcess = ItemProcess } },
                //                                    Size = new Size(420, 170),
                //                                    Text = "现场检验",
                //                                }.Dialog();
                //if (result != DialogResult.OK)
                //{
                //    teProduct.Properties.ReadOnly = false;
                //    teProduct.Text = string.Empty;
                //    teOperator.Text = string.Empty;
                //    teProduct.Focus();

                //    ShowOK(productCode + "检验不通过需要返工");
                //    lblContent.Text = string.Empty;
                //    lblNotice.Text = string.Empty;
                //    ItemProcess.Status = (int)ItemProcessStatus.Rework;
                //    ItemProcess.Save();
                //    Rebind();
                //    return;
                //}
            }

            teProduct.Properties.ReadOnly = false;
            teProduct.Text = string.Empty;
            teOperator.Text = string.Empty;
            teProduct.Focus();

            ShowOK(productCode + "工序完成");
            lblContent.Text = string.Empty;
            lblNotice.Text = string.Empty;
            ItemProcess.Status = (int) ItemProcessStatus.Finished;
            ItemProcess.Save();


            List<Process> processes =
                ProcessService.FindAll(
                    c => c.ProductId == ItemProcess.ProcessId);

            if (processes.Count > 0)
            {
                if (processes.Count > 1)
                    processes.Sort((x, y) => y.Sequence - x.Sequence);
            }
            // 保存
            int findIndex = processes.FindIndex(c => c.ProcessId == ItemProcess.ProcessId);
            if (findIndex >= processes.Count - 1)
            {
                _item.Status = ItemStatus.FinishedProduct;
                _item.Save();
            }
            else if (processes[findIndex + 1].Type == (int) ProcessType.Inspect)
            {
                _item.Status = ItemStatus.SemiManufactures;
                _item.Save();
            }

            Rebind();
        }

        /// <summary>
        ///     显示提示
        /// </summary>
        /// <param name="notice"></param>
        private void ShowNotice(string notice)
        {
            lblContent.Text = notice;
            lblNotice.Text = string.Empty;
        }

        /// <summary>
        ///     打印产品
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnPrintProductItemClick(object sender, ItemClickEventArgs e)
        {
            //var productCode = new ProductCode();
            //if (string.IsNullOrEmpty(_item.Barcode))
            //{
            //    DateTime now = DateTimeHelper.Now;
            //    ProductLine productLine = ServiceBloker.GetService<ProductLine>().GetById(ProductStation.ProductLineId);
            //    ItemInspect itemInspect = ServiceBloker.GetService<ItemInspect>().Find(c => c.ItemId == _item.ItemId);
            //    Sku sku = ServiceBloker.GetService<Sku>().GetById(_item.SkuId);
            //    string product = ServiceBloker.GetService<Product>().GetById(
            //        sku.ProductId).Code;
            //    Software software = ServiceBloker.GetService<Software>().GetById(itemInspect.SoftwareId);
            //    string softwareCode = software != null ? software.Code : "00000";
            //    if (string.IsNullOrEmpty(softwareCode) || softwareCode.Length < 5)
            //    {
            //        softwareCode = "00000";
            //    }
            //    // 生成产品条码
            //    string data = productLine.Code + now.ToString("yy") + now.DayOfYear.ToString("000") +
            //                  product +
            //                  softwareCode;

            //    IEntityService<ItemSequence> service = ServiceBloker.GetService<ItemSequence>();
            //    ItemSequence itemSequence = service.Find(c => c.Code == product) ??
            //                                new ItemSequence {Code = product, Step = 1};
            //    int currentNumber = itemSequence.CurrentNumber;
            //    itemSequence.CurrentNumber = currentNumber + itemSequence.Step;
            //    service.Save(itemSequence);

            //    _item.Barcode = (currentNumber + itemSequence.Step).ToString("0000000") + data;
            //    _item.Save();
            //}
            //productCode.AppendData('\"' + _item.Barcode + "\",\"Name\"");
            //// 打印
            //productCode.Print();
        }

        /// <summary>
        ///     重置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnForceStopItemClick(object sender, ItemClickEventArgs e)
        {
            Rebind();
        }
    }
}