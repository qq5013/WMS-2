using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ecWMS.Common.GenerateRegionAndFlag
{
    public class GenerateRegionAndFlagFactory
    {

        public static AbstractGenerateRegionAndFlagInfo CreateGenerateRegionAndFlag(int type)
        {
            AbstractGenerateRegionAndFlagInfo abstractGenerateRegionAndFlagInfo = null;
            switch (type)
            {
                case 1:
                    abstractGenerateRegionAndFlagInfo = new GeneratePickRegionAndFlagInfo();
                    break;
                case 2:
                    abstractGenerateRegionAndFlagInfo = new GenerateRegionAndFlagInfoPutAway();
                    break;
                case 3:
                    abstractGenerateRegionAndFlagInfo = new GenerateReplenishRegionAndFlagInfo();
                    break;
            }
            return abstractGenerateRegionAndFlagInfo;
        }
    }
}
