using System;
using System.Web;
using System.Collections.Generic;
using Frame.Utils.Service;
using MES.Entity;

namespace MES.Web.Data
{
    public partial class ItemProcessStepDetailData : BaseData<ItemProcessStepDetail>
    {
		public List<ItemProcessStepDetail> SelectByMaster(int masterId)
		{
			return Service.FindAll(c=>c.ItemProcessStepId==masterId, null);
		}
	
		public void Update(ItemProcessStepDetail entity)
        {
            try
            {
				entity.ItemProcessStepId = Convert.ToInt32(HttpContext.Current.Session["ItemProcessStepId"]);


                Service.Save(entity);
            }
            catch (Exception ex)
            {
                throw CustomError(ex);
            }
        }

        public void Insert(ItemProcessStepDetail entity)
        {
            try
            {
				entity.ItemProcessStepId = Convert.ToInt32(HttpContext.Current.Session["ItemProcessStepId"]);
	
                Service.Save(entity);
            }
            catch (Exception ex)
            {
                throw CustomError(ex);
            }
        }

        public void Delete(ItemProcessStepDetail entity)
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
