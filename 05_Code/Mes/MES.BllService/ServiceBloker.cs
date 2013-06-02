/*----------------------------------------------------------------
// Copyright (C) 2010 有限公司
// 版权所有。 
//
// 文件名：         ServiceHelper.cs
// 文件功能描述：   Service帮助类
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
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml.Serialization;
using Frame.Utils;
using Frame.Utils.ConditionInterpreter;
using Frame.Utils.Contract;
using Frame.Utils.Log;
using Frame.Utils.MetaDB;
using Frame.Utils.Service;
using MES.BllService.Data;
using MES.Entity;

namespace MES.BllService
{
    /// <summary>
    ///     Service帮助类
    /// </summary>
    public static class ServiceBloker
    {
        /// <summary>
        ///     数据库连接工厂
        /// </summary>
        public static readonly SqlConnectionFactory Connection = new SqlConnectionFactory
            {
                ConnectionString = ConfigurationManager.ConnectionStrings["MES"].ConnectionString
            };


        /// <summary>
        ///     表信息
        /// </summary>
        private static List<TableInfo> _tableInfos;

        /// <summary>
        ///     日志
        /// </summary>
        private static readonly ILogger FileWriter
            = new FileWriter {PathName = "./"};

        /// <summary>
        ///     SqlServer翻译
        /// </summary>
        private static readonly SqlServerInterpreter SqlServerInterpreter = new SqlServerInterpreter();

        /// <summary>
        ///     表信息
        /// </summary>
        public static List<TableInfo> TableInfos
        {
            get
            {
                //Trace.WriteLine("TableInfos" + DateTime.Now);
                if (_tableInfos == null)
                {
                    const string tableinfosConfig = "TableInfos.config";
                    var serializer = new XmlSerializer(typeof (List<TableInfo>));

                    const string sql =
                        @" SELECT     TOP (100) PERCENT d.[name] AS TableName, f.[value] Description
        FROM        sysobjects AS d  LEFT OUTER JOIN
        sys.extended_properties AS f
        ON d.id = f.major_id AND f.minor_id = 0
        where  d.xtype = 'U' AND d.status >= 0 and d.[name] not like 'Enum_%'
        and  d.[name] not like '_Del%' and d.[name]!='sysdiagrams'
        order by d.[name]";

                    using (
                        var sc =
                            new SqlConnection(
                                ConfigurationManager.ConnectionStrings["MES"].ConnectionString))
                    {
                        sc.Open();
                        SqlCommand sqlCommand = sc.CreateCommand();
                        sqlCommand.CommandText = sql;
                        _tableInfos = new List<TableInfo>();
                        SqlDataReader reader = sqlCommand.ExecuteReader();
                        while (reader.Read())
                        {
                            string tableName = reader["TableName"] != DBNull.Value
                                                   ? reader["TableName"].ToString()
                                                   : null;
                            string description = reader["Description"] != DBNull.Value
                                                     ? reader["Description"].ToString()
                                                     : null;
                            _tableInfos.Add(new TableInfo
                                {
                                    TableName = tableName,
                                    Description = description,
                                });
                        }
                        reader.Close();
                        sc.Close();
                    }
                    using (var writer = new StreamWriter(tableinfosConfig))
                    {
                        serializer.Serialize(writer, _tableInfos);
                    }
                }

                //Trace.WriteLine("TableInfos end" + DateTime.Now);
                return _tableInfos;
            }
        }

        /// <summary>
        ///     获取实体服务
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IEntityService<T> GetService<T>() where T : class, IBaseEntity
        {
            //Trace.WriteLine("GetService" + DateTime.Now);
            List<TableInfo> tableInfos = TableInfos;
            IEntityService<T> sqlServer2008EntityService = SqlServer2008EntityService<T>(tableInfos);
            //Trace.WriteLine("GetService End" + DateTime.Now);
            return sqlServer2008EntityService;
        }

        private static IEntityService<T> SqlServer2008EntityService<T>(List<TableInfo> tableInfos)
            where T : class, IBaseEntity
        {
            Type typeName = typeof (T);

            TableInfo tableInfo = tableInfos.Find(c => c.EntityName == typeName.Name);
            if (tableInfo != null)
            {
                if (tableInfo.Service == null)
                {
                    EntityInfo entityInfo = EntityInfoCreater.Create(typeName,
                                                                     tableInfo.EntityPrefix);

                    AdjustEntity(entityInfo);

                    var sqlServer2008EntityService = new SqlServer2008EntityService<T>
                        {
                            EntityInfo = entityInfo,
                            Connection = Connection,
                            DbInterpreter = SqlServerInterpreter,
                            Logger = FileWriter
                        };
                    tableInfo.Service = sqlServer2008EntityService;

                    return sqlServer2008EntityService;
                }
                return tableInfo.Service as IEntityService<T>;
            }

            return null;
        }

        /// <summary>
        ///     获取主从表服务
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TDetail"></typeparam>
        /// <returns></returns>
        public static IMasterDetailService<T, TDetail> GetService<T, TDetail>()
            where T : class, IBaseEntity
            where TDetail : class, IBaseEntity
        {
            return new MasterDetailService<T, TDetail>();
        }

        /// <summary>
        ///     获取树状服务
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static ITreeService<T> GetTreeService<T>() where T : class, IBaseEntity
        {
            return new TreeService<T> {Service = GetService<T>()};
        }

        /// <summary>
        ///     获取查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IEntityQuery<T> GetQuery<T>()
        {
            if (typeof (T) == typeof (SkuInfo))
            {
                return new SqlServer2008QueryService<T>
                    {
                        QueryString =
                            @"SELECT     Base_Sku.ProductId AS ProductId, Base_Sku.SkuId AS SkuId, Base_Sku.Code, Base_Sku.Spec, Base_Sku.Model, Base_Sku.Color, Base_Product.Name,Base_Product.TraceType,   Base_Product.IsMateriel,
                      Base_ProductCategory.Name AS CategoryName,Base_ProductCategory.Code AS CategoryCode
FROM         Base_Product INNER JOIN
                      Base_ProductCategory ON Base_Product.ProductCategoryId = Base_ProductCategory.ProductCategoryId INNER JOIN
                      Base_Sku ON Base_Product.ProductId = Base_Sku.ProductId",
                        Connection = Connection,
                        DbInterpreter = SqlServerInterpreter,
                        Logger = FileWriter
                    };
            }
            if (typeof (T) == typeof (ProductResult))
            {
                return new SqlServer2008QueryService<T>
                    {
                        QueryString =
                            @"select g.*,u.Name as WorkNo,p.Name as ProductName from 
(
select j.WorkerId,j.Date,j.ProductId,sum(j.Quantity) as Quantity,sum(j.ReworkQuantity) as ReworkQuantity,sum(j.WasterQuantity) as WasterQuantity from 
(
select distinct p.OperatorId WorkerId,Barcode,SUBSTRING(Convert(varchar,p.BegainTime,120 ),0,11) Date,s.ProductId, 1  Quantity,case when p.[Status]=3 then 1 else 0 end ReworkQuantity,case when p.[Status]=4 then 1 else 0 end WasterQuantity 
from dbo.Log_ItemProcess as p 
join Log_Item i on p.ItemId=i.ItemId and i.Barcode is not null 
join Base_Sku s on i.SkuId=s.SkuId)
as j 
group by j.WorkerId,j.Date,j.ProductId ) 
as g join Auth_User as u on g.WorkerId=u.UserId join Base_Product as p on g.ProductId=p.ProductId",
                        Connection = Connection,
                        DbInterpreter = SqlServerInterpreter,
                        Logger = FileWriter
                    };
            }
            if (typeof (T) == typeof (SemiManufacturesResult))
            {
                return new SqlServer2008QueryService<T>
                    {
                        QueryString =
                            @"select g.*,u.Name as WorkNo,p.Name as ProductName from 
(
select j.WorkerId,j.Date,j.ProductId,sum(j.Quantity) as Quantity,sum(j.ReworkQuantity) as ReworkQuantity,sum(j.WasterQuantity) as WasterQuantity from 
(
select distinct p.OperatorId WorkerId,Barcode,SUBSTRING(Convert(varchar,p.BegainTime,120 ),0,11) Date,s.ProductId,1 Quantity,case when p.[Status]=3 then 1 else 0 end ReworkQuantity,case when p.[Status]=4 then 1 else 0 end WasterQuantity 
from dbo.Log_ItemProcess as p 
join Log_Item i on p.ItemId=i.ItemId and i.Barcode is null
join Base_Sku s on i.SkuId=s.SkuId)
as j 
group by j.WorkerId,j.Date,j.ProductId ) 
as g join Auth_User as u on g.WorkerId=u.UserId join Base_Product as p on g.ProductId=p.ProductId",
                        Connection = Connection,
                        DbInterpreter = SqlServerInterpreter,
                        Logger = FileWriter
                    };
            }


            if (typeof (T) == typeof (QualityTrace))
            {
                return new SqlServer2008QueryService<T>
                    {
                        QueryString =
                            @"select i.ItemId,s.ProductId,s.SkuId,p.ProcessId,f.ProcessStepId,f.ProcessStepDetailId,p.OperatorId,psd.createtime BegainTime,psd.TraceCode from dbo.Log_Item as i join dbo.Log_ItemProcess as p on i.ItemId=p.ItemId
join dbo.Log_ItemProcessStep as ps on ps.ItemProcessId=p.ItemProcessId join dbo.Log_ItemProcessStepDetail as psd on psd.ItemProcessStepId=ps.ItemProcessStepId
join dbo.Fun_ProcessStepDetail as f on psd.SkuId=f.SkuId and ps.ProcessStepId=f.ProcessStepId join Base_Sku as s on s.SkuId=psd.SkuId",
                        Connection = Connection,
                        DbInterpreter = SqlServerInterpreter,
                        Logger = FileWriter
                    };
            }
            if (typeof (T) == typeof (ProductionRework))
            {
                return new SqlServer2008QueryService<T>
                    {
                        QueryString =
                            @" select i.SkuId ,i.TraceCode [TraceCode],u.Name EmployeeCode ,r.[ActualOperateTime] [Time]
   from Log_Rework as r 
   join Log_Item as i on r.ProductProcedureId=i.itemid   
   join Auth_User u on r.[ActualOperator]=u.UserId",
                        Connection = Connection,
                        DbInterpreter = SqlServerInterpreter,
                        Logger = FileWriter
                    };
            }

            if (typeof (T) == typeof (ProductionWaster))
            {
                return new SqlServer2008QueryService<T>
                    {
                        QueryString =
                            @"   select i.SkuId ,i.TraceCode [TraceCode],u.Name EmployeeCode ,r.[CreateTime] [Time]
   from Log_Waster as r join Log_Item as i on r.ProductInfoId=i.itemid    join Auth_User u on r.[CreaterId]=u.UserId",
                        Connection = Connection,
                        DbInterpreter = SqlServerInterpreter,
                        Logger = FileWriter
                    };
            }

            return null;
        }

        /// <summary>
        ///     获取对象，暂时不用
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T GetObject<T>()
        {
            return default(T);
        }

        /// <summary>
        ///     获取枚举数据
        /// </summary>
        /// <param name="enumType"></param>
        /// <returns></returns>
        public static List<EnumItem> GetEnumQuery(string enumType)
        {
            var db2O = new Db2O<EnumItem>();

            if (enumType.EndsWith("type", StringComparison.CurrentCultureIgnoreCase))
            {
                return
                    db2O.Query(
                        Connection.CreateCommand("select * from enum_itemtype where enumname='" +
                                                 (enumType.Substring(0, enumType.Length - 4) + "'")));
            }
            if (enumType.EndsWith("status", StringComparison.CurrentCultureIgnoreCase))
            {
                return
                    db2O.Query(
                        Connection.CreateCommand("select * from enum_itemstatus where enumname='" +
                                                 (enumType.Substring(0, enumType.Length - 6) + "'")));
            }
            return db2O.Query(Connection.CreateCommand("select * from enum_item where enumname='" + enumType + "'"));
        }

        /// <summary>
        ///     解密
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string GetCrypt(string text)
        {
            return text;
        }

        public static void AddColumn(EntityInfo tableInfo, PropertyInfo propertyInfo)
        {
            using (
                var sc =
                    new SqlConnection(
                        ConfigurationManager.ConnectionStrings["MES"].ConnectionString))
            {
                sc.Open();
                SqlCommand sqlCommand = sc.CreateCommand();
                string s;
                if (propertyInfo.PropertyType == typeof (int))
                {
                    s = @" int NULL";
                }
                else if (propertyInfo.PropertyType == typeof (DateTime))
                {
                    s = @" DateTime NULL";
                }
                else
                    s = @" nvarchar(256) NULL";
                sqlCommand.CommandText = @"ALTER TABLE dbo." + tableInfo.TableName + @" ADD " + propertyInfo.Name + s;
                sqlCommand.ExecuteNonQuery();
                sc.Close();
            }
        }

        public static List<string> GetColumnList(string tableName)
        {
            var list = new List<string>();
            using (
                var sc =
                    new SqlConnection(
                        ConfigurationManager.ConnectionStrings["MES"].ConnectionString))
            {
                sc.Open();
                SqlCommand sqlCommand = sc.CreateCommand();

                sqlCommand.CommandText = @"   SELECT    
       a.name AS ColumnName
        FROM         syscolumns AS a LEFT OUTER JOIN
        systypes AS b ON a.xtype = b.xusertype INNER JOIN
        sysobjects AS d ON a.id = d.id AND d.xtype = 'U' AND d.status >= 0 and d.[Name] not like '_Del_%' and d.[name] not like 'Enum_%' LEFT OUTER JOIN
        syscomments AS e ON a.cdefault = e.id LEFT OUTER JOIN
        sys.extended_properties AS g ON a.id = g.major_id AND a.colid = g.minor_id LEFT OUTER JOIN
        sys.extended_properties AS f ON d.id = f.major_id AND f.minor_id = 0
        Where d.name='" + tableName + @"'";
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    list.Add(sqlDataReader[0].ToString());
                }


                sc.Close();
            }
            return list;
        }

        public static void AdjustEntity(EntityInfo info)
        {
            var baseEntities = new Hashtable();
            foreach (
                var type in
                    typeof (ProductLine).Assembly.GetTypes()
                                        .Where(type => type.GetInterfaces().Contains(typeof (IBaseEntity))))
            {
                baseEntities.Add(type.Name, type);
            }
            List<string> list = baseEntities.Keys.ToList<string>();
            if (list.Any(c => string.Compare(c, info.EntityName, StringComparison.OrdinalIgnoreCase) == 0))
            {
                List<string> columnNames = GetColumnList(info.TableName);
                var type = baseEntities[info.EntityName] as Type;
                if (type != null)
                    foreach (
                        var propertyInfo in
                            type.GetProperties()
                                .Where(propertyInfo => columnNames.All(c => string.Compare(c, propertyInfo.Name,
                                                                                           StringComparison
                                                                                               .CurrentCultureIgnoreCase) != 0))
                                .Where(propertyInfo => !propertyInfo.PropertyType.IsGenericType ||
                                                       propertyInfo.PropertyType.GetGenericTypeDefinition() !=
                                                       typeof (List<>)))
                    {
                        AddColumn(info, propertyInfo);
                    }
            }
        }
    }
}