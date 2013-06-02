using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraReports.UI;
using Frame.Utils.Service;
using MES.BllService;
using MES.Common;
using MES.Entity;
using MES.Enum;
using MES.Execute.Properties;

namespace MES.Execute.Controls
{
    /// <summary>
    /// 检测工序
    /// </summary>
    public partial class UcProcessCheck : UserControl, IInitControl
    {
        /// <summary>
        /// 检测日志
        /// </summary>
        private readonly List<InspectLog> _inspectLogs = new List<InspectLog>();

        public UcProcessCheck()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Pcb检测
        /// </summary>
        public PcbInspect Data { get; set; }

        /// <summary>
        /// Pcb检测明细服务
        /// </summary>
        public IEntityService<PcbInspectDetail> PcbInspectDetailService
        {
            get { return ServiceBloker.GetService<PcbInspectDetail>(); }
        }

        /// <summary>
        /// PCB检测服务
        /// </summary>
        public IEntityService<PcbInspect> PcbInspectService
        {
            get { return ServiceBloker.GetService<PcbInspect>(); }
        }

        #region IInitControl Members

        /// <summary>
        /// 初始化
        /// </summary>
        public void Init()
        {
            //glueVendor.BindVendor(ControlMode.Edit);
            //glueInspecter.BindUser(ControlMode.Edit, null);
            //glueSoftware.BindSoftware(ControlMode.Edit);
            gridView1.ExpandAllGroups();
        }

        #endregion

        /// <summary>
        /// 检测工序
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
                MessageBox.Show("请输入正确的PCB板跟踪码");
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
            int pcbInspectId = PcbInspectService.Save(Data);
            if (Data.PcbInspectId == 0)
                Data.PcbInspectId = pcbInspectId;
            // 保存明细
            foreach (InspectLog inspectLog in _inspectLogs)
            {
                PcbInspectDetailService.Save(new PcbInspectDetail
                                                 {
                                                     Data = inspectLog.Data,
                                                     Remark = inspectLog.Remark,
                                                     Result = inspectLog.Result,
                                                     PcbInspectId = Data.PcbInspectId
                                                 });
            }
            return true;
        }

        /// <summary>
        /// 输入跟踪码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TeTraceCodeKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                string traceCode = teTraceCode.Text.Trim();
                Storage storage =
                    ServiceBloker.GetService<Storage>().Find(c => c.Code == traceCode && c.TraceType == TraceType.Single);
                // 检查库存是否存在
                if (storage != null)
                {
                    if (ServiceBloker.GetService<PcbInspect>().Find(c => c.TraceCode == traceCode) != null)
                        Data = ServiceBloker.GetService<PcbInspect>().Find(c => c.TraceCode == traceCode);
                    else
                    {
                        Data = new PcbInspect();
                        Data.TraceCode = traceCode;
                        Data.OrderCode = CommonApi.GetCode<PcbInspect>();
                        Vendor vendor = ServiceBloker.GetService<Vendor>().Find(
                            c => c.Code == traceCode.Substring(0, 4));
                        if (vendor != null) Data.VendorId = vendor.VendorId;
                        Data.InspecterId = CommonApi.CurrentUser().UserId;
                        Data.InspectTime = DateTimeHelper.Now;
                    }
                    SkuInfo skuInfo = ServiceBloker.GetQuery<SkuInfo>().Find(t => t.SkuId == storage.SkuId);

                    teLotNo.Text = traceCode.Substring(9, 5);
                    teSkuName.Text = skuInfo.Name;
                    teSpec.Text = skuInfo.Spec;
                    teModel.Text = skuInfo.Model;
                    teCategoryName.Text = skuInfo.Code;

                    Data.FillData(Controls);

                    // 结束
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

                    List<PcbInspectDetail> pcbInspectDetails =
                        ServiceBloker.GetService<PcbInspectDetail>().FindAll(c => c.PcbInspectId == Data.PcbInspectId,
                                                                             null);
                    _inspectLogs.Clear();
                    _inspectLogs.AddRange(
                        ServiceBloker.GetService<PcbInspectConfig>().FindAll(c => c.SkuId == skuInfo.SkuId, null).
                            Select(
                                c =>
                                InspectLog(c, pcbInspectDetails)
                            ).ToList());
                    BindDetail();
                    gridView1.ExpandAllGroups();
                }
                else
                {
                    btnSave.Enabled = true;
                    btnFinish.Caption = "完工";
                }
            }
        }

        /// <summary>
        /// 检测日志
        /// </summary>
        /// <param name="pcbInspectConfig"></param>
        /// <param name="pcbInspectDetails"></param>
        /// <returns></returns>
        private static InspectLog InspectLog(PcbInspectConfig pcbInspectConfig, List<PcbInspectDetail> pcbInspectDetails)
        {
            var inspectLog = new InspectLog
                                 {
                                     InspectId = pcbInspectConfig.PcbInspectConfigId,
                                     Name = pcbInspectConfig.Name,
                                     Content = pcbInspectConfig.Content,
                                     Status = "初始状态",
                                     // (pcbInspectConfig.Type == ProductInspectType.Init) ? : "工作状态",
                                     NormalData = pcbInspectConfig.MinData + "~" + pcbInspectConfig.MaxData
                                 };
            PcbInspectDetail itemInspectDetail =
                pcbInspectDetails.Find(d => d.PcbInspectConfigId == pcbInspectConfig.PcbInspectConfigId);
            if (itemInspectDetail != null)
            {
                inspectLog.Data = itemInspectDetail.Data;
                inspectLog.Remark = itemInspectDetail.Remark;
                inspectLog.Result = itemInspectDetail.Result;
            }
            return inspectLog;
        }

        /// <summary>
        /// 打印结果
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnPrintResultItemClick(object sender, ItemClickEventArgs e)
        {
            //XtraReport report = Data.GetReport();
            //report.Print();
        }

        /// <summary>
        /// 完成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnFinishItemClick(object sender, ItemClickEventArgs e)
        {
            if (Data == null)
            {
                MessageBox.Show("请输入正确的PCB板跟踪码");
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
        /// 绑定明细
        /// </summary>
        private void BindDetail()
        {
            gridControl1.DataSource = null;
            gridControl1.DataSource = _inspectLogs;
        }
    }
}