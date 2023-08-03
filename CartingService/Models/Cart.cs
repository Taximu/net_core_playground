using LiteDB;

namespace Store.Core.Models;

public class Cart
{
    [BsonId]
    public ObjectId Id { get; set; }

    public Cart()
    {
        Id = ObjectId.NewObjectId();
    }
    
    public List<Item>? Items { get; set; }
}
