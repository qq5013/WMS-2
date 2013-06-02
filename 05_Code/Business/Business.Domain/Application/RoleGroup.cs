namespace Business.Domain.Application
{
    public class RoleGroup : DomainObject
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
        /// 用户组编号
        /// </summary> 
        public int GroupId { get; set; }
    }
}