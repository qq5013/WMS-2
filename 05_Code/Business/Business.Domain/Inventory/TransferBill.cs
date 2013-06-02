using System.Collections.Generic;

namespace Business.Domain.Inventory
{
    public class TransferBill : DomainObject
    {
        /// <summary>
        /// 移库单编号
        /// </summary>
        public int BillId { get; set; }

        /// <summary>
        /// 移库单代码
        /// </summary>
        public string BillNumber { get; set; }

        /// <summary>
        /// 仓库
        /// </summary>
        public int WarehouseId { get; set; }

        /// <summary>
        /// 移库类型
        /// </summary>
        public int TransferType { get; set; }

        /// <summary>
        /// 关联单据类型
        /// </summary>
        public int LinkBillType { get; set; }

        /// <summary>
        /// 关联单据编号
        /// </summary>
        public int LinkBillId { get; set; }

        /// <summary>
        /// 计划移库日期
        /// </summary>
        public string PlanTransferDate { get; set; }

        /// <summary>
        /// 移库时间
        /// </summary>
        public string TransferTime { get; set; }

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

        #region additional property

        public IList<TransferBillDetail> Details { get; set; }

        #endregion additional property
    }
}