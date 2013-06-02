using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Wms.Mobile.Common;
using Business.Domain.Mobile.Mobile;
using Spring.Rest.Client;
using Newtonsoft.Json.Converters;
using Spring.Http.Converters.Json;
using Spring.Http;
using Spring.Http.Converters;
using Business.Domain.Mobile;

namespace Wms.Mobile.UI.Putaway
{
    public partial class PutawayForm_Step4 : Wms.Mobile.UI.TemplateForm
    {
        public PutawayTask CurrentTask { get; set; }

        public PutawayTaskResult CurrentTaskResult { get; set; }

        public bool _isCompletePutaway { get; set; }

        public PutawayForm_Step4()
        {
            InitializeComponent();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            PutawayForm_Step3 form = new PutawayForm_Step3();
            form.ModuleForm = this.ModuleForm;
            form.CurrentTask = this.CurrentTask;
            form.CurrentTaskResult = this.CurrentTaskResult;
            this.Hide();
            this.Close();
            form.ShowDialog();
        }

        private void btnAbort_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("是否放弃收货操作,数据将舍弃？", "问题", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dialogResult == DialogResult.No) return;
            if (ModuleForm != null)
            {
                this.Close();
                ((PutawayForm_Step1)ModuleForm).AbandonReciving();
                ModuleForm.Show();
            }
        }

        private void btnComplete_Click(object sender, EventArgs e)
        {
            if (!_isCompletePutaway)
            {
                DialogResult dialogResult = MessageBox.Show("部分货物尚为完成扫描，是否结束收货？", "问题", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (dialogResult == DialogResult.No)
                    return;
            }

            // save receiving result to server
            UploadReceivingResult();
        }

        private void PutawayForm_step4_Load(object sender, EventArgs e)
        {
            SetTitle("上架-上架完成");

            BindTask();
            BindResult();

            _isCompletePutaway = IsReceivingComplete();
            if (!_isCompletePutaway)
                lblMessage.Text = "部分货物尚未上架完成。";
        }

        private void BindResult()
        {
            gridResult.DataSource = null;
            if (CurrentTaskResult.Details.Count > 0)
            {
                gridResult.DataSource = CurrentTaskResult.Details;
                SetResultGridStyle();
            }
        }

        private void SetResultGridStyle()
        {
            DataGridTableStyle style = new DataGridTableStyle();
            gridResult.TableStyles.Clear();
            gridResult.TableStyles.Add(style);

            style.MappingName = gridResult.DataSource.GetType().Name;
            style.GridColumnStyles["SkuNumber"].HeaderText = "货物代码";
            style.GridColumnStyles["SkuNumber"].Width = 80;
            style.GridColumnStyles["TransferQty"].HeaderText = "实收数量";
            style.GridColumnStyles["TransferQty"].Width = 40;
            style.GridColumnStyles["PackName"].HeaderText = "包装";
            style.GridColumnStyles["PackName"].Width = 40;
            style.GridColumnStyles["IsPieceManagement"].HeaderText = "单件管理";
            style.GridColumnStyles["IsPieceManagement"].Width = 40;
            style.GridColumnStyles["BatchNumber"].HeaderText = "批次";
            style.GridColumnStyles["BatchNumber"].Width = 60;
            style.GridColumnStyles["ContainerBarcode"].HeaderText = "容器条码";
            style.GridColumnStyles["ContainerBarcode"].Width = 60;
            //style.GridColumnStyles["SerialNumbers"].HeaderText = "";
            //style.GridColumnStyles["SerialNumbers"].Width = 0;
        }

        private void BindTask()
        {
            gridDetails.DataSource = null;
            if (CurrentTask.Details.Count > 0)
            {
                gridDetails.DataSource = CurrentTask.Details;
                SetTaskGridStyle();
            }
        }

        private void SetTaskGridStyle()
        {
            DataGridTableStyle style = new DataGridTableStyle();
            gridDetails.TableStyles.Clear();
            gridDetails.TableStyles.Add(style);

            style.MappingName = gridDetails.DataSource.GetType().Name;
            style.GridColumnStyles["SkuNumber"].HeaderText = "货物代码";
            style.GridColumnStyles["SkuNumber"].Width = 80;
            style.GridColumnStyles["SkuName"].HeaderText = "货物名称";
            style.GridColumnStyles["SkuName"].Width = 80;
            style.GridColumnStyles["Qty"].HeaderText = "待上架数量";
            style.GridColumnStyles["Qty"].Width = 40;
            style.GridColumnStyles["PackName"].HeaderText = "包装";
            style.GridColumnStyles["PackName"].Width = 40;
            //style.GridColumnStyles["IsPieceManagement"].HeaderText = "单件管理";
            //style.GridColumnStyles["IsPieceManagement"].Width = 40;
            //style.GridColumnStyles["Barcode"].HeaderText = "条码";
            //style.GridColumnStyles["Barcode"].Width = 60;
            //style.GridColumnStyles["UPC"].HeaderText = "UPC";
            //style.GridColumnStyles["UPC"].Width = 60;
        }

        private bool IsReceivingComplete()
        {
            int taskQty = 0;
            int receivedQty = 0;
            foreach (var detail in CurrentTask.Details)
                taskQty = taskQty + detail.Qty;
            foreach (var detail in CurrentTaskResult.Details)
                receivedQty = receivedQty + detail.TransferQty;

            if (taskQty == receivedQty)
                return true;

            return false;
        }

        private void UploadReceivingResult()
        {
            try
            {
                string uri = string.Format("Putaway/UploadTaskResult");
                HttpHeaders headers = new HttpHeaders();
                headers.Accept = new MediaType[] { MediaType.APPLICATION_JSON, MediaType.APPLICATION_OCTET_STREAM };
                headers.ContentType = new MediaType("application", "json", System.Text.Encoding.UTF8);
                headers.Allow = new HttpMethod[] { HttpMethod.POST };

                string resultStr = Newtonsoft.Json.JsonConvert.SerializeObject(CurrentTaskResult);
                HttpEntity entity = new HttpEntity(resultStr, headers);
                string str = entity.Body.ToString();
                try
                {
                    BoolResultObject result = GlobalState.MyRestService.PostForObject<BoolResultObject>(uri, entity);

                    if (result.Result)
                    {
                        MessageBox.Show("上传上架结果数据成功。");
                        this.CurrentTaskResult = null;
                        this.ModuleForm.Show();
                        ((PutawayForm_Step1)this.ModuleForm).RefreshTask();
                        this.Close();
                    }
                    else
                        MessageBox.Show("上传上架结果数据失败。");

                }
                catch (ServiceException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

