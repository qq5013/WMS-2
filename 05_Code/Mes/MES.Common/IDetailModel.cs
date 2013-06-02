namespace MES.Common
{
    /// <summary>
    /// Detial Model
    /// </summary>
    public interface IDetailModel
    {
        /// <summary>
        /// 临时编号
        /// </summary>
        int TempId { get; set; }

        /// <summary>
        /// 操作名称
        /// </summary>
        string OperationName { get; set; }
    }
}