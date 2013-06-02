/*----------------------------------------------------------------
// Copyright (C) 2010 有限公司
// 版权所有。 
//
// 文件名：         CallBack.cs
// 文件功能描述：   条码扫描回调
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

namespace MES.Execute.Controls
{
    /// <summary>
    /// 条码扫描回调
    /// </summary>
    /// <param name="skuInfo">Sku信息</param>
    /// <param name="barcode">条码</param>
    /// <param name="lotNo">批号</param>
    /// <param name="measureId">单位</param>
    /// <param name="quantity">数量</param>
    /// <param name="showError">错误回调</param>
    public delegate void CallBack(SkuInfo skuInfo, string barcode, string lotNo, int measureId,int quantity,ShowError showError);
}