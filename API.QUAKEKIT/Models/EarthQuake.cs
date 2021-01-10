using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace API.QUAKEKIT.Models
{
    public class EarthQuake
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string eqID { get; set; }
        public string eqDate { get; set; }
        public string eqTime { get; set; }
        //Enlem
        public string eqLat { get; set; }
        //Boylam
        public string eqLng { get; set; }
        public string eqDepth { get; set; }
        public string eqSize { get; set; }
        public string eqLocationName { get; set; }
        public string eqCity { get; set; }
    }
}