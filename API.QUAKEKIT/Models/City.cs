using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace API.QUAKEKIT.Models
{
    public class City
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string cID { get; set; }
        public int cityNo { get; set; }
        public string cityName { get; set; }
    }
}