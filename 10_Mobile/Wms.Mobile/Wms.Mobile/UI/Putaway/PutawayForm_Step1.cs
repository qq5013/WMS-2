using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Wms.Mobile.Common;
using Business.Domain.Mobile.Mobile;

namespace Wms.Mobile.UI.Putaway
{
    public partial class PutawayForm_Step1 : Wms.Mobile.UI.TemplateForm
    {
        public PutawayTask CurrentTask { get; set; }

        public PutawayTaskResult CurrentTaskResult { get; set; }

        public PutawayForm_Step1()
        {
            InitializeComponent();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            GetPutawayTask();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            if (ModuleForm != null)
            {
                ModuleForm.Show();
                this.Close();
            }
        }

        private void btnPutaway_Click(object sender, EventArgs e)
        {
            if (CurrentTaskResult == null)
            {
                CurrentTaskResult = new PutawayTaskResult();
                CurrentTaskResult.WarehouseCode = CurrentTask.WarehouseCode;
                CurrentTaskResult.BillNumber = CurrentTask.BillNumber;
                CurrentTaskResult.Details = new List<PutawayTaskResultDetail>();
                CurrentTaskResult.Operator = GlobalState.CurrentUser.UserId;
                CurrentTaskResult.TransferTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            }

            PutawayForm_Step2 form = new PutawayForm_Step2();
            form.ModuleForm = this;
            form.CurrentTask = this.CurrentTask;
            form.CurrentTaskResult = this.CurrentTaskResult;
            this.Hide();
            form.ShowDialog();
        }

        private void cbBillNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            string billNumber = (string)cbBillNumber.SelectedItem;

            try
            {
                string uri = string.Format("Putaway/GetTask/{0}", billNumber);
                var task = GlobalState.MyRestService.GetForObject<PutawayTask>(uri);
                CurrentTask = task;

                SetTaskMemo(task);
                BindDetailGrid(task);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SetTaskMemo(PutawayTask task)
        {
            string memo = string.Empty;
            memo = "关联单据号 : " + task.LinkBillNumber + "\r\n";
            memo = memo + "计划上架日期 : " + task.PlanTransferDate + "\r\n";
            memo = memo + "备注 : " + task.Remark + "\r\n";

            txtRemark.Text = memo;
        }

        private void BindDetailGrid(PutawayTask task)
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

        private void PutawayForm_Step1_Load(object sender, EventArgs e)
        {
            SetTitle("上架-选择上架任务");
            GetPutawayTask();
        }

        private void GetPutawayTask()
        {
            string warehouseCode = GlobalState.CurrentWarehouse.WarehouseCode;

            try
            {
                string uri = string.Format("Putaway/{0}/GetTasks", warehouseCode);
                var tasks = GlobalState.MyRestService.GetForObject<List<string>>(uri);
                cbBillNumber.DataSource = tasks;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void AbandonPutaway()
        {
            CurrentTaskResult = null;
        }

        public void RefreshTask()
        {
            this.CurrentTaskResult = null;
            btnRefresh_Click(null, null);
        }
    }
}

