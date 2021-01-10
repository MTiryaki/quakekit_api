using System.Collections.Generic;
using API.QUAKEKIT.Models;
using MongoDB.Driver;

namespace API.QUAKEKIT.Services
{
    public class EarthQuakeService
    {
        private readonly IMongoCollection<EarthQuake> _earthQuakes;
        private readonly IQuakeKitDatabaseSettings _quakeKitDatabaseSettings;

        public EarthQuakeService(IQuakeKitDatabaseSettings settings)
        {
            _quakeKitDatabaseSettings = settings;
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _earthQuakes = database.GetCollection<EarthQuake>("EarthQuakes");
        }

        public List<EarthQuake> Get()
        {
            List<EarthQuake> earthQuakes = _earthQuakes.Find(x => true).ToList();
            return earthQuakes;
        }

        public EarthQuake Get(string id)
        {
            return _earthQuakes.Find<EarthQuake>(x => x.eqID == id).FirstOrDefault();
        }

        public EarthQuake Create(EarthQuake earthQuake)
        {
            _earthQuakes.InsertOne(earthQuake);
            return earthQuake;
        }

        public void Update(string id, EarthQuake EarthQuakeIn)
        {
            _earthQuakes.ReplaceOne(earthQuake => earthQuake.eqID == id, EarthQuakeIn);
        }

        public void Remove(EarthQuake EarthQuakeIn)
        {
            _earthQuakes.DeleteOne(earthQuake => earthQuake.eqID == EarthQuakeIn.eqID);
        }

        public void Remove(string id)
        {
            _earthQuakes.DeleteOne(earthQuake => earthQuake.eqID == id);
        }
    }
}