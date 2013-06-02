/*----------------------------------------------------------------
// Copyright (C) 2010 有限公司
// 版权所有。 
//
// 文件名：         UcProcessItemInspect.cs
// 文件功能描述：   商品抽检
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
    /// 商品抽检
    /// </summary>
    public partial class UcProcessItemInspect : UserControl, IInitControl
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
        /// 商品抽检
        /// </summary>
        public UcProcessItemInspect()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 商品抽检数据
        /// </summary>
        public ItemSampleInspect Data { get; set; }

        #region IInitControl Members

        /// <summary>
        /// 初始化
        /// </summary>
        public void Init()
        {
            glueConfirmer.BindUser(ControlMode.Edit);
            glueCustomer.BindCustomer(ControlMode.Edit);
            glueDebugMember.BindUser(ControlMode.Edit);
            gluePcbInpecter.BindUser(ControlMode.Edit);
            glueSoftware.BindSoftware(ControlMode.Edit);
            glueResult.BindResult(ControlMode.Edit);

            gridView1.ExpandAllGroups();
        }

        #endregion
        /// <summary>
        /// 价值
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
                MessageBox.Show(Resources.PlsInputProductCode);
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
            int itemInspectId = ServiceBloker.GetService<ItemSampleInspect>().Save(Data);
            if (Data.ItemSampleInspectId <= 0)
                Data.ItemSampleInspectId = itemInspectId;


            // 保存明细
            foreach (InspectLog inspectLog in _inspectLogs)
            {
                ServiceBloker.GetService<ItemSampleInspectDetail>().Save(new ItemSampleInspectDetail
                                                                       {
                                                                           Data = inspectLog.Data,
                                                                           Remark = inspectLog.Remark,
                                                                           Result = inspectLog.Result,
                                                                           ItemSampleInspectId = Data.ItemSampleInspectId,
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
                _item = ServiceBloker.GetService<Item>().Find(c => c.Barcode == teTraceCode.Text);
                if (_item == null)
                {
                    ShowError("追踪码未找到");
                    return;
                }

                Data = ServiceBloker.GetService<ItemSampleInspect>().Find(c => c.ItemId == _item.ItemId);
                glueConfirmer.EditValue = CommonApi.CurrentUser().UserId;
                ItemInspect itemInspect = ServiceBloker.GetService<ItemInspect>().Find(c=>c.ItemId==_item.ItemId);
                if(itemInspect != null)
                {
                    glueDebugMember.EditValue = itemInspect.DebugMemberId;
                    if (itemInspect.SoftwareId > 0)
                    {
                        glueSoftware.EditValue = itemInspect.SoftwareId;
                    }
                }
                var itemProcessIds = ServiceBloker.GetService<ItemProcess>().FindAll(c => c.ItemId == _item.ItemId, null).Select(c => c.ItemProcessId).ToList();
                if (itemProcessIds.Count>0)
                {
                    var itemProcessStepIds =
                        ServiceBloker.GetService<ItemProcessStep>().FindAll(
                            c => itemProcessIds.Contains(c.ItemProcessId), null).Select(c => c.ItemProcessStepId).ToList
                            ();
                    if (itemProcessStepIds.Count > 0)
                    {
                        var itemProcessStepDetails = ServiceBloker.GetService<ItemProcessStepDetail>().FindAll(
                            c => itemProcessStepIds.Contains(c.ItemProcessStepId)&&c.TraceType==TraceType.Single, null);

                        if(itemProcessStepDetails.Count>0)
                        {
                            var pcbInspect = ServiceBloker.GetService<PcbInspect>().Find(c=>c.TraceCode==  itemProcessStepDetails[0].TraceCode);
                           
                            if (pcbInspect != null)
                            {
                                gluePcbInpecter.EditValue = pcbInspect.InspecterId;
                                if (glueSoftware.EditValue != null)
                                {
                                    glueSoftware.EditValue = pcbInspect.SoftwareId;
                                }
                            }
                        }
                    }
                }

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
                    Data = new ItemSampleInspect
                               {
                                   ItemId = _item.ItemId
                               };
                }
                SkuInfo skuInfo = ServiceBloker.GetQuery<SkuInfo>().Find(t => t.SkuId == _item.SkuId);

                Product product = ServiceBloker.GetService<Product>().GetById(skuInfo.ProductId);

                ProductionOrder productionOrder = ServiceBloker.GetService<ProductionOrder>().GetById(_item.ProductionOrderId);
                if (productionOrder != null)
                {
                    deFinishTime.EditValue = productionOrder.ProductionDate;
                    beProductionOrderCode.Text = productionOrder.Code;
                }

                teSkuName.Text = skuInfo.Name;
                var itemInspectDetails =
                    ServiceBloker.GetService<ItemSampleInspectDetail>().FindAll(c => c.ItemSampleInspectId == Data.ItemSampleInspectId,
                                                                          null);

                int productId = product.ProductId;
                _inspectLogs.AddRange(ServiceBloker.GetService<ProductItemInspect>().FindAll(c => c.ProductId == productId, null).
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
        /// 检测日志
        /// </summary>
        /// <param name="productInspect"></param>
        /// <param name="itemInspectDetails"></param>
        /// <returns></returns>
        private static InspectLog InspectLog(ProductItemInspect productInspect, List<ItemSampleInspectDetail> itemInspectDetails)
        {
            var inspectLog = new InspectLog
                                 {
                                     InspectId = productInspect.ProductId,
                                     Name = productInspect.Name,
                                     Content = productInspect.Content,
                                     NormalData = productInspect.MinData + "~" + productInspect.MaxData
                                 };
            var itemInspectDetail =
                itemInspectDetails.Find(d => d.ProductInspectId == productInspect.ProductId);
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
                MessageBox.Show(Resources.PlsInputProductCode);
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
        /// 打印
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnPrintResultItemClick(object sender, ItemClickEventArgs e)
        {
            //Data.GetReport().Print();
        }
    }
}