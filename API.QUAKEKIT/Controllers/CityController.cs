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
    public class CityController : ControllerBase
    {
        private readonly CityService _cityService;
        public CityController(CityService cityService)
        {
            _cityService = cityService;
        }
        [HttpGet]
        public ActionResult<List<City>> Get()
        {
            return _cityService.Get();
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult<City> Create(City city)
        {
            _cityService.Create(city);

            return CreatedAtRoute("GetCity", new { id = city.cID.ToString() }, city);
        }

        [AllowAnonymous]
        [HttpGet("{id:length(24)}", Name = "GetCity")]
        public ActionResult<City> Get(string id)
        {
            var city = _cityService.Get(id);

            if (city == null)
            {
                return NotFound();
            }

            return city;
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, City cityIn)
        {
            var city = _cityService.Get(id);

            if (city == null)
            {
                return NotFound();
            }

            _cityService.Update(id, cityIn);

            return NoContent();
        }
        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var city = _cityService.Get(id);

            if (city == null)
            {
                return NotFound();
            }

            _cityService.Remove(city.cID);

            return NoContent();
        }
    }
}