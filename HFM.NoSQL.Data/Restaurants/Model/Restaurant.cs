using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace HFM.NoSQL.Data.Restaurants.Model
{
    public class Restaurant
    {
        public ObjectId Id { get; set; }
        public Address address { get; set; }
        public string borough { get; set; }
        public string cuisine { get; set; }
        public IList<Grades> grades { get; set; }
        public string name { get; set; }
        public int restaurant_id { get; set; }
    }
}
