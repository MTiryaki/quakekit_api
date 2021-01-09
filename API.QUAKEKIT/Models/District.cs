using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace API.QUAKEKIT.Models
{
    public class District
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string dID { get; set; }
        public string distName { get; set; }
        public City Cities { get; set; }
    }
}