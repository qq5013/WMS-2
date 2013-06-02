using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Domain.Report
{
    public class InboundPlanReportEntity
    {
        public string LogisticsCompanyName { get; set; }

        public string WarehouseName { get; set; }

        public string BillType { get; set; }

        public string BillNumber { get; set; }

        public string OwnerName { get; set; }

        public string ContactInformation { get; set; }

        public string Remark { get; set; }

        public string PrintOperator { get; set; }

        public string PrintTime { get; set; }

        public List<InboundPlanDetailReportEntity> Details { get; set; }
    }

    public class InboundPlanDetailReportEntity
    {
        public string SkuNumber { get; set; }

        public string SkuName { get; set; }

        public string ModelSpec { get; set; }

        public string OtherInformation { get; set; }

        public string Qty { get; set; }
    }
}
