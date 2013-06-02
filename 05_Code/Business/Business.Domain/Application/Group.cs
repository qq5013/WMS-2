using System.Collections.Generic;

namespace Business.Domain.Application
{
    public class Group : DomainObject
    {
        #region property

        /// <summary> 
        /// 应用系统编号
        /// </summary> 
        public int ApplicationId { get; set; }

        /// <summary> 
        /// 用户组编号
        /// </summary> 
        public int GroupId { get; set; }

        /// <summary> 
        /// 用户组级别
        /// </summary> 
        public int GroupLevel { get; set; }

        /// <summary> 
        /// 父级用户组编号
        /// </summary> 
        public int ParentId { get; set; }

        /// <summary> 
        /// 用户组代码
        /// </summary> 
        public string GroupCode { get; set; }

        /// <summary> 
        /// 用户组名
        /// </summary> 
        public string GroupName { get; set; }

        /// <summary> 
        /// 描述
        /// </summary> 
        public string Remark { get; set; }

        /// <summary> 
        /// 是否激活
        /// </summary> 
        public bool IsActive { get; set; }

        #endregion

        #region additional property

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