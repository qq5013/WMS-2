namespace Business.Common.DataDictionary
{
    public enum InboundType
    {
        Purchase = 31101,     // 采购入库
        Return = 31102,       // 退货入库 
        Adjust = 31103,       // 调整入库
        Transfer = 31104,     // 移仓入库
        Others = 31199        // 其它入库  
    }
}