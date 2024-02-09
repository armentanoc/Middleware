using Microsoft.AspNetCore.Mvc;
using Middleware.Application;
using Middleware.Domain;
using System.ComponentModel.DataAnnotations;

namespace Middleware.WebAPI.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(
            ILogger<UserController> logger, 
            IUserService userService
            )
        {
            _userService = userService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }

        [HttpPost(Name = "AddUser")]
        public IActionResult AddUser(
            [Required] string name, 
            [Required][EmailAddress] string email
            )
        {
            var user = new User(name, email);
            if(_userService.Add(user))
                return Ok(user);
            else
                return BadRequest();
        }

        [HttpGet("{id}")]
        public ActionResult Get(
            [FromRoute] int id
            )
        {
            if (_userService.Get(id) is not User user)
                throw new Exception($"User with id {id} not found");
            return Ok(user);
            
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(
            [FromRoute] int id
            )
        {
            if (_userService.Delete(id))
                return NoContent();
            else
                return BadRequest();
        }
    }
}
