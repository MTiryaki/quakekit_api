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
    public class DamageReportController : ControllerBase
    {
        private readonly DamageReportService _damageReportService;
        public DamageReportController(DamageReportService damageReportService)
        {
            _damageReportService = damageReportService;
        }
        [HttpGet]
        public ActionResult<List<DamageReport>> Get()
        {
            return _damageReportService.Get();
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult<DamageReport> Create(DamageReport damageReport)
        {
            _damageReportService.Create(damageReport);

            return CreatedAtRoute("GetDamageReport", new { id = damageReport.drID.ToString() }, damageReport);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, DamageReport damageReportIn)
        {
            var damageReport = _damageReportService.Get(id);

            if (damageReport == null)
            {
                return NotFound();
            }

            _damageReportService.Update(id, damageReportIn);

            return NoContent();
        }
        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var damageReport = _damageReportService.Get(id);

            if (damageReport == null)
            {
                return NotFound();
            }

            _damageReportService.Remove(damageReport.drID);

            return NoContent();
        }
    }
}