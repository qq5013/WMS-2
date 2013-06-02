using System;
using System.Collections.Generic;
using System.ComponentModel;
using Frame.Utils.Contract;
using MES.Enum;

namespace MES.Entity
{
    /// <summary>
    ///     生产计划
    /// </summary>
    public class ProductionPlan : IBaseEntity, ICloneable
    {
        private readonly List<ProductionPlanDetail> _details = new List<ProductionPlanDetail>();
        private readonly List<ProductionPlanDetail> _removeList = new List<ProductionPlanDetail>();

        /// <summary>
        /// </summary>
        public Int32 ProductionPlanId { get; set; }

        /// <summary>
        ///     生产计划号
        /// </summary>
        public String Code { get; set; }

        /// <summary>
        ///     客户
        /// </summary>
        public string CustomerName { get; set; }

        /// <summary>
        ///     联系人
        /// </summary>
        public String ContractWith { get; set; }

        /// <summary>
        ///     计划月份
        /// </summary>
        public DateTime PlanMonth { get; set; }

  
        /// <summary>
        ///     创建人
        /// </summary>
        public Int32 CreaterId { get; set; }

        /// <summary>
        ///     备注
        /// </summary>
        public String Remark { get; set; }

        /// <summary>
        ///     状态
        /// </summary>
        public ProductionPlanStatus Status { get; set; }

        /// <summary>
        ///     制单日期
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        ///     关联销售订单
        /// </summary>
        public String SalesOrderCode { get; set; }

        [Description("明细")]
        public List<ProductionPlanDetail> Details
        {
            get { return _details; }
        }

        [Browsable(false)]
        public List<ProductionPlanDetail> RemoveList
        {
            get { return _removeList; }
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
        /// 交货地址
        /// </summary>
        public string DeliveryAddress { get; set; }

        /// <summary>
        /// 下单员
        /// </summary>
        public int OrderCreaterId { get; set; }

        #region IBaseEntity Members

        public int GetEntityId()
        {
            return ProductionPlanId;
        }

        #endregion

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}