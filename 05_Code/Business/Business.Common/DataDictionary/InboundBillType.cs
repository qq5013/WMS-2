namespace Business.Common.DataDictionary
{
    public enum InboundBillType
    {
        PURCHASE = 32301,  // 采购单
        RMA = 32302,       // 退换货单
        COUNTING = 32303,  // 盘点单
        TRANSFER_WAREHOUSE = 32304, // 移仓单
        SALES = 32305,  // 销售退货单
        OTHERS = 32399, // 其它单据
    }
}