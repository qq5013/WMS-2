using System.Collections.Generic;
using Business.Common.QueryModel;
using Business.DataAccess.Contract.Repository.Wms;
using Business.Domain.Wms;

namespace Business.DataAccess.Repository.Wms
{
    public class SkuImageRepository : Repository<SkuImage>, ISkuImageRepository
    {
        public SkuImageRepository()
        {
            Database = DatabaseConfigName.Wms;
        }
    }
}