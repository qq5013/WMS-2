using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Business.Domain.Mobile.Mobile
{
    public class PutawayTaskResult
    {
        ///// <summary>
        ///// 关联单据编号
        ///// </summary>
        //public int LinkBillId { get; set; }

        /// <summary>
        /// 上架仓库代码
        /// </summary>
        public string WarehouseCode { get; set; }

        /// <summary>
        /// 入库单据号
        /// </summary>
        public string BillNumber { get; set; }

        /// <summary>
        /// 上架时间
        /// </summary>
        public string TransferTime { get; set; }

        ///// <summary>
        ///// 库位代码
        ///// </summary>
        //public string TargetLocationCode { get; set; }

        ///// <summary>
        ///// 上架库位条码
        ///// </summary>
        //public string LocationBarcode { get; set; }

        ///// <summary>
        ///// 容器代码
        ///// </summary>
        //public string TargetContainerCode { get; set; }


        public List<PutawayTaskResultDetail> Details { get; set; }

        public int Operator { get; set; }

        ///// <summary>
        ///// 货物名称
        ///// </summary>
        //public string SkuName { get; set; }

        ///// <summary>
        ///// 货物代码
        ///// </summary>
        //public string SkuNumber { get; set; }
    }

    public class PutawayTaskResultDetail
    {
        ///// <summary>
        ///// 关联单据编号
        ///// </summary>
        //public int LinkBillId { get; set; }

        ///// <summary>
        ///// 移库单编号
        ///// </summary>
        //public int BillId { get; set; }

        ///// <summary>
        ///// 库存编号
        ///// </summary>
        //public int StockId { get; set; }

        ///// <summary>
        ///// 货物编号
        ///// </summary>
        //public int SkuId { get; set; }

        ///// <summary>
        ///// 包装单位
        ///// </summary>
        //public int PackId { get; set; }

        ///// <summary>
        ///// 目标库位
        ///// </summary>
        //public int TargetLocationId { get; set; }

        ///// <summary>
        ///// 目标容器
        ///// </summary>
        //public int TargetContainerId { get; set; }

        ///// <summary>
        ///// 包装名称
        ///// </summary>
        //public string PackName { get; set; }

        ///// <summary>
        ///// 上架批次号
        ///// </summary>
        //public string BatchNumber { get; set; }

        ///// <summary>
        ///// 是否单件管理
        ///// </summary>
        //public bool IsPieceManagement { get; set; }

        ///// <summary>
        ///// 数量
        ///// </summary>
        //public int TransferQty { get; set; }

        ///// <summary>
        ///// 是否移动容器
        ///// </summary>
        //public bool IsTransferContainer { get; set; }

        ///// <summary>
        ///// 容器条码
        ///// </summary>
        //public string ContainerBarcode { get; set; }

        ///// <summary>
        ///// 货物代码
        ///// </summary>
        //public string SkuNumber { get; set; }

        ///// <summary>
        ///// 原容器
        ///// </summary>
        //public int SourceContainerId { get; set; }

        ///// <summary>
        ///// 原容器条码
        ///// </summary>
        //public string SourceContainerNumber { get; set; }

        ///// <summary>
        ///// 原库位
        ///// </summary>
        //public int SourceLocationId { get; set; }

        ///// <summary>
        ///// 原库位条码
        ///// </summary>
        //public string SourceLocationNumber { get; set; }

        ///// <summary>
        ///// 上架库位条码
        ///// </summary>
        //public string LocationBarcode { get; set; }

        ///// <summary>
        ///// 计划移库数量
        ///// </summary>
        //public int PlanQty { get; set; }


        /// <summary>
        /// 周转容器条码
        /// </summary>
        public string SourceContainerBarcode { get; set; }

        public string TargetContainerBarcode { get; set; }

        public string SourceLocationBarcode { get; set; }

        public string TargetLocationBarcode { get; set; }

        /// <summary>
        /// 货物代码
        /// </summary>
        public string SkuNumber { get; set; }

        /// <summary>
        /// 包装名称
        /// </summary>
        public string PackName { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public int TransferedQty { get; set; }

        /// <summary>
        /// 入库批次
        /// </summary>
        public string BatchNumber { get; set; }

        /// <summary>
        /// 是否单件管理
        /// </summary>
        public bool IsPieceManagement { get; set; }

        public bool IsTransferContainer { get; set; }
    }
}
