using System.Collections.Generic;

namespace Business.Domain.Inventory
{
    public class Package : DomainObject
    {
        /// <summary> 
        /// 包裹编号
        /// </summary> 
        public int PackageId { get; set; }

        /// <summary> 
        /// 包裹号
        /// </summary> 
        public string PackageNumber { get; set; }

        /// <summary> 
        /// 发货仓库编号
        /// </summary> 
        public int WarehouseId { get; set; }

        /// <summary> 
        /// 出库单编号
        /// </summary> 
        public int BillId { get; set; }

        /// <summary> 
        /// 关联单号
        /// </summary> 
        public string LinkBillNumber { get; set; }

        /// <summary> 
        /// 包裹索引
        /// </summary> 
        public int PackageIndex { get; set; }

        /// <summary> 
        /// 包裹重量
        /// </summary> 
        public decimal Weight { get; set; }

        /// <summary> 
        /// 包裹体积
        /// </summary> 
        public decimal Volume { get; set; }

        #region additional property

        public IList<PackageDetail> Details { get; set; }

        #endregion
    }
}