/*----------------------------------------------------------------
// Copyright (C) 2010 有限公司
// 版权所有。 
//
// 文件名：         MaterielCode.cs
// 文件功能描述：   物料条码打印
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
    /// 物料条码打印
    /// </summary>
    public class MaterielCode : BarcodeLabel
    {
        public MaterielCode()
        {
            // Bartend模板文件
            FormatFileName = "Material.btw";

            // 数据文件
            DataFileName = "product.txt";

            // 数据文件头
            HeadData = string.Format("\"{0}\",\"{1}\"", "Code", "Name");

            // 数据文件内容
            DataFormat = "\"{0}\",\"{1}\"";

            // 检查模板文件是否存在
            if (!CheckTemplateFile())
            {
                MessageBox.Show("模板文件未找到，请联系管理员");
            }
        }
    }
}