using DungeDexBE.Interfaces.ServiceInterfaces;
using DungeDexBE.Services;
using Microsoft.AspNetCore.Mvc;

namespace DungeDexBE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult getUsers()
        {
            var result = _userService.getUsers();

            if (result != null && result.Count > 0)
            {
                return Ok(result);
            }
            else if (result is null)
            {
                return BadRequest();
            }
            else if (result.Count == 0)
            {
                return NotFound();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet ("{name}")]

        public IActionResult getUserByName(string name)
        {
            var result = _userService.getuserByName(name);

            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }

        }
    }
}
