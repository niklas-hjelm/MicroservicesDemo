using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace VillainApi.DataAccess.Models;

internal class Villain
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    [BsonElement]
    public string Name { get; set; } = string.Empty;
    [BsonElement]
    public string Description { get; set; } = string.Empty;
}