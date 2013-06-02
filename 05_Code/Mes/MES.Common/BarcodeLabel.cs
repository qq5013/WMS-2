/*----------------------------------------------------------------
// Copyright (C) 2010 有限公司
// 版权所有。 
//
// 文件名：         BarcodeLabel.cs
// 文件功能描述：   条码打印
//
// 
// 创建标识：
//
// 修改标识：
// 修改描述：
//
// 修改标识：
// 修改描述：
----------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace MES.Common
{
    /// <summary>
    /// 条码打印
    /// </summary>
    public sealed class BarcodeLabel
    {
        /// <summary>
        /// 多线程锁
        /// </summary>
        private static readonly object Locker = new object();
        /// <summary>
        /// 可执行程序
        /// </summary>
        public static string ExeFileName = "";
        /// <summary>
        /// 打印程序路径
        /// </summary>
        public static string PrintExeFilePath = "";
        /// <summary>
        /// 标签模板路径
        /// </summary>
        public static string LabelsPath = "";
        /// <summary>
        /// 格式化文件名
        /// </summary>
        public static string FormatFileName = "";
        /// <summary>
        /// 数据文件名
        /// </summary>
        public static string DataFileName = "";
        /// <summary>
        /// 头数据
        /// </summary>
        public static string HeadData = "";
        /// <summary>
        /// 数据格式
        /// </summary>
        public static string DataFormat = "";
        /// <summary>
        /// 命令格式
        /// </summary>
        public static string CommandFormat = @"{0}";
        /// <summary>
        /// 参数格式
        /// </summary>
        public static string ParmatersFormat = @"/f=""{0}"" /d=""{1}"" /p /x";
        /// <summary>
        /// 命令
        /// </summary>
        public static string Command = "";
        /// <summary>
        /// 参数
        /// </summary>
        public static string Paramters = "";
        /// <summary>
        /// 打印数据
        /// </summary>
        public List<string> DataStrings;
        /// <summary>
        /// 检查模板是否存在
        /// </summary>
        /// <returns></returns>
        public bool CheckTemplateFile()
        {
            return File.Exists(Path.Combine(LabelsPath, FormatFileName));
        }
        /// <summary>
        /// 条码
        /// </summary>
        public BarcodeLabel()
        {
            // init
            ExeFileName = @"bartend.exe";
            PrintExeFilePath = AppDomain.CurrentDomain.BaseDirectory;
            LabelsPath = @"c:\MES";//Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Labels");

            DataStrings = new List<string>();
        }
        /// <summary>
        /// 打印
        /// </summary>
        public void Print()
        {
            // init commond
            string p0 = Path.Combine(PrintExeFilePath, ExeFileName);
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
                var ps = new Process {StartInfo = {FileName = Command, Arguments = Paramters}};
                ps.Start();
            }
            catch (Exception exception)
            {
                exception.Process("");
                //
            }
        }
        /// <summary>
        /// 添加打印数据
        /// </summary>
        /// <param name="data"></param>
        public void AppendData(string data)
        {
            //如果有打印数据列表则添加数据
            if (DataStrings != null)
            {
                DataStrings.Add(data);
            }
        }
        /// <summary>
        /// 写数据文件
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="list"></param>
        public static void WriteDataFile(string fileName, List<string> list)
        {
            EnsureLabelFolder();
            string file = Path.Combine(LabelsPath, fileName);
            // 防止多线程同时调用
            lock (Locker)
            {
                using (var sw = new StreamWriter(file, false, Encoding.UTF8))
                {
                    // 写入头
                    sw.WriteLine(HeadData);
                    foreach (string data in list)
                    {
                        // 写入数据
                        sw.WriteLine(data);
                    }
                }
            }
        }
        /// <summary>
        /// 确认打印文件夹是否存在
        /// </summary>
        public static void EnsureLabelFolder()
        {
            // 如果文件夹不存在，则创建
            if (Directory.Exists(LabelsPath) != true)
                Directory.CreateDirectory(LabelsPath);
        }
    }
}