using System;
using System.Collections.Generic;
using System.ComponentModel;
using Frame.Utils.Contract;
using MES.Enum;

namespace MES.Entity
{
    /// <summary>
    ///     生产工单
    /// </summary>
    public class MaterialRequisition : IBaseEntity, ICloneable
    {
        private readonly List<MaterialRequisitionDetail> _details = new List<MaterialRequisitionDetail>();
        private readonly List<Item> _items = new List<Item>();
        private readonly List<MaterialRequisitionDetail> _removeList = new List<MaterialRequisitionDetail>();

        /// <summary>
        /// </summary>
        public Int32 MaterialRequisitionId { get; set; }

        /// <summary>
        ///     生产工单号
        /// </summary>
        public String Code { get; set; }

        /// <summary>
        ///     生产计划单号
        /// </summary>
        public String ProductionPlanCode { get; set; }

        /// <summary>
        ///     客户
        /// </summary>
        public string CustomerName { get; set; }

        /// <summary>
        ///     订购日期
        /// </summary>
        public DateTime PurchaseDate { get; set; }

      

        /// <summary>
        ///     创建人
        /// </summary>
        public Int32 CreaterId { get; set; }

        /// <summary>
        ///     创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        ///     类型
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        ///     备注
        /// </summary>
        public String Remark { get; set; }

        /// <summary>
        ///     采购订单号
        /// </summary>
        public Int32 PurchaseOrderId { get; set; }

        /// <summary>
        ///     生产计划
        /// </summary>
        public Int32 ProductionPlanId { get; set; }

        /// <summary>
        ///     状态
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        ///     生产日期
        /// </summary>
        public DateTime ProductionDate { get; set; }

        [Description("明细")]
        public List<MaterialRequisitionDetail> Details
        {
            get { return _details; }
        }

        [Browsable(false)]
        public List<MaterialRequisitionDetail> RemoveList
        {
            get { return _removeList; }
        }

        public List<Item> Items
        {
            get { return _items; }
        }

        /// <summary>
        ///     订购日期
        /// </summary>
        public DateTime OrderDate { get; set; }

        /// <summary>
        ///     交货日期
        /// </summary>
        public DateTime DeliveryDate { get; set; }

        /// <summary>
        ///     工单类型
        /// </summary>
        public int OrderType { get; set; }

        #region IBaseEntity Members

        public int GetEntityId()
        {
            return MaterialRequisitionId;
        }

        #endregion

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}