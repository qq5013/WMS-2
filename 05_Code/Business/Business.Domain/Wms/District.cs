namespace Business.Domain.Wms
{
    public class District : DomainObject
    {
        /// <summary> 
        /// 地区编号
        /// </summary> 
        public int DistrictId { get; set; }

        /// <summary> 
        /// 区域代码
        /// </summary> 
        public string DistrictCode { get; set; }

        /// <summary> 
        /// 区域级别
        /// </summary> 
        public int DistrictLevel { get; set; }

        /// <summary> 
        /// 父级区域编号
        /// </summary> 
        public int ParentId { get; set; }

        /// <summary> 
        /// 名称
        /// </summary> 
        public string DistrictName { get; set; }

        /// <summary> 
        /// 邮编
        /// </summary> 
        public string PostalCode { get; set; }
    }
}