using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace MES.BllService
{
    public class DataHelper
    {
        public Dictionary<int, string> GetProducts()
        {
            const string name = "WMS";
            SqlConnection sqlConnection = SqlConnection(name);
            sqlConnection.Open();
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = "SELECT [SkuId],[SkuName]  FROM [dbo].[Sku] nolock";
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            var dictionary = new Dictionary<int, string>();
            while (sqlDataReader.Read())
            {
                dictionary.Add((int) sqlDataReader[0], (string) sqlDataReader[1]);
            }

            return dictionary;
        }

        private static SqlConnection SqlConnection(string name)
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings[name].ConnectionString);
        }

        public Dictionary<int, string> ProductLineTypes()
        {
            return new Dictionary<int, string>
                {
                    {1, "下线"},
                    {2, "组装"},
                    {3, "组件"}
                };
        }

        public static DataTable GetTable(string name, string commandText)
        {
            var dataTable = new DataTable();
            using (var sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[name].ConnectionString))
            {
                new SqlDataAdapter(commandText, sqlConnection).Fill(dataTable);
            }
            return dataTable;
        }
    }
}