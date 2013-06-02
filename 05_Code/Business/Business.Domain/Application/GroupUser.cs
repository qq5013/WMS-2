namespace Business.Domain.Application
{
    public class GroupUser : DomainObject
    {
        /// <summary> 
        /// 自动编号
        /// </summary> 
        public int Id { get; set; }

        /// <summary> 
        /// 用户分组编号
        /// </summary> 
        public int GroupId { get; set; }

        /// <summary> 
        /// 用户编号
        /// </summary> 
        public int UserId { get; set; }
    }
}