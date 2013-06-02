/*----------------------------------------------------------------
// Copyright (C) 2010 有限公司
// 版权所有。 
//
// 文件名：         ProductTraceCode.cs
// 文件功能描述：   产品追踪号打印
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

using System.Windows.Forms;
using MES.Execute;

namespace MES.Common
{
    /// <summary>
    /// 产品追踪号打印
    /// </summary>
    public class ProductTraceCode : BarcodeLabel
    {
        public ProductTraceCode()
        {
            FormatFileName = "ProductTrace.btw";

            DataFileName = "ProductTrace.txt";

            HeadData = string.Format("\"{0}\",\"{1}\"", "Code", "Name");

            DataFormat = "\"{0}\",\"{1}\"";
            if (!CheckTemplateFile())
            {
                MessageBox.Show("模板文件未找到，请联系管理员");
            }
        }
    }
}