/*----------------------------------------------------------------
// Copyright (C) 2010 有限公司
// 版权所有。 
//
// 文件名：         UcWaster.cs
// 文件功能描述：   报废
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
using DevExpress.XtraEditors.Controls;
using Frame.Utils.Service;
using MES.BllService;
using MES.Common;
using MES.Entity;
using MES.Enum;

namespace MES.Execute.Controls
{
    /// <summary>
    ///     报废
    /// </summary>
    public partial class UcWaster : UserControl, IInitControl
    {
        /// <summary>
        ///     物料追踪
        /// </summary>
        private readonly List<MaterielTraceInfo> _materielTraces = new List<MaterielTraceInfo>();

        /// <summary>
        ///     事件
        /// </summary>
        private EventHandler _handler;

        public UcWaster()
        {
            InitializeComponent();
        }

        #region IInitControl Members

        /// <summary>
        ///     初始化
        /// </summary>
        public void Init()
        {
        }

        #endregion

        /// <summary>
        ///     报废服务
        /// </summary>
        private IEntityService<Waster> WasterService
        {
            get { return ServiceBloker.GetService<Waster>(); }
        }

        /// <summary>
        ///     报废
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TeSkuBarcodeKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                Retrieve();
            }
        }

        /// <summary>
        ///     报废
        /// </summary>
        private void Retrieve()
        {
            MaterielTraceInfo info = _materielTraces.Find(c => c.TraceCode == teSkuBarcode.Text.Trim());
            if (info != null)
            {
                if (info.Quantity == 1)
                {
                    info.Quantity--;
                    var storageTrace = new StorageTrace
                        {Code = info.TraceCode, Quantity = -1, TraceType = info.TraceType};
                    ItemProcessStepDetail itemProcessStepDetail = info.Details[0];
                    itemProcessStepDetail.Status = ItemProcessStepDetailStatus.Normal;
                    itemProcessStepDetail.Save();
                    info.Details.Remove(itemProcessStepDetail);
                    CommonApi.MaterialTrace(new List<StorageTrace> {storageTrace});
                    if (info.Quantity == 0)
                        _materielTraces.Remove(info);
                }
                else
                {
                    teSkuBarcode.Properties.ReadOnly = true;
                    seQuantity.Properties.ReadOnly = false;
                    seQuantity.Focus();
                    seQuantity.EditValue = 1;
                    seQuantity.Properties.MinValue = 1;
                    seQuantity.Properties.MaxValue = info.Quantity;

                    _handler = (sender, e)
                               =>
                        {
                            int quantity = Convert.ToInt32(seQuantity.EditValue);
                            info.Quantity -= quantity;
                            var storageTrace =
                                new StorageTrace
                                    {
                                        Code = info.TraceCode,
                                        Quantity = -quantity,
                                        TraceType = info.TraceType
                                    };
                            CommonApi.MaterialTrace(new List<StorageTrace> {storageTrace});
                            if (info.Quantity == 0)
                                _materielTraces.Remove(info);

                            List<ItemProcessStepDetail> itemProcessStepDetails = info.Details.GetRange(0,
                                                                                                       quantity);
                            foreach (ItemProcessStepDetail itemProcessStepDetail in itemProcessStepDetails)
                            {
                                itemProcessStepDetail.Status = ItemProcessStepDetailStatus.Normal;
                                itemProcessStepDetail.Save();
                                info.Details.Remove(itemProcessStepDetail);
                            }


                            seQuantity.EditValue = 1;
                            seQuantity.Properties.ReadOnly = true;
                            teSkuBarcode.Properties.ReadOnly = false;
                            teSkuBarcode.SelectAll();
                            teSkuBarcode.Focus();
                            BindDetail();
                        };
                }
            }
            teSkuBarcode.SelectAll();
            BindDetail();
        }

        /// <summary>
        ///     绑定明细
        /// </summary>
        private void BindDetail()
        {
            gridControl1.DataSource = null;
            gridControl1.DataSource = _materielTraces;
        }

        /// <summary>
        ///     输入产品跟踪码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TeProductTraceCodeKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\r') return;
            string s = teProductTraceCode.Text.Trim();

            Item item = ServiceBloker.GetService<Item>().Find(c => c.TraceCode == s);

            if (item != null)
            {
                bool isNew = false;
                if (item.Status != ItemStatus.Waster)
                {
                    isNew = true;
                    item.Status = ItemStatus.Waster;
                    item.Save();

                    WasterService.Save(new Waster
                        {
                            CreateTime = DateTimeHelper.Now,
                            CreaterId = CommonApi.CurrentUser().UserId,
                            ProductInfoId = item.ItemId
                        });
                }

                teProductTraceCode.Properties.ReadOnly = true;
                teSkuBarcode.Properties.ReadOnly = false;
                teSkuBarcode.Focus();

                List<int> ints =
                    ServiceBloker.GetService<ItemProcess>().FindAll(c => c.ItemId == item.ItemId).Select(
                        c => c.ItemProcessId).ToList();
                if (ints.Count <= 0)
                {
                }
                else
                {
                    List<int> steps =
                        ServiceBloker.GetService<ItemProcessStep>().FindAll(c => ints.Contains(c.ItemProcessId)).Select(c => c.ItemProcessStepId).
                                      ToList();
                    List<ItemProcessStepDetail> details;
                    if (isNew)
                        details = ServiceBloker.GetService<ItemProcessStepDetail>().FindAll(
                            c => steps.Contains(c.ItemProcessStepId));
                    else
                    {
                        details = ServiceBloker.GetService<ItemProcessStepDetail>().FindAll(
                            c => steps.Contains(c.ItemProcessStepId) && c.Status == ItemProcessStepDetailStatus.Invalid);
                    }
                    foreach (ItemProcessStepDetail itemProcessStep in details)
                    {
                        ItemProcessStepDetail step = itemProcessStep;
                        if (isNew)
                        {
                            step.Status = ItemProcessStepDetailStatus.Invalid;
                            step.Save();
                        }
                        MaterielTraceInfo materielTrace = _materielTraces.Find(c => c.TraceCode == step.TraceCode);
                        if (materielTrace == null)
                        {
                            materielTrace = new MaterielTraceInfo
                                {
                                    TraceCode = step.TraceCode,
                                    SkuInfo =
                                        ServiceBloker.GetQuery<SkuInfo>().Find(
                                            t => t.SkuId == step.SkuId)
                                };

                            _materielTraces.Add(materielTrace);
                        }
                        materielTrace.Details.Add(step);
                        materielTrace.Quantity += 1;
                    }
                }

                BindDetail();
            }
        }

        /// <summary>
        ///     结束
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnFinishItemClick(object sender, ItemClickEventArgs e)
        {
            Reset();
        }

        /// <summary>
        ///     重置
        /// </summary>
        private void Reset()
        {
            _materielTraces.Clear();
            teProductTraceCode.Text = string.Empty;
            teProductTraceCode.Properties.ReadOnly = false;
            teSkuBarcode.Text = string.Empty;
            teSkuBarcode.Properties.ReadOnly = true;
            seQuantity.EditValue = 1;
            seQuantity.Properties.ReadOnly = true;
            teProductTraceCode.Focus();
            BindDetail();
        }

        /// <summary>
        ///     设置数量
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SeQuantityPropertiesButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (_handler != null) _handler.Invoke(sender, e);
        }

        /// <summary>
        ///     设置数量
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SeQuantityKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r' && _handler != null) _handler.Invoke(sender, e);
        }
    }
}