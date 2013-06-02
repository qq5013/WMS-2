using System;

namespace Wms.Common
{
    public class ConvertHelper
    {

        #region Type Parse
        public static string DateTimeToDateString(DateTime dateTime)
        {
            if (dateTime != DateTime.MinValue)
                return dateTime.ToString("yyyy-MM-dd");
            return string.Empty;
        }

        public static string DateTimeToString(DateTime dateTime)
        {
            if (dateTime != DateTime.MinValue)
                return dateTime.ToString("yyyy-MM-dd HH:mm:ss");
            return string.Empty;
        }

        public static int ParseInt(object input)
        {
            try
            {
                return int.Parse(input.ToString().Trim());
            }
            catch
            {
                return 0;
            }
        }

        public static decimal ParseDecimal(object input)
        {
            try
            {
                return decimal.Parse(input.ToString().Trim());
            }
            catch
            {
                return (decimal)0.0;
            }
        }

        #endregion

    }
}
