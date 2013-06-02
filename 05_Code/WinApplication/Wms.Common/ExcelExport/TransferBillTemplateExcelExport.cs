using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ecWMS.Common.ExcelExport.ExcelExportEntity;
using ecWMS.Common.ExcelExport.ExcelExportEntity.Export;

namespace ecWMS.Common.ExcelExport
{
    public class TransferBillTemplateExcelExport : AbstractExcelExport
    {
        private IEntityFactory entityFactory;
        private IList<TransferBillTemplate> ExportEntity = new List<TransferBillTemplate>();


        public override void SetEntity(int billId, int billDetailId, int flagId)
        {
            entityFactory = new EntityFactory();
            ExportEntity = entityFactory.GetTransferBillTemplateByTransferBillId(billId);
        }

        public override void ExportExcel()
        {
            if (ExportEntity != null)
            {
                int count = 0;
                foreach (TransferBillTemplate info in ExportEntity)
                {
                    count++;
                    if (info != null)
                    {
                        WriteCellValue(count.ToString(), 3, 2, _formatFactory.Barcode128(info.TransferBillCode));
                        WriteCellValue(count.ToString(), 3, 4, info.TransferWarehouse);
                        WriteCellValue(count.ToString(), 4, 2, info.TransferType);
                        WriteCellValue(count.ToString(), 4, 4, info.TransferOperator);
                        WriteCellValue(count.ToString(), 5, 2, info.TransferPlanDate);
                        WriteCellValue(count.ToString(), 5, 4, info.TransferDate);
                        WriteCellValue(count.ToString(), 6, 2, info.TransferUnit);
                        WriteCellValue(count.ToString(), 7, 2, info.TransferMemo);
                        int i = 9;
                        if (info.TransferBillTemplates != null && info.TransferBillTemplates.Count > 0)
                        {
                            foreach (TransferBillTemplateDetail inBoundTemplateDetail in info.TransferBillTemplates)
                            {
                                //WriteCellValue(count.ToString(), i, 1, inBoundTemplateDetail.Index);
                                WriteCellValue(count.ToString(), i, 2, _formatFactory.Barcode128(inBoundTemplateDetail.ItemCode));
                                WriteCellValue(count.ToString(), i, 3, inBoundTemplateDetail.ItemName);
                                WriteCellValue(count.ToString(), i, 4, inBoundTemplateDetail.PlanTransferQuantity);
                                WriteCellValue(count.ToString(), i, 5, inBoundTemplateDetail.TransferQuantity);
                                WriteCellValue(count.ToString(), i, 6, inBoundTemplateDetail.ItemPack);
                                WriteCellValue(count.ToString(), i, 7, inBoundTemplateDetail.SourceLocation);
                                WriteCellValue(count.ToString(), i, 8, inBoundTemplateDetail.SourceUnit);
                                WriteCellValue(count.ToString(), i, 9, inBoundTemplateDetail.TargetLocation);
                                WriteCellValue(count.ToString(), i, 10, inBoundTemplateDetail.TargetUnit);
                                WriteCellValue(count.ToString(), i, 11, inBoundTemplateDetail.BatchNo);
                                i++;
                            }
                        }

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
