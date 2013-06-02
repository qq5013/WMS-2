namespace Business.Domain.Warehouse
{
    public class ContainerType : DomainObject
    {
        /// <summary> 
        /// 容器类型编号
        /// </summary> 
        public int TypeId { get; set; }

        /// <summary> 
        /// 类型代码
        /// </summary> 
        public string TypeCode { get; set; }

        /// <summary> 
        /// 类型名称
        /// </summary> 
        public string TypeName { get; set; }

        /// <summary> 
        /// 隶属仓库
        /// </summary> 
        public int WarehouseId { get; set; }

        /// <summary> 
        /// 长度
        /// </summary> 
        public decimal Length { get; set; }

        /// <summary> 
        /// 宽度
        /// </summary> 
        public decimal Width { get; set; }

        /// <summary> 
        /// 高度
        /// </summary> 
        public decimal Height { get; set; }

        /// <summary> 
        /// 自重
        /// </summary> 
        public decimal Weight { get; set; }

        /// <summary> 
        /// 承重
        /// </summary> 
        public decimal BearingWeight { get; set; }

        /// <summary> 
        /// 用途类型
        /// </summary> 
        public int PurposeType { get; set; }
    }
}