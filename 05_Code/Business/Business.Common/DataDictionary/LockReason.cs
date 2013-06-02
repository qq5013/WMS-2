namespace Business.Common.DataDictionary
{
    public enum LockReason
    {
        Damage = 30601,     // 破损锁定
        Qc = 30602,         // 质检锁定  
        Pick = 30603,       // 拣货锁定 
        Reserve = 30604,    // 保留锁定
        Handling = 30605    // 操作锁定 
    }
}