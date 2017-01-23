using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HFM.NoSQL.Data;

namespace HFM.NoSQL.Data.Menu
{
    public class MenuRepository
    {
        public void Get()
        {
            MongoDBHelper<MenuRepository> helper = new MongoDBHelper<MenuRepository>();
            
        }
    }
}
