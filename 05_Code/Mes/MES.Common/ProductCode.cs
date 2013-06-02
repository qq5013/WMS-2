/*----------------------------------------------------------------
// Copyright (C) 2010 有限公司
// 版权所有。 
//
// 文件名：         ProductCode.cs
// 文件功能描述：   产品条码打印
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

namespace MES.Common
{
    /// <summary>
    ///     产品条码打印
    /// </summary>
    public class ProductCode : BarcodeLabel
    {
        /// <summary>
        ///     产品代码
        /// </summary>
        public ProductCode()
        {
            // Bartend模板文件
            FormatFileName = "Product.btw";

            // 数据文件
            DataFileName = "product.txt";

            //数据文件头
            HeadData = string.Format("\"{0}\",\"{1}\",\"{2}\"", "Code", "Code2", "Code3");

            // 数据格式
            DataFormat = "\"{0}\",\"{1}\",\"{2}\"";

            // 检查模板是否存在
            if (!CheckTemplateFile())
            {
                MessageBox.Show("模板文件未找到，请联系管理员");
            }
        }
    }
}