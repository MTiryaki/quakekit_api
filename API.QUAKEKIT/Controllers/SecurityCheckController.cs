using System.Collections.Generic;
using API.QUAKEKIT.Models;
using API.QUAKEKIT.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.QUAKEKIT.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class SecurityCheckController : ControllerBase
    {
        private readonly SecurityCheckService _securityCheckService;
        public SecurityCheckController(SecurityCheckService securityCheckService)
        {
            _securityCheckService = securityCheckService;
        }
        [HttpGet]
        public ActionResult<List<SecurityCheck>> Get()
        {
            return _securityCheckService.Get();
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult<SecurityCheck> Create(SecurityCheck securityCheck)
        {
            _securityCheckService.Create(securityCheck);

            return CreatedAtRoute("GetSecurityCheck", new { id = securityCheck.scID.ToString() }, securityCheck);
        }

        [AllowAnonymous]
        [HttpGet("{id:length(24)}", Name = "GetSecurityCheck")]
        public ActionResult<SecurityCheck> Get(string id)
        {
            var securityCheck = _securityCheckService.Get(id);

            if (securityCheck == null)
            {
                return NotFound();
            }

            return securityCheck;
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, SecurityCheck securityCheckIn)
        {
            var securityCheck = _securityCheckService.Get(id);

            if (securityCheck == null)
            {
                return NotFound();
            }

            _securityCheckService.Update(id, securityCheckIn);

            return NoContent();
        }
        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var securityCheck = _securityCheckService.Get(id);

            if (securityCheck == null)
            {
                return NotFound();
            }

            _securityCheckService.Remove(securityCheck.scID);

            return NoContent();
        }
    }
}