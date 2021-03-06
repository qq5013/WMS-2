﻿namespace Business.Domain.Wms
{
    public class SkuManagement : DomainObject
    {
        /// <summary>
        /// 货物编号
        /// </summary>
        public int SkuId { get; set; }

        /// <summary>
        /// ABC分类
        /// </summary>
        public int AbcType { get; set; }

        /// <summary>
        /// 是否大货
        /// </summary>
        public bool IsBigItem { get; set; }

        /// <summary>
        /// 是否重货
        /// </summary>
        public bool IsHeavyItem { get; set; }

        /// <summary>
        /// 存储条件
        /// </summary>
        public int StorageCondition { get; set; }

        /// <summary>
        /// 容器管理
        /// </summary>
        public bool ContainerManagement { get; set; }

        /// <summary>
        /// 单件管理
        /// </summary>
        public bool PieceManagement { get; set; }

        /// <summary>
        /// 条码管理
        /// </summary>
        public bool BarcodeManagement { get; set; }

        /// <summary>
        /// 批次管理
        /// </summary>
        public bool BatchManagement { get; set; }

        /// <summary>
        /// 质检百分比
        /// </summary>
        public int QcPercent { get; set; }

        /// <summary>
        /// 拣选规则
        /// </summary>
        public int PickRule { get; set; }

        /// <summary>
        /// 拣选分组
        /// </summary>
        public int PickGroup { get; set; }

        /// <summary>
        /// 补货分组
        /// </summary>
        public int ReplenishGroup { get; set; }

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
    }
}