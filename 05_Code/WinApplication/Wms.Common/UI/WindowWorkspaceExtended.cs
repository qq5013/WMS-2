using System.Windows.Forms;

namespace Wms.Common.UI
{
    public class WindowWorkspaceExtended : Microsoft.Practices.CompositeUI.WinForms.WindowWorkspace
    {
        readonly IWin32Window _owner;

        public WindowWorkspaceExtended()
        {
            //
        }

        public WindowWorkspaceExtended(IWin32Window owner)
            : base(owner)
        {
            _owner = owner;
        }

        protected override void OnShow(Control smartPart, Microsoft.Practices.CompositeUI.WinForms.WindowSmartPartInfo smartPartInfo)
        {
            GetOrCreateForm(smartPart);
            OnApplySmartPartInfo(smartPart, smartPartInfo);
            base.OnShow(smartPart, smartPartInfo);
        }

        protected override void OnClose(Control smartPart)
        {
            Form host = Windows[smartPart];
            host.Hide();
            base.OnClose(smartPart);
        }

        protected override void OnApplySmartPartInfo(Control smartPart, Microsoft.Practices.CompositeUI.WinForms.WindowSmartPartInfo smartPartInfo)
        {
            base.OnApplySmartPartInfo(smartPart, smartPartInfo);
            if (smartPartInfo is WindowSmartPartInfo)
            {
                WindowSmartPartInfo spi = (WindowSmartPartInfo)smartPartInfo;
                if (spi.Keys.ContainsKey(WindowWorkspaceSetting.AcceptButton))
                    Windows[smartPart].AcceptButton = (IButtonControl)spi.Keys[WindowWorkspaceSetting.AcceptButton];
                if (spi.Keys.ContainsKey(WindowWorkspaceSetting.CancelButton))
                    Windows[smartPart].CancelButton = (IButtonControl)spi.Keys[WindowWorkspaceSetting.CancelButton];
                if (spi.Keys.ContainsKey(WindowWorkspaceSetting.FormBorderStyle))
                    Windows[smartPart].FormBorderStyle = (FormBorderStyle)spi.Keys[WindowWorkspaceSetting.FormBorderStyle];
                if (spi.Keys.ContainsKey(WindowWorkspaceSetting.FormStartPosition))
                    Windows[smartPart].StartPosition = (FormStartPosition)spi.Keys[WindowWorkspaceSetting.FormStartPosition];
            }
        }

        protected new Form GetOrCreateForm(Control control)
        {
            bool resizeRequired = !Windows.ContainsKey(control);
            Form form = base.GetOrCreateForm(control);
            form.ShowInTaskbar = (_owner == null);
            if (resizeRequired)
                form.ClientSize = control.Size;
            return form;
        }
    }

}
