namespace Business.Domain.Application
{
    public class RoleFunction : DomainObject
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
        /// 功能编号
        /// </summary> 
        public int FunctionId { get; set; }
    }
}