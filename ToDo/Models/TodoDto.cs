using MongoDB.Bson;

namespace ToDoHomework.Models;

public class TodoDto 
{
    public string Id { get; set; } = null!;
    public string Value { get; set; } = string.Empty!;
    public bool Finished { get; set; }

    public static implicit operator Todo(TodoDto dto)
        => new()
        {
            Id = ObjectId.Parse(dto.Id),
            Finished = dto.Finished,
            Value = dto.Value
        };

    public static implicit operator TodoDto(Todo dto)
    => new()
    {
        Id = dto.Id.ToString(),
        Finished = dto.Finished,
        Value = dto.Value
    };
}
