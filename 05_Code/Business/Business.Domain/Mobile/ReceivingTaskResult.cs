using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Domain.Mobile
{
    public class ReceivingTaskResult
    {
        /// <summary>
        /// 收货仓库代码
        /// </summary>
        public string WarehouseCode { get; set; }

        /// <summary>
        /// 任务单据号
        /// </summary>
        public string BillNumber { get; set; }

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
        /// 收货库位条码
        /// </summary>
        public string LocationBarcode { get; set; }

        /// <summary>
        /// 收货操作员
        /// </summary>
        public int Operator { get; set; }

        /// <summary>
        /// 收货明细信息
        /// </summary>
        public List<ReceivingTaskResultDetail> Details { get; set; }
    }

    public class ReceivingTaskResultDetail
    {
        /// <summary>
        /// 收货周转/存储容器
        /// </summary>
        public string ContainerBarcode { get; set; }

        /// <summary>
        /// 货物代码
        /// </summary>
        public string SkuNumber { get; set; }

        /// <summary>
        /// 包装名称
        /// </summary>
        public string PackName { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public int ReceivedQty { get; set; }

        /// <summary>
        /// 入库批次号
        /// </summary>
        public string BatchNumber { get; set; }

        /// <summary>
        /// 是否单件管理
        /// </summary>
        public bool IsPieceManagement { get; set; }

        /// <summary>
        /// 序列号列表
        /// </summary>
        //public List<string> SerialNumbers {get; set;}
    }
}
