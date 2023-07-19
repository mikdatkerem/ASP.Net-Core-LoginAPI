using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using WebAPI.Models;
using WebAPI.Repositories;
using System.Xml.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly RepositoryContext _context;

        public UserController(RepositoryContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var users = _context.Users;
            return Ok(users);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetUser([FromRoute(Name = "id")] int id)
        {
            try
            {
                var user = _context.Users.Where(a => a.Id.Equals(id)).SingleOrDefault();

                if (user == null)
                {
                    return NotFound();
                }

                return Ok(user);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        [HttpPost]
        [Route("SignUp")]
        public IActionResult CreateUser([FromBody] User user)
        {
            try
            {
                var name1 = _context.Users.Where(a => a.Name.Equals(user.Name)).SingleOrDefault();
                if (user is null || name1!=null)
                    return BadRequest(); // 400              
                _context.Users.Add(user);
                _context.SaveChanges();

                return StatusCode(201, user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteUser([FromRoute(Name = "id")] int id)
        {
            try
            {
                var entity = _context.Users.Where(a => a.Id.Equals(id)).SingleOrDefault();

                if (entity is null)
                    return NotFound(new
                    {
                        statusCode = 404,
                        message = $"Book with id:{id} could not found."
                    });
                _context.Users.Remove(entity);
                _context.SaveChanges();

                return NoContent();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        
        [HttpPost]
        [Route("login")]
        public IActionResult Login(string name, int password)
        {
            var name1 = _context.Users.Where(a => a.Name.Equals(name)).SingleOrDefault();
            var password1 = _context.Users.Where(a => a.password.Equals(password)).SingleOrDefault();
            if (name1!=null&& password1 != null)
                return Ok();
            return NotFound(new
            {
                statusCode = 404,
                message = $"Kullanici adi veya parola yanlis. Tekrar Deneyiniz."
            });
        }
    }
}