using System;
using System.Web;
using System.Collections.Generic;
using Frame.Utils.Service;
using MES.Entity;

namespace MES.Web.Data
{
    public partial class PurchaseOrderDetailTraceData : BaseData<PurchaseOrderDetailTrace>
    {
	
		public void Update(PurchaseOrderDetailTrace entity)
        {
            try
            {
                Service.Save(entity);
            }
            catch (Exception ex)
            {
                throw CustomError(ex);
            }
        }

        public void Insert(PurchaseOrderDetailTrace entity)
        {
            try
            {
                Service.Save(entity);
            }
            catch (Exception ex)
            {
                throw CustomError(ex);
            }
        }

        public void Delete(PurchaseOrderDetailTrace entity)
        {
            try
            {
                Service.Delete(entity.GetEntityId());
            }
            catch (Exception ex)
            {
                throw CustomError(ex);
            }
        }
    }
}
