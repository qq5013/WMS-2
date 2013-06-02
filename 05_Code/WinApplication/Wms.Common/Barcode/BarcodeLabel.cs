using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using Framework.Core.Configuration;

namespace Wms.Common.Barcode
{
    public class BarcodeLabel
    {
        private static readonly object Locker = new object();

        public static string ExeFileName = "";
        public static string PrintExeFilePath = "";
        public static string LabelsPath = "";
        public static string FormatFileName = "";
        public static string DataFileName = "";
        public static string HeadData = "";
        public static string DataFormat = "";
        public static string CommandFormat = @"{0}";
        public static string ParmatersFormat = @"/f={0} /d={1} /p /x";
        public static string Command = "";
        public static string Paramters = "";
        public ArrayList DataStrings;

        public BarcodeLabel()
        {
            // init
            ExeFileName = @"bartend.exe";

            string configPath = AppConfigHelper.GetAppSetting("PrintBarcodePath");
            if (configPath == string.Empty)
                PrintExeFilePath = AppDomain.CurrentDomain.BaseDirectory;
            else
                PrintExeFilePath = configPath;
            //PrintExeFilePath = "D:\\Program Files (x86)\\Seagull\\BarTender Suite\\BarTender";//AppDomain.CurrentDomain.BaseDirectory;
            LabelsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Labels");

            DataStrings = new ArrayList();
        }

        public virtual void Print()
        {
            // init commond
            string p0 = Path.Combine(PrintExeFilePath, ExeFileName); ;
            Command = string.Format(CommandFormat, p0);

            // init parameters
            string p1 = Path.Combine(LabelsPath, FormatFileName);
            string p2 = Path.Combine(LabelsPath, DataFileName);
            Paramters = string.Format(ParmatersFormat, p1, p2);

            // Init Data
            string dataFile = Path.Combine(LabelsPath, DataFileName);
            WriteDataFile(dataFile, DataStrings);

            try
            {
                Process ps = new Process();
                ps.StartInfo.FileName = Command;
                ps.StartInfo.Arguments = Paramters;
                ps.Start();
            }
            catch (Exception ex)
            {
                //
            }
        }

        public virtual void AppendData(string data)
        {
            if (DataStrings != null)
            {
                DataStrings.Add(data);
            }
        }

        public static void WriteDataFile(string fileName, ArrayList list)
        {
            EnsureLogFolder();
            string file = Path.Combine(LabelsPath, fileName);
            lock (Locker)
            {
                using (StreamWriter sw = new StreamWriter(file, false))
                {
                    sw.WriteLine(HeadData);
                    foreach (string data in list)
                    {
                        sw.WriteLine(data);
                    }
                }
            }
        }

        public static void EnsureLogFolder()
        {
            if (Directory.Exists(LabelsPath) != true)
                Directory.CreateDirectory(LabelsPath);
        }
    }
}
