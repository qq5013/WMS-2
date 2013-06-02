using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Wms.Mobile.Common;
using Business.Domain.Mobile.Mobile;
using Business.Domain.Mobile;
using Business.Domain.Mobile.Inventory;
using Spring.Rest.Client;
using Newtonsoft.Json.Converters;
using Spring.Http.Converters.Json;
using Spring.Http;
using Spring.Http.Converters;

namespace Wms.Mobile.UI.Delivery
{
    public partial class DeliveryForm : Wms.Mobile.UI.TemplateForm
    {
        public DeliveryTask CurrentTask { get; set; }
        public OutboundBill CurrentTaskResult { get; set; }

        public DeliveryForm()
        {
            InitializeComponent();
        }

        private void cbOutBillNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            string billNumber = (string)cbOutBillNumber.SelectedItem;

            try
            {
                string uri = string.Format("Delivery/GetTask/{0}", billNumber);
                var task = GlobalState.MyRestService.GetForObject<DeliveryTask>(uri);

                CurrentTask = task;

                SetTaskMemo(task);

                BindDetailGrid(task);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DeliveryForm_Load(object sender, EventArgs e)
        {
            SetTitle("出库-选择出库任务");

            GetReceivingTasks();
        }

        private void GetReceivingTasks()
        {
            string warehouseCode = GlobalState.CurrentWarehouse.WarehouseCode;

            try
            {
                string uri = string.Format("Delivery/{0}/GetTasks", warehouseCode);
                var tasks = GlobalState.MyRestService.GetForObject<List<string>>(uri);
                cbOutBillNumber.DataSource = tasks;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BindDetailGrid(DeliveryTask task)
        {
            gridDetails.DataSource = null;
            if (task.Details.Count > 0)
            {
                gridDetails.DataSource = task.Details;
                SetGridStyle();
            }
        }

        private void SetGridStyle()
        {
            DataGridTableStyle style = new DataGridTableStyle();
            gridDetails.TableStyles.Clear();
            gridDetails.TableStyles.Add(style);
            style.MappingName = gridDetails.DataSource.GetType().Name;

            style.MappingName = gridDetails.DataSource.GetType().Name;
            style.GridColumnStyles["SkuNumber"].HeaderText = "货物代码";
            style.GridColumnStyles["SkuNumber"].Width = 80;
            style.GridColumnStyles["SkuName"].HeaderText = "货物名称";
            style.GridColumnStyles["SkuName"].Width = 80;
            style.GridColumnStyles["Qty"].HeaderText = "出货数量";
            style.GridColumnStyles["Qty"].Width = 40;
            style.GridColumnStyles["PackName"].HeaderText = "包装";
            style.GridColumnStyles["PackName"].Width = 40;
            style.GridColumnStyles["BatchNumber"].HeaderText = "入库批次";
            style.GridColumnStyles["BatchNumber"].Width = 80;
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            if (ModuleForm != null)
            {
                ModuleForm.Show();
                this.Close();
            }
        }

        private void SetTaskMemo(DeliveryTask task)
        {
            string memo = string.Empty;
            memo = "单据号 : " + task.BillNumber + "\r\n";
            memo = memo + "出库日期 : " + task.IssueTime + "\r\n";
            memo = memo + "备注 : " + task.Remark + "\r\n";

            txtRemark.Text = memo;
        }

        private void btnReceive_Click(object sender, EventArgs e)
        {
            string billNumber = (string)cbOutBillNumber.SelectedItem;

            try
            {
                string uri = string.Format("Delivery/GetBill/{0}", billNumber);
                var task = GlobalState.MyRestService.GetForObject<OutboundBill>(uri);

                CurrentTaskResult = task;

                // UploadIssueResult();
                UploadIssueResultByWebService();

                //if (task)
                //{
                //    MessageBox.Show("上传拣货结果数据成功。");
                //    GetReceivingTasks();
                //}
                //else
                //    MessageBox.Show("上传拣货结果数据失败。");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void UploadIssueResultByWebService()
        {
            try
            {
                try
                {
                    bool result = GlobalState.DeviceService.UpdateDeliveryTask(CurrentTaskResult);

                    if (result)
                    {
                        MessageBox.Show("上传发货结果数据成功。");
                        GetReceivingTasks();
                    }
                    else
                        MessageBox.Show("上传发货结果数据失败。");

                }
                catch (ServiceException ex)
                {
                    MessageBox.Show("上传发货结果数据异常。");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UploadIssueResult()
        {
            try
            {
                btnReceive.Enabled = false;
                string uri = string.Format("Delivery/UploadTaskResult");
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
                        GetReceivingTasks();
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

