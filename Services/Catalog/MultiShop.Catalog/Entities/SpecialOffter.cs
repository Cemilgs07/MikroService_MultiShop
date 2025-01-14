using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MultiShop.Catalog.Entities
{
    public class SpecialOffter
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string SpecialOffterId { get; set; }
        public string Title { get; set; }
        public string subTitle { get; set; }
        public string ImageUrl { get; set; }
    }
}
