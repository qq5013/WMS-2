/*----------------------------------------------------------------
// Copyright (C) 2010 有限公司
// 版权所有。 
//
// 文件名：         SemiManufacturesResult.cs
// 文件功能描述：   半成品结果
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

namespace MES.BllService.Data
{
    /// <summary>
    ///     半成品结果
    /// </summary>
    public class SemiManufacturesResult
    {
        public string Date { get; set; }

        //public int WorkerId { get; set; }
        //public int ProductId { get; set; }

        public int Quantity { get; set; }

        public int ReworkQuantity { get; set; }

        public int WasterQuantity { get; set; }

        public string WorkNo { get; set; }

        public string ProductName { get; set; }

        //public string DataString { get; set; }
    }
}