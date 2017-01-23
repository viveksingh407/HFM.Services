using System;
using System.Collections.Generic;
using System.Linq;
using HFM.NoSQL.Data.Menu.Model;
using MongoDB.Bson;
using MongoDB.Driver;

namespace HFM.NoSQL.Data.Menu
{
    public class MenuRepository
    {
        private readonly string _address = "localhost";
        private readonly string _db = "Menu";
        private readonly string _menuCollection = "dailyMenu";

        public void Get()
        {
            var helper = new MongoDBHelper<MenuRepository>(_address, _db);

            var client = helper.client;
            var database = helper.db;

            var collection = database.GetCollection<DailyMenu>(_menuCollection);
            var restaurants = collection.Find<DailyMenu>(new BsonDocument()).ToList();
        }

        public void Create(DailyMenu dailyMenu)
        {
            var helper = new MongoDBHelper<MenuRepository>(_address, _db);
            var database = helper.db;

            dailyMenu = new DailyMenu() {
                MealName = "Test",
                MealDuration = "Breakfast",
                Day = "Monday",
                FamilyMember = "VS",
                MealType = "Veg",
                Season = "All",
                MealCatgory = "Test",
                Remarks = "NA",
                MenuIdentifier = "NA",
                CreatedOn = DateTime.Now,
                CreatedBy = "System",
                ModifiedOn = DateTime.Now,
                Modifiedby = "System",
            };

            var collection = database.GetCollection<DailyMenu>(_menuCollection);
            collection.InsertOne(dailyMenu, null, default(System.Threading.CancellationToken));
        }
    }
}
