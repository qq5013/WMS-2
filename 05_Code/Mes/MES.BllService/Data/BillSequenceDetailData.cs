using System;
using System.Web;
using System.Collections.Generic;
using Frame.Utils.Service;
using MES.Entity;

namespace MES.Web.Data
{
    public partial class BillSequenceDetailData : BaseData<BillSequenceDetail>
    {
		public List<BillSequenceDetail> SelectByMaster(int masterId)
		{
			return Service.FindAll(c=>c.BillSequenceId==masterId, null);
		}
	
		public void Update(BillSequenceDetail entity)
        {
            try
            {
				entity.BillSequenceId = Convert.ToInt32(HttpContext.Current.Session["BillSequenceId"]);

  if (Service.Exists(c => c.Code == entity.Code&&c.BillSequenceDetailId!=entity.BillSequenceDetailId))
                    throw CustomError("Code", "代码不能重复");

                Service.Save(entity);
            }
            catch (Exception ex)
            {
                throw CustomError(ex);
            }
        }

        public void Insert(BillSequenceDetail entity)
        {
            try
            {
				entity.BillSequenceId = Convert.ToInt32(HttpContext.Current.Session["BillSequenceId"]);

    if (Service.Exists(c => c.Code == entity.Code))
                    throw CustomError("Code", "代码不能重复");
	
                Service.Save(entity);
            }
            catch (Exception ex)
            {
                throw CustomError(ex);
            }
        }

        public void Delete(BillSequenceDetail entity)
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
