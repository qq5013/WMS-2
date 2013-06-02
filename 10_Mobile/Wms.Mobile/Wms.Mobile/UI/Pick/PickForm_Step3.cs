using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Business.Domain.Mobile.Mobile;
using Wms.Mobile.Common;
using Spring.Rest.Client;
using Newtonsoft.Json.Converters;
using Spring.Http.Converters.Json;
using Spring.Http;
using Spring.Http.Converters;
using Business.Domain.Mobile;

namespace Wms.Mobile.UI.Pick
{
    public partial class PickForm_Step3 : Wms.Mobile.UI.TemplateForm
    {
        public PickTask CurrentTask { get; set; }

        public PickTaskResult CurrentTaskResult { get; set; }

        public PickForm_Step3()
        {
            InitializeComponent();
        }

        private void btnAbort_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("是否放弃收货操作,数据将舍弃？", "问题", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dialogResult == DialogResult.No) return;
            if (ModuleForm != null)
            {
                this.Close();
                ((PickForm_Step1)ModuleForm).AbandonPutaway();
                ModuleForm.Show();
            }
        }

        private void btnComplete_Click(object sender, EventArgs e)
        {
            //UploadPickResult();
            UploadPickResultByWebService();
        }

        private void UploadPickResultByWebService()
        {
            try
            {

                try
                {
                    bool result = GlobalState.DeviceService.UploadPickTaskResult(CurrentTaskResult);

                    if (result)
                    {
                        MessageBox.Show("上传拣货结果数据成功。");
                        this.CurrentTaskResult = null;
                        this.ModuleForm.Show();
                        ((PickForm_Step1)this.ModuleForm).RefreshTask();
                        this.Close();
                    }
                    else
                        MessageBox.Show("上传拣货结果数据失败。");

                }
                catch (ServiceException ex)
                {
                    MessageBox.Show("上传拣货结果数据异常。");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void PickForm_Step3_Load(object sender, EventArgs e)
        {
            SetTitle("拣货-拣货完成");

            BindTask();
            BindResult();
        }

        private void BindResult()
        {
            gridPickTask.DataSource = null;
            if (CurrentTaskResult.Details.Count > 0)
            {
                gridPickTask.DataSource = CurrentTaskResult.Details;
                SetResultGridStyle();
            }
        }

        private void SetResultGridStyle()
        {
            DataGridTableStyle style = new DataGridTableStyle();
            gridPickTask.TableStyles.Clear();
            gridPickTask.TableStyles.Add(style);

            style.MappingName = gridPickTask.DataSource.GetType().Name;

            style.GridColumnStyles["SkuNumber"].HeaderText = "货物代码";
            style.GridColumnStyles["SkuNumber"].Width = 80;
            style.GridColumnStyles["PackName"].HeaderText = "包装";
            style.GridColumnStyles["PackName"].Width = 40;
            style.GridColumnStyles["ReceivedQty"].HeaderText = "出库数量";
            style.GridColumnStyles["ReceivedQty"].Width = 40;
            style.GridColumnStyles["BatchNumber"].HeaderText = "入库批次";
            style.GridColumnStyles["BatchNumber"].Width = 80;
            style.GridColumnStyles["LocationBarcode"].HeaderText = "出库库位";
            style.GridColumnStyles["LocationBarcode"].Width = 60;
            style.GridColumnStyles["ContainerBarcode"].HeaderText = "出库容器";
            style.GridColumnStyles["ContainerBarcode"].Width = 60;
            style.GridColumnStyles["IsPieceManagement"].HeaderText = "是否单件管理";
            style.GridColumnStyles["IsPieceManagement"].Width = 80;
            style.GridColumnStyles["PickTask"].HeaderText = "拣选任务";
            style.GridColumnStyles["PickTask"].Width = 0;
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
            style.GridColumnStyles["Qty"].HeaderText = "待出数量";
            style.GridColumnStyles["Qty"].Width = 40;
            style.GridColumnStyles["IssuedQty"].HeaderText = "出库数量";
            style.GridColumnStyles["IssuedQty"].Width = 80;
            style.GridColumnStyles["PackName"].HeaderText = "包装";
            style.GridColumnStyles["PackName"].Width = 40;
            style.GridColumnStyles["IsPieceManagement"].HeaderText = "单件管理";
            style.GridColumnStyles["IsPieceManagement"].Width = 40;
            style.GridColumnStyles["Barcode"].HeaderText = "条码";
            style.GridColumnStyles["Barcode"].Width = 60;
            style.GridColumnStyles["UPC"].HeaderText = "UPC";
            style.GridColumnStyles["UPC"].Width = 60;
        }

        private void SetGridStyle()
        {
            DataGridTableStyle style = new DataGridTableStyle();
            gridDetails.TableStyles.Clear();
            gridDetails.TableStyles.Add(style);

            style.MappingName = gridDetails.DataSource.GetType().Name;
            style.GridColumnStyles["SkuNumber"].HeaderText = "货物代码";
            style.GridColumnStyles["SkuNumber"].Width = 80;
            style.GridColumnStyles["SkuName"].HeaderText = "货物名称";
            style.GridColumnStyles["SkuName"].Width = 80;
            style.GridColumnStyles["Qty"].HeaderText = "待收数量";
            style.GridColumnStyles["Qty"].Width = 40;
            style.GridColumnStyles["PackName"].HeaderText = "包装";
            style.GridColumnStyles["PackName"].Width = 40;
            style.GridColumnStyles["IsPieceManagement"].HeaderText = "单件管理";
            style.GridColumnStyles["IsPieceManagement"].Width = 40;
            style.GridColumnStyles["Barcode"].HeaderText = "条码";
            style.GridColumnStyles["Barcode"].Width = 60;
            style.GridColumnStyles["UPC"].HeaderText = "UPC";
            style.GridColumnStyles["UPC"].Width = 60;
        }

        private void BindDetailGrid(PickTask task)
        {
            gridDetails.DataSource = null;
            if (task.Details.Count > 0)
            {
                gridDetails.DataSource = task.Details;
                SetGridStyle();
            }
        }

        private void UploadPickResult()
        {
            try
            {
                btnComplete.Enabled = false;
                string uri = string.Format("Pick/UploadTaskResult");
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
                        MessageBox.Show("上传拣货结果数据成功。");
                        this.CurrentTaskResult = null;
                        this.ModuleForm.Show();
                        ((PickForm_Step1)this.ModuleForm).RefreshTask();
                        this.Close();
                    }
                    else
                        MessageBox.Show("上传拣货结果数据失败。");

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

