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

namespace MES.Execute.Controls
{
    /// <summary>
    /// 返工
    /// </summary>
    public partial class UcRework : UserControl, IInitControl
    {
        /// <summary>
        /// 物料追踪信息
        /// </summary>
        private readonly List<MaterielTraceInfo> _materielTraceInfos = new List<MaterielTraceInfo>();

        /// <summary>
        /// 商品
        /// </summary>
        private Item _item;

        /// <summary>
        /// 物料追踪
        /// </summary>
        private MaterielTrace _materielTrace;

        /// <summary>
        /// 返工
        /// </summary>
        public UcRework()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 物料追踪服务
        /// </summary>
        private IEntityService<MaterielTrace> MaterielTraceService
        {
            get { return ServiceBloker.GetService<MaterielTrace>(); }
        }

        /// <summary>
        /// Sku信息查询
        /// </summary>
        private IEntityQuery<SkuInfo> SkuInfoQuery
        {
            get { return ServiceBloker.GetQuery<SkuInfo>(); }
        }

        /// <summary>
        /// 商品工序Service
        /// </summary>
        private IEntityService<ItemProcess> ItemProcessService
        {
            get { return ServiceBloker.GetService<ItemProcess>(); }
        }

        /// <summary>
        /// 商品工步明细Service
        /// </summary>
        private IEntityService<ItemProcessStepDetail> ItemProcessStepDetailService
        {
            get { return ServiceBloker.GetService<ItemProcessStepDetail>(); }
        }

        /// <summary>
        /// 商品工步Service
        /// </summary>
        private IEntityService<ItemProcessStep> ItemProcessStepService
        {
            get { return ServiceBloker.GetService<ItemProcessStep>(); }
        }

        /// <summary>
        /// 返工Service
        /// </summary>
        private IEntityService<Rework> ReworkService
        {
            get { return ServiceBloker.GetService<Rework>(); }
        }

        #region IInitControl Members
        /// <summary>
        /// 初始化
        /// </summary>
        public void Init()
        {
        }

        #endregion
        /// <summary>
        /// 输入追踪码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TeProductTraceCodeKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\r') return;

            string traceCode = teProductTraceCode.Text.Trim();

            _item = ServiceBloker.GetService<Item>().Find(c => c.TraceCode == traceCode);

            if (_item != null)
            {
                bool isNew = false;
                if (_item.Status != ItemStatus.Rework)
                {
                    isNew = true;
                    // 设为返工状态，直到返工结束
                    _item.Status = ItemStatus.Rework;
                    _item.Save();

                    ReworkService.Save(new Rework
                                           {
                                               ActualOperateTime = DateTimeHelper.Now,
                                               ActualOperator = CommonApi.CurrentUser().UserId,
                                               CreateTime = DateTimeHelper.Now,
                                               Creater = CommonApi.CurrentUser().UserId,
                                               OperatorModel = 1,
                                               PlanOperateTime = DateTimeHelper.Now,
                                               PlanOperator = CommonApi.CurrentUser().UserId,
                                               ProductProcedureId = _item.ItemId
                                           });
                }

                teProductTraceCode.Properties.ReadOnly = true;
                teSkuBarcode.Properties.ReadOnly = false;
                teSkuBarcode.Focus();

                List<ItemProcess> itemProcesses = ItemProcessService.FindAll(c => c.ItemId == _item.ItemId, null);
                List<int> itemProcessIds =
                    itemProcesses.Select(
                        c => c.ItemProcessId).ToList();

                // 加载以完成的工序工步
                if (itemProcessIds.Count > 0)
                {
                    List<ItemProcessStep> itemProcessSteps =
                        ItemProcessStepService.FindAll(c => itemProcessIds.Contains(c.ItemProcessId),
                                                       null);
                    List<int> itemProcessStepIds =
                        itemProcessSteps.Select(c => c.ItemProcessStepId).
                            ToList();

                    List<ItemProcessStepDetail> details;
                    if (isNew)
                        details = ItemProcessStepDetailService.FindAll(
                            c => itemProcessStepIds.Contains(c.ItemProcessStepId), null);
                    else
                    {
                        details = ItemProcessStepDetailService.FindAll(
                            c =>
                            itemProcessStepIds.Contains(c.ItemProcessStepId) &&
                            c.Status == ItemProcessStepDetailStatus.Normal,
                            null);
                    }
                    foreach (ItemProcessStepDetail itemProcessStep in details)
                    {
                        ItemProcessStepDetail step = itemProcessStep;

                        MaterielTraceInfo materielTrace = _materielTraceInfos.Find(c => c.TraceCode == step.TraceCode);
                        if (materielTrace == null)
                        {
                            materielTrace = new MaterielTraceInfo
                                                {
                                                    TraceCode = step.TraceCode,
                                                    SkuInfo =
                                                        SkuInfoQuery.Find(
                                                            t => t.SkuId == step.SkuId)
                                                };

                            _materielTraceInfos.Add(materielTrace);
                        }
                        materielTrace.Details.Add(step);
                        materielTrace.Quantity += 1;
                    }
                }

                BindDetail();
            }
        }
        /// <summary>
        /// 绑定明细
        /// </summary>
        private void BindDetail()
        {
            gridControl1.DataSource = null;
            gridControl1.DataSource = _materielTraceInfos;
        }
        /// <summary>
        /// 输入报废的Sku条码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TeSkuBarcodeKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                string traceCode = teSkuBarcode.Text.Trim();

                _materielTrace = _materielTraceInfos.Find(c => c.TraceCode == traceCode);

                if (_materielTrace != null)
                {
                    teSkuBarcode.Properties.ReadOnly = true;
                    teNewSkuBarcode.Focus();
                    teNewSkuBarcode.Properties.ReadOnly = false;
                }
            }
        }
        /// <summary>
        /// 输入新的Sku条码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TeNewSkuBarcodeKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                MaterielTraceInfo info = _materielTraceInfos.Find(c => c.TraceCode == teSkuBarcode.Text.Trim());

                // 替换返工中用掉的物料
                if (info != null)
                {
                    ItemProcessStepDetail oldDetail = info.Details[0];
                    info.Details.Remove(oldDetail);
                    var newDetail = new ItemProcessStepDetail
                                        {
                                            CreateTime = DateTime.Now,
                                            ItemProcessStepId = oldDetail.ItemProcessStepId,
                                            SkuId = oldDetail.SkuId,
                                            TraceCode = _materielTrace.TraceCode,
                                            TraceType = oldDetail.TraceType
                                        };

                    oldDetail.Status = ItemProcessStepDetailStatus.Invalid;
                    oldDetail.Save();

                    int itemProcessStepDetailId = ItemProcessStepDetailService.Save(newDetail);
                    if (newDetail.ItemProcessStepDetailId == 0)
                        newDetail.ItemProcessStepDetailId = itemProcessStepDetailId;
                    info.Details.Insert(0, newDetail);

                    _materielTrace.Quantity -= 1;
                    if (_materielTrace.Quantity == 0)
                    {
                        info.TraceCode = teNewSkuBarcode.Text;
                        MaterielTraceService.Delete(_materielTrace.GetEntityId());
                    }
                    else
                    {
                        MaterielTraceService.Save(_materielTrace);
                    }
                    teSkuBarcode.Text = string.Empty;
                    teNewSkuBarcode.Text = string.Empty;
                    teSkuBarcode.Properties.ReadOnly = false;
                    teSkuBarcode.Focus();
                    teNewSkuBarcode.Properties.ReadOnly = true;
                }
                teSkuBarcode.SelectAll();
                BindDetail();
            }
        }
        /// <summary>
        /// 重置
        /// </summary>
        private void Reset()
        {
            if (_item != null)
            {
                _item.Status = ItemStatus.Init;
                _item.Save();
                _item = null;
                _materielTraceInfos.Clear();
            }

            teProductTraceCode.Text = string.Empty;
            teProductTraceCode.Properties.ReadOnly = false;

            teSkuBarcode.Text = string.Empty;
            teSkuBarcode.Properties.ReadOnly = true;

            teNewSkuBarcode.EditValue = string.Empty;
            teNewSkuBarcode.Properties.ReadOnly = true;

            teProductTraceCode.Focus();
            BindDetail();
        }
        /// <summary>
        /// 结束
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnFinishItemClick(object sender, ItemClickEventArgs e)
        {
            Reset();
        }
    }
}