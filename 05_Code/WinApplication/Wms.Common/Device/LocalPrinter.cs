using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Printing;  

namespace Wms.Common.Device
{
    public class LocalPrinter
    {
        private static PrintDocument _printDocument = new PrintDocument();
        /// <summary>  
        /// 获取本机默认打印机名称  
        /// </summary>  
        public static string DefaultPrinter
        {
            get 
            {
                try
                {
                    return _printDocument.PrinterSettings.PrinterName;
                }
                catch (Exception ex)
                {
                    Framework.Core.Exception.ExceptionHelper.HandleException(ex, true, false);
                }

                return string.Empty;
            }
        }
        /// <summary>  
        /// 获取本机的打印机列表。列表中的第一项就是默认打印机。  
        /// </summary>  
        public static List<String> GetLocalPrinters()
        {
            try
            {
                List<String> printerList = new List<string>();
                printerList.Add(DefaultPrinter); // 默认打印机始终出现在列表的第一项  
                foreach (string printerName in PrinterSettings.InstalledPrinters)
                {
                    if (!printerList.Contains(printerName))
                        printerList.Add(printerName);
                }
                return printerList;
            }
            catch (Exception ex)
            {
                Framework.Core.Exception.ExceptionHelper.HandleException(ex, true, false);
            }

            return new List<string>();
        }  
    }
}
