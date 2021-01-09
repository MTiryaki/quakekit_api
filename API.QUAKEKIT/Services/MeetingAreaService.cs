using System.Collections.Generic;
using API.QUAKEKIT.Models;
using MongoDB.Driver;

namespace API.QUAKEKIT.Services
{
    public class MeetingAreaService
    {
        private readonly IMongoCollection<MeetingArea> _meetingAreas;
        private readonly IQuakeKitDatabaseSettings _quakeKitDatabaseSettings;
        public MeetingAreaService(IQuakeKitDatabaseSettings settings)
        {
            _quakeKitDatabaseSettings = settings;
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _meetingAreas = database.GetCollection<MeetingArea>("MeetingAreas");
        }

        public List<MeetingArea> Get()
        {
            List<MeetingArea> meetingAreas = _meetingAreas.Find(x => true).ToList();
            return meetingAreas;
        }

        public MeetingArea Get(string id)
        {
            return _meetingAreas.Find<MeetingArea>(x => x.maID == id).FirstOrDefault();
        }

        public MeetingArea Create(MeetingArea meetingArea)
        {
            _meetingAreas.InsertOne(meetingArea);
            return meetingArea;
        }

        public void Update(string id, MeetingArea MeetingAreaIn)
        {
            _meetingAreas.ReplaceOne(meetingArea => meetingArea.maID == id, MeetingAreaIn);
        }

        public void Remove(MeetingArea MeetingAreaIn)
        {
            _meetingAreas.DeleteOne(meetingArea => meetingArea.maID == MeetingAreaIn.maID);
        }

        public void Remove(string id)
        {
            _meetingAreas.DeleteOne(meetingArea => meetingArea.maID == id);
        }
    }
}
