namespace Business.Common.DataDictionary
{
    public enum AreaType
    {
        Receiving = 20101,   // 收货暂存区
        Qc = 20102,          // 质检区
        Bad = 20103,         // 坏品区
        SecondHand = 20104,  // 二手区
        Handle = 20105,      // 加工区
        Picking = 20106,     // 拣货区
        Storage = 20107,     // 存储区
        Issuing = 20108,     // 发货暂存区
        Virtual = 20109      //  虚拟区
    }
}