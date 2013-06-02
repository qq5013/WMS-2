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
    public interface ILockService
    {
        //bool LockSku(int warehouseId, int locationId, int containerId, int skuId, int packId, string batchNumber);

        //bool UnlockSku(int warehouseId, int locationId, int containerId, int skuId, int packId, string batchNumber);
    }
}
