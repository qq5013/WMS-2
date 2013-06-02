using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Business.Domain.Mobile
{
    public class PickTaskResult
    {
        /// <summary>
        /// 出货仓库代码
        /// </summary>
        public string WarehouseCode { get; set; }

        /// <summary>
        /// 任务单据号
        /// </summary>
        public string PlanNumber { get; set; }

        /// <summary>
        /// 发货人
        /// </summary>
        public string Receiver { get; set; }

        /// <summary>
        /// 计划发货时间
        /// </summary>
        public string PlanIssueTime { get; set; }

        /// <summary>
        /// 客户编号
        /// </summary>
        public int ClientId { get; set; }

        /// <summary>
        /// 出库计划编号
        /// </summary>
        public int PlanId { get; set; }

        public List<PickTaskResultDetail> Details { get; set; }

        public int Operator { get; set; }
    }

    public class PickTaskResultDetail
    {
        /// <summary>
        /// 货物代码
        /// </summary>
        public string SkuNumber { get; set; }

        /// <summary>
        /// 包装名称
        /// </summary>
        public string PackName { get; set; }

        /// <summary>
        /// 入库批次
        /// </summary>
        public string BatchNumber { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public int ReceivedQty { get; set; }

        /// <summary>
        /// 是否单件管理
        /// </summary>
        public bool IsPieceManagement { get; set; }

        /// <summary>
        /// 序列号列表
        /// </summary>
        //public List<string> SerialNumbers { get; set; }

        /// <summary>
        /// 容器条码
        /// </summary>
        public string ContainerBarcode { get; set; }

        /// <summary>
        /// 库位条码
        /// </summary>
        public string LocationBarcode { get; set; }

        /// <summary>
        /// 库位编号
        /// </summary>
        public int LocationId { get; set; }

        /// <summary>
        /// 库存ＩＤ
        /// </summary>
        public int StockId { get; set; }
    }
}
