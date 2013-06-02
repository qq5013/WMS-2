using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Wms.Mobile.UI;
using System.Reflection;

namespace Wms.Mobile.Common
{
    public class FormHelper
    {
        public static void OpenModuleForm(System.Windows.Forms.Form parentForm, string moduleName)
        {
            string className = GetModuleClassName(moduleName);
            if (className != string.Empty)
            {
                Type t = GetFormType(parentForm, className);
                var form = Activator.CreateInstance(t) as TemplateForm;
                form.MainForm = parentForm;
                form.ModuleForm = parentForm;
                //form.ModuleForm = form;
                (parentForm as MainForm).CurrentForm = form;
                parentForm.Hide();
                form.ShowDialog();
            }
        }

        private static Type GetFormType(System.Windows.Forms.Form mainForm, string className)
        {
            Type listType =  mainForm.GetType();
            Assembly assembly = listType.Assembly;
            Type[] types = assembly.GetTypes();

            foreach (Type t in types)
            {
                if (t.Name == className)
                    return t;
            }
            return null;
        }

        private static string GetModuleClassName(string moduleName)
        {
            switch (moduleName)
            {
                case "Receiving":
                    {
                        return "ReceivingForm_Step1";
                        break;
                    }
                case "Putaway":
                    {
                        return "PutawayForm_Step1";
                        break;
                    }
                case "StockQuery":
                    {
                        return "StockQueryForm";
                        break;
                    }
                case "Pick":
                    {
                        return "PickForm_Step1";
                        break;
                    }

                case "Delivery":
                    {
                        return "DeliveryForm";
                        break;
                    }
                case "Transfer":
                    {
                        return "TransferForm_Step1";
                        break;
                    }
            }

            return string.Empty;
        }
    }
}
