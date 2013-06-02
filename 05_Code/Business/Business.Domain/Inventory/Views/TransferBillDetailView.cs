using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Domain.Inventory.Views
{
    public class TransferBillDetailView : TransferBillDetail
    {
        public string SkuNumber { get; set; }

        public string SkuName { get; set; }

        public string PackName { get; set; }

        public string SourceLocationCode { get; set; }

        public string SourceLocationName { get; set; }

        public string TargetLocationCode { get; set; }

        public string TargetLocationName { get; set; }

        public string SourceContainerCode { get; set; }

        public string SourceContainerName { get; set; }

        public string TargetContainerCode { get; set; }

        public string TargetContainerName { get; set; }
    }
}
