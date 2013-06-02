namespace Business.Common.Exception
{
    public class ServiceException : System.Exception
    {
        public ServiceError Error { get; set; }

        public ServiceException(ServiceError serviceError)
            :base(serviceError.ErrorMessage)
        {
            Error = serviceError;
        }
    }
}
