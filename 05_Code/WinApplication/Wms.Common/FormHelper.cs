using System;
using Business.Common.Exception;
using DevExpress.XtraGrid.Views.Grid;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Wms.Common
{
    public class FormHelper
    {
        public static void BegainWait(Control control, object sender)
        {
            if (sender != null && sender.GetType() == typeof(ButtonEdit))
            {
                control.Cursor = Cursors.WaitCursor;
            }
        }

        public static void EndWait(Control control, object sender)
        {
            if (sender != null && sender.GetType() == typeof(ButtonEdit))
            {
                control.Cursor = Cursors.Default;
            }
        }

        public static void SetGridColumn(GridView view, string columnName, string columnCaption, int columnWidth, int columnIndex, bool isVisiable)
        {
            try
            {
                view.Columns[columnName].Caption = columnCaption;
                view.Columns[columnName].Width = columnWidth;
                view.Columns[columnName].VisibleIndex = columnIndex;
                view.Columns[columnName].Visible = isVisiable;
            }
            catch (Exception ex)
            {
                BusinessExceptionHelper.HandleException(ex, true, false);
            }
        }

        public static void ShowInformationDialog(string message)
        {
            MessageBox.Show(message, "ÐÅÏ¢", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void ShowWarningDialog(string message)
        {
            MessageBox.Show(message, "¾¯¸æ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static void ShowErrorDialog(string message)
        {
            MessageBox.Show(message, "´íÎó", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
