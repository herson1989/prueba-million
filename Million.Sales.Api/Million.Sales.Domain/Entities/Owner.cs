﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace Million.Sales.Domain.Entities
{
    public class Owner
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = "";

        [BsonElement("name")]
        public string Name { get; set; } = "";

        [BsonElement("address")]
        public string Address { get; set; } = "";

        [BsonElement("photo")]
        public string Photo { get; set; } = "";

        [BsonElement("birthday")]
        public DateTime Birthday { get; set; }
    }
}
