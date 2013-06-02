using System;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.Commands;
using Microsoft.Practices.CompositeUI.SmartParts;
using Microsoft.Practices.CompositeUI.WinForms;
using Modules.SettingModule.Views;
using WCPierce.Practices.CompositeUI.WinForms;
using Wms.Common.Constants;

namespace Modules.SettingModule
{
    public class SettingController: Controller
    {
        [CommandHandler("SettingModule.ShowForm")]
        public void ShowSettingListFormHandler(object sender, EventArgs e)
        {
            SettingListForm form = WorkItem.Items.Get<SettingListForm>("SettingListForm");
            if (form == null)
            {
                form = WorkItem.Items.AddNew<SettingListForm>("SettingListForm");
                form.WorkItemController = this;
            }

            IWorkspace moduleWorkspace = WorkItem.Workspaces[WorkspaceNames.ContentWorkspace];
            
            ((TabbedDocumentWorkspace)moduleWorkspace).WorkItem = WorkItem;
            ((TabbedDocumentWorkspace)moduleWorkspace).O = form;

            TabSmartPartInfo smartPartInfo = new TabSmartPartInfo();
            smartPartInfo.Title = "设置维护";
            moduleWorkspace.Show(form, smartPartInfo);

        }
    }
}
