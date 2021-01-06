using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace API.QUAKEKIT.Models
{
    public class DamageReport
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string drID { get; set; }
        public string uID { get; set; }
        public ICollection<DamagePhoto> drPhoto { get; set; }
        public string drPhotoPath { get; set; }
        public string drLatitude { get; set; }
        public string drLongitude { get; set; }
        public string drOtherUserName { get; set; }
        public string drOtherSurname { get; set; }
        public string drOtherPhoneNo { get; set; }
        public string drOtherCity { get; set; }
        public string drOtherDistrict { get; set; }
        public string drOtherNeighborhood { get; set; }
        public string drOtherAddress { get; set; }
        public Boolean IsActive { get; set; }
        public int CreateEpoch { get; set; }
        public int UpdateEpoch { get; set; }
    }

    public class DamagePhoto
    {
        public string photoID { get; set; }
        public string photoName { get; set; }
        public string photoPath { get; set; }
    }
}