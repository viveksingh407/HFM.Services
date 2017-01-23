using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using HFM.NoSQL.Data;
using HFM.NoSQL.Data.Restaurants.Model;
using MongoDB.Bson;
using MongoDB.Driver;

namespace HFM.NoSQL.Data.Restaurants
{
    public class RestaurantsRepository
    {
        private readonly string _address = "localhost";
        private readonly string _db = "RestaurantsTutorial";
        private readonly string _restaurantsCollection = "restaurants";

        public void Get()
        {
            var helper = new MongoDBHelper<RestaurantsRepository>(_address, _db);

            var client = helper.client;
            var database = helper.db;

            var collection = database.GetCollection<Restaurant>(_restaurantsCollection);
            var restaurants = collection.Find<Restaurant>(new BsonDocument()).ToList();
        }
    }
}
