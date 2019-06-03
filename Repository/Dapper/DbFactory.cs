using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Repository
{
    public class DbFactory
    {
        /// <summary>
        /// 获取数据库连接
        /// </summary>
        /// <returns></returns>
        public static IDbConnection GetConnection()
        {
            IDbConnection connection = null;

            //获取配置进行转换
            string  stype = Common.Helper.ConfigManager.Configuration["DBConnectoin:DBType"];
            //DefaultDatabase 根据这个配置项获取对应连接字符串
            string strConn = Common.Helper.ConfigManager.Configuration["DBConnectoin:"+stype];

            var dbType = GetDataBaseType(stype);

           

            switch (dbType)
            {
                case DatabaseType.SqlServer:
                    connection = new System.Data.SqlClient.SqlConnection(strConn);
                    break;
                case DatabaseType.MySql:
                    connection = new MySql.Data.MySqlClient.MySqlConnection(strConn);
                    break;
                case DatabaseType.Oracle:
                    connection = new Oracle.ManagedDataAccess.Client.OracleConnection(strConn);
                    //connection = new System.Data.OracleClient.OracleConnection(strConn);
                    break;
            }

            return connection;
        }
        /// <summary>
        /// 转换数据库类型
        /// </summary>
        /// <param name="databaseType">数据库类型</param>
        /// <returns></returns>
        private static DatabaseType GetDataBaseType(string databaseType)
        {
            DatabaseType returnValue = DatabaseType.SqlServer;
            foreach (DatabaseType dbType in Enum.GetValues(typeof(DatabaseType)))
            {
                if (dbType.ToString().Equals(databaseType, StringComparison.OrdinalIgnoreCase))
                {
                    returnValue = dbType;
                    break;
                }
            }
            return returnValue;
        }

        /// <summary>
        /// 数据库类型定义
        /// </summary>
        public enum DatabaseType
        {
            SqlServer,  //SQLServer数据库
            MySql,      //Mysql数据库
            Oracle,     //Oracle数据库
        }
    }
}
