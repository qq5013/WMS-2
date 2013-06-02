namespace MES.Enum
{
    /// <summary>
    /// InboundType
    /// </summary>
    public enum  InboundType
    {

        /// <summary>
        /// 采购入库
        /// 供应商	====>>	中心仓
        /// </summary>		
        Purchase = 1,


        /// <summary>
        /// 车间仓库领料
        /// 中心仓	====>>	车间仓
        /// </summary>		
        Material = 2,


        /// <summary>
        /// 退料入库
        /// 生产线	====>>	车间仓
        /// </summary>		
        ReturnMaterial = 3,


        /// <summary>
        /// 成品入库
        /// 生产线	====>>	成品仓
        /// </summary>		
        Product = 4,


        /// <summary>
        /// 退货入库
        /// 总装车间(客户)	====>>	成品仓
        /// </summary>		
        ReturnProduct = 5,


        /// <summary>
        /// 退料入库
        /// 中心仓	====>>	中心仓
        /// </summary>		
        ReturnMaterialToCenter = 6,


        /// <summary>
        /// 损益入库
        /// 中心仓	====>>	中心仓
        /// </summary>		
        CenterAdjust = 7,


        /// <summary>
        /// 损益入库
        /// 车间仓	====>>	车间仓
        /// </summary>		
        PlantAdjust = 8,


        /// <summary>
        /// 归还入库
        /// 其他车间或单位	====>>	成品仓
        /// </summary>		
        BackProduct = 9,


        /// <summary>
        /// 损益入库
        /// 成品仓	====>>	成品仓
        /// </summary>		
        ProductAdjust = 10,

    }
}