using System;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.WinForms;
using Microsoft.Practices.CompositeUI.SmartParts;
using Microsoft.Practices.CompositeUI.Commands;
using WCPierce.Practices.CompositeUI.WinForms;
using Wms.Common.Constants;
using Modules.DataDictionaryModule.Views;

namespace Modules.DataDictionaryModule
{
    public class DataDictionaryController: Controller
    {
        [CommandHandler("DataDictionaryModule.ShowForm")]
        public void ShowDataDictionaryFormHandler(object sender, EventArgs e)
        {
            var listForm = WorkItem.Items.Get<DataDictionaryForm>("DataDictionaryForm");
            if (listForm == null)
            {
                listForm = WorkItem.Items.AddNew<DataDictionaryForm>("DataDictionaryForm");
                listForm.WorkItemController = this;
            }

            var smartPartInfo = new TabSmartPartInfo();
            //string tipa = GlobalState.LanguageHelper.GetLanguageString("DataDictionary", "data_DataDictionary_maintainment_tip");
            smartPartInfo.Title = "Êý¾Ý×ÖµäÎ¬»¤";

            var moduleWorkspace = WorkItem.Workspaces[WorkspaceNames.ContentWorkspace];
            moduleWorkspace.Show(listForm, smartPartInfo);
            ((TabbedDocumentWorkspace)moduleWorkspace).WorkItem = WorkItem;
            ((TabbedDocumentWorkspace)moduleWorkspace).O = listForm;
        }
    }
}
