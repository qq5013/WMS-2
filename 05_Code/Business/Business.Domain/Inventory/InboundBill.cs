using System.Collections.Generic;

namespace Business.Domain.Inventory
{
    public class InboundBill : DomainObject
    {
        #region property

        /// <summary>
        /// 入库单编号
        /// </summary>
        public int BillId { get; set; }

        /// <summary>
        /// 入库单号
        /// </summary>
        public string BillNumber { get; set; }

        /// <summary>
        /// 入库计划编号
        /// </summary>
        public int PlanId { get; set; }

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
        /// 收货仓库
        /// </summary>
        public int WarehouseId { get; set; }

        /// <summary>
        /// 送货人
        /// </summary>
        public string DeliveryMan { get; set; }

        /// <summary>
        /// 送货车辆
        /// </summary>
        public string Vehicle { get; set; }

        /// <summary>
        /// 到仓时间
        /// </summary>
        public string ArrivalTime { get; set; }

        /// <summary>
        /// 收货时间
        /// </summary>
        public string ReceiveTime { get; set; }

        /// <summary>
        /// 收货库位编号
        /// </summary>
        public int ReceiveLocationId { get; set; }

        /// <summary>
        /// 收货人
        /// </summary>
        public int Receiver { get; set; }

        /// <summary>
        /// 单据状态
        /// </summary>
        public int BillStatus { get; set; }

        /// <summary>
        /// 审核人
        /// </summary>
        public int Auditor { get; set; }

        /// <summary>
        /// 审核时间
        /// </summary>
        public string AuditTime { get; set; }

        /// <summary>
        /// 描述
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

        //public IList<InboundBillDetail> Details { get; set; }

        #endregion additional property
    }
}