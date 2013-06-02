using System;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.Commands;
using Microsoft.Practices.CompositeUI.SmartParts;
using Microsoft.Practices.CompositeUI.WinForms;
using Modules.ParameterModule.Views;
using WCPierce.Practices.CompositeUI.WinForms;
using Wms.Common.Constants;

namespace Modules.ParameterModule
{
    public class ParameterController: Controller
    {
        [CommandHandler("ParameterModule.ShowForm")]
        public void ShowParameterListFormHandler(object sender, EventArgs e)
        {
            var form = WorkItem.Items.Get<ParameterListForm>("ParameterListForm");
            if (form == null)
            {
                form = WorkItem.Items.AddNew<ParameterListForm>("ParameterListForm");
                form.WorkItemController = this;
            }

            var moduleWorkspace = WorkItem.Workspaces[WorkspaceNames.ContentWorkspace];
            ((TabbedDocumentWorkspace)moduleWorkspace).WorkItem = WorkItem;
            ((TabbedDocumentWorkspace)moduleWorkspace).O = form;

            var smartPartInfo = new TabSmartPartInfo {Title = "参数维护"};
            moduleWorkspace.Show(form, smartPartInfo);
        }
    }
}
