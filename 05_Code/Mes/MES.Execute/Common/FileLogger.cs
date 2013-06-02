/*----------------------------------------------------------------
// Copyright (C) 2010 有限公司
// 版权所有。 
//
// 文件名：         FileLogger.cs
// 文件功能描述：   记录日志文件
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
using System.Text;
using Frame.Utils.Log;

namespace MES.Execute.Common
{
    /// <summary>
    ///     记录日志文件
    /// </summary>
    public class FileLogger : ILogger
    {
        #region ILogger Members

        /// <summary>
        ///     记录消息
        /// </summary>
        /// <param name="message"></param>
        public void Write(string message)
        {
            string file = DateTime.Now.ToString("yyyyMMdd") + ".log";
            using (var fs = new StreamWriter(file, true, Encoding.UTF8))
            {
                fs.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                fs.WriteLine(message);
                fs.Flush(); // Flush Stream
                fs.Close();
            }
        }

        /// <summary>
        ///     记录异常
        /// </summary>
        /// <param name="exception"></param>
        public void Write(Exception exception)
        {
            string file = DateTime.Now.ToString("yyyyMMdd") + ".exception.log";
            using (var fs = new StreamWriter(file, true, Encoding.UTF8))
            {
                fs.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " Exception:" + exception.GetType() +
                             " Message:" + exception.Message);
                fs.WriteLine(exception.StackTrace);
                fs.Flush(); // Flush Stream
                fs.Close();
            }
        }

        /// <summary>
        ///     记录异常
        /// </summary>
        /// <param name="message"></param>
        /// <param name="ex"></param>
        public void Write(string message, Exception ex)
        {
            string file = DateTime.Now.ToString("yyyyMMdd") + ".exception.log";
            using (var fs = new StreamWriter(file, true, Encoding.UTF8))
            {
                fs.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " Exception:" + ex.GetType() + " Message:" +
                             ex.Message);
                fs.WriteLine(message);
                fs.WriteLine(ex.StackTrace);
                fs.Flush(); // Flush Stream
                fs.Close();
            }
        }

        #endregion
    }
}