namespace Business.Domain
{
    public interface ISupportValidation
    {
        /// <summary>
        /// Domain对象是否合法
        /// </summary>
        bool IsValid { get; }

        /// <summary>
        /// 校验Domain对象是否合法
        /// </summary>
        //IList<ValidationError> Validate();
    }
}