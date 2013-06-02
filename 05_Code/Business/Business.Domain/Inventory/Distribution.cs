namespace Business.Domain.Inventory
{
    public class Distribution : DomainObject
    {
        /// <summary>
        /// 自动编号
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 出库计划编号
        /// </summary>
        public int PlanId { get; set; }

        /// <summary>
        /// 销售订单号
        /// </summary>
        public string OrderNumber { get; set; }

        /// <summary>
        /// 订单时间
        /// </summary>
        public string OrderTime { get; set; }

        /// <summary>
        /// 快递公司
        /// </summary>
        public int ExpressCompany { get; set; }

        /// <summary>
        /// 快递服务类型
        /// </summary>
        public int ExpressService { get; set; }

        /// <summary>
        /// 计划送货日期
        /// </summary>
        public string PlanDeliveryDate { get; set; }

        /// <summary>
        /// 计划时间段
        /// </summary>
        public int PlanDeliveryPeriod { get; set; }

        /// <summary>
        /// 付款方式
        /// </summary>
        public int PayMode { get; set; }

        /// <summary>
        /// 代收金额
        /// </summary>
        public decimal CollectingAmount { get; set; }

        /// <summary>
        /// 配送员
        /// </summary>
        public string DeliveryStaff { get; set; }

        /// <summary>
        /// 客户姓名
        /// </summary>
        public string PurchaserName { get; set; }

        /// <summary>
        /// 收货人姓名
        /// </summary>
        public string ReceiverName { get; set; }

        /// <summary>
        /// 收货人地址
        /// </summary>
        public string ReceiverAddress { get; set; }

        /// <summary>
        /// 收货人邮编
        /// </summary>
        public string ReceiverPostalCode { get; set; }

        /// <summary>
        /// 收货人手机
        /// </summary>
        public string ReceiverCellphone { get; set; }

        /// <summary>
        /// 收货人联系电话
        /// </summary>
        public string ReceiverPhone { get; set; }
    }
}