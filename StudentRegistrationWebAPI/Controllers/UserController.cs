using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentRegistrationWebAPI.Data;
using StudentRegistrationWebAPI.Models;

namespace StudentRegistrationWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public UserController(ApplicationDbContext db)
        {
            _db = db;

        }

        [HttpGet("GetAllUsers")]
        public IEnumerable<User> GetAllUsers()
        {

            var userData = _db.Users.ToList();
            return userData;
        }

        [HttpGet("GetUserByUsername")]
        public Task<User> GetUserByUsername(string username)
        {
            var user = _db.Users.FirstOrDefaultAsync(m => m.UserName == username);
            return user;
        }

        [HttpPost("CreateUser")]
        public async Task<ActionResult> AddUser(User newUser)
        {
            var userCheck = GetUserByUsername(newUser.UserName);
            if(userCheck != null)
            {
                return BadRequest("Username Already Exist");
            }
            _db.Users.Add(newUser);
            _db.SaveChanges();
            return Ok(
                new ResponseGlobal()
                {
                    ResponseCode = ((int)System.Net.HttpStatusCode.OK),
                    Message = "User Created Successfully",
                    Data = newUser
                });
        }

        [HttpPost("Login")]
        public async Task<ActionResult> Login(User userLogin)
        {
            if (userLogin == null)
                return BadRequest("Invalid login details");

            User user = _db.Users.FirstOrDefault(m => m.UserName == userLogin.UserName);
            if (user == null)
                return NotFound("User Not Found!");

            if (user.Password != userLogin.Password)
                return BadRequest("Wrong Credentails");

            return Ok(
                new ResponseGlobal()
                {
                    ResponseCode = ((int)System.Net.HttpStatusCode.OK),
                    Message = "Logged In"
                }) ;
        }


    }
}