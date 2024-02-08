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

        public UserController(ILogger<UserController> logger, IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("all")]
        public ActionResult<IEnumerable<User>> GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }

        [HttpPost(Name = "AddUser")]
        public IActionResult AddUser([Required] string name, [Required] string password, [Required] bool isAdmin)
        {
            var user = new User(name, password, isAdmin);
            if(_userService.Add(user))
                return Ok(user);
            else
                return BadRequest();
        }

        [HttpGet("{id}")]
        public IActionResult Delete([FromRoute] Guid id)
        {
            if (_userService.Delete(id))
                return NoContent();
            else
                return BadRequest();
        }
    }
}
