using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Domain.Inventory.Views
{
    public class InboundBillDetailView : InboundBillDetail
    {
        public string SkuNumber { get; set; }

        public string SkuName { get; set; }

        public string PackName { get; set; }

        public decimal PackVolume { get; set; }

        public decimal PackWeight { get; set; }

        public string ContainerName { get; set; }


    }
}
