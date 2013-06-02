using System;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.Commands;
using Microsoft.Practices.CompositeUI.SmartParts;
using Microsoft.Practices.CompositeUI.WinForms;
using Modules.TagModule.Views;
using WCPierce.Practices.CompositeUI.WinForms;
using Wms.Common.Constants;

namespace Modules.TagModule
{
    public class SettingController: Controller
    {
        [CommandHandler("TagModule.ShowForm")]
        public void ShowTagListFormHandler(object sender, EventArgs e)
        {
            TagListForm form = WorkItem.Items.Get<TagListForm>("TagListForm");
            if (form == null)
            {
                form = WorkItem.Items.AddNew<TagListForm>("TagListForm");
                form.WorkItemController = this;
            }

            IWorkspace moduleWorkspace = WorkItem.Workspaces[WorkspaceNames.ContentWorkspace];
            
            ((TabbedDocumentWorkspace)moduleWorkspace).WorkItem = WorkItem;
            ((TabbedDocumentWorkspace)moduleWorkspace).O = form;

            TabSmartPartInfo smartPartInfo = new TabSmartPartInfo();
            smartPartInfo.Title = "标签维护";
            moduleWorkspace.Show(form, smartPartInfo);

        }
    }
}
