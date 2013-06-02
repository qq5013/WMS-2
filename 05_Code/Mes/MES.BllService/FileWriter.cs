/*----------------------------------------------------------------
// Copyright (C) 2010 有限公司
// 版权所有。 
//
// 文件名：         FileWriter.cs
// 文件功能描述：   写文件日志
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
using System.IO;
using Frame.Utils.Log;

namespace MES.BllService
{
    /// <summary>
    ///     写文件日志
    /// </summary>
    public class FileWriter : ILogger
    {
        #region ILogger Members

        /// <summary>
        ///     写消息
        /// </summary>
        /// <param name="message"></param>
        public void Write(string message)
        {
            if (!Directory.Exists(PathName))
                Directory.CreateDirectory(PathName);
            using (
                var fs =
                    new StreamWriter(
                        Path.Combine(PathName,
                                     DateTime.Now.ToString("yyyyMMdd") + ".log"), true))
            {
                fs.Write(message);
                fs.Flush();
                fs.Close();
            }
        }

        /// <summary>
        ///     写异常
        /// </summary>
        /// <param name="exception"></param>
        public void Write(Exception exception)
        {
            Write(DateTime.Now + "\r\n");
            Write(exception.Message + "\r\n");
            Write(exception.StackTrace + "\r\n");
        }

        /// <summary>
        ///     写异常
        /// </summary>
        /// <param name="message"></param>
        /// <param name="ex"></param>
        public void Write(string message, Exception ex)
        {
            Write(DateTime.Now + "\r\n");
            Write(message + "\r\n");
            Write(ex.StackTrace + "\r\n");
        }

        #endregion

        /// <summary>
        ///     文件路径
        /// </summary>
        public string PathName { get; set; }
    }
}