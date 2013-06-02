using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Business.Domain.Mobile.Inventory
{
    public class OutboundBill : DomainObject
    {
        /// <summary>
        /// 出库单编号
        /// </summary>
        public int BillId { get; set; }

        /// <summary>
        /// 出库单号
        /// </summary>
        public string BillNumber { get; set; }

        /// <summary>
        /// 出库计划编号
        /// </summary>
        public int PlanId { get; set; }

        /// <summary>
        /// 拣货单编号
        /// </summary>
        public long? PickBillId { get; set; }

        /// <summary>
        /// 分拣单编号
        /// </summary>
        public long? SortBillId { get; set; }

        /// <summary>
        /// 客户编号
        /// </summary>
        public int ClientId { get; set; }

        /// <summary>
        /// 商家编号
        /// </summary>
        public int MerchantId { get; set; }

        /// <summary>
        /// 发货仓库
        /// </summary>
        public int WarehouseId { get; set; }

        /// <summary>
        /// 发货人
        /// </summary>
        public int IssuePerson { get; set; }

        /// <summary>
        /// 发货库位编号
        /// </summary>
        public int IssueLocationId { get; set; }

        /// <summary>
        /// 发货时间
        /// </summary>
        public string IssueTime { get; set; }

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
    }
}
