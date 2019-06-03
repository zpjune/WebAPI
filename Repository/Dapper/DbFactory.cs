using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Common
{
    public class DbFactory
    {
        public static IDbConnection GetConnection()
        {
           string DBType = Common.Helper.ConfigManager.Configuration["DBConnectoin:DBType"];
           return GetSqlConnection(Common.Helper.ConfigManager.Configuration[DBType]);
        }
            public static IDbConnection GetSqlConnection(string sqlConnectionString)
            {
                IDbConnection conn = new SqlConnection(sqlConnectionString);
                return conn;

            }
       
    }
}
