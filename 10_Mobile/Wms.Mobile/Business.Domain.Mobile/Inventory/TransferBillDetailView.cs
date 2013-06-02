using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Business.Domain.Mobile.Inventory
{
    public class TransferBillDetailView
    {
        /// <summary>
        /// 自动编号
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 移库单编号
        /// </summary>
        public int BillId { get; set; }

        /// <summary>
        /// 库存编号
        /// </summary>
        public int StockId { get; set; }

        /// <summary>
        /// 货物编号
        /// </summary>
        public int SkuId { get; set; }

        /// <summary>
        /// 包装单位
        /// </summary>
        public int PackId { get; set; }



        /// <summary>
        /// 原库位
        /// </summary>
        public int SourceLocationId { get; set; }

        /// <summary>
        /// 目标库位
        /// </summary>
        public int TargetLocationId { get; set; }

        /// <summary>
        /// 原容器
        /// </summary>
        public int SourceContainerId { get; set; }

        /// <summary>
        /// 目标容器
        /// </summary>
        public int TargetContainerId { get; set; }

        /// <summary>
        /// 计划移库数量
        /// </summary>
        public int PlanQty { get; set; }



        /// <summary>
        /// 是否移动容器
        /// </summary>
        public bool IsTransferContainer { get; set; }

        public string SkuNumber { get; set; }

        public string SkuName { get; set; }

        public string PackName { get; set; }

        /// <summary>
        /// 移库数量
        /// </summary>
        public int TransferedQty { get; set; }

        public string SourceLocationCode { get; set; }

        public string SourceLocationName { get; set; }

        public string TargetLocationCode { get; set; }

        public string TargetLocationName { get; set; }

        public string SourceContainerCode { get; set; }

        public string SourceContainerName { get; set; }

        public string TargetContainerCode { get; set; }

        public string TargetContainerName { get; set; }

        /// <summary>
        /// 入库批次
        /// </summary>
        public string BatchNumber { get; set; }

        public virtual bool IsValid
        {
            get { return true; }
        }
    }
}
