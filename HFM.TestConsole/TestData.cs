using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HFM.TestConsole.Test.NoSQL.Menu;
using HFM.TestConsole.Test.NoSQL.Restaurants;

namespace HFM.TestConsole
{
    public class TestData
    {
        private static void Main(string[] args)
        {
            //RestaurantsTest test = new RestaurantsTest();
            MenuTest test = new MenuTest();
            test.MenuActions();
        }
    }
}
