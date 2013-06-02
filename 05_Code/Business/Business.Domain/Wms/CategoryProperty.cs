namespace Business.Domain.Wms
{
    public class CategoryProperty : DomainObject
    {
        /// <summary> 
        /// 自动编号
        /// </summary> 
        public int Id { get; set; }

        /// <summary> 
        /// 管理分类编号
        /// </summary> 
        public int CategoryId { get; set; }

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