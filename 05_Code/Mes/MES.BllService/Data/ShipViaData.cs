using System;
using System.Web;
using System.Collections.Generic;
using Frame.Utils.Service;
using MES.Entity;

namespace MES.Web.Data
{
    public partial class ShipViaData : BaseData<ShipVia>
    {
	
		public void Update(ShipVia entity)
        {
            try
            {

  if (Service.Exists(c => c.Code == entity.Code&&c.ShipViaId!=entity.ShipViaId))
                    throw CustomError("Code", "代码不能重复");

                Service.Save(entity);
            }
            catch (Exception ex)
            {
                throw CustomError(ex);
            }
        }

        public void Insert(ShipVia entity)
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

        public void Delete(ShipVia entity)
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
