using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Business.Domain.Mobile
{
    public class PickTask
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
        /// 关联单据号
        /// </summary>
        public string LinkBillNumber { get; set; }

        /// <summary>
        /// 计划出货时间
        /// </summary>
        public string PlanIssueTime { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 客户编号
        /// </summary>
        public int ClientId { get; set; }

        /// <summary>
        /// 出库计划编号
        /// </summary>
        public int PlanId { get; set; }

        /// <summary>
        /// 收货任务明细
        /// </summary>
        public List<PickTaskDetail> Details { get; set; }
    }

    public class PickTaskDetail
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
        /// 数量
        /// </summary>
        public int Qty { get; set; }

        /// <summary>
        /// 出库数量
        /// </summary>
        public string IssuedQty { get; set; }

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
