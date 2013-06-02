using System;
using System.Web;
using System.Collections.Generic;
using Frame.Utils.Service;
using MES.Entity;

namespace MES.Web.Data
{
    public partial class ItemInspectDetailData : BaseData<ItemInspectDetail>
    {
		public List<ItemInspectDetail> SelectByMaster(int masterId)
		{
			return Service.FindAll(c=>c.ItemInspectId==masterId, null);
		}
	
		public void Update(ItemInspectDetail entity)
        {
            try
            {
				entity.ItemInspectId = Convert.ToInt32(HttpContext.Current.Session["ItemInspectId"]);


                Service.Save(entity);
            }
            catch (Exception ex)
            {
                throw CustomError(ex);
            }
        }

        public void Insert(ItemInspectDetail entity)
        {
            try
            {
				entity.ItemInspectId = Convert.ToInt32(HttpContext.Current.Session["ItemInspectId"]);
	
                Service.Save(entity);
            }
            catch (Exception ex)
            {
                throw CustomError(ex);
            }
        }

        public void Delete(ItemInspectDetail entity)
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
