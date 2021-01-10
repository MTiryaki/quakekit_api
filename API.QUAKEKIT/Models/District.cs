using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace API.QUAKEKIT.Models
{
    public class District
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string dID { get; set; }
        public string cID { get; set; }
        public string distID { get; set; }
        public string distName { get; set; }
    }
}