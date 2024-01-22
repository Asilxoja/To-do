using MongoDB.Bson;

namespace ToDoHomework.Models;

public class UpdateDto 
{
    public string Id { get; set; } = null!;
    public string Value { get; set; } = string.Empty!;
    public bool Finished { get; set; }
    public static implicit operator Todo(UpdateDto dto)
        => new()
        {
            Id = ObjectId.Parse(dto.Id),
            Finished = dto.Finished,
            Value = dto.Value
        };
}
