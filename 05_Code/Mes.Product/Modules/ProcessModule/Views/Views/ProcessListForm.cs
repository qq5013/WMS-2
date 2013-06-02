using System;
using System.Collections.Generic;
using System.ServiceModel;
using Business.Common.Exception;
using Frame.Utils.MetaDB;
using Frame.Utils.RelaAndCondition;
using Frame.Utils.Service;
using Framework.UI.Template.Common;
using Framework.UI.Template.MasterDetail;
using MES.BllService;
using MES.Entity;
using Microsoft.Practices.CompositeUI.SmartParts;

namespace Mes.Product.Modules.ProcessModule.Views
{
    [SmartPart]
    public partial class ProcessListForm : MasterListForm
    {
        private readonly List<EntitySetting<Process>> _settings =
            new List<EntitySetting<Process>>();

        private Condition _condition;

        private IEntityService<Process> _service;

        public ProcessListForm()
        {
            InitializeComponent();
        }

        public ProcessListForm(FormMode mode, bool isMultiSelect)
            : base(mode, isMultiSelect)
        {
            InitializeComponent();
        }

        public override void FormInitialize()
        {
//            ��������	
//�������	
//��Ʒ����	����ѡ��������Ʒ
//����ͼƬ	�ϴ�
//���ߴ���	����ѡ��
//��Ӧ��λ	���Զ�ѡ
//����	


            _settings
                .Setting(c => c.Code, new EntitySetting
                    {
                        Name = "�������",
                        Width = 100,
                        IsShow = true,
                        Control = txtProcessCode
                    })
                .Setting(c => c.Name, new EntitySetting
                    {
                        Name = "��������",
                        Width = 100,
                        IsShow = true,
                        Control = txtProcessName
                    })
                .Setting(c => c.ProductId, new EntitySetting
                    {
                        Name = "��Ʒ����",
                        Width = 100,
                        IsShow = true,
                        Control = txtProcessName
                    })
                .Setting(c => c.ImageData, new EntitySetting
                    {
                        Name = "����ͼƬ",
                        Width = 100,
                        IsShow = false,
                        Control = null
                    })
                .Setting(c => c.IsStepByStep, new EntitySetting
                    {
                        Name = "˳��ִ��",
                        Width = 100,
                        IsShow = true,
                        Control = null
                    })
                .Setting(c => c.Memo, new EntitySetting
                    {
                        Name = "����",
                        Width = 100,
                        IsShow = true,
                        Control = null
                    });

            // BOM��Ϣά��
//            �ֶ���	˵��	��ע
//���ϴ���	����ѡ��	
//����		
//��λ		
//װ��ָ��	����˵������	���Ұ��߳���
//װ��˳��	��������	
//����		


            _service = ServiceBloker.GetService<Process>();
            RegisterDetailForm(typeof (ProcessEditForm).FullName);
        }

        public override void InitButtonAuthority()
        {
            //btnCopy.Tag = "Process_INSERT";
            //btnInsert.Tag = "Process_INSERT";
            //btnUpdate.Tag = "Process_EDIT";
            //btnDelete.Tag = "Process_DELETE";
            //btnSearch.Tag = "Process_QUERY";
        }

        public override void LoadData()
        {
            try
            {
                var query = new QueryInfo {Condition = _settings.Condition(_condition)};
                int totalCount = _service.GetCount(query);
                DataList = _service.GetList(query, (PageNumber - 1)*PageSize, PageSize);
                SetSplitPage(totalCount);
                BindData();
            }
            catch (Exception ex)
            {
                ex.Process();
            }
        }

        public override void CustomizeGrid()
        {
            _settings.SetGridColumn(MasterGridView);
        }

        public override void SetQueryConditions()
        {
            _condition = null;
            var entity = new Entity<Process>();
            _settings.ForEach(s =>
                {
                    if (s.Control.Text.Trim() != "")
                    {
                        _condition = _condition & entity.Column(c => c.Code) == txtProcessCode.Text;
                    }
                });
        }

        public override void QueryData(int pageSize, int pageNumber)
        {
            try
            {
                var query = new QueryInfo();

                int totalCount = _service.GetCount(query);
                DataList = _service.GetList(query, (pageNumber - 1)*pageSize, pageSize);
                BindData();
            }
            catch (FaultException<ServiceError> sex)
            {
                sex.Process();
                if (sex.Detail != null)
                    FormHelper.ShowWarningDialog(sex.Detail.ErrorMessage);
            }
        }

        public void DeleteData()
        {
            var process = CurrentData as Process;
            if (process == null) return;

            bool deleteResult = false;
            try
            {
                deleteResult = _service.Delete(process.ProcessId) > 0;
            }
            catch (FaultException<ServiceError> sex)
            {
                if (sex.Detail != null)
                    FormHelper.ShowWarningDialog(sex.Detail.ErrorMessage);
            }

            if (deleteResult)
                FormHelper.ShowInformationDialog("ɾ������ɹ���");
        }
    }
}