using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors.Controls;
using Frame.Utils.Service;
using MES.BllService;
using MES.Common;
using MES.Entity;

namespace MES.Execute.Controls
{
    /// <summary>
    ///     车间物料管理
    /// </summary>
    public partial class UcMaterielTraceManage : UserControl, IInitControl
    {
        /// <summary>
        ///     车间物料追踪列表
        /// </summary>
        private readonly List<MaterielTrace> _materielTraces = new List<MaterielTrace>();

        /// <summary>
        ///     事件
        /// </summary>
        private EventHandler _handler;

        /// <summary>
        ///     UcMaterielTraceManage
        /// </summary>
        public UcMaterielTraceManage()
        {
            InitializeComponent();
        }

        #region IInitControl Members

        /// <summary>
        ///     初始化
        /// </summary>
        public void Init()
        {
            Reset();
        }

        #endregion

        /// <summary>
        ///     作废/回收
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
        ///     作废/回收
        /// </summary>
        private void Retrieve()
        {
            MaterielTrace info = _materielTraces.Find(c => c.TraceCode == teSkuBarcode.Text.Trim());
            if (Convert.ToInt32(radioGroup1.EditValue) == 1)
            {
                // 作废
                if (info != null)
                {
                    // 临时库存数量等于一的报废后就没有了
                    if (info.Quantity == 1)
                    {
                        info.Remove();
                        _materielTraces.Remove(info);
                        teSkuBarcode.SelectAll();
                        BindDetail();
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
                                // 临时库存数量等于零后删除
                                if (info.Quantity == 0)
                                {
                                    info.Remove();
                                    _materielTraces.Remove(info);
                                }
                                else
                                {
                                    // 不等于零则保存新的库存数量
                                    info.Save();
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
            }
            else
            {
                // 回收
                if (info != null)
                {
                    // 单品不能重复
                    if (teSkuBarcode.Text.Trim().Length == 19)
                    {
                        MessageBox.Show("单品物料不能重复");
                        teSkuBarcode.SelectAll();
                        return;
                    }

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
                            info.Quantity += quantity;
                            info.Save();
                            seQuantity.EditValue = 1;
                            seQuantity.Properties.ReadOnly = true;
                            teSkuBarcode.Properties.ReadOnly = false;
                            teSkuBarcode.SelectAll();
                            teSkuBarcode.Focus();
                            BindDetail();
                        };
                }
                else
                {
                    if (teSkuBarcode.Text.Trim().Length == 19)
                    {
                        info = new MaterielTrace {Quantity = 1, TraceCode = teSkuBarcode.Text.Trim()};
                        info.MaterielTraceId = ServiceBloker.GetService<MaterielTrace>().Save(info);
                        _materielTraces.Add(info);
                        teSkuBarcode.SelectAll();
                        BindDetail();
                        return;
                    }

                    teSkuBarcode.Properties.ReadOnly = true;
                    seQuantity.Properties.ReadOnly = false;
                    seQuantity.Focus();
                    seQuantity.EditValue = 1;
                    seQuantity.Properties.MinValue = 1;

                    _handler = (sender, e)
                               =>
                        {
                            try
                            {
                                int quantity = Convert.ToInt32(seQuantity.EditValue);
                                info = new MaterielTrace {TraceCode = teSkuBarcode.Text.Trim(), Quantity = quantity};
                                info.MaterielTraceId = ServiceBloker.GetService<MaterielTrace>().Save(info);
                                _materielTraces.Add(info);
                                seQuantity.EditValue = 1;
                                seQuantity.Properties.ReadOnly = true;
                                teSkuBarcode.Properties.ReadOnly = false;
                                teSkuBarcode.SelectAll();
                                teSkuBarcode.Focus();
                                BindDetail();
                            }
                            catch (Exception ex)
                            {
                                CommonApi.Logger.Write(ex);
                            }
                        };
                }
            }
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
            _materielTraces.AddRange(ServiceBloker.GetService<MaterielTrace>().GetAll());
            teSkuBarcode.Text = string.Empty;
            teSkuBarcode.Properties.ReadOnly = false;
            seQuantity.EditValue = 1;
            seQuantity.Properties.ReadOnly = true;

            BindDetail();
        }

        /// <summary>
        ///     调整数量
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SeQuantityPropertiesButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (_handler != null) _handler.Invoke(sender, e);
        }

        /// <summary>
        ///     数量回车
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SeQuantityKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r' && _handler != null) _handler.Invoke(sender, e);
        }
    }
}