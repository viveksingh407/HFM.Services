using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HFM.NoSQL.Data.Restaurants.Model
{
    public class Grades
    {
        public DateTime date { get; set; }
        public char grade { get; set; }
        public double? score { get; set; }
    }
}
