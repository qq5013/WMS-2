namespace MES.Enum
{
    /// <summary>
    /// OutboundType
    /// </summary>
    public enum  OutboundType
    {

        /// <summary>
        /// 销售出库
        /// 成品仓	====>>	总装车间(客户)
        /// </summary>		
        Product = 1,


        /// <summary>
        /// 领料出库
        /// 中心仓	====>>	车间仓
        /// </summary>		
        Material = 2,


        /// <summary>
        /// 退料出库
        /// 中心仓	====>>	供应商
        /// </summary>		
        ReturnMaterial = 3,


        /// <summary>
        /// 车间领料出库
        /// 车间仓	====>>	生产线
        /// </summary>		
        WorkShopMaterial = 4,


        /// <summary>
        /// 调试检验/借用出库
        /// 成品仓	====>>	其他车间或单位
        /// </summary>		
        Inspect = 5,


        /// <summary>
        /// 损益出库
        /// 中心仓	====>>	中心仓
        /// </summary>		
        CenterAdjust = 6,


        /// <summary>
        /// 退货出库
        /// 车间仓	====>>	中心仓
        /// </summary>		
        BackCenter = 7,


        /// <summary>
        /// 损益出库
        /// 车间仓	====>>	车间仓
        /// </summary>		
        PlantAdjust = 8,


        /// <summary>
        /// 损益出库
        /// 成品仓	====>>	成品仓
        /// </summary>		
        ProductAdjust = 9,

    }
}