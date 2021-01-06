using System;
using System.Collections.Generic;
using API.QUAKEKIT.Models;
using MongoDB.Driver;

namespace API.QUAKEKIT.Services
{
    public class EmergencyContactService
    {
        private readonly IMongoCollection<EmergencyContact> _emergencyContacts;
        private readonly IQuakeKitDatabaseSettings _quakeKitDatabaseSettings;
        public EmergencyContactService(IQuakeKitDatabaseSettings settings)
        {
            _quakeKitDatabaseSettings = settings;
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _emergencyContacts = database.GetCollection<EmergencyContact>("EmergencyContacts");
        }

        public List<EmergencyContact> Get()
        {
            List<EmergencyContact> machines = _emergencyContacts.Find(x => true).ToList();
            return machines;
        }

        public EmergencyContact Get(string id)
        {
            return _emergencyContacts.Find<EmergencyContact>(x => x.ecID == id).FirstOrDefault();
        }

        public EmergencyContact Create(EmergencyContact emergencyContact)
        {
            _emergencyContacts.InsertOne(emergencyContact);
            return emergencyContact;
        }

        public void Update(string id, EmergencyContact EmergencyContactIn)
        {
            _emergencyContacts.ReplaceOne(emergencyContact => emergencyContact.ecID == id, EmergencyContactIn);
        }

        public void Remove(EmergencyContact EmergencyContactIn)
        {
            _emergencyContacts.DeleteOne(emergencyContact => emergencyContact.ecID == EmergencyContactIn.ecID);
        }

        public void Remove(string id)
        {
            _emergencyContacts.DeleteOne(emergencyContact => emergencyContact.ecID == id);
        }
    }
}