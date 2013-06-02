using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ecWMS.Common.ExcelExport.ExcelExportEntity.Export;

namespace ecWMS.Common.ExcelExport.ExcelExportEntity
{
    public interface IEntityFactory
    {
        IList<InBoundTemplate> GetInBoundTemplateByInBoundBillId(int billId);

        IList<PickBillBoChi> GetPickBillBoChiByPickBillId(int billId);

        IList<SingleOrderPickBill> GetSingleOrderPickBillByPickBillId(int billId, int billDetailId);

        IList<TransferBillTemplate> GetTransferBillTemplateByTransferBillId(int billId);
    }
}
