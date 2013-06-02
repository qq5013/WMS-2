using System.Collections.Generic;
using Business.Domain.Warehouse;

namespace Business.Domain.Wms
{
    public class Sku : DomainObject
    {
        #region property

        /// <summary>
        /// 货物编号
        /// </summary>
        public int SkuId { get; set; }

        /// <summary>
        /// 客户编号
        /// </summary>
        public int ClientId { get; set; }

        /// <summary>
        /// 商家编号
        /// </summary>
        public int MerchantId { get; set; }

        /// <summary>
        /// 制造商编号
        /// </summary>
        public int Manufacturer { get; set; }

        /// <summary>
        /// 货物代码
        /// </summary>
        public string SkuNumber { get; set; }

        /// <summary>
        /// 货物名称
        /// </summary>
        public string SkuName { get; set; }

        /// <summary>
        /// ERP代码
        /// </summary>
        public string ErpCode { get; set; }

        /// <summary>
        /// 品牌
        /// </summary>
        public string Brand { get; set; }

        /// <summary>
        /// 规格
        /// </summary>
        public string Specification { get; set; }

        /// <summary>
        /// 型号
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// 通用产品代码
        /// </summary>
        public string Upc { get; set; }

        /// <summary>
        /// 管理分类编号
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// 条码
        /// </summary>
        public string Barcode { get; set; }

        /// <summary>
        /// 保质期年
        /// </summary>
        public int GuranteePeriodYear { get; set; }

        /// <summary>
        /// 保质期月
        /// </summary>
        public int GuranteePeriodMonth { get; set; }

        /// <summary>
        /// 保质期天
        /// </summary>
        public int GuranteePeriodDay { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 创建用户
        /// </summary>
        public int CreateUser { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public string CreateTime { get; set; }

        /// <summary>
        /// 编辑用户
        /// </summary>
        public int EditUser { get; set; }

        /// <summary>
        /// 编辑时间
        /// </summary>
        public string EditTime { get; set; }

        /// <summary>
        /// 是否激活
        /// </summary>
        public bool IsActive { get; set; }

        #endregion property

        //#region additional property

        //public Company Client { get; set; }

        //public Company Merchant { get; set; }

        //public CategoryManagement CategoryManagement { get; set; }

        //public SkuManagement SkuManagement { get; set; }

        //public Pack DefaultPack { get; set; }

        //public IList<Pack> Packs { get; set; }

        //public IList<BatchProperty> BatchProperties { get; set; }

        //public IList<Tag> Tags { get; set; }

        //public IList<Location> PickLocations { get; set; }

        //public IList<Location> StoreLocations { get; set; }

        //#endregion additional property
    }
}