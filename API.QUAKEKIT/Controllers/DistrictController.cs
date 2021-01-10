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
    public class DistrictController : ControllerBase
    {
        private readonly DistrictService _districtService;
        public DistrictController(DistrictService districtService)
        {
            _districtService = districtService;
        }
        [HttpGet]
        public ActionResult<List<District>> Get()
        {
            return _districtService.Get();
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult<District> Create(District district)
        {
            _districtService.Create(district);

            return CreatedAtRoute("GetDistrict", new { id = district.dID.ToString() }, district);
        }

        [AllowAnonymous]
        [HttpGet("{id:length(24)}", Name = "GetDistrict")]
        public ActionResult<District> Get(string id)
        {
            var district = _districtService.Get(id);

            if (district == null)
            {
                return NotFound();
            }

            return district;
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, District districtIn)
        {
            var district = _districtService.Get(id);

            if (district == null)
            {
                return NotFound();
            }

            _districtService.Update(id, districtIn);

            return NoContent();
        }
        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var district = _districtService.Get(id);

            if (district == null)
            {
                return NotFound();
            }

            _districtService.Remove(district.dID);

            return NoContent();
        }
    }
}