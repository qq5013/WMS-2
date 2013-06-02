using System.Collections.Generic;

namespace Business.Domain.Inventory.Views
{
    public class InboundTaskDetailResult 
    {
        /// <summary>
        /// 收货准备任务编号
        /// </summary>
        public int InboundTaskId { get; set; }

        /// <summary>
        /// 收货准备任务明细编号
        /// </summary>
        public int InboundTaskDetailId { get; set; }

        public int SkuId { get; set; }

        public string SkuNumber { get; set; }

        public string SkuName { get; set; }

        public int PackId { get; set; }

        public string PackName { get; set; }

        /// <summary>
        /// 收货容器编号
        /// </summary>
        public int ContainerId { get; set; }

        public string ContainerName { get; set; }

        /// <summary>
        /// 入库批次号
        /// </summary>
        public string BatchNumber { get; set; }

        public InboundBatch Batch { get; set; }

        /// <summary>
        /// 核收数量
        /// </summary>
        public int Qty { get; set; }

        /// <summary>
        /// 序列号列表
        /// </summary>
        public List<string> SerialNumbers { get; set; }
    }
}
