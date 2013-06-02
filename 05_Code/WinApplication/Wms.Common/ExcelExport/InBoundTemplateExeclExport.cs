using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ecWMS.Common.ExcelExport.ExcelExportEntity;
using ecWMS.Common.ExcelExport.ExcelExportEntity.Export;

namespace ecWMS.Common.ExcelExport
{
    public class InBoundTemplateExeclExport:AbstractExcelExport
    {
        private IEntityFactory entityFactory;
        private IList<InBoundTemplate> ExportEntity = new List<InBoundTemplate>();


        public override void SetEntity(int billId, int billDetailId, int flagId)
        {
            entityFactory = new EntityFactory();
            ExportEntity = entityFactory.GetInBoundTemplateByInBoundBillId(billId);
        }

        public override void ExportExcel()
        {
            if (ExportEntity != null)
            {
                int count = 0;
                foreach (InBoundTemplate info in ExportEntity)
                {
                    count++;
                    if (info != null)
                    {
                        WriteCellValue(count.ToString(), 3, 2, _formatFactory.Barcode128(info.InBoundBillCode));
                        WriteCellValue(count.ToString(), 3, 4, info.InBoundDate);
                        WriteCellValue(count.ToString(), 4, 2, info.InBoundType);
                        WriteCellValue(count.ToString(), 4, 4, info.Buyer);
                        WriteCellValue(count.ToString(), 5, 2, info.Provider);
                        WriteCellValue(count.ToString(), 6, 2, info.LinkMan);
                        WriteCellValue(count.ToString(), 6, 4, info.LinkPhone);
                        int i = 9;
                        if(info.InBoundTemplateDetailList!=null && info.InBoundTemplateDetailList.Count > 0)
                        {
                            foreach(InBoundTemplateDetail inBoundTemplateDetail in info.InBoundTemplateDetailList)
                            {
                                WriteCellValue(count.ToString(), i, 1, inBoundTemplateDetail.Index);
                                WriteCellValue(count.ToString(), i, 2, _formatFactory.Barcode128(inBoundTemplateDetail.ItemCode));
                                WriteCellValue(count.ToString(), i, 3, inBoundTemplateDetail.ItemName);
                                WriteCellValue(count.ToString(), i, 4, inBoundTemplateDetail.Management);
                                WriteCellValue(count.ToString(), i, 5, inBoundTemplateDetail.UPC);
                                WriteCellValue(count.ToString(), i, 6, inBoundTemplateDetail.PlanQutity);
                                WriteCellValue(count.ToString(), i, 7, inBoundTemplateDetail.FactQutity);
                                WriteCellValue(count.ToString(), i, 8, inBoundTemplateDetail.Heavey);
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
