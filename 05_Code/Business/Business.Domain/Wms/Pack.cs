namespace Business.Domain.Wms
{
    public class Pack : DomainObject
    {
        /// <summary> 
        /// 包装编号
        /// </summary> 
        public int PackId { get; set; }

        /// <summary> 
        /// 货物编号
        /// </summary> 
        public int SkuId { get; set; }

        /// <summary> 
        /// 货物单位级别
        /// </summary> 
        public int PackLevel { get; set; }

        /// <summary> 
        /// 父级包装编号
        /// </summary> 
        public int ParentId { get; set; }

        /// <summary> 
        /// 包装名称
        /// </summary> 
        public string PackName { get; set; }

        /// <summary> 
        /// 转换单品数量
        /// </summary> 
        public int ToPieceQty { get; set; }

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
        /// 重量
        /// </summary> 
        public decimal Weight { get; set; }

        /// <summary> 
        /// 是否缺省管理包装
        /// </summary> 
        public bool DefaultPack { get; set; }
    }
}