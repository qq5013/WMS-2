using System;
using System.Web;
using System.Collections.Generic;
using Frame.Utils.Service;
using MES.Entity;

namespace MES.Web.Data
{
    public partial class PaymentData : BaseData<Payment>
    {
	
		public void Update(Payment entity)
        {
            try
            {

  if (Service.Exists(c => c.Code == entity.Code&&c.PaymentId!=entity.PaymentId))
                    throw CustomError("Code", "代码不能重复");

                Service.Save(entity);
            }
            catch (Exception ex)
            {
                throw CustomError(ex);
            }
        }

        public void Insert(Payment entity)
        {
            try
            {

    if (Service.Exists(c => c.Code == entity.Code))
                    throw CustomError("Code", "代码不能重复");
	
                Service.Save(entity);
            }
            catch (Exception ex)
            {
                throw CustomError(ex);
            }
        }

        public void Delete(Payment entity)
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
