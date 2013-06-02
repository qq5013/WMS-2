using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Wms.Mobile.Common;
using Business.Domain.Mobile.Mobile;

namespace Wms.Mobile.UI.Pick
{
    public partial class PickForm_Step1 : Wms.Mobile.UI.TemplateForm
    {
        public PickTask CurrentTask { get; set; }

        public PickTaskResult CurrentTaskResult { get; set; }

        public PickForm_Step1()
        {
            InitializeComponent();
        }

        private void btnPick_Click(object sender, EventArgs e)
        {
            if (CurrentTaskResult == null)
            {
                CurrentTaskResult = new PickTaskResult();
                CurrentTaskResult.WarehouseCode = CurrentTask.WarehouseCode;
                CurrentTaskResult.PlanNumber = CurrentTask.PlanNumber;
                CurrentTaskResult.Details = new List<PickTaskResultDetail>();
                CurrentTaskResult.Operator = GlobalState.CurrentUser.UserId;
                CurrentTaskResult.PlanId = CurrentTask.PlanId;
                CurrentTaskResult.ClientId = CurrentTask.ClientId;
            }

            PickForm_Step2 form = new PickForm_Step2();
            form.ModuleForm = this;
            form.CurrentTask = this.CurrentTask;
            form.CurrentTaskResult = this.CurrentTaskResult;
            this.Hide();
            form.ShowDialog();
        }

        private void cbPlanNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            string billNumber = (string)cbPlanNumber.SelectedItem;

            try
            {
                string uri = string.Format("Pick/GetTask/{0}", billNumber);
                var task = GlobalState.MyRestService.GetForObject<PickTask>(uri);
                CurrentTask = task;

                SetTaskMemo(task);
                BindDetailGrid(task);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
            GetPickTask();
        }

        private void GetPickTask()
        {
            string warehouseCode = GlobalState.CurrentWarehouse.WarehouseCode;

            try
            {
                string uri = string.Format("Pick/{0}/GetTasks", warehouseCode);
                var tasks = GlobalState.MyRestService.GetForObject<List<string>>(uri);
                cbPlanNumber.DataSource = tasks;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void PickForm_Step1_Load(object sender, EventArgs e)
        {
            SetTitle("拣货-选择拣货任务");
            GetPickTask();
        }

        private void SetTaskMemo(PickTask task)
        {
            string memo = string.Empty;
            memo = "关联单据号 : " + task.LinkBillNumber + "\r\n";
            memo = memo + "计划出库日期 : " + task.PlanIssueTime + "\r\n";
            memo = memo + "备注 : " + task.Remark + "\r\n";

            txtRemark.Text = memo;
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

