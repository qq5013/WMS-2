namespace Business.Common.DataDictionary
{
    public enum StockLogType
    {
        Receiving = 30801,             // 收货
        PutawayIn = 30802,             // 上架移入
        PutawayOut = 30803,            // 上架移出
        InventoryCounting = 30804,     // 盘点
        TransferIn = 30805,            // 移货入
        TransferOut = 30806,           // 移货出
        ReplenishIn = 30807,           // 补货入
        ReplenishOut = 30808,          // 补货出
        Picking = 30809,               // 拣选
        Sorting = 30810,               // 分拣
        Issuing = 30811,               // 发货
        Splitting = 30812              // 库存分割
    }
}