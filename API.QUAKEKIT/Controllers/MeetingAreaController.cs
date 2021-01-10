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
    public class MeetingAreaController : ControllerBase
    {
        private readonly MeetingAreaService _meetingAreaService;
        public MeetingAreaController(MeetingAreaService meetingAreaService)
        {
            _meetingAreaService = meetingAreaService;
        }
        [HttpGet]
        public ActionResult<List<MeetingArea>> Get()
        {
            return _meetingAreaService.Get();
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult<MeetingArea> Create(MeetingArea meetingArea)
        {
            _meetingAreaService.Create(meetingArea);

            return CreatedAtRoute("GetMeetingArea", new { id = meetingArea.maID.ToString() }, meetingArea);
        }

        [AllowAnonymous]
        [HttpGet("{id:length(24)}", Name = "GetMeetingArea")]
        public ActionResult<MeetingArea> Get(string id)
        {
            var meetingArea = _meetingAreaService.Get(id);

            if (meetingArea == null)
            {
                return NotFound();
            }

            return meetingArea;
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, MeetingArea meetingAreaIn)
        {
            var meetingArea = _meetingAreaService.Get(id);

            if (meetingArea == null)
            {
                return NotFound();
            }

            _meetingAreaService.Update(id, meetingAreaIn);

            return NoContent();
        }
        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var meetingArea = _meetingAreaService.Get(id);

            if (meetingArea == null)
            {
                return NotFound();
            }

            _meetingAreaService.Remove(meetingArea.maID);

            return NoContent();
        }
    }
}