using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Domain.Mobile
{
    public class PutawayTask
    {
        /// <summary>
        /// 入库仓库代码
        /// </summary>
        public string WarehouseCode { get; set; }

        /// <summary>
        /// 上架任务单据号
        /// </summary>
        public string BillNumber { get; set; }

        /// <summary>
        /// 关联单据号
        /// </summary>
        public string LinkBillNumber { get; set; }

        /// <summary>
        /// 计划收货时间
        /// </summary>
        public string PlanTransferDate { get; set; }

        /// <summary>
        /// 收货库位名
        /// </summary>
        public string ReceivingLocationName { get; set; }

        /// <summary>
        /// 收货库位条码
        /// </summary>
        public string ReceivingLocationBarcode { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 收货任务明细信息
        /// </summary>
        public List<PutawayTaskDetail> Details { get; set; }
    }

    public class PutawayTaskDetail
    {
        /// <summary>
        /// 周转/存储容器名称
        /// </summary>
        public string ContainerName { get; set; }

        /// <summary>
        /// 周转/周转容器条码
        /// </summary>
        public string ContainerBarcode { get; set; }

        /// <summary>
        /// 货物名称
        /// </summary>
        public string SkuName { get; set; }

        /// <summary>
        /// 货物代码
        /// </summary>
        public string SkuNumber { get; set; }

        /// <summary>
        /// 货物条码
        /// </summary>
        public string Barcode { get; set; }

        /// <summary>
        /// UPC条码
        /// </summary>
        public string UPC { get; set; }

        /// <summary>
        /// 包装名称
        /// </summary>
        public string PackName { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public int Qty { get; set; }

        /// <summary>
        /// 入库批次
        /// </summary>
        public string BatchNumber { get; set; }

        /// <summary>
        /// 是否单件管理
        /// </summary>
        public bool IsPieceManagement { get; set; }
    }
}
