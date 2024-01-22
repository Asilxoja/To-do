using MongoDB.Bson;

namespace ToDoHomework.Models;

public class AddTodoDto
{
    public string Value { get; set; } = string.Empty!;
    public bool Finished { get; set; }

    public static implicit operator Todo(AddTodoDto dto)
        => new()
        {
            Finished = dto.Finished,
            Value = dto.Value
        };
}
