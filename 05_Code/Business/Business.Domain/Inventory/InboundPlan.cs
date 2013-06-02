using System.Collections.Generic;

namespace Business.Domain.Inventory
{
    public class InboundPlan : DomainObject
    {
        #region property

        /// <summary>
        /// 入库计划编号
        /// </summary>
        public int PlanId { get; set; }

        /// <summary>
        /// 入库计划单号
        /// </summary>
        public string PlanNumber { get; set; }

        /// <summary>
        /// 收货仓库编号
        /// </summary>
        public int WarehouseId { get; set; }

        /// <summary>
        /// 入库类型
        /// </summary>
        public int InboundType { get; set; }

        /// <summary>
        /// 优先级
        /// </summary>
        public int Priority { get; set; }

        /// <summary>
        /// 关联单据类型
        /// </summary>
        public int LinkBillType { get; set; }

        /// <summary>
        /// 关联单号
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
        /// 供应商
        /// </summary>
        public int VendorId { get; set; }

        /// <summary>
        /// 计划收货时间
        /// </summary>
        public string PlanReceiveTime { get; set; }

        /// <summary>
        /// 是否越库转运
        /// </summary>
        public bool IsCrossDock { get; set; }

        /// <summary>
        /// 审核人
        /// </summary>
        public int Auditor { get; set; }

        /// <summary>
        /// 审核时间
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

        #endregion property

        #region additional property

        //public IList<InboundPlanDetail> Details { get; set; }

        //public IList<InboundBill> InboundBills { get; set; }

        //public IList<SerialNumber> SerialNumbers { get; set; }

        #endregion additional property
    }
}