using System;
using System.Web;
using System.Collections.Generic;
using Frame.Utils.Service;
using MES.Entity;

namespace MES.Web.Data
{
    public partial class PcbInspectDetailData : BaseData<PcbInspectDetail>
    {
		public List<PcbInspectDetail> SelectByMaster(int masterId)
		{
			return Service.FindAll(c=>c.PcbInspectId==masterId, null);
		}
	
		public void Update(PcbInspectDetail entity)
        {
            try
            {
				entity.PcbInspectId = Convert.ToInt32(HttpContext.Current.Session["PcbInspectId"]);


                Service.Save(entity);
            }
            catch (Exception ex)
            {
                throw CustomError(ex);
            }
        }

        public void Insert(PcbInspectDetail entity)
        {
            try
            {
				entity.PcbInspectId = Convert.ToInt32(HttpContext.Current.Session["PcbInspectId"]);
	
                Service.Save(entity);
            }
            catch (Exception ex)
            {
                throw CustomError(ex);
            }
        }

        public void Delete(PcbInspectDetail entity)
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
