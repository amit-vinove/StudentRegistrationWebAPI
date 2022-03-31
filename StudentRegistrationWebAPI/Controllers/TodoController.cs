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

        [HttpGet("GetTodoByUsername")]

        public IEnumerable<Todo> GetTodoByUsername(string username)
        {
            var todoData = (from todoDb in _db.Todos
                            join userDB in _db.Users
                            on todoDb.UserId equals userDB.UserId
                            where userDB.UserName == username
                            select new Todo()
                            {
                                TodoId = todoDb.TodoId,
                                TodoName = todoDb.TodoName,
                                UserId = todoDb.UserId,
                            }).ToList();
            return todoData;
        }

        [HttpPost("AddTodo")]
        public Todo CreateTodo(Todo todo)
        {
            var username = _db.Users.FirstOrDefault(m => m.UserName == todo.Username);

            Todo newTodo = new Todo
            {
                TodoName = todo.TodoName,
                UserId = username.UserId,
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
                    Data = true
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
        Data = GetAllTodo()
    });
        }

    }
}
