using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using Business.Common.Exception;
using Business.Common.QueryModel;
using Business.Domain.Application;

namespace Business.Service.Contract
{
    [ServiceContract(SessionMode = SessionMode.NotAllowed)]
    public interface ILogService
    {
    }
}
