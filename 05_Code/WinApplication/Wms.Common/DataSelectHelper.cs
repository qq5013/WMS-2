using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System.Windows.Forms;

namespace Wms.Common
{
    public class DataSelectHelper
    {
        /// <summary>
        /// 公司选择（供应商、客户、商家）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void SelectCompany_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            DevExpress.XtraEditors.ButtonEdit edit = (DevExpress.XtraEditors.ButtonEdit)sender;
            if (e.Button.Kind == ButtonPredefines.Delete)
            {
                edit.Tag = null;
                edit.Text = string.Empty;
                return;
            }

            Form parentForm = new DevExpress.XtraEditors.XtraForm();
            parentForm.AutoSize = true;
            parentForm.StartPosition = FormStartPosition.CenterScreen;
            parentForm.ControlBox = false;
            parentForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            CompanyListForm form = new CompanyListForm(FormMode.Select, false);
            form.Size = new System.Drawing.Size(810, 600);
            form.Parent = parentForm;
            form.ReferenceForm = parentForm;
            parentForm.ShowDialog();
            IList companys = form.GetSelectedData<Company>();
            if (companys != null && companys.Count > 0)
            {
                Company company = companys[0] as Company;
                ((ButtonEdit)sender).Tag = company;
                ((ButtonEdit)sender).Text = company.ShortName;
            }
        }
    }
}
