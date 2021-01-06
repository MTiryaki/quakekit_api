using System;
using System.Collections.Generic;
using API.QUAKEKIT.Models;
using MongoDB.Driver;

namespace API.QUAKEKIT.Services
{
    public class DamageReportService
    {
        private readonly IMongoCollection<DamageReport> _damageReports;
        private readonly IQuakeKitDatabaseSettings _quakeKitDatabaseSettings;
        public DamageReportService(IQuakeKitDatabaseSettings settings)
        {
            _quakeKitDatabaseSettings = settings;
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _damageReports = database.GetCollection<DamageReport>("DamageReports");
        }

        public List<DamageReport> Get()
        {
            List<DamageReport> damageReports = _damageReports.Find(x => true).ToList();
            return damageReports;
        }

        public DamageReport Get(string id)
        {
            return _damageReports.Find<DamageReport>(x => x.drID == id).FirstOrDefault();
        }

        public DamageReport Create(DamageReport damageReport)
        {
            _damageReports.InsertOne(damageReport);
            return damageReport;
        }

        public void Update(string id, DamageReport DamageReportIn)
        {
            _damageReports.ReplaceOne(damageReport => damageReport.drID == id, DamageReportIn);
        }

        public void Remove(DamageReport DamageReportIn)
        {
            _damageReports.DeleteOne(damageReport => damageReport.drID == DamageReportIn.drID);
        }

        public void Remove(string id)
        {
            _damageReports.DeleteOne(damageReport => damageReport.drID == id);
        }
    }
}