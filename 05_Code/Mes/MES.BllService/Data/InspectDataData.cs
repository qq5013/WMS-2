using System;
using System.Web;
using System.Collections.Generic;
using Frame.Utils.Service;
using MES.Entity;

namespace MES.Web.Data
{
    public partial class InspectDataData : BaseData<InspectData>
    {
	
		public void Update(InspectData entity)
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

        public void Insert(InspectData entity)
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

        public void Delete(InspectData entity)
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
