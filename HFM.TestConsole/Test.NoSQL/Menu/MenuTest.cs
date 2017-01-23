using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HFM.NoSQL.Data.Menu;
using HFM.NoSQL.Data.Menu.Model;

namespace HFM.TestConsole.Test.NoSQL.Menu
{
    public class MenuTest
    {
        public void MenuActions()
        {
            MenuRepository repo = new MenuRepository();
            repo.Create(new DailyMenu());
        }
    }
}
