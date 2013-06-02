using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ecWMS.Business.Entity.Extend;
using ecWMS.Common.ExcelExport.ExcelExportEntity;
using ecWMS.Common.ExcelExport.ExcelExportEntity.Export;

namespace ecWMS.Common.ExcelExport
{
    public class SingleOrderPickBillExcelExport : AbstractExcelExport
    {
        private IEntityFactory entityFactory;
        private IList<SingleOrderPickBill> ExportEntity = new List<SingleOrderPickBill>();


        public override void SetEntity(int billId, int billDetailId, int flagId)
        {
            entityFactory = new EntityFactory();
            ExportEntity = entityFactory.GetSingleOrderPickBillByPickBillId(billId,billDetailId);
        }

        public override void ExportExcel()
        {
            if (ExportEntity != null)
            {
                int count = 0;
                foreach (SingleOrderPickBill info in ExportEntity)
                {
                    count++;
                    if (info != null)
                    {
                        WriteCellValue(count.ToString(), 3, 2, info.OrderMan);
                        WriteCellValue(count.ToString(), 3, 5, info.OutboundPlanCode);
                        WriteCellValue(count.ToString(), 4, 2, info.OrderAddress);
                        WriteCellValue(count.ToString(), 4, 4, info.OrderBillCode);
                        WriteCellValue(count.ToString(), 5, 2, info.LinkPhone);
                        WriteCellValue(count.ToString(), 5, 5, info.DeliveryCompany);
                        WriteCellValue(count.ToString(), 6, 2, info.OrderDate);
                        WriteCellValue(count.ToString(), 6, 4, info.Remark);

                        int i = 8;

                        if (info.SingleOrderPickBillDetails != null && info.SingleOrderPickBillDetails.Count > 0)
                        {
                            foreach (SingleOrderPickBillDetail inBoundTemplateDetail in info.SingleOrderPickBillDetails)
                            {
                                WriteCellValue(count.ToString(), i, 1, inBoundTemplateDetail.LocationId);
                                WriteCellValue(count.ToString(), i, 2, inBoundTemplateDetail.Item);
                                WriteCellValue(count.ToString(), i, 3, inBoundTemplateDetail.ItemCount.ToString());
                                WriteCellValue(count.ToString(), i, 4, inBoundTemplateDetail.ItemName);
                                WriteCellValue(count.ToString(), i, 5, inBoundTemplateDetail.ItemDescription);
                                WriteCellValue(count.ToString(), i, 6, inBoundTemplateDetail.Model);
                                WriteCellValue(count.ToString(), i, 7, inBoundTemplateDetail.Price.ToString());
                                i++;
                            }
                        }

                        WriteCellValue(count.ToString(), 36, 5,
                                             info.ItemCount < 1 ? "" : info.ItemCount.ToString());
                        WriteCellValue(count.ToString(), 36, 7,
                                            info.TotalMonery < 1 ? "" : info.TotalMonery.ToString());
                    }
                }
                for (int i = 99; i >= ExportEntity.Count; i--)
                {
                    Workbook.Worksheets.RemoveAt(i);
                }
            }
        }
    }
}
