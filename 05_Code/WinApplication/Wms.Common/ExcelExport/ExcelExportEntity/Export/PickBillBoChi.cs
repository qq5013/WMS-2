using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ecWMS.Common.ExcelExport.ExcelExportEntity.Export
{
    /// <summary>
    /// 批量拣货单导出
    /// </summary>
    [Serializable]
    public class PickBillBoChi
    {
        /// <summary>
        /// 配送方式
        /// </summary>
        public String DeliveryCompany { get; set; }

        /// <summary>
        /// 波次号
        /// </summary>
        public String PickBillCode { get; set; }

        /// <summary>
        /// 合单类型（单一订单，多品种）
        /// </summary>
        public String OrderType { get; set; }

        /// <summary>
        /// 拣货方式
        /// </summary>
        public String PickMode { get; set; }

        /// <summary>
        /// 生成时间
        /// </summary>
        public String GeneryTime { get; set; }

        /// <summary>
        /// 小车号
        /// </summary>
        public String DistrbutionVehicle { get; set; }

        /// <summary>
        /// 配送车号
        /// </summary>
        public String DistrbutionCar { get; set; }

        /// <summary>
        /// 订单数量
        /// </summary>
        public String OrderCount { get; set; }

        /// <summary>
        /// 产品种类
        /// </summary>
        public Int32 ItemTypeCount { get; set; }

        /// <summary>
        /// 产品数量
        /// </summary>
        public int ItemCount { get; set; }

        public IList<PickBillBoChiDetail> SubPickBillBoChiDetail{ get; set;}
    }
}
