namespace Business.Domain.Wms
{
    public class SkuProperty : DomainObject
    {
        /// <summary> 
        /// 自动编号
        /// </summary> 
        public int Id { get; set; }

        /// <summary> 
        /// 货物编号
        /// </summary> 
        public int SkuId { get; set; }

        /// <summary> 
        /// 批次属性编号
        /// </summary> 
        public int PropertyId { get; set; }

        /// <summary> 
        /// 优先级
        /// </summary> 
        public int Priority { get; set; }
    }
}