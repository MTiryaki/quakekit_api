using System.Collections.Generic;
using API.QUAKEKIT.Models;
using MongoDB.Driver;

namespace API.QUAKEKIT.Services
{
    public class CityService
    {
        private readonly IMongoCollection<City> _cities;
        private readonly IQuakeKitDatabaseSettings _quakeKitDatabaseSettings;

        public CityService(IQuakeKitDatabaseSettings settings)
        {
            _quakeKitDatabaseSettings = settings;
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _cities = database.GetCollection<City>("Cities");
        }

        public List<City> Get()
        {
            List<City> cities = _cities.Find(x => true).ToList();
            return cities;
        }

        public City Get(string id)
        {
            return _cities.Find<City>(x => x.cID == id).FirstOrDefault();
        }

        public City Create(City city)
        {
            _cities.InsertOne(city);
            return city;
        }

        public void Update(string id, City citiesIn)
        {
            _cities.ReplaceOne(city => city.cID == id, citiesIn);
        }

        public void Remove(City citiesIn)
        {
            _cities.DeleteOne(city => city.cID == citiesIn.cID);
        }

        public void Remove(string id)
        {
            _cities.DeleteOne(city => city.cID == id);
        }
    }
}