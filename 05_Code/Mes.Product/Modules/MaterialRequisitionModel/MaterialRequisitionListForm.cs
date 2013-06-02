using System.Collections.Generic;
using System.ServiceModel;
using Business.Common.Exception;
using Business.Domain.Application;
using DevExpress.XtraEditors.Repository;
using Frame.Utils.RelaAndCondition;
using Frame.Utils.Service;
using Framework.UI.Template.Common;
using Framework.UI.Template.MasterDetail;
using MES.BllService;
using MES.Common;
using MES.Entity;
using Microsoft.Practices.CompositeUI.SmartParts;
using Wms.Common;

namespace Mes.Product.Modules.MaterialRequisitionModel
{
    /// <summary>
    /// 领料单列表
    /// </summary>
    [SmartPart]
    public partial class MaterialRequisitionListForm : MasterListForm
    {
        private Condition _condition;

        private IEntityService<MaterialRequisition> _service;

        private List<EntitySetting<MaterialRequisition>> _settings;

        public MaterialRequisitionListForm()
        {
            InitializeComponent();
        }

        public MaterialRequisitionListForm(FormMode mode, bool isMultiSelect)
            : base(mode, isMultiSelect)
        {
            InitializeComponent();
        }


        public override bool ValidateUpdateAuthority()
        {
            var bill = CurrentData as MaterialRequisition;
            if (bill != null)
            {
                DataDictionary dictionary = ServiceHelper.ApplicationService.GetDataDictionary((int) bill.Status);

                if (dictionary != null)
                {
                    //if (dictionary.DictionaryCode !=
                    //    DictionaryHelper.ConvertToDictionaryCode((int) MaterialRequisitionStatus.Created) &&
                    //    dictionary.DictionaryCode !=
                    //    DictionaryHelper.ConvertToDictionaryCode((int) MaterialRequisitionStatus.Finished))
                    //{
                    //    FormHelper.ShowWarningDialog("此生产计划当前状态不允许被编辑。");
                    //    return false;
                    //}
                }
            }
            return true;
        }

        public override void InitButtonAuthority()
        {
            //btnAdd.Tag = "INBOUNDPLAN_INSERT";
            //btnUpdate.Tag = "INBOUNDPLAN_EDIT";
        }


        public override void FormInitialize()
        {
            RegisterDetailForm(typeof (MaterialRequisitionEditForm).FullName);

            // TODO: 领料单区分车间，通过备注传给仓库

            _service = ServiceBloker.GetService<MaterialRequisition>();
            _settings = new List<EntitySetting<MaterialRequisition>>()
                .Setting(c => c.CustomerName, new EntitySetting
                    {
                        Name = "客户",
                        Width = 100,
                        Control = beCustomer.BindCustomer(),
                        ColumnEdit = new RepositoryItemLookUpEdit().BindUser() 
                    })
                .Setting(c => c.OrderDate, new EntitySetting
                    {
                        Name = "订购日期",
                        Width = 100,
                        Control = deOrderDate
                    })
                .Setting(c => c.DeliveryDate, new EntitySetting
                    {
                        Name = "交货日期",
                        Width = 100,
                        Control = deDeliveryDate
                    })
                .Setting(c => c.CreaterId, new EntitySetting
                    {
                        Name = "制单人",
                        Width = 100,
                        Control = lueCreateId.BindUser(),
                        ColumnEdit = new RepositoryItemLookUpEdit().BindUser() 
                    })
                .Setting(c => c.CreateTime, new EntitySetting
                    {
                        Name = "制单日期",
                        Width = 100,
                        Control = deCreateTime
                    })
                
                .Setting(c => c.Remark, new EntitySetting
                    {
                        Name = "备注",
                        Width = 100,
                        Control = meRemark
                    });
        }

        public override void SetButtonStatus()
        {
            base.SetButtonStatus();

            var member = "领料单";
            btnAdd.Caption = string.Format("新增{0}", member);
            btnUpdate.Caption = string.Format("编辑{0}", member);
        }

        public override void LoadData()
        {
            QueryData(PageSize, PageNumber);
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
                int totalCount = _service.GetCount(query);
                DataList = _service.GetList(query, (pageNumber - 1)*pageSize, pageSize);
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