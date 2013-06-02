namespace Business.Common.DataDictionary
{
    public enum OutboundType
    {
        Sales = 31401,              // 销售出库
        ReturnToVendor = 31402,     // 供应商退货
        Adjust = 31403,             // 调整出库
        Transfer = 31404,           // 移仓出库
        Rma = 31405,                // RMA出库 
        Others = 31499              // 其它出库 
    }                                
}