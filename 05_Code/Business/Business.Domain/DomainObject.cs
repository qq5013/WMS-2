namespace Business.Domain
{
    public abstract class DomainObject : ISupportValidation
    {
        //#region ISupportValidation Members

        public virtual bool IsValid
        {
            get { return true; }
        }

        //#endregion

        //IList<ValidationError> Validate()
        //{
        //    return new List<ValidationError>();
        //}

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}