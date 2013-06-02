using System;
using System.Web;
using System.Collections.Generic;
using Frame.Utils.Service;
using MES.Entity;

namespace MES.Web.Data
{
    public partial class SalesOrderDetailTraceData : BaseData<SalesOrderDetailTrace>
    {
	
		public void Update(SalesOrderDetailTrace entity)
        {
            try
            {

  if (Service.Exists(c => c.Code == entity.Code&&c.SalesOrderDetailTraceId!=entity.SalesOrderDetailTraceId))
                    throw CustomError("Code", "代码不能重复");

                Service.Save(entity);
            }
            catch (Exception ex)
            {
                throw CustomError(ex);
            }
        }

        public void Insert(SalesOrderDetailTrace entity)
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

        public void Delete(SalesOrderDetailTrace entity)
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
