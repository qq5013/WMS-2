namespace CabApplication.Common
{
    public class BillStatusHelper
    {
        // 单据缩写说明
        // PO 采购单
        // IP 入库计划
        // IB 收货报告
        // OP 出库计划
        // PL 拣货单
        // SPL 分拣单
        // OB 发货报告
        // CB 盘点单
        // TB 移库单
          

        // 采购单状态
        public static readonly string PO_CREATED = "4401";
        public static readonly string PO_MODIFIED = "4402";
        public static readonly string PO_CREATE_IB = "4403";
        public static readonly string PO_CANCELED = "4404";

        // 入库计划状态
        public static readonly string IP_CREATED = "4501";
        public static readonly string IP_PARTIAL = "4502";
        public static readonly string IP_RECEIVED = "4503";
        public static readonly string IP_CANCELED = "4504";

        // 收货报告状态
        public static readonly string IB_RECEIVED = "4801";
        public static readonly string IB_COMPLETED = "4803";
        public static readonly string IB_PUTAWAY = "4802";
        public static readonly string IB_CANCELED = "4804";

        // 出库计划状态
        public static readonly string OP_CREATED = "4701";
        public static readonly string OP_PICKED = "4702";
        public static readonly string OP_PARTIAL = "4703";
        public static readonly string OP_DELIVERED = "4704";
        public static readonly string OP_CANCELED = "4705";

        // 拣货单状态
        public static readonly string PL_CREATED = "7801";

        // 分拣单状态

        // 发货报告状态
        // 发货报告状态
        public static readonly string OB_CREATED = "4901";
        public static readonly string OB_DELIVERED = "4902";
        public static readonly string OB_CANCELED = "4903";

        // 移库单状态
        public static readonly string TB_CREATED = "2301";
        public static readonly string TB_TRANSFERED = "2302";
        public static readonly string TB_CANCELED = "2303";

        // 盘点单状态
        public static readonly string CB_CREATED = "6901";
        public static readonly string CB_COUNTED = "6902";
        public static readonly string CB_CANCELED = "6903";
    }
}
