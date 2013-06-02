using System.Collections.Generic;

namespace Business.Domain.Inventory
{
    public class CountBill : DomainObject
    {
        #region property

        /// <summary>
        /// 盘点单编号
        /// </summary>
        public int BillId { get; set; }

        /// <summary>
        /// 盘点单号
        /// </summary>
        public string BillNumber { get; set; }

        /// <summary>
        /// 仓库编号
        /// </summary>
        public int WarehouseId { get; set; }

        /// <summary>
        /// 计划盘点日期
        /// </summary>
        public string PlanCountDate { get; set; }

        /// <summary>
        /// 盘点时间
        /// </summary>
        public string CountTime { get; set; }

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

        //#region additional property

        //public IList<CountBillDetail> Details { get; set; }

        //#endregion additional property
    }
}