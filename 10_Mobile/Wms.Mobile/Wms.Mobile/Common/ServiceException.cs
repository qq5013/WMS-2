using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Wms.Mobile.Common
{
    public class ServiceException : System.Exception
    {
        public ServiceError Error { get; set; }

        public ServiceException(ServiceError serviceError)
            : base(serviceError.ErrorMessage)
        {
            Error = serviceError;
        }
    }
}
