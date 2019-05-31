using IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
   public class AdvertisementRepository: IAdvertisementRepository
    {
        public int Sum(int i, int j)
        {
            return i + j;
        }
    }
}
