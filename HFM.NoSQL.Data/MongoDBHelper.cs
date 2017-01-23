using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Driver.Core.Servers;
using MongoDB.Driver.Core.Configuration;

namespace HFM.NoSQL.Data
{
    public class MongoDBHelper<T> where T : class
    {
        public IMongoClient client;
        public IMongoDatabase db;

        public MongoDBHelper() { }

        public MongoDBHelper(string connectionAddress, string database)
        {
            try
            {
                var settings = GetMongoClientSettings(connectionAddress);
                var dbSettings = GetMongoDatabaseSettings();

                client = new MongoClient(settings);
                db = client.GetDatabase(database, dbSettings);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static MongoClientSettings GetMongoClientSettings(string address)
        {
            var settings = new MongoClientSettings();

            settings.Server = new MongoServerAddress(address, 27017);

            return settings;
        }

        private static MongoDatabaseSettings GetMongoDatabaseSettings()
        {
            var dbSettings = new MongoDatabaseSettings();

            dbSettings = null;
            return dbSettings;
        }
    }
}
