
using Common;
using Dapper;
using IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Repository
{
   public class AdvertisementRepository: IAdvertisementRepository
    {
        IDbConnection conn= DbFactory.GetConnection();
        public int Sum(int i, int j)
        {
            dynamic o = conn.Query("select * from ts_uidp_config");
            return i + j;
        }
    }
}
