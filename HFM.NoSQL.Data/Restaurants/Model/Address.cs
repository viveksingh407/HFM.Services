using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HFM.NoSQL.Data.Restaurants.Model
{
    public class Address
    {
        public string building { get; set; }
        public double[] coord { get; set; }
        public string street { get; set; }
        public string zipcode { get; set; }
    }
}
