using System;

namespace ecWMS.Common.Constants
{
    /// <summary>
    /// 常量字符串
    /// </summary>
    public class ConstantString
    {
        /// <summary>
        /// 拣货库位标签生成规则字符串
        /// <code>PICK_{0}</code>
        /// </summary>
        public const String PickFlag = "PICK_{0}";

        /// <summary>
        /// 上架库位标签生成规则字符串
        /// <code>PUTAWAY_{0}</code>
        /// </summary>
        public const String PutawayFlag = "PUTAWAY_{0}";

        /// <summary>
        /// 补货库位标签生成规则字符串
        /// <code>REPLENISH_{0}</code>
        /// </summary>
        public const String ReplenishFlag = "REPLENISH_{0}";
    }
}
