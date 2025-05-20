using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Million.Sales.Domain.Entities
{
    public class PropertyImage
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = "";

        [BsonElement("idProperty")]
        public string IdProperty { get; set; } = "";

        [BsonElement("file")]
        public string File { get; set; } = "";

        [BsonElement("enabled")]
        public bool Enabled { get; set; }
    }
}
