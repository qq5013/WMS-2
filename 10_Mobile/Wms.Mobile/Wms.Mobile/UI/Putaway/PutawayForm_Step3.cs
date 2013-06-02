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
    public partial class PutawayForm_Step3 : Wms.Mobile.UI.TemplateForm
    {
        public PutawayTask CurrentTask { get; set; }

        public PutawayTaskResult CurrentTaskResult { get; set; }

        public bool _isCompletePutaway { get; set; }

        public PutawayForm_Step3()
        {
            InitializeComponent();
        }

        //private void btnReturn_Click(object sender, EventArgs e)
        //{
        //    PutawayForm_Step3 form = new PutawayForm_Step3();
        //    form.ModuleForm = this.ModuleForm;
        //    form.CurrentTask = this.CurrentTask;
        //    form.CurrentTaskResult = this.CurrentTaskResult;
        //    this.Hide();
        //    this.Close();
        //    form.ShowDialog();
        //}

        private void btnAbort_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("是否放弃收货操作,数据将舍弃？", "问题", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dialogResult == DialogResult.No) return;
            if (ModuleForm != null)
            {
                this.Close();
                ((PutawayForm_Step1)ModuleForm).AbandonPutaway();
                ModuleForm.Show();
            }
        }

        private void btnComplete_Click(object sender, EventArgs e)
        {
            //if (!_isCompletePutaway)
            //{
            //    DialogResult dialogResult = MessageBox.Show("部分货物尚为完成扫描，是否结束收货？", "问题", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            //    if (dialogResult == DialogResult.No)
            //        return;
            //}

            // save receiving result to server
            //UploadReceivingResult();
            UploadPutawayesultByWebService();
        }

        private void PutawayForm_step4_Load(object sender, EventArgs e)
        {
            SetTitle("上架-上架完成");

            BindTask();
            BindResult();

            //_isCompletePutaway = IsPutawayComplete();
            //if (!_isCompletePutaway)
            //    lblMessage.Text = "部分货物尚未上架完成。";
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
            style.GridColumnStyles["PackName"].HeaderText = "包装";
            style.GridColumnStyles["PackName"].Width = 40;
            style.GridColumnStyles["TransferedQty"].HeaderText = "上架数量";
            style.GridColumnStyles["TransferedQty"].Width = 40;
            style.GridColumnStyles["BatchNumber"].HeaderText = "入库批次";
            style.GridColumnStyles["BatchNumber"].Width = 80;

            style.GridColumnStyles["SourceLocationBarcode"].HeaderText = "";
            style.GridColumnStyles["SourceLocationBarcode"].Width = 0;
            style.GridColumnStyles["SourceContainerBarcode"].HeaderText = "周转容器";
            style.GridColumnStyles["SourceContainerBarcode"].Width = 60;
            style.GridColumnStyles["TargetLocationBarcode"].HeaderText = "上架库位";
            style.GridColumnStyles["TargetLocationBarcode"].Width = 60;
            style.GridColumnStyles["TargetContainerBarcode"].HeaderText = "上架容器";
            style.GridColumnStyles["TargetContainerBarcode"].Width = 60;

            style.GridColumnStyles["IsPieceManagement"].HeaderText = "是否单件管理";
            style.GridColumnStyles["IsPieceManagement"].Width = 80;
            style.GridColumnStyles["IsTransferContainer"].Width = 0;
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

            style.GridColumnStyles["ContainerName"].HeaderText = "容器";
            style.GridColumnStyles["ContainerName"].Width = 80;
            style.GridColumnStyles["ContainerBarcode"].Width = 0;

            style.GridColumnStyles["SkuNumber"].HeaderText = "货物代码";
            style.GridColumnStyles["SkuNumber"].Width = 80;
            style.GridColumnStyles["SkuName"].HeaderText = "货物名称";
            style.GridColumnStyles["SkuName"].Width = 80;
            style.GridColumnStyles["PackName"].HeaderText = "包装";
            style.GridColumnStyles["PackName"].Width = 40;
            style.GridColumnStyles["Qty"].HeaderText = "待上架数量";
            style.GridColumnStyles["Qty"].Width = 40;
            style.GridColumnStyles["Barcode"].HeaderText = "条码";
            style.GridColumnStyles["Barcode"].Width = 80;
            style.GridColumnStyles["UPC"].HeaderText = "UPC";
            style.GridColumnStyles["UPC"].Width = 80;
            style.GridColumnStyles["BatchNumber"].HeaderText = "入库批次";
            style.GridColumnStyles["BatchNumber"].Width = 80;
            style.GridColumnStyles["IsPieceManagement"].HeaderText = "是否单件管理";
            style.GridColumnStyles["IsPieceManagement"].Width = 80;
        }

        //private bool IsPutawayComplete()
        //{
        //    int taskQty = 0;
        //    int transferedQty = 0;
        //    foreach (var detail in CurrentTask.Details)
        //        taskQty = taskQty + detail.Qty;
        //    foreach (var detail in CurrentTaskResult.Details)
        //        transferedQty = transferedQty + detail.TransferedQty;

        //    if (taskQty == transferedQty)
        //        return true;

        //    return false;
        //}

        private void UploadPutawayResult()
        {
            try
            {
                btnComplete.Enabled = false;
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

        private void UploadPutawayesultByWebService()
        {
            try
            {
                
                try
                {
                    bool result = GlobalState.DeviceService.UploadPutawayTaskResult(CurrentTaskResult);

                    if (result)
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
                    MessageBox.Show("上传上架结果数据异常。");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

