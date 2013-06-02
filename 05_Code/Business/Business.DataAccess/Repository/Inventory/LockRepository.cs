using System.Collections.Generic;
using Business.DataAccess.Contract.Repository.Inventory;
using Business.Domain.Inventory;
using Framework.Core.Collections;
using Framework.Database.IBatis;

namespace Business.DataAccess.Repository.Inventory
{
    public class LockRepository : Repository<Lock>, ILockRepository
    {
        public LockRepository()
        {
            Database = DatabaseConfigName.Inventory;
        }

        #region ILockRepository Members

        public List<Lock> GetSkuLocks(int warehouseId, int skuId)
        {
            var @lock = new Lock
                            {
                                WarehouseId = warehouseId,
                                SkuId = skuId
                            };
            return
                CollectionHelper.ToList(DataMapperHelper.GetMapper(Database).QueryForList<Lock>("Lock.GetSkuLocks",
                                                                                                @lock));
        }

        #endregion
    }
}