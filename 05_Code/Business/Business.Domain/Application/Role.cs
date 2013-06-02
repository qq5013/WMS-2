using System.Collections.Generic;

namespace Business.Domain.Application
{
    public class Role : DomainObject
    {
        #region property

        /// <summary> 
        /// 应用系统编号
        /// </summary> 
        public int ApplicationId { get; set; }

        /// <summary> 
        /// 角色编号
        /// </summary> 
        public int RoleId { get; set; }

        /// <summary> 
        /// 角色代码
        /// </summary> 
        public string RoleCode { get; set; }

        /// <summary> 
        /// 角色名称
        /// </summary> 
        public string RoleName { get; set; }

        /// <summary> 
        /// 备注
        /// </summary> 
        public string Remark { get; set; }

        /// <summary> 
        /// 是否激活
        /// </summary> 
        public bool IsActive { get; set; }

        #endregion

        #region addition property

        public IList<Function> Functions { get; set; }

        public IList<Group> Groups { get; set; }

        public IList<User> Users { get; set; }

        #endregion

        public void Disable()
        {
            IsActive = false;
        }

        public void Enable()
        {
            IsActive = true;
        }
    }
}