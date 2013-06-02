using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.DataAccess.Repository.Application;
using Business.Domain.Application;
using Business.Common;

namespace Business.Component
{
    /// <summary>
    /// 数据字典管理器
    /// </summary>
    public class DictionaryManager
    {
        /// <summary>
        /// 获取数据字典代码
        /// </summary>
        /// <param name="dictionaryId">数据字典编号</param>
        /// <returns>成功返回数据字典代码，否则返回空字符串</returns>
        public static string GetDictionaryCodeById(int dictionaryId)
        {
            var repository = new DataDictionaryRepository();
            DataDictionary dictionary = repository.Get(dictionaryId);
            if (dictionary != null)
                return dictionary.DictionaryCode;

            return string.Empty;
        }

        public static string GetDictionaryValueById(int dictionaryId)
        {
            var repository = new DataDictionaryRepository();
            DataDictionary dictionary = repository.Get(dictionaryId);
            if (dictionary != null)
                return dictionary.DictionaryValue;

            return string.Empty;
        }

        /// <summary>
        /// 获取数据字典编号
        /// </summary>
        /// <param name="dictionaryCode">数据字典代码</param>
        /// <returns>成功返回数据字典编号，否则返回0</returns>
        public static int GetDictionaryIdByCode(int dictionaryCode)
        {
            var repository = new DataDictionaryRepository();
            DataDictionary dictionary = repository.GetByCode(ApplicationInformation.ApplicationCode, dictionaryCode.ToString()); 
            if (dictionary != null)
                return dictionary.DictionaryId;

            return 0;
        }

        /// <summary>
        /// 数据字典编号与代码是否一致
        /// </summary>
        /// <param name="dictionaryId">数据字典编号</param>
        /// <param name="comparedDictionaryCode">数据字典代码</param>
        /// <returns>一致返回true，否则返回false</returns>
        public static bool IsEuqalDictionary(int dictionaryId, int comparedDictionaryCode)
        {
            string code = GetDictionaryCodeById(dictionaryId);
            if (code == comparedDictionaryCode.ToString())
                return true;

            return false;
        }
    }
}
