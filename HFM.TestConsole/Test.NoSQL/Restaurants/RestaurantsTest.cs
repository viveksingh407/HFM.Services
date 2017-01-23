using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HFM.NoSQL.Data.Restaurants;

namespace HFM.TestConsole.Test.NoSQL.Restaurants
{
    public class RestaurantsTest
    {
        public void GetRestaurants()
        {
            RestaurantsRepository repo = new RestaurantsRepository();
            repo.Get();
        }
    }
}
