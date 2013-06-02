using System;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.Commands;
using Microsoft.Practices.CompositeUI.WinForms;
using Microsoft.Practices.CompositeUI.SmartParts;
using WCPierce.Practices.CompositeUI.WinForms;
using Modules.InboundPlanModule.Views;
using Wms.Common.Constants;
using Business.Common;
//using Modules.Inbound.Modules.InboundPlan;
using System.Windows.Forms;
using Business.Domain.Inventory;

namespace Modules.InboundPlanModule
{
    public class InboundPlanController:Controller
    {
        //[CommandHandler("InboundPlanModule.ShowForm")]
        //public void ShowInboundPlanListFormHandler(object sender, EventArgs e)
        //{
        //    bool newWindow = false;
        //    if (WorkItem.RootWorkItem.State["NEW_WINDOW"] != null)
        //        newWindow = true;

        //    InboundPlanEditForm list;

        //    if (newWindow)
        //    {
        //        list = WorkItem.Items.Get<InboundPlanEditForm>("InboundPlanEditForm" + DateTime.Now.ToString("yyyyMMddHHmmss"));
        //        if (list == null)
        //        {
        //            list = WorkItem.Items.AddNew<InboundPlanEditForm>("InboundPlanEditForm" + DateTime.Now.ToString("yyyyMMddHHmmss"));
        //            list.WorkItemController = this;
        //        }
        //    }
        //    else
        //    {
        //        list = WorkItem.Items.Get<InboundPlanEditForm>("InboundPlanEditForm");
        //        if (list == null)
        //        {
        //            list = WorkItem.Items.AddNew<InboundPlanEditForm>("InboundPlanEditForm");
        //            list.WorkItemController = this;
        //        }
        //    }

        //    TabSmartPartInfo smartPartInfo = new TabSmartPartInfo();
        //    string tipa = GlobalState.LanguageHelper.GetLanguageString("ReceivePlanListForm", "caption_ReceivePlanListForm_maintainment");
        //    smartPartInfo.Title = tipa;
        //    list.MasterOperationType = ecWMS.Template.ControlType.Read;

        //    IWorkspace moduleWorkspace = WorkItem.Workspaces[WorkspaceNames.ContentWorkspace];
        //    moduleWorkspace.Show(list, smartPartInfo);
        //    ((TabbedDocumentWorkspace)moduleWorkspace).WorkItem = WorkItem;
        //    ((TabbedDocumentWorkspace)moduleWorkspace).O = list;
        //}

        [CommandHandler("InboundPlanModule.ShowForm")]
        public void ShowInboundPlanListFormHander(object sender, EventArgs e)
        {
            //InboundPlan inboundPlan = null;
            //if (WorkItem.RootWorkItem.State["InboundPlan"] != null)
            //{
            //    inboundPlan = WorkItem.RootWorkItem.State["InboundPlan"] as InboundPlan;
            //}
            //else
            //    return;

            InboundPlanListForm form = WorkItem.Items.Get<InboundPlanListForm>("InboundPlanListForm");
            if (form == null)
            {
                form = WorkItem.Items.AddNew<InboundPlanListForm>("InboundPlanListForm");
                //form.WorkItemController = this;
            }

            TabSmartPartInfo smartPartInfo = new TabSmartPartInfo();
            //string tipa = GlobalState.LanguageHelper.GetLanguageString("ReceivePlanListForm", "caption_ReceivePlanListForm_maintainment");
            smartPartInfo.Title = "入库计划维护";

            IWorkspace moduleWorkspace = WorkItem.Workspaces[WorkspaceNames.ContentWorkspace];
            moduleWorkspace.Show(form, smartPartInfo);
            ((TabbedDocumentWorkspace)moduleWorkspace).WorkItem = WorkItem;
            ((TabbedDocumentWorkspace)moduleWorkspace).O = form;

        }


        //[CommandHandler("Modules.PrintLabel.ShowForm")]
        //public void ShowReceiveFormHandler(object sender, EventArgs e)
        //{
        //    PrintGoodsLabelForm printGoodsLabelForm = new PrintGoodsLabelForm();
        //    printGoodsLabelForm.FormBorderStyle = FormBorderStyle.FixedSingle;
        //    printGoodsLabelForm.CurrentInboundPlan = null;
        //    printGoodsLabelForm.ShowDialog();
        //}
    }
}



