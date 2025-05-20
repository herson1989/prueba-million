using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Million.Sales.Domain.Entities
{
    public class Property
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; } = "";

        [BsonElement("address")]
        public string Address { get; set; } = "";

        [BsonElement("price")]
        public decimal Price { get; set; }

        [BsonElement("codeInternal")]
        public string CodeInternal { get; set; } = "";

        [BsonElement("year")]
        public string Year { get; set; } = "";

        [BsonElement("idOwner")]
        public string IdOwner { get; set; } = "";
    }
}
