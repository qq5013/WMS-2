using System;
using System.Web;
using System.Collections.Generic;
using Frame.Utils.Service;
using MES.Entity;

namespace MES.Web.Data
{
    public partial class PurchaseOrderDetailItemData : BaseData<PurchaseOrderDetailItem>
    {
	
		public void Update(PurchaseOrderDetailItem entity)
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

        public void Insert(PurchaseOrderDetailItem entity)
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

        public void Delete(PurchaseOrderDetailItem entity)
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
