using System;
using System.Collections.Generic;
using API.QUAKEKIT.Helpers;
using API.QUAKEKIT.Models;
using API.QUAKEKIT.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.QUAKEKIT.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("[action]")]
        public IActionResult Token(AuthenticateModel model)
        {
            try
            {
                User user = _userService.Get(model);

                if (user == null)
                {
                    if (this.GetLanguage() == "TR")
                    {
                        return BadRequest(new { message = "Kullanıcı adı veya şifre yanlış." });
                    }
                    else
                    {
                        return BadRequest(new { message = "Username or password is incorrect." });
                    }
                }
                return Ok(_userService.Token(model));
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.InnerException.Message });
            }
        }

        [HttpGet]
        public ActionResult<List<User>> Get()
        {
            return _userService.Get();
        }

        [AllowAnonymous]
        [HttpGet("{id:length(24)}", Name = "GetUser")]
        public ActionResult<User> Get(string id)
        {
            var user = _userService.Get(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult<User> Create(User user)
        {
            _userService.Create(user);

            return CreatedAtRoute("GetUser", new { id = user.uID.ToString() }, user);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, User userIn)
        {
            var user = _userService.Get(id);

            if (user == null)
            {
                return NotFound();
            }

            _userService.Update(id, userIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var user = _userService.Get(id);

            if (user == null)
            {
                return NotFound();
            }

            _userService.Remove(user.uID);

            return NoContent();
        }
    }
}