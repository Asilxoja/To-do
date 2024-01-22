using MongoDB.Bson;

namespace ToDoHomework.Models;

public class Todo
{
    public ObjectId Id { get; set; }
    public string Value { get; set; } = string.Empty!;
    public bool Finished { get; set; }
}