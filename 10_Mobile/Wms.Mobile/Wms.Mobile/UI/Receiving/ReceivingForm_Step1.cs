using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Wms.Mobile.Common;
using Business.Domain.Mobile.Mobile;

namespace Wms.Mobile.UI.Receiving
{
    public partial class ReceivingForm_Step1 : TemplateForm
    {
        public ReceivingTask CurrentTask {get; set;}

        public ReceivingTaskResult CurrentTaskResult { get; set; }

        public ReceivingForm_Step1()
        {
            InitializeComponent();
        }

        private void ReceivingForm_Step1_Load(object sender, EventArgs e)
        {
            SetTitle("收货-选择收货任务");

            GetReceivingTasks();
        }

        private void GetReceivingTasks()
        {
            string warehouseCode = GlobalState.CurrentWarehouse.WarehouseCode;

            try
            {
                string uri = string.Format("Receiving/{0}/GetTasks", warehouseCode);
                var tasks = GlobalState.MyRestService.GetForObject<List<string>>(uri);
                cbBillNumber.DataSource = tasks;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cbBillNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            string billNumber = (string)cbBillNumber.SelectedItem;

            try
            {
                string uri = string.Format("Receiving/GetTask/{0}", billNumber);
                var task = GlobalState.MyRestService.GetForObject<ReceivingTask>(uri);
                CurrentTask = task;

                SetTaskMemo(task);
                BindDetailGrid(task);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BindDetailGrid(ReceivingTask task)
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

        private void SetTaskMemo(ReceivingTask task)
        {
            string memo = string.Empty;
            memo = "关联单据号 : " + task.LinkBillNumber + "\r\n";
            memo = memo + "计划收货时间 : " + task.PlanReceivingTime + "\r\n";
            memo = memo + "备注 : " + task.Remark + "\r\n";

            txtMemo.Text = memo;
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            if (ModuleForm != null)
            {
                ModuleForm.Show();
                this.Close();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            GetReceivingTasks();
        }

        public void RefreshTask()
        {
            this.CurrentTaskResult = null;
            btnRefresh_Click(null, null);
        }

        private void btnReceive_Click(object sender, EventArgs e)
        {
            if (CurrentTaskResult == null)
            {
                CurrentTaskResult = new ReceivingTaskResult();
                CurrentTaskResult.WarehouseCode = CurrentTask.WarehouseCode;
                CurrentTaskResult.BillNumber = CurrentTask.BillNumber;
                CurrentTaskResult.Details = new List<ReceivingTaskResultDetail>();
                CurrentTaskResult.Operator = GlobalState.CurrentUser.UserId;
            }

            ReceivingForm_Step2 form = new ReceivingForm_Step2();
            form.ModuleForm = this;
            form.CurrentTask = this.CurrentTask;
            form.CurrentTaskResult = this.CurrentTaskResult;
            this.Hide();
            form.ShowDialog();
        }

        public void AbandonReciving()
        {
            CurrentTaskResult = null;
        }
    }
}