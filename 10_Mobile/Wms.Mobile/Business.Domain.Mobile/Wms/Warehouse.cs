using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Business.Domain.Mobile.Wms
{
    public class Warehouse : DomainObject
    {
        #region property

        /// <summary>
        /// 仓库编号
        /// </summary>
        public int WarehouseId { get; set; }

        /// <summary>
        /// 仓库代码
        /// </summary>
        public string WarehouseCode { get; set; }

        /// <summary>
        /// 仓库名称
        /// </summary>
        public string WarehouseName { get; set; }

        /// <summary>
        /// 区县编号
        /// </summary>
        public int CountyId { get; set; }

        /// <summary>
        /// 是否保税
        /// </summary>
        public bool Isbonded { get; set; }

        /// <summary>
        /// 面积
        /// </summary>
        public decimal? Acreage { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 联系人
        /// </summary>
        public string Contactor { get; set; }

        /// <summary>
        /// 邮编
        /// </summary>
        public string PostalCode { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 传真
        /// </summary>
        public string FaxNumber { get; set; }

        /// <summary>
        /// 备注
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
        /// 是否激活
        /// </summary>
        public bool IsActive { get; set; }

        #endregion property

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
