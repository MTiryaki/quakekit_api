using System.Collections.Generic;
using API.QUAKEKIT.Models;
using MongoDB.Driver;

namespace API.QUAKEKIT.Services
{
    public class SecurityCheckService
    {
        private readonly IMongoCollection<SecurityCheck> _securityChecks;
        private readonly IQuakeKitDatabaseSettings _quakeKitDatabaseSettings;

        public SecurityCheckService(IQuakeKitDatabaseSettings settings)
        {
            _quakeKitDatabaseSettings = settings;
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _securityChecks = database.GetCollection<SecurityCheck>("SecurityChecks");
        }

        public List<SecurityCheck> Get()
        {
            List<SecurityCheck> securityChecks = _securityChecks.Find(x => true).ToList();
            return securityChecks;
        }

        public SecurityCheck Get(string id)
        {
            return _securityChecks.Find<SecurityCheck>(x => x.scID == id).FirstOrDefault();
        }

        public SecurityCheck Create(SecurityCheck securityCheck)
        {
            _securityChecks.InsertOne(securityCheck);
            return securityCheck;
        }

        public void Update(string id, SecurityCheck SecurityCheckIn)
        {
            _securityChecks.ReplaceOne(securityCheck => securityCheck.scID == id, SecurityCheckIn);
        }

        public void Remove(SecurityCheck SecurityCheckIn)
        {
            _securityChecks.DeleteOne(securityCheck => securityCheck.scID == SecurityCheckIn.scID);
        }

        public void Remove(string id)
        {
            _securityChecks.DeleteOne(securityCheck => securityCheck.scID == id);
        }
    }
}