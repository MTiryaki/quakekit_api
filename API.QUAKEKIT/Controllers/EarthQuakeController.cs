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
    public class EarthQuakeController : ControllerBase
    {
        private readonly EarthQuakeService _earthQuakeService;
        public EarthQuakeController(EarthQuakeService earthQuakeService)
        {
            _earthQuakeService = earthQuakeService;
        }
        [HttpGet]
        public ActionResult<List<EarthQuake>> Get()
        {
            return _earthQuakeService.Get();
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult<DamageReport> Create(EarthQuake earthQuake)
        {
            _earthQuakeService.Create(earthQuake);

            return CreatedAtRoute("GetEarthQuake", new { id = earthQuake.eqID.ToString() }, earthQuake);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, EarthQuake earthQuakeIn)
        {
            var earthQuake = _earthQuakeService.Get(id);

            if (earthQuake == null)
            {
                return NotFound();
            }

            _earthQuakeService.Update(id, earthQuakeIn);

            return NoContent();
        }
        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var earthQuake = _earthQuakeService.Get(id);

            if (earthQuake == null)
            {
                return NotFound();
            }

            _earthQuakeService.Remove(earthQuake.eqID);

            return NoContent();
        }
    }
}
