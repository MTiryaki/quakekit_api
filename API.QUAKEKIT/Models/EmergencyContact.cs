using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace API.QUAKEKIT.Models
{
    public class EmergencyContact
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ecID { get; set; }
        public string uID { get; set; }
        public string ecName { get; set; }
        public string ecSurname { get; set; }
        public string ecPhoneNo { get; set; }
        public Boolean ecIsActive { get; set; }
        public int CreateEpoch { get; set; }
        public int UpdateEpoch { get; set; }
    }
}