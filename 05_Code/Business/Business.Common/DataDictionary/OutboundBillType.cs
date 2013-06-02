namespace Business.Common.DataDictionary
{
    public enum OutboundBillType
    {
        SALES = 32401,     // 销售单
        RMA = 32402,       // 退换货单
        COUNTING = 32403,  // 盘点单
        TRANSFER_WAREHOUSE = 32404, // 移仓单
        PURCHASE = 32405, // 采购退货单
        OTHERS = 32499, // 其它单据
    }
}