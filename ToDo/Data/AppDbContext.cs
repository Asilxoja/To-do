using MongoDB.Driver;
using ToDoHomework.Models;

namespace ToDoHomework.Data;

public class AppDbContext
{
    public IMongoDatabase _database { get; }

    public AppDbContext(string connecton, string database)
    {
        var client = new MongoClient(connecton);
        _database = client.GetDatabase(database);
    }

    public IMongoCollection<Todo> Todos
        => _database.GetCollection<Todo>("Todos"); 
}
