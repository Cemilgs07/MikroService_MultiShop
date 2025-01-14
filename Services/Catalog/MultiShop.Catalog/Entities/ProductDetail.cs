using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MultiShop.Catalog.Entities
{
    public class ProductDetail
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ProdcutDetailId { get; set; }
        public string ProdcutDetailDescription { get; set; }
        public string ProdcutDetailinfo { get; set; }
        public string ProductId { get; set; }
        [BsonIgnore]

        public Product Product { get; set; }
    }
}
