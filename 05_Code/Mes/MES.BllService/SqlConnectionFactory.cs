using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Frame.Utils.MetaDB;

namespace MES.BllService
{
    /// <summary>
    ///     数据库连接工厂
    /// </summary>
    public class SqlConnectionFactory : IConnectionFactory
    {
        private DbConnection _connection;
        private IsolationLevel _isolationLevel = IsolationLevel.Unspecified;

        /// <summary>
        ///     连接
        /// </summary>
        public DbConnection Connection
        {
            get { return _connection ?? (_connection = new SqlConnection {ConnectionString = ConnectionString}); }
        }

        /// <summary>
        ///     分离级别
        /// </summary>
        public IsolationLevel IsolationLevel
        {
            get { return _isolationLevel; }
            set { _isolationLevel = value; }
        }

        /// <summary>
        ///     连接串
        /// </summary>
        public string ConnectionString { private get; set; }

        #region IConnectionFactory Members

        /// <summary>
        ///     获取连接
        /// </summary>
        /// <returns></returns>
        public DbConnection GetConnection()
        {
            switch (Connection.State)
            {
                case ConnectionState.Closed:
                    Connection.Open();
                    break;
                case ConnectionState.Broken:
                    Connection.Close();
                    Connection.Open();
                    break;
            }
            return Connection;
        }

        /// <summary>
        ///     获取事务
        /// </summary>
        /// <returns></returns>
        public DbTransaction GetTransaction()
        {
            return null;
        }

        /// <summary>
        ///     关闭
        /// </summary>
        public void Close()
        {
            Connection.Close();
        }

        #endregion
    }
}