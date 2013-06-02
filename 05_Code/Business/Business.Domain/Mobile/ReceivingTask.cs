using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Domain.Mobile
{
    public class ReceivingTask
    {
        /// <summary>
        /// 收货仓库代码
        /// </summary>
        public string WarehouseCode { get; set; }

        /// <summary>
        /// 收货任务单据号
        /// </summary>
        public string BillNumber { get; set; }

        /// <summary>
        /// 关联单据号 
        /// </summary>
        public string LinkBillNumber { get; set; }

        /// <summary>
        /// 计划收货时间
        /// </summary> 
        public string PlanReceivingTime { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 收货任务明细信息
        /// </summary>
        public List<ReceivingTaskDetail> Details { get; set; }
    }

    public class ReceivingTaskDetail
    {
        /// <summary>
        /// 货物代码
        /// </summary>
        public string SkuNumber { get; set; }

        /// <summary>
        /// 货物名称
        /// </summary>
        public string SkuName { get; set; }

        /// <summary>
        /// 仓库条码
        /// </summary>
        public string Barcode { get; set; }

        /// <summary>
        /// UPC条码
        /// </summary>
        public string UPC { get; set; }

        /// <summary>
        /// 待收货数量
        /// </summary>
        public int Qty { get; set; }

        /// <summary>
        /// 包装名称
        /// </summary>
        public string PackName { get; set; }

        /// <summary>
        /// 是否单件管理
        /// </summary>
        public bool IsPieceManagement { get; set; }
    }
}
