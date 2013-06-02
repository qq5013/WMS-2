namespace Business.Domain.Inventory.Views
{
    public class StockView : Stock
    {
        public int AreaId { get; set; }
        public string AreaCode { get; set; }
        public string AreaName { get; set; }
        public int AreaType { get; set; }
        public string WarehouseCode { get; set; }
        public string WarehouseName { get; set; }
        public string SkuNumber { get; set; }
        public string LocationCode { get; set; }
        public string LocationName { get; set; }
        public string ContainerCode { get; set; }
        public string ContainerName { get; set; }
        public string SkuName { get; set; }
        public string PackName { get; set; }
        public string PlanNumber { get; set; }
        public string BillNumber { get; set; }
        public string InboundDate { get; set; }
        public int MerchantId { get; set; }
        public int VendorId { get; set; }

        public string ProductionDate { get; set; }
        public string ExpiringDate { get; set; }
        public string ProductionBatch { get; set; }
        public string ManufacturingOrigin { get; set; }
        public string PropertyValue1 { get; set; }
        public string PropertyValue2 { get; set; }
        public string PropertyValue3 { get; set; }
        public string PropertyValue4 { get; set; }
        public string PropertyValue5 { get; set; }
        public string PropertyValue6 { get; set; }

        public string StorageDays { get; set; }
    }
}
