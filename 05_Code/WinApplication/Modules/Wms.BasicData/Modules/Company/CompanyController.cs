using System;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.WinForms;
using Microsoft.Practices.CompositeUI.SmartParts;
using Microsoft.Practices.CompositeUI.Commands;
using WCPierce.Practices.CompositeUI.WinForms;
using Wms.Common.Constants;
using Modules.CompanyModule.Views;
using Business.Common;

namespace Modules.CompanyModule
{
    public class CompanyController:Controller
    {
        [CommandHandler("CompanyModule.ShowForm")]
        public void ShowCompanyListFormHandler(object sender, EventArgs e)
        {
            CompanyListForm list = WorkItem.Items.Get<CompanyListForm>("CompanyListForm");
            if (list == null)
            {
                list = WorkItem.Items.AddNew<CompanyListForm>("CompanyListForm");
                list.WorkItemController = this;
            }

            TabSmartPartInfo smartPartInfo = new TabSmartPartInfo();
            //string tipa = GlobalState.LanguageHelper.GetLanguageString("company", "company_info_maintainment_tip");
            smartPartInfo.Title = "公司维护";

            IWorkspace moduleWorkspace = WorkItem.Workspaces[WorkspaceNames.ContentWorkspace];
            moduleWorkspace.Show(list, smartPartInfo);
            ((TabbedDocumentWorkspace)moduleWorkspace).WorkItem = WorkItem;
            ((TabbedDocumentWorkspace)moduleWorkspace).O = list;
        }

    }
}



