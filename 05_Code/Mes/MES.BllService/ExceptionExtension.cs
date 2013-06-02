using System;
using System.Diagnostics;

namespace MES.BllService
{
    public static class ExceptionExtension
    {
        public static void Process(this Exception ex)
        {
            Trace.WriteLine(ex.Message);
            Trace.WriteLine(ex.StackTrace);
            if (ex.InnerException != null)
            {
                Process(ex.InnerException);
            }
        }
    }
}