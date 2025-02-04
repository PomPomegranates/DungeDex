using DungeDexBE.Interfaces.ServiceInterfaces;
using DungeDexBE.Services;
using Microsoft.AspNetCore.Mvc;
using DungeDexBE.Models;

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
        public IActionResult GetUsers()
        {
            var result = _userService.GetUsers();

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

        public IActionResult GetUserByName(string name)
        {
            var result = _userService.GetUserByName(name);

            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }

        }



        [HttpPost("{newUser}")]
        public IActionResult PostUser(User newUser)
        {
            var result = _userService.PostUser(newUser);
            if (result.Item2 == "Success")
            {
                return Created($"api/User{newUser.UserName}", newUser);
            }
            else
            {
                return BadRequest(result.Item1);
            }
        }



        
    }
}
