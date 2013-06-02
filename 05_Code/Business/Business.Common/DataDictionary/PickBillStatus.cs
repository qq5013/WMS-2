namespace Business.Common.DataDictionary
{
    public enum PickBillStatus
    {
        Created = 31701,       // 制单
        Modified = 31702,      // 已修改
        Picking = 31703,       // 拣货中
        Picked = 31704,        // 拣货完成
        Sorting = 31705,       // 分拣中
        Sorted = 31706         // 分拣完成 
    }
}