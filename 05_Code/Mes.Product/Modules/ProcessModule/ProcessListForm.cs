using System.Collections.Generic;
using System.ServiceModel;
using Business.Common.Exception;
using DevExpress.XtraEditors.Repository;
using Frame.Utils.RelaAndCondition;
using Frame.Utils.Service;
using Framework.UI.Template.Common;
using Framework.UI.Template.MasterDetail;
using MES.BllService;
using MES.Common;
using MES.Entity;
using Microsoft.Practices.CompositeUI.SmartParts;

namespace Mes.Product.Modules.ProcessModule
{
    [SmartPart]
    public partial class ProcessListForm : MasterListForm
    {
        private Condition _condition;

        private List<EntitySetting<Process>> _settings;

        public ProcessListForm()
        {
            InitializeComponent();
        }

        public ProcessListForm(FormMode mode, bool isMultiSelect)
            : base(mode, isMultiSelect)
        {
            InitializeComponent();
        }

        public ProcessListForm(FormMode mode, bool isMultiSelect, bool isInvoice)
            : base(mode, isMultiSelect)
        {
            InitializeComponent();
        }

        public IEntityService<Process> Service
        {
            get { return ServiceBloker.GetService<Process>(); }
        }

        public override bool ValidateUpdateAuthority()
        {
            var plan = CurrentData as Process;
            if (plan != null)
            {
            }
            return true;
        }

        public override void InitButtonAuthority()
        {
            //btnAdd.Tag = "Process_INSERT";
            //btnUpdate.Tag = "Process_EDIT";
        }


        public override void FormInitialize()
        {
            RegisterDetailForm(typeof (ProcessEditForm).FullName);
            _settings = new List<EntitySetting<Process>>()
                .Setting(c => c.Name, new EntitySetting
                    {
                        Name = "工序名称",
                        Width = 100,
                        Control = teName
                    })
                .Setting(c => c.Code, new EntitySetting
                    {
                        Name = "工序代码",
                        Width = 100,
                        Control = teCode
                    })
                .Setting(c => c.ProductId, new EntitySetting
                    {
                        Name = "产品代码",
                        Width = 100,
                        Control = lueProduct.BindProduct(),
                        ColumnEdit = new RepositoryItemLookUpEdit().BindProduct()
                    })
               
                .Setting(c => c.ProductLineId, new EntitySetting
                    {
                        Name = "产线代码",
                        Width = 100,
                        Control = lueProductLine.BindProductLine(),
                        ColumnEdit = new RepositoryItemLookUpEdit().BindProductLine()
                    })
                .Setting(c => c.ProcessId, new EntitySetting
                    {
                        Name = "对应工位",
                        Width = 100,
                        Control = lueProductStation.BindProductStation(),
                        ColumnEdit = new RepositoryItemLookUpEdit().BindProductStation()
                    })
                .Setting(c => c.Memo, new EntitySetting
                    {
                        Name = "描述",
                        Width = 100,
                        Control = meRemark
                    });
        }

        public override void SetButtonStatus()
        {
            base.SetButtonStatus();

            btnAdd.Caption = "新增工序";
            btnUpdate.Caption = "编辑工序";
        }

        public override void LoadData()
        {
            try
            {
                _condition = null;
                var query = new QueryInfo
                    {
                        Condition = _settings.Condition(_condition),
                    };
                int totalCount = Service.GetCount(query);
                DataList = Service.GetList(query, (PageNumber - 1)*PageSize, PageSize);
                SetSplitPage(totalCount);
                BindData();
            }
            catch (FaultException<ServiceError> sex)
            {
                sex.Process();
                if (sex.Detail != null)
                    FormHelper.ShowWarningDialog(sex.Detail.ErrorMessage);
            }
        }


        public override void QueryData(int pageSize, int pageNumber)
        {
            try
            {
                _condition = null;
                var query = new QueryInfo
                    {
                        Condition = _settings.Condition(_condition),
                    };
                int totalCount = Service.GetCount(query);
                DataList = Service.GetList(query, (pageNumber - 1)*pageSize, pageSize);
                SetSplitPage(totalCount);
                BindData();
            }
            catch (FaultException<ServiceError> sex)
            {
                sex.Process();
                if (sex.Detail != null)
                    FormHelper.ShowWarningDialog(sex.Detail.ErrorMessage);
            }
        }

        public override void CustomizeGrid()
        {
            _settings.SetGridColumn(MasterGridView);
        }
    }
}