using System;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.Commands;
using WCPierce.Practices.CompositeUI.WinForms;
using Wms.Common.Constants;


namespace Modules.SidebarModule.Views
{
    public partial class SideBarView : UserControl, IDockableSmartPart 
    {
        /// ADDED
        private static readonly Guid dspGuid = new Guid("{B69E82F9-5FA2-4309-8FC0-0F421D12F0EB}");
        ///

        public SideBarView()
        {
            InitializeComponent();
        }

        /// ADDED
        #region IDockableSmartPart Members

        Guid IDockableSmartPart.Guid
        {
            get { return dspGuid; }
        }

        public WorkItem MyWorkItem = null;

        #endregion

        private void SideBarView_Load(object sender, EventArgs e)
        {
            // init main form menu 
            InitMenu();
            
            LoadApplicationTree();

            MyWorkItem.RootWorkItem.Items.Add(tvNavigator, "Navigator");
            // init command
        }

        [CommandHandler("Modules.Sidebar.InitMenu")]
        private void InitMenu()
        {
            string languageCode = "zh-CHS";// GlobalState.LanguageHelper.LanguageCode;

            string configFile = Application.StartupPath + @"\Configuration\Application.config.{0}.xml";
            configFile = String.Format(configFile, languageCode);

            ApplicationMenus.ApplicationConfig config = new ApplicationMenus.ApplicationConfig();

            config = (ApplicationMenus.ApplicationConfig)ReadXmlFile(config, configFile);

            MenuStrip mainMenu = MyWorkItem.RootWorkItem.Items.Get(UIExtensionConstants.Mainmenu) as MenuStrip;

            ApplicationMenus.ApplicationConfigMainMenuMenuGroup[] groups = config.MainMenu;

            foreach (ApplicationMenus.ApplicationConfigMainMenuMenuGroup group in groups)
            {
                ApplicationMenus.ApplicationConfigMainMenuMenuGroupMenu[] menus = group.Menu;

                ToolStripMenuItem item = new ToolStripMenuItem();
                item.Text = group.Caption;
                mainMenu.Items.Add(item);

                foreach (ApplicationMenus.ApplicationConfigMainMenuMenuGroupMenu menu in menus)
                {
                    ToolStripMenuItem subItem = new ToolStripMenuItem();
                    subItem.Text = menu.Caption;
                    subItem.Tag = menu;
                    subItem.Click += new EventHandler(this.SubMenu_Click);
                    item.DropDownItems.Add(subItem);
                }
            }
        }


        ///
        [CommandHandler("Modules.Sidebar.InitTree")]
        private void LoadApplicationTree()
        {
            string languageCode = "zh-CHS";// GlobalState.LanguageHelper.LanguageCode;

            string configFile = Application.StartupPath + @"\Configuration\Application.config.{0}.xml";
            configFile = String.Format(configFile, languageCode);

            ApplicationMenus.ApplicationConfig config = new ApplicationMenus.ApplicationConfig();

            config = (ApplicationMenus.ApplicationConfig)ReadXmlFile(config, configFile);

            tvNavigator.Nodes.Clear();
            TreeNode rootNode = tvNavigator.Nodes.Add(config.ApplicationName);
            rootNode.ImageIndex = 0;
            rootNode.SelectedImageIndex = 0;

            ApplicationMenus.ApplicationConfigMainMenuMenuGroup[] groups = config.MainMenu;

            foreach (ApplicationMenus.ApplicationConfigMainMenuMenuGroup group in groups)
            {
                ApplicationMenus.ApplicationConfigMainMenuMenuGroupMenu[] menus = group.Menu;

                TreeNode groupNode = rootNode.Nodes.Add(group.ID, group.Caption);
                groupNode.ImageIndex = 1;
                groupNode.SelectedImageIndex = 2;
                groupNode.Tag = group;

                foreach (ApplicationMenus.ApplicationConfigMainMenuMenuGroupMenu menu in menus)
                {
                    TreeNode menuNode = groupNode.Nodes.Add(menu.ID, menu.Caption);
                    menuNode.ImageIndex = 3;
                    menuNode.SelectedImageIndex = 4;
                    menuNode.Tag = menu;
                }
            }

            rootNode.Expand();
            tvNavigator.SelectedNode = tvNavigator.Nodes[0];
        }

        /// <summary>
        /// Read XML File 
        /// </summary>
        /// <param name="type">Class Type</param>
        /// <param name="xmlDocumentUrl">XML File Url</param>
        /// <returns>XML Object</returns>
        public object ReadXmlFile(object type, string xmlDocumentUrl)
        {
            try
            {
                using (FileStream fileStream = new FileStream(xmlDocumentUrl, FileMode.Open))
                {
                    //new serializer
                    XmlSerializer xmlSerializer = new XmlSerializer(type.GetType());
                    //deserialize the object
                    type = xmlSerializer.Deserialize(fileStream);
                }
                return type;
            }
            catch (Exception ex)
            {
                //
            }
            return null;
        }

        private void SubMenu_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem)
            {
                ToolStripMenuItem subItem = sender as ToolStripMenuItem;
                if (subItem.Tag != null)
                {
                    // string command = (string)subItem.Tag;
                    ApplicationMenus.ApplicationConfigMainMenuMenuGroupMenu menu =
                        subItem.Tag as ApplicationMenus.ApplicationConfigMainMenuMenuGroupMenu;
                    string command = menu.Command;
                    MyWorkItem.Commands[command].Execute();
                }
            }
        }

        private void tvNavigator_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //
        }

        private void tvNavigator_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeNode selectedNode = e.Node;
            if (selectedNode.Tag != null)
            {
                if (selectedNode.Tag is ApplicationMenus.ApplicationConfigMainMenuMenuGroupMenu)
                {
                    string command = (selectedNode.Tag as ApplicationMenus.ApplicationConfigMainMenuMenuGroupMenu).Command;
                    MyWorkItem.Commands[command].Execute();
                }
            }

            if (selectedNode == tvNavigator.Nodes[0])
                MyWorkItem.Commands["Module.Sidebar.PortalView"].Execute();
        }
    }
}
