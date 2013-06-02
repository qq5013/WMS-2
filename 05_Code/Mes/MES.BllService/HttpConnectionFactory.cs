/*----------------------------------------------------------------
// Copyright (C) 2010 有限公司
// 版权所有。 
//
// 文件名：         HttpConnectionFactory.cs
// 文件功能描述：   Http数据库连接工厂
//
// 
// 创建标识：
//
// 修改标识：
// 修改描述：
//
// 修改标识：
// 修改描述：
----------------------------------------------------------------*/

using System;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Web;
using Frame.Utils.MetaDB;

namespace MES.Web
{
    /// <summary>
    /// Http数据库连接工厂
    /// </summary>
    public class HttpConnectionFactory : IConnectionFactory
    {
        private string _connectionString;
        private string _connectionStringName;
        private string _contextKey = "Connection";
        private string _contextTransactionKey = "Transaction";
        private IsolationLevel _isolationLevel = IsolationLevel.Unspecified;

        /// <summary>
        /// 名称
        /// </summary>
        public string Name
        {
            set { _connectionStringName = value; }
        }

        /// <summary>
        /// 数据
        /// </summary>
        public string ContextKey
        {
            set { _contextKey = value; }
        }

        /// <summary>
        /// 事务
        /// </summary>
        public string ContextTransactionKey
        {
            set { _contextTransactionKey = value; }
        }

        /// <summary>
        /// 分离级别
        /// </summary>
        public IsolationLevel IsolationLevel
        {
            get { return _isolationLevel; }
            set { _isolationLevel = value; }
        }

        #region IConnectionFactory Members

        public DbConnection GetConnection()
        {
            SqlConnection connection;
            if (null == HttpContext.Current.Items[_contextKey])
            {
                connection = new SqlConnection(ConnectionString);

                connection.Open();
                HttpContext.Current.Items[_contextKey] = connection;
            }
            else
            {
                connection = HttpContext.Current.Items[_contextKey] as SqlConnection;
                if (connection != null)
                {
                    switch (connection.State)
                    {
                        case ConnectionState.Closed:
                            HttpContext.Current.Items[_contextTransactionKey] = null;
                            connection.Open();
                            break;
                        case ConnectionState.Broken:
                            connection.Close();
                            HttpContext.Current.Items[_contextTransactionKey] = null;
                            connection.Open();
                            break;
                        default:
                            break;
                    }
                }
            }
            return connection;
        }

        public DbTransaction GetTransaction()
        {
            DbTransaction transaction;
            if (null == HttpContext.Current.Items[_contextTransactionKey])
            {
                DbConnection dbConnection = GetConnection();
                transaction = dbConnection.BeginTransaction(IsolationLevel);

                HttpContext.Current.Items[_contextTransactionKey] = transaction;
            }
            else
            {
                transaction = HttpContext.Current.Items[_contextTransactionKey] as DbTransaction;
            }
            return transaction;
        }

        public void Close()
        {
            if (null == HttpContext.Current.Items[_contextTransactionKey])
            {
                if (null == HttpContext.Current.Items[_contextKey])
                {
                }
                else
                {
                    var connection = (HttpContext.Current.Items[_contextKey] as DbConnection);
                    if (connection != null)
                        if (connection.State != ConnectionState.Closed)
                        {
                            connection.Close();
                        }
                    HttpContext.Current.Items[_contextKey] = null;
                }
            }
            else
            {
                if (null == HttpContext.Current.Items[_contextKey])
                {
                    HttpContext.Current.Items[_contextTransactionKey] = null;
                }
                else
                {
                    try
                    {
                        ((DbTransaction) HttpContext.Current.Items[_contextTransactionKey]).Commit();
                        var connection = (HttpContext.Current.Items[_contextKey] as DbConnection);
                        if (connection != null)
                            if (connection.State != ConnectionState.Closed)
                            {
                                connection.Close();
                            }
                        HttpContext.Current.Items[_contextKey] = null;
                        HttpContext.Current.Items[_contextTransactionKey] = null;
                    }
                    catch (Exception exception)
                    {
                        exception.Process();
                    }
                }
            }
        }

        #endregion

        /// <summary>
        /// 连接串
        /// </summary>
        private string ConnectionString
        {
            get
            {
                if (string.IsNullOrEmpty(_connectionString))
                    _connectionString = ConfigurationManager.ConnectionStrings[_connectionStringName].ConnectionString;
                
                return _connectionString;
            }
            set { _connectionString = value; }
        }
    }
}