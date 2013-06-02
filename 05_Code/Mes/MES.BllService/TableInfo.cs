/*----------------------------------------------------------------
// Copyright (C) 2010 有限公司
// 版权所有。 
//
// 文件名：         TableInfo.cs
// 文件功能描述：   表信息
//
// 
// 创建标识：
//
// 修改标识：
// 修改描述：
//
// 修改标识：
// 修改描述：
----------------------------------------------------------------*/

namespace MES.BllService
{
    /// <summary>
    ///     表信息
    /// </summary>
    public class TableInfo
    {
        private string _entityName;

        private string _entityPrefix;

        /// <summary>
        ///     表信息
        /// </summary>
        public string TableName
        {
            get
            {
                if (string.IsNullOrEmpty(_entityPrefix))
                {
                    return _entityName;
                }
                return _entityPrefix + "_" + _entityName;
            }
            set
            {
                string[] split = value.Split("_".ToCharArray());
                _entityName = split[split.Length - 1];

                if (split.Length > 1)
                {
                    _entityPrefix = split[0];
                }
            }
        }

        /// <summary>
        ///     实体信息
        /// </summary>
        public string EntityName
        {
            get { return _entityName; }
            set { _entityName = value; }
        }

        /// <summary>
        ///     前缀
        /// </summary>
        public string EntityPrefix
        {
            get { return _entityPrefix; }
            set { _entityPrefix = value; }
        }


        /// <summary>
        ///     描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        ///     服务
        /// </summary>
        public object Service { get; set; }
    }
}