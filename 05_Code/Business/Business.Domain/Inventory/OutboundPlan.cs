using System.Collections.Generic;

namespace Business.Domain.Inventory
{
    public class OutboundPlan : DomainObject
    {
        /// <summary>
        /// 出库计划编号
        /// </summary>
        public int PlanId { get; set; }

        /// <summary>
        /// 出库计划单号
        /// </summary>
        public string PlanNumber { get; set; }

        /// <summary>
        /// 出库类型
        /// </summary>
        public int OutboundType { get; set; }

        /// <summary>
        /// 优先级
        /// </summary>
        public int Priority { get; set; }

        /// <summary>
        /// 关联单据类型
        /// </summary>
        public int LinkBillType { get; set; }

        /// <summary>
        /// 关联单据代码
        /// </summary>
        public string LinkBillNumber { get; set; }

        /// <summary>
        /// 客户编号
        /// </summary>
        public int ClientId { get; set; }

        /// <summary>
        /// 商家编号
        /// </summary>
        public int MerchantId { get; set; }

        /// <summary>
        /// 发货仓库编号
        /// </summary>
        public int WarehouseId { get; set; }

        /// <summary>
        /// 收货人
        /// </summary>
        public string Receiver { get; set; }

        /// <summary>
        /// 计划发货时间
        /// </summary>
        public string PlanIssueTime { get; set; }

        /// <summary>
        /// 审核人
        /// </summary>
        public int Auditor { get; set; }

        /// <summary>
        /// 审核日期
        /// </summary>
        public string AuditTime { get; set; }

        /// <summary>
        /// 单据状态
        /// </summary>
        public int BillStatus { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 创建用户
        /// </summary>
        public int CreateUser { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public string CreateTime { get; set; }

        /// <summary>
        /// 编辑用户
        /// </summary>
        public int EditUser { get; set; }

        /// <summary>
        /// 编辑时间
        /// </summary>
        public string EditTime { get; set; }

        //#region additional property

        //public IList<OutboundPlanDetail> Details { get; set; }

        //public IList<OutboundBill> OutboundBills { get; set; }

        //public Distribution Distribution { get; set; }

        //public PickBill PickBill { get; set; }

        //public SortBill SortBill { get; set; }

        //#endregion additional property
    }
}