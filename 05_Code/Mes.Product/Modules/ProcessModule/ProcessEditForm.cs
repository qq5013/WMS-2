using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.ServiceModel;
using System.Windows.Forms;
using Business.Common.Exception;
using Frame.Utils.Service;
using Framework.Core.Collections;
using Framework.UI.Template.Common;
using Framework.UI.Template.MasterDetail;
using MES.BllService;
using MES.Common;
using MES.Entity;

namespace Mes.Product.Modules.ProcessModule
{
    public partial class ProcessEditForm : MasterEditForm
    {
        private List<EntitySetting<ProcessStep>> _detailSettings;

        private List<EntitySetting<Process>> _settings;

        public IList<ProcessStepModel> listLocalData = new List<ProcessStepModel>();

        public ProcessEditForm()
        {
            InitializeComponent();
        }

        public IEntityService<Process> Service
        {
            get { return ServiceBloker.GetService<Process>(); }
        }

        public IEntityService<ProcessStep> DeatilService
        {
            get { return ServiceBloker.GetService<ProcessStep>(); }
        }


        public override void FormInitialize()
        {
            RegisterDetailForm(typeof (ProcessDetailEditForm).FullName);

            _settings = new List<EntitySetting<Process>>()
                .Setting(c => c.Code, new EntitySetting
                    {
                        Name = "工序代码",
                        Width = 100,
                        Control = teCode
                    })
                .Setting(c => c.Name, new EntitySetting
                    {
                        Name = "工序名称",
                        Width = 100,
                        Control = teName
                    })
                .Setting(c => c.ProductId, new EntitySetting
                    {
                        Name = "产品代码",
                        Width = 100,
                        Control = lueProduct.BindProduct(ControlMode.Edit)
                    })
                .Setting(c => c.ImageData, new EntitySetting
                    {
                        Name = "工序图片",
                        Width = 100,
                        IsShow = false,
                        Control = pictureEdit1
                    })
                .Setting(c => c.ProductLineId, new EntitySetting
                    {
                        Name = "产线代码",
                        Width = 100,
                        Control = lueProductLine.BindProductLine(ControlMode.Edit)
                    })
                .Setting(c => c.ProductStationIds, new EntitySetting
                    {
                        Name = "对应工位",
                        Width = 100,
                        Control = checkedComboBoxEdit1.BindProductStation(ControlMode.Edit)
                    })
                .Setting(c => c.Memo, new EntitySetting
                    {
                        Name = "描述",
                        Width = 100,
                        Control = meRemark
                    });


            _detailSettings = new List<EntitySetting<ProcessStep>>()
                .Setting(c => c.SkuId, new EntitySetting
                    {
                        Name = "物料代码",
                        Width = 100,
                    })
                .Setting(c => c.Quantity, new EntitySetting
                    {
                        Name = "数量",
                        Width = 100,
                    })
                .Setting(c => c.MeasureId, new EntitySetting
                    {
                        Name = "单位",
                        Width = 100,
                    })
                .Setting(c => c.Description, new EntitySetting
                    {
                        Name = "装配指导",
                        Width = 100
                    })
                .Setting(c => c.Sequence, new EntitySetting
                    {
                        Name = "装配顺序",
                        Width = 100
                    })
                .Setting(c => c.Remark, new EntitySetting
                    {
                        Name = "描述",
                        Width = 100
                    });


            base.FormInitialize();
        }

        public override void InitInputControlData()
        {
        }

        public override void InitToolButtons()
        {
            //btnCancelBill.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            //btnAdditionButton.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            //btnAdditionButton.Caption = @"导出工序";

            //btnImport.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            //btnImport.Caption = @"打印货物条码";

            //btnConfirm.Visibility = BarItemVisibility.Always;
            //btnConfirm.Caption = @"审核";

            //btnRevoke.Visibility = BarItemVisibility.Always;
            //btnPrint.Visibility = BarItemVisibility.Always;

            //btnAdditionButton.Visibility = BarItemVisibility.Always;
            //btnAdditionButton.Caption = "打印条码标签";
        }

        public override void AdditionButtonClick()
        {
            //base.AdditionButtonClick();
            var plan = CurrentMasterData as Process;
            if (plan != null)
            {
            }
        }

        public override void SetToolButtons()
        {
            base.SetToolButtons();

            // 判读当前单据状态是否可以审核
            var plan = CurrentMasterData as Process;
            if (plan != null)
            {
                //DataDictionary dictionary = ServiceHelper.ApplicationService.GetDataDictionary(plan.BillStatus);
                //if (dictionary != null)
                //{
                //    if (dictionary.DictionaryCode != DictionaryHelper.ConvertToDictionaryCode((int)ProcessStatus.Created) && dictionary.DictionaryCode != DictionaryHelper.ConvertToDictionaryCode((int)ProcessStatus.Modified))
                //    {
                //        btnConfirm.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                //        btnUpdateMaster.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                //    }

                //    if (dictionary.DictionaryCode != DictionaryHelper.ConvertToDictionaryCode((int)ProcessStatus.Created) && dictionary.DictionaryCode != DictionaryHelper.ConvertToDictionaryCode((int)ProcessStatus.Modified)
                //        && dictionary.DictionaryCode != DictionaryHelper.ConvertToDictionaryCode((int)ProcessStatus.Confirmed))
                //    {
                //        btnRevoke.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                //    }
                //}
            }
        }

        public override bool ConfirmData()
        {
            if (CurrentMasterData != null)
            {
                var plan = CurrentMasterData as Process;

                if (plan != null)
                {
                    try
                    {
                        //bool comfirmResult = Service.ConfirmProcess(GlobalState.CurrentWarehouse.WarehouseId, plan.PlanId, GlobalState.CurrentUser.UserId);

                        //if (comfirmResult)
                        //{
                        //    CurrentMasterData = Service.GetProcess(plan.PlanId);
                        //    SetMainData();
                        //    btnConfirm.Enabled = false;
                        //    btnUpdateMaster.Enabled = false;
                        //}
                    }
                    catch (FaultException<ServiceError> sex)
                    {
                        sex.Process();
                        if (sex.Detail != null)
                            FormHelper.ShowWarningDialog(sex.Detail.ErrorMessage);
                    }
                }
            }
            return true;
        }

        public override void SetMainDataInputStatus()
        {
            switch (MasterDataState)
            {
                case DataState.Read:
                    {
                        btnConfirm.Enabled = true;
                        btnPrint.Enabled = true;
                        btnRevoke.Enabled = true;
                        break;
                    }
                case DataState.Create:
                    {
                        btnConfirm.Enabled = false;
                        btnPrint.Enabled = false;
                        btnRevoke.Enabled = false;
                        break;
                    }
                case DataState.Update:
                    {
                        btnConfirm.Enabled = false;
                        btnPrint.Enabled = false;
                        btnRevoke.Enabled = false;
                        break;
                    }
            }
        }

        public override void InitAuthority()
        {
            //btnInsertMaster.Tag = "Process_INSERT";
            //btnUpdateMaster.Tag = "Process_EDIT";
            //btnQueryMaster.Tag = "Process_QUERY";
        }

        public override void RevokeData()
        {
            if (CurrentMasterData != null)
            {
                var plan = CurrentMasterData as Process;

                if (plan != null)
                {
                    try
                    {
                        //bool revokeResult = Service.RevokeProcess(GlobalState.CurrentWarehouse.WarehouseId, plan.PlanId, GlobalState.CurrentUser.UserId);

                        //if (revokeResult)
                        //{
                        //    CurrentMasterData = Service.GetProcess(plan.PlanId);
                        //    SetMainData();
                        //    btnRevoke.Enabled = false;
                        //    btnUpdateMaster.Enabled = false;
                        //}
                    }
                    catch (FaultException<ServiceError> sex)
                    {
                        sex.Process();
                        if (sex.Detail != null)
                            FormHelper.ShowWarningDialog(sex.Detail.ErrorMessage);
                    }
                }
            }
        }

        public override void LoadDetailData()
        {
            if (CurrentMasterData == null) return;

            var plan = CurrentMasterData as Process;
            if (plan != null)
            {
                List<ProcessStep> details = DeatilService.FindAll(c => c.ProcessId == plan.ProcessId);

                listLocalData = ObjCopyToLocal(details);
                DetailDataList = CollectionHelper.ToArrayList(listLocalData);
                BindDetailGrid();
                BindGridColumnMap();
            }
        }

        public override void ClearMainDataControl()
        {
            _settings.ClearValue();
        }

        public override void ReloadData()
        {
            if (CurrentMasterData != null)
            {
                var process = CurrentMasterData as Process;
                if (process != null) CurrentMasterData = Service.GetById(process.ProcessId);

                LoadDetailData();
            }
        }

        public override void SetMainData()
        {
            if (CurrentMasterData != null)
            {
                var process = CurrentMasterData as Process;

                if (process != null)
                {
                    Text = string.Format(" 工序 - {0}", process.Code);


                    _settings.DataFromEntity(process);
                }
            }
        }


        public override void SaveData()
        {
            Process plan = null;
            if (MasterDataState == DataState.Create)
            {
                plan = new Process();
            }
            if (MasterDataState == DataState.Update)
            {
                plan = CurrentMasterData as Process;
            }

            if (plan != null)
            {
                _settings.DataToEntity(plan);

                if (MasterDataState == DataState.Create)
                {
                    if (Service.Save(plan) == 0)
                    {
                        FormHelper.ShowErrorDialog("创建工序失败。");
                        return;
                    }
                }
                if (MasterDataState == DataState.Update)
                {
                    bool updateResult = Service.Save(plan) > 0;
                    if (!updateResult)
                    {
                        FormHelper.ShowErrorDialog("更新工序失败。");
                        return;
                    }
                }

                CurrentMasterData = plan;
                SetMainData();
            }

            if (plan != null)
            {
                foreach (ProcessStepModel localInfo in listLocalData)
                {
                    switch (localInfo.OperationName)
                    {
                        case "ADD":
                            {
                                localInfo.ProcessId = plan.ProcessId; //改成主键
                                int newID = DeatilService.Save(
                                    ObjCopyToParent(
                                        localInfo));
                                if (newID <= 0)
                                {
                                    throw new Exception();
                                }
                                localInfo.OperationName = "NONE";
                                localInfo.ProcessStepId = newID;
                                break;
                            }
                        case "EDIT":
                            {
                                bool updateResult =
                                    DeatilService.Save(ObjCopyToParent(localInfo)) > 0;
                                if (!updateResult)
                                {
                                    throw new Exception();
                                }
                                localInfo.OperationName = "NONE";
                                break;
                            }
                        case "DELETE":
                            {
                                bool deleteResult =
                                    Service.Delete(
                                        ObjCopyToParent(localInfo).GetEntityId()) > 0;
                                if (!deleteResult)
                                {
                                    throw new Exception();
                                }
                                break;
                            }

                            //case "NONE":
                            //    {
                            //        bool updateResult = GenericServiceHelper.Update<ProcessDetail>(out bllResult, ObjCopyToParent(localInfo));
                            //        if (!updateResult)
                            //        {
                            //            throw new Exception();
                            //        }
                            //        break;
                            //    }
                    }
                }
            }

            if (MasterDataState == DataState.Create)
            {
                listLocalData.Clear();
            }

            CountData();
        }

        public override void DeleteLocalData()
        {
            if (CurrentDetailData == null) return;

            var localInfo = CurrentDetailData as ProcessStepModel;

            DetailDataList.Remove(localInfo);

            if (localInfo != null)
                if (localInfo.OperationName == "ADD")
                {
                    listLocalData.Remove(localInfo);
                }
                else
                {
                    localInfo.OperationName = "DELETE";
                    listLocalData[localInfo.TempId] = localInfo;
                }
        }

        public override bool ValidateUpdateOperation()
        {
            var plan = CurrentMasterData as Process;
            if (plan != null)
            {
            }

            return true;
        }

        public override bool ValidateMainData()
        {
            return _settings.Validate(Validator);
        }

        public override void CustomizeDetailGrid()
        {
            _detailSettings.SetGridColumn(DetailGridView);
        }

        /// <summary>
        ///     将本地对象的数据拷贝到远程对象
        /// </summary>
        private ProcessStep ObjCopyToParent(ProcessStepModel localInfo)
        {
            var info = new ProcessStep();

            Type ts = typeof (ProcessStepModel);
            Type t = typeof (ProcessStep);
            PropertyInfo[] pis = t.GetProperties();
            for (int i = 0, j = pis.Length; i < j; i++)
            {
                PropertyInfo pi = ts.GetProperty(pis[i].Name);
                try
                {
                    pis[i].SetValue(info, pi.GetValue(localInfo, null), null);
                }
                catch (Exception ex)
                {
                    
                    ex.Process();
                }
            }
            return info;
        }

        private IList<ProcessStepModel> ObjCopyToLocal(IList<ProcessStep> entyInfoList)
        {
            IList<ProcessStepModel> list = new List<ProcessStepModel>();

            Type ts = typeof (ProcessStep);
            PropertyInfo[] pis = ts.GetProperties();

            Type t = typeof (ProcessStepModel);

            for (int c = 0, count = entyInfoList.Count; c < count; c++)
            {
                var info = new ProcessStepModel();

                for (int i = 0, j = pis.Length; i < j; i++)
                {
                    PropertyInfo pi = t.GetProperty(pis[i].Name);
                    try
                    {
                        pi.SetValue(info, pis[i].GetValue(entyInfoList[c], null), null);
                    }
                    catch (Exception ex)
                    {
                        ex.Process();
                    }
                }
                info.TempId = c;
                info.OperationName = "NONE";
                list.Add(info);
            }

            return list;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            switch (dialog.ShowDialog())
            {
                case DialogResult.None:
                    break;
                case DialogResult.OK:
                    var process = CurrentMasterData as Process;

                    using (var reader = new FileStream(dialog.FileName, FileMode.Open, FileAccess.Read))
                    {
                        var bytes = new byte[reader.Length];
                        reader.Read(bytes, 0, bytes.Length);
                        process.ImageData = bytes;
                        pictureEdit1.EditValue = process.ImageData;
                    }

                    break;
                case DialogResult.Cancel:
                    break;
                case DialogResult.Abort:
                    break;
                case DialogResult.Retry:
                    break;
                case DialogResult.Ignore:
                    break;
                case DialogResult.Yes:
                    break;
                case DialogResult.No:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}