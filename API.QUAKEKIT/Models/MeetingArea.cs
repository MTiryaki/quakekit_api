using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace API.QUAKEKIT.Models
{
    public class MeetingArea
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string maID { get; set; }
        public string mID { get; set; }
        public string maTitle { get; set; }
        public float maLat { get; set; }
        public float maLng { get; set; }
        public string maCity { get; set; }
        public string maDistrict { get; set; }
        public string maNeighborhood { get; set; }
    }
}