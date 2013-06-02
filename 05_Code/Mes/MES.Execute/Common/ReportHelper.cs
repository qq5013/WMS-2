/*----------------------------------------------------------------
// Copyright (C) 2010 有限公司
// 版权所有。 
//
// 文件名：         ReportHelper.cs
// 文件功能描述：   报表帮助
//
// 
// 创建标识：
//
// 修改标识：
// 修改描述：
//
// 修改标识：
// 修改描述：
----------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using DevExpress.XtraReports.UI;
using Frame.Utils.Service;
using MES.BllService;
using MES.Entity;
using MES.Reports;
using MES.Reports.Datas;

namespace MES.Execute.Common
{
    /// <summary>
    /// 报表帮助
    /// </summary>
    public static class ReportHelper
    {
        /// <summary>
        /// 入库单标本
        /// </summary>
        /// <param name="inbound">入库单</param>
        /// <param name="type">入库单类型</param>
        /// <returns></returns>
        public static XtraReport GetReport(this Inbound inbound, InboundType type)
        {
            XtraReport report;
            switch (type)
            {
                case InboundType.Purchase:
                    report = new InboundReport();
                    break;
                case InboundType.Material:
                    report = new WorkShopInboundReport();
                    break;
                case InboundType.Product:
                    report = new ProductInboundReport();
                    break;
                case InboundType.ReturnMaterial:
                case InboundType.ReturnProduct:
                case InboundType.ReturnMaterialToCenter:
                case InboundType.CenterAdjust:
                case InboundType.PlantAdjust:
                case InboundType.BackProduct:
                case InboundType.ProductAdjust:
                    return null;
                default:
                    throw new ArgumentOutOfRangeException("type");
            }

            var dataSet = new InboundData();
            InboundData.InboundDataTable inboundDataTable = dataSet.Inbound;
            InboundData.InboundRow inboundRow = inboundDataTable.NewInboundRow();
            inboundRow.InboundId = inbound.InboundId;
            inboundRow.Code = inbound.Code;
            if(inbound.ReceiveTime>DateTimeHelper.Min)
            inboundRow.Date = inbound.ReceiveTime;
            Warehouse warehouse = ServiceHelper.GetService<Warehouse>().GetById(inbound.WarehouseId);
            if (warehouse != null)
            {
                inboundRow.ReceiveWarehouseName = warehouse.Name;
            }
            inboundRow.OutboundCode = inbound.RelationCode;
            if (inbound.ReceiveTime > DateTimeHelper.Min)
            inboundRow.ReceiveDate = inbound.ReceiveTime;
            inboundRow.ProductionPlanCode = "";

            User inspector = ServiceHelper.GetService<User>().GetById(inbound.InspectorId);
            if (inspector != null) inboundRow.InspecterName = inspector.Name;
            
            User receiver = ServiceHelper.GetService<User>().GetById(inbound.ReceiverId);
            if (receiver != null)
            {
                inboundRow.ReceiverName = receiver.Name;
                inboundRow.User = receiver.Name;
            }

            User deliverMan = ServiceHelper.GetService<User>().GetById(inbound.DeliverManId);
            if (deliverMan != null)
                inboundRow.DeliverManName = deliverMan.Name;

            var deliverDep = ServiceHelper.GetService<Department>().GetById(inbound.DeliverDepId);
            if (deliverDep != null)
                inboundRow.DeliverDepName = deliverDep.Name;

            inboundDataTable.Rows.Add(inboundRow);
            string vendorName = string.Empty;
            Vendor vendor = ServiceHelper.GetService<Vendor>().GetById(inbound.SourceUnitId);
            if (vendor != null) vendorName = vendor.Name;

            List<InboundDetail> details = inbound.Details;
            if (details.Count == 0)
                details = ServiceHelper.GetService<InboundDetail>().FindAll(c => c.InboundId == inbound.InboundId, null);
            InboundData.InboundDetailDataTable inboundDetailDataTable = dataSet.InboundDetail;

            // 获取明细信息
            for (int index = 0; index < details.Count; index++)
            {
                InboundDetail detail = details[index];
                InboundData.InboundDetailRow detailRow = inboundDetailDataTable.NewInboundDetailRow();
               
                int skuId = detail.SkuId;
                SkuInfo skuInfo = ServiceHelper.GetQuery<SkuInfo>().Find(t => t.SkuId == skuId);

                //明细中Sku信息
                if (skuInfo != null)
                {
                    detailRow.Name = skuInfo.Name;
                    detailRow.Code = skuInfo.Code;
                    detailRow.Spec = skuInfo.Spec;
                    detailRow.Model = skuInfo.Model;
                    detailRow.Code = skuInfo.Code;
                } 
                // Julio:库存
                
                detailRow.Sequence = index + 1;
                detailRow.Quantity = detail.Quantity;
                detailRow.LotNo = detail.LotNo;
                detailRow.UseWay = detail.UseWay;
                detailRow.InboundDetailId = detail.InboundDetailId;
                detailRow.InboundId = detail.InboundId;
                detailRow.VendorName = vendorName;
                detailRow.Remark = detail.Remark;
                
                inboundDetailDataTable.Rows.Add(detailRow);
            }

            report.DataSource = dataSet;
            report.CreateDocument();
            return report;
        }

        /// <summary>
        /// 出库单报表
        /// </summary>
        /// <param name="outbound">出库单</param>
        /// <param name="type">出库单类型</param>
        /// <returns></returns>
        public static XtraReport GetReport(this Outbound outbound, OutboundType type)
        {
            XtraReport report;
            switch (type)
            {
                case OutboundType.Product:
                    report = new ProductOutboundReport();
                    break;
                case OutboundType.Material:
                    report = new OutboundReport();
                    break;
                case OutboundType.WorkShopMaterial:
                    report = new OutboundReport();
                    break;
                case OutboundType.ReturnMaterial:
                case OutboundType.Inspect:
                case OutboundType.CenterAdjust:
                case OutboundType.BackCenter:
                case OutboundType.PlantAdjust:
                case OutboundType.ProductAdjust:
                    report = new OutboundReport();
                    break;
                default:
                    throw new ArgumentOutOfRangeException("type");
            }


            var dataSource = new OutboundDataSet();

            OutboundDataSet.OutboundRow row = dataSource.Outbound.NewOutboundRow();
            row.Code = outbound.Code;
            User user = ServiceHelper.GetService<User>().GetById(outbound.OperatorId);
            if (user != null) row.OperatorName = user.Name;
            row.OperateTime = outbound.OperateTime;
            row.PrintTime = DateTimeHelper.Now;
            row.OutboundId = outbound.OutboundId;
            Warehouse warehouse = ServiceHelper.GetService<Warehouse>().GetById(outbound.WarehouseId);
            if (warehouse != null) row.WarehouseName = warehouse.Name;
            row.SalesOrder = outbound.SalesOrderCode;
           // row.OperatorName
            dataSource.Outbound.Rows.Add(row);

            List<OutboundDetail> outboundDetails = outbound.Details;
            if (outbound.Details.Count == 0)
                outboundDetails =
                    ServiceHelper.GetService<OutboundDetail>().FindAll(c => c.OutboundId == outbound.OutboundId, null);

            // 获取明细信息
            for (int index = 0; index < outboundDetails.Count; index++)
            {
                OutboundDetail detail = outboundDetails[index];

                OutboundDataSet.OutboundDetailRow detailRow = dataSource.OutboundDetail.NewOutboundDetailRow();
                detailRow.Sequence = index + 1;
                detailRow.OutboundId = outbound.OutboundId;
                detailRow.OutboundDetailId = detail.OutboundDetailId;
                SkuInfo skuInfo = ServiceHelper.GetQuery<SkuInfo>().Find(t => t.SkuId == detail.SkuId);

                //明细中Sku信息
                if (skuInfo != null)
                {
                    detailRow.CategoryName = skuInfo.CategoryName;
                    detailRow.Code = skuInfo.Code;
                    detailRow.Model = skuInfo.Model;
                    detailRow.Spec = skuInfo.Spec;
                    detailRow.Name = skuInfo.Name;
                }

                detailRow.FloatRatio = detail.FloatRatio ?? 0;
                detailRow.Remark = detail.Remark;
                detailRow.Quantity = detail.Quantity;

                dataSource.OutboundDetail.Rows.Add(detailRow);
            }
            report.DataSource = dataSource;
            report.CreateDocument();
            return report;
        }

        /// <summary>
        /// 销售订单报表
        /// </summary>
        /// <param name="salesOrder"></param>
        /// <returns></returns>
        public static XtraReport GetReport(this SalesOrder salesOrder)
        {
            XtraReport report = new SalesOrderReport();

            var dataSource = new SalesOrderDataSet();
            SalesOrderDataSet.SalesOrderRow row = dataSource.SalesOrder.NewSalesOrderRow();
            row.Code = salesOrder.Code;
            row.CreateTime = salesOrder.CreateTime;
            Customer customer = ServiceHelper.GetService<Customer>().GetById(salesOrder.CustomerId);
            if (customer != null) row.CustomerName = customer.Name;
            row.DeliveryAddress = salesOrder.DeliveryAddress;
            if (salesOrder.DeliveryDate > DateTimeHelper.Min)
            row.DeliveryDate = salesOrder.DeliveryDate;
            User user = ServiceHelper.GetService<User>().GetById(salesOrder.OperatorId);
            if (user != null) row.OperatorName = user.Name;
            row.OrderContract = salesOrder.OrderContract;
            if (salesOrder.OrderDate > DateTimeHelper.Min)
            row.OrderDate = salesOrder.OrderDate;
            row.PrintTime = DateTimeHelper.Now;
            row.SalesOrderId = salesOrder.SalesOrderId;
            row.TopicNumber = salesOrder.TopicNumber;
            dataSource.SalesOrder.Rows.Add(row);

            List<SalesOrderDetail> salesOrderDetails = salesOrder.Details;
            if (salesOrderDetails.Count == 0)
                salesOrderDetails =
                    ServiceHelper.GetService<SalesOrderDetail>().FindAll(
                        c => c.SalesOrderId == salesOrder.SalesOrderId, null);

            // 获取明细信息
            for (int index = 0; index < salesOrderDetails.Count; index++)
            {
                SalesOrderDetail detail = salesOrderDetails[index];
                SalesOrderDataSet.SalesOrderDetailRow detailRow = dataSource.SalesOrderDetail.NewSalesOrderDetailRow();

                detailRow.Sequence = index + 1;
                detailRow.SalesOrderId = salesOrder.SalesOrderId;
                detailRow.SalesOrderDetailId = detail.SalesOrderDetailId;
                SkuInfo skuInfo = ServiceHelper.GetQuery<SkuInfo>().Find(t => t.SkuId == detail.SkuId);
                //明细中Sku信息
                if (skuInfo != null)
                {
                    detailRow.CategoryName = skuInfo.CategoryName;
                    detailRow.Code = skuInfo.Code;
                    detailRow.Model = skuInfo.Model;
                    detailRow.Spec = skuInfo.Spec;
                    detailRow.Name = skuInfo.Name;
                }
                detailRow.Remark = detail.Remark;
                detailRow.Quantity = detail.Quantity;
                dataSource.SalesOrderDetail.Rows.Add(detailRow);
            }

            report.DataSource = dataSource;
            report.CreateDocument();
            return report;
        }

        /// <summary>
        /// 采购订单报表
        /// </summary>
        /// <param name="purchaseOrder"></param>
        /// <returns></returns>
        public static XtraReport GetReport(this PurchaseOrder purchaseOrder)
        {
            XtraReport report = new PurchaseOrderReport();
            var dataSource = new PurchaseOrderDataSet();
            PurchaseOrderDataSet.PurchaseOrderRow row = dataSource.PurchaseOrder.NewPurchaseOrderRow();
            row.Code = purchaseOrder.Code;
            row.Amount = purchaseOrder.Amount;
            row.BargainNo = purchaseOrder.BargainNo;
            var vendor = ServiceHelper.GetService<Vendor>().GetById(purchaseOrder.VendorId);
            if (vendor != null)
                row.VendorName = vendor.Name;
            User user = ServiceHelper.GetService<User>().GetById(purchaseOrder.OperatorId);
            if (user != null) row.OperatorName = user.Name;
            row.PurchasePlanDepartment = purchaseOrder.PurchaseDepartment;
            if (purchaseOrder.ApplyDate > DateTimeHelper.Min)
            row.PurchaseDate = purchaseOrder.ApplyDate;
            row.PurchaseOrderId = purchaseOrder.PurchaseOrderId;
            row.PurchasePlanCode = purchaseOrder.PurchasePlanCode;
            if (purchaseOrder.PlanDeliverDate > DateTimeHelper.Min)
                row.DeliverDate = purchaseOrder.PlanDeliverDate;
            row.DeliverPlace = purchaseOrder.PlanDeliverPlace;

            row.Amount = purchaseOrder.Amount;
            row.OrderTax = purchaseOrder.AmountOutTax * purchaseOrder.OrderTax / (1 + purchaseOrder.OrderTax);
            row.AmountOutTax = purchaseOrder.AmountOutTax;

            dataSource.PurchaseOrder.Rows.Add(row);

            List<PurchaseOrderDetail> purchaseOrderDetails = purchaseOrder.Details;
            if (purchaseOrderDetails.Count == 0)
                purchaseOrderDetails =
                    ServiceHelper.GetService<PurchaseOrderDetail>().FindAll(
                        c => c.PurchaseOrderId == purchaseOrder.PurchaseOrderId, null);

            // 获取明细信息
            for (int index = 0; index < purchaseOrderDetails.Count; index++)
            {
                PurchaseOrderDetail detail = purchaseOrderDetails[index];
                PurchaseOrderDataSet.PurchaseOrderDetailRow detailRow =
                    dataSource.PurchaseOrderDetail.NewPurchaseOrderDetailRow();

                detailRow.Sequence = index + 1;
                detailRow.PuchaseOrderId = purchaseOrder.PurchaseOrderId;
                detailRow.PuchaseOrderDetailId = detail.PurchaseOrderDetailId;
                SkuInfo skuInfo = ServiceHelper.GetQuery<SkuInfo>().Find(t => t.SkuId == detail.SkuId);

                //明细中Sku信息
                if (skuInfo != null)
                {
                    detailRow.CategoryName = skuInfo.CategoryName;
                    detailRow.Code = skuInfo.Code;
                    detailRow.Model = skuInfo.Model;
                    detailRow.Spec = skuInfo.Spec;
                    detailRow.Name = skuInfo.Name;
                }
                if (purchaseOrder.PlanDeliverDate > DateTimeHelper.Min)
                detailRow.DeliverDate = purchaseOrder.PlanDeliverDate;
                detailRow.Amount = detail.Amount;
                detailRow.Price = detail.Price;
                Measure measure = ServiceHelper.GetService<Measure>().GetById(detail.MeasureId);
                if (measure != null) detailRow.MeasureName = measure.Name;
                detailRow.Quantity = detail.Quantity;
                detailRow.Memo = detail.Memo;


                dataSource.PurchaseOrderDetail.Rows.Add(detailRow);
            }

            report.DataSource = dataSource;
            report.CreateDocument();
            return report;
        }

        /// <summary>
        /// 生产计划报表
        /// </summary>
        /// <param name="productionPlan"></param>
        /// <returns></returns>
        public static XtraReport GetReport(this ProductionPlan productionPlan)
        {
            XtraReport report = new ProductionPlanReport();
            var dataSource = new ProductionPlanDataSet();
            ProductionPlanDataSet.ProductionPlanRow row = dataSource.ProductionPlan.NewProductionPlanRow();
            row.ProductionPlanId = productionPlan.ProductionPlanId;
            row.Code = productionPlan.Code;
            row.SalesOrder = productionPlan.SalesOrderCode;

            List<ProductionPlanDetail> details = productionPlan.Details;
            if (details.Count == 0)
            {
                details =
                    ServiceHelper.GetService<ProductionPlanDetail>().FindAll(
                        c => c.ProductionPlanId == productionPlan.ProductionPlanId, null);
            }
            
            row.ProductMonth = productionPlan.PlanMonth.ToString("yyyy 年 M 月");

            dataSource.ProductionPlan.Rows.Add(row);
            
            var detailRows = new List<ProductionPlanDataSet.ProductionPlanDetailRow>();

            // 获取明细信息
            for (int index = 0; index < details.Count; index++)
            {
                ProductionPlanDetail detail = details[index];

                var detailRow = dataSource.ProductionPlanDetail.NewProductionPlanDetailRow();
                detailRow.ProductionPlanId = productionPlan.ProductionPlanId;
                detailRow.ProductionPlanDetailId = index;
                detailRow.Sequence = index + 1;
                detailRow.DepartmentName = "";
                detailRow.LotNo = "";

                SkuInfo skuInfo = ServiceHelper.GetQuery<SkuInfo>().Find(t => t.SkuId == detail.SkuId);


                if (skuInfo != null)
                {
                    detailRow.CategoryName = skuInfo.CategoryName;
                    detailRow.Code = skuInfo.Code;
                    detailRow.Name = skuInfo.Name;
                }

                detailRow.Quantity = detail.Quantity;
             
                // 获取每日记录
                var productionPlanMonthItem = ServiceHelper.GetService<ProductionPlanMonthItem>().Find(c => c.ProductionPlanDetailId == detail.ProductionPlanDetailId);

                if (productionPlanMonthItem!=null)
                // 纵横表转换
                for (int i = 1; i <= 31; i++)
                {
                    switch (i)
                    {
                        case 1:
                            if (productionPlanMonthItem.Item0>0)
                            detailRow.DataColumn1 = productionPlanMonthItem.Item0;
                            break;
                        case 2:
                            if (productionPlanMonthItem.Item1 > 0)
                            detailRow.DataColumn2 = productionPlanMonthItem.Item1;
                            break;
                        case 3: if (productionPlanMonthItem.Item2 > 0)
                            detailRow.DataColumn3 = productionPlanMonthItem.Item2;
                            break;
                        case 4: if (productionPlanMonthItem.Item3 > 0)
                            detailRow.DataColumn4 = productionPlanMonthItem.Item3;
                            break;
                        case 5: if (productionPlanMonthItem.Item4 > 0)
                            detailRow.DataColumn5 = productionPlanMonthItem.Item4;
                            break;
                        case 6: if (productionPlanMonthItem.Item5 > 0)
                            detailRow.DataColumn6 = productionPlanMonthItem.Item5;
                            break;
                        case 7: if (productionPlanMonthItem.Item6 > 0)
                            detailRow.DataColumn7 = productionPlanMonthItem.Item6;
                            break;
                        case 8: if (productionPlanMonthItem.Item7 > 0)
                            detailRow.DataColumn8 = productionPlanMonthItem.Item7;
                            break;
                        case 9: if (productionPlanMonthItem.Item8 > 0)
                            detailRow.DataColumn9 = productionPlanMonthItem.Item8;
                            break;
                        case 10: if (productionPlanMonthItem.Item9 > 0)
                            detailRow.DataColumn10 = productionPlanMonthItem.Item9;
                            break;
                        case 11: if (productionPlanMonthItem.Item10 > 0)
                            detailRow.DataColumn11 = productionPlanMonthItem.Item10;
                            break;
                        case 12: if (productionPlanMonthItem.Item11 > 0)
                            detailRow.DataColumn12 = productionPlanMonthItem.Item11;
                            break;
                        case 13: if (productionPlanMonthItem.Item12 > 0)
                            detailRow.DataColumn13 = productionPlanMonthItem.Item12;
                            break;
                        case 14: if (productionPlanMonthItem.Item13 > 0)
                            detailRow.DataColumn14 = productionPlanMonthItem.Item13;
                            break;
                        case 15: if (productionPlanMonthItem.Item14 > 0)
                            detailRow.DataColumn15 = productionPlanMonthItem.Item14;
                            break;
                        case 16: if (productionPlanMonthItem.Item15 > 0)
                            detailRow.DataColumn16 = productionPlanMonthItem.Item15;
                            break;
                        case 17: if (productionPlanMonthItem.Item16 > 0)
                            detailRow.DataColumn17 = productionPlanMonthItem.Item16;
                            break;
                        case 18: if (productionPlanMonthItem.Item17 > 0)
                            detailRow.DataColumn18 = productionPlanMonthItem.Item17;
                            break;
                        case 19: if (productionPlanMonthItem.Item18 > 0)
                            detailRow.DataColumn19 = productionPlanMonthItem.Item18;
                            break;
                        case 20: if (productionPlanMonthItem.Item19 > 0)
                            detailRow.DataColumn20 = productionPlanMonthItem.Item19;
                            break;
                        case 21: if (productionPlanMonthItem.Item20 > 0)
                            detailRow.DataColumn21 = productionPlanMonthItem.Item20;
                            break;
                        case 22: if (productionPlanMonthItem.Item21 > 0)
                            detailRow.DataColumn22 = productionPlanMonthItem.Item21;
                            break;
                        case 23: if (productionPlanMonthItem.Item22 > 0)
                            detailRow.DataColumn23 = productionPlanMonthItem.Item22;
                            break;
                        case 24: if (productionPlanMonthItem.Item23 > 0)
                            detailRow.DataColumn24 = productionPlanMonthItem.Item23;
                            break;
                        case 25: if (productionPlanMonthItem.Item24 > 0)
                            detailRow.DataColumn25 = productionPlanMonthItem.Item24;
                            break;
                        case 26: if (productionPlanMonthItem.Item25 > 0)
                            detailRow.DataColumn26 = productionPlanMonthItem.Item25;
                            break;
                        case 27: if (productionPlanMonthItem.Item26 > 0)
                            detailRow.DataColumn27 = productionPlanMonthItem.Item26;
                            break;
                        case 28: if (productionPlanMonthItem.Item27 > 0)
                            detailRow.DataColumn28 = productionPlanMonthItem.Item27;
                            break;
                        case 29: if (productionPlanMonthItem.Item28 > 0)
                            detailRow.DataColumn29 = productionPlanMonthItem.Item28;
                            break;
                        case 30: if (productionPlanMonthItem.Item29 > 0)
                            detailRow.DataColumn30 = productionPlanMonthItem.Item29;
                            break;
                        case 31: if (productionPlanMonthItem.Item30 > 0)
                            detailRow.DataColumn31 = productionPlanMonthItem.Item30;
                            break;
                        default:
                            break;
                    }
                }

                detailRows.Add(detailRow);
                dataSource.ProductionPlanDetail.Rows.Add(detailRow);
            }
            
            report.DataSource = dataSource;
            report.CreateDocument();
            return report;
        }

        /// <summary>
        /// 生产工单报表
        /// </summary>
        /// <param name="productionOrder"></param>
        /// <returns></returns>
        public static XtraReport GetReport(this ProductionOrder productionOrder)
        {
            XtraReport report = new ProductionProcessOrderReport();

            var dataSource = new ProductionOrderDataSet();

            ProductionOrderDataSet.ProductionOrderRow row = dataSource.ProductionOrder.NewProductionOrderRow();
            row.Code = productionOrder.Code;
            if (productionOrder.ProductionDate>DateTimeHelper.Min)
            row.ProductionDate = productionOrder.ProductionDate;
            row.ProductionOrderId = productionOrder.ProductionOrderId;
            row.ProductPlan = productionOrder.ProductionPlanCode;
            User user = ServiceHelper.GetService<User>().GetById(productionOrder.CreaterId);
            if (user != null) row.CreaterName = user.Name;
            row.CreaterTime = productionOrder.CreateTime;
            dataSource.ProductionOrder.Rows.Add(row);

            List<ProductionOrderDetail> details = productionOrder.Details;
            if (details.Count == 0)
            {
                details =
                    ServiceHelper.GetService<ProductionOrderDetail>().FindAll(
                        c => c.ProductionOrderId == productionOrder.ProductionOrderId, null);
            }

            // 获取明细信息
            for (int index = 0; index < details.Count; index++)
            {
                ProductionOrderDetail detail = details[index];
                ProductionOrderDataSet.ProductionOrderDetailRow detailRow =
                    dataSource.ProductionOrderDetail.NewProductionOrderDetailRow();

                detailRow.Sequence = index + 1;
                detailRow.ProductionOrderId = productionOrder.ProductionOrderId;
                detailRow.ProductionOrderDetailId = detail.ProductionOrderDetailId;
                SkuInfo skuInfo = ServiceHelper.GetQuery<SkuInfo>().Find(t => t.SkuId == detail.SkuId);

                //明细中Sku信息
                if (skuInfo != null)
                {
                    detailRow.CategoryName = skuInfo.CategoryName;
                    detailRow.Code = skuInfo.Code;
                    detailRow.Model = skuInfo.Model;
                    detailRow.Spec = skuInfo.Spec;
                    detailRow.Name = skuInfo.Name;
                }

                detailRow.Quantity = detail.Quantity;
                detailRow.Remark = "";
                dataSource.ProductionOrderDetail.Rows.Add(detailRow);
            }
            report.DataSource = dataSource;
            report.CreateDocument();
            return report;
        }

        /// <summary>
        /// 检验单报表
        /// </summary>
        /// <param name="itemInspect"></param>
        /// <returns></returns>
        public static XtraReport GetReport(this ItemInspect itemInspect)
        {
            XtraReport report = new ProductionOrderReport();

            var dataSource = new ProductionOrderDataSet();
            // 未使用：
            report.DataSource = dataSource;

            report.CreateDocument();
            return report;
        }

        /// <summary>
        /// PCB检验单
        /// </summary>
        /// <param name="pcbInspect"></param>
        /// <returns></returns>
        public static XtraReport GetReport(this PcbInspect pcbInspect)
        {
            XtraReport report = new ProductionOrderReport();

            var dataSource = new ProductionOrderDataSet();
            // 未使用：
            report.DataSource = dataSource;

            report.CreateDocument();
            return report;
        }
    }
}