using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Business.Domain.Mobile.Mobile
{
    public class DeliveryTask
    {
        /// <summary>
        /// 出货仓库代码
        /// </summary>
        public string WarehouseCode { get; set; }

        /// <summary>
        /// 任务单据号
        /// </summary>
        public string BillNumber { get; set; }

        /// <summary>
        /// 出货时间
        /// </summary>
        public string IssueTime { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 客户编号
        /// </summary>
        public int ClientId { get; set; }

        /// <summary>
        /// 出库编号
        /// </summary>
        public int BillId { get; set; }

        /// <summary>
        /// 收货任务明细
        /// </summary>
        public List<DeliveryTaskDetail> Details { get; set; }
    }

    public class DeliveryTaskDetail
    {
        /// <summary>
        /// 货物代码
        /// </summary>
        public string SkuNumber { get; set; }

        /// <summary>
        /// 货物名称
        /// </summary>
        public string SkuName { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public int Qty { get; set; }

        /// <summary>
        /// 批次号
        /// </summary>
        public string BatchNumber { get; set; }

        /// <summary>
        /// 包装名称
        /// </summary>
        public string PackName { get; set; }
    }
}
