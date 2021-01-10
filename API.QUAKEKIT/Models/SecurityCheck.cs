using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace API.QUAKEKIT.Models
{
    public class SecurityCheck
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string scID { get; set; }
        public string uID { get; set; }
        public bool scStatus { get; set; }
    }
}