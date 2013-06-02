using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using DevExpress.LookAndFeel;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.WinForms;
using Framework.Core.Exception;
using Wms.Common.Constants;
using Wms.Common.UI;
using KnightsWarriorAutoupdater;
using System.Net;
using System.Xml;

namespace Wms
{
    public class ShellApplication : FormShellApplication<WorkItem, ShellForm>
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            //System.Windows.Forms.Application.EnableVisualStyles();
            //System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            //System.Windows.Forms.Application.Run(new Form1());
            //return;
            try
            {
                System.Windows.Forms.Application.EnableVisualStyles();
                System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);

                //#region check and download new version program
                //bool bHasError = false;
                //IAutoUpdater autoUpdater = new AutoUpdater();
                //try
                //{
                //    autoUpdater.Update();
                //}
                //catch (WebException exp)
                //{
                //    //MessageBox.Show("连接升级服务器失败。");
                //    bHasError = true;
                //}
                //catch (XmlException exp)
                //{
                //    bHasError = true;
                //    MessageBox.Show("下载升级文件清单失败。");
                //}
                //catch (NotSupportedException exp)
                //{
                //    bHasError = true;
                //    MessageBox.Show("更新地址配置文件错误。");
                //}
                //catch (ArgumentException exp)
                //{
                //    bHasError = true;
                //    MessageBox.Show("下载升级文件错误。");
                //}
                //catch (Exception exp)
                //{
                //    bHasError = true;
                //    MessageBox.Show("升级时发生异常。");
                //}
                //finally
                //{
                //    if (bHasError == true)
                //    {
                //        try
                //        {
                //            autoUpdater.RollBack();
                //        }
                //        catch (Exception ex)
                //        {
                //            //Log the message to your file or database
                //            Framework.Core.Exception.ExceptionHelper.HandleException(ex, true, false);
                //        }
                //    }
                //}
                //#endregion

                // set devexpress controls style

                //DevExpress.Skins.SkinManager.EnableFormSkins();
                //DevExpress.UserSkins.BonusSkins.Register();
                //UserLookAndFeel.Default.SetSkinStyle("DevExpress Dark Style");

                DevExpress.Skins.SkinManager.EnableFormSkins();
                DevExpress.UserSkins.BonusSkins.Register();
                UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");


                // Adds the event handler to to the event.
                CustomExceptionHandler handler = new CustomExceptionHandler();
                System.Windows.Forms.Application.ThreadException += handler.OnThreadException;

                new ShellApplication().Run();
            }
            catch (Exception ex)
            {
                ExceptionHelper.HandleException(ex, true, false);
            }
           
        }

        protected override void AfterShellCreated()
        {
            base.AfterShellCreated();

            // add a modlewindow space
            WindowWorkspaceExtended space = new WindowWorkspaceExtended(Shell);

            RootWorkItem.ID = "ROOT_WORKITEM";
            RootWorkItem.Workspaces.Add(space, WorkspaceNames.ModalWindows);

            //RootWorkItem.UIExtensionSites.RegisterSite(UIExtensionConstants.Mainmenu, Shell.MenuBar);
            //RootWorkItem.UIExtensionSites.RegisterSite(UIExtensionConstants.Mainstatus, Shell.StatusBar);
            //RootWorkItem.Items.Add(Shell.MenuBar, UIExtensionConstants.Mainmenu);

            RootWorkItem.Commands["Modules.Sidebar.ShowSidebar"].AddInvoker(Shell.ModuleButton, "Click");
            RootWorkItem.Commands["Modules.Sidebar.ShowSidebar"].Execute();

            Shell.ProcessCommandMap();
        }
    }

    internal class CustomExceptionHandler
    {
        // Handles the exception event.
        public void OnThreadException(object sender, ThreadExceptionEventArgs t)
        {
            if (t.Exception is Exception)
            {
                Exception ex = t.Exception as Exception;
                ExceptionHelper.HandleException(ex, true, false);
                return;
            }

            DialogResult result = DialogResult.Cancel;
            try
            {
                result = ShowThreadExceptionDialog(t.Exception);
            }
            catch
            {
                try
                {
                    MessageBox.Show("系统异常", "系统异常", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Stop);
                }
                finally
                {
                    System.Windows.Forms.Application.Exit();
                }
            }

            if (result == DialogResult.Abort)
                System.Windows.Forms.Application.Exit();
        }

        // Creates the error message and displays it.
        private static DialogResult ShowThreadExceptionDialog(Exception e)
        {
            string errorMsg = "系统出现了一个严重的异常，请将下列异常信息发送给系统管理员: \n\n";
            errorMsg = errorMsg + e.Message + "\n堆栈信息:\n" + e.StackTrace;
            return MessageBox.Show(errorMsg, "系统异常", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Stop);
        }
    }
}