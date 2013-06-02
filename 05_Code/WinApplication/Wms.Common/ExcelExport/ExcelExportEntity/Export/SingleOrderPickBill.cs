using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ecWMS.Business.Entity.Extend;

namespace ecWMS.Common.ExcelExport.ExcelExportEntity.Export
{
    /// <summary>
    /// 单定单拣货单
    /// </summary>
    [Serializable]
    public class SingleOrderPickBill
    {
        /// <summary>
        /// 下单人
        /// </summary>
        public String OrderMan { get; set; }

        /// <summary>
        /// 贱货单号，使用出库计划号
        /// </summary>
        public String OutboundPlanCode { get; set; }

        /// <summary>
        /// 送货地址
        /// </summary>
        public String OrderAddress { get; set; }

        /// <summary>
        /// 订单号
        /// </summary>
        public String OrderBillCode { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>
        public String LinkPhone { get; set; }

        /// <summary>
        /// 快递方式
        /// </summary>
        public String DeliveryCompany { get; set; }

        /// <summary>
        /// 下单日期
        /// </summary>
        public String OrderDate { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public String Remark { get; set; }

        /// <summary>
        /// 总数
        /// </summary>
        public Int32 ItemCount { get; set; }

        /// <summary>
        /// 总金额
        /// </summary>
        public decimal TotalMonery { get; set; }

        public IList<SingleOrderPickBillDetail> SingleOrderPickBillDetails { get; set; }
    }
}
