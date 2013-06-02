using System.Collections.Generic;

namespace Business.Domain.Inventory
{
    public class PickBill : DomainObject
    {
        /// <summary>
        /// 拣货单编号
        /// </summary>
        public int BillId { get; set; }

        /// <summary>
        /// 拣货单号
        /// </summary>
        public string BillNumber { get; set; }

        /// <summary>
        /// 拣货模式
        /// </summary>
        public int PickMode { get; set; }

        /// <summary>
        /// 拣选仓库
        /// </summary>
        public int WarehouseId { get; set; }

        /// <summary>
        /// 优先级
        /// </summary>
        public int Priority { get; set; }

        /// <summary>
        /// 计划拣货时间
        /// </summary>
        public string PlanPickTime { get; set; }

        /// <summary>
        /// 拣货时间
        /// </summary>
        public string PickTime { get; set; }

        /// <summary>
        /// 分拣库位编号
        /// </summary>
        public int SortLocationId { get; set; }

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

        public IList<PickBillDetail> Details { get; set; }

        public IList<PickWave> Waves { get; set; }

        #endregion additional property
    }
}