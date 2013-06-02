/*----------------------------------------------------------------
// Copyright (C) 2010 有限公司
// 版权所有。 
//
// 文件名：         InspectLog.cs
// 文件功能描述：   检测日志
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


namespace MES.Execute
{
    /// <summary>
    ///     检测日志
    /// </summary>
    public class InspectLog
    {
        /// <summary>
        ///     状态
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        ///     名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        ///     数值
        /// </summary>
        public decimal Data { get; set; }

        /// <summary>
        ///     正常值
        /// </summary>
        public string NormalData { get; set; }

        /// <summary>
        ///     结果
        /// </summary>
        public bool Result { get; set; }

        /// <summary>
        ///     备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        ///     检测记录Id
        /// </summary>
        public int InspectId { get; set; }
    }
}