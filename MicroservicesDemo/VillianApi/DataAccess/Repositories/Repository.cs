using DomainCommons.DTOs;
using DomainCommons.Services;
using MongoDB.Driver;
using VillainApi.DataAccess.Models;

namespace VillainApi.DataAccess.Repositories;

public class Repository : IRepository<VillainDto>
{

    private readonly IMongoCollection<Villain> _collection;

    public Repository()
    {
        var hostname = Environment.GetEnvironmentVariable("DB_HOST");
        var databaseName = Environment.GetEnvironmentVariable("DB_NAME");
        var connectionString = $"mongodb://{hostname}:27017";

        var client = new MongoClient(connectionString);
        var database = client.GetDatabase(databaseName);
        _collection = database.GetCollection<Villain>("Villains", new MongoCollectionSettings() { AssignIdOnInsert = true });
    }

    public async Task<VillainDto?> Add(VillainDto villain)
    {
        await _collection.InsertOneAsync(new Villain
        {
            Name = villain.Name,
            Description = villain.Description

        });
        return villain;
    }

    public async Task<VillainDto?> GetById(object id)
    {
        var villain = await _collection.FindAsync(v => v.Id == (string)id).Result.FirstOrDefaultAsync();

        return villain is not null ?
               new VillainDto(villain.Name, villain.Description)
               : null;
    }

    public async Task<IEnumerable<VillainDto>> GetAll()
    {
        var villainsCol = await _collection.FindAsync(_ => true);
        var villains = villainsCol.ToList().Select(v => new VillainDto(v.Name, v.Description));
        return villains;
    }

    public async Task<VillainDto?> Update(VillainDto villain, object id)
    {
        var filter = Builders<Villain>.Filter.Eq("Id", (string)id);
        var update = Builders<Villain>
            .Update
            .Set("Name", villain.Name)
            .Set("Description", villain.Description);

        var updated = await _collection
            .FindOneAndUpdateAsync(
                filter,
                update,
                new FindOneAndUpdateOptions<Villain, Villain>
                {
                    IsUpsert = true
                }
                );

        return new VillainDto(updated.Name,updated.Description);
    }

    public async Task<VillainDto?> Delete(object id)
    {
        var filter = Builders<Villain>.Filter.Eq("Id", (string)id);
        var deleted = await _collection.FindOneAndDeleteAsync(filter);
        return new VillainDto(deleted.Name, "");
    }
}