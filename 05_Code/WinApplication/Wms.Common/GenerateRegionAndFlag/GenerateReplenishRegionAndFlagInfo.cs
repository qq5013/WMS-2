using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ecWMS.Business.Entity;
using ecWMS.Common.Constants;

namespace ecWMS.Common.GenerateRegionAndFlag
{
    public class GenerateReplenishRegionAndFlagInfo : AbstractGenerateRegionAndFlagInfo
    {
        #region IGenerateRegionAndFlagInfo Members

        public override int GenerateRegionAndFlag(int warehouseId, string flagCode, string flagName, string memo, int flagId, int userId, bool isInsert)
        {
            DateTime dateTime = DateTime.Now;
            Int32 result = 0;
            string code = string.Format(ConstantString.ReplenishFlag, flagCode);
            if (isInsert)
            {
                var regionAndFlag = new RegionAndFlag();
                regionAndFlag.WarehouseID = warehouseId;
                regionAndFlag.RegionFlagCode = code;
                regionAndFlag.RegionFlagName = code;
                regionAndFlag.CreateTime = dateTime.ToString("yyyy-MM-dd");
                regionAndFlag.EditTime = dateTime.ToString("yyyy-MM-dd");
                regionAndFlag.CreateUser = userId;
                regionAndFlag.EditUser = userId;
                //regionAndFlag.Description = memo;
                regionAndFlag.RegionFlagType = ServiceHelper.FacadeService.GetDictionaryByCode("8106").DictionaryId;
                result = ServiceHelper.FacadeService.Insert(out bllResult, typeof (RegionAndFlag).FullName, regionAndFlag);
            }
            else
            {
                var regionAndFlag = GetRegionAndFlagById(flagId);
                if(regionAndFlag != null)
                {
                    regionAndFlag.WarehouseID = warehouseId;
                    regionAndFlag.RegionFlagCode = code;
                    regionAndFlag.RegionFlagName = code;
                    regionAndFlag.EditTime = dateTime.ToString("yyyy-MM-dd");
                    regionAndFlag.EditUser = userId;
                    regionAndFlag.RegionFlagType = ServiceHelper.FacadeService.GetDictionaryByCode("8106").DictionaryId;
                    //regionAndFlag.Description = memo;
                    ServiceHelper.FacadeService.Update(out bllResult, typeof(RegionAndFlag).FullName, regionAndFlag);
                    result = regionAndFlag.ID;
                }
                else
                {
                    regionAndFlag = new RegionAndFlag();
                    regionAndFlag.WarehouseID = warehouseId;
                    regionAndFlag.RegionFlagCode = code;
                    regionAndFlag.RegionFlagName = code;
                    regionAndFlag.CreateTime = dateTime.ToString("yyyy-MM-dd");
                    regionAndFlag.EditTime = dateTime.ToString("yyyy-MM-dd");
                    regionAndFlag.CreateUser = userId;
                    regionAndFlag.EditUser = userId;
                    //regionAndFlag.Description = memo;
                    regionAndFlag.RegionFlagType = ServiceHelper.FacadeService.GetDictionaryByCode("8106").DictionaryId;
                    result = ServiceHelper.FacadeService.Insert(out bllResult, typeof(RegionAndFlag).FullName, regionAndFlag);
                }
            }

            return result;
        }

        #endregion
    }
}