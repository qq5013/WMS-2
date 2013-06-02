/*----------------------------------------------------------------
// Copyright (C) 2010 有限公司
// 版权所有。 
//
// 文件名：         SetProduct.cs
// 文件功能描述：   设置产品及数量
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

namespace MES.Execute
{
    /// <summary>
    ///     设置产品及数量
    /// </summary>
    /// <param name="productId"></param>
    /// <param name="quantity"></param>
    public delegate void SetProduct(int productId, int quantity);
}