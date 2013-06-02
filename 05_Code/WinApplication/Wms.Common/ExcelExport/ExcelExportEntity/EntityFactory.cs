using System;
using System.Collections;
using System.Linq;
using System.Text;
using Wms.Common;
using ecWMS.Business.Entity;
using ecWMS.Business.Common;
using System.Collections.Generic;
using ecWMS.Business.Entity.Extend;
using ecWMS.Common.ExcelExport.ExcelExportEntity.Export;

namespace ecWMS.Common.ExcelExport.ExcelExportEntity
{
    public class EntityFactory : IEntityFactory
    {
        private BllResult _bllResult; 

        #region IEntityFactory Members

        public IList<InBoundTemplate> GetInBoundTemplateByInBoundBillId(int billId)
        {
            //InBoundTemplate inBoundTemplate = null;
            IList<InBoundTemplate> list = new List<InBoundTemplate>();
            if(billId > 0)
            {

                var arrayList1 = ServiceHelper.FacadeService.GetByCondition(out _bllResult, typeof(InboundPlanDetail).FullName, "InboundPlanID = " + billId);
                if (arrayList1 != null && arrayList1.Count > 0)
                {
                    int row = arrayList1.Count / 10;
                    if((arrayList1.Count % 10)>0)
                    {
                        row++;
                    }

                    var arrayList = ServiceHelper.FacadeService.GetByCondition(out _bllResult, typeof (InboundPlan).FullName,
                                                                      "InboundPlanID = " + billId);
                    if (arrayList != null && arrayList.Count > 0)
                    {
                        var inboundPlan = (InboundPlan) arrayList[0];
                        if (inboundPlan != null)
                        {
                            var inBoundTemplate = new InBoundTemplate();
                            inBoundTemplate.InBoundBillCode = inboundPlan.InboundPlanCode;
                            if (!string.IsNullOrEmpty(inboundPlan.PlanReceiveDate))
                            {
                                inBoundTemplate.InBoundDate = inboundPlan.PlanReceiveDate;
                            }

                            var arrayListCompany = ServiceHelper.FacadeService.GetByCondition(out _bllResult, typeof(Company).FullName,
                                                                              "CompanyID = " + inboundPlan.ProviderId);
                            if (arrayListCompany != null && arrayListCompany.Count > 0)
                            {
                                var company = (Company) arrayListCompany[0];
                                if(company != null)
                                {
                                    inBoundTemplate.Provider = company.CompanyName;
                                    inBoundTemplate.LinkMan = company.Contactor;
                                    inBoundTemplate.LinkPhone = company.Phone;
                                }
                            }

                            var arrayListDataDictionary = ServiceHelper.FacadeService.GetByCondition(out _bllResult, typeof(DataDictionary).FullName,
                                                                              "DictionaryID = " + inboundPlan.InboundType);
                            if (arrayListDataDictionary != null && arrayListDataDictionary.Count > 0)
                            {
                                var dataDictionary = (DataDictionary)arrayListDataDictionary[0];
                                if (dataDictionary != null)
                                {
                                    inBoundTemplate.InBoundType = dataDictionary.DictionaryValue;
                                }
                            }
                            int i = 1;
                            bool test = false;
                            foreach (InboundPlanDetail info in arrayList1)
                            {
                                test = false;
                                var inBoundTemplateDetail = new InBoundTemplateDetail();
                                inBoundTemplateDetail.Index = i.ToString();
                                inBoundTemplateDetail.ItemCode = info.GoodsCode;
                                inBoundTemplateDetail.ItemName = info.GoodsName;
                                bool flag = ServiceHelper.FacadeService.IsBatchManagement(info.GoodsId);
                                inBoundTemplateDetail.Management = flag == true ? "Y" : "N";
                                //if (inboundPlan)
                                flag = ServiceHelper.FacadeService.IsPieceManagement(info.GoodsId);
                                inBoundTemplateDetail.UPC = flag == true ? "Y" : "N";
                                flag = ServiceHelper.FacadeService.IsNeedToWeight(info.GoodsId,info.GoodsPacket);
                                inBoundTemplateDetail.Heavey = flag == true ? "Y" : "N";
                                inBoundTemplateDetail.PlanQutity = info.GoodsQty > 0 ? info.GoodsQty.ToString() : "";
                                inBoundTemplateDetail.FactQutity = info.ReceivedGoodsQty > 0 ? info.ReceivedGoodsQty.ToString() : "";

                                inBoundTemplate.InBoundTemplateDetailList.Add(inBoundTemplateDetail);

                                if ((i % 10) == 0)
                                {
                                    list.Add(inBoundTemplate);
                                    inBoundTemplate.InBoundTemplateDetailList.Clear();
                                    i = 0;
                                    test = true;
                                }
                                i++;
                            }
                            if (!test)
                            {
                                list.Add(inBoundTemplate);
                            }
                        }
                    }
                }
            }
            return list;
        }

        public IList<PickBillBoChi> GetPickBillBoChiByPickBillId(int billId)
        {
            //InBoundTemplate inBoundTemplate = null;
            IList<PickBillBoChi> list = new List<PickBillBoChi>();
            //try
            //{
                DateTime dateTime = DateTime.Now;
                if (billId > 0)
                {
                    ArrayList arrayList1 = ServiceHelper.FacadeService.GetByCondition(out _bllResult,
                                                                             typeof (PickBill).FullName,
                                                                             string.Format("PickBillID = {0}", billId));
                    if (arrayList1 != null && arrayList1.Count > 0)
                    {
                        var pickBill = (PickBill) arrayList1[0];
                        if (pickBill != null)
                        {
                            ArrayList arrayList =
                                ServiceHelper.FacadeService.GetDistinctPickWave(billId);
                            if (arrayList != null && arrayList.Count > 0)
                            {
                                int info = Convert.ToInt32(arrayList[0]);
                                var pickBillBoChi = new PickBillBoChi();
                                pickBillBoChi.PickBillCode = pickBill.PickBillCode;
                                var arrayList2 = ServiceHelper.FacadeService.GetByCondition(out _bllResult,
                                                                                   typeof (OrderDistribution).
                                                                                       FullName,
                                                                                   " OutboundPlanID = " + info);
                                if (arrayList2 != null && arrayList2.Count > 0)
                                {
                                    var orderDistribution = (OrderDistribution) arrayList2[0];
                                    if (orderDistribution != null)
                                    {
                                        bool test = ServiceHelper.FacadeService.ValidateOutboundBatch(billId);
                                        ArrayList company = ServiceHelper.FacadeService.GetByCondition(out _bllResult,
                                                                                              typeof (DataDictionary
                                                                                                  ).FullName,
                                                                                              " DictionaryID = " +
                                                                                              orderDistribution.
                                                                                                  DeliveryWay);
                                        if (company != null && company.Count > 0)
                                        {
                                            pickBillBoChi.DeliveryCompany =
                                                ((DataDictionary) company[0]).DictionaryValue;
                                        }
                                        var dataDictionary = ServiceHelper.FacadeService.GetByCondition(out _bllResult,
                                                                                               typeof (
                                                                                                   DataDictionary).
                                                                                                   FullName,
                                                                                               String.Format(
                                                                                                   " DictionaryID IN (SELECT PickingMode FROM dbo.PickWave WHERE PickBillID = {0} AND OutboundPlanID = {1} ) ",
                                                                                                   billId, info));
                                        if (dataDictionary != null && dataDictionary.Count > 0)
                                        {
                                            pickBillBoChi.PickMode =
                                                ((DataDictionary) dataDictionary[0]).DictionaryValue;
                                        }
                                        pickBillBoChi.GeneryTime = dateTime.ToString("yyyy-MM-dd HH-mm-ss");

                                        var pickwareList = ServiceHelper.FacadeService.GetByCondition(out _bllResult,
                                                                                             typeof (PickWave).
                                                                                                 FullName,
                                                                                             string.Format(
                                                                                                 "[OutboundPlanID] IN ( SELECT OutboundPlanID FROM dbo.VW_OutboundPlanItemCountNoAddPro WITH (NOLOCK) WHERE ItemTypeCount = 1) AND [OutboundPlanID] = {0} AND  PickBillID = {1} ",
                                                                                                 info, billId));

                                        if (pickwareList != null && pickwareList.Count > 0)
                                        {
                                            pickBillBoChi.OrderType = "单一品种";
                                        }
                                        else
                                        {
                                            pickBillBoChi.OrderType = "多品种";
                                        }
                                        pickBillBoChi.OrderCount = arrayList.Count.ToString();
                                        pickwareList = ServiceHelper.FacadeService.GetByCondition(out _bllResult,
                                                                                         typeof (PickWave).
                                                                                             FullName,
                                                                                         string.Format(
                                                                                             " PickBillID = {0} AND OutboundPlanID ={1}",
                                                                                             billId, info));
                                        if (pickwareList != null && pickwareList.Count > 0)
                                        {
                                            var pickWave = (PickWave) pickwareList[0];
                                            if (pickWave != null)
                                            {
                                                dataDictionary =
                                                    ServiceHelper.FacadeService.GetByCondition(out _bllResult,
                                                                                      typeof (
                                                                                          DataDictionary).
                                                                                          FullName,
                                                                                      String.Format(
                                                                                          " DictionaryID ={0} ",
                                                                                          pickWave.PickingMode));
                                                if (dataDictionary != null && dataDictionary.Count > 0)
                                                {
                                                    pickBillBoChi.PickMode =
                                                        ((DataDictionary) dataDictionary[0]).DictionaryValue;
                                                }
                                            }
                                        }
                                        //pickwareList = BLLHelper.facadeBL.GetByCondition(out _bllResult,
                                        //                                                 typeof (PickBillDetail).
                                        //                                                     FullName,
                                        //                                                 string.Format(
                                        //                                                     " PickBillID = {0} ",
                                        //                                                     billId));
                                        pickwareList = ServiceHelper.FacadeService.GetPickBillDetailExtension(billId);

                                        pickBillBoChi.ItemCount = 0;
                                        if (pickwareList != null && pickwareList.Count > 0)
                                        {
                                            IList<String> list_Name = new List<string>();
                                            foreach (PickBillDetailExtension pickWave in pickwareList)
                                            {
                                                if (!list_Name.Contains(pickWave.PlanGoodsCode))
                                                {
                                                    pickBillBoChi.ItemTypeCount++;
                                                }
                                                pickBillBoChi.ItemCount += pickWave.PlanGoodsQty;
                                            }
                                        }
                                        if (pickwareList != null && pickwareList.Count > 0)
                                        {
                                            int index = 1; //14
                                            bool flag = false;
                                            IList<PickBillBoChiDetail> pickBillBoChiDetails =
                                                new List<PickBillBoChiDetail>();
                                            foreach (PickBillDetailExtension pickWave in pickwareList)
                                            {
                                                var pickBillBoChiDetail = new PickBillBoChiDetail();
                                                pickBillBoChiDetail.Index = index;

                                                pickBillBoChiDetail.Item = pickWave.PlanGoodsCode;
                                                pickBillBoChiDetail.ITemCount = pickWave.PlanGoodsQty;
                                                pickBillBoChiDetail.ItemName = pickWave.PlanGoodsName;
                                                pickBillBoChiDetail.LocationIn = pickWave.LocationName;
                                                pickBillBoChiDetail.ITemType = pickWave.AbcTypeName;

                                                string descript = pickWave.Model;
                                                if (string.IsNullOrEmpty(descript))
                                                {
                                                    descript = pickWave.Description;
                                                }
                                                else
                                                {
                                                    if (!string.IsNullOrEmpty(pickWave.Description))
                                                    {
                                                        descript = " / " + pickWave.Description;
                                                    }
                                                }
                                                pickBillBoChiDetail.ItemDescription = descript;
                                                pickBillBoChiDetail.IsGo = test ? "是" : "否";
                                                pickBillBoChiDetails.Add(pickBillBoChiDetail);
                                                if (index == 14)
                                                {
                                                    pickBillBoChi.SubPickBillBoChiDetail = pickBillBoChiDetails;
                                                    list.Add(pickBillBoChi);
                                                    pickBillBoChiDetails = new List<PickBillBoChiDetail>();
                                                    index = 1;
                                                    flag = true;
                                                }
                                                else
                                                {
                                                    flag = false;
                                                    index++;
                                                }
                                            }
                                            if (!flag)
                                            {
                                                pickBillBoChi.SubPickBillBoChiDetail = pickBillBoChiDetails;
                                                list.Add(pickBillBoChi);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            //}
            //catch (Exception e)
            //{

            //}
            return list;
        }

        public IList<SingleOrderPickBill> GetSingleOrderPickBillByPickBillId(int billId, int billDetailId)
        {
            IList<SingleOrderPickBill> list = new List<SingleOrderPickBill>();
            DateTime dateTime = DateTime.Now;
            if (billId > 0)
            {
                ArrayList arrayList1 = ServiceHelper.FacadeService.GetByCondition(out _bllResult,
                                                                         typeof(PickBill).FullName,
                                                                         string.Format("PickBillID = {0}", billId));
                if (arrayList1 != null && arrayList1.Count > 0)
                {
                    var pickBill = (PickBill)arrayList1[0];
                    if (pickBill != null)
                    {
                        ArrayList arrayList = ServiceHelper.FacadeService.GetDistinctPickWave(billId);
                        if (arrayList != null && arrayList.Count > 0)
                        {
                            foreach (Int32 info in arrayList)
                            {
                                var pickBillBoChi = new SingleOrderPickBill();
                                var arrayList2 = ServiceHelper.FacadeService.GetByCondition(out _bllResult,
                                                                                   typeof(OrderDistribution).FullName,
                                                                                   " OutboundPlanID = " + info);
                                if (arrayList2 != null && arrayList2.Count > 0)
                                {
                                    var orderDistribution = (OrderDistribution)arrayList2[0];
                                    if (orderDistribution != null)
                                    {
                                        pickBillBoChi.OutboundPlanCode = orderDistribution.OutboundPlanCode;
                                        pickBillBoChi.OrderAddress = orderDistribution.ReceiverAddress;
                                        pickBillBoChi.OrderBillCode = orderDistribution.SalesOrderCode;
                                        pickBillBoChi.LinkPhone = orderDistribution.ReceiverPhone;
                                        bool test = ServiceHelper.FacadeService.ValidateOutboundBatch(info);
                                        ArrayList company = ServiceHelper.FacadeService.GetByCondition(out _bllResult,
                                                                                   typeof(DataDictionary).FullName,
                                                                                   " DictionaryID = " + orderDistribution.DeliveryWay);
                                        if (company != null && company.Count > 0)
                                        {
                                            pickBillBoChi.DeliveryCompany = ((DataDictionary)company[0]).DictionaryValue;
                                        }
                                        //company = BLLHelper.facadeBL.GetByCondition(out _bllResult,
                                        //                                            typeof(Company).FullName,
                                        //                                            " CompanyID = " + orderDistribution.Purchaser);
                                        //if (company != null && company.Count > 0)
                                        //{
                                        //    pickBillBoChi.OrderMan = ((Company)company[0]).CompanyName;
                                        //}
                                        pickBillBoChi.OrderMan = orderDistribution.PurchaserName;
                                        pickBillBoChi.OrderDate = dateTime.ToString("yyyy-MM-dd HH-mm-ss");

                                        ArrayList singleOrderPickBillDetails =
                                            ServiceHelper.FacadeService.GetSingleOrderPickBillDetail(
                                                billId, info);
                                        if(singleOrderPickBillDetails != null && singleOrderPickBillDetails.Count > 0)
                                        {
                                            pickBillBoChi.ItemCount = 0;
                                            pickBillBoChi.TotalMonery = 0;
                                            foreach (SingleOrderPickBillDetail singleOrderPickBillDetail in singleOrderPickBillDetails)
                                            {
                                                pickBillBoChi.ItemCount += singleOrderPickBillDetail.ItemCount;
                                                pickBillBoChi.TotalMonery += singleOrderPickBillDetail.Price;
                                            }
                                            int num = 0;
                                            bool flag = false;
                                            foreach (SingleOrderPickBillDetail singleOrderPickBillDetail in singleOrderPickBillDetails)
                                            {
                                                var location = ServiceHelper.FacadeService.GetPickLocation(singleOrderPickBillDetail.GoodsId,
                                                                              GlobalState.LoginUserWarehouse);
                                                if (location != null)
                                                {
                                                    singleOrderPickBillDetail.LocationId = location.LocationName;
                                                }
                                                flag = false;
                                                if(num==0)
                                                {
                                                    pickBillBoChi.SingleOrderPickBillDetails=new List<SingleOrderPickBillDetail>();
                                                }
                                                num++;
                                                pickBillBoChi.SingleOrderPickBillDetails.Add((SingleOrderPickBillDetail)singleOrderPickBillDetail);
                                                if(num==28)
                                                {
                                                    flag = true;
                                                    list.Add(GetSingleOrderPickBill(pickBillBoChi));
                                                    pickBillBoChi.SingleOrderPickBillDetails.Clear();
                                                    num = 0;
                                                }
                                            }
                                            if(!flag)
                                            {
                                                list.Add(GetSingleOrderPickBill(pickBillBoChi));
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return list;
        }

        private SingleOrderPickBill GetSingleOrderPickBill(SingleOrderPickBill bill)
        {
            var singleOrderPickBill = new SingleOrderPickBill();
            singleOrderPickBill.DeliveryCompany = bill.DeliveryCompany;
            singleOrderPickBill.ItemCount = bill.ItemCount;
            singleOrderPickBill.LinkPhone = bill.LinkPhone;
            singleOrderPickBill.OrderAddress = bill.OrderAddress;
            singleOrderPickBill.OrderBillCode = bill.OrderBillCode;
            singleOrderPickBill.OrderDate = bill.OrderDate;
            singleOrderPickBill.OrderMan = bill.OrderMan;
            singleOrderPickBill.OutboundPlanCode = bill.OutboundPlanCode;
            singleOrderPickBill.Remark = bill.Remark;
            singleOrderPickBill.TotalMonery = bill.TotalMonery;
            if (bill.SingleOrderPickBillDetails != null)
            {
                singleOrderPickBill.SingleOrderPickBillDetails = new List<SingleOrderPickBillDetail>();
                foreach(SingleOrderPickBillDetail info in bill.SingleOrderPickBillDetails)
                {
                    singleOrderPickBill.SingleOrderPickBillDetails.Add(info);
                }
            }
            
            return singleOrderPickBill;
        }

        public IList<TransferBillTemplate> GetTransferBillTemplateByTransferBillId(int billId)
        {
            IList<TransferBillTemplate> list = new List<TransferBillTemplate>();

            ArrayList arrayList = ServiceHelper.FacadeService.GetByCondition(out _bllResult,
                                                                    typeof(TransferBillDetail).FullName,
                                                                    string.Format("[TransferBillID] = {0}", billId));
            if(arrayList != null && arrayList.Count >0)
            {
                TransferBillTemplate transferBillTemplate = null;
                int index = 0;
                IList<TransferBillTemplateDetail> lists = new List<TransferBillTemplateDetail>();
                bool flag = false;
                foreach(TransferBillDetail info in arrayList)
                {
                    if (index == 0)
                    {
                        transferBillTemplate = GetTransferBillTemplateById(billId);
                        transferBillTemplate.TransferBillTemplates = new List<TransferBillTemplateDetail>();
                        flag = false;
                    }
                    var detail = new TransferBillTemplateDetail();
                    detail.BatchNo = info.Property1;
                    detail.Index = index + 1;
                    detail.ItemCode = info.GoodsCode;
                    detail.ItemName = info.GoodsName;
                    detail.ItemPack = ""; 
                    ArrayList lists1 = ServiceHelper.FacadeService.GetByCondition(out _bllResult,
                                                                      typeof(Packet).FullName,
                                                                      string.Format("[PacketID] = {0}", info.PlanGoodsPacket));
                    if (lists1 != null && lists1.Count > 0)
                    {
                        var user = (Packet)lists1[0];
                        detail.ItemPack = user.PacketName;
                    }

                    detail.PlanTransferQuantity = info.PlanGoodsQty > 0 ? info.PlanGoodsQty.ToString() : "0";
                    detail.TransferQuantity = info.GoodsQty > 0 ? info.GoodsQty.ToString() : "0";
                    detail.SourceLocation = "";
                    detail.TargetUnit = "";
                    detail.SourceUnit = "";
                    detail.TargetLocation = "";
                    lists1 = ServiceHelper.FacadeService.GetByCondition(out _bllResult,
                                                                       typeof(Location).FullName,
                                                                       string.Format("[LocationID] = {0}", info.SourceLocation));
                    if (lists1 != null && lists1.Count > 0)
                    {
                        var user = (Location)lists1[0];
                        detail.SourceLocation = user.LocationName;
                    }
                    lists1 = ServiceHelper.FacadeService.GetByCondition(out _bllResult,
                                                                       typeof(Location).FullName,
                                                                       string.Format("[LocationID] = {0}", info.TargetLocation));
                    if (lists1 != null && lists1.Count > 0)
                    {
                        var user = (Location)lists1[0];
                        detail.TargetLocation = user.LocationName;
                    }
                    lists1 = ServiceHelper.FacadeService.GetByCondition(out _bllResult,
                                                                       typeof(StorageUnit).FullName,
                                                                       string.Format("[StorageUnitID] = {0}", info.SourceStorageUnit));
                    if (lists1 != null && lists1.Count > 0)
                    {
                        var user = (StorageUnit)lists1[0];
                        detail.SourceUnit = user.StorageUnitName;
                    }
                    lists1 = ServiceHelper.FacadeService.GetByCondition(out _bllResult,
                                                                       typeof(StorageUnit).FullName,
                                                                       string.Format("[StorageUnitID] = {0}", info.TargetStorageUnit));
                    if (lists1 != null && lists1.Count > 0)
                    {
                        var user = (StorageUnit)lists1[0];
                        detail.TargetUnit = user.StorageUnitName;
                    }
                    if(index == 14)
                    {
                        transferBillTemplate.TransferBillTemplates.Add(detail);
                        list.Add(transferBillTemplate);
                        index = 0;
                        flag = true;
                    }
                    else
                    {
                        transferBillTemplate.TransferBillTemplates.Add(detail);
                    }
                    index++;
                }
                if (!flag)
                {
                    if (transferBillTemplate != null)
                    {
                        list.Add(transferBillTemplate);
                    }
                }
            }
            else
            {
                list.Add(GetTransferBillTemplateById(billId));
            }
            return list;
        }

        private TransferBillTemplate GetTransferBillTemplateById(int id)
        {
            TransferBillTemplate transferBillTemplate = null;
            ArrayList arrayList = ServiceHelper.FacadeService.GetByCondition(out _bllResult,
                                                                    typeof (TransferBill).FullName,
                                                                    string.Format("[TransferBillID] = {0}", id));
            if(arrayList != null && arrayList.Count > 0)
            {
                var transferBill = (TransferBill) arrayList[0];
                if(transferBill != null)
                {
                    transferBillTemplate = new TransferBillTemplate();
                    transferBillTemplate.TransferBillCode = transferBill.TransferBillCode;
                    transferBillTemplate.TransferDate = transferBill.TransferTime;
                    transferBillTemplate.TransferPlanDate = transferBill.PlanTransferDate;
                    transferBillTemplate.TransferMemo = transferBill.Description;
                    transferBillTemplate.TransferOperator = "";
                    transferBillTemplate.TransferType = "";
                    transferBillTemplate.TransferWarehouse = "";
                    ArrayList lists = ServiceHelper.FacadeService.GetByCondition(out _bllResult,
                                                                    typeof(User).FullName,
                                                                    string.Format("[UserID] = {0}", transferBill.Operator));
                    if(lists != null && lists.Count>0)
                    {
                        var user = (User)lists[0];
                        transferBillTemplate.TransferOperator = user.UserName;
                    }
                    lists = ServiceHelper.FacadeService.GetByCondition(out _bllResult,
                                                                     typeof(DataDictionary).FullName,
                                                                     string.Format("[DictionaryID] = {0}", transferBill.TransferType));
                    if (lists != null && lists.Count > 0)
                    {
                        var user = (DataDictionary)lists[0];
                        transferBillTemplate.TransferType = user.DictionaryValue;
                    }
                    lists = ServiceHelper.FacadeService.GetByCondition(out _bllResult,
                                                                     typeof(Warehouse).FullName,
                                                                     string.Format("[WarehouseID] = {0}", transferBill.WarehouseId));
                    if (lists != null && lists.Count > 0)
                    {
                        var user = (Warehouse)lists[0];
                        transferBillTemplate.TransferWarehouse = user.WarehouseName;
                    }
                    transferBillTemplate.TransferUnit = transferBill.IsTransferStorageUnit ? "是" : "否";
                }
            }
            return transferBillTemplate;
        }

        #endregion
    }
}
