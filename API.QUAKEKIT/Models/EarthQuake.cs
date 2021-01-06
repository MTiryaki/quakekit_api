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
        public EarthQuakeSize Sizes { get; set; }
        public string LocationName { get; set; }
        public string Attribute { get; set; }
    }

    public class EarthQuakeSize
    {
        public float MD { get; set; }
        public float ML { get; set; }
        public float MW { get; set; }
    }
}