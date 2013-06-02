namespace Business.Common.DataDictionary
{
    public enum OperationType
    {
        ValidateSku = 20301,        // 核对货物品种数量
        Qc = 20302,                 // 质检  
        PrintLabel = 20303,         // 打印条码标签
        PasteLabel = 20304,         // 粘贴标签 
        ReceivingScan = 20305,      // 收货扫描 
        Putaway = 20306,            // 上架 
        Counting = 20307,           // 盘点
        TransferSku = 20308,        // 移货
        Picking = 20309,            // 拣货 
        Sorting = 20310,            // 分拣
        IssuingScan = 20311,        // 发货扫描
        Packing = 20312,            // 包装 
        Weighing = 20313            // 承重 
    }
}