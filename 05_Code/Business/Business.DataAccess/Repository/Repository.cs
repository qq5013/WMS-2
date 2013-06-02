using System;
using System.Collections;
using System.Collections.Generic;
using Business.Common.Exception;
using Business.Common.QueryModel;
using Business.DataAccess.Contract;
using Framework.Core.Collections;
using Framework.Core.Exception;
using Framework.Database.IBatis;

namespace Business.DataAccess.Repository
{
    //public abstract class Repository<T> : IRepository<T>
    public class Repository<T> : IRepository<T>
    {
        /// <summary>
        /// 数据库
        /// </summary>
        public string Database;

        #region IRepository<T> Members

        /// <summary>
        /// 保存实体对象
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public virtual int Create(T item)
        {
            string command = typeof(T).Name + ".Insert";

            try
            {
                return Convert.ToInt32(DataMapperHelper.GetMapper(Database).Insert(command, item));
            }
            catch (Exception ex)
            {
                DataAccessExceptionHelper.ThrowException("DATAAPPEND_ERROR", ex, true);
            }

            return 0;
        }

        public virtual bool Update(T item)
        {
            bool result = true;
            try
            {
                string command = typeof(T).Name + ".Update";
                DataMapperHelper.GetMapper(Database).Update(command, item);
            }
            catch (Exception ex)
            {
                result = false;
                DataAccessExceptionHelper.ThrowException("DATAUPDATE_ERROR", ex, true);
            }
            return result;
        }

        public virtual bool Delete(int id)
        {
            bool result = true;
            try
            {
                string command = typeof(T).Name + ".Delete";
                DataMapperHelper.GetMapper(Database).Delete(command, id);
            }
            catch (Exception ex)
            {
                result = false;
                DataAccessExceptionHelper.ThrowException("DATADELETE_ERROR", ex, true);
            }
            return result;
        }

        //public virtual bool Delete(long id)
        //{
        //    bool result = true;
        //    try
        //    {
        //        string command = typeof(T).Name + ".Delete";
        //        DataMapperHelper.GetMapper(Database).Delete(command, id);
        //    }
        //    catch (Exception ex)
        //    {
        //        result = false;
        //        DataAccessExceptionHelper.ThrowException("DATADELETE_ERROR", ex, true);
        //    }
        //    return result;
        //}

        public virtual bool Delete(T item)
        {
            bool result = true;
            try
            {
                string command = typeof(T).Name + ".Delete";
                DataMapperHelper.GetMapper(Database).Delete(command, item);
            }
            catch (Exception ex)
            {
                result = false;
                DataAccessExceptionHelper.ThrowException("DATADELETE_ERROR", ex, true);
            }
            return result;
        }

        public virtual bool DeleteAll()
        {
            bool result = true;
            try
            {
                string command = typeof(T).Name + ".DeleteAll";
                DataMapperHelper.GetMapper(Database).Delete(command, 0);
            }
            catch (Exception ex)
            {
                result = false;
                DataAccessExceptionHelper.ThrowException("DATADELETE_ERROR", ex, true);
            }
            return result;
        }

        public virtual T Get(int id)
        {
            try
            {
                string command = typeof(T).Name + ".Get";
                return (T)DataMapperHelper.GetMapper(Database).QueryForObject<object>(command, id);
            }
            catch (Exception ex)
            {
                DataAccessExceptionHelper.ThrowException("DATAACCESS_ERROR", ex, true);
            }

            return default(T);
        }

        public virtual T Get(long id)
        {
            try
            {
                string command = typeof(T).Name + ".Get";
                return (T)DataMapperHelper.GetMapper(Database).QueryForObject<object>(command, id);
            }
            catch (Exception ex)
            {
                DataAccessExceptionHelper.ThrowException("DATAACCESS_ERROR", ex, true);
            }

            return default(T);
        }

        public virtual IList<T> GetAll()
        {
            try
            {
                string command = typeof(T).Name + ".GetAll";
                return CollectionHelper.ToIList<T>(DataMapperHelper.GetMapper(Database).QueryForList(command, null));
            }
            catch (Exception ex)
            {
                DataAccessExceptionHelper.ThrowException("DATAACCESS_ERROR", ex, true);
            }

            return new List<T>();
        }

        public virtual T GetByQuery(Query query)
        {
            try
            {
                return GetByCondition(query.ToSqlCondition());
            }
            catch (Exception ex)
            {
                DataAccessExceptionHelper.ThrowException("DATAQUERY_ERROR", ex, true);
            }

            return default(T);
        }

        public virtual IList<T> GetListByQuery(Query query)
        {
            try
            {
                return GetListByCondition(query.ToSqlCondition());
            }
            catch (Exception ex)
            {
                DataAccessExceptionHelper.ThrowException("DATAQUERY_ERROR", ex, true);
            }

            return new List<T>();
        }

        #endregion IRepository<T> Members

        private T GetByCondition(string condition)
        {
            try
            {
                string command = typeof(T).Name + ".GetByCondition";
                return (T)DataMapperHelper.GetMapper(Database).QueryForObject<object>(command, condition);
            }
            catch (Exception ex)
            {
                DataAccessExceptionHelper.ThrowException("DATAQUERY_ERROR", ex, true);
            }

            return default(T);
        }

        private List<T> GetListByCondition(string condition)
        {
            try
            {
                string command = typeof(T).Name + ".GetByCondition";
                return CollectionHelper.ToList<T>(DataMapperHelper.GetMapper(Database).QueryForList(command, condition));
            }
            catch (Exception ex)
            {
                DataAccessExceptionHelper.ThrowException("DATAQUERY_ERROR", ex, true);
            }

            return new List<T>();
        }

        public virtual List<T> GetByPager(PagerQuery query, out int qty)
        {
            List<T> list = new List<T>();
            try
            {
                Hashtable ht = new Hashtable();
                ht.Add("TableName", query.DomainObjectName);
                ht.Add("SelectFields", query.SelectedPropertyNameList);
                ht.Add("OrderByField", query.OrderedPropertyName);
                ht.Add("OrderType", PagerQuery.ConvertOrderClauseCriteria(query.OrderType));
                ht.Add("PageSize", query.PageSize);
                ht.Add("PageIndex", query.PageCount);
                ht.Add("RecordsCount", 0);
                if (query.ToSqlCondition() != string.Empty)
                    ht.Add("SelectCondition", query.ToSqlCondition());
                else
                    ht.Add("SelectCondition", " 1 = 1");

                string command = typeof(T).Name + ".GetByPager";
                
                //foreach (var key in ht.Keys)
                //    Framework.Core.Logger.LogHelper.WriteDebugLog(key.ToString() + " - "+ ht[key].ToString());

                list = CollectionHelper.ToList<T>(DataMapperHelper.GetMapper(Database).QueryForList(command, ht));

                qty = (int)ht["RecordsCount"];
            }
            catch (Exception ex)
            {
                qty = 0;
                DataAccessExceptionHelper.ThrowException("DATAACCESS_ERROR", ex, true);
            }
            
            return list;
        }

        public virtual List<T> GetByPager(Hashtable parameters)
        {
            try
            {
                string command = typeof(T).Name + ".GetByPager";
                return CollectionHelper.ToList<T>(DataMapperHelper.GetMapper(Database).QueryForList(command, parameters));
            }
            catch (Exception ex)
            {
                DataAccessExceptionHelper.ThrowException("DATAACCESS_ERROR", ex, true);
            }

            return new List<T>();
        }

        public virtual K GetByCommand<K>(string command, object item)
        {
            try
            {
                return (K)DataMapperHelper.GetMapper(Database).QueryForObject<object>(command, item);
            }
            catch (Exception ex)
            {
                DataAccessExceptionHelper.ThrowException("DATAACCESS_ERROR", ex, true);
            }

            return default(K);
        }

        public virtual List<K> GetListByCommand<K>(string command, object item)
        {
            try
            {
                return CollectionHelper.ToList<K>(DataMapperHelper.GetMapper(Database).QueryForList(command, item));
            }
            catch (Exception ex)
            {
                DataAccessExceptionHelper.ThrowException("DATAACCESS_ERROR", ex, true);
            }

            return new List<K>();
        }

        public virtual T GetByCommand(string command, Hashtable parameters)
        {
            try
            {
                return (T)DataMapperHelper.GetMapper(Database).QueryForObject<object>(command, parameters);
            }
            catch (Exception ex)
            {
                DataAccessExceptionHelper.ThrowException("DATAACCESS_ERROR", ex, true);
            }

            return default(T);
        }

        public virtual List<T> GetListByCommand(string command, Hashtable parameters)
        {
            try
            {
                return CollectionHelper.ToList<T>(DataMapperHelper.GetMapper(Database).QueryForList(command, parameters));
            }
            catch (Exception ex)
            {
                DataAccessExceptionHelper.ThrowException("DATAACCESS_ERROR", ex, true);
            }

            return new List<T>();
        }

        public virtual void BeginTransaction()
        {
            DataMapperHelper.GetMapper(Database).BeginTransaction();
        }

        public virtual void CommitTransaction()
        {
            DataMapperHelper.GetMapper(Database).CommitTransaction();
        }

        public virtual void RollBackTransaction()
        {
            DataMapperHelper.GetMapper(Database).RollBackTransaction();
        }

        #region sql text toolkit

        /// <summary>
        /// 格式化查询SQL字句，避免SQL注入攻击
        /// </summary>
        /// <param name="condition">SQL子句</param>
        /// <returns>格式化后的SQL字句</returns>
        private static string FormatSqlCondition(string condition)
        {
            // 如果条件中包含敏感sql关键字，那么将认为存在sql注入危险，过滤该条件
            if (!ValidateSqlText(condition)) return "1 = 1";

            string upperString = condition.ToUpper();
            var sperator = new string[1];
            sperator[0] = " AND ";
            string[] sList = upperString.Split(sperator, StringSplitOptions.None);
            var newList = new ArrayList();
            foreach (string s in sList)
            {
                if (s.IndexOf(" IN ") > 0)
                {
                    newList.Add(s);
                    continue;
                }

                int lIndex = s.IndexOf("'");
                int rIndex = s.LastIndexOf("'");
                if (lIndex > 0 && rIndex > 0 && lIndex != rIndex)
                {
                    string l = s.Substring(0, lIndex + 1);
                    string r = s.Substring(rIndex);
                    string m = s.Substring(lIndex + 1, rIndex - lIndex - 1);
                    string newS = l + m.Replace("'", "''") + r;
                    newList.Add(newS);
                }
                else
                {
                    newList.Add(s);
                }
            }

            string result = "";
            foreach (string ns in newList)
            {
                if (result != "")
                    result = result + " AND " + ns;
                else
                    result = ns;
            }

            return result;
        }

        ///  <summary>
        /// 分析用户请求是否正常
        ///  </summary>
        ///  <param name="sqlText">传入用户提交数据 </param>
        ///  <returns>返回是否含有SQL注入式攻击代码 </returns>
        private static bool ValidateSqlText(string sqlText)
        {
            bool returnValue = true;
            try
            {
                if (sqlText.Trim() != "")
                {
                    const string sqlStr =
                        "exec |insert |delete |update |count |* |chr |mid |master |truncate |char |declare";

                    string[] anySqlStr = sqlStr.Split('|');
                    foreach (string ss in anySqlStr)
                    {
                        if (sqlText.ToLower().IndexOf(ss) >= 0)
                        {
                            returnValue = false;
                            break;
                        }
                    }
                }
            }
            catch
            {
                returnValue = false;
            }
            return returnValue;
        }

        #endregion sql text toolkit
    }
}