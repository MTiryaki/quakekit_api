using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace API.QUAKEKIT.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string uID { get; set; }
        public string uName { get; set; }
        public string uSurname { get; set; }
        public string uPhoneNo { get; set; }
        public string uMail { get; set; }
        public string uGender { get; set; }
        public DateTime uBirthdate { get; set; }
        public string uBloodType { get; set; }
        public string uCity { get; set; }
        public string uDistrict { get; set; }
        public string uNeighborhood { get; set; }
        public string uBuilding { get; set; }
        public string uFloor { get; set; }
        public string uCondo { get; set; }
        public string uAddress { get; set; }
        public string uSMSCode { get; set; }
        public string uType { get; set; }
        public Boolean uIsActive { get; set; }
        public int CreateEpoch { get; set; }
        public int UpdateEpoch { get; set; }
    }
}