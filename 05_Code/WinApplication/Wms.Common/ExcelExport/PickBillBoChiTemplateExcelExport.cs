using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ecWMS.Common.ExcelExport.ExcelExportEntity;
using ecWMS.Common.ExcelExport.ExcelExportEntity.Export;

namespace ecWMS.Common.ExcelExport
{
    public class PickBillBoChiTemplateExcelExport : AbstractExcelExport
    {
        private IEntityFactory entityFactory;
        private IList<PickBillBoChi> ExportEntity = new List<PickBillBoChi>();


        public override void SetEntity(int billId, int billDetailId, int flagId)
        {
            entityFactory = new EntityFactory();
            ExportEntity = entityFactory.GetPickBillBoChiByPickBillId(billId);
        }

        public override void ExportExcel()
        {
            if (ExportEntity != null)
            {
                int count = 0;
                foreach (PickBillBoChi info in ExportEntity)
                {
                    count++;
                    if (info != null)
                    {
                        WriteCellValue(count.ToString(), 2, 2, info.DeliveryCompany);
                        WriteCellValue(count.ToString(), 2, 5, info.PickBillCode);
                        WriteCellValue(count.ToString(), 3, 2, info.PickMode);
                        WriteCellValue(count.ToString(), 3, 5, info.GeneryTime);
                        WriteCellValue(count.ToString(), 4, 2, info.OrderType);
                        WriteCellValue(count.ToString(), 4, 4, info.DistrbutionVehicle);
                        WriteCellValue(count.ToString(), 4, 6, info.DistrbutionCar);
                        WriteCellValue(count.ToString(), 5, 2, info.OrderCount);
                        WriteCellValue(count.ToString(), 5, 4,
                                            info.ItemTypeCount < 1 ? "" : info.ItemTypeCount.ToString());
                        WriteCellValue(count.ToString(), 5, 6,
                                            info.ItemCount < 1 ? "" : info.ItemCount.ToString());
                        int i = 7;

                        if (info.SubPickBillBoChiDetail != null && info.SubPickBillBoChiDetail.Count > 0)
                        {
                            foreach (PickBillBoChiDetail inBoundTemplateDetail in info.SubPickBillBoChiDetail)
                            {
                                WriteCellValue(count.ToString(), i, 1, inBoundTemplateDetail.Index.ToString());
                                WriteCellValue(count.ToString(), i, 2, inBoundTemplateDetail.LocationIn);
                                WriteCellValue(count.ToString(), i, 3, inBoundTemplateDetail.Item);
                                WriteCellValue(count.ToString(), i, 4, inBoundTemplateDetail.ITemCount.ToString());
                                WriteCellValue(count.ToString(), i, 5, inBoundTemplateDetail.ItemName);
                                WriteCellValue(count.ToString(), i, 6, inBoundTemplateDetail.ItemDescription);
                                WriteCellValue(count.ToString(), i, 7, inBoundTemplateDetail.IsGo);
                                WriteCellValue(count.ToString(), i, 8, inBoundTemplateDetail.ITemType);
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
