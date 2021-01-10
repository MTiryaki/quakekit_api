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
    public class EmergencyContactController : ControllerBase
    {
        private readonly EmergencyContactService _emergencyContactService;
        public EmergencyContactController(EmergencyContactService emergencyContactService)
        {
            _emergencyContactService = emergencyContactService;
        }
        [HttpGet]
        public ActionResult<List<EmergencyContact>> Get()
        {
            return _emergencyContactService.Get();
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult<EmergencyContact> Create(EmergencyContact emergencyContact)
        {
            _emergencyContactService.Create(emergencyContact);

            return CreatedAtRoute("GetEmergencyContact", new { id = emergencyContact.ecID.ToString() }, emergencyContact);
        }

        [AllowAnonymous]
        [HttpGet("{id:length(24)}", Name = "GetEmergencyContact")]
        public ActionResult<EmergencyContact> Get(string id)
        {
            var emergencyContact = _emergencyContactService.Get(id);

            if (emergencyContact == null)
            {
                return NotFound();
            }

            return emergencyContact;
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, EmergencyContact emergencyContactIn)
        {
            var emergencyContact = _emergencyContactService.Get(id);

            if (emergencyContact == null)
            {
                return NotFound();
            }

            _emergencyContactService.Update(id, emergencyContactIn);

            return NoContent();
        }
        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var emergencyContact = _emergencyContactService.Get(id);

            if (emergencyContact == null)
            {
                return NotFound();
            }

            _emergencyContactService.Remove(emergencyContact.ecID);

            return NoContent();
        }
    }
}