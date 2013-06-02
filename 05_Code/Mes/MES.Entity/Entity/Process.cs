using System;
using Frame.Utils.Contract;

namespace MES.Entity
{
    /// <summary>
    ///     工序
    /// </summary>
    public class Process : IBaseEntity,ICloneable
    {
        /// <summary>
        /// </summary>
        public Int32 ProcessId { get; set; }

        /// <summary>
        ///     产品
        /// </summary>
        public Int32 ProductId { get; set; }

        /// <summary>
        ///     工序号
        /// </summary>
        public String Code { get; set; }

        /// <summary>
        ///     名称
        /// </summary>
        public String Name { get; set; }

        /// <summary>
        ///     备注
        /// </summary>
        public String Memo { get; set; }

        /// <summary>
        ///     顺序
        /// </summary>
        public Int32 Sequence { get; set; }

        /// <summary>
        ///     是否顺序执行
        /// </summary>
        public Boolean IsStepByStep { get; set; }

        /// <summary>
        ///     类型
        /// </summary>
        public Int32 Type { get; set; }

        /// <summary>
        /// </summary>
        public Byte[] ImageData { get; set; }

        /// <summary>
        /// </summary>
        public Boolean IsCheck { get; set; }

        /// <summary>
        /// 产线
        /// </summary>
        public int ProductLineId { get; set; }

        /// <summary>
        /// 对应工位
        /// </summary>
        public int[] ProductStationIds { get; set; }

        #region IBaseEntity Members

        public int GetEntityId()
        {
            return ProcessId;
        }

        #endregion

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}