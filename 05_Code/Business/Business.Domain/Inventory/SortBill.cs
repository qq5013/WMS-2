using System.Collections.Generic;

namespace Business.Domain.Inventory
{
    public class SortBill : DomainObject
    {
        /// <summary>
        /// 分拣单编号
        /// </summary>
        public int BillId { get; set; }

        /// <summary>
        /// 分拣单代码
        /// </summary>
        public string BillNumber { get; set; }

        /// <summary>
        /// 拣货单编号
        /// </summary>
        public int PickBillId { get; set; }

        /// <summary>
        /// 出库计划编号
        /// </summary>
        public int PlanId { get; set; }

        /// <summary>
        /// 分拣时间
        /// </summary>
        public string SortTime { get; set; }

        /// <summary>
        /// 分拣仓库编号
        /// </summary>
        public int WarehouseId { get; set; }

        /// <summary>
        /// 发货库位编号
        /// </summary>
        public int IssueLocationId { get; set; }

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

        public IList<SortBillDetail> Details { get; set; }

        #endregion additional property
    }
}