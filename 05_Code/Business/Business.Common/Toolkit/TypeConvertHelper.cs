using System;

namespace Business.Common.Toolkit
{
    public class TypeConvertHelper
    {
        public static string DateToString(DateTime datetime)
        {
            return datetime.ToString("yyyy-MM-dd");
        }

        public static string DatetimeToString(DateTime datetime)
        {
            return datetime.ToString("yyyy-MM-dd HH:mm:ss");
        }
    }
}