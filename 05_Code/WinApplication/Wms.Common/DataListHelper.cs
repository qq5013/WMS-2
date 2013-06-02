using System;
using System.Collections.Generic;
using System.Data;
using System.Collections;
using System.Reflection;

namespace CabApplication.Common
{
    public sealed class DataListHelper
    {       
        /// <summary>
        /// Ilist<T> 转换成 DataSet
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static DataSet ConvertToDataSet<T>(IList<T> list)
        {
            if (list == null || list.Count <= 0)
            {
                return null;
            }

            DataSet ds = new DataSet();
            DataTable dt = new DataTable(typeof(T).Name);
            DataColumn column;
            DataRow row;

            PropertyInfo[] myPropertyInfo = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (T t in list)
            {
                if (t == null)
                {
                    continue;
                }

                row = dt.NewRow();

                for (int i = 0, j = myPropertyInfo.Length; i < j; i++)
                {
                    PropertyInfo pi = myPropertyInfo[i];

                    string name = pi.Name;

                    if (dt.Columns[name] == null)
                    {
                        column = new DataColumn(name, pi.PropertyType);
                        dt.Columns.Add(column);
                    }

                    row[name] = pi.GetValue(t, null);
                }

                dt.Rows.Add(row);
            }

            ds.Tables.Add(dt);

            return ds;
        }

        /// <summary>
        /// Ilist<T> 转换成 DataSet
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static DataSet ConvertToDataSetPro<T>(IList<T> list)
        {
            //if (list == null || list.Count <= 0)
            //{
            //    return null;
            //}

            DataSet ds = new DataSet();
            DataTable dt = new DataTable(typeof(T).Name);
            DataColumn column;
            DataRow row;

            PropertyInfo[] myPropertyInfo = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            for (int i = 0, j = myPropertyInfo.Length; i < j; i++)
            {
                PropertyInfo pi = myPropertyInfo[i];

                string name = pi.Name;

                if (!dt.Columns.Contains(name))
                {
                    column = new DataColumn(name, pi.PropertyType);
                    dt.Columns.Add(column);
                }
            }

            foreach (T t in list)
            {
                if (t == null)
                {
                    continue;
                }

                row = dt.NewRow();

                for (int i = 0, j = myPropertyInfo.Length; i < j; i++)
                {
                    PropertyInfo pi = myPropertyInfo[i];

                    string name = pi.Name;

                    row[name] = pi.GetValue(t, null);
                }

                dt.Rows.Add(row);
            }
            dt.AcceptChanges();
            ds.Tables.Add(dt);
            dt.AcceptChanges();
            return ds;
        }

        public static Hashtable ConvertToHashtable<T>(T obj)
        {
            Hashtable ht = new Hashtable();
            Type entityType = Type.GetType(obj.GetType().AssemblyQualifiedName);
            PropertyInfo[] infos = entityType.GetProperties();
            for (int i = 0; i < infos.Length; i++)
            {
                ht.Add(infos[i].Name, infos[i].GetValue(obj, null));
            }
            return ht;
        }

        public static IList<T> DeapCopy<T>(IList<T> lst) where T : class, new()
        {
            IList<T> lstResult = new List<T>();
            Type tp = typeof(T);
            for (int i = 0, j = lst.Count; i < j; i++)
            {
                T info = new T();
                PropertyInfo[] ps = tp.GetProperties();
                for (int k = 0, cnt = ps.Length; k < cnt; k++)
                {
                    object obj = ps[k].GetValue(lst[i], null);
                    ps[k].SetValue(info, obj, null);
                }
                //
                lstResult.Add(info);
            }
            return lstResult;
        }

        /// <summary>
        /// 取得
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T FindFirst<T>(IList<T> list, string name, object value) where T : class, new()
        {
            PropertyInfo property = typeof(T).GetProperty(name);
            foreach (T t in list)
            {
                if (property.GetValue(t, null).ToString().Equals(value.ToString()))
                {
                    return t;
                }
            }
            return null;
        }

        public static T FindFirst<T>(IList<T> list, params object[] args) where T : class, new()
        {
            int length = args.Length / 2;
            PropertyInfo[] propetrys = new PropertyInfo[length];
            object[] objs = new object[length];

            for (int i = 0; i < length; i++)
            {
                string key = Convert.ToString(args[2 * i]);
                propetrys[i] = typeof(T).GetProperty(key);
                objs[i] = args[2 * i + 1];
            }

            foreach (T t in list)
            {
                bool isEqual = true;
                for (int i = 0; i < length; i++)
                {
                    object vl = propetrys[i].GetValue(t, null);
                    if (!vl.ToString().Equals(objs[i].ToString()))
                    {
                        isEqual = false;
                        break;
                    }
                }
                if (isEqual)
                {
                    return t;
                }
            }
            return null;
        }

        public static IList<T> FindAll<T>(IList<T> list, string name, object value)
        {
            List<T> ls = new List<T>();
            PropertyInfo property = typeof(T).GetProperty(name);
            foreach (T t in list)
            {
                object vl = property.GetValue(t, null);
                if (vl.ToString().Equals(value.ToString()))
                {
                    ls.Add(t);
                }
            }
            return ls;
        }

        public static IList<T> FindAll<T>(IList<T> list, params object[] args)
        {
            List<T> ls = new List<T>();
            int length = args.Length / 2;
            PropertyInfo[] propetrys = new PropertyInfo[length];
            object[] objs = new object[length];

            for (int i = 0; i < length; i++)
            {
                string key = Convert.ToString(args[2 * i]);
                propetrys[i] = typeof(T).GetProperty(key);
                objs[i] = args[2 * i + 1];
            }

            foreach (T t in list)
            {
                bool isEqual = true;
                for (int i = 0; i < length; i++)
                {
                    if (!propetrys[i].GetValue(t, null).ToString().Equals(objs[i].ToString()))
                    {
                        isEqual = false;
                        break;
                    }
                }
                if (isEqual)
                {
                    ls.Add(t);
                }
            }
            return ls;
        }

        public IList<T> FindAll<T>(IList<T> list, string sort)
        {
            return null;
        }

        public static IList<T> DistillAll<T>(ref IList<T> list, string name, object value)
        {
            List<T> lstResult = new List<T>();
            List<T> lstSource = new List<T>();
            PropertyInfo property = typeof(T).GetProperty(name);
            foreach (T t in list)
            {
                object vl = property.GetValue(t, null);
                if (vl.ToString().Equals(value.ToString()))
                {
                    lstResult.Add(t);
                }
                else
                {
                    lstSource.Add(t);
                }
            }
            list = lstSource;

            return lstResult;
        }

        public static IList<T> ConvertToIList<T>(IList list)
        {
            IList<T> resultList = new List<T>();
            foreach (T item in list)
            {
                resultList.Add(item);
            }

            return resultList;
        }

        public static ArrayList ConvertToArrayList<T>(IList<T> list)
        {
            ArrayList resultList = new ArrayList();
            foreach (T item in list)
            {
                resultList.Add(item);
            }

            return resultList;
        }

        public static ArrayList ConvertIListToArrayList(IList list)
        {
            ArrayList arrayList = new ArrayList();
            if (list != null)
            {
                foreach (object obj in list)
                {
                    arrayList.Add(obj);
                }
            }
            return arrayList;
        }
    }
}