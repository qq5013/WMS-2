using System;
using System.Web;
using System.Collections.Generic;
using Frame.Utils.Service;
using MES.Entity;

namespace MES.Web.Data
{
    public partial class ItemSampleInspectDetailData : BaseData<ItemSampleInspectDetail>
    {
		public List<ItemSampleInspectDetail> SelectByMaster(int masterId)
		{
			return Service.FindAll(c=>c.ItemSampleInspectId==masterId, null);
		}
	
		public void Update(ItemSampleInspectDetail entity)
        {
            try
            {
				entity.ItemSampleInspectId = Convert.ToInt32(HttpContext.Current.Session["ItemSampleInspectId"]);


                Service.Save(entity);
            }
            catch (Exception ex)
            {
                throw CustomError(ex);
            }
        }

        public void Insert(ItemSampleInspectDetail entity)
        {
            try
            {
				entity.ItemSampleInspectId = Convert.ToInt32(HttpContext.Current.Session["ItemSampleInspectId"]);
	
                Service.Save(entity);
            }
            catch (Exception ex)
            {
                throw CustomError(ex);
            }
        }

        public void Delete(ItemSampleInspectDetail entity)
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
