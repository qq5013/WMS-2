using System;
using System.Web;
using System.Collections.Generic;
using Frame.Utils.Service;
using MES.Entity;

namespace MES.Web.Data
{
    public partial class ProductionOrderDetailData : BaseData<ProductionOrderDetail>
    {
		public List<ProductionOrderDetail> SelectByMaster(int masterId)
		{
			return Service.FindAll(c=>c.ProductionOrderId==masterId, null);
		}
	
		public void Update(ProductionOrderDetail entity)
        {
            try
            {
				entity.ProductionOrderId = Convert.ToInt32(HttpContext.Current.Session["ProductionOrderId"]);


                Service.Save(entity);
            }
            catch (Exception ex)
            {
                throw CustomError(ex);
            }
        }

        public void Insert(ProductionOrderDetail entity)
        {
            try
            {
				entity.ProductionOrderId = Convert.ToInt32(HttpContext.Current.Session["ProductionOrderId"]);
	
                Service.Save(entity);
            }
            catch (Exception ex)
            {
                throw CustomError(ex);
            }
        }

        public void Delete(ProductionOrderDetail entity)
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
