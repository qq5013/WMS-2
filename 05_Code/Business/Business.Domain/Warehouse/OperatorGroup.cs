using System.Collections.Generic;
using Business.Domain.Application;

namespace Business.Domain.Warehouse
{
    public class OperatorGroup : DomainObject
    {
        #region property

        /// <summary>
        /// 操作员组编号
        /// </summary>
        public int GroupId { get; set; }

        /// <summary>
        /// 组名
        /// </summary>
        public string GroupName { get; set; }

        /// <summary>
        /// 隶属仓库编号
        /// </summary>
        public int WarehouseId { get; set; }

        /// <summary>
        /// 操作类型
        /// </summary>
        public int OperationType { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 创建用户
        /// </summary>
        public int CreateUser { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public string CreateTime { get; set; }

        /// <summary>
        /// 编辑用户
        /// </summary>
        public int EditUser { get; set; }

        /// <summary>
        /// 编辑时间
        /// </summary>
        public string EditTime { get; set; }

        /// <summary>
        /// 是否禁用
        /// </summary>
        public bool IsActive { get; set; }

        #endregion property

        #region additional property

        public IList<User> Members { get; set; }

        #endregion additional property

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