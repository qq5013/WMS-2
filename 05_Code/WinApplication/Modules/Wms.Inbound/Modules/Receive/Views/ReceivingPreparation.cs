using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using Business.Domain.Inventory;
using Business.Domain.Inventory.Views;

namespace Business.Domain.Inventory
{
    public class ReceivingPreparation
    {
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
        /// 操作员
        /// </summary> 
        public int Operator { get; set; }

        public List<ReceivingPreparationDetail> Details { get; set; }
    }

    public class ReceivingPreparationDetail: InboundPlanDetailView
    {
        public int ReceivingQty { get; set; }

        public bool IsBatchManagement { get; set; }

        public bool IsBarcodeManagement { get; set; }

        public bool IsPieceManagement { get; set; }

        public List<ReceivingInboundBatch> Batchs { get; set; }
    }

    public class ReceivingInboundBatch : InboundBatch
    {
        //List<string> SerialNumbers { get; set; }
    }
}
