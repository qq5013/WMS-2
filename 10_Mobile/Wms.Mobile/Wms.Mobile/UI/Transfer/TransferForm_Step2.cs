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
using Business.Domain.Mobile.Wms;
using Business.Domain.Mobile.Inventory;

namespace Wms.Mobile.UI.Transfer
{
    public partial class TransferForm_Step2 : Wms.Mobile.UI.TemplateForm
    {
        public List<TransferBillDetailView> TransferBillDetails { get; set; }

        public TransferForm_Step2()
        {
            InitializeComponent();
        }

        private void btnAbort_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("是否放弃移货操作,数据将舍弃？", "问题", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dialogResult == DialogResult.No) return;
            if (MainForm != null)
            {
                this.Close();
                //((TransferForm_Step1)ModuleForm).AbandonTransfer();
                MainForm.Show();
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
        }

        private void PutawayForm_step4_Load(object sender, EventArgs e)
        {
            SetTitle("移货-移货完成");

            BindResult();
        }

        private void BindResult()
        {
            gridResult.DataSource = null;
            if (TransferBillDetails.Count > 0)
            {
                gridResult.DataSource = TransferBillDetails;
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
            style.GridColumnStyles["TransferedQty"].HeaderText = "移货数量";
            style.GridColumnStyles["TransferedQty"].Width = 40;
            style.GridColumnStyles["SourceLocationName"].HeaderText = "原库位";
            style.GridColumnStyles["SourceLocationName"].Width = 60;
            style.GridColumnStyles["SourceContainerName"].HeaderText = "原容器";
            style.GridColumnStyles["SourceContainerName"].Width = 60;
            style.GridColumnStyles["TargetLocationName"].HeaderText = "目标库位";
            style.GridColumnStyles["TargetLocationName"].Width = 60;
            style.GridColumnStyles["TargetContainerName"].HeaderText = "目标容器";
            style.GridColumnStyles["TargetContainerName"].Width = 60;
            style.GridColumnStyles["BatchNumber"].HeaderText = "入库批次";
            style.GridColumnStyles["BatchNumber"].Width = 80;

            style.GridColumnStyles["PlanQty"].Width = 0;
            style.GridColumnStyles["SkuId"].Width = 0;
            style.GridColumnStyles["SourceLocationId"].Width = 0;
            style.GridColumnStyles["SourceLocationCode"].Width = 0;
            style.GridColumnStyles["SourceContainerId"].Width = 0;
            style.GridColumnStyles["SourceContainerCode"].Width = 0;
            style.GridColumnStyles["TargetLocationId"].Width = 0;
            style.GridColumnStyles["TargetLocationCode"].Width = 0;
            style.GridColumnStyles["TargetContainerId"].Width = 0;
            style.GridColumnStyles["TargetContainerCode"].Width = 0;
            style.GridColumnStyles["IsTransferContainer"].Width = 0;

            style.GridColumnStyles["Id"].Width = 0;
            style.GridColumnStyles["BillId"].Width = 0;
            style.GridColumnStyles["StockId"].Width = 0;
            style.GridColumnStyles["PackId"].Width = 0;
            style.GridColumnStyles["SkuName"].Width = 0;
            style.GridColumnStyles["IsValid"].Width = 0;
        }


        //private void UploadReceivingResult()
        //{
        //    try
        //    {
        //        btnComplete.Enabled = false;
        //        string uri = string.Format("Putaway/UploadTaskResult");
        //        HttpHeaders headers = new HttpHeaders();
        //        headers.Accept = new MediaType[] { MediaType.APPLICATION_JSON, MediaType.APPLICATION_OCTET_STREAM };
        //        headers.ContentType = new MediaType("application", "json", System.Text.Encoding.UTF8);
        //        headers.Allow = new HttpMethod[] { HttpMethod.POST };

        //        string resultStr = Newtonsoft.Json.JsonConvert.SerializeObject(CurrentTaskResult);
        //        HttpEntity entity = new HttpEntity(resultStr, headers);
        //        string str = entity.Body.ToString();
        //        try
        //        {
        //            BoolResultObject result = GlobalState.MyRestService.PostForObject<BoolResultObject>(uri, entity);

        //            if (result.Result)
        //            {
        //                MessageBox.Show("上传上架结果数据成功。");
        //                this.CurrentTaskResult = null;
        //                this.ModuleForm.Show();
        //                ((TransferForm_Step1)this.ModuleForm).RefreshTask();
        //                this.Close();
        //            }
        //            else
        //                MessageBox.Show("上传上架结果数据失败。");

        //        }
        //        catch (ServiceException ex)
        //        {
        //            MessageBox.Show(ex.Message);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}
    }
}

