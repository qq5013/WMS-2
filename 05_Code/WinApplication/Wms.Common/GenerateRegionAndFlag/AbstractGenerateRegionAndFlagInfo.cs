using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ecWMS.Business.Common;
using ecWMS.Business.Entity;

namespace ecWMS.Common.GenerateRegionAndFlag
{
    public abstract class AbstractGenerateRegionAndFlagInfo
    {
        protected BllResult bllResult; 


        public virtual Int32 GenerateRegionAndFlag(int warehouseId, string flagCode, string flagName, string memo, int flagId, int userId,
                                    bool isInsert)
        {
            return 0;
        }

        protected RegionAndFlag GetRegionAndFlagById(int id)
        {
            RegionAndFlag regionAndFlag = null;
            ArrayList arrayList = ServiceHelper.FacadeService.GetByCondition(out bllResult, typeof(RegionAndFlag).FullName,
                                              string.Format(" [ID] = {0}", id));
            if(arrayList != null && arrayList.Count > 0)
            {
                regionAndFlag = (RegionAndFlag) arrayList[0];
            }
            return regionAndFlag;
        }

    }
}
