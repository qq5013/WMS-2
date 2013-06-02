using System;
using Framework.Core.Logger;

namespace Business.Common.Exception
{
    public class DataAccessExceptionHelper
    {
        private const string CreateExceptionMessage = "未处理的数据新增异常。";

        private const string ReadExceptionMessage = "未处理的数据查询异常。";

        private const string UpdateExceptionMessage = "未处理的数据编辑异常。";

        private const string DeleteExceptionMessage = "未处理的数据删除异常。";

        public static void ThrowException(string exceptionCode, System.Exception exception, bool writeLog)
        {
            if (writeLog)
                LogHelper.WriteExceptionLog(exception.ToString());

            string message = @"数据源访问失败。";
            DataAccessException dataAccessException = new DataAccessException(message, exception, exceptionCode, GetExceptionMessage(exceptionCode));
            throw dataAccessException;
        }

        private static string GetExceptionMessage(string exceptionCode)
        {
            switch (exceptionCode)
            {
                case "105" : 
                    return CreateExceptionMessage;
                    break;
                case "106" :
                    return ReadExceptionMessage;
                    break;
                case "107" :
                    return UpdateExceptionMessage;
                    break;
                case "108" :
                    return DeleteExceptionMessage;
                    break;
                default:
                    return string.Empty;
            }
        }
    }
}
