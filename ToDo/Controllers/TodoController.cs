using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using ToDoHomework.Data;
using ToDoHomework.Models;

namespace ToDoHomework.Controllers;
public class TodoController(AppDbContext dbContext) : Controller
{
    private readonly AppDbContext dbContext = dbContext;
    public IActionResult Index()
    {
        var list = dbContext.Todos.Find(v => true).ToList();
        return View(list);
    }

    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Add(AddTodoDto dto)
    {
        dbContext.Todos.InsertOne((Todo)dto);

        return RedirectToAction("Index"); 
    }
    [HttpGet]
    public async Task<IActionResult> Edit(string id)
    {
        var res = await dbContext.Todos.Find(t => t.Id == ObjectId.Parse(id)).FirstOrDefaultAsync();
        var todo = (TodoDto)res;

        return View(todo);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(TodoDto dto)
    {
        if (!ModelState.IsValid)
        {
            return View(dto);
        }
        Todo todo = (Todo)dto;

        try
        {
            var result = await dbContext.Todos.ReplaceOneAsync(t => t.Id == todo.Id, todo);
            return RedirectToAction("Index");
        }
        catch (Exception ex)
        {
            return BadRequest($"Error updating Todo item {ex.Message}");
        }
    }

    public async Task<IActionResult> Delete(string id)
    {
        var objectId = ObjectId.Parse(id);
        var todo = await dbContext.Todos.FindOneAndDeleteAsync(t => t.Id == objectId);

        if (todo == null)
        {
            return NotFound();
        }

        return RedirectToAction("Index");
    }

}
