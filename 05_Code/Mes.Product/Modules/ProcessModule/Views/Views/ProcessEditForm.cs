using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.ServiceModel;
using System.Windows.Forms;
using Business.Common.DataDictionary;
using Business.Common.Exception;
using Business.Common.QueryModel;
using Business.Domain.Application;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using Frame.Utils.Service;
using Framework.UI.Template.Common;
using Framework.UI.Template.Single;
using MES.BllService;
using MES.Entity;
using Wms.Common;

namespace Mes.Product.Modules.ProcessModule.Views
{
    public partial class ProcessEditForm : SingleEditForm
    {
        private IEntityService<Process> _entityService;

        public ProcessEditForm()
        {
            InitializeComponent();
        }

        public override void InitForm()
        {
            InitComboBox();

            if (CurrentData != null)
            {
                var process = CurrentData as Process;
                if (process != null)
                    BackupData = process.Clone() as Process;
            }
            _entityService = ServiceBloker.GetService<Process>();
            tcDetail.BackColor = BackColor;
        }


        private void InitComboBox()
        {
            // currency type
            var query = new Query();
            query.Criteria.Add(new Criterion("ProductStation", CriteriaOperator.Equal,
                                             DictionaryEnum.CURRENCY_TYPE.ToString()));
            query.Criteria.Add(new Criterion("DictionaryLevel", CriteriaOperator.Equal, 2));


            query.Criteria.Clear();
            query.Criteria.Add(new Criterion("ProductStation", CriteriaOperator.Equal,
                                             DictionaryEnum.INVOICE_TYPE.ToString()));
            query.Criteria.Add(new Criterion("DictionaryLevel", CriteriaOperator.Equal, 2));


            query.Criteria.Clear();
            //query.Criteria.Add(new Criterion("ProductStation", CriteriaOperator.Equal, DictionaryEnum.Process_TYPE.ToString()));
            query.Criteria.Add(new Criterion("DictionaryLevel", CriteriaOperator.Equal, 2));
            List<DataDictionary> processTypes = ServiceHelper.ApplicationService.GetDataDictionaryByQuery(query);
            ccbProcessType.Properties.DataSource = processTypes;
            ccbProcessType.Properties.DisplayMember = "DictionaryValue";
            ccbProcessType.Properties.ValueMember = "DictionaryId";
        }

        public override bool CreateData()
        {
            try
            {
                int newId = _entityService
                    .Save((Process) CurrentData);
                //if (_currentProcessTypes != string.Empty)
                //    ServiceHelper.BasicDataService.UpdateProcessType(
                //        ((Process) CurrentData).ProcessId, _currentProcessTypes);
                //CurrentData = ServiceHelper.BasicDataService.GetProcess(newId);
                //DataList.Add(CurrentData);
            }
            catch (FaultException<ServiceError> sex)
            {
                if (sex.Detail != null)
                    FormHelper.ShowWarningDialog(sex.Detail.ErrorMessage);

                return false;
            }

            return true;
        }

        public override bool UpdateData()
        {
            try
            {
                bool updateResult =
                    _entityService.Save((Process) CurrentData) > 0;
                //if (_currentProcessTypes != string.Empty)
                //    ServiceHelper.BasicDataService.UpdateProcessType(
                //        ((Process) CurrentData).ProcessId, _currentProcessTypes);

                return updateResult;
            }
            catch (FaultException<ServiceError> sex)
            {
                if (sex.Detail != null)
                    FormHelper.ShowWarningDialog(sex.Detail.ErrorMessage);

                return false;
            }
        }

        public override void SaveFormData()
        {
            Process process = null;
            switch (CurrentDataState)
            {
                case DataState.Create:
                    {
                        process = new Process();
                        //Process. = GlobalState.CurrentUser.UserId;
                        CurrentData = process;
                    }
                    break;
                case DataState.Update:
                    {
                        process = BackupData as Process;
                        //Process.EditUser = GlobalState.CurrentUser.UserId;
                        CurrentData = process;
                    }
                    break;
                case DataState.Copy:
                    {
                        //Process = BackupData as Process;
                        process = new Process();
                        //Process.CreateUser = GlobalState.CurrentUser.UserId;
                        CurrentData = process;
                    }
                    break;
            }

            if (process != null)
            {
                process.Code = txtProcessCode.Text.Trim();
                process.Name = txtProcessName.Text.Trim();
                //Process.Description = txtShortName.Text.Trim();
                //Process.ErpCode = txtErpCode.Text.Trim();


                if (beParentId.Tag != null)
                {
                    var parentProcess = beParentId.Tag as Process;
                    //if (parentProcess != null)
                    //    Process.ParentId = parentProcess.ProcessId;
                }
            }
        }

        public override void SetFormData()
        {
            var process = CurrentData as Process;
            if (process != null)
            {
                txtProcessCode.Text = process.Code;
                txtProcessName.Text = process.Name;
                //txtErpCode.Text = Process.ErpCode;
                //txtShortName.Text = Process.Description;
                //Processtype & parentID;
                //List<ProcessType> ProcessTypes =
                //    ServiceHelper.BasicDataService.GetProcessTypes(Process.ProcessId);
                //string itemValues = string.Empty;
                //foreach (ProcessType type in ProcessTypes)
                //{
                //    if (itemValues != string.Empty)
                //        itemValues = itemValues + "," + type.ProcessTypeId.ToString();
                //    else
                //        itemValues = type.ProcessTypeId.ToString();
                //}
                //ccbProcessType.SetEditValue(itemValues);


                //if (Process.ParentId > 0)
                //{
                //    Process parentProcess =
                //        ServiceHelper.BasicDataService.GetProcess(Process.ParentId);
                //    if (parentProcess != null)
                //    {
                //        beParentId.Text = parentProcess.ShortName;
                //        beParentId.Tag = parentProcess;
                //    }
                //}
            }
        }

        public override bool ValidateData()
        {
            Validator.Clear();

            bool result = true;

            if (txtProcessCode.Text.Trim() == string.Empty)
            {
                string tip = "请填写公司代码。";
                Validator.SetError(txtProcessCode, tip);
                result = false;
            }

            if (txtProcessName.Text.Trim() == string.Empty)
            {
                string tip = "请填写公司名称。";
                Validator.SetError(txtProcessName, tip);
                result = false;
            }

            if (txtShortName.Text.Trim() == string.Empty)
            {
                string tip = "请填写公司短名。";
                Validator.SetError(txtShortName, tip);
                result = false;
            }

            //if (ccbProcessType.SelectedText == string.Empty)
            //{
            //    string tip = "请选择公司类型。";
            //    Validator.SetError(ccbProcessType, tip);
            //    result = false;
            //}

            if (txtShortName.Text.Trim() == string.Empty)
            {
                string tip = "请填写公司短名。";
                Validator.SetError(txtShortName, tip);
                result = false;
            }


            return result;
        }

        public override void ClearFormData()
        {
            txtProcessCode.Text = string.Empty;
            txtProcessName.Text = string.Empty;
            txtErpCode.Text = string.Empty;
            txtShortName.Text = string.Empty;


            //Processtype & parentID;
            ccbProcessType.SetEditValue("");


            beParentId.Tag = null;
            beParentId.Text = string.Empty;
        }

        public override void SetInputStatus()
        {
            switch (CurrentDataState)
            {
                case DataState.Create:
                case DataState.Update:
                    {
                        gcBase.Enabled = true;

                        break;
                    }
            }
        }

        private void beParentId_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            Form parentForm = new XtraForm();
            parentForm.AutoSize = true;
            parentForm.StartPosition = FormStartPosition.CenterScreen;
            parentForm.ControlBox = false;
            parentForm.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            var form = new ProcessListForm(FormMode.Select, false)
                {
                    Size = new Size(810, 600),
                    Parent = parentForm,
                    ReferenceForm = parentForm
                };
            parentForm.ShowDialog();
            IList Processs = form.GetSelectedData<Process>();
            if (Processs == null || Processs.Count <= 0) return;
            var Process = Processs[0] as Process;
            beParentId.Tag = Process;
            //beParentId.Text = Process.Description;
        }
    }
}