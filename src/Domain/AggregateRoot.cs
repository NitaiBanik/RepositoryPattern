using MongoDB.Bson.Serialization.Attributes;

namespace Domain;

public abstract class AggregateRoot
{
    [BsonId]
    public string ItemId { get; set; } = default!;
}
