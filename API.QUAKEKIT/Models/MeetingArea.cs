using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace API.QUAKEKIT.Models
{
    public class MeetingArea
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string maID { get; set; }
        public string maTitle { get; set; }
        public int maCityID { get; set; }
        public int maDistrictID { get; set; }
    }
}