using System.Collections.Generic;

namespace Business.Domain.Inventory.Views
{
    public class InboundTaskDetailView : InboundTaskDetail
    {
        public string SkuNumber { get; set; }

        public string SkuName { get; set; }

        public string PackName { get; set; }

        public string UPC { get; set; }

        public string Barcode { get; set; }

        public bool IsContainerManagement { get; set; }

        public bool IsBarcodeManagement { get; set; }

        public bool IsPieceManagement { get; set; }

        public List<InboundBatch> Batchs { get; set; }

        /// <summary>
        /// 核收数量
        /// </summary>
        public int ReceivedQty { get; set; }
    }
}
