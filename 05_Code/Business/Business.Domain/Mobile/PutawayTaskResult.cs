using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Domain.Mobile
{
    public class PutawayTaskResult
    {
        /// <summary>
        /// 上架仓库代码
        /// </summary>
        public string WarehouseCode { get; set; }

        /// <summary>
        /// 上架任务单据号
        /// </summary>
        public string BillNumber { get; set; }

        /// <summary>
        /// 上架时间
        /// </summary>
        public string TransferTime { get; set; }

        /// <summary>
        /// 上架操作员
        /// </summary>
        public int Operator { get; set; }

        /// <summary>
        /// 上架操作明细信息
        /// </summary>
        public List<PutawayTaskResultDetail> Details { get; set; }
    }

    public class PutawayTaskResultDetail
    {
        /// <summary>
        /// 原收货库位条码
        /// </summary>
        public string SourceLocationBarcode { get; set; }

        /// <summary>
        /// 上架库位条码
        /// </summary>
        public string TargetLocationBarcode { get; set; }

        /// <summary>
        /// 原周转/存储容器条码
        /// </summary>
        public string SourceContainerBarcode { get; set; }

        /// <summary>
        /// 上架存储容器条码
        /// </summary>
        public string TargetContainerBarcode { get; set; }

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

        /// <summary>
        /// 是否整容器上架
        /// </summary>
        public bool IsTransferContainer { get; set; }
    }
}
