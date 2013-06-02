using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System;
using System.Collections.Generic;


using Business.Domain.Application;


using Business.Common.Exception;
using Business.Common.QueryModel;
using Business.Domain.Application;
using Business.Domain.Wms;
using Business.Domain.Warehouse;
using Business.Domain.Mobile;
using Business.Domain;

using Business.Domain.Inventory.Views;
using Business.Domain.Inventory;
using Business.Service;

namespace Server.Wcf.Service
{
    /// <summary>
    /// Summary description for SmartDevice
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class SmartDevice : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public bool UploadReceivingTaskResult(ReceivingTaskResult result)
        {
            try
            {
                MobileService service = new MobileService();
                BoolResultObject uploadResult = service.UploadReceivingTaskResult(result);
                return uploadResult.Result;
            }
            catch (Exception ex)
            {
                //ServiceExceptionHelper.ThrowServiceException(ex);
                Framework.Core.Exception.ExceptionHelper.HandleException(ex, true, false);
            }

            return false;
        }

        [WebMethod]
        public bool UploadPutawayTaskResult(PutawayTaskResult result)
        {
            try
            {
                MobileService service = new MobileService();
                BoolResultObject uploadResult = service.UploadPutawayTaskResult(result);
                return uploadResult.Result;
            }
            catch (Exception ex)
            {
                //ServiceExceptionHelper.ThrowServiceException(ex);
                Framework.Core.Exception.ExceptionHelper.HandleException(ex, true, false);
            }

            return false;
        }

        [WebMethod]
        public bool UploadPickTaskResult(PickTaskResult result)
        {
            try
            {
                MobileService service = new MobileService();
                BoolResultObject uploadResult = service.UploadPickTaskResult(result);
                return uploadResult.Result;
            }
            catch (Exception ex)
            {
                //ServiceExceptionHelper.ThrowServiceException(ex);
                Framework.Core.Exception.ExceptionHelper.HandleException(ex, true, false);
            }

            return false;
        }


        [WebMethod]
        public bool UpdateDeliveryTask(OutboundBill outboundBill)
        {
            try
            {
                MobileService service = new MobileService();
                BoolResultObject uploadResult = service.UpdateDeliveryTask(outboundBill);
                return uploadResult.Result;
            }
            catch (Exception ex)
            {
                //ServiceExceptionHelper.ThrowServiceException(ex);
                Framework.Core.Exception.ExceptionHelper.HandleException(ex, true, false);
            }

            return false;
        }

        [WebMethod]
        public bool UploadTransferResult(string warehouseCode, List<TransferBillDetailView> transferResult, int operatorId)
        {
            try
            {
                MobileService service = new MobileService();
                BoolResultObject uploadResult = service.UploadTransferResult(warehouseCode, transferResult, operatorId);
                return uploadResult.Result;
            }
            catch (Exception ex)
            {
                //ServiceExceptionHelper.ThrowServiceException(ex);
                Framework.Core.Exception.ExceptionHelper.HandleException(ex, true, false);
            }

            return false;
        }
    }
}
