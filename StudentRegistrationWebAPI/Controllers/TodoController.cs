using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentRegistrationWebAPI.Data;
using StudentRegistrationWebAPI.Models;

namespace StudentRegistrationWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public TodoController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IEnumerable<Todo> GetAllTodo()
        {
            var todos = _db.Todos.ToList();
            return todos;
        }

        [HttpPost("AddTodo")]
        public Todo CreateTodo(Todo todo)
        {
            Todo newTodo = new Todo
            {
                TodoName = todo.TodoName,
                UserId = todo.UserId,
            };
            _db.Todos.Add(newTodo);
            _db.SaveChanges();
            return newTodo;
        }

        [HttpDelete("DeleteTodo")]
        public async Task<ActionResult> DeleteTodo(int todoId)
        {
            var todo = _db.Todos.Find(todoId);
            _db.Todos.Remove(todo);
            _db.SaveChanges();
            return Ok(
                new ResponseGlobal()
                {
                    ResponseCode = ((int)System.Net.HttpStatusCode.OK),
                    Message = "Todo Deleted",
                    Data = GetAllTodo()
                });
        }

        [HttpPut("CheckTodo")]
        public async Task<ActionResult> CheckTodo(bool checkTodo , int todoId)
        {
            var todo = _db.Todos.Find(todoId);
            todo.Checked = checkTodo;
            _db.SaveChanges();
            return Ok(
    new ResponseGlobal()
    {
        ResponseCode = ((int)System.Net.HttpStatusCode.OK),
        Message = "Todo Checked",
        Data = todo
    });
        }

    }
}
