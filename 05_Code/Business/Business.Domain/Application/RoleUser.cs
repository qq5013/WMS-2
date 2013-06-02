namespace Business.Domain.Application
{
    public class RoleUser : DomainObject
    {
        /// <summary> 
        /// 自动编号
        /// </summary> 
        public int Id { get; set; }

        /// <summary> 
        /// 角色编号
        /// </summary> 
        public int RoleId { get; set; }

        /// <summary> 
        /// 用户编号
        /// </summary> 
        public int UserId { get; set; }
    }
}