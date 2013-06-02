namespace Business.Domain.Wms
{
    public class SkuImage : DomainObject
    {
        /// <summary> 
        /// 自增主键
        /// </summary> 
        public int Id { get; set; }

        /// <summary> 
        /// 货物编号
        /// </summary> 
        public int SkuId { get; set; }

        /// <summary> 
        /// 图片序号
        /// </summary> 
        public int ImageIndex { get; set; }

        /// <summary> 
        /// 图片
        /// </summary> 
        public string Image { get; set; }

    }
}
