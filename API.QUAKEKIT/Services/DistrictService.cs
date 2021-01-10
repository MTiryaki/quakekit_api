using System.Collections.Generic;
using API.QUAKEKIT.Models;
using MongoDB.Driver;

namespace API.QUAKEKIT.Services
{
    public class DistrictService
    {
        private readonly IMongoCollection<District> _districts;
        private readonly IQuakeKitDatabaseSettings _quakeKitDatabaseSettings;

        public DistrictService(IQuakeKitDatabaseSettings settings)
        {
            _quakeKitDatabaseSettings = settings;
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _districts = database.GetCollection<District>("Districts");
        }

        public List<District> Get()
        {
            List<District> districts = _districts.Find(x => true).ToList();
            return districts;
        }

        public District Get(string id)
        {
            return _districts.Find<District>(x => x.dID == id).FirstOrDefault();
        }

        public District Create(District district)
        {
            _districts.InsertOne(district);
            return district;
        }

        public void Update(string id, District districtIn)
        {
            _districts.ReplaceOne(district => district.dID == id, districtIn);
        }

        public void Remove(District districtIn)
        {
            _districts.DeleteOne(district => district.dID == districtIn.dID);
        }

        public void Remove(string id)
        {
            _districts.DeleteOne(district => district.dID == id);
        }
    }
}